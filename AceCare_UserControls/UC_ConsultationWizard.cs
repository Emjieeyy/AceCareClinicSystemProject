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

        // Store loaded patient ID
        private string loadedPatientID = "";

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
        }

        // CHANGED: Removed auto-advance to Step 2, now stays on Step 1
        public void LoadPatientData(string patientID, string firstName, string lastName,
            string middleInitial, string category, string department,
            DateTime dateOfBirth, string contact, string emergency, string yearLevel)
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

            // Calculate age from date of birth
            int age = CalculateAge(dateOfBirth);
            txtAge.Text = age.ToString();

            // Set sex - default or from record
            cmbSex.Text = "Male";

            // Address - leave blank for input
            txtAddress.Text = "";

            // Guardian/Emergency from patient record
            txtGuardian.Text = emergency ?? "";
            txtEmergencyContact.Text = emergency ?? "";

            // REMOVED: Don't auto-advance to Step 2, stay on Step 1 for review
            // WizardMethods.ShowStep(2, StagePanel, stepIcons, stepLines);

            // Show confirmation
            string patientName = $"{firstName} {middleInitial} {lastName}".Trim();
            MessageBox.Show($"Patient loaded: {patientName}\nCategory: {category}\nDepartment: {department}",
                "Patient Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            if (MessageBox.Show("Finalize and save this consultation?", "Confirm Save",
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
                               txtRefOtherDetails.Text;

                string complaint = rbHeadache.Checked ? "Headache" :
                                   rbFever.Checked ? "Fever" :
                                   txtComplaintOther.Text;

                decimal temp = 0;
                decimal.TryParse(txtTemperature.Text, out temp);

                decimal oxySat = 0;
                decimal.TryParse(numOxygenSaturation.Value.ToString(), out oxySat);

                string treatment = "";
                if (chkMedication.Checked) treatment += "Medication; ";
                if (chkRest.Checked) treatment += "Rest; ";
                if (!string.IsNullOrWhiteSpace(txtFirstAidOther.Text)) treatment += txtFirstAidOther.Text;

                string outcome = rbNormalActivity.Checked ? "Returned to Normal Activity" :
                                rbSentHome.Checked ? "Sent Home" : "Referred to Hospital";

                string safeDosage = !string.IsNullOrWhiteSpace(txtDosage.Text)
                    ? txtDosage.Text.Trim()
                    : "N/A";

                // Use actual names from form
                bool success = _conController.SaveFullConsultation(
                    patientNumber,
                    vType,
                    refBy,
                    complaint,
                    rtbSymptomsDescription.Text,
                    temp,
                    txtBloodPressure.Text,
                    (int)numPulseRate.Value,
                    (int)numRespiratoryRate.Value,
                    oxySat,
                    txtPhysicalFindings.Text,
                    rtbInjuryDescription.Text,
                    rtbNurseNotes.Text,
                    treatment,
                    cmbMedicineName.Text,
                    (int)numMedQuantity.Value,
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
                    txtGuardian.Text,
                    txtEmergencyContact.Text,
                    txtFirstName.Text,
                    txtLastName.Text,
                    "Student",
                    "Unknown"
                );

                if (success)
                {
                    MessageBox.Show("Consultation Saved Successfully! ✅", "Success");
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
            txtStaffID.Clear();
            txtTemperature.Clear();
            txtBloodPressure.Clear();
            txtPhysicalFindings.Clear();
            rtbSymptomsDescription.Clear();
            rtbInjuryDescription.Clear();
            rtbNurseNotes.Clear();
            rtbTreatmentNotes.Clear();
            rtbRemarksInstructions.Clear();
            rtbFinalNotes.Clear();
            txtClinicIncharge.Clear();
            txtAge.Clear();
            txtAddress.Clear();
            txtGuardian.Clear();
            txtEmergencyContact.Clear();
            txtRefOtherDetails.Clear();
            txtComplaintOther.Text = "";
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

            numPulseRate.Value = 0;
            numRespiratoryRate.Value = 0;
            numOxygenSaturation.Value = 0;
            numMedQuantity.Value = 0;
            dtpExpiration.Value = DateTime.Now.AddYears(1);
        }

        private void txtPatientID_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
        }
    }
}