using AceCareClinicSystem.AceCare_UserControls;
using AceCareClinicSystem.Services;
using System;
using System.Windows.Forms;

namespace AceCareClinicSystem.Forms
{
    public partial class ClinicStaffDashboard : Form
    {
        public ClinicStaffDashboard()
        {
            InitializeComponent();
        }

        public void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            HomemainPanel.Controls.Clear();
            HomemainPanel.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void ClinicStaffDashboard_Load(object sender, EventArgs e)
        {
            addUserControl(new UC_Home("Clinic Staff"));
        }

        private void Homebtn_Click(object sender, EventArgs e)
        {
            addUserControl(new UC_Home("Clinic Staff"));
        }

        private void PatientRecordsBtn_Click(object sender, EventArgs e)
        {
            addUserControl(new UC_PatientRecords());
        }

        private void InventoryBtn_Click(object sender, EventArgs e)
        {
            addUserControl(new UC_MedicineInventory());
        }

        private void ReportBtn_Click(object sender, EventArgs e)
        {
            addUserControl(new UC_Reportscs());
        }

        private void hopeButton6_Click(object sender, EventArgs e)
        {
            addUserControl(new UC_About());
        }

        private void LogoutBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to log out?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                
                // Open your Landing Page
                AceCareLanding landing = new AceCareLanding();
                landing.Show();
                this.Hide();

            }
        }

        private void ConsultationBtn_Click(object sender, EventArgs e)
        {
            addUserControl(new UC_ConsultationWizard());
        }
    }
}