namespace AceCareClinicSystem.Forms
{
    partial class FormUserAddEdit
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            txtFullName = new TextBox();
            txtEmail = new TextBox();
            cmbRole = new ComboBox();
            cmbStatus = new ComboBox();
            btnSave = new Button();
            btnCancel = new Button();
            lblTitle = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            cbshowpass = new CheckBox();
            SuspendLayout();
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(25, 90);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(330, 27);
            txtUsername.TabIndex = 2;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(25, 150);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(264, 27);
            txtPassword.TabIndex = 4;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(25, 210);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(330, 27);
            txtFullName.TabIndex = 6;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(25, 270);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(330, 27);
            txtEmail.TabIndex = 8;
            // 
            // cmbRole
            // 
            cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRole.Location = new Point(25, 330);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(330, 28);
            cmbRole.TabIndex = 10;
            // 
            // cmbStatus
            // 
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.Items.AddRange(new object[] { "Active", "Inactive" });
            cmbStatus.Location = new Point(25, 390);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(330, 28);
            cmbStatus.TabIndex = 12;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.DarkBlue;
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(150, 440);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 40);
            btnSave.TabIndex = 13;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(255, 440);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 40);
            btnCancel.TabIndex = 14;
            btnCancel.Text = "Cancel";
            btnCancel.Click += btnCancel_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.Location = new Point(20, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(200, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Add New User";
            // 
            // label2
            // 
            label2.Location = new Point(25, 70);
            label2.Name = "label2";
            label2.Size = new Size(100, 23);
            label2.TabIndex = 1;
            label2.Text = "Username:";
            // 
            // label3
            // 
            label3.Location = new Point(25, 130);
            label3.Name = "label3";
            label3.Size = new Size(100, 23);
            label3.TabIndex = 3;
            label3.Text = "Password:";
            // 
            // label4
            // 
            label4.Location = new Point(25, 190);
            label4.Name = "label4";
            label4.Size = new Size(100, 23);
            label4.TabIndex = 5;
            label4.Text = "Full Name:";
            // 
            // label5
            // 
            label5.Location = new Point(25, 250);
            label5.Name = "label5";
            label5.Size = new Size(100, 23);
            label5.TabIndex = 7;
            label5.Text = "Email:";
            // 
            // label6
            // 
            label6.Location = new Point(25, 310);
            label6.Name = "label6";
            label6.Size = new Size(100, 23);
            label6.TabIndex = 9;
            label6.Text = "Role:";
            // 
            // label7
            // 
            label7.Location = new Point(25, 370);
            label7.Name = "label7";
            label7.Size = new Size(100, 23);
            label7.TabIndex = 11;
            label7.Text = "Status:";
            // 
            // cbshowpass
            // 
            cbshowpass.AutoSize = true;
            cbshowpass.Location = new Point(295, 153);
            cbshowpass.Name = "cbshowpass";
            cbshowpass.Size = new Size(67, 24);
            cbshowpass.TabIndex = 15;
            cbshowpass.Text = "Show";
            cbshowpass.UseVisualStyleBackColor = true;
            cbshowpass.CheckedChanged += cbshowpass_CheckedChanged;
            // 
            // FormUserAddEdit
            // 
            ClientSize = new Size(380, 500);
            Controls.Add(cbshowpass);
            Controls.Add(lblTitle);
            Controls.Add(label2);
            Controls.Add(txtUsername);
            Controls.Add(label3);
            Controls.Add(txtPassword);
            Controls.Add(label4);
            Controls.Add(txtFullName);
            Controls.Add(label5);
            Controls.Add(txtEmail);
            Controls.Add(label6);
            Controls.Add(cmbRole);
            Controls.Add(label7);
            Controls.Add(cmbStatus);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormUserAddEdit";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "User Details";
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.ComboBox cmbRole;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private CheckBox cbshowpass;
    }
}
