using AceCareClinicSystem.AceCare_UserControls;
using System;
using System.Windows.Forms;

namespace AceCareClinicSystem.Forms
{
    public partial class AdminDashboard : Form
    {
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

        private void PatientRecordsBtn_Click(object sender, EventArgs e)
        {
            addUserControl(new UC_PatientRecords());
        }

        private void ConsultationBtn_Click(object sender, EventArgs e)
        {
            addUserControl(new UC_ConsultationWizard());
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
    }
}