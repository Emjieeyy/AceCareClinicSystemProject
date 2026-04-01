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

            // This ensures the Home design is visible as soon as the Admin logs in
            addUserControl(new UC_Home());
        }

        // This is the method that handles the swapping logic
        private void addUserControl(UserControl userControl)
        {
            // Makes the UserControl stretch to fill the HomemainPanel
            userControl.Dock = DockStyle.Fill;

            // Use your specific panel name here
            HomemainPanel.Controls.Clear();
            HomemainPanel.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void Homebtn_Click(object sender, EventArgs e)
        {
            // When "Home" is clicked, show the UC_Home control
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
    }
}