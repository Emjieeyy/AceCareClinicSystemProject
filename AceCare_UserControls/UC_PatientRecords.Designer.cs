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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_PatientRecords));
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            label1 = new Label();
            panel1 = new Panel();
            txtSearch = new ReaLTaiizor.Controls.PoisonTextBox();
            btnPrev = new ReaLTaiizor.Controls.HopeRoundButton();
            btnNext = new ReaLTaiizor.Controls.HopeRoundButton();
            label2 = new Label();
            dgvPatients = new ReaLTaiizor.Controls.PoisonDataGridView();
            btnSearch = new ReaLTaiizor.Controls.HopeRoundButton();
            pictureBox4 = new PictureBox();
            panel2 = new Panel();
            pictureBox1 = new PictureBox();
            btnClear = new ReaLTaiizor.Controls.HopeButton();
            pictureBox6 = new PictureBox();
            btnSave = new ReaLTaiizor.Controls.HopeButton();
            txtEmergency = new TextBox();
            label11 = new Label();
            txtContact = new TextBox();
            label10 = new Label();
            cmbDepartment = new ReaLTaiizor.Controls.PoisonComboBox();
            label9 = new Label();
            txtMI = new TextBox();
            txtLastName = new TextBox();
            txtFirstName = new TextBox();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            txtIDNumber = new TextBox();
            label5 = new Label();
            cmbCategory = new ReaLTaiizor.Controls.PoisonComboBox();
            label4 = new Label();
            label3 = new Label();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Department = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPatients).BeginInit();
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
            panel1.Controls.Add(txtSearch);
            panel1.Controls.Add(btnPrev);
            panel1.Controls.Add(btnNext);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(dgvPatients);
            panel1.Controls.Add(btnSearch);
            panel1.Controls.Add(pictureBox4);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(554, 778);
            panel1.TabIndex = 5;
            // 
            // txtSearch
            // 
            txtSearch.BackColor = Color.FromArgb(235, 239, 244);
            // 
            // 
            // 
            txtSearch.CustomButton.Image = null;
            txtSearch.CustomButton.Location = new Point(321, 1);
            txtSearch.CustomButton.Name = "";
            txtSearch.CustomButton.Size = new Size(37, 37);
            txtSearch.CustomButton.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Blue;
            txtSearch.CustomButton.TabIndex = 1;
            txtSearch.CustomButton.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
            txtSearch.CustomButton.UseSelectable = true;
            txtSearch.CustomButton.Visible = false;
            txtSearch.FontSize = ReaLTaiizor.Extension.Poison.PoisonTextBoxSize.Medium;
            txtSearch.Location = new Point(37, 128);
            txtSearch.MaxLength = 32767;
            txtSearch.Name = "txtSearch";
            txtSearch.PasswordChar = '\0';
            txtSearch.ScrollBars = ScrollBars.None;
            txtSearch.SelectedText = "";
            txtSearch.SelectionLength = 0;
            txtSearch.SelectionStart = 0;
            txtSearch.ShortcutsEnabled = true;
            txtSearch.Size = new Size(359, 39);
            txtSearch.TabIndex = 30;
            txtSearch.UseCustomBackColor = true;
            txtSearch.UseSelectable = true;
            txtSearch.WaterMarkColor = Color.FromArgb(109, 109, 109);
            txtSearch.WaterMarkFont = new Font("Segoe UI", 12F, FontStyle.Italic, GraphicsUnit.Pixel);
            // 
            // btnPrev
            // 
            btnPrev.BorderColor = Color.FromArgb(220, 223, 230);
            btnPrev.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            btnPrev.DangerColor = Color.FromArgb(245, 108, 108);
            btnPrev.DefaultColor = Color.FromArgb(255, 255, 255);
            btnPrev.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPrev.HoverTextColor = Color.FromArgb(48, 49, 51);
            btnPrev.InfoColor = Color.FromArgb(144, 147, 153);
            btnPrev.Location = new Point(399, 724);
            btnPrev.Name = "btnPrev";
            btnPrev.PrimaryColor = Color.FromArgb(11, 45, 114);
            btnPrev.Size = new Size(70, 35);
            btnPrev.SuccessColor = Color.FromArgb(103, 194, 58);
            btnPrev.TabIndex = 28;
            btnPrev.Text = "<<";
            btnPrev.TextColor = Color.White;
            btnPrev.WarningColor = Color.FromArgb(230, 162, 60);
          
            // 
            // btnNext
            // 
            btnNext.BorderColor = Color.FromArgb(220, 223, 230);
            btnNext.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            btnNext.DangerColor = Color.FromArgb(245, 108, 108);
            btnNext.DefaultColor = Color.FromArgb(255, 255, 255);
            btnNext.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNext.HoverTextColor = Color.FromArgb(48, 49, 51);
            btnNext.InfoColor = Color.FromArgb(144, 147, 153);
            btnNext.Location = new Point(475, 724);
            btnNext.Name = "btnNext";
            btnNext.PrimaryColor = Color.FromArgb(11, 45, 114);
            btnNext.Size = new Size(70, 35);
            btnNext.SuccessColor = Color.FromArgb(103, 194, 58);
            btnNext.TabIndex = 27;
            btnNext.Text = ">>";
            btnNext.TextColor = Color.White;
            btnNext.WarningColor = Color.FromArgb(230, 162, 60);
           
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
            // dgvPatients
            // 
            dgvPatients.AllowUserToOrderColumns = true;
            dgvPatients.AllowUserToResizeRows = false;
            dgvPatients.BackgroundColor = Color.FromArgb(255, 255, 255);
            dgvPatients.BorderStyle = BorderStyle.None;
            dgvPatients.CellBorderStyle = DataGridViewCellBorderStyle.RaisedHorizontal;
            dgvPatients.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(11, 45, 114);
            dataGridViewCellStyle1.Font = new Font("Century Gothic", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(255, 255, 255);
            dataGridViewCellStyle1.Padding = new Padding(7);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(11, 45, 114);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(17, 17, 17);
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvPatients.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvPatients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPatients.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Department, Column4 });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(255, 255, 255);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.Padding = new Padding(7);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(192, 255, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(17, 17, 17);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvPatients.DefaultCellStyle = dataGridViewCellStyle3;
            dgvPatients.EnableHeadersVisualStyles = false;
            dgvPatients.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
            dgvPatients.GridColor = Color.FromArgb(11, 45, 114);
            dgvPatients.Location = new Point(-21, 267);
            dgvPatients.Name = "dgvPatients";
            dgvPatients.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.DarkBlue;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
            dataGridViewCellStyle4.ForeColor = Color.Black;
            dataGridViewCellStyle4.Padding = new Padding(7);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(0, 198, 247);
            dataGridViewCellStyle4.SelectionForeColor = Color.FromArgb(17, 17, 17);
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvPatients.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvPatients.RowHeadersWidth = 51;
            dgvPatients.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvPatients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPatients.Size = new Size(584, 441);
            dgvPatients.TabIndex = 25;
            dgvPatients.UseCustomBackColor = true;
            dgvPatients.UseCustomForeColor = true;
       
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(235, 239, 244);
            btnSearch.BackgroundImageLayout = ImageLayout.Zoom;
            btnSearch.BorderColor = Color.FromArgb(235, 239, 244);
            btnSearch.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            btnSearch.DangerColor = Color.FromArgb(245, 108, 108);
            btnSearch.DefaultColor = Color.FromArgb(255, 255, 255);
            btnSearch.Font = new Font("Century Gothic", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSearch.HoverTextColor = Color.FromArgb(48, 49, 51);
            btnSearch.InfoColor = Color.FromArgb(144, 147, 153);
            btnSearch.Location = new Point(413, 129);
            btnSearch.Name = "btnSearch";
            btnSearch.PrimaryColor = Color.FromArgb(11, 45, 114);
            btnSearch.Size = new Size(109, 35);
            btnSearch.SuccessColor = Color.FromArgb(103, 194, 58);
            btnSearch.TabIndex = 23;
            btnSearch.Text = "Search";
            btnSearch.TextColor = Color.White;
            btnSearch.WarningColor = Color.FromArgb(230, 162, 60);
            btnSearch.Click += btnSearch_Click;
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
            panel2.Controls.Add(btnClear);
            panel2.Controls.Add(pictureBox6);
            panel2.Controls.Add(btnSave);
            panel2.Controls.Add(txtEmergency);
            panel2.Controls.Add(label11);
            panel2.Controls.Add(txtContact);
            panel2.Controls.Add(label10);
            panel2.Controls.Add(cmbDepartment);
            panel2.Controls.Add(label9);
            panel2.Controls.Add(txtMI);
            panel2.Controls.Add(txtLastName);
            panel2.Controls.Add(txtFirstName);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(txtIDNumber);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(cmbCategory);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(554, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(533, 778);
            panel2.TabIndex = 6;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.DarkRed;
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.InitialImage = (Image)resources.GetObject("pictureBox1.InitialImage");
            pictureBox1.Location = new Point(142, 607);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(47, 29);
            pictureBox1.TabIndex = 48;
            pictureBox1.TabStop = false;
            // 
            // btnClear
            // 
            btnClear.BorderColor = Color.FromArgb(220, 223, 230);
            btnClear.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            btnClear.DangerColor = Color.FromArgb(245, 108, 108);
            btnClear.DefaultColor = Color.FromArgb(255, 255, 255);
            btnClear.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClear.HoverTextColor = Color.FromArgb(48, 49, 51);
            btnClear.InfoColor = Color.FromArgb(144, 147, 153);
            btnClear.Location = new Point(110, 593);
            btnClear.Name = "btnClear";
            btnClear.PrimaryColor = Color.DarkRed;
            btnClear.Size = new Size(160, 59);
            btnClear.SuccessColor = Color.FromArgb(103, 194, 58);
            btnClear.TabIndex = 47;
            btnClear.Text = "        Clear";
            btnClear.TextColor = Color.White;
            btnClear.WarningColor = Color.FromArgb(230, 162, 60);
            // 
            // pictureBox6
            // 
            pictureBox6.BackColor = Color.LimeGreen;
            pictureBox6.BackgroundImage = (Image)resources.GetObject("pictureBox6.BackgroundImage");
            pictureBox6.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox6.InitialImage = (Image)resources.GetObject("pictureBox6.InitialImage");
            pictureBox6.Location = new Point(314, 608);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(47, 29);
            pictureBox6.TabIndex = 46;
            pictureBox6.TabStop = false;
            // 
            // btnSave
            // 
            btnSave.BorderColor = Color.FromArgb(220, 223, 230);
            btnSave.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            btnSave.DangerColor = Color.FromArgb(245, 108, 108);
            btnSave.DefaultColor = Color.FromArgb(255, 255, 255);
            btnSave.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.HoverTextColor = Color.FromArgb(48, 49, 51);
            btnSave.InfoColor = Color.FromArgb(144, 147, 153);
            btnSave.Location = new Point(289, 593);
            btnSave.Name = "btnSave";
            btnSave.PrimaryColor = Color.LimeGreen;
            btnSave.Size = new Size(160, 59);
            btnSave.SuccessColor = Color.FromArgb(103, 194, 58);
            btnSave.TabIndex = 30;
            btnSave.Text = "        Save";
            btnSave.TextColor = Color.White;
            btnSave.WarningColor = Color.FromArgb(230, 162, 60);
            btnSave.Click += btnSave_Click;
            // 
            // txtEmergency
            // 
            txtEmergency.Location = new Point(57, 538);
            txtEmergency.Name = "txtEmergency";
            txtEmergency.Size = new Size(392, 27);
            txtEmergency.TabIndex = 45;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.FromArgb(235, 239, 244);
            label11.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.Location = new Point(57, 503);
            label11.Name = "label11";
            label11.Size = new Size(172, 19);
            label11.TabIndex = 44;
            label11.Text = "Emergency Contact";
            // 
            // txtContact
            // 
            txtContact.Location = new Point(57, 449);
            txtContact.Name = "txtContact";
            txtContact.Size = new Size(392, 27);
            txtContact.TabIndex = 43;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.FromArgb(235, 239, 244);
            label10.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(57, 414);
            label10.Name = "label10";
            label10.Size = new Size(107, 19);
            label10.TabIndex = 42;
            label10.Text = "Contact No.";
            // 
            // cmbDepartment
            // 
            cmbDepartment.FormattingEnabled = true;
            cmbDepartment.ItemHeight = 24;
            cmbDepartment.Location = new Point(260, 365);
            cmbDepartment.Name = "cmbDepartment";
            cmbDepartment.Size = new Size(189, 30);
            cmbDepartment.TabIndex = 41;
            cmbDepartment.UseSelectable = true;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.FromArgb(235, 239, 244);
            label9.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(260, 333);
            label9.Name = "label9";
            label9.Size = new Size(104, 19);
            label9.TabIndex = 40;
            label9.Text = "Department";
            // 
            // txtMI
            // 
            txtMI.Location = new Point(57, 368);
            txtMI.Name = "txtMI";
            txtMI.Size = new Size(186, 27);
            txtMI.TabIndex = 39;
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(260, 289);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(189, 27);
            txtLastName.TabIndex = 38;
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(57, 289);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(186, 27);
            txtFirstName.TabIndex = 37;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.FromArgb(235, 239, 244);
            label8.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(59, 334);
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
            label7.Location = new Point(260, 253);
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
            label6.Location = new Point(57, 252);
            label6.Name = "label6";
            label6.Size = new Size(94, 19);
            label6.TabIndex = 34;
            label6.Text = "First Name";
            // 
            // txtIDNumber
            // 
            txtIDNumber.Location = new Point(57, 205);
            txtIDNumber.Name = "txtIDNumber";
            txtIDNumber.Size = new Size(392, 27);
            txtIDNumber.TabIndex = 33;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.FromArgb(235, 239, 244);
            label5.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(57, 173);
            label5.Name = "label5";
            label5.Size = new Size(97, 19);
            label5.TabIndex = 32;
            label5.Text = "ID Number";
            // 
            // cmbCategory
            // 
            cmbCategory.FormattingEnabled = true;
            cmbCategory.ItemHeight = 24;
            cmbCategory.Location = new Point(219, 120);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(230, 30);
            cmbCategory.TabIndex = 31;
            cmbCategory.UseSelectable = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.FromArgb(235, 239, 244);
            label4.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(55, 124);
            label4.Name = "label4";
            label4.Size = new Size(157, 22);
            label4.TabIndex = 30;
            label4.Text = "Patient Category";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century Gothic", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(24, 36);
            label3.Name = "label3";
            label3.Size = new Size(281, 40);
            label3.TabIndex = 29;
            label3.Text = "Add/Edit Patient";
            // 
            // Column1
            // 
            Column1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column1.DataPropertyName = "Patients Name";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            Column1.DefaultCellStyle = dataGridViewCellStyle2;
            Column1.HeaderText = "Patients Name";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            // 
            // Column2
            // 
            Column2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column2.DataPropertyName = "ID No.";
            Column2.HeaderText = "ID No.";
            Column2.MinimumWidth = 6;
            Column2.Name = "Column2";
            // 
            // Column3
            // 
            Column3.DataPropertyName = "Type";
            Column3.HeaderText = "Type";
            Column3.MinimumWidth = 6;
            Column3.Name = "Column3";
            Column3.Width = 125;
            // 
            // Department
            // 
            Department.DataPropertyName = "Department";
            Department.HeaderText = "Department";
            Department.MinimumWidth = 6;
            Department.Name = "Department";
            Department.Width = 125;
            // 
            // Column4
            // 
            Column4.DataPropertyName = "Last Visit";
            Column4.HeaderText = "Last Visit";
            Column4.MinimumWidth = 6;
            Column4.Name = "Column4";
            Column4.Width = 125;
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
            ((System.ComponentModel.ISupportInitialize)dgvPatients).EndInit();
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
        private ReaLTaiizor.Controls.HopeRoundButton btnSearch;
        private ReaLTaiizor.Controls.PoisonDataGridView dgvPatients;
        private Label label2;
        private Panel panel2;
        private ReaLTaiizor.Controls.HopeRoundButton btnPrev;
        private ReaLTaiizor.Controls.HopeRoundButton btnNext;
        private Label label3;
        private Label label4;
        private Label label5;
        private ReaLTaiizor.Controls.PoisonComboBox cmbCategory;
        private ReaLTaiizor.Controls.PoisonComboBox cmbDepartment;
        private Label label9;
        private TextBox txtMI;
        private TextBox txtLastName;
        private TextBox txtFirstName;
        private Label label8;
        private Label label7;
        private Label label6;
        private TextBox txtIDNumber;
        private TextBox txtEmergency;
        private Label label11;
        private TextBox txtContact;
        private Label label10;
        private ReaLTaiizor.Controls.HopeButton btnSave;
        private PictureBox pictureBox1;
        private ReaLTaiizor.Controls.HopeButton btnClear;
        private PictureBox pictureBox6;
        private ReaLTaiizor.Controls.PoisonTextBox txtSearch;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Department;
        private DataGridViewTextBoxColumn Column4;
    }
}
