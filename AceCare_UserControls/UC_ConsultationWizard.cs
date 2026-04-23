using AceCareClinicSystem.Services;
using AceCareClinicSystem.Controllers;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;

namespace AceCareClinicSystem.AceCare_UserControls
{
    public partial class UC_ConsultationWizard : UserControl
    {
        private PictureBox[] stepIcons;
        private Panel[] stepLines;
        private ConsultationController _conController = new ConsultationController();
        private Label lblAssessmentDate;

        // Store loaded patient ID
        private string loadedPatientID = "";

        // Track if we're in edit mode
        private bool _isEditMode = false;
        private int? _existingConsultationId = null;

        public UC_ConsultationWizard()
        {
            InitializeComponent();

            stepIcons = new PictureBox[] { pbStep1, pbStep2, pbStep3, pbStep4, pbStep5 };
            stepLines = new Panel[] { StepLine1, StepLine2, StepLine3, StepLine4 };

            foreach (Control ctrl in StagePanel.Controls)
            {
                if (ctrl is Panel p && p.Name.StartsWith("Step"))
                {
                    p.Dock = DockStyle.Fill;
                    p.Visible = false;
                }
            }

            WizardMethods.ShowStep(1, StagePanel, stepIcons, stepLines);
            InitializeAssessmentDateLabel();
            SetDefaultUser();
        }

        private void InitializeAssessmentDateLabel()
        {
            lblAssessmentDate = new Label();
            lblAssessmentDate.AutoSize = true;
            lblAssessmentDate.Font = new Font("Century Gothic", 11F, FontStyle.Italic);
            lblAssessmentDate.ForeColor = Color.DimGray;
            lblAssessmentDate.BackColor = Color.White;
            lblAssessmentDate.Location = new Point(365, 10);
            
            // Find panel2 (Step 3) to add the label
            foreach (Control ctrl in Controls)
            {
                if (ctrl.Name == "Step3")
                {
                    foreach (Control stepCtrl in ctrl.Controls)
                    {
                        if (stepCtrl.Name == "panel2")
                        {
                            stepCtrl.Controls.Add(lblAssessmentDate);
                            lblAssessmentDate.BringToFront();
                            break;
                        }
                    }
                }
            }
        }

        private void SetDefaultUser()
        {
            txtClinicIncharge.Text = UserSession.FullName;
            txtStaffID.Text = UserSession.UserId > 0 ? UserSession.UserId.ToString() : "";
            if (lblAssessmentDate != null)
                lblAssessmentDate.Text = "Recording: " + DateTime.Now.ToString("dd-MMM-yyyy hh:mm tt");
        }


