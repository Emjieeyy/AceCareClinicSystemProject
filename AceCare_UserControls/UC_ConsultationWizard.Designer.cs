namespace AceCareClinicSystem.AceCare_UserControls
{
    partial class UC_ConsultationWizard
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
            Stage = new Panel();
            Step1Panel = new Panel();
            Step2Panel = new Panel();
            Step3Panel = new Panel();
            Step4Panel = new Panel();
            Step5Panel = new Panel();
            panel1 = new Panel();
            materialLabel1 = new ReaLTaiizor.Controls.MaterialLabel();
            Stage.SuspendLayout();
            Step5Panel.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // Stage
            // 
            Stage.Controls.Add(Step5Panel);
            Stage.Controls.Add(Step4Panel);
            Stage.Controls.Add(Step3Panel);
            Stage.Controls.Add(Step2Panel);
            Stage.Controls.Add(Step1Panel);
            Stage.Dock = DockStyle.Fill;
            Stage.Location = new Point(0, 0);
            Stage.Name = "Stage";
            Stage.Size = new Size(1084, 739);
            Stage.TabIndex = 0;
            // 
            // Step1Panel
            // 
            Step1Panel.Dock = DockStyle.Fill;
            Step1Panel.Location = new Point(0, 0);
            Step1Panel.Name = "Step1Panel";
            Step1Panel.Size = new Size(1084, 739);
            Step1Panel.TabIndex = 0;
            // 
            // Step2Panel
            // 
            Step2Panel.Dock = DockStyle.Fill;
            Step2Panel.Location = new Point(0, 0);
            Step2Panel.Name = "Step2Panel";
            Step2Panel.Size = new Size(1084, 739);
            Step2Panel.TabIndex = 0;
            Step2Panel.Visible = false;
            // 
            // Step3Panel
            // 
            Step3Panel.Dock = DockStyle.Fill;
            Step3Panel.Location = new Point(0, 0);
            Step3Panel.Name = "Step3Panel";
            Step3Panel.Size = new Size(1084, 739);
            Step3Panel.TabIndex = 0;
            Step3Panel.Visible = false;
            // 
            // Step4Panel
            // 
            Step4Panel.Dock = DockStyle.Fill;
            Step4Panel.Location = new Point(0, 0);
            Step4Panel.Name = "Step4Panel";
            Step4Panel.Size = new Size(1084, 739);
            Step4Panel.TabIndex = 0;
            Step4Panel.Visible = false;
            // 
            // Step5Panel
            // 
            Step5Panel.Controls.Add(panel1);
            Step5Panel.Dock = DockStyle.Fill;
            Step5Panel.Location = new Point(0, 0);
            Step5Panel.Name = "Step5Panel";
            Step5Panel.Size = new Size(1084, 739);
            Step5Panel.TabIndex = 0;
            Step5Panel.Visible = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(materialLabel1);
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1081, 125);
            panel1.TabIndex = 0;
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.Location = new Point(116, 63);
            materialLabel1.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(107, 19);
            materialLabel1.TabIndex = 0;
            materialLabel1.Text = "materialLabel1";
            // 
            // UC_ConsultationWizard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(Stage);
            Name = "UC_ConsultationWizard";
            Size = new Size(1084, 739);
            Stage.ResumeLayout(false);
            Step5Panel.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel Stage;
        private Panel Step1Panel;
        private Panel Step2Panel;
        private Panel Step3Panel;
        private Panel Step4Panel;
        private Panel Step5Panel;
        private Panel panel1;
        private ReaLTaiizor.Controls.MaterialLabel materialLabel1;
    }
}
