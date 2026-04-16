namespace AceCareClinicSystem.AceCare_UserControls
{
    partial class UC_UserManagement
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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            panel4 = new Panel();
            lblRecentLog0 = new Label();
            pictureBox1 = new PictureBox();
            label2 = new Label();
            panel2 = new Panel();
            label1 = new Label();
            pictureBox2 = new PictureBox();
            label7 = new Label();
            panel5 = new Panel();
            lblTotalUser0 = new Label();
            pictureBox3 = new PictureBox();
            label6 = new Label();
            pictureBox8 = new PictureBox();
            AuditTable = new TabPage();
            btnSearchAudit = new ReaLTaiizor.Controls.HopeRoundButton();
            txtSearchAudit = new ReaLTaiizor.Controls.PoisonTextBox();
            btnClear = new ReaLTaiizor.Controls.HopeRoundButton();
            btnRefresh = new ReaLTaiizor.Controls.HopeRoundButton();
            dgvAuditLogs = new ReaLTaiizor.Controls.PoisonDataGridView();
            Timestamp = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            tabPage1 = new TabPage();
            label11 = new Label();
            label8 = new Label();
            btnSearch = new ReaLTaiizor.Controls.HopeRoundButton();
            txtSearch = new ReaLTaiizor.Controls.PoisonTextBox();
            btnDeleteUser = new ReaLTaiizor.Controls.HopeRoundButton();
            btnAddUser = new ReaLTaiizor.Controls.HopeRoundButton();
            btnUpdateUser = new ReaLTaiizor.Controls.HopeRoundButton();
            dgvUserManagemend = new ReaLTaiizor.Controls.PoisonDataGridView();
            ID = new DataGridViewTextBoxColumn();
            ColFullName = new DataGridViewTextBoxColumn();
            Role = new DataGridViewTextBoxColumn();
            Email = new DataGridViewTextBoxColumn();
            Status = new DataGridViewTextBoxColumn();
            UserManagementTable = new TabControl();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).BeginInit();
            AuditTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAuditLogs).BeginInit();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUserManagemend).BeginInit();
            UserManagementTable.SuspendLayout();
            SuspendLayout();
            // 
            // panel4
            // 
            panel4.BackgroundImage = Properties.Resources._21;
            panel4.BackgroundImageLayout = ImageLayout.Stretch;
            panel4.Controls.Add(lblRecentLog0);
            panel4.Controls.Add(pictureBox1);
            panel4.Controls.Add(label2);
            panel4.Location = new Point(798, 124);
            panel4.Name = "panel4";
            panel4.Size = new Size(309, 108);
            panel4.TabIndex = 12;
            // 
            // lblRecentLog0
            // 
            lblRecentLog0.AutoSize = true;
            lblRecentLog0.BackColor = Color.FromArgb(235, 239, 244);
            lblRecentLog0.Font = new Font("Century Gothic", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRecentLog0.Location = new Point(145, 42);
            lblRecentLog0.Name = "lblRecentLog0";
            lblRecentLog0.Size = new Size(40, 44);
            lblRecentLog0.TabIndex = 7;
            lblRecentLog0.Text = "0";
            lblRecentLog0.Click += lblRecentLog0_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(235, 239, 244);
            pictureBox1.BackgroundImage = Properties.Resources.prepared;
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new Point(39, 31);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(53, 54);
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(235, 239, 244);
            label2.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(107, 21);
            label2.Name = "label2";
            label2.Size = new Size(117, 22);
            label2.TabIndex = 6;
            label2.Text = "Recent Logs";
            // 
            // panel2
            // 
            panel2.Controls.Add(label1);
            panel2.Controls.Add(pictureBox2);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(panel4);
            panel2.Controls.Add(panel5);
            panel2.Controls.Add(pictureBox8);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1215, 397);
            panel2.TabIndex = 1;
            panel2.Paint += panel2_Paint;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(22, 75);
            label1.Name = "label1";
            label1.Size = new Size(349, 20);
            label1.TabIndex = 54;
            label1.Text = "Monitor system access and manage staff permissions.";
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImage = Properties.Resources.Blue_Modern_Business_Marketing_Banner_Landscape;
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox2.Location = new Point(16, 116);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(428, 139);
            pictureBox2.TabIndex = 40;
            pictureBox2.TabStop = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Century Gothic", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(16, 25);
            label7.Name = "label7";
            label7.Size = new Size(320, 40);
            label7.TabIndex = 28;
            label7.Text = "User Management";
            // 
            // panel5
            // 
            panel5.BackgroundImage = Properties.Resources._21;
            panel5.BackgroundImageLayout = ImageLayout.Stretch;
            panel5.Controls.Add(lblTotalUser0);
            panel5.Controls.Add(pictureBox3);
            panel5.Controls.Add(label6);
            panel5.Location = new Point(475, 124);
            panel5.Name = "panel5";
            panel5.Size = new Size(298, 112);
            panel5.TabIndex = 13;
            // 
            // lblTotalUser0
            // 
            lblTotalUser0.AutoSize = true;
            lblTotalUser0.BackColor = Color.FromArgb(235, 239, 244);
            lblTotalUser0.Font = new Font("Century Gothic", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalUser0.Location = new Point(143, 46);
            lblTotalUser0.Name = "lblTotalUser0";
            lblTotalUser0.Size = new Size(40, 44);
            lblTotalUser0.TabIndex = 7;
            lblTotalUser0.Text = "0";
            lblTotalUser0.Click += lblTotalUser0_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.FromArgb(235, 239, 244);
            pictureBox3.BackgroundImage = Properties.Resources.group;
            pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox3.Location = new Point(39, 36);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(53, 54);
            pictureBox3.TabIndex = 5;
            pictureBox3.TabStop = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.FromArgb(235, 239, 244);
            label6.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(112, 24);
            label6.Name = "label6";
            label6.Size = new Size(94, 22);
            label6.TabIndex = 6;
            label6.Text = "Total User";
            // 
            // pictureBox8
            // 
            pictureBox8.BackColor = Color.White;
            pictureBox8.BackgroundImage = Properties.Resources._646378810_910016875123051_9142573013095368996_n__1__removebg_preview1;
            pictureBox8.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox8.Location = new Point(1092, 0);
            pictureBox8.Name = "pictureBox8";
            pictureBox8.Size = new Size(120, 118);
            pictureBox8.TabIndex = 39;
            pictureBox8.TabStop = false;
            // 
            // AuditTable
            // 
            AuditTable.Controls.Add(btnSearchAudit);
            AuditTable.Controls.Add(txtSearchAudit);
            AuditTable.Controls.Add(btnClear);
            AuditTable.Controls.Add(btnRefresh);
            AuditTable.Controls.Add(dgvAuditLogs);
            AuditTable.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AuditTable.Location = new Point(4, 29);
            AuditTable.Name = "AuditTable";
            AuditTable.Padding = new Padding(3);
            AuditTable.Size = new Size(1207, 515);
            AuditTable.TabIndex = 1;
            AuditTable.Text = "Audit Logs";
            AuditTable.UseVisualStyleBackColor = true;
            // 
            // btnSearchAudit
            // 
            btnSearchAudit.BackColor = Color.FromArgb(235, 239, 244);
            btnSearchAudit.BackgroundImageLayout = ImageLayout.Zoom;
            btnSearchAudit.BorderColor = Color.FromArgb(235, 239, 244);
            btnSearchAudit.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            btnSearchAudit.DangerColor = Color.FromArgb(245, 108, 108);
            btnSearchAudit.DefaultColor = Color.FromArgb(255, 255, 255);
            btnSearchAudit.Font = new Font("Century Gothic", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSearchAudit.HoverTextColor = Color.FromArgb(48, 49, 51);
            btnSearchAudit.InfoColor = Color.FromArgb(144, 147, 153);
            btnSearchAudit.Location = new Point(1082, 15);
            btnSearchAudit.Name = "btnSearchAudit";
            btnSearchAudit.PrimaryColor = Color.FromArgb(11, 45, 114);
            btnSearchAudit.Size = new Size(92, 39);
            btnSearchAudit.SuccessColor = Color.FromArgb(103, 194, 58);
            btnSearchAudit.TabIndex = 59;
            btnSearchAudit.Text = "Search";
            btnSearchAudit.TextColor = Color.White;
            btnSearchAudit.WarningColor = Color.FromArgb(230, 162, 60);
            btnSearchAudit.Click += btnSearchAudit_Click;
            // 
            // txtSearchAudit
            // 
            txtSearchAudit.BackColor = Color.FromArgb(235, 239, 244);
            // 
            // 
            // 
            txtSearchAudit.CustomButton.Image = null;
            txtSearchAudit.CustomButton.Location = new Point(217, 1);
            txtSearchAudit.CustomButton.Name = "";
            txtSearchAudit.CustomButton.Size = new Size(27, 27);
            txtSearchAudit.CustomButton.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Blue;
            txtSearchAudit.CustomButton.TabIndex = 1;
            txtSearchAudit.CustomButton.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
            txtSearchAudit.CustomButton.UseSelectable = true;
            txtSearchAudit.CustomButton.Visible = false;
            txtSearchAudit.Location = new Point(831, 16);
            txtSearchAudit.MaxLength = 32767;
            txtSearchAudit.Name = "txtSearchAudit";
            txtSearchAudit.PasswordChar = '\0';
            txtSearchAudit.ScrollBars = ScrollBars.None;
            txtSearchAudit.SelectedText = "";
            txtSearchAudit.SelectionLength = 0;
            txtSearchAudit.SelectionStart = 0;
            txtSearchAudit.ShortcutsEnabled = true;
            txtSearchAudit.Size = new Size(245, 29);
            txtSearchAudit.TabIndex = 60;
            txtSearchAudit.UseSelectable = true;
            txtSearchAudit.WaterMarkColor = Color.FromArgb(109, 109, 109);
            txtSearchAudit.WaterMarkFont = new Font("Segoe UI", 12F, FontStyle.Italic, GraphicsUnit.Pixel);
            txtSearchAudit.Click += txtSearchAudit_Click;
            // 
            // btnClear
            // 
            btnClear.BorderColor = Color.FromArgb(220, 223, 230);
            btnClear.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            btnClear.DangerColor = Color.FromArgb(245, 108, 108);
            btnClear.DefaultColor = Color.FromArgb(255, 255, 255);
            btnClear.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClear.HoverTextColor = Color.FromArgb(48, 49, 51);
            btnClear.InfoColor = Color.FromArgb(144, 147, 153);
            btnClear.Location = new Point(915, 455);
            btnClear.Name = "btnClear";
            btnClear.PrimaryColor = Color.DarkBlue;
            btnClear.Size = new Size(161, 39);
            btnClear.SuccessColor = Color.FromArgb(103, 194, 58);
            btnClear.TabIndex = 58;
            btnClear.Text = "    Clear Logs";
            btnClear.TextColor = Color.White;
            btnClear.WarningColor = Color.FromArgb(230, 162, 60);
            btnClear.Click += btnClear_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.White;
            btnRefresh.BackgroundImageLayout = ImageLayout.Zoom;
            btnRefresh.BorderColor = Color.FromArgb(235, 239, 244);
            btnRefresh.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            btnRefresh.DangerColor = Color.FromArgb(245, 108, 108);
            btnRefresh.DefaultColor = Color.FromArgb(255, 255, 255);
            btnRefresh.Font = new Font("Century Gothic", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRefresh.HoverTextColor = Color.FromArgb(48, 49, 51);
            btnRefresh.InfoColor = Color.FromArgb(144, 147, 153);
            btnRefresh.Location = new Point(1082, 455);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.PrimaryColor = Color.FromArgb(11, 45, 114);
            btnRefresh.Size = new Size(92, 39);
            btnRefresh.SuccessColor = Color.FromArgb(103, 194, 58);
            btnRefresh.TabIndex = 55;
            btnRefresh.Text = "Refresh";
            btnRefresh.TextColor = Color.White;
            btnRefresh.WarningColor = Color.FromArgb(230, 162, 60);
            btnRefresh.Click += btnRefresh_Click;
            // 
            // dgvAuditLogs
            // 
            dgvAuditLogs.AllowUserToResizeRows = false;
            dgvAuditLogs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAuditLogs.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvAuditLogs.BackgroundColor = Color.FromArgb(255, 255, 255);
            dgvAuditLogs.BorderStyle = BorderStyle.None;
            dgvAuditLogs.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvAuditLogs.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.DarkBlue;
            dataGridViewCellStyle1.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(255, 255, 255);
            dataGridViewCellStyle1.Padding = new Padding(7);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(0, 198, 247);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(17, 17, 17);
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvAuditLogs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvAuditLogs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAuditLogs.Columns.AddRange(new DataGridViewColumn[] { Timestamp, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5 });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(255, 255, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(136, 136, 136);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(0, 198, 247);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(17, 17, 17);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvAuditLogs.DefaultCellStyle = dataGridViewCellStyle2;
            dgvAuditLogs.EnableHeadersVisualStyles = false;
            dgvAuditLogs.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
            dgvAuditLogs.GridColor = Color.FromArgb(255, 255, 255);
            dgvAuditLogs.Location = new Point(12, 60);
            dgvAuditLogs.Name = "dgvAuditLogs";
            dgvAuditLogs.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(0, 174, 219);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(255, 255, 255);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(0, 198, 247);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(17, 17, 17);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvAuditLogs.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvAuditLogs.RowHeadersWidth = 51;
            dgvAuditLogs.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvAuditLogs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAuditLogs.Size = new Size(1162, 375);
            dgvAuditLogs.TabIndex = 1;
            dgvAuditLogs.CellContentClick += poisonDataGridView2_CellContentClick;
            // 
            // Timestamp
            // 
            Timestamp.DataPropertyName = "timestamp";
            Timestamp.HeaderText = "Timestamp";
            Timestamp.MinimumWidth = 6;
            Timestamp.Name = "Timestamp";
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.DataPropertyName = "email";
            dataGridViewTextBoxColumn2.HeaderText = "Email";
            dataGridViewTextBoxColumn2.MinimumWidth = 6;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.DataPropertyName = "activity";
            dataGridViewTextBoxColumn3.HeaderText = "Activity";
            dataGridViewTextBoxColumn3.MinimumWidth = 6;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.DataPropertyName = "description";
            dataGridViewTextBoxColumn4.HeaderText = "Description";
            dataGridViewTextBoxColumn4.MinimumWidth = 6;
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.DataPropertyName = "status";
            dataGridViewTextBoxColumn5.HeaderText = "Status";
            dataGridViewTextBoxColumn5.MinimumWidth = 6;
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.White;
            tabPage1.Controls.Add(label11);
            tabPage1.Controls.Add(label8);
            tabPage1.Controls.Add(btnSearch);
            tabPage1.Controls.Add(txtSearch);
            tabPage1.Controls.Add(btnDeleteUser);
            tabPage1.Controls.Add(btnAddUser);
            tabPage1.Controls.Add(btnUpdateUser);
            tabPage1.Controls.Add(dgvUserManagemend);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1207, 515);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "User Management";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.Transparent;
            label11.Font = new Font("Century Gothic", 7.8F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label11.Location = new Point(811, 87);
            label11.Name = "label11";
            label11.Size = new Size(263, 16);
            label11.TabIndex = 53;
            label11.Text = "Centralized user account management";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Century Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(810, 38);
            label8.Name = "label8";
            label8.Size = new Size(223, 37);
            label8.TabIndex = 36;
            label8.Text = "Manage Users";
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
            btnSearch.Location = new Point(1063, 127);
            btnSearch.Name = "btnSearch";
            btnSearch.PrimaryColor = Color.FromArgb(11, 45, 114);
            btnSearch.Size = new Size(92, 39);
            btnSearch.SuccessColor = Color.FromArgb(103, 194, 58);
            btnSearch.TabIndex = 51;
            btnSearch.Text = "Search";
            btnSearch.TextColor = Color.White;
            btnSearch.WarningColor = Color.FromArgb(230, 162, 60);
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearch
            // 
            txtSearch.BackColor = Color.FromArgb(235, 239, 244);
            // 
            // 
            // 
            txtSearch.CustomButton.Image = null;
            txtSearch.CustomButton.Location = new Point(191, 2);
            txtSearch.CustomButton.Name = "";
            txtSearch.CustomButton.Size = new Size(27, 27);
            txtSearch.CustomButton.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Blue;
            txtSearch.CustomButton.TabIndex = 1;
            txtSearch.CustomButton.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
            txtSearch.CustomButton.UseSelectable = true;
            txtSearch.CustomButton.Visible = false;
            txtSearch.Location = new Point(836, 134);
            txtSearch.MaxLength = 32767;
            txtSearch.Name = "txtSearch";
            txtSearch.PasswordChar = '\0';
            txtSearch.ScrollBars = ScrollBars.None;
            txtSearch.SelectedText = "";
            txtSearch.SelectionLength = 0;
            txtSearch.SelectionStart = 0;
            txtSearch.ShortcutsEnabled = true;
            txtSearch.Size = new Size(221, 32);
            txtSearch.TabIndex = 52;
            txtSearch.UseSelectable = true;
            txtSearch.WaterMarkColor = Color.FromArgb(109, 109, 109);
            txtSearch.WaterMarkFont = new Font("Segoe UI", 12F, FontStyle.Italic, GraphicsUnit.Pixel);
            txtSearch.Click += txtSearch_Click;
            // 
            // btnDeleteUser
            // 
            btnDeleteUser.BorderColor = Color.FromArgb(220, 223, 230);
            btnDeleteUser.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            btnDeleteUser.DangerColor = Color.FromArgb(245, 108, 108);
            btnDeleteUser.DefaultColor = Color.FromArgb(255, 255, 255);
            btnDeleteUser.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDeleteUser.HoverTextColor = Color.FromArgb(48, 49, 51);
            btnDeleteUser.InfoColor = Color.FromArgb(144, 147, 153);
            btnDeleteUser.Location = new Point(821, 382);
            btnDeleteUser.Name = "btnDeleteUser";
            btnDeleteUser.PrimaryColor = Color.DarkBlue;
            btnDeleteUser.Size = new Size(345, 60);
            btnDeleteUser.SuccessColor = Color.FromArgb(103, 194, 58);
            btnDeleteUser.TabIndex = 50;
            btnDeleteUser.Text = "    Delere User";
            btnDeleteUser.TextColor = Color.White;
            btnDeleteUser.WarningColor = Color.FromArgb(230, 162, 60);
            btnDeleteUser.Click += btnDeleteUser_Click;
            // 
            // btnAddUser
            // 
            btnAddUser.BorderColor = Color.FromArgb(220, 223, 230);
            btnAddUser.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            btnAddUser.DangerColor = Color.FromArgb(245, 108, 108);
            btnAddUser.DefaultColor = Color.FromArgb(255, 255, 255);
            btnAddUser.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddUser.HoverTextColor = Color.FromArgb(48, 49, 51);
            btnAddUser.InfoColor = Color.FromArgb(144, 147, 153);
            btnAddUser.Location = new Point(821, 204);
            btnAddUser.Name = "btnAddUser";
            btnAddUser.PrimaryColor = Color.DarkBlue;
            btnAddUser.Size = new Size(345, 60);
            btnAddUser.SuccessColor = Color.FromArgb(103, 194, 58);
            btnAddUser.TabIndex = 48;
            btnAddUser.Text = "   Add User";
            btnAddUser.TextColor = Color.White;
            btnAddUser.WarningColor = Color.FromArgb(230, 162, 60);
            btnAddUser.Click += btnAddUser_Click;
            // 
            // btnUpdateUser
            // 
            btnUpdateUser.BorderColor = Color.FromArgb(220, 223, 230);
            btnUpdateUser.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            btnUpdateUser.DangerColor = Color.FromArgb(245, 108, 108);
            btnUpdateUser.DefaultColor = Color.FromArgb(255, 255, 255);
            btnUpdateUser.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUpdateUser.HoverTextColor = Color.FromArgb(48, 49, 51);
            btnUpdateUser.InfoColor = Color.FromArgb(144, 147, 153);
            btnUpdateUser.Location = new Point(821, 292);
            btnUpdateUser.Name = "btnUpdateUser";
            btnUpdateUser.PrimaryColor = Color.DarkBlue;
            btnUpdateUser.Size = new Size(345, 60);
            btnUpdateUser.SuccessColor = Color.FromArgb(103, 194, 58);
            btnUpdateUser.TabIndex = 49;
            btnUpdateUser.Text = "    Update User";
            btnUpdateUser.TextColor = Color.White;
            btnUpdateUser.WarningColor = Color.FromArgb(230, 162, 60);
            btnUpdateUser.Click += btnUpdateUser_Click;
            // 
            // dgvUserManagemend
            // 
            dgvUserManagemend.AllowUserToResizeRows = false;
            dgvUserManagemend.BackgroundColor = Color.FromArgb(255, 255, 255);
            dgvUserManagemend.BorderStyle = BorderStyle.None;
            dgvUserManagemend.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvUserManagemend.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = Color.DarkBlue;
            dataGridViewCellStyle4.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(255, 255, 255);
            dataGridViewCellStyle4.Padding = new Padding(7);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(0, 198, 247);
            dataGridViewCellStyle4.SelectionForeColor = Color.FromArgb(17, 17, 17);
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvUserManagemend.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvUserManagemend.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUserManagemend.Columns.AddRange(new DataGridViewColumn[] { ID, ColFullName, Role, Email, Status });
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(255, 255, 255);
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
            dataGridViewCellStyle5.ForeColor = Color.FromArgb(136, 136, 136);
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(0, 198, 247);
            dataGridViewCellStyle5.SelectionForeColor = Color.FromArgb(17, 17, 17);
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            dgvUserManagemend.DefaultCellStyle = dataGridViewCellStyle5;
            dgvUserManagemend.EnableHeadersVisualStyles = false;
            dgvUserManagemend.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
            dgvUserManagemend.GridColor = Color.FromArgb(255, 255, 255);
            dgvUserManagemend.Location = new Point(12, 36);
            dgvUserManagemend.Name = "dgvUserManagemend";
            dgvUserManagemend.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.FromArgb(0, 174, 219);
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
            dataGridViewCellStyle6.ForeColor = Color.FromArgb(255, 255, 255);
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(0, 198, 247);
            dataGridViewCellStyle6.SelectionForeColor = Color.FromArgb(17, 17, 17);
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            dgvUserManagemend.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            dgvUserManagemend.RowHeadersWidth = 51;
            dgvUserManagemend.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvUserManagemend.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUserManagemend.Size = new Size(792, 507);
            dgvUserManagemend.TabIndex = 0;
            dgvUserManagemend.CellContentClick += poisonDataGridView1_CellContentClick;
            // 
            // ID
            // 
            ID.DataPropertyName = "user_id";
            ID.HeaderText = "User ID";
            ID.MinimumWidth = 6;
            ID.Name = "ID";
            ID.Width = 125;
            // 
            // ColFullName
            // 
            ColFullName.DataPropertyName = "full_name";
            ColFullName.HeaderText = "Name";
            ColFullName.MinimumWidth = 6;
            ColFullName.Name = "ColFullName";
            ColFullName.Width = 125;
            // 
            // Role
            // 
            Role.DataPropertyName = "role_name";
            Role.HeaderText = "Role";
            Role.MinimumWidth = 6;
            Role.Name = "Role";
            Role.Width = 125;
            // 
            // Email
            // 
            Email.DataPropertyName = "email";
            Email.HeaderText = "Email";
            Email.MinimumWidth = 6;
            Email.Name = "Email";
            Email.Width = 125;
            // 
            // Status
            // 
            Status.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Status.DataPropertyName = "status";
            Status.HeaderText = "Status";
            Status.MinimumWidth = 6;
            Status.Name = "Status";
            // 
            // UserManagementTable
            // 
            UserManagementTable.Controls.Add(tabPage1);
            UserManagementTable.Controls.Add(AuditTable);
            UserManagementTable.Dock = DockStyle.Bottom;
            UserManagementTable.Location = new Point(0, 284);
            UserManagementTable.Name = "UserManagementTable";
            UserManagementTable.SelectedIndex = 0;
            UserManagementTable.Size = new Size(1215, 548);
            UserManagementTable.TabIndex = 2;
            // 
            // UC_UserManagement
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(UserManagementTable);
            Controls.Add(panel2);
            Name = "UC_UserManagement";
            Size = new Size(1215, 832);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).EndInit();
            AuditTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAuditLogs).EndInit();
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUserManagemend).EndInit();
            UserManagementTable.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel panel4;
        private Label lblRecentLog0;
        private PictureBox pictureBox1;
        private Label label2;
        private Panel panel2;
        private Panel panel5;
        private Label lblTotalUser0;
        private PictureBox pictureBox3;
        private Label label6;
        private TabPage AuditTable;
        private ReaLTaiizor.Controls.HopeRoundButton btnSearchAudit;
        private ReaLTaiizor.Controls.PoisonTextBox txtSearchAudit;
        private ReaLTaiizor.Controls.HopeRoundButton btnClear;
        private ReaLTaiizor.Controls.HopeRoundButton btnRefresh;
        private ReaLTaiizor.Controls.PoisonDataGridView dgvAuditLogs;
        private TabPage tabPage1;
        private ReaLTaiizor.Controls.HopeRoundButton btnSearch;
        private ReaLTaiizor.Controls.PoisonTextBox txtSearch;
        private ReaLTaiizor.Controls.HopeRoundButton btnDeleteUser;
        private ReaLTaiizor.Controls.HopeRoundButton btnAddUser;
        private ReaLTaiizor.Controls.HopeRoundButton btnUpdateUser;
        private ReaLTaiizor.Controls.PoisonDataGridView dgvUserManagemend;
        private TabControl UserManagementTable;
        private DataGridViewTextBoxColumn Timestamp;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private Label label7;
        private Label label8;
        private Label label11;
        private PictureBox pictureBox8;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn ColFullName;
        private DataGridViewTextBoxColumn Role;
        private DataGridViewTextBoxColumn Email;
        private DataGridViewTextBoxColumn Status;
        private PictureBox pictureBox2;
        private Label label1;
    }
}
