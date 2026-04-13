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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_PatientRecords));
            label1 = new Label();
            panel1 = new Panel();
            txtSearch = new ReaLTaiizor.Controls.PoisonTextBox();
            btnPrev = new ReaLTaiizor.Controls.HopeRoundButton();
            btnNext = new ReaLTaiizor.Controls.HopeRoundButton();
            label2 = new Label();
            dgvPatients = new ReaLTaiizor.Controls.PoisonDataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Department = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            btnSearch = new ReaLTaiizor.Controls.HopeRoundButton();
            pictureBox4 = new PictureBox();
            ReloadPix = new PictureBox();
            panel2 = new Panel();
            pictureBox2 = new PictureBox();
            btnAddNewPatient = new ReaLTaiizor.Controls.HopeButton();
            dobTimePicker = new ReaLTaiizor.Controls.PoisonDateTime();
            label13 = new Label();
            pictureBox1 = new PictureBox();
            cmbYearLevel = new ReaLTaiizor.Controls.PoisonComboBox();
            label12 = new Label();
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
            toolTip1 = new ToolTip(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPatients).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ReloadPix).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
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
            panel1.Controls.Add(ReloadPix);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(616, 813);
            panel1.TabIndex = 5;
            // 
            // txtSearch
            // 
            txtSearch.BackColor = Color.FromArgb(235, 239, 244);
            // 
            // 
            // 
            txtSearch.CustomButton.Image = null;
            txtSearch.CustomButton.Location = new Point(370, 1);
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
            txtSearch.Size = new Size(408, 39);
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
            btnPrev.Location = new Point(446, 756);
            btnPrev.Name = "btnPrev";
            btnPrev.PrimaryColor = Color.FromArgb(11, 45, 114);
            btnPrev.Size = new Size(70, 35);
            btnPrev.SuccessColor = Color.FromArgb(103, 194, 58);
            btnPrev.TabIndex = 28;
            btnPrev.Text = "<<";
            btnPrev.TextColor = Color.White;
            btnPrev.WarningColor = Color.FromArgb(230, 162, 60);
            btnPrev.Click += btnPrev_Click;
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
            btnNext.Location = new Point(532, 756);
            btnNext.Name = "btnNext";
            btnNext.PrimaryColor = Color.FromArgb(11, 45, 114);
            btnNext.Size = new Size(70, 35);
            btnNext.SuccessColor = Color.FromArgb(103, 194, 58);
            btnNext.TabIndex = 27;
            btnNext.Text = ">>";
            btnNext.TextColor = Color.White;
            btnNext.WarningColor = Color.FromArgb(230, 162, 60);
            btnNext.Click += btnNext_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(16, 211);
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
            dgvPatients.Location = new Point(7, 267);
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
            dgvPatients.Size = new Size(603, 470);
            dgvPatients.TabIndex = 25;
            dgvPatients.UseCustomBackColor = true;
            dgvPatients.UseCustomForeColor = true;
            dgvPatients.CellClick += dgvPatients_CellContentClick;
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
            // btnSearch
            // 
            btnSearch.BackColor = Color.Transparent;
            btnSearch.BackgroundImageLayout = ImageLayout.Zoom;
            btnSearch.BorderColor = Color.FromArgb(235, 239, 244);
            btnSearch.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            btnSearch.DangerColor = Color.FromArgb(245, 108, 108);
            btnSearch.DefaultColor = Color.FromArgb(255, 255, 255);
            btnSearch.Font = new Font("Century Gothic", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSearch.HoverTextColor = Color.FromArgb(48, 49, 51);
            btnSearch.InfoColor = Color.FromArgb(144, 147, 153);
            btnSearch.Location = new Point(466, 132);
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
            pictureBox4.Location = new Point(-8, 109);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(637, 80);
            pictureBox4.TabIndex = 21;
            pictureBox4.TabStop = false;
            // 
            // ReloadPix
            // 
            ReloadPix.BackColor = Color.Transparent;
            ReloadPix.BackgroundImage = Properties.Resources.loading_arrow;
            ReloadPix.BackgroundImageLayout = ImageLayout.Zoom;
            ReloadPix.InitialImage = Properties.Resources.loading_arrow;
            ReloadPix.Location = new Point(385, 758);
            ReloadPix.Name = "ReloadPix";
            ReloadPix.Size = new Size(50, 32);
            ReloadPix.TabIndex = 48;
            ReloadPix.TabStop = false;
            toolTip1.SetToolTip(ReloadPix, "Refresh Table");
            ReloadPix.Click += pictureBox1_Click;
            // 
            // panel2
            // 
            panel2.BackgroundImage = (Image)resources.GetObject("panel2.BackgroundImage");
            panel2.BackgroundImageLayout = ImageLayout.Zoom;
            panel2.Controls.Add(pictureBox2);
            panel2.Controls.Add(btnAddNewPatient);
            panel2.Controls.Add(dobTimePicker);
            panel2.Controls.Add(label13);
            panel2.Controls.Add(pictureBox1);
            panel2.Controls.Add(cmbYearLevel);
            panel2.Controls.Add(label12);
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
            panel2.Location = new Point(616, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(569, 813);
            panel2.TabIndex = 6;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.White;
            pictureBox2.BackgroundImage = Properties.Resources.add__1_;
            pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox2.InitialImage = (Image)resources.GetObject("pictureBox2.InitialImage");
            pictureBox2.Location = new Point(211, 102);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(57, 29);
            pictureBox2.TabIndex = 54;
            pictureBox2.TabStop = false;
            // 
            // btnAddNewPatient
            // 
            btnAddNewPatient.BorderColor = Color.FromArgb(0, 0, 192);
            btnAddNewPatient.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            btnAddNewPatient.DangerColor = Color.FromArgb(245, 108, 108);
            btnAddNewPatient.DefaultColor = Color.FromArgb(255, 255, 255);
            btnAddNewPatient.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddNewPatient.HoverTextColor = Color.FromArgb(48, 49, 51);
            btnAddNewPatient.InfoColor = Color.FromArgb(144, 147, 153);
            btnAddNewPatient.Location = new Point(87, 96);
            btnAddNewPatient.Name = "btnAddNewPatient";
            btnAddNewPatient.PrimaryColor = Color.White;
            btnAddNewPatient.Size = new Size(431, 42);
            btnAddNewPatient.SuccessColor = Color.FromArgb(103, 194, 58);
            btnAddNewPatient.TabIndex = 55;
            btnAddNewPatient.Text = "        New Patient";
            btnAddNewPatient.TextColor = Color.Black;
            btnAddNewPatient.WarningColor = Color.FromArgb(230, 162, 60);
            btnAddNewPatient.Click += btnAddNewPatient_Click;
            // 
            // dobTimePicker
            // 
            dobTimePicker.FontSize = ReaLTaiizor.Extension.Poison.PoisonDateTimeSize.Medium;
            dobTimePicker.Location = new Point(294, 411);
            dobTimePicker.MinimumSize = new Size(0, 30);
            dobTimePicker.Name = "dobTimePicker";
            dobTimePicker.Size = new Size(224, 30);
            dobTimePicker.TabIndex = 52;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.BackColor = Color.FromArgb(235, 239, 244);
            label13.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.Location = new Point(294, 382);
            label13.Name = "label13";
            label13.Size = new Size(106, 19);
            label13.TabIndex = 51;
            label13.Text = "Date of Birth";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.DarkRed;
            pictureBox1.BackgroundImage = Properties.Resources.bin;
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.InitialImage = (Image)resources.GetObject("pictureBox1.InitialImage");
            pictureBox1.Location = new Point(200, 706);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(47, 29);
            pictureBox1.TabIndex = 50;
            pictureBox1.TabStop = false;
            // 
            // cmbYearLevel
            // 
            cmbYearLevel.FormattingEnabled = true;
            cmbYearLevel.ItemHeight = 24;
            cmbYearLevel.Location = new Point(294, 491);
            cmbYearLevel.Name = "cmbYearLevel";
            cmbYearLevel.Size = new Size(224, 30);
            cmbYearLevel.TabIndex = 49;
            cmbYearLevel.UseSelectable = true;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.BackColor = Color.FromArgb(235, 239, 244);
            label12.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.Location = new Point(294, 448);
            label12.Name = "label12";
            label12.Size = new Size(95, 19);
            label12.TabIndex = 48;
            label12.Text = "Year Level";
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
            btnClear.Location = new Point(186, 691);
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
            pictureBox6.Location = new Point(390, 706);
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
            btnSave.Location = new Point(365, 691);
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
            txtEmergency.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEmergency.Location = new Point(87, 632);
            txtEmergency.Name = "txtEmergency";
            txtEmergency.Size = new Size(434, 34);
            txtEmergency.TabIndex = 45;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.FromArgb(235, 239, 244);
            label11.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.Location = new Point(85, 603);
            label11.Name = "label11";
            label11.Size = new Size(172, 19);
            label11.TabIndex = 44;
            label11.Text = "Emergency Contact";
            // 
            // txtContact
            // 
            txtContact.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtContact.Location = new Point(86, 562);
            txtContact.Name = "txtContact";
            txtContact.Size = new Size(434, 34);
            txtContact.TabIndex = 43;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.FromArgb(235, 239, 244);
            label10.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(83, 534);
            label10.Name = "label10";
            label10.Size = new Size(107, 19);
            label10.TabIndex = 42;
            label10.Text = "Contact No.";
            // 
            // cmbDepartment
            // 
            cmbDepartment.FormattingEnabled = true;
            cmbDepartment.ItemHeight = 24;
            cmbDepartment.Location = new Point(85, 491);
            cmbDepartment.Name = "cmbDepartment";
            cmbDepartment.Size = new Size(197, 30);
            cmbDepartment.TabIndex = 41;
            cmbDepartment.UseSelectable = true;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.FromArgb(235, 239, 244);
            label9.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(85, 447);
            label9.Name = "label9";
            label9.Size = new Size(104, 19);
            label9.TabIndex = 40;
            label9.Text = "Department";
            // 
            // txtMI
            // 
            txtMI.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMI.Location = new Point(84, 414);
            txtMI.Name = "txtMI";
            txtMI.Size = new Size(198, 34);
            txtMI.TabIndex = 39;
            // 
            // txtLastName
            // 
            txtLastName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtLastName.Location = new Point(294, 332);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(224, 34);
            txtLastName.TabIndex = 38;
            // 
            // txtFirstName
            // 
            txtFirstName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtFirstName.Location = new Point(84, 332);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(198, 34);
            txtFirstName.TabIndex = 37;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.FromArgb(235, 239, 244);
            label8.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(86, 382);
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
            label7.Location = new Point(294, 300);
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
            label6.Location = new Point(84, 300);
            label6.Name = "label6";
            label6.Size = new Size(94, 19);
            label6.TabIndex = 34;
            label6.Text = "First Name";
            // 
            // txtIDNumber
            // 
            txtIDNumber.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtIDNumber.Location = new Point(86, 248);
            txtIDNumber.Name = "txtIDNumber";
            txtIDNumber.Size = new Size(434, 34);
            txtIDNumber.TabIndex = 33;
            txtIDNumber.TextChanged += txtIDNumber_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.FromArgb(235, 239, 244);
            label5.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(84, 218);
            label5.Name = "label5";
            label5.Size = new Size(97, 19);
            label5.TabIndex = 32;
            label5.Text = "ID Number";
            // 
            // cmbCategory
            // 
            cmbCategory.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            cmbCategory.FormattingEnabled = true;
            cmbCategory.ItemHeight = 24;
            cmbCategory.Location = new Point(255, 172);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(263, 30);
            cmbCategory.TabIndex = 31;
            cmbCategory.UseSelectable = true;
            cmbCategory.SelectedIndexChanged += cmbCategory_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.FromArgb(235, 239, 244);
            label4.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(83, 176);
            label4.Name = "label4";
            label4.Size = new Size(157, 22);
            label4.TabIndex = 30;
            label4.Text = "Patient Category";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century Gothic", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(21, 17);
            label3.Name = "label3";
            label3.Size = new Size(325, 40);
            label3.TabIndex = 29;
            label3.Text = "Patient Information";
            // 
            // UC_PatientRecords
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "UC_PatientRecords";
            Size = new Size(1185, 813);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPatients).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)ReloadPix).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
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
        private PictureBox ReloadPix;
        private ReaLTaiizor.Controls.HopeButton btnClear;
        private PictureBox pictureBox6;
        private ReaLTaiizor.Controls.PoisonTextBox txtSearch;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Department;
        private DataGridViewTextBoxColumn Column4;
        private ReaLTaiizor.Controls.HopeButton ReloadBtn;
        private ToolTip toolTip1;
        private ReaLTaiizor.Controls.PoisonComboBox cmbYearLevel;
        private Label label12;
        private PictureBox pictureBox1;
        private ReaLTaiizor.Controls.PoisonDateTime dobTimePicker;
        private Label label13;
        private PictureBox pictureBox2;
        private ReaLTaiizor.Controls.HopeButton btnAddNewPatient;
    }
}
