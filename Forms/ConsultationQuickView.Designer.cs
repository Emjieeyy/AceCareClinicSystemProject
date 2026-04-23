namespace AceCareClinicSystem.Forms
{
    partial class ConsultationQuickView
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
            label1 = new Label();
            label16 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            btnViewHistory = new Button();
            btnClose = new Button();
            lblPatientName = new Label();
            lblSex = new Label();
            lblVisitType = new Label();
            lblComplaint = new Label();
            lblVitals = new Label();
            lblDiagnosis = new Label();
            lblMedicine = new Label();
            lblOutcome = new Label();
            lblHandledBy = new Label();
            lblDate = new Label();
            label = new Label();
            lblAge = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(52, 19);
            label1.Name = "label1";
            label1.Size = new Size(436, 37);
            label1.TabIndex = 1;
            label1.Text = "Consultation Quick Summary";
           
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label16.Location = new Point(51, 86);
            label16.Name = "label16";
            label16.Size = new Size(67, 23);
            label16.TabIndex = 10;
            label16.Text = "Patient:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(54, 150);
            label2.Name = "label2";
            label2.Size = new Size(45, 23);
            label2.TabIndex = 11;
            label2.Text = "Sex: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(50, 186);
            label3.Name = "label3";
            label3.Size = new Size(61, 23);
            label3.TabIndex = 12;
            label3.Text = " Visit:  ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(50, 227);
            label4.Name = "label4";
            label4.Size = new Size(93, 23);
            label4.TabIndex = 13;
            label4.Text = "Complaint:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(52, 274);
            label5.Name = "label5";
            label5.Size = new Size(65, 23);
            label5.TabIndex = 14;
            label5.Text = "Vitals:  ";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(50, 323);
            label6.Name = "label6";
            label6.Size = new Size(87, 23);
            label6.TabIndex = 15;
            label6.Text = "Diagnosis:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(48, 385);
            label7.Name = "label7";
            label7.Size = new Size(88, 23);
            label7.TabIndex = 16;
            label7.Text = " Medicine:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(48, 476);
            label8.Name = "label8";
            label8.Size = new Size(106, 23);
            label8.TabIndex = 17;
            label8.Text = " Handled By:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(50, 433);
            label9.Name = "label9";
            label9.Size = new Size(90, 23);
            label9.TabIndex = 18;
            label9.Text = "Outcome: ";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Location = new Point(52, 521);
            label10.Name = "label10";
            label10.Size = new Size(50, 23);
            label10.TabIndex = 19;
            label10.Text = "Date:";
            // 
            // btnViewHistory
            // 
            btnViewHistory.Location = new Point(225, 568);
            btnViewHistory.Name = "btnViewHistory";
            btnViewHistory.Size = new Size(168, 29);
            btnViewHistory.TabIndex = 20;
            btnViewHistory.Text = "View Full History";
            btnViewHistory.UseVisualStyleBackColor = true;
            btnViewHistory.Click += btnViewHistory_Click;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(412, 568);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(135, 29);
            btnClose.TabIndex = 21;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // lblPatientName
            // 
            lblPatientName.AutoSize = true;
            lblPatientName.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPatientName.Location = new Point(215, 86);
            lblPatientName.Name = "lblPatientName";
            lblPatientName.Size = new Size(67, 23);
            lblPatientName.TabIndex = 22;
            lblPatientName.Text = "Patient:";
            // 
            // lblSex
            // 
            lblSex.AutoSize = true;
            lblSex.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSex.Location = new Point(215, 151);
            lblSex.Name = "lblSex";
            lblSex.Size = new Size(67, 23);
            lblSex.TabIndex = 23;
            lblSex.Text = "Patient:";
            // 
            // lblVisitType
            // 
            lblVisitType.AutoSize = true;
            lblVisitType.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblVisitType.Location = new Point(215, 186);
            lblVisitType.Name = "lblVisitType";
            lblVisitType.Size = new Size(67, 23);
            lblVisitType.TabIndex = 24;
            lblVisitType.Text = "Patient:";
            // 
            // lblComplaint
            // 
            lblComplaint.AutoSize = true;
            lblComplaint.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblComplaint.Location = new Point(215, 227);
            lblComplaint.Name = "lblComplaint";
            lblComplaint.Size = new Size(67, 23);
            lblComplaint.TabIndex = 25;
            lblComplaint.Text = "Patient:";
            // 
            // lblVitals
            // 
            lblVitals.AutoSize = true;
            lblVitals.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblVitals.Location = new Point(215, 265);
            lblVitals.Name = "lblVitals";
            lblVitals.Size = new Size(67, 23);
            lblVitals.TabIndex = 26;
            lblVitals.Text = "Patient:";
            // 
            // lblDiagnosis
            // 
            lblDiagnosis.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDiagnosis.Location = new Point(215, 318);
            lblDiagnosis.MaximumSize = new Size(280, 60);
            lblDiagnosis.Name = "lblDiagnosis";
            lblDiagnosis.Size = new Size(280, 60);
            lblDiagnosis.TabIndex = 27;
            lblDiagnosis.Text = "Patient:";
            // 
            // lblMedicine
            // 
            lblMedicine.AutoSize = true;
            lblMedicine.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMedicine.Location = new Point(215, 389);
            lblMedicine.Name = "lblMedicine";
            lblMedicine.Size = new Size(67, 23);
            lblMedicine.TabIndex = 28;
            lblMedicine.Text = "Patient:";
            // 
            // lblOutcome
            // 
            lblOutcome.AutoSize = true;
            lblOutcome.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblOutcome.Location = new Point(215, 430);
            lblOutcome.Name = "lblOutcome";
            lblOutcome.Size = new Size(67, 23);
            lblOutcome.TabIndex = 29;
            lblOutcome.Text = "Patient:";
            // 
            // lblHandledBy
            // 
            lblHandledBy.AutoSize = true;
            lblHandledBy.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblHandledBy.Location = new Point(215, 478);
            lblHandledBy.Name = "lblHandledBy";
            lblHandledBy.Size = new Size(67, 23);
            lblHandledBy.TabIndex = 30;
            lblHandledBy.Text = "Patient:";
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDate.Location = new Point(215, 521);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(67, 23);
            lblDate.TabIndex = 31;
            lblDate.Text = "Patient:";
            // 
            // label
            // 
            label.AutoSize = true;
            label.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label.Location = new Point(57, 116);
            label.Name = "label";
            label.Size = new Size(44, 23);
            label.TabIndex = 32;
            label.Text = "Age:";
            // 
            // lblAge
            // 
            lblAge.AutoSize = true;
            lblAge.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAge.Location = new Point(215, 119);
            lblAge.Name = "lblAge";
            lblAge.Size = new Size(67, 23);
            lblAge.TabIndex = 33;
            lblAge.Text = "Patient:";
            // 
            // ConsultationQuickView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(577, 628);
            Controls.Add(lblAge);
            Controls.Add(label);
            Controls.Add(lblDate);
            Controls.Add(lblHandledBy);
            Controls.Add(lblOutcome);
            Controls.Add(lblMedicine);
            Controls.Add(lblDiagnosis);
            Controls.Add(lblVitals);
            Controls.Add(lblComplaint);
            Controls.Add(lblVisitType);
            Controls.Add(lblSex);
            Controls.Add(lblPatientName);
            Controls.Add(btnClose);
            Controls.Add(btnViewHistory);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label16);
            Controls.Add(label1);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "ConsultationQuickView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ConsultationQuickView";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label16;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Button btnViewHistory;
        private Button btnClose;
        private Label lblPatientName;
        private Label lblSex;
        private Label lblVisitType;
        private Label lblComplaint;
        private Label lblVitals;
        private Label lblDiagnosis;
        private Label lblMedicine;
        private Label lblOutcome;
        private Label lblHandledBy;
        private Label lblDate;
        private Label label;
        private Label lblAge;
    }
}