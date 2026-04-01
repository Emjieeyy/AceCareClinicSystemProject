namespace AceCareClinicSystem.AceCare_UserControls
{
    partial class UC_PatientRecords
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle13 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle15 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle16 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle14 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_PatientRecords));
            label1 = new Label();
            panel1 = new Panel();
            hopeRoundButton2 = new ReaLTaiizor.Controls.HopeRoundButton();
            hopeRoundButton1 = new ReaLTaiizor.Controls.HopeRoundButton();
            label2 = new Label();
            poisonDataGridView1 = new ReaLTaiizor.Controls.PoisonDataGridView();
            Patient = new DataGridViewTextBoxColumn();
            Column1 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            SearchBtn = new ReaLTaiizor.Controls.HopeRoundButton();
            textBox1 = new TextBox();
            pictureBox4 = new PictureBox();
            panel2 = new Panel();
            pictureBox1 = new PictureBox();
            hopeButton2 = new ReaLTaiizor.Controls.HopeButton();
            pictureBox6 = new PictureBox();
            hopeButton1 = new ReaLTaiizor.Controls.HopeButton();
            textBox7 = new TextBox();
            label11 = new Label();
            textBox6 = new TextBox();
            label10 = new Label();
            poisonComboBox2 = new ReaLTaiizor.Controls.PoisonComboBox();
            label9 = new Label();
            textBox5 = new TextBox();
            textBox4 = new TextBox();
            textBox3 = new TextBox();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            textBox2 = new TextBox();
            label5 = new Label();
            poisonComboBox1 = new ReaLTaiizor.Controls.PoisonComboBox();
            label4 = new Label();
            label3 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)poisonDataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(21, 30);
            label1.Name = "label1";
            label1.Size = new Size(351, 51);
            label1.TabIndex = 4;
            label1.Text = "Patient Records";
            // 
            // panel1
            // 
            panel1.Controls.Add(hopeRoundButton2);
            panel1.Controls.Add(hopeRoundButton1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(poisonDataGridView1);
            panel1.Controls.Add(SearchBtn);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(pictureBox4);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(563, 778);
            panel1.TabIndex = 5;
            // 
            // hopeRoundButton2
            // 
            hopeRoundButton2.BorderColor = Color.FromArgb(220, 223, 230);
            hopeRoundButton2.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            hopeRoundButton2.DangerColor = Color.FromArgb(245, 108, 108);
            hopeRoundButton2.DefaultColor = Color.FromArgb(255, 255, 255);
            hopeRoundButton2.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            hopeRoundButton2.HoverTextColor = Color.FromArgb(48, 49, 51);
            hopeRoundButton2.InfoColor = Color.FromArgb(144, 147, 153);
            hopeRoundButton2.Location = new Point(399, 724);
            hopeRoundButton2.Name = "hopeRoundButton2";
            hopeRoundButton2.PrimaryColor = Color.FromArgb(11, 45, 114);
            hopeRoundButton2.Size = new Size(70, 35);
            hopeRoundButton2.SuccessColor = Color.FromArgb(103, 194, 58);
            hopeRoundButton2.TabIndex = 28;
            hopeRoundButton2.Text = "<<";
            hopeRoundButton2.TextColor = Color.White;
            hopeRoundButton2.WarningColor = Color.FromArgb(230, 162, 60);
            // 
            // hopeRoundButton1
            // 
            hopeRoundButton1.BorderColor = Color.FromArgb(220, 223, 230);
            hopeRoundButton1.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            hopeRoundButton1.DangerColor = Color.FromArgb(245, 108, 108);
            hopeRoundButton1.DefaultColor = Color.FromArgb(255, 255, 255);
            hopeRoundButton1.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            hopeRoundButton1.HoverTextColor = Color.FromArgb(48, 49, 51);
            hopeRoundButton1.InfoColor = Color.FromArgb(144, 147, 153);
            hopeRoundButton1.Location = new Point(475, 724);
            hopeRoundButton1.Name = "hopeRoundButton1";
            hopeRoundButton1.PrimaryColor = Color.FromArgb(11, 45, 114);
            hopeRoundButton1.Size = new Size(70, 35);
            hopeRoundButton1.SuccessColor = Color.FromArgb(103, 194, 58);
            hopeRoundButton1.TabIndex = 27;
            hopeRoundButton1.Text = ">>";
            hopeRoundButton1.TextColor = Color.White;
            hopeRoundButton1.WarningColor = Color.FromArgb(230, 162, 60);
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(21, 214);
            label2.Name = "label2";
            label2.Size = new Size(274, 40);
            label2.TabIndex = 26;
            label2.Text = "Current Patients\r\n";
            // 
            // poisonDataGridView1
            // 
            poisonDataGridView1.AllowUserToOrderColumns = true;
            poisonDataGridView1.AllowUserToResizeRows = false;
            poisonDataGridView1.BackgroundColor = Color.FromArgb(255, 255, 255);
            poisonDataGridView1.BorderStyle = BorderStyle.None;
            poisonDataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.RaisedHorizontal;
            poisonDataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle13.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = Color.FromArgb(11, 45, 114);
            dataGridViewCellStyle13.Font = new Font("Century Gothic", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle13.ForeColor = Color.FromArgb(255, 255, 255);
            dataGridViewCellStyle13.SelectionBackColor = Color.FromArgb(11, 45, 114);
            dataGridViewCellStyle13.SelectionForeColor = Color.FromArgb(17, 17, 17);
            dataGridViewCellStyle13.WrapMode = DataGridViewTriState.True;
            poisonDataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            poisonDataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            poisonDataGridView1.Columns.AddRange(new DataGridViewColumn[] { Patient, Column1, Column3, Column4 });
            dataGridViewCellStyle15.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle15.BackColor = Color.FromArgb(255, 255, 255);
            dataGridViewCellStyle15.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle15.ForeColor = Color.FromArgb(136, 136, 136);
            dataGridViewCellStyle15.Padding = new Padding(7);
            dataGridViewCellStyle15.SelectionBackColor = Color.FromArgb(192, 255, 255);
            dataGridViewCellStyle15.SelectionForeColor = Color.FromArgb(17, 17, 17);
            dataGridViewCellStyle15.WrapMode = DataGridViewTriState.True;
            poisonDataGridView1.DefaultCellStyle = dataGridViewCellStyle15;
            poisonDataGridView1.EnableHeadersVisualStyles = false;
            poisonDataGridView1.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
            poisonDataGridView1.GridColor = Color.FromArgb(11, 45, 114);
            poisonDataGridView1.Location = new Point(21, 267);
            poisonDataGridView1.Name = "poisonDataGridView1";
            poisonDataGridView1.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle16.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = Color.FromArgb(0, 174, 219);
            dataGridViewCellStyle16.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
            dataGridViewCellStyle16.ForeColor = Color.FromArgb(255, 255, 255);
            dataGridViewCellStyle16.SelectionBackColor = Color.FromArgb(0, 198, 247);
            dataGridViewCellStyle16.SelectionForeColor = Color.FromArgb(17, 17, 17);
            dataGridViewCellStyle16.WrapMode = DataGridViewTriState.True;
            poisonDataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle16;
            poisonDataGridView1.RowHeadersWidth = 51;
            poisonDataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            poisonDataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            poisonDataGridView1.Size = new Size(524, 441);
            poisonDataGridView1.TabIndex = 25;
            // 
            // Patient
            // 
            Patient.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle14.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.WrapMode = DataGridViewTriState.True;
            Patient.DefaultCellStyle = dataGridViewCellStyle14;
            Patient.HeaderText = "Patients Name";
            Patient.MinimumWidth = 6;
            Patient.Name = "Patient";
            // 
            // Column1
            // 
            Column1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column1.HeaderText = "ID No.";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            // 
            // Column3
            // 
            Column3.HeaderText = "Type";
            Column3.MinimumWidth = 6;
            Column3.Name = "Column3";
            Column3.Width = 125;
            // 
            // Column4
            // 
            Column4.HeaderText = "Last Visit";
            Column4.MinimumWidth = 6;
            Column4.Name = "Column4";
            Column4.Width = 125;
            // 
            // SearchBtn
            // 
            SearchBtn.BackColor = Color.FromArgb(235, 239, 244);
            SearchBtn.BackgroundImageLayout = ImageLayout.Zoom;
            SearchBtn.BorderColor = Color.FromArgb(235, 239, 244);
            SearchBtn.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            SearchBtn.DangerColor = Color.FromArgb(245, 108, 108);
            SearchBtn.DefaultColor = Color.FromArgb(255, 255, 255);
            SearchBtn.Font = new Font("Century Gothic", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SearchBtn.HoverTextColor = Color.FromArgb(48, 49, 51);
            SearchBtn.InfoColor = Color.FromArgb(144, 147, 153);
            SearchBtn.Location = new Point(420, 129);
            SearchBtn.Name = "SearchBtn";
            SearchBtn.PrimaryColor = Color.FromArgb(11, 45, 114);
            SearchBtn.Size = new Size(109, 35);
            SearchBtn.SuccessColor = Color.FromArgb(103, 194, 58);
            SearchBtn.TabIndex = 23;
            SearchBtn.Text = "Search";
            SearchBtn.TextColor = Color.White;
            SearchBtn.WarningColor = Color.FromArgb(230, 162, 60);
            // 
            // textBox1
            // 
            textBox1.Location = new Point(40, 134);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(374, 27);
            textBox1.TabIndex = 22;
            // 
            // pictureBox4
            // 
            pictureBox4.BackgroundImage = (Image)resources.GetObject("pictureBox4.BackgroundImage");
            pictureBox4.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox4.Location = new Point(3, 109);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(560, 80);
            pictureBox4.TabIndex = 21;
            pictureBox4.TabStop = false;
            // 
            // panel2
            // 
            panel2.BackgroundImage = (Image)resources.GetObject("panel2.BackgroundImage");
            panel2.BackgroundImageLayout = ImageLayout.Zoom;
            panel2.Controls.Add(pictureBox1);
            panel2.Controls.Add(hopeButton2);
            panel2.Controls.Add(pictureBox6);
            panel2.Controls.Add(hopeButton1);
            panel2.Controls.Add(textBox7);
            panel2.Controls.Add(label11);
            panel2.Controls.Add(textBox6);
            panel2.Controls.Add(label10);
            panel2.Controls.Add(poisonComboBox2);
            panel2.Controls.Add(label9);
            panel2.Controls.Add(textBox5);
            panel2.Controls.Add(textBox4);
            panel2.Controls.Add(textBox3);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(textBox2);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(poisonComboBox1);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(563, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(524, 778);
            panel2.TabIndex = 6;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(11, 45, 114);
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.InitialImage = (Image)resources.GetObject("pictureBox1.InitialImage");
            pictureBox1.Location = new Point(327, 604);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(47, 29);
            pictureBox1.TabIndex = 48;
            pictureBox1.TabStop = false;
            // 
            // hopeButton2
            // 
            hopeButton2.BorderColor = Color.FromArgb(220, 223, 230);
            hopeButton2.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            hopeButton2.DangerColor = Color.FromArgb(245, 108, 108);
            hopeButton2.DefaultColor = Color.FromArgb(255, 255, 255);
            hopeButton2.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            hopeButton2.HoverTextColor = Color.FromArgb(48, 49, 51);
            hopeButton2.InfoColor = Color.FromArgb(144, 147, 153);
            hopeButton2.Location = new Point(303, 590);
            hopeButton2.Name = "hopeButton2";
            hopeButton2.PrimaryColor = Color.FromArgb(11, 45, 114);
            hopeButton2.Size = new Size(160, 59);
            hopeButton2.SuccessColor = Color.FromArgb(103, 194, 58);
            hopeButton2.TabIndex = 47;
            hopeButton2.Text = "        Clear";
            hopeButton2.TextColor = Color.White;
            hopeButton2.WarningColor = Color.FromArgb(230, 162, 60);
            // 
            // pictureBox6
            // 
            pictureBox6.BackColor = Color.FromArgb(11, 45, 114);
            pictureBox6.BackgroundImage = (Image)resources.GetObject("pictureBox6.BackgroundImage");
            pictureBox6.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox6.InitialImage = (Image)resources.GetObject("pictureBox6.InitialImage");
            pictureBox6.Location = new Point(147, 605);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(47, 29);
            pictureBox6.TabIndex = 46;
            pictureBox6.TabStop = false;
            // 
            // hopeButton1
            // 
            hopeButton1.BorderColor = Color.FromArgb(220, 223, 230);
            hopeButton1.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            hopeButton1.DangerColor = Color.FromArgb(245, 108, 108);
            hopeButton1.DefaultColor = Color.FromArgb(255, 255, 255);
            hopeButton1.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            hopeButton1.HoverTextColor = Color.FromArgb(48, 49, 51);
            hopeButton1.InfoColor = Color.FromArgb(144, 147, 153);
            hopeButton1.Location = new Point(122, 590);
            hopeButton1.Name = "hopeButton1";
            hopeButton1.PrimaryColor = Color.FromArgb(11, 45, 114);
            hopeButton1.Size = new Size(160, 59);
            hopeButton1.SuccessColor = Color.FromArgb(103, 194, 58);
            hopeButton1.TabIndex = 30;
            hopeButton1.Text = "        Save";
            hopeButton1.TextColor = Color.White;
            hopeButton1.WarningColor = Color.FromArgb(230, 162, 60);
            // 
            // textBox7
            // 
            textBox7.Location = new Point(55, 538);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(410, 27);
            textBox7.TabIndex = 45;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.FromArgb(235, 239, 244);
            label11.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.Location = new Point(55, 503);
            label11.Name = "label11";
            label11.Size = new Size(172, 19);
            label11.TabIndex = 44;
            label11.Text = "Emergency Contact";
            // 
            // textBox6
            // 
            textBox6.Location = new Point(55, 449);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(410, 27);
            textBox6.TabIndex = 43;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.FromArgb(235, 239, 244);
            label10.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(55, 414);
            label10.Name = "label10";
            label10.Size = new Size(107, 19);
            label10.TabIndex = 42;
            label10.Text = "Contact No.";
            // 
            // poisonComboBox2
            // 
            poisonComboBox2.FormattingEnabled = true;
            poisonComboBox2.ItemHeight = 24;
            poisonComboBox2.Location = new Point(258, 365);
            poisonComboBox2.Name = "poisonComboBox2";
            poisonComboBox2.Size = new Size(207, 30);
            poisonComboBox2.TabIndex = 41;
            poisonComboBox2.UseSelectable = true;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.FromArgb(235, 239, 244);
            label9.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(258, 333);
            label9.Name = "label9";
            label9.Size = new Size(67, 19);
            label9.TabIndex = 40;
            label9.Text = "Course\r\n";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(55, 368);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(197, 27);
            textBox5.TabIndex = 39;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(258, 289);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(207, 27);
            textBox4.TabIndex = 38;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(55, 289);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(197, 27);
            textBox3.TabIndex = 37;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.FromArgb(235, 239, 244);
            label8.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(57, 334);
            label8.Name = "label8";
            label8.Size = new Size(112, 19);
            label8.TabIndex = 36;
            label8.Text = "Middle Initial";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.FromArgb(235, 239, 244);
            label7.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(258, 253);
            label7.Name = "label7";
            label7.Size = new Size(95, 19);
            label7.TabIndex = 35;
            label7.Text = "Last Name";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.FromArgb(235, 239, 244);
            label6.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(55, 252);
            label6.Name = "label6";
            label6.Size = new Size(94, 19);
            label6.TabIndex = 34;
            label6.Text = "First Name";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(55, 205);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(410, 27);
            textBox2.TabIndex = 33;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.FromArgb(235, 239, 244);
            label5.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(55, 173);
            label5.Name = "label5";
            label5.Size = new Size(97, 19);
            label5.TabIndex = 32;
            label5.Text = "ID Number";
            // 
            // poisonComboBox1
            // 
            poisonComboBox1.FormattingEnabled = true;
            poisonComboBox1.ItemHeight = 24;
            poisonComboBox1.Location = new Point(217, 125);
            poisonComboBox1.Name = "poisonComboBox1";
            poisonComboBox1.Size = new Size(248, 30);
            poisonComboBox1.TabIndex = 31;
            poisonComboBox1.UseSelectable = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.FromArgb(235, 239, 244);
            label4.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(53, 125);
            label4.Name = "label4";
            label4.Size = new Size(157, 22);
            label4.TabIndex = 30;
            label4.Text = "Patient Category";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century Gothic", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(29, 27);
            label3.Name = "label3";
            label3.Size = new Size(281, 40);
            label3.TabIndex = 29;
            label3.Text = "Add/Edit Patient";
            // 
            // UC_PatientRecords
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "UC_PatientRecords";
            Size = new Size(1087, 778);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)poisonDataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private PictureBox pictureBox4;
        private ReaLTaiizor.Controls.HopeRoundButton SearchBtn;
        private TextBox textBox1;
        private ReaLTaiizor.Controls.PoisonDataGridView poisonDataGridView1;
        private Label label2;
        private Panel panel2;
        private ReaLTaiizor.Controls.HopeRoundButton hopeRoundButton2;
        private ReaLTaiizor.Controls.HopeRoundButton hopeRoundButton1;
        private DataGridViewTextBoxColumn Patient;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private Label label3;
        private Label label4;
        private Label label5;
        private ReaLTaiizor.Controls.PoisonComboBox poisonComboBox1;
        private ReaLTaiizor.Controls.PoisonComboBox poisonComboBox2;
        private Label label9;
        private TextBox textBox5;
        private TextBox textBox4;
        private TextBox textBox3;
        private Label label8;
        private Label label7;
        private Label label6;
        private TextBox textBox2;
        private TextBox textBox7;
        private Label label11;
        private TextBox textBox6;
        private Label label10;
        private ReaLTaiizor.Controls.HopeButton hopeButton1;
        private PictureBox pictureBox1;
        private ReaLTaiizor.Controls.HopeButton hopeButton2;
        private PictureBox pictureBox6;
    }
}