        // ===========================
        // UPDATED: LoadPatientData with Age, Sex, Address
        // ===========================
        public void LoadPatientData(string patientID, string firstName, string lastName,
            string middleInitial, string category, string department,
            DateTime dateOfBirth, string contact, string emergencyContactNumber,
            string emergencyContactName, string yearLevel,
            int? age, string sex, string address)
        {
            // Store patient ID
            loadedPatientID = patientID;

            // Step 1: Patient Information - Auto-fill from patient record
            txtPatientID.Text = patientID;
            txtPatientID.ReadOnly = true;
            txtPatientID.BackColor = Color.LightGray;

            // Populate the name fields
            txtFirstName.Text = firstName ?? "";
            txtLastName.Text = lastName ?? "";
            txtMI.Text = middleInitial ?? "";

            // UPDATED: Use age from patient record if available, otherwise calculate from DOB
            if (age.HasValue)
                txtAge.Text = age.Value.ToString();
            else
                txtAge.Text = CalculateAge(dateOfBirth).ToString();

            // UPDATED: Use sex from patient record
            cmbSex.Text = !string.IsNullOrEmpty(sex) ? sex : "Male";

            // UPDATED: Use address from patient record
            txtAddress.Text = address ?? "";

            txtContactNo.Text = contact ?? "";

            txtEmergencyContactName.Text = emergencyContactName ?? "";
            txtEmergencyContactNumber.Text = emergencyContactNumber ?? "";



            // CHECK IF PATIENT HAS EXISTING CONSULTATION
            LoadExistingConsultationIfExists(patientID);

            // Show confirmation
            string patientName = $"{firstName} {middleInitial} {lastName}".Trim();
            string message = _isEditMode
                ? $"Patient loaded: {patientName}\nExisting consultation found! You can now edit the record."
                : $"Patient loaded: {patientName}\nCategory: {category}\nDepartment: {department}";

            MessageBox.Show(message, "Patient Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Check if patient has existing consultation and load it
        /// </summary>
        private void LoadExistingConsultationIfExists(string patientNumber)
        {
            DataRow consultation = _conController.GetLatestConsultation(patientNumber);

            if (consultation != null)
            {
                _isEditMode = true;
                _existingConsultationId = Convert.ToInt32(consultation["id"]);

                // Change Save button text
                SaveBtns5.Text = "Update Record";
                SaveBtns5.BackColor = Color.DodgerBlue;
                if (lblAssessmentDate != null)
                    lblAssessmentDate.Text = "Recorded on: " + Convert.ToDateTime(consultation["visit_date"]).ToString("dd-MMM-yyyy hh:mm tt");

                // Load Step 1 data (Patient Info)
                // UPDATED: Only override if consultation has values, otherwise keep patient record values
                if (consultation["age"] != DBNull.Value && !string.IsNullOrWhiteSpace(consultation["age"]?.ToString()))
                    txtAge.Text = consultation["age"].ToString();

                if (consultation["sex"] != DBNull.Value && !string.IsNullOrWhiteSpace(consultation["sex"]?.ToString()))
                    cmbSex.Text = consultation["sex"].ToString();

                if (consultation["address"] != DBNull.Value && !string.IsNullOrWhiteSpace(consultation["address"]?.ToString()))
                    txtAddress.Text = consultation["address"].ToString();

                // Load Step 2 data (Visit Details)
                string visitType = consultation["visit_type"]?.ToString();
                if (visitType == "Consultation") rbConsultation.Checked = true;
                else if (visitType == "First Aid") rbFirstAid.Checked = true;
                else if (visitType == "Emergency") rbEmergency.Checked = true;

                string referredBy = consultation["referred_by"]?.ToString();
                if (referredBy == "Teacher") rbRefTeacher.Checked = true;
                else if (referredBy == "Self") rbRefSelf.Checked = true;
                else if (!string.IsNullOrWhiteSpace(referredBy))
                {
                    rbRefFriend.Checked = true;
                    txtRefOtherDetails.Text = consultation["ref_details"]?.ToString() ?? "";
                }

                string chiefComplaint = consultation["chief_complaint"]?.ToString();
                if (chiefComplaint == "Headache") rbHeadache.Checked = true;
                else if (chiefComplaint == "Fever") rbFever.Checked = true;
                else if (chiefComplaint == "Cough") rbCough.Checked = true;
                else if (chiefComplaint == "Cold") rbCold.Checked = true;
                else if (chiefComplaint == "Stomachache") rbStomachache.Checked = true;
                else if (chiefComplaint == "Dizziness") rbDizziness.Checked = true;
                else if (chiefComplaint == "Injury") rbInjury.Checked = true;
                else if (chiefComplaint == "Menstrual Pain") rbMenstrual.Checked = true;
                else if (!string.IsNullOrWhiteSpace(chiefComplaint))
                {
                    rbStomachache.Checked = true;
                }

                rtbSymptomsDescription.Text = consultation["symptoms_description"]?.ToString() ?? "";

                // Load Step 3 data (Vital Signs & Assessment)
                txtTemperature.Text = consultation["temperature"]?.ToString() ?? "";
                txtBloodPressure.Text = consultation["blood_pressure"]?.ToString() ?? "";
                txtNumPulseRate.Text = consultation["pulse_rate"]?.ToString() ?? "";
                txtNumRespiratoryRate.Text = consultation["respiratory_rate"]?.ToString() ?? "";
                txtNumOxygenSaturation.Text = consultation["oxygen_saturation"]?.ToString() ?? "";
                txtPhysicalFindings.Text = consultation["physical_findings"]?.ToString() ?? "";
                rtbInjuryDescription.Text = consultation["injury_description"]?.ToString() ?? "";
                rtbNurseNotes.Text = consultation["nurse_notes"]?.ToString() ?? "";

                // Load Step 4 data (Treatment & Medicine)
                string treatmentChecklist = consultation["treatment_checklist"]?.ToString() ?? "";
                chkMedication.Checked = treatmentChecklist.Contains("Medication");
                chkRest.Checked = treatmentChecklist.Contains("Rest");
                if (!string.IsNullOrWhiteSpace(treatmentChecklist) && !chkMedication.Checked && !chkRest.Checked)
                {
                    txtFirstAidOther.Text = consultation["treatment_other"]?.ToString() ?? "";
                }

                cmbMedicineName.Text = consultation["medicine_name"]?.ToString() ?? "";
                txtNumMedQuantity.Text = consultation["medicine_quantity"]?.ToString() ?? "";
                txtDosage.Text = consultation["dosage"]?.ToString() ?? "";

                if (consultation["medicine_expiry"] != DBNull.Value)
                    dtpExpiration.Value = Convert.ToDateTime(consultation["medicine_expiry"]);

                rtbTreatmentNotes.Text = consultation["treatment_notes"]?.ToString() ?? "";

                // Load Step 5 data (Outcome & Confirmation)
                string outcome = consultation["outcome"]?.ToString();
                if (outcome == "Returned to Normal Activity") rbNormalActivity.Checked = true;
                else if (outcome == "Sent Home") rbSentHome.Checked = true;
                else if (outcome == "Referred to Hospital") rbReferredHospital.Checked = true;

                rtbRemarksInstructions.Text = consultation["remarks_instructions"]?.ToString() ?? "";
                txtClinicIncharge.Text = consultation["clinic_incharge"]?.ToString() ?? "";
                rtbFinalNotes.Text = consultation["final_notes"]?.ToString() ?? "";
                txtStaffID.Text = consultation["user_id"]?.ToString() ?? "";
            }
            else
            {
                // New consultation - reset button
                _isEditMode = false;
                _existingConsultationId = null;
                SaveBtns5.Text = "Save";
                SaveBtns5.BackColor = Color.LimeGreen;
                SetDefaultUser();
            }
        }

        // Helper to calculate age
        private int CalculateAge(DateTime birthDate)
        {
            int age = DateTime.Now.Year - birthDate.Year;
            if (DateTime.Now.DayOfYear < birthDate.DayOfYear)
                age--;
            return age;
        }

        private void Next1Btn_Click(object sender, EventArgs e) => WizardMethods.ShowStep(2, StagePanel, stepIcons, stepLines);
        private void PrevBtn_Click(object sender, EventArgs e) => WizardMethods.ShowStep(1, StagePanel, stepIcons, stepLines);
        private void NextS2Btn_Click(object sender, EventArgs e) => WizardMethods.ShowStep(3, StagePanel, stepIcons, stepLines);
        private void PrevS3Btn_Click(object sender, EventArgs e) => WizardMethods.ShowStep(2, StagePanel, stepIcons, stepLines);
        private void NextS3Btn_Click(object sender, EventArgs e) => WizardMethods.ShowStep(4, StagePanel, stepIcons, stepLines);
        private void PrevS4Btn_Click(object sender, EventArgs e) => WizardMethods.ShowStep(3, StagePanel, stepIcons, stepLines);
        private void NextS4Btn_Click(object sender, EventArgs e) => WizardMethods.ShowStep(5, StagePanel, stepIcons, stepLines);
        private void Prevs5Btn_Click(object sender, EventArgs e) => WizardMethods.ShowStep(4, StagePanel, stepIcons, stepLines);

        private void txtPatientID_Validating(object sender, System.ComponentModel.CancelEventArgs e) =>
            errorProvider1.SetError(txtPatientID, string.IsNullOrWhiteSpace(txtPatientID.Text) ? "Patient ID Number is required." : "");

        private void txtTemperature_Validating(object sender, System.ComponentModel.CancelEventArgs e) =>
            errorProvider1.SetError(txtTemperature, decimal.TryParse(txtTemperature.Text, out _) ? "" : "Invalid temperature.");

        private void txtNumPulseRate_Validating(object sender, System.ComponentModel.CancelEventArgs e) =>
            errorProvider1.SetError(txtNumPulseRate, int.TryParse(txtNumPulseRate.Text, out _) ? "" : "Invalid pulse rate.");

        private void txtNumRespiratoryRate_Validating(object sender, System.ComponentModel.CancelEventArgs e) =>
            errorProvider1.SetError(txtNumRespiratoryRate, int.TryParse(txtNumRespiratoryRate.Text, out _) ? "" : "Invalid respiratory rate.");

        private void txtNumOxygenSaturation_Validating(object sender, System.ComponentModel.CancelEventArgs e) =>
            errorProvider1.SetError(txtNumOxygenSaturation, decimal.TryParse(txtNumOxygenSaturation.Text, out _) ? "" : "Invalid oxygen saturation.");

        private void txtNumMedQuantity_Validating(object sender, System.ComponentModel.CancelEventArgs e) =>
            errorProvider1.SetError(txtNumMedQuantity, int.TryParse(txtNumMedQuantity.Text, out _) ? "" : "Invalid quantity.");

        private void txtStaffID_Validating(object sender, System.ComponentModel.CancelEventArgs e) =>
            errorProvider1.SetError(txtStaffID, int.TryParse(txtStaffID.Text, out _) ? "" : "Numeric Staff ID required.");

        private void SaveBtns5_Click(object sender, EventArgs e)
        {
            string patientNumber = !string.IsNullOrEmpty(loadedPatientID) ? loadedPatientID : txtPatientID.Text.Trim();

            if (string.IsNullOrWhiteSpace(patientNumber))
            {
                MessageBox.Show("Please enter a Patient ID Number.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int sId = 0;
            if (!int.TryParse(txtStaffID.Text, out sId) || sId <= 0)
            {
                MessageBox.Show("Please enter a valid Staff ID.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate numeric textbox fields
            if (!int.TryParse(txtNumPulseRate.Text, out int pulseRate))
            {
                MessageBox.Show("Please enter a valid Pulse Rate.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtNumRespiratoryRate.Text, out int respiratoryRate))
            {
                MessageBox.Show("Please enter a valid Respiratory Rate.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtNumOxygenSaturation.Text, out decimal oxygenSat))
            {
                MessageBox.Show("Please enter a valid Oxygen Saturation.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtNumMedQuantity.Text, out int medQty))
            {
                MessageBox.Show("Please enter a valid Medicine Quantity.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // STOCK VALIDATION
            string medicineName = cmbMedicineName.Text.Trim();
            if (!string.IsNullOrWhiteSpace(medicineName) && medQty > 0)
            {
                InventoryController invController = new InventoryController();
                int currentStock = invController.GetTotalStock(medicineName);

                // If updating, we should account for the quantity already "held" by this consultation
                if (_isEditMode && _existingConsultationId.HasValue)
                {
                    DataRow currentRecord = _conController.GetConsultationById(_existingConsultationId.Value);
                    if (currentRecord != null && currentRecord["medicine_name"]?.ToString() == medicineName)
                    {
                        currentStock += Convert.ToInt32(currentRecord["medicine_quantity"] ?? 0);
                    }
                }

                if (currentStock < medQty)
                {
                    MessageBox.Show($"Insufficient stock for {medicineName}.\nAvailable: {currentStock}\nRequested: {medQty}",
                        "Out of Stock", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            string confirmText = _isEditMode ? "Update this consultation record?" : "Finalize and save this consultation?";
            if (MessageBox.Show(confirmText, "Confirm",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                string vType = rbConsultation.Checked ? "Consultation" :
                               rbFirstAid.Checked ? "First Aid" : "Emergency";

                string refBy = rbRefTeacher.Checked ? "Teacher" :
                               rbRefSelf.Checked ? "Self" :
                               rbRefFriend.Checked ? "Friend / Relative" :
                               txtRefOtherDetails.Text;

                string complaint = rbHeadache.Checked ? "Headache" :
                                   rbFever.Checked ? "Fever" :
                                   rbCough.Checked ? "Cough" :
                                   rbCold.Checked ? "Cold" :
                                   rbStomachache.Checked ? "Stomachache" :
                                   rbDizziness.Checked ? "Dizziness" :
                                   rbInjury.Checked ? "Injury" :
                                   rbMenstrual.Checked ? "Menstrual Pain" :
                                   "Other";

                decimal temp = 0;
                decimal.TryParse(txtTemperature.Text, out temp);

                string treatment = "";
                if (chkMedication.Checked) treatment += "Medication; ";
                if (chkRest.Checked) treatment += "Rest; ";
                if (!string.IsNullOrWhiteSpace(txtFirstAidOther.Text)) treatment += txtFirstAidOther.Text;

                string outcome = rbNormalActivity.Checked ? "Returned to Normal Activity" :
                                rbSentHome.Checked ? "Sent Home" : "Referred to Hospital";

                string safeDosage = !string.IsNullOrWhiteSpace(txtDosage.Text)
                    ? txtDosage.Text.Trim()
                    : "N/A";

                bool success;

                if (_isEditMode && _existingConsultationId.HasValue)
                {
                    // UPDATE existing consultation
                    success = _conController.UpdateConsultation(
                        _existingConsultationId.Value,
                        patientNumber,
                        vType,
                        refBy,
                        complaint,
                        rtbSymptomsDescription.Text,
                        temp,
                        txtBloodPressure.Text,
                        pulseRate,
                        respiratoryRate,
                        oxygenSat,
                        txtPhysicalFindings.Text,
                        rtbInjuryDescription.Text,
                        rtbNurseNotes.Text,
                        treatment,
                        cmbMedicineName.Text,
                        medQty,
                        safeDosage,
                        dtpExpiration.Value,
                        rtbTreatmentNotes.Text,
                        outcome,
                        rtbRemarksInstructions.Text,
                        txtClinicIncharge.Text,
                        sId,
                        rtbFinalNotes.Text,
                        txtAge.Text,
                        cmbSex.Text,
                        txtAddress.Text,
                        txtEmergencyContactName.Text,
                        txtEmergencyContactNumber.Text,
                        txtFirstName.Text,
                        txtLastName.Text,
                        "Student",
                        "Unknown"
                    );
                }
                else
                {
                    // SAVE new consultation
                    success = _conController.SaveFullConsultation(
                        patientNumber,
                        vType,
                        refBy,
                        complaint,
                        rtbSymptomsDescription.Text,
                        temp,
                        txtBloodPressure.Text,
                        pulseRate,
                        respiratoryRate,
                        oxygenSat,
                        txtPhysicalFindings.Text,
                        rtbInjuryDescription.Text,
                        rtbNurseNotes.Text,
                        treatment,
                        cmbMedicineName.Text,
                        medQty,
                        safeDosage,
                        dtpExpiration.Value,
                        rtbTreatmentNotes.Text,
                        outcome,
                        rtbRemarksInstructions.Text,
                        txtClinicIncharge.Text,
                        sId,
                        rtbFinalNotes.Text,
                        txtAge.Text,
                        cmbSex.Text,
                        txtAddress.Text,
                        txtEmergencyContactName.Text,
                        txtEmergencyContactNumber.Text,
                        txtFirstName.Text,
                        txtLastName.Text,
                        "Student",
                        "Unknown"
                    );
                }

                if (success)
                {
                    string successMsg = _isEditMode ? "Consultation Updated Successfully! ✅" : "Consultation Saved Successfully! ✅";
                    MessageBox.Show(successMsg, "Success");
                    WizardMethods.ShowStep(1, StagePanel, stepIcons, stepLines);
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Failed to save consultation.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Critical Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearForm()
        {
            // Clear name fields
            txtFirstName.Clear();
            txtLastName.Clear();
            txtMI.Clear();

            txtPatientID.ReadOnly = false;
            txtPatientID.BackColor = Color.White;
            loadedPatientID = "";

            txtPatientID.Clear();
            txtTemperature.Clear();
            txtBloodPressure.Clear();
            txtPhysicalFindings.Clear();

            // Reset edit mode
            _isEditMode = false;
            _existingConsultationId = null;
            SaveBtns5.Text = "Save";
            SaveBtns5.BackColor = Color.LimeGreen;

            txtNumPulseRate.Clear();
            txtNumRespiratoryRate.Clear();
            txtNumOxygenSaturation.Clear();
            txtNumMedQuantity.Clear();

            rtbSymptomsDescription.Clear();
            rtbInjuryDescription.Clear();
            rtbNurseNotes.Clear();
            rtbTreatmentNotes.Clear();
            rtbRemarksInstructions.Clear();
            rtbFinalNotes.Clear();
            SetDefaultUser();
            txtAge.Clear();
            txtAddress.Clear();

            txtEmergencyContactName.Clear();
            txtEmergencyContactNumber.Clear();

            txtRefOtherDetails.Clear();
            txtFirstAidOther.Clear();
            txtDosage.Clear();
            cmbMedicineName.SelectedIndex = -1;
            cmbSex.SelectedIndex = -1;

            rbConsultation.Checked = true;
            rbRefSelf.Checked = true;
            rbHeadache.Checked = true;
            rbNormalActivity.Checked = true;
            chkMedication.Checked = false;
            chkRest.Checked = false;
        }

        private void txtPatientID_Click(object sender, EventArgs e) { }
        private void pictureBox12_Click(object sender, EventArgs e) { }
        private void label52_Click(object sender, EventArgs e) { }
        private void rtbInjuryDescription_Click(object sender, EventArgs e) { }
    }
}