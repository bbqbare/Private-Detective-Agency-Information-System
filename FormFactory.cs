namespace cursova
{
    public static class FormFactory
    {
        private static readonly Color BgColor = Color.FromArgb(15, 15, 20);
        private static readonly Color AccentColor = Color.FromArgb(80, 80, 150);
        private static readonly Color TextColor = Color.FromArgb(200, 200, 220);

        public static Form CreateDialog(string title, Size size, Control[] controls)
        {
            Form f = new Form
            {
                Text = title,
                Size = size,
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                BackColor = BgColor
            };
            foreach (Control c in controls) ApplyTheme(c);
            f.Controls.AddRange(controls);
            return f;
        }

        private static void ApplyTheme(Control c)
        {
            c.ForeColor = TextColor;
            if (c is TextBox || c is ComboBox) c.BackColor = Color.FromArgb(30, 30, 40);
            else if (c is Label) c.BackColor = Color.Transparent;
            if (c is ComboBox cb) cb.FlatStyle = FlatStyle.Flat;
        }

        public static Button CreateDefaultButton(string text, Point pos, int width, DialogResult res) =>
            new Button
            {
                Text = text,
                Location = pos,
                Width = width,
                Height = 40,
                DialogResult = res,
                BackColor = AccentColor,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 },
                Cursor = Cursors.Hand
            };
    }
}