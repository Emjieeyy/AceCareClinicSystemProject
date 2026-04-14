namespace AceCareClinicSystem.Forms
{
    partial class FormPatientEdit
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
            txtIDNumber = new ReaLTaiizor.Controls.PoisonTextBox();
            txtFirstName = new ReaLTaiizor.Controls.PoisonTextBox();
            txtLastName = new ReaLTaiizor.Controls.PoisonTextBox();
            txtMI = new ReaLTaiizor.Controls.PoisonTextBox();
            txtContact = new ReaLTaiizor.Controls.PoisonTextBox();
            txtEmergencyName = new ReaLTaiizor.Controls.PoisonTextBox();
            txtEmergencyNumber = new ReaLTaiizor.Controls.PoisonTextBox();
            cmbCategory = new ReaLTaiizor.Controls.PoisonComboBox();
            cmbDepartment = new ReaLTaiizor.Controls.PoisonComboBox();
            cmbYearLevel = new ReaLTaiizor.Controls.PoisonComboBox();
            dobPicker = new System.Windows.Forms.DateTimePicker();
            btnSave = new ReaLTaiizor.Controls.HopeRoundButton();
            btnCancel = new ReaLTaiizor.Controls.HopeRoundButton();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // txtIDNumber
            // 
            txtIDNumber.Location = new System.Drawing.Point(30, 100);
            txtIDNumber.Name = "txtIDNumber";
            txtIDNumber.Size = new System.Drawing.Size(180, 30);
            txtIDNumber.TabIndex = 0;
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new System.Drawing.Point(230, 100);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new System.Drawing.Size(180, 30);
            txtFirstName.TabIndex = 1;
            // 
            // txtLastName
            // 
            txtLastName.Location = new System.Drawing.Point(430, 100);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new System.Drawing.Size(180, 30);
            txtLastName.TabIndex = 2;
            // 
            // txtMI
            // 
            txtMI.Location = new System.Drawing.Point(630, 100);
            txtMI.Name = "txtMI";
            txtMI.Size = new System.Drawing.Size(60, 30);
            txtMI.TabIndex = 3;
            // 
            // txtContact
            // 
            txtContact.Location = new System.Drawing.Point(30, 170);
            txtContact.Name = "txtContact";
            txtContact.Size = new System.Drawing.Size(180, 30);
            txtContact.TabIndex = 4;
            // 
            // cmbCategory
            // 
            cmbCategory.FormattingEnabled = true;
            cmbCategory.ItemHeight = 23;
            cmbCategory.Location = new System.Drawing.Point(230, 170);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new System.Drawing.Size(180, 29);
            cmbCategory.TabIndex = 5;
            // 
            // cmbDepartment
            // 
            cmbDepartment.FormattingEnabled = true;
            cmbDepartment.ItemHeight = 23;
            cmbDepartment.Location = new System.Drawing.Point(430, 170);
            cmbDepartment.Name = "cmbDepartment";
            cmbDepartment.Size = new System.Drawing.Size(180, 29);
            cmbDepartment.TabIndex = 6;
            // 
            // cmbYearLevel
            // 
            cmbYearLevel.FormattingEnabled = true;
            cmbYearLevel.ItemHeight = 23;
            cmbYearLevel.Location = new System.Drawing.Point(30, 240);
            cmbYearLevel.Name = "cmbYearLevel";
            cmbYearLevel.Size = new System.Drawing.Size(180, 29);
            cmbYearLevel.TabIndex = 7;
            // 
            // dobPicker
            // 
            dobPicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dobPicker.Location = new System.Drawing.Point(230, 241);
            dobPicker.Name = "dobPicker";
            dobPicker.Size = new System.Drawing.Size(180, 27);
            dobPicker.TabIndex = 8;
            // 
            // txtEmergencyName
            // 
            txtEmergencyName.Location = new System.Drawing.Point(30, 310);
            txtEmergencyName.Name = "txtEmergencyName";
            txtEmergencyName.Size = new System.Drawing.Size(320, 30);
            txtEmergencyName.TabIndex = 9;
            // 
            // txtEmergencyNumber
            // 
            txtEmergencyNumber.Location = new System.Drawing.Point(370, 310);
            txtEmergencyNumber.Name = "txtEmergencyNumber";
            txtEmergencyNumber.Size = new System.Drawing.Size(240, 30);
            txtEmergencyNumber.TabIndex = 10;
            // 
            // btnSave
            // 
            btnSave.PrimaryColor = System.Drawing.Color.DarkBlue;
            btnSave.Location = new System.Drawing.Point(430, 370);
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(120, 40);
            btnSave.TabIndex = 11;
            btnSave.Text = "Update";
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.PrimaryColor = System.Drawing.Color.Gray;
            btnCancel.Location = new System.Drawing.Point(570, 370);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(120, 40);
            btnCancel.TabIndex = 12;
            btnCancel.Text = "Cancel";
            btnCancel.Click += btnCancel_Click;
            // 
            // labels
            // 
            label1.Text = "ID Number"; label1.Location = new System.Drawing.Point(30, 75);
            label2.Text = "First Name"; label2.Location = new System.Drawing.Point(230, 75);
            label3.Text = "Last Name"; label3.Location = new System.Drawing.Point(430, 75);
            label4.Text = "M.I."; label4.Location = new System.Drawing.Point(630, 75);
            label5.Text = "Contact"; label5.Location = new System.Drawing.Point(30, 145);
            label6.Text = "Category"; label6.Location = new System.Drawing.Point(230, 145);
            label7.Text = "Department"; label7.Location = new System.Drawing.Point(430, 145);
            label8.Text = "Year Level"; label8.Location = new System.Drawing.Point(30, 215);
            label9.Text = "Date of Birth"; label9.Location = new System.Drawing.Point(230, 215);
            label10.Text = "Emergency Contact Name"; label10.Location = new System.Drawing.Point(30, 285);
            label11.Text = "Emergency Contact Number"; label11.Location = new System.Drawing.Point(370, 285);
            // 
            // FormPatientEdit
            // 
            ClientSize = new System.Drawing.Size(730, 440);
            Controls.Add(txtIDNumber); Controls.Add(txtFirstName); Controls.Add(txtLastName); Controls.Add(txtMI);
            Controls.Add(txtContact); Controls.Add(cmbCategory); Controls.Add(cmbDepartment);
            Controls.Add(cmbYearLevel); Controls.Add(dobPicker);
            Controls.Add(txtEmergencyName); Controls.Add(txtEmergencyNumber);
            Controls.Add(btnSave); Controls.Add(btnCancel);
            Controls.Add(label1); Controls.Add(label2); Controls.Add(label3); Controls.Add(label4);
            Controls.Add(label5); Controls.Add(label6); Controls.Add(label7); Controls.Add(label8);
            Controls.Add(label9); Controls.Add(label10); Controls.Add(label11);
            Text = "Edit Patient Record";
            ResumeLayout(false);
        }

        private ReaLTaiizor.Controls.PoisonTextBox txtIDNumber;
        private ReaLTaiizor.Controls.PoisonTextBox txtFirstName;
        private ReaLTaiizor.Controls.PoisonTextBox txtLastName;
        private ReaLTaiizor.Controls.PoisonTextBox txtMI;
        private ReaLTaiizor.Controls.PoisonTextBox txtContact;
        private ReaLTaiizor.Controls.PoisonTextBox txtEmergencyName;
        private ReaLTaiizor.Controls.PoisonTextBox txtEmergencyNumber;
        private ReaLTaiizor.Controls.PoisonComboBox cmbCategory;
        private ReaLTaiizor.Controls.PoisonComboBox cmbDepartment;
        private ReaLTaiizor.Controls.PoisonComboBox cmbYearLevel;
        private System.Windows.Forms.DateTimePicker dobPicker;
        private ReaLTaiizor.Controls.HopeRoundButton btnSave;
        private ReaLTaiizor.Controls.HopeRoundButton btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
    }
}
