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

        // CHANGED: Renamed parameters for clarity
        public void LoadPatientData(string patientID, string firstName, string lastName,
            string middleInitial, string category, string department,
            DateTime dateOfBirth, string contact, string emergencyContactNumber,
            string emergencyContactName, string yearLevel)
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

            // CHANGED: Use renamed controls
            txtEmergencyContactName.Text = emergencyContactName ?? "";
            txtEmergencyContactNumber.Text = emergencyContactNumber ?? "";

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

                // CHANGED: Added rbCough and rbCold options
                string complaint = rbHeadache.Checked ? "Headache" :
                                   rbFever.Checked ? "Fever" :
                                   rbCough.Checked ? "Cough" :
                                   rbCold.Checked ? "Cold" :
                                   txtComplaintOther.Text;

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

                // CHANGED: Use renamed controls
                bool success = _conController.SaveFullConsultation(
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
                    txtEmergencyContactName.Text,   // CHANGED: Renamed from txtGuardian
                    txtEmergencyContactNumber.Text, // CHANGED: Renamed from txtEmergencyContact
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

            // CHANGED: Clear renamed textbox fields
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
            txtClinicIncharge.Clear();
            txtAge.Clear();
            txtAddress.Clear();

            // CHANGED: Clear renamed emergency contact fields
            txtEmergencyContactName.Clear();
            txtEmergencyContactNumber.Clear();

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
        }

        private void txtPatientID_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
        }

        private void label52_Click(object sender, EventArgs e)
        {

        }
    }
}