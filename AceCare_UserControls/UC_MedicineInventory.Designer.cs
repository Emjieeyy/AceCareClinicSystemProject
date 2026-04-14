namespace AceCareClinicSystem.AceCare_UserControls
{
    partial class UC_MedicineInventory
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
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            panel1 = new Panel();
            label9 = new Label();
            panel6 = new Panel();
            lblCountExpiring = new Label();
            pictureBox4 = new PictureBox();
            label8 = new Label();
            panel5 = new Panel();
            lblCountLowStock = new Label();
            pictureBox3 = new PictureBox();
            label6 = new Label();
            panel3 = new Panel();
            lblCountTotalSupplies = new Label();
            pictureBox2 = new PictureBox();
            label4 = new Label();
            panel4 = new Panel();
            lblCountTotalMedicine = new Label();
            pictureBox1 = new PictureBox();
            label2 = new Label();
            pictureBox5 = new PictureBox();
            panel2 = new Panel();
            label11 = new Label();
            pictureBox9 = new PictureBox();
            pictureBox8 = new PictureBox();
            pictureBox7 = new PictureBox();
            pictureBox6 = new PictureBox();
            label10 = new Label();
            txtSearchInventory = new ReaLTaiizor.Controls.PoisonTextBox();
            btnSearch = new ReaLTaiizor.Controls.HopeRoundButton();
            btnAddMedicine = new ReaLTaiizor.Controls.HopeRoundButton();
            btnAddSupply = new ReaLTaiizor.Controls.HopeRoundButton();
            btnEditItem = new ReaLTaiizor.Controls.HopeRoundButton();
            btnDeleteItem = new ReaLTaiizor.Controls.HopeRoundButton();
            tabControl1 = new TabControl();
            MedicineRecords = new TabPage();
            dgvMedicineRecords = new ReaLTaiizor.Controls.PoisonDataGridView();
            MedicineName = new DataGridViewTextBoxColumn();
            InStock = new DataGridViewTextBoxColumn();
            UsedWk = new DataGridViewTextBoxColumn();
            Expiry = new DataGridViewTextBoxColumn();
            tabPage2 = new TabPage();
            dgvSuppliesRecords = new ReaLTaiizor.Controls.PoisonDataGridView();
            colSupName = new DataGridViewTextBoxColumn();
            colSupQty = new DataGridViewTextBoxColumn();
            colSupUsage = new DataGridViewTextBoxColumn();
            colSupExpiry = new DataGridViewTextBoxColumn();
            panel1.SuspendLayout();
            panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            tabControl1.SuspendLayout();
            MedicineRecords.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMedicineRecords).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSuppliesRecords).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label9);
            panel1.Controls.Add(panel6);
            panel1.Controls.Add(panel5);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(pictureBox5);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(916, 186);
            panel1.TabIndex = 0;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.White;
            label9.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.Black;
            label9.Location = new Point(15, 26);
            label9.Name = "label9";
            label9.Size = new Size(191, 29);
            label9.TabIndex = 12;
            label9.Text = "Clinic Inventory";
            // 
            // panel6
            // 
            panel6.BackgroundImage = Properties.Resources._21;
            panel6.BackgroundImageLayout = ImageLayout.Stretch;
            panel6.Controls.Add(lblCountExpiring);
            panel6.Controls.Add(pictureBox4);
            panel6.Controls.Add(label8);
            panel6.Location = new Point(674, 66);
            panel6.Margin = new Padding(3, 2, 3, 2);
            panel6.Name = "panel6";
            panel6.Size = new Size(214, 102);
            panel6.TabIndex = 11;
            // 
            // lblCountExpiring
            // 
            lblCountExpiring.AutoSize = true;
            lblCountExpiring.BackColor = Color.FromArgb(235, 239, 244);
            lblCountExpiring.Font = new Font("Microsoft Sans Serif", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCountExpiring.Location = new Point(119, 50);
            lblCountExpiring.Name = "lblCountExpiring";
            lblCountExpiring.Size = new Size(33, 36);
            lblCountExpiring.TabIndex = 7;
            lblCountExpiring.Text = "0";
            // 
            // pictureBox4
            // 
            pictureBox4.BackColor = Color.FromArgb(235, 239, 244);
            pictureBox4.BackgroundImage = Properties.Resources.calendar;
            pictureBox4.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox4.Location = new Point(26, 34);
            pictureBox4.Margin = new Padding(3, 2, 3, 2);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(49, 46);
            pictureBox4.TabIndex = 5;
            pictureBox4.TabStop = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.FromArgb(235, 239, 244);
            label8.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(78, 31);
            label8.Name = "label8";
            label8.Size = new Size(113, 18);
            label8.TabIndex = 6;
            label8.Text = "Expiring Soon";
            // 
            // panel5
            // 
            panel5.BackgroundImage = Properties.Resources._21;
            panel5.BackgroundImageLayout = ImageLayout.Stretch;
            panel5.Controls.Add(lblCountLowStock);
            panel5.Controls.Add(pictureBox3);
            panel5.Controls.Add(label6);
            panel5.Location = new Point(455, 66);
            panel5.Margin = new Padding(3, 2, 3, 2);
            panel5.Name = "panel5";
            panel5.Size = new Size(214, 102);
            panel5.TabIndex = 10;
            // 
            // lblCountLowStock
            // 
            lblCountLowStock.AutoSize = true;
            lblCountLowStock.BackColor = Color.FromArgb(235, 239, 244);
            lblCountLowStock.Font = new Font("Microsoft Sans Serif", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCountLowStock.Location = new Point(119, 50);
            lblCountLowStock.Name = "lblCountLowStock";
            lblCountLowStock.Size = new Size(33, 36);
            lblCountLowStock.TabIndex = 7;
            lblCountLowStock.Text = "0";
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.FromArgb(235, 239, 244);
            pictureBox3.BackgroundImage = Properties.Resources.warning__1_;
            pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox3.Location = new Point(26, 34);
            pictureBox3.Margin = new Padding(3, 2, 3, 2);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(49, 46);
            pictureBox3.TabIndex = 5;
            pictureBox3.TabStop = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.FromArgb(235, 239, 244);
            label6.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(78, 31);
            label6.Name = "label6";
            label6.Size = new Size(112, 18);
            label6.TabIndex = 6;
            label6.Text = "Low Inventory";
            // 
            // panel3
            // 
            panel3.BackgroundImage = Properties.Resources._21;
            panel3.BackgroundImageLayout = ImageLayout.Stretch;
            panel3.Controls.Add(lblCountTotalSupplies);
            panel3.Controls.Add(pictureBox2);
            panel3.Controls.Add(label4);
            panel3.Location = new Point(236, 68);
            panel3.Margin = new Padding(3, 2, 3, 2);
            panel3.Name = "panel3";
            panel3.Size = new Size(214, 102);
            panel3.TabIndex = 9;
            // 
            // lblCountTotalSupplies
            // 
            lblCountTotalSupplies.AutoSize = true;
            lblCountTotalSupplies.BackColor = Color.FromArgb(235, 239, 244);
            lblCountTotalSupplies.Font = new Font("Microsoft Sans Serif", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCountTotalSupplies.Location = new Point(119, 50);
            lblCountTotalSupplies.Name = "lblCountTotalSupplies";
            lblCountTotalSupplies.Size = new Size(33, 36);
            lblCountTotalSupplies.TabIndex = 7;
            lblCountTotalSupplies.Text = "0";
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.FromArgb(235, 239, 244);
            pictureBox2.BackgroundImage = Properties.Resources.medical_supplies;
            pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox2.Location = new Point(26, 34);
            pictureBox2.Margin = new Padding(3, 2, 3, 2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(49, 46);
            pictureBox2.TabIndex = 5;
            pictureBox2.TabStop = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.FromArgb(235, 239, 244);
            label4.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(78, 31);
            label4.Name = "label4";
            label4.Size = new Size(115, 18);
            label4.TabIndex = 6;
            label4.Text = "Total Supplies";
            // 
            // panel4
            // 
            panel4.BackgroundImage = Properties.Resources._21;
            panel4.BackgroundImageLayout = ImageLayout.Stretch;
            panel4.Controls.Add(lblCountTotalMedicine);
            panel4.Controls.Add(pictureBox1);
            panel4.Controls.Add(label2);
            panel4.Location = new Point(16, 68);
            panel4.Margin = new Padding(3, 2, 3, 2);
            panel4.Name = "panel4";
            panel4.Size = new Size(214, 102);
            panel4.TabIndex = 8;
            // 
            // lblCountTotalMedicine
            // 
            lblCountTotalMedicine.AutoSize = true;
            lblCountTotalMedicine.BackColor = Color.FromArgb(235, 239, 244);
            lblCountTotalMedicine.Font = new Font("Microsoft Sans Serif", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCountTotalMedicine.Location = new Point(119, 50);
            lblCountTotalMedicine.Name = "lblCountTotalMedicine";
            lblCountTotalMedicine.Size = new Size(33, 36);
            lblCountTotalMedicine.TabIndex = 7;
            lblCountTotalMedicine.Text = "0";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(235, 239, 244);
            pictureBox1.BackgroundImage = Properties.Resources.prepared;
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new Point(26, 34);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(49, 46);
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(235, 239, 244);
            label2.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(78, 31);
            label2.Name = "label2";
            label2.Size = new Size(118, 18);
            label2.TabIndex = 6;
            label2.Text = "Total Medicine";
            // 
            // pictureBox5
            // 
            pictureBox5.BackColor = Color.White;
            pictureBox5.BackgroundImage = Properties.Resources._646378810_910016875123051_9142573013095368996_n__1__removebg_preview1;
            pictureBox5.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox5.Location = new Point(820, -7);
            pictureBox5.Margin = new Padding(3, 2, 3, 2);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(94, 82);
            pictureBox5.TabIndex = 8;
            pictureBox5.TabStop = false;
            // 
            // panel2
            // 
            panel2.Controls.Add(label11);
            panel2.Controls.Add(pictureBox9);
            panel2.Controls.Add(pictureBox8);
            panel2.Controls.Add(pictureBox7);
            panel2.Controls.Add(pictureBox6);
            panel2.Controls.Add(label10);
            panel2.Controls.Add(txtSearchInventory);
            panel2.Controls.Add(btnSearch);
            panel2.Controls.Add(btnAddMedicine);
            panel2.Controls.Add(btnAddSupply);
            panel2.Controls.Add(btnEditItem);
            panel2.Controls.Add(btnDeleteItem);
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(586, 186);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(330, 408);
            panel2.TabIndex = 1;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label11.Location = new Point(28, 49);
            label11.Name = "label11";
            label11.Size = new Size(206, 26);
            label11.TabIndex = 44;
            label11.Text = "Manage medicines, medical supplies, and \r\nother clinic inventory items";
            // 
            // pictureBox9
            // 
            pictureBox9.BackColor = Color.DarkBlue;
            pictureBox9.BackgroundImage = Properties.Resources.folder;
            pictureBox9.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox9.Location = new Point(88, 343);
            pictureBox9.Margin = new Padding(3, 2, 3, 2);
            pictureBox9.Name = "pictureBox9";
            pictureBox9.Size = new Size(39, 28);
            pictureBox9.TabIndex = 39;
            pictureBox9.TabStop = false;
            // 
            // pictureBox8
            // 
            pictureBox8.BackColor = Color.DarkBlue;
            pictureBox8.BackgroundImage = Properties.Resources.edit;
            pictureBox8.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox8.Location = new Point(87, 280);
            pictureBox8.Margin = new Padding(3, 2, 3, 2);
            pictureBox8.Name = "pictureBox8";
            pictureBox8.Size = new Size(39, 28);
            pictureBox8.TabIndex = 38;
            pictureBox8.TabStop = false;
            // 
            // pictureBox7
            // 
            pictureBox7.BackColor = Color.DarkBlue;
            pictureBox7.BackgroundImage = Properties.Resources.add_product;
            pictureBox7.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox7.Location = new Point(86, 215);
            pictureBox7.Margin = new Padding(3, 2, 3, 2);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(39, 28);
            pictureBox7.TabIndex = 37;
            pictureBox7.TabStop = false;
            // 
            // pictureBox6
            // 
            pictureBox6.BackColor = Color.DarkBlue;
            pictureBox6.BackgroundImage = Properties.Resources.add;
            pictureBox6.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox6.Location = new Point(82, 152);
            pictureBox6.Margin = new Padding(3, 2, 3, 2);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(39, 28);
            pictureBox6.TabIndex = 8;
            pictureBox6.TabStop = false;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.White;
            label10.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.ForeColor = Color.Black;
            label10.Location = new Point(20, 16);
            label10.Name = "label10";
            label10.Size = new Size(249, 29);
            label10.TabIndex = 13;
            label10.Text = "Manage Clinic Items";
            // 
            // txtSearchInventory
            // 
            txtSearchInventory.BackColor = Color.FromArgb(235, 239, 244);
            // 
            // 
            // 
            txtSearchInventory.CustomButton.Image = null;
            txtSearchInventory.CustomButton.Location = new Point(175, 1);
            txtSearchInventory.CustomButton.Margin = new Padding(3, 2, 3, 2);
            txtSearchInventory.CustomButton.Name = "";
            txtSearchInventory.CustomButton.Size = new Size(27, 27);
            txtSearchInventory.CustomButton.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Blue;
            txtSearchInventory.CustomButton.TabIndex = 1;
            txtSearchInventory.CustomButton.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
            txtSearchInventory.CustomButton.UseSelectable = true;
            txtSearchInventory.CustomButton.Visible = false;
            txtSearchInventory.Location = new Point(25, 92);
            txtSearchInventory.Margin = new Padding(3, 2, 3, 2);
            txtSearchInventory.MaxLength = 32767;
            txtSearchInventory.Name = "txtSearchInventory";
            txtSearchInventory.PasswordChar = '\0';
            txtSearchInventory.ScrollBars = ScrollBars.None;
            txtSearchInventory.SelectedText = "";
            txtSearchInventory.SelectionLength = 0;
            txtSearchInventory.SelectionStart = 0;
            txtSearchInventory.ShortcutsEnabled = true;
            txtSearchInventory.Size = new Size(203, 29);
            txtSearchInventory.TabIndex = 32;
            txtSearchInventory.UseSelectable = true;
            txtSearchInventory.WaterMarkColor = Color.FromArgb(109, 109, 109);
            txtSearchInventory.WaterMarkFont = new Font("Segoe UI", 12F, FontStyle.Italic, GraphicsUnit.Pixel);
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(235, 239, 244);
            btnSearch.BackgroundImageLayout = ImageLayout.Zoom;
            btnSearch.BorderColor = Color.FromArgb(235, 239, 244);
            btnSearch.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            btnSearch.DangerColor = Color.FromArgb(245, 108, 108);
            btnSearch.DefaultColor = Color.FromArgb(255, 255, 255);
            btnSearch.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSearch.HoverTextColor = Color.FromArgb(48, 49, 51);
            btnSearch.InfoColor = Color.FromArgb(144, 147, 153);
            btnSearch.Location = new Point(234, 93);
            btnSearch.Margin = new Padding(3, 2, 3, 2);
            btnSearch.Name = "btnSearch";
            btnSearch.PrimaryColor = Color.FromArgb(11, 45, 114);
            btnSearch.Size = new Size(80, 26);
            btnSearch.SuccessColor = Color.FromArgb(103, 194, 58);
            btnSearch.TabIndex = 31;
            btnSearch.Text = "Search";
            btnSearch.TextColor = Color.White;
            btnSearch.WarningColor = Color.FromArgb(230, 162, 60);
            btnSearch.Click += btnSearch_Click;
            // 
            // btnAddMedicine
            // 
            btnAddMedicine.BorderColor = Color.FromArgb(220, 223, 230);
            btnAddMedicine.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            btnAddMedicine.DangerColor = Color.FromArgb(245, 108, 108);
            btnAddMedicine.DefaultColor = Color.FromArgb(255, 255, 255);
            btnAddMedicine.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddMedicine.HoverTextColor = Color.FromArgb(48, 49, 51);
            btnAddMedicine.InfoColor = Color.FromArgb(144, 147, 153);
            btnAddMedicine.Location = new Point(27, 145);
            btnAddMedicine.Margin = new Padding(3, 2, 3, 2);
            btnAddMedicine.Name = "btnAddMedicine";
            btnAddMedicine.PrimaryColor = Color.DarkBlue;
            btnAddMedicine.Size = new Size(264, 45);
            btnAddMedicine.SuccessColor = Color.FromArgb(103, 194, 58);
            btnAddMedicine.TabIndex = 40;
            btnAddMedicine.Text = "      Add Medicine";
            btnAddMedicine.TextColor = Color.White;
            btnAddMedicine.WarningColor = Color.FromArgb(230, 162, 60);
            btnAddMedicine.Click += btnAddMedicine_Click;
            // 
            // btnAddSupply
            // 
            btnAddSupply.BorderColor = Color.FromArgb(220, 223, 230);
            btnAddSupply.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            btnAddSupply.DangerColor = Color.FromArgb(245, 108, 108);
            btnAddSupply.DefaultColor = Color.FromArgb(255, 255, 255);
            btnAddSupply.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddSupply.HoverTextColor = Color.FromArgb(48, 49, 51);
            btnAddSupply.InfoColor = Color.FromArgb(144, 147, 153);
            btnAddSupply.Location = new Point(28, 206);
            btnAddSupply.Margin = new Padding(3, 2, 3, 2);
            btnAddSupply.Name = "btnAddSupply";
            btnAddSupply.PrimaryColor = Color.DarkBlue;
            btnAddSupply.Size = new Size(262, 45);
            btnAddSupply.SuccessColor = Color.FromArgb(103, 194, 58);
            btnAddSupply.TabIndex = 41;
            btnAddSupply.Text = "    Add Supply";
            btnAddSupply.TextColor = Color.White;
            btnAddSupply.WarningColor = Color.FromArgb(230, 162, 60);
            btnAddSupply.Click += btnAddSupply_Click;
            // 
            // btnEditItem
            // 
            btnEditItem.BorderColor = Color.FromArgb(220, 223, 230);
            btnEditItem.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            btnEditItem.DangerColor = Color.FromArgb(245, 108, 108);
            btnEditItem.DefaultColor = Color.FromArgb(255, 255, 255);
            btnEditItem.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEditItem.HoverTextColor = Color.FromArgb(48, 49, 51);
            btnEditItem.InfoColor = Color.FromArgb(144, 147, 153);
            btnEditItem.Location = new Point(28, 270);
            btnEditItem.Margin = new Padding(3, 2, 3, 2);
            btnEditItem.Name = "btnEditItem";
            btnEditItem.PrimaryColor = Color.DarkBlue;
            btnEditItem.Size = new Size(262, 45);
            btnEditItem.SuccessColor = Color.FromArgb(103, 194, 58);
            btnEditItem.TabIndex = 42;
            btnEditItem.Text = " Edit";
            btnEditItem.TextColor = Color.White;
            btnEditItem.WarningColor = Color.FromArgb(230, 162, 60);
            btnEditItem.Click += btnEditItem_Click;
            // 
            // btnDeleteItem
            // 
            btnDeleteItem.BorderColor = Color.FromArgb(220, 223, 230);
            btnDeleteItem.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            btnDeleteItem.DangerColor = Color.FromArgb(245, 108, 108);
            btnDeleteItem.DefaultColor = Color.FromArgb(255, 255, 255);
            btnDeleteItem.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDeleteItem.HoverTextColor = Color.FromArgb(48, 49, 51);
            btnDeleteItem.InfoColor = Color.FromArgb(144, 147, 153);
            btnDeleteItem.Location = new Point(28, 333);
            btnDeleteItem.Margin = new Padding(3, 2, 3, 2);
            btnDeleteItem.Name = "btnDeleteItem";
            btnDeleteItem.PrimaryColor = Color.DarkBlue;
            btnDeleteItem.Size = new Size(265, 45);
            btnDeleteItem.SuccessColor = Color.FromArgb(103, 194, 58);
            btnDeleteItem.TabIndex = 43;
            btnDeleteItem.Text = " Delete";
            btnDeleteItem.TextColor = Color.White;
            btnDeleteItem.WarningColor = Color.FromArgb(230, 162, 60);
            btnDeleteItem.Click += btnDeleteItem_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(MedicineRecords);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tabControl1.Location = new Point(0, 186);
            tabControl1.Margin = new Padding(3, 2, 3, 2);
            tabControl1.Multiline = true;
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(586, 408);
            tabControl1.TabIndex = 0;
            // 
            // MedicineRecords
            // 
            MedicineRecords.Controls.Add(dgvMedicineRecords);
            MedicineRecords.Location = new Point(4, 26);
            MedicineRecords.Margin = new Padding(3, 2, 3, 2);
            MedicineRecords.Name = "MedicineRecords";
            MedicineRecords.Padding = new Padding(3, 2, 3, 2);
            MedicineRecords.Size = new Size(578, 378);
            MedicineRecords.TabIndex = 0;
            MedicineRecords.Text = "Medicine Records";
            MedicineRecords.UseVisualStyleBackColor = true;
            // 
            // dgvMedicineRecords
            // 
            dgvMedicineRecords.AllowUserToAddRows = false;
            dgvMedicineRecords.AllowUserToResizeRows = false;
            dgvMedicineRecords.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMedicineRecords.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvMedicineRecords.BackgroundColor = Color.FromArgb(255, 255, 255);
            dgvMedicineRecords.BorderStyle = BorderStyle.None;
            dgvMedicineRecords.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvMedicineRecords.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(0, 174, 219);
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(255, 255, 255);
            dataGridViewCellStyle1.Padding = new Padding(7);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(0, 198, 247);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(17, 17, 17);
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvMedicineRecords.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvMedicineRecords.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMedicineRecords.Columns.AddRange(new DataGridViewColumn[] { MedicineName, InStock, UsedWk, Expiry });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(255, 255, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(136, 136, 136);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(0, 198, 247);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(17, 17, 17);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvMedicineRecords.DefaultCellStyle = dataGridViewCellStyle2;
            dgvMedicineRecords.Dock = DockStyle.Fill;
            dgvMedicineRecords.EditMode = DataGridViewEditMode.EditOnEnter;
            dgvMedicineRecords.EnableHeadersVisualStyles = false;
            dgvMedicineRecords.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
            dgvMedicineRecords.GridColor = Color.FromArgb(255, 255, 255);
            dgvMedicineRecords.Location = new Point(3, 2);
            dgvMedicineRecords.Margin = new Padding(3, 2, 3, 2);
            dgvMedicineRecords.Name = "dgvMedicineRecords";
            dgvMedicineRecords.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(0, 174, 219);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(255, 255, 255);
            dataGridViewCellStyle3.Padding = new Padding(7);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(0, 198, 247);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(17, 17, 17);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvMedicineRecords.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvMedicineRecords.RowHeadersWidth = 51;
            dgvMedicineRecords.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.Padding = new Padding(7);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(255, 255, 192);
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvMedicineRecords.RowsDefaultCellStyle = dataGridViewCellStyle4;
            dgvMedicineRecords.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMedicineRecords.Size = new Size(572, 374);
            dgvMedicineRecords.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Blue;
            dgvMedicineRecords.TabIndex = 0;
            // 
            // MedicineName
            // 
            MedicineName.DataPropertyName = "Name";
            MedicineName.HeaderText = "Medicine Name";
            MedicineName.MinimumWidth = 6;
            MedicineName.Name = "MedicineName";
            // 
            // InStock
            // 
            InStock.DataPropertyName = "Quantity";
            InStock.HeaderText = "In Stock";
            InStock.MinimumWidth = 6;
            InStock.Name = "InStock";
            // 
            // UsedWk
            // 
            UsedWk.DataPropertyName = "WeeklyUsage";
            UsedWk.HeaderText = "Used (Wk)";
            UsedWk.MinimumWidth = 6;
            UsedWk.Name = "UsedWk";
            // 
            // Expiry
            // 
            Expiry.DataPropertyName = "ExpiryDate";
            Expiry.HeaderText = "Expiry";
            Expiry.MinimumWidth = 6;
            Expiry.Name = "Expiry";
            // 
            // tabPage2
            // 
            tabPage2.BackColor = Color.White;
            tabPage2.Controls.Add(dgvSuppliesRecords);
            tabPage2.Location = new Point(4, 26);
            tabPage2.Margin = new Padding(3, 2, 3, 2);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3, 2, 3, 2);
            tabPage2.Size = new Size(578, 378);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Supplies Records";
            // 
            // dgvSuppliesRecords
            // 
            dgvSuppliesRecords.AllowUserToAddRows = false;
            dgvSuppliesRecords.AllowUserToResizeRows = false;
            dgvSuppliesRecords.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSuppliesRecords.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvSuppliesRecords.BackgroundColor = Color.FromArgb(255, 255, 255);
            dgvSuppliesRecords.BorderStyle = BorderStyle.None;
            dgvSuppliesRecords.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvSuppliesRecords.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(0, 174, 219);
            dataGridViewCellStyle5.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle5.ForeColor = Color.FromArgb(255, 255, 255);
            dataGridViewCellStyle5.Padding = new Padding(7);
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(0, 198, 247);
            dataGridViewCellStyle5.SelectionForeColor = Color.FromArgb(17, 17, 17);
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgvSuppliesRecords.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgvSuppliesRecords.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSuppliesRecords.Columns.AddRange(new DataGridViewColumn[] { colSupName, colSupQty, colSupUsage, colSupExpiry });
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = Color.FromArgb(255, 255, 255);
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
            dataGridViewCellStyle6.ForeColor = Color.FromArgb(136, 136, 136);
            dataGridViewCellStyle6.Padding = new Padding(7);
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(0, 198, 247);
            dataGridViewCellStyle6.SelectionForeColor = Color.FromArgb(17, 17, 17);
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            dgvSuppliesRecords.DefaultCellStyle = dataGridViewCellStyle6;
            dgvSuppliesRecords.Dock = DockStyle.Fill;
            dgvSuppliesRecords.EnableHeadersVisualStyles = false;
            dgvSuppliesRecords.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
            dgvSuppliesRecords.GridColor = Color.FromArgb(255, 255, 255);
            dgvSuppliesRecords.Location = new Point(3, 2);
            dgvSuppliesRecords.Margin = new Padding(3, 2, 3, 2);
            dgvSuppliesRecords.Name = "dgvSuppliesRecords";
            dgvSuppliesRecords.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = Color.FromArgb(0, 174, 219);
            dataGridViewCellStyle7.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
            dataGridViewCellStyle7.ForeColor = Color.FromArgb(255, 255, 255);
            dataGridViewCellStyle7.Padding = new Padding(7);
            dataGridViewCellStyle7.SelectionBackColor = Color.FromArgb(0, 198, 247);
            dataGridViewCellStyle7.SelectionForeColor = Color.FromArgb(17, 17, 17);
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
            dgvSuppliesRecords.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dgvSuppliesRecords.RowHeadersWidth = 51;
            dgvSuppliesRecords.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle8.Padding = new Padding(7);
            dataGridViewCellStyle8.SelectionBackColor = Color.FromArgb(255, 255, 192);
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.True;
            dgvSuppliesRecords.RowsDefaultCellStyle = dataGridViewCellStyle8;
            dgvSuppliesRecords.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSuppliesRecords.Size = new Size(572, 374);
            dgvSuppliesRecords.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Blue;
            dgvSuppliesRecords.TabIndex = 1;
            // 
            // colSupName
            // 
            colSupName.DataPropertyName = "Name";
            colSupName.HeaderText = "Item Name";
            colSupName.MinimumWidth = 6;
            colSupName.Name = "colSupName";
            // 
            // colSupQty
            // 
            colSupQty.DataPropertyName = "Quantity";
            colSupQty.HeaderText = "In Stock";
            colSupQty.MinimumWidth = 6;
            colSupQty.Name = "colSupQty";
            // 
            // colSupUsage
            // 
            colSupUsage.DataPropertyName = "WeeklyUsage";
            colSupUsage.HeaderText = "Used (Wk)";
            colSupUsage.MinimumWidth = 6;
            colSupUsage.Name = "colSupUsage";
            // 
            // colSupExpiry
            // 
            colSupExpiry.DataPropertyName = "ExpiryDate";
            colSupExpiry.HeaderText = "Expiry";
            colSupExpiry.MinimumWidth = 6;
            colSupExpiry.Name = "colSupExpiry";
            // 
            // UC_MedicineInventory
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(tabControl1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "UC_MedicineInventory";
            Size = new Size(916, 594);
            Load += UC_MedicineInventory_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            tabControl1.ResumeLayout(false);
            MedicineRecords.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMedicineRecords).EndInit();
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSuppliesRecords).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private TabControl tabControl1;
        private TabPage MedicineRecords;
        private TabPage tabPage2;
        private Panel panel4;
        private Label lblCountTotalMedicine;
        private PictureBox pictureBox1;
        private Label label2;
        private Panel panel6;
        private Label lblCountExpiring;
        private PictureBox pictureBox4;
        private Label label8;
        private Panel panel5;
        private Label lblCountLowStock;
        private PictureBox pictureBox3;
        private Label label6;
        private Panel panel3;
        private Label lblCountTotalSupplies;
        private PictureBox pictureBox2;
        private Label label4;
        private Label label9;
        private ReaLTaiizor.Controls.PoisonDataGridView dgvMedicineRecords;
        private ReaLTaiizor.Controls.PoisonDataGridView dgvSuppliesRecords;
        private ReaLTaiizor.Controls.PoisonTextBox txtSearchInventory;
        private ReaLTaiizor.Controls.HopeRoundButton btnSearch;
        private PictureBox pictureBox6;
        private Label label10;
        private PictureBox pictureBox9;
        private PictureBox pictureBox8;
        private PictureBox pictureBox7;
        private ReaLTaiizor.Controls.HopeRoundButton btnAddMedicine;
        private ReaLTaiizor.Controls.HopeRoundButton btnAddSupply;
        private ReaLTaiizor.Controls.HopeRoundButton btnEditItem;
        private ReaLTaiizor.Controls.HopeRoundButton btnDeleteItem;
        private PictureBox pictureBox5;
        private Label label11;
        private DataGridViewTextBoxColumn MedicineName;
        private DataGridViewTextBoxColumn InStock;
        private DataGridViewTextBoxColumn UsedWk;
        private DataGridViewTextBoxColumn Expiry;
        private DataGridViewTextBoxColumn colSupName;
        private DataGridViewTextBoxColumn colSupQty;
        private DataGridViewTextBoxColumn colSupUsage;
        private DataGridViewTextBoxColumn colSupExpiry;
    }
}
