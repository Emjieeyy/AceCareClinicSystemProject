using AceCareClinicSystem.AceCare_UserControls;
using System;
using System.Windows.Forms;

namespace AceCareClinicSystem.Forms
{
    public partial class AdminDashboard : Form
    {
        // NEW: Store references to UserControls so we can access them
        private UC_PatientRecords ucPatientRecords;
        private UC_ConsultationWizard ucConsultationWizard;

        public AdminDashboard()
        {
            InitializeComponent();

            addUserControl(new UC_Home());
        }

        public void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            HomemainPanel.Controls.Clear();
            HomemainPanel.Controls.Add(userControl);
            userControl.BringToFront();
        }

        // NEW: Method to switch to consultation with patient data
        public void OpenConsultationWithPatient(System.Data.DataRow patient)
        {
            // Create consultation wizard if not exists
            if (ucConsultationWizard == null)
            {
                ucConsultationWizard = new UC_ConsultationWizard();
            }

            // Load patient data into consultation
            ucConsultationWizard.LoadPatientData(
                patient["patient_number"].ToString(),
                patient["first_name"].ToString(),
                patient["last_name"].ToString(),
                patient["middle_initial"].ToString(),
                patient["category"].ToString(),
                patient["department"].ToString(),
                Convert.ToDateTime(patient["date_of_birth"]),
                patient["contact_number"].ToString(),
                patient["emergency_contact_name"].ToString(),
                patient["year_level"]?.ToString()
            );

            // Switch to consultation view
            addUserControl(ucConsultationWizard);
        }

        private void Homebtn_Click(object sender, EventArgs e)
        {
            addUserControl(new UC_Home());
        }

        private void HomemainPanel_Paint(object sender, PaintEventArgs e)
        {
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
        }

        // CHANGED: Store reference and wire up event
        private void PatientRecordsBtn_Click(object sender, EventArgs e)
        {
            ucPatientRecords = new UC_PatientRecords();

            // NEW: Wire up double-click event
            ucPatientRecords.PatientSelectedForConsultation += (patient) =>
            {
                OpenConsultationWithPatient(patient);
            };

            addUserControl(ucPatientRecords);
        }

        private void ConsultationBtn_Click(object sender, EventArgs e)
        {
            if (ucConsultationWizard == null)
            {
                ucConsultationWizard = new UC_ConsultationWizard();
            }
            addUserControl(ucConsultationWizard);
        }

        private void hopeButton4_Click(object sender, EventArgs e)
        {
            addUserControl(new UC_MedicineInventory());
        }

        private void ReportBtn_Click(object sender, EventArgs e)
        {
            addUserControl(new UC_Reportscs());
        }

        private void hopeButton6_Click(object sender, EventArgs e)
        {
            addUserControl(new UC_UserManagement());
        }

        private void LogoutBtn_Click(object sender, EventArgs e)
        {

            DialogResult dialog = MessageBox.Show("Are you sure you want to log out?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialog == DialogResult.Yes)
            {
                // 1. Create a new instance of your Login Form
                Login login = new Login();

                // 2. Show the Login Form
                login.Show();

                // 3. Close the current Dashboard Form
                // Use this.Hide() if you want to keep the process alive in the background
                // Use this.Close() if the Login form is the 'Main' entry point of the app
                this.Hide();
            }
        }
    }
}