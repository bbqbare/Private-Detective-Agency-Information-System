using System.Drawing.Drawing2D;
namespace cursova
{
    public partial class Form1 : Form
    {
        private readonly CaseRepository _repo = new CaseRepository();

        public Form1()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = true;

            btnAddClient.Click += (s, e) => OpenAddClient();
            btnAddDetective.Click += (s, e) => OpenAddDetective();
            button2.Click += (s, e) => OpenAddSuspect();
            button1.Click += (s, e) => OpenAddEvidence();
            btnAddCase.Click += (s, e) => OpenAddCase();
            btnChangeDet.Click += (s, e) => OpenChangeDetective();
            btnReport.Click += (s, e) => OpenReport();
            btnStatus.Click += (s, e) => OpenChangeStatus();
            btnDelete.Click += (s, e) => ExecuteDelete();

            LoadData();
            ApplyRoundedButtons();
        }

        private void ApplyRoundedButtons()
        {
            int radius = 10;
            var buttons = this.Controls.OfType<Button>();

            foreach (var btn in buttons)
            {
                GraphicsPath path = new GraphicsPath();
                path.AddArc(0, 0, radius, radius, 180, 90);
                path.AddArc(btn.Width - radius, 0, radius, radius, 270, 90);
                path.AddArc(btn.Width - radius, btn.Height - radius, radius, radius, 0, 90);
                path.AddArc(0, btn.Height - radius, radius, radius, 90, 90);
                btn.Region = new Region(path);
            }
        }

        private static void LettersOnly(TextBox tb) =>
            tb.KeyPress += (s, e) => {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != ' ' && !char.IsLetter(e.KeyChar))
                    e.Handled = true;
            };
        private static void DigitsOnly(TextBox tb) =>
            tb.KeyPress += (s, e) => {
                if (e.KeyChar != (char)Keys.Back && !char.IsDigit(e.KeyChar) && e.KeyChar != '+')
                    e.Handled = true;
            };
        private static void LettersAndDash(TextBox tb) =>
            tb.KeyPress += (s, e) => {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != ' ' && e.KeyChar != '-' && !char.IsLetter(e.KeyChar))
                    e.Handled = true;
            };

        private void LoadData() {
            try { 
                dataGridView1.DataSource = _repo.GetAll().ToList();
            }
            catch (Exception ex) { 
                MessageBox.Show("Помилка бази: " + ex.Message);
            }
        }

        private Elements? SelectedCase() {
            if (dataGridView1.CurrentRow?.DataBoundItem is Elements c) return c;
            MessageBox.Show("Оберіть справу");
            return null;
        }

        private void OpenAddSuspect() {
            if (SelectedCase() is not Elements c) return;

            var tPib = new TextBox { Location = new Point(20, 40), Width = 290 };
            var tDesc = new TextBox { Location = new Point(20, 100), Width = 290, Multiline = true, Height = 60 };
            LettersAndDash(tPib);
            LettersOnly(tDesc);

            var btn = FormFactory.CreateDefaultButton("Зберегти", new Point(20, 180), 290, DialogResult.OK);
            using var f = FormFactory.CreateDialog("Новий підозрюваний", new Size(350, 280), new Control[] {
                new Label { Text = "ПІБ підозрюваного:", Location = new Point(20, 15), AutoSize = true }, tPib,
                new Label { Text = "Прикмети:",          Location = new Point(20, 75), AutoSize = true }, tDesc, btn 
            });

            if (f.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(tPib.Text)) {
                _repo.AddSuspect(c.id, tPib.Text, tDesc.Text);
                LoadData();
            }
        }

        private void OpenAddEvidence() {
            if (SelectedCase() is not Elements c) return;

            var tType = new TextBox { Location = new Point(20, 40), Width = 290 };
            var tDesc = new TextBox { Location = new Point(20, 100), Width = 290, Multiline = true, Height = 60 };
            LettersOnly(tType);
            LettersOnly(tDesc);

            var btn = FormFactory.CreateDefaultButton("Зберегти", new Point(20, 180), 290, DialogResult.OK);
            using var f = FormFactory.CreateDialog("Новий доказ", new Size(350, 280), new Control[] {
                new Label { Text = "Тип доказу:",  Location = new Point(20, 15), AutoSize = true }, tType,
                new Label { Text = "Опис доказу:", Location = new Point(20, 75), AutoSize = true }, tDesc, btn 
            });

            if (f.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(tType.Text)) {
                _repo.AddEvidence(c.id, tType.Text, tDesc.Text);
                LoadData();
            }
        }

        private void OpenAddClient() {
            var tPib = new TextBox { Location = new Point(20, 40), Width = 290 };
            var tPhone = new TextBox { Location = new Point(20, 100), Width = 290 };
            var tAddress = new TextBox { Location = new Point(20, 160), Width = 290 };
            var tPass = new TextBox { Location = new Point(20, 220), Width = 290 };
            LettersOnly(tPib);
            DigitsOnly(tPhone);
            DigitsOnly(tPass);

            var btn = FormFactory.CreateDefaultButton("Зберегти", new Point(20, 260), 290, DialogResult.OK);
            using var f = FormFactory.CreateDialog("Новий клієнт", new Size(350, 360), new Control[] {
                new Label { Text = "ПІБ:",     Location = new Point(20, 15),  AutoSize = true }, tPib,
                new Label { Text = "Телефон:", Location = new Point(20, 75),  AutoSize = true }, tPhone,
                new Label { Text = "Адреса:",  Location = new Point(20, 135), AutoSize = true }, tAddress,
                new Label { Text = "Паспорт:", Location = new Point(20, 195), AutoSize = true }, tPass, btn 
            });

            if (f.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(tPib.Text)) {
                _repo.AddClient(tPib.Text, tPhone.Text, tAddress.Text, tPass.Text);
                LoadData();
            }
        }

        private void OpenAddDetective() {
            var tPib = new TextBox { Location = new Point(20, 40), Width = 290 };
            var tSpec = new TextBox { Location = new Point(20, 100), Width = 290 };
            LettersOnly(tPib);
            LettersOnly(tSpec);

            var btn = FormFactory.CreateDefaultButton("Зберегти", new Point(20, 140), 290, DialogResult.OK);
            using var f = FormFactory.CreateDialog("Новий детектив", new Size(350, 240), new Control[] {
                new Label { Text = "ПІБ:",           Location = new Point(20, 15), AutoSize = true }, tPib,
                new Label { Text = "Спеціалізація:", Location = new Point(20, 75), AutoSize = true }, tSpec, btn 
            });

            if (f.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(tPib.Text)) {
                _repo.AddDetective(tPib.Text, tSpec.Text);
                LoadData();
            }
        }

        private void OpenAddCase() {
            var cls = _repo.GetClients().ToList();
            var dts = _repo.GetDetectives().ToList();
            if (!cls.Any() || !dts.Any()) { MessageBox.Show("Спочатку додайте клієнтів та детективів"); return; }

            var tTitle = new TextBox { Location = new Point(20, 40), Width = 290 };
            var cb1 = new ComboBox {
                DataSource = cls,
                DisplayMember = "pib",
                ValueMember = "id",
                Location = new Point(20, 100),
                Width = 290,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            var cb2 = new ComboBox {
                DataSource = dts,
                DisplayMember = "pib",
                ValueMember = "id",
                Location = new Point(20, 160),
                Width = 290,
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            var btn = FormFactory.CreateDefaultButton("Створити", new Point(20, 200), 290, DialogResult.OK);
            using var f = FormFactory.CreateDialog("Нова справа", new Size(350, 300), new Control[] {
                new Label { Text = "Назва:",    Location = new Point(20, 15),  AutoSize = true }, tTitle,
                new Label { Text = "Клієнт:",   Location = new Point(20, 75),  AutoSize = true }, cb1,
                new Label { Text = "Детектив:", Location = new Point(20, 135), AutoSize = true }, cb2, btn 
            });

            if (f.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(tTitle.Text)) {
                _repo.Add((int)cb1.SelectedValue!, (int)cb2.SelectedValue!, tTitle.Text, "Нова");
                LoadData();
            }
        }

        private void OpenChangeDetective() {
            if (SelectedCase() is not Elements c) return;

            var cb = new ComboBox {
                DataSource = _repo.GetDetectives().ToList(),
                DisplayMember = "pib",
                ValueMember = "id",
                Location = new Point(20, 40),
                Width = 290,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            var tReason = new TextBox { Location = new Point(20, 100), Width = 290 };
            LettersOnly(tReason);

            var btn = FormFactory.CreateDefaultButton("Зберегти", new Point(20, 140), 290, DialogResult.OK);
            using var f = FormFactory.CreateDialog("Заміна детектива", new Size(350, 250), new Control[] {
                new Label { Text = "Новий детектив:", Location = new Point(20, 15), AutoSize = true }, cb,
                new Label { Text = "Причина заміни:", Location = new Point(20, 75), AutoSize = true }, tReason, btn 
            });

            if (f.ShowDialog() == DialogResult.OK && cb.SelectedValue != null) {
                _repo.ChangeDetective(c.id, (int)cb.SelectedValue);
                _repo.AddEvidence(c.id, "Заміна детективу", $"Новий детектив: {cb.Text}. Причина: {tReason.Text}");
                LoadData();
            }
        }

        private void OpenReport() {
            if (SelectedCase() is not Elements c) return;

            using var rf = new Form { Text = "Картка справи", Size = new Size(500, 520), StartPosition = FormStartPosition.CenterParent };
            rf.Controls.Add(new RichTextBox {
                Dock = DockStyle.Fill,
                Text = _repo.GetFullCaseReport(c),
                ReadOnly = true,
                Font = new Font("Segoe UI", 10),
                BackColor = Color.FromArgb(20, 20, 25),
                ForeColor = Color.FromArgb(200, 200, 220),
            });
            rf.ShowDialog();
        }

        private void OpenChangeStatus() {
            if (SelectedCase() is not Elements c) return;

            var cb = new ComboBox {
                DataSource = new[] { "Нова", "В процесі", "Закрита", "В архіві" },
                Location = new Point(20, 20),
                Width = 200,
                DropDownStyle = ComboBoxStyle.DropDownList,
                BackColor = Color.FromArgb(50, 50, 50),
                ForeColor = Color.White
            };
            var btn = FormFactory.CreateDefaultButton("Зберегти", new Point(20, 60), 200, DialogResult.OK);
            using var f = FormFactory.CreateDialog("Статус", new Size(260, 160), new Control[] { cb, btn });

            if (f.ShowDialog() == DialogResult.OK) {
                _repo.UpdateStatus(c.id, cb.Text);
                LoadData();
            }
        }

        private void ExecuteDelete() {
            if (SelectedCase() is not Elements c) return;
            if (MessageBox.Show($"Видалити справу «{c.title}»?", "Увага", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) {
                _repo.Delete(c.id);
                LoadData();
            }
        }

    }
}