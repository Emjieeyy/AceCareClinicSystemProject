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
            DataGridViewCellStyle dataGridViewCellStyle19 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle20 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle21 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle22 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle23 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle24 = new DataGridViewCellStyle();
            panel4 = new Panel();
            lblRecentLog0 = new Label();
            pictureBox1 = new PictureBox();
            label2 = new Label();
            panel2 = new Panel();
            panel5 = new Panel();
            lblTotalUser0 = new Label();
            pictureBox3 = new PictureBox();
            label6 = new Label();
            AuditTable = new TabPage();
            btnSearchAudit = new ReaLTaiizor.Controls.HopeRoundButton();
            txtSearchAudit = new ReaLTaiizor.Controls.PoisonTextBox();
            btnExport = new ReaLTaiizor.Controls.HopeRoundButton();
            btnClear = new ReaLTaiizor.Controls.HopeRoundButton();
            btnRefresh = new ReaLTaiizor.Controls.HopeRoundButton();
            txtFilterActivity = new ReaLTaiizor.Controls.PoisonTextBox();
            dgvAuditLogs = new ReaLTaiizor.Controls.PoisonDataGridView();
            Timestamp = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            tabPage1 = new TabPage();
            btnSearch = new ReaLTaiizor.Controls.HopeRoundButton();
            txtSearch = new ReaLTaiizor.Controls.PoisonTextBox();
            btnDeleteUser = new ReaLTaiizor.Controls.HopeRoundButton();
            btnAddUser = new ReaLTaiizor.Controls.HopeRoundButton();
            btnUpdateUser = new ReaLTaiizor.Controls.HopeRoundButton();
            dgvUserManagemend = new ReaLTaiizor.Controls.PoisonDataGridView();
            ID = new DataGridViewTextBoxColumn();
            Name = new DataGridViewTextBoxColumn();
            Role = new DataGridViewTextBoxColumn();
            Email = new DataGridViewTextBoxColumn();
            Status = new DataGridViewTextBoxColumn();
            UserManagementTable = new TabControl();
            label7 = new Label();
            label8 = new Label();
            label11 = new Label();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
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
            panel4.Location = new Point(566, 113);
            panel4.Name = "panel4";
            panel4.Size = new Size(270, 108);
            panel4.TabIndex = 12;
            // 
            // lblRecentLog0
            // 
            lblRecentLog0.AutoSize = true;
            lblRecentLog0.BackColor = Color.FromArgb(235, 239, 244);
            lblRecentLog0.Font = new Font("Century Gothic", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRecentLog0.Location = new Point(127, 42);
            lblRecentLog0.Name = "lblRecentLog0";
            lblRecentLog0.Size = new Size(40, 44);
            lblRecentLog0.TabIndex = 7;
            lblRecentLog0.Text = "0";
            lblRecentLog0.Click += lblRecentLog0_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(235, 239, 244);
            pictureBox1.BackgroundImage = Properties.Resources.medical_supplies;
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new Point(30, 33);
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
            label2.Location = new Point(89, 21);
            label2.Name = "label2";
            label2.Size = new Size(117, 22);
            label2.TabIndex = 6;
            label2.Text = "Recent Logs";
            // 
            // panel2
            // 
            panel2.Controls.Add(label7);
            panel2.Controls.Add(panel4);
            panel2.Controls.Add(panel5);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1072, 227);
            panel2.TabIndex = 1;
            panel2.Paint += panel2_Paint;
            // 
            // panel5
            // 
            panel5.BackgroundImage = Properties.Resources._21;
            panel5.BackgroundImageLayout = ImageLayout.Stretch;
            panel5.Controls.Add(lblTotalUser0);
            panel5.Controls.Add(pictureBox3);
            panel5.Controls.Add(label6);
            panel5.Location = new Point(239, 109);
            panel5.Name = "panel5";
            panel5.Size = new Size(270, 112);
            panel5.TabIndex = 13;
            // 
            // lblTotalUser0
            // 
            lblTotalUser0.AutoSize = true;
            lblTotalUser0.BackColor = Color.FromArgb(235, 239, 244);
            lblTotalUser0.Font = new Font("Century Gothic", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalUser0.Location = new Point(126, 47);
            lblTotalUser0.Name = "lblTotalUser0";
            lblTotalUser0.Size = new Size(40, 44);
            lblTotalUser0.TabIndex = 7;
            lblTotalUser0.Text = "0";
            lblTotalUser0.Click += lblTotalUser0_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.FromArgb(235, 239, 244);
            pictureBox3.BackgroundImage = Properties.Resources.medical_supplies;
            pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox3.Location = new Point(30, 38);
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
            label6.Location = new Point(95, 27);
            label6.Name = "label6";
            label6.Size = new Size(94, 22);
            label6.TabIndex = 6;
            label6.Text = "Total User";
            // 
            // AuditTable
            // 
            AuditTable.Controls.Add(btnSearchAudit);
            AuditTable.Controls.Add(txtSearchAudit);
            AuditTable.Controls.Add(btnExport);
            AuditTable.Controls.Add(btnClear);
            AuditTable.Controls.Add(btnRefresh);
            AuditTable.Controls.Add(txtFilterActivity);
            AuditTable.Controls.Add(dgvAuditLogs);
            AuditTable.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AuditTable.Location = new Point(4, 29);
            AuditTable.Name = "AuditTable";
            AuditTable.Padding = new Padding(3);
            AuditTable.Size = new Size(1064, 464);
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
            btnSearchAudit.Location = new Point(943, 61);
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
            txtSearchAudit.CustomButton.Location = new Point(183, 1);
            txtSearchAudit.CustomButton.Name = "";
            txtSearchAudit.CustomButton.Size = new Size(37, 37);
            txtSearchAudit.CustomButton.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Blue;
            txtSearchAudit.CustomButton.TabIndex = 1;
            txtSearchAudit.CustomButton.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
            txtSearchAudit.CustomButton.UseSelectable = true;
            txtSearchAudit.CustomButton.Visible = false;
            txtSearchAudit.Location = new Point(716, 62);
            txtSearchAudit.MaxLength = 32767;
            txtSearchAudit.Name = "txtSearchAudit";
            txtSearchAudit.PasswordChar = '\0';
            txtSearchAudit.ScrollBars = ScrollBars.None;
            txtSearchAudit.SelectedText = "";
            txtSearchAudit.SelectionLength = 0;
            txtSearchAudit.SelectionStart = 0;
            txtSearchAudit.ShortcutsEnabled = true;
            txtSearchAudit.Size = new Size(221, 39);
            txtSearchAudit.TabIndex = 60;
            txtSearchAudit.UseSelectable = true;
            txtSearchAudit.WaterMarkColor = Color.FromArgb(109, 109, 109);
            txtSearchAudit.WaterMarkFont = new Font("Segoe UI", 12F, FontStyle.Italic, GraphicsUnit.Pixel);
            txtSearchAudit.Click += txtSearchAudit_Click;
            // 
            // btnExport
            // 
            btnExport.BorderColor = Color.FromArgb(220, 223, 230);
            btnExport.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            btnExport.DangerColor = Color.FromArgb(245, 108, 108);
            btnExport.DefaultColor = Color.FromArgb(255, 255, 255);
            btnExport.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExport.HoverTextColor = Color.FromArgb(48, 49, 51);
            btnExport.InfoColor = Color.FromArgb(144, 147, 153);
            btnExport.Location = new Point(733, 279);
            btnExport.Name = "btnExport";
            btnExport.PrimaryColor = Color.DarkBlue;
            btnExport.Size = new Size(302, 60);
            btnExport.SuccessColor = Color.FromArgb(103, 194, 58);
            btnExport.TabIndex = 57;
            btnExport.Text = "      Export";
            btnExport.TextColor = Color.White;
            btnExport.WarningColor = Color.FromArgb(230, 162, 60);
            btnExport.Click += btnExport_Click;
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
            btnClear.Location = new Point(736, 192);
            btnClear.Name = "btnClear";
            btnClear.PrimaryColor = Color.DarkBlue;
            btnClear.Size = new Size(299, 60);
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
            btnRefresh.Location = new Point(586, 15);
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
            // txtFilterActivity
            // 
            txtFilterActivity.BackColor = Color.FromArgb(235, 239, 244);
            // 
            // 
            // 
            txtFilterActivity.CustomButton.Image = null;
            txtFilterActivity.CustomButton.Location = new Point(217, 2);
            txtFilterActivity.CustomButton.Name = "";
            txtFilterActivity.CustomButton.Size = new Size(25, 25);
            txtFilterActivity.CustomButton.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Blue;
            txtFilterActivity.CustomButton.TabIndex = 1;
            txtFilterActivity.CustomButton.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
            txtFilterActivity.CustomButton.UseSelectable = true;
            txtFilterActivity.CustomButton.Visible = false;
            txtFilterActivity.Location = new Point(335, 16);
            txtFilterActivity.MaxLength = 32767;
            txtFilterActivity.Name = "txtFilterActivity";
            txtFilterActivity.PasswordChar = '\0';
            txtFilterActivity.ScrollBars = ScrollBars.None;
            txtFilterActivity.SelectedText = "";
            txtFilterActivity.SelectionLength = 0;
            txtFilterActivity.SelectionStart = 0;
            txtFilterActivity.ShortcutsEnabled = true;
            txtFilterActivity.Size = new Size(245, 30);
            txtFilterActivity.TabIndex = 56;
            txtFilterActivity.UseSelectable = true;
            txtFilterActivity.WaterMarkColor = Color.FromArgb(109, 109, 109);
            txtFilterActivity.WaterMarkFont = new Font("Segoe UI", 12F, FontStyle.Italic, GraphicsUnit.Pixel);
            txtFilterActivity.Click += txtFilterActivity_Click;
            // 
            // dgvAuditLogs
            // 
            dgvAuditLogs.AllowUserToResizeRows = false;
            dgvAuditLogs.BackgroundColor = Color.FromArgb(255, 255, 255);
            dgvAuditLogs.BorderStyle = BorderStyle.None;
            dgvAuditLogs.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvAuditLogs.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle19.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle19.BackColor = Color.DarkBlue;
            dataGridViewCellStyle19.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle19.ForeColor = Color.FromArgb(255, 255, 255);
            dataGridViewCellStyle19.Padding = new Padding(7);
            dataGridViewCellStyle19.SelectionBackColor = Color.FromArgb(0, 198, 247);
            dataGridViewCellStyle19.SelectionForeColor = Color.FromArgb(17, 17, 17);
            dataGridViewCellStyle19.WrapMode = DataGridViewTriState.True;
            dgvAuditLogs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle19;
            dgvAuditLogs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAuditLogs.Columns.AddRange(new DataGridViewColumn[] { Timestamp, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5 });
            dataGridViewCellStyle20.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = Color.FromArgb(255, 255, 255);
            dataGridViewCellStyle20.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
            dataGridViewCellStyle20.ForeColor = Color.FromArgb(136, 136, 136);
            dataGridViewCellStyle20.SelectionBackColor = Color.FromArgb(0, 198, 247);
            dataGridViewCellStyle20.SelectionForeColor = Color.FromArgb(17, 17, 17);
            dataGridViewCellStyle20.WrapMode = DataGridViewTriState.False;
            dgvAuditLogs.DefaultCellStyle = dataGridViewCellStyle20;
            dgvAuditLogs.EnableHeadersVisualStyles = false;
            dgvAuditLogs.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
            dgvAuditLogs.GridColor = Color.FromArgb(255, 255, 255);
            dgvAuditLogs.Location = new Point(3, 62);
            dgvAuditLogs.Name = "dgvAuditLogs";
            dgvAuditLogs.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle21.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle21.BackColor = Color.FromArgb(0, 174, 219);
            dataGridViewCellStyle21.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
            dataGridViewCellStyle21.ForeColor = Color.FromArgb(255, 255, 255);
            dataGridViewCellStyle21.SelectionBackColor = Color.FromArgb(0, 198, 247);
            dataGridViewCellStyle21.SelectionForeColor = Color.FromArgb(17, 17, 17);
            dataGridViewCellStyle21.WrapMode = DataGridViewTriState.True;
            dgvAuditLogs.RowHeadersDefaultCellStyle = dataGridViewCellStyle21;
            dgvAuditLogs.RowHeadersWidth = 51;
            dgvAuditLogs.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvAuditLogs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAuditLogs.Size = new Size(680, 399);
            dgvAuditLogs.TabIndex = 1;
            dgvAuditLogs.CellContentClick += poisonDataGridView2_CellContentClick;
            // 
            // Timestamp
            // 
            Timestamp.DataPropertyName = "created_at";
            Timestamp.HeaderText = "Timestamp";
            Timestamp.MinimumWidth = 6;
            Timestamp.Name = "Timestamp";
            Timestamp.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.DataPropertyName = "email";
            dataGridViewTextBoxColumn2.HeaderText = "Email";
            dataGridViewTextBoxColumn2.MinimumWidth = 6;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.Width = 125;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.DataPropertyName = "action";
            dataGridViewTextBoxColumn3.HeaderText = "Activity";
            dataGridViewTextBoxColumn3.MinimumWidth = 6;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.Width = 125;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.DataPropertyName = "details";
            dataGridViewTextBoxColumn4.HeaderText = "Description";
            dataGridViewTextBoxColumn4.MinimumWidth = 6;
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.Width = 125;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.DataPropertyName = "status";
            dataGridViewTextBoxColumn5.HeaderText = "Status";
            dataGridViewTextBoxColumn5.MinimumWidth = 6;
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            dataGridViewTextBoxColumn5.Width = 125;
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
            tabPage1.Size = new Size(1064, 438);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "User Management";
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
            btnSearch.Location = new Point(952, 104);
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
            txtSearch.CustomButton.Location = new Point(183, 1);
            txtSearch.CustomButton.Name = "";
            txtSearch.CustomButton.Size = new Size(37, 37);
            txtSearch.CustomButton.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Blue;
            txtSearch.CustomButton.TabIndex = 1;
            txtSearch.CustomButton.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
            txtSearch.CustomButton.UseSelectable = true;
            txtSearch.CustomButton.Visible = false;
            txtSearch.Location = new Point(725, 105);
            txtSearch.MaxLength = 32767;
            txtSearch.Name = "txtSearch";
            txtSearch.PasswordChar = '\0';
            txtSearch.ScrollBars = ScrollBars.None;
            txtSearch.SelectedText = "";
            txtSearch.SelectionLength = 0;
            txtSearch.SelectionStart = 0;
            txtSearch.ShortcutsEnabled = true;
            txtSearch.Size = new Size(221, 39);
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
            btnDeleteUser.Location = new Point(725, 333);
            btnDeleteUser.Name = "btnDeleteUser";
            btnDeleteUser.PrimaryColor = Color.DarkBlue;
            btnDeleteUser.Size = new Size(313, 60);
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
            btnAddUser.Location = new Point(725, 169);
            btnAddUser.Name = "btnAddUser";
            btnAddUser.PrimaryColor = Color.DarkBlue;
            btnAddUser.Size = new Size(313, 60);
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
            btnUpdateUser.Location = new Point(725, 252);
            btnUpdateUser.Name = "btnUpdateUser";
            btnUpdateUser.PrimaryColor = Color.DarkBlue;
            btnUpdateUser.Size = new Size(313, 60);
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
            dataGridViewCellStyle22.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle22.BackColor = Color.DarkBlue;
            dataGridViewCellStyle22.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle22.ForeColor = Color.FromArgb(255, 255, 255);
            dataGridViewCellStyle22.Padding = new Padding(7);
            dataGridViewCellStyle22.SelectionBackColor = Color.FromArgb(0, 198, 247);
            dataGridViewCellStyle22.SelectionForeColor = Color.FromArgb(17, 17, 17);
            dataGridViewCellStyle22.WrapMode = DataGridViewTriState.True;
            dgvUserManagemend.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle22;
            dgvUserManagemend.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUserManagemend.Columns.AddRange(new DataGridViewColumn[] { ID, Name, Role, Email, Status });
            dataGridViewCellStyle23.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle23.BackColor = Color.FromArgb(255, 255, 255);
            dataGridViewCellStyle23.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
            dataGridViewCellStyle23.ForeColor = Color.FromArgb(136, 136, 136);
            dataGridViewCellStyle23.SelectionBackColor = Color.FromArgb(0, 198, 247);
            dataGridViewCellStyle23.SelectionForeColor = Color.FromArgb(17, 17, 17);
            dataGridViewCellStyle23.WrapMode = DataGridViewTriState.False;
            dgvUserManagemend.DefaultCellStyle = dataGridViewCellStyle23;
            dgvUserManagemend.Dock = DockStyle.Left;
            dgvUserManagemend.EnableHeadersVisualStyles = false;
            dgvUserManagemend.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
            dgvUserManagemend.GridColor = Color.FromArgb(255, 255, 255);
            dgvUserManagemend.Location = new Point(3, 3);
            dgvUserManagemend.Name = "dgvUserManagemend";
            dgvUserManagemend.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle24.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle24.BackColor = Color.FromArgb(0, 174, 219);
            dataGridViewCellStyle24.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
            dataGridViewCellStyle24.ForeColor = Color.FromArgb(255, 255, 255);
            dataGridViewCellStyle24.SelectionBackColor = Color.FromArgb(0, 198, 247);
            dataGridViewCellStyle24.SelectionForeColor = Color.FromArgb(17, 17, 17);
            dataGridViewCellStyle24.WrapMode = DataGridViewTriState.True;
            dgvUserManagemend.RowHeadersDefaultCellStyle = dataGridViewCellStyle24;
            dgvUserManagemend.RowHeadersWidth = 51;
            dgvUserManagemend.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvUserManagemend.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUserManagemend.Size = new Size(680, 432);
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
            // Name
            // 
            Name.DataPropertyName = "full_name";
            Name.HeaderText = "Name";
            Name.MinimumWidth = 6;
            Name.Name = "Name";
            Name.Width = 125;
            // 
            // Role
            // 
            Role.DataPropertyName = "role_id";
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
            Status.DataPropertyName = "status";
            Status.HeaderText = "Status";
            Status.MinimumWidth = 6;
            Status.Name = "Status";
            Status.Width = 125;
            // 
            // UserManagementTable
            // 
            UserManagementTable.Controls.Add(tabPage1);
            UserManagementTable.Controls.Add(AuditTable);
            UserManagementTable.Dock = DockStyle.Fill;
            UserManagementTable.Location = new Point(0, 227);
            UserManagementTable.Name = "UserManagementTable";
            UserManagementTable.SelectedIndex = 0;
            UserManagementTable.Size = new Size(1072, 471);
            UserManagementTable.TabIndex = 2;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Century Gothic", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(19, 31);
            label7.Name = "label7";
            label7.Size = new Size(320, 40);
            label7.TabIndex = 28;
            label7.Text = "User Management";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.FromArgb(235, 239, 244);
            label8.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(725, 29);
            label8.Name = "label8";
            label8.Size = new Size(170, 27);
            label8.TabIndex = 36;
            label8.Text = "Manage Users";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.Transparent;
            label11.Font = new Font("Century Gothic", 7.8F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label11.Location = new Point(725, 72);
            label11.Name = "label11";
            label11.Size = new Size(263, 16);
            label11.TabIndex = 53;
            label11.Text = "Centralized user account management";
            // 
            // UC_UserManagement
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(UserManagementTable);
            Controls.Add(panel2);
         
            Size = new Size(1072, 698);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
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
        private ReaLTaiizor.Controls.HopeRoundButton btnExport;
        private ReaLTaiizor.Controls.HopeRoundButton btnClear;
        private ReaLTaiizor.Controls.HopeRoundButton btnRefresh;
        private ReaLTaiizor.Controls.PoisonTextBox txtFilterActivity;
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
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn Name;
        private DataGridViewTextBoxColumn Role;
        private DataGridViewTextBoxColumn Email;
        private DataGridViewTextBoxColumn Status;
        private Label label7;
        private Label label8;
        private Label label11;
    }
}
