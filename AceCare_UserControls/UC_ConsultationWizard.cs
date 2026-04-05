using AceCareClinicSystem.Services;
using AceCareClinicSystem.Controllers;
using System;
using System.Windows.Forms;
using System.Linq;

namespace AceCareClinicSystem.AceCare_UserControls
{
    public partial class UC_ConsultationWizard : UserControl
    {
        private PictureBox[] stepIcons;
        private Panel[] stepLines;
        private ConsultationController _conController = new ConsultationController();

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

     
        private void Next1Btn_Click(object sender, EventArgs e) => WizardMethods.ShowStep(2, StagePanel, stepIcons, stepLines);
        private void PrevBtn_Click(object sender, EventArgs e) => WizardMethods.ShowStep(1, StagePanel, stepIcons, stepLines);
        private void NextS2Btn_Click(object sender, EventArgs e) => WizardMethods.ShowStep(3, StagePanel, stepIcons, stepLines);
        private void PrevS3Btn_Click(object sender, EventArgs e) => WizardMethods.ShowStep(2, StagePanel, stepIcons, stepLines);
        private void NextS3Btn_Click(object sender, EventArgs e) => WizardMethods.ShowStep(4, StagePanel, stepIcons, stepLines);
        private void PrevS4Btn_Click(object sender, EventArgs e) => WizardMethods.ShowStep(3, StagePanel, stepIcons, stepLines);
        private void NextS4Btn_Click(object sender, EventArgs e) => WizardMethods.ShowStep(5, StagePanel, stepIcons, stepLines);
        private void Prevs5Btn_Click(object sender, EventArgs e) => WizardMethods.ShowStep(4, StagePanel, stepIcons, stepLines);

       
        private void txtPatientID_Validating(object sender, System.ComponentModel.CancelEventArgs e) =>
            errorProvider1.SetError(txtPatientID, int.TryParse(txtPatientID.Text, out _) ? "" : "Numeric ID required.");

        private void txtTemperature_Validating(object sender, System.ComponentModel.CancelEventArgs e) =>
            errorProvider1.SetError(txtTemperature, decimal.TryParse(txtTemperature.Text, out _) ? "" : "Invalid temperature.");

        private void txtStaffID_Validating(object sender, System.ComponentModel.CancelEventArgs e) =>
            errorProvider1.SetError(txtStaffID, int.TryParse(txtStaffID.Text, out _) ? "" : "Numeric Staff ID required.");

        private void SaveBtns5_Click(object sender, EventArgs e)
        {

             if (MessageBox.Show("Finalize and save this consultation?", "Confirm Save",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
             {
                try
                {
                   
                    int pId = 0;
                    int sId = 0;
                    int.TryParse(txtPatientID.Text, out pId);
                    int.TryParse(txtStaffID.Text, out sId);

                   
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

                    bool success = _conController.SaveFullConsultation(
                        pId,
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
                        txtEmergencyContact.Text 
                    );

                    if (success)
                    {
                        MessageBox.Show("Consultation Saved Successfully! ✅", "Success");
                       
                        WizardMethods.ShowStep(1, StagePanel, stepIcons, stepLines);
                    }
                    else
                    {
                        MessageBox.Show("Failed to save consultation. Check your database connection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Critical Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void txtPatientID_Click(object sender, EventArgs e)
        {

        }
    }
}