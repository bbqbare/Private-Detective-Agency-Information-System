using System.Data;
using Dapper;
using Npgsql;

namespace cursova {
    public class CaseRepository {

        private IDbConnection OpenConn() {
            var conn = new NpgsqlConnection(AppConfig.ConnectionString);
            conn.Open();
            return conn;
        }

        public IEnumerable<Elements> GetAll() {
            using var db = OpenConn();
            return db.Query<Elements>(@"
                SELECT c.id, c.id_client, c.id_detective, c.title, c.status, c.start_date,
                       cl.pib           AS client_pib,
                       cl.phone_number  AS client_phone,
                       cl.address       AS client_address,
                       cl.passport_info AS client_passport,
                       d.pib            AS detective_pib,
                       d.specialization AS detective_spec,
                       (SELECT string_agg(s.pib, ', ')
                          FROM Suspect s WHERE s.id_case = c.id) AS suspects,
                       (SELECT string_agg(e.description, '; ')
                          FROM Evidence e
                         WHERE e.id_case = c.id
                           AND e.type != 'Заміна детективу') AS evidences
                FROM Cases c
                JOIN Client   cl ON c.id_client    = cl.id
                JOIN Detectiv  d ON c.id_detective  = d.id").ToList();
        }

        public void Add(int clId, int detId, string title, string status) {
            using var db = OpenConn();
            db.Execute(
                "INSERT INTO Cases (id_client, id_detective, title, status, start_date) " +
                "VALUES (@clId, @detId, @title, @status, CURRENT_DATE)",
                new { clId, detId, title, status }
            );
        }

        public void UpdateStatus(int id, string status) {
            using var db = OpenConn();
            db.Execute("UPDATE Cases SET status = @status WHERE id = @id", new { status, id });
        }

        public void ChangeDetective(int caseId, int newDetId) {
            using var db = OpenConn();
            db.Execute("UPDATE Cases SET id_detective = @newDetId WHERE id = @caseId", new { newDetId, caseId });
        }

        public void Delete(int id) {
            using var db = OpenConn();
            using var tx = db.BeginTransaction();
            try {
                db.Execute("DELETE FROM Evidence WHERE id_case = @id", new { id }, tx);
                db.Execute("DELETE FROM Suspect  WHERE id_case = @id", new { id }, tx);
                db.Execute("DELETE FROM Cases    WHERE id      = @id", new { id }, tx);
                tx.Commit();
            }
            catch { 
                tx.Rollback();
                throw;
            }
        }

        public void AddClient(string pib, string phone, string address, string passport) {
            using var db = OpenConn();
            db.Execute("INSERT INTO Client (pib, phone_number, address, passport_info) VALUES (@pib, @phone, @address, @passport)",
                new { pib, phone, address, passport }
            );
        }

        public void AddDetective(string pib, string spec) {
            using var db = OpenConn();
            db.Execute("INSERT INTO Detectiv (pib, specialization) VALUES (@pib, @spec)", new { pib, spec });
        }

        public void AddSuspect(int caseId, string pib, string desc) {
            using var db = OpenConn();
            db.Execute("INSERT INTO Suspect (id_case, pib, description) VALUES (@caseId, @pib, @desc)", new { caseId, pib, desc });
        }

        public void AddEvidence(int caseId, string type, string desc) {
            using var db = OpenConn();
            db.Execute("INSERT INTO Evidence (id_case, type, description) VALUES (@caseId, @type, @desc)", new { caseId, type, desc });
        }

        public IEnumerable<dynamic> GetClients() {
            using var db = OpenConn();
            return db.Query("SELECT id, pib FROM Client ORDER BY pib").ToList();
        }

        public IEnumerable<dynamic> GetDetectives() {
            using var db = OpenConn();
            return db.Query("SELECT id, pib FROM Detectiv ORDER BY pib").ToList();
        }

        public string GetFullCaseReport(Elements c) {
            using var db = OpenConn();

            var suspects = db.Query(
                "SELECT pib, description FROM Suspect WHERE id_case = @id ORDER BY id",
                new { id = c.id }
            ).ToList();

            var evidences = db.Query(
                "SELECT type, COALESCE(description, '') AS description " +
                "FROM Evidence WHERE id_case = @id AND type != 'Заміна детективу' ORDER BY id",
                new { id = c.id }
            ).ToList();

            var changes = db.Query<string>(
                "SELECT description FROM Evidence WHERE id_case = @id AND type = 'Заміна детективу' ORDER BY id",
                new { id = c.id }
            ).ToList();

            string suspectsText = suspects.Any()
                ? string.Join("\n", suspects.Select(s => $" - {s.pib}: {s.description}"))
                : " - Немає";
            string evidencesText = evidences.Any()
                ? string.Join("\n", evidences.Select(e => $" - [{e.type}] {e.description}"))
                : " - Немає";
            string changesText = changes.Any()
                ? string.Join("\n", changes.Select(ch => $" - {ch}"))
                : " - Немає";

            return
                $"ID справи: {c.id}\nНазва: {c.title}\nСтатус: {c.status}\nДата: {c.start_date:dd.MM.yyyy}\n\n" +
                $"Клієнт: {c.client_pib}\nТелефон: {c.client_phone}\nАдреса: {c.client_address}\nПаспорт: {c.client_passport}\n\n" +
                $"Детектив: {c.detective_pib} ({c.detective_spec})\n\n" +
                $"Історія замін:\n{changesText}\n\n" +
                $"Підозрювані:\n{suspectsText}\n\n" +
                $"Докази:\n{evidencesText}";
        }
    }
}