using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace cursova {
    partial class Form1 {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            dataGridView1 = new DataGridView();
            btnAddClient = new Button();
            btnAddDetective = new Button();
            btnAddCase = new Button();
            btnChangeDet = new Button();
            btnReport = new Button();
            btnStatus = new Button();
            btnDelete = new Button();
            button1 = new Button();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 75);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1801, 900);
            dataGridView1.TabIndex = 0;
            dataGridView1.BackgroundColor = Color.FromArgb(25, 25, 35);
            dataGridView1.GridColor = Color.FromArgb(40, 40, 60);
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(40, 40, 60);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(200, 200, 220);
            dataGridView1.DefaultCellStyle.BackColor = Color.FromArgb(25, 25, 35);
            dataGridView1.DefaultCellStyle.ForeColor = Color.FromArgb(200, 200, 220);
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(80, 80, 150);

            btnAddClient.BackColor = Color.FromArgb(80, 80, 150);
            btnAddClient.FlatAppearance.BorderSize = 0;
            btnAddClient.FlatStyle = FlatStyle.Flat;
            btnAddClient.ForeColor = Color.White;
            btnAddClient.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, 100, 180);
            btnAddClient.FlatAppearance.MouseDownBackColor = Color.FromArgb(60, 60, 120);
            btnAddClient.Location = new Point(12, 15);
            btnAddClient.Name = "btnAddClient";
            btnAddClient.Size = new Size(110, 45);
            btnAddClient.TabIndex = 5;
            btnAddClient.Text = "+ Клієнт";
            btnAddClient.UseVisualStyleBackColor = false;
            btnAddClient.Cursor = Cursors.Hand;
 
            btnAddDetective.BackColor = Color.FromArgb(80, 80, 150);
            btnAddDetective.FlatAppearance.BorderSize = 0;
            btnAddDetective.FlatStyle = FlatStyle.Flat;
            btnAddDetective.ForeColor = Color.White;
            btnAddDetective.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, 100, 180);
            btnAddDetective.FlatAppearance.MouseDownBackColor = Color.FromArgb(60, 60, 120);
            btnAddDetective.Location = new Point(128, 15);
            btnAddDetective.Name = "btnAddDetective";
            btnAddDetective.Size = new Size(110, 45);
            btnAddDetective.TabIndex = 6;
            btnAddDetective.Text = "+ Детектив";
            btnAddDetective.UseVisualStyleBackColor = false;

            btnAddCase.BackColor = Color.FromArgb(80, 80, 150);
            btnAddCase.FlatAppearance.BorderSize = 0;
            btnAddCase.FlatStyle = FlatStyle.Flat;
            btnAddCase.ForeColor = Color.White;
            btnAddCase.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, 100, 180);
            btnAddCase.FlatAppearance.MouseDownBackColor = Color.FromArgb(60, 60, 120);
            btnAddCase.Location = new Point(500, 15);
            btnAddCase.Name = "btnAddCase";
            btnAddCase.Size = new Size(130, 45);
            btnAddCase.TabIndex = 7;
            btnAddCase.Text = "Додати справу";
            btnAddCase.UseVisualStyleBackColor = false;

            btnChangeDet.BackColor = Color.FromArgb(80, 80, 150);
            btnChangeDet.FlatAppearance.BorderSize = 0;
            btnChangeDet.FlatStyle = FlatStyle.Flat;
            btnChangeDet.ForeColor = Color.White;
            btnAddCase.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, 100, 180);
            btnAddCase.FlatAppearance.MouseDownBackColor = Color.FromArgb(60, 60, 120);
            btnChangeDet.Location = new Point(645, 15);
            btnChangeDet.Name = "btnChangeDet";
            btnChangeDet.Size = new Size(160, 45);
            btnChangeDet.TabIndex = 1;
            btnChangeDet.Text = "Замінити детектив";
            btnChangeDet.UseVisualStyleBackColor = false;

            btnReport.BackColor = Color.FromArgb(80, 80, 150);
            btnReport.FlatAppearance.BorderSize = 0;
            btnReport.FlatStyle = FlatStyle.Flat;
            btnReport.ForeColor = Color.White;
            btnAddCase.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, 100, 180);
            btnAddCase.FlatAppearance.MouseDownBackColor = Color.FromArgb(60, 60, 120);
            btnReport.Location = new Point(820, 15);
            btnReport.Name = "btnReport";
            btnReport.Size = new Size(150, 45);
            btnReport.TabIndex = 2;
            btnReport.Text = "Повний звіт";
            btnReport.UseVisualStyleBackColor = false;

            btnStatus.BackColor = Color.FromArgb(80, 80, 150);
            btnStatus.FlatAppearance.BorderSize = 0;
            btnStatus.FlatStyle = FlatStyle.Flat;
            btnStatus.ForeColor = Color.White;
            btnAddCase.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, 100, 180);
            btnAddCase.FlatAppearance.MouseDownBackColor = Color.FromArgb(60, 60, 120);
            btnStatus.Location = new Point(985, 15);
            btnStatus.Name = "btnStatus";
            btnStatus.Size = new Size(140, 45);
            btnStatus.TabIndex = 3;
            btnStatus.Text = "Змінити статус";
            btnStatus.UseVisualStyleBackColor = false;

            btnDelete.BackColor = Color.FromArgb(80, 80, 150);
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.ForeColor = Color.White;
            btnAddCase.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, 100, 180);
            btnAddCase.FlatAppearance.MouseDownBackColor = Color.FromArgb(60, 60, 120);
            btnDelete.Location = new Point(1140, 15);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(140, 45);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "Видалити справу";
            btnDelete.UseVisualStyleBackColor = false;

            button1.BackColor = Color.FromArgb(80, 80, 150);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = Color.White;
            btnAddCase.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, 100, 180);
            btnAddCase.FlatAppearance.MouseDownBackColor = Color.FromArgb(60, 60, 120);
            button1.Location = new Point(384, 15);
            button1.Name = "button1";
            button1.Size = new Size(110, 45);
            button1.TabIndex = 9;
            button1.Text = "+ Доказ";
            button1.UseVisualStyleBackColor = false;
 
            button2.BackColor = Color.FromArgb(80, 80, 150);
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.ForeColor = Color.White;
            btnAddCase.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, 100, 180);
            btnAddCase.FlatAppearance.MouseDownBackColor = Color.FromArgb(60, 60, 120);
            button2.Location = new Point(244, 15);
            button2.Name = "button2";
            button2.Size = new Size(134, 45);
            button2.TabIndex = 8;
            button2.Text = "+ Підозрюваний";
            button2.UseVisualStyleBackColor = false;

            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(15, 15, 20);
            ClientSize = new Size(1920, 1055);
            Controls.Add(button1);
            Controls.Add(button2);
            Controls.Add(btnAddCase);
            Controls.Add(btnAddDetective);
            Controls.Add(btnAddClient);
            Controls.Add(btnDelete);
            Controls.Add(btnStatus);
            Controls.Add(btnReport);
            Controls.Add(btnChangeDet);
            Controls.Add(dataGridView1);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Детективне агентство";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnChangeDet;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnStatus;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAddClient;
        private System.Windows.Forms.Button btnAddDetective;
        private System.Windows.Forms.Button btnAddCase;
        private Button button1;
        private Button button2;
    }
}