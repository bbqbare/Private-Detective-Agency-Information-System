namespace cursova {
    public class Elements {
        public int id { get; set; }
        public int id_client { get; set; }
        public int id_detective { get; set; }
        public string title { get; set; } = "";
        public string status { get; set; } = "";
        public DateOnly start_date { get; set; }
        public string client_pib { get; set; } = "";
        public string client_phone { get; set; } = "";
        public string client_address { get; set; } = "";
        public string client_passport { get; set; } = "";
        public string detective_pib { get; set; } = "";
        public string detective_spec { get; set; } = "";
        public string suspects { get; set; } = "";
        public string evidences { get; set; } = "";
    }
}