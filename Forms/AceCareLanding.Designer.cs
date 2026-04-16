namespace AceCareClinicSystem.Forms
{
    partial class AceCareLanding
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AceCareLanding));
            mainPanel = new Panel();
            ImageSlider = new Panel();
            NavLeft = new ReaLTaiizor.Controls.HopeRoundButton();
            NavRight = new ReaLTaiizor.Controls.HopeRoundButton();
            CardsPanel = new Panel();
            panel4 = new Panel();
            label5 = new Label();
            pictureBox5 = new PictureBox();
            label12 = new Label();
            panel3 = new Panel();
            label11 = new Label();
            label4 = new Label();
            pictureBox3 = new PictureBox();
            panel2 = new Panel();
            label9 = new Label();
            label3 = new Label();
            pictureBox1 = new PictureBox();
            FooterPanel = new Panel();
            label10 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            NavagationBarPanel = new Panel();
            pictureBox4 = new PictureBox();
            LandingLoginBtn = new ReaLTaiizor.Controls.HopeRoundButton();
            lblGoal = new Label();
            lblFeatures = new Label();
            pictureBox2 = new PictureBox();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            mainPanel.SuspendLayout();
            ImageSlider.SuspendLayout();
            CardsPanel.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            FooterPanel.SuspendLayout();
            NavagationBarPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // mainPanel
            // 
            mainPanel.BackColor = Color.White;
            mainPanel.Controls.Add(ImageSlider);
            mainPanel.Controls.Add(CardsPanel);
            mainPanel.Controls.Add(FooterPanel);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 0);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(1212, 1074);
            mainPanel.TabIndex = 0;
            // 
            // ImageSlider
            // 
            ImageSlider.BackgroundImage = (Image)resources.GetObject("ImageSlider.BackgroundImage");
            ImageSlider.BackgroundImageLayout = ImageLayout.Zoom;
            ImageSlider.Controls.Add(NavLeft);
            ImageSlider.Controls.Add(NavRight);
            ImageSlider.Location = new Point(7, 93);
            ImageSlider.Name = "ImageSlider";
            ImageSlider.Size = new Size(1187, 453);
            ImageSlider.TabIndex = 19;
            // 
            // NavLeft
            // 
            NavLeft.BorderColor = Color.FromArgb(220, 223, 230);
            NavLeft.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            NavLeft.DangerColor = Color.FromArgb(245, 108, 108);
            NavLeft.DefaultColor = Color.FromArgb(255, 255, 255);
            NavLeft.Font = new Font("Segoe UI", 12F);
            NavLeft.HoverTextColor = Color.FromArgb(48, 49, 51);
            NavLeft.InfoColor = Color.FromArgb(144, 147, 153);
            NavLeft.Location = new Point(57, 200);
            NavLeft.Name = "NavLeft";
            NavLeft.PrimaryColor = Color.LightSkyBlue;
            NavLeft.Size = new Size(67, 50);
            NavLeft.SuccessColor = Color.FromArgb(103, 194, 58);
            NavLeft.TabIndex = 4;
            NavLeft.Text = "<";
            NavLeft.TextColor = Color.White;
            NavLeft.WarningColor = Color.FromArgb(230, 162, 60);
            NavLeft.Click += NavLeft_Click;
            // 
            // NavRight
            // 
            NavRight.BackColor = Color.LightSkyBlue;
            NavRight.BorderColor = Color.FromArgb(220, 223, 230);
            NavRight.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            NavRight.DangerColor = Color.FromArgb(245, 108, 108);
            NavRight.DefaultColor = Color.FromArgb(255, 255, 255);
            NavRight.Font = new Font("Segoe UI", 12F);
            NavRight.HoverTextColor = Color.FromArgb(48, 49, 51);
            NavRight.InfoColor = Color.FromArgb(144, 147, 153);
            NavRight.Location = new Point(1061, 200);
            NavRight.Name = "NavRight";
            NavRight.PrimaryColor = Color.LightSkyBlue;
            NavRight.Size = new Size(65, 50);
            NavRight.SuccessColor = Color.FromArgb(103, 194, 58);
            NavRight.TabIndex = 3;
            NavRight.Text = ">";
            NavRight.TextColor = Color.White;
            NavRight.WarningColor = Color.FromArgb(230, 162, 60);
            NavRight.Click += NavRight_Click;
            // 
            // CardsPanel
            // 
            CardsPanel.Controls.Add(panel4);
            CardsPanel.Controls.Add(panel3);
            CardsPanel.Controls.Add(panel2);
            CardsPanel.Location = new Point(0, 547);
            CardsPanel.Name = "CardsPanel";
            CardsPanel.Size = new Size(1208, 298);
            CardsPanel.TabIndex = 18;
            // 
            // panel4
            // 
            panel4.BackgroundImage = Properties.Resources._21;
            panel4.BackgroundImageLayout = ImageLayout.Stretch;
            panel4.Controls.Add(label5);
            panel4.Controls.Add(pictureBox5);
            panel4.Controls.Add(label12);
            panel4.Location = new Point(806, 11);
            panel4.Name = "panel4";
            panel4.Size = new Size(361, 280);
            panel4.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(75, 152);
            label5.Name = "label5";
            label5.Size = new Size(211, 18);
            label5.TabIndex = 10;
            label5.Text = "Real-Time Inventory Control";
            // 
            // pictureBox5
            // 
            pictureBox5.BackColor = Color.Transparent;
            pictureBox5.BackgroundImage = Properties.Resources.inventorycotrol_removebg_preview;
            pictureBox5.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox5.Location = new Point(40, 31);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(276, 119);
            pictureBox5.TabIndex = 0;
            pictureBox5.TabStop = false;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.BackColor = Color.Transparent;
            label12.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.Location = new Point(34, 178);
            label12.Name = "label12";
            label12.Size = new Size(294, 51);
            label12.TabIndex = 9;
            label12.Text = "Automated tracking for medicines and medical \r\nsupplies with real-time stock alerts to ensure the \r\nclinic is always fully equipped.";
            label12.TextAlign = ContentAlignment.TopCenter;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Transparent;
            panel3.BackgroundImage = Properties.Resources._21;
            panel3.BackgroundImageLayout = ImageLayout.Stretch;
            panel3.Controls.Add(label11);
            panel3.Controls.Add(label4);
            panel3.Controls.Add(pictureBox3);
            panel3.Location = new Point(433, 10);
            panel3.Name = "panel3";
            panel3.Size = new Size(379, 280);
            panel3.TabIndex = 9;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.ForeColor = Color.Black;
            label11.Location = new Point(90, 156);
            label11.Name = "label11";
            label11.Size = new Size(185, 18);
            label11.TabIndex = 8;
            label11.Text = "Smart Patient Monitoring";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(22, 183);
            label4.Name = "label4";
            label4.Size = new Size(333, 51);
            label4.TabIndex = 1;
            label4.Text = "Streamlined triage and recovery tracking, allowing staff \r\nto manage consultations and bed occupancy \r\nwith a single digital dashboard.";
            label4.TextAlign = ContentAlignment.TopCenter;
            // 
            // pictureBox3
            // 
            pictureBox3.BackgroundImage = Properties.Resources.patient_monitoring_removebg_preview;
            pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox3.Location = new Point(24, 27);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(321, 131);
            pictureBox3.TabIndex = 0;
            pictureBox3.TabStop = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Transparent;
            panel2.BackgroundImage = Properties.Resources._21;
            panel2.BackgroundImageLayout = ImageLayout.Stretch;
            panel2.Controls.Add(label9);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(pictureBox1);
            panel2.Location = new Point(54, 11);
            panel2.Name = "panel2";
            panel2.Size = new Size(383, 280);
            panel2.TabIndex = 8;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.Black;
            label9.Location = new Point(98, 150);
            label9.Name = "label9";
            label9.Size = new Size(177, 18);
            label9.TabIndex = 7;
            label9.Text = "Centralized Health Hub";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(33, 180);
            label3.Name = "label3";
            label3.Size = new Size(310, 51);
            label3.TabIndex = 2;
            label3.Text = "Consolidated digital records for students and staff, \r\nproviding instant access to medical histories and\r\n patient data in one secure location.";
            label3.TextAlign = ContentAlignment.TopCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.centralizedhub_removebg_preview;
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new Point(17, 25);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(333, 128);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // FooterPanel
            // 
            FooterPanel.BackColor = Color.FromArgb(11, 45, 114);
            FooterPanel.Controls.Add(label10);
            FooterPanel.Controls.Add(label8);
            FooterPanel.Controls.Add(label7);
            FooterPanel.Controls.Add(label6);
            FooterPanel.Location = new Point(0, 849);
            FooterPanel.Name = "FooterPanel";
            FooterPanel.Size = new Size(1208, 221);
            FooterPanel.TabIndex = 17;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.ForeColor = Color.White;
            label10.Location = new Point(862, 36);
            label10.Name = "label10";
            label10.Size = new Size(82, 22);
            label10.TabIndex = 6;
            label10.Text = "MISSION";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.White;
            label8.Location = new Point(318, 34);
            label8.Name = "label8";
            label8.Size = new Size(69, 22);
            label8.TabIndex = 4;
            label8.Text = "VISION";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.White;
            label7.Location = new Point(657, 74);
            label7.Name = "label7";
            label7.Size = new Size(476, 85);
            label7.TabIndex = 3;
            label7.Text = resources.GetString("label7.Text");
            label7.TextAlign = ContentAlignment.TopCenter;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.White;
            label6.Location = new Point(134, 69);
            label6.Name = "label6";
            label6.Size = new Size(427, 102);
            label6.TabIndex = 2;
            label6.Text = resources.GetString("label6.Text");
            label6.TextAlign = ContentAlignment.TopCenter;
            // 
            // NavagationBarPanel
            // 
            NavagationBarPanel.BackColor = Color.FromArgb(240, 244, 248);
            NavagationBarPanel.Controls.Add(pictureBox4);
            NavagationBarPanel.Controls.Add(LandingLoginBtn);
            NavagationBarPanel.Controls.Add(lblGoal);
            NavagationBarPanel.Controls.Add(lblFeatures);
            NavagationBarPanel.Controls.Add(pictureBox2);
            NavagationBarPanel.Dock = DockStyle.Top;
            NavagationBarPanel.Location = new Point(0, 0);
            NavagationBarPanel.Name = "NavagationBarPanel";
            NavagationBarPanel.Size = new Size(1212, 87);
            NavagationBarPanel.TabIndex = 9;
            // 
            // pictureBox4
            // 
            pictureBox4.BackgroundImage = (Image)resources.GetObject("pictureBox4.BackgroundImage");
            pictureBox4.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox4.Location = new Point(3, 1);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(83, 96);
            pictureBox4.TabIndex = 3;
            pictureBox4.TabStop = false;
            // 
            // LandingLoginBtn
            // 
            LandingLoginBtn.BorderColor = Color.FromArgb(220, 223, 230);
            LandingLoginBtn.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            LandingLoginBtn.DangerColor = Color.FromArgb(245, 108, 108);
            LandingLoginBtn.DefaultColor = Color.FromArgb(255, 255, 255);
            LandingLoginBtn.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LandingLoginBtn.HoverTextColor = Color.FromArgb(48, 49, 51);
            LandingLoginBtn.InfoColor = Color.FromArgb(144, 147, 153);
            LandingLoginBtn.Location = new Point(1067, 20);
            LandingLoginBtn.Name = "LandingLoginBtn";
            LandingLoginBtn.PrimaryColor = Color.FromArgb(64, 158, 255);
            LandingLoginBtn.Size = new Size(127, 50);
            LandingLoginBtn.SuccessColor = Color.FromArgb(103, 194, 58);
            LandingLoginBtn.TabIndex = 1;
            LandingLoginBtn.Text = "Login";
            LandingLoginBtn.TextColor = Color.White;
            LandingLoginBtn.WarningColor = Color.FromArgb(230, 162, 60);
            LandingLoginBtn.Click += LandingLoginBtn_Click;
            // 
            // lblGoal
            // 
            lblGoal.AutoSize = true;
            lblGoal.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblGoal.Location = new Point(960, 33);
            lblGoal.Name = "lblGoal";
            lblGoal.Size = new Size(86, 21);
            lblGoal.TabIndex = 5;
            lblGoal.Text = "Our Goal";
            lblGoal.Click += lblGoal_Click;
            // 
            // lblFeatures
            // 
            lblFeatures.AutoSize = true;
            lblFeatures.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFeatures.Location = new Point(868, 33);
            lblFeatures.Name = "lblFeatures";
            lblFeatures.Size = new Size(81, 21);
            lblFeatures.TabIndex = 1;
            lblFeatures.Text = "Features";
            lblFeatures.Click += lblFeatures_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImage = (Image)resources.GetObject("pictureBox2.BackgroundImage");
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox2.Location = new Point(64, -3);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(181, 105);
            pictureBox2.TabIndex = 4;
            pictureBox2.TabStop = false;
            // 
            // AceCareLanding
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1212, 1074);
            Controls.Add(NavagationBarPanel);
            Controls.Add(mainPanel);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AceCareLanding";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AceCareLanding";
            mainPanel.ResumeLayout(false);
            ImageSlider.ResumeLayout(false);
            CardsPanel.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            FooterPanel.ResumeLayout(false);
            FooterPanel.PerformLayout();
            NavagationBarPanel.ResumeLayout(false);
            NavagationBarPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel mainPanel;
        private Panel FooterPanel;
        private Label label10;
        private Label label8;
        private Label label7;
        private Label label6;
        private Panel NavagationBarPanel;
        private ReaLTaiizor.Controls.HopeRoundButton LandingLoginBtn;
        private Label lblGoal;
        private Label lblFeatures;
        private PictureBox pictureBox2;
        private PictureBox pictureBox4;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Panel CardsPanel;
        private Panel panel4;
        private Label label5;
        private PictureBox pictureBox5;
        private Label label12;
        private Panel panel3;
        private Label label11;
        private Label label4;
        private PictureBox pictureBox3;
        private Panel panel2;
        private Label label9;
        private Label label3;
        private PictureBox pictureBox1;
        private Panel ImageSlider;
        private ReaLTaiizor.Controls.HopeRoundButton NavRight;
        private ReaLTaiizor.Controls.HopeRoundButton NavLeft;
    }
}