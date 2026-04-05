using AceCareClinicSystem.Controllers;
using AceCareClinicSystem.Forms;
using AceCareClinicSystem.Services;
using System;
using System.Data;
using System.Windows.Forms;

namespace AceCareClinicSystem.AceCare_UserControls
{
    public partial class UC_Home : UserControl
    {
        private DashboardController _dashboard = new DashboardController();
        private int currentOffset = 0;

        public UC_Home()
        {
            InitializeComponent();

            dgvRecent.AutoGenerateColumns = false;
        }

        private void UC_Home_Load(object sender, EventArgs e)
        {
            DataGridViewStyle.ApplyModernDesign(dgvRecent);

            if (dgvRecent.Columns.Count >= 4)
            {
                dgvRecent.Columns[0].DataPropertyName = "Patients Name";
                dgvRecent.Columns[1].DataPropertyName = "Chief Complaint";
                dgvRecent.Columns[2].DataPropertyName = "Time of Visit";
                dgvRecent.Columns[3].DataPropertyName = "Outcome";
            }

            RefreshDashboard();
        }

        public void RefreshDashboard()
        {
            lblTotalPatients.Text = _dashboard.GetTotalPatients();
            lblTodaysVisit.Text = _dashboard.GetTodaysVisits();
            lblLowInventory.Text = _dashboard.GetLowInventoryCount();

            DataTable dt = _dashboard.GetRecentConsultations(currentOffset);
            dgvRecent.DataSource = dt;

            int lowItems = 0;
            int.TryParse(lblLowInventory.Text, out lowItems);
            medicineCircle.ValueNumber = (lowItems > 100) ? 100 : lowItems;
        }

       
        private void btnNext_Click(object sender, EventArgs e)
        {
            currentOffset += 5;
            DataTable nextData = _dashboard.GetRecentConsultations(currentOffset);
            if (nextData.Rows.Count > 0) dgvRecent.DataSource = nextData;
            else { currentOffset -= 5; MessageBox.Show("End of records."); }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (currentOffset >= 5)
            {
                currentOffset -= 5;
                dgvRecent.DataSource = _dashboard.GetRecentConsultations(currentOffset);
            }
        }

        private void NewConsultBtn_Click(object sender, EventArgs e)
        {
            if (this.ParentForm is AdminDashboard main) main.addUserControl(new UC_ConsultationWizard());
        }
    }
}