namespace AceCareClinicSystem.Forms
{
    partial class Login
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            txtUser = new TextBox();
            txtPass = new TextBox();
            LoginBtn = new ReaLTaiizor.Controls.HopeRoundButton();
            showPassCB = new CheckBox();
            label3 = new Label();
            label2 = new Label();
            pictureBox4 = new PictureBox();
            label1 = new Label();
            pictureBox3 = new PictureBox();
            pictureBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new Point(-2, -60);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(516, 807);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(txtUser);
            panel1.Controls.Add(txtPass);
            panel1.Controls.Add(LoginBtn);
            panel1.Controls.Add(showPassCB);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(pictureBox4);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pictureBox3);
            panel1.Controls.Add(pictureBox2);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(510, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(540, 696);
            panel1.TabIndex = 1;
            // 
            // txtUser
            // 
            txtUser.BackColor = Color.FromArgb(235, 239, 244);
            txtUser.Location = new Point(112, 292);
            txtUser.Name = "txtUser";
            txtUser.Size = new Size(342, 27);
            txtUser.TabIndex = 11;
            // 
            // txtPass
            // 
            txtPass.BackColor = Color.FromArgb(235, 239, 244);
            txtPass.Location = new Point(112, 406);
            txtPass.Name = "txtPass";
            txtPass.Size = new Size(342, 27);
            txtPass.TabIndex = 10;
            txtPass.UseSystemPasswordChar = true;
            // 
            // LoginBtn
            // 
            LoginBtn.BorderColor = Color.FromArgb(220, 223, 230);
            LoginBtn.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            LoginBtn.DangerColor = Color.FromArgb(245, 108, 108);
            LoginBtn.DefaultColor = Color.FromArgb(255, 255, 255);
            LoginBtn.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LoginBtn.HoverTextColor = Color.FromArgb(48, 49, 51);
            LoginBtn.InfoColor = Color.FromArgb(144, 147, 153);
            LoginBtn.Location = new Point(340, 523);
            LoginBtn.Name = "LoginBtn";
            LoginBtn.PrimaryColor = Color.FromArgb(11, 45, 114);
            LoginBtn.Size = new Size(144, 50);
            LoginBtn.SuccessColor = Color.FromArgb(103, 194, 58);
            LoginBtn.TabIndex = 8;
            LoginBtn.Text = "Login";
            LoginBtn.TextColor = Color.White;
            LoginBtn.WarningColor = Color.FromArgb(230, 162, 60);
            LoginBtn.Click += LoginBtn_Click;
            // 
            // showPassCB
            // 
            showPassCB.AutoSize = true;
            showPassCB.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            showPassCB.Location = new Point(93, 491);
            showPassCB.Name = "showPassCB";
            showPassCB.Size = new Size(145, 24);
            showPassCB.TabIndex = 7;
            showPassCB.Text = "Show Password";
            showPassCB.UseVisualStyleBackColor = true;
            showPassCB.CheckedChanged += showPassCB_CheckedChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(93, 360);
            label3.Name = "label3";
            label3.Size = new Size(88, 21);
            label3.TabIndex = 6;
            label3.Text = "Password";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(89, 243);
            label2.Name = "label2";
            label2.Size = new Size(93, 21);
            label2.TabIndex = 5;
            label2.Text = "Username";
            // 
            // pictureBox4
            // 
            pictureBox4.BackgroundImage = (Image)resources.GetObject("pictureBox4.BackgroundImage");
            pictureBox4.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox4.Location = new Point(76, 363);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(410, 109);
            pictureBox4.TabIndex = 4;
            pictureBox4.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(120, 163);
            label1.Name = "label1";
            label1.Size = new Size(327, 21);
            label1.TabIndex = 3;
            label1.Text = "Please Log In to access your account.";
            // 
            // pictureBox3
            // 
            pictureBox3.BackgroundImage = (Image)resources.GetObject("pictureBox3.BackgroundImage");
            pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox3.Location = new Point(217, 55);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(126, 91);
            pictureBox3.TabIndex = 2;
            pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImage = (Image)resources.GetObject("pictureBox2.BackgroundImage");
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox2.Location = new Point(76, 248);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(410, 109);
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(1050, 696);
            Controls.Add(panel1);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Panel panel1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private Label label1;
        private PictureBox pictureBox4;
        private Label label2;
        private ReaLTaiizor.Controls.HopeRoundButton LoginBtn;
        private CheckBox showPassCB;
        private Label label3;
        private TextBox txtPass;
        private TextBox txtUser;
    }
}