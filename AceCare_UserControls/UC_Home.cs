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
        private int totalRecords = 0;
        private const int PageSize = 10;
        private string _userRole = "Admin"; // Store role, default to Admin

        // Default constructor for Admin/Designer
        public UC_Home()
        {
            InitializeComponent();
            dgvRecent.AutoGenerateColumns = false;
        }

        // Constructor with role parameter for Clinic Staff
        public UC_Home(string userRole) : this()
        {
            _userRole = userRole;
        }

        private void UC_Home_Load(object sender, EventArgs e)
        {
            DataGridViewStyle.ApplyModernDesign(dgvRecent);
            SetupColumns();
            ConfigureUIBasedOnRole(); // Configure UI based on role
            RefreshDashboard();
        }

        // NEW: Configure UI elements based on user role
        private void ConfigureUIBasedOnRole()
        {
            if (_userRole == "Clinic Staff")
            {
                CreateUserBtn.Text = "About"; // Change to About for Clinic Staff
            }
            else
            {
                CreateUserBtn.Text = "Create User"; // Admin sees original
            }
        }

        private void SetupColumns()
        {
            if (dgvRecent.Columns.Count >= 4)
            {
                dgvRecent.Columns[0].DataPropertyName = "Patients Name";
                dgvRecent.Columns[1].DataPropertyName = "Chief Complaint";
                dgvRecent.Columns[2].DataPropertyName = "Time of Visit";
                dgvRecent.Columns[3].DataPropertyName = "Outcome";
            }
        }

        public void RefreshDashboard()
        {
            // Update Top Stats
            lblTotalPatients.Text = _dashboard.GetTotalPatients();
            lblTodaysVisit.Text = _dashboard.GetTodaysVisits();
            lblLowInventory_0.Text = _dashboard.GetLowInventoryCount();
            lbTotalUser_0.Text = _dashboard.GetTotalUsers();

            // Fetch Table Data
            DataTable dt = _dashboard.GetRecentConsultations(currentOffset, PageSize, txtSearch.Text.Trim());
            totalRecords = _dashboard.GetTotalConsultations(txtSearch.Text.Trim());

            // Pagination Safety
            if (dt.Rows.Count == 0 && currentOffset > 0)
            {
                currentOffset -= PageSize;
                RefreshDashboard();
                return;
            }

            BindingHelper.BindToGrid(dgvRecent, dt);
            UpdatePaginationButtons();

            // Update Medicine Inventory Circle
            int stockPercentage = _dashboard.GetStockFillPercentage();
            medicineCircle.ValueNumber = stockPercentage;
        }

        private void UpdatePaginationButtons()
        {
            btnPrev.Enabled = currentOffset > 0;
            btnNext.Enabled = (currentOffset + PageSize) < totalRecords;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            currentOffset = 0;
            RefreshDashboard();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if ((currentOffset + PageSize) < totalRecords)
            {
                currentOffset += PageSize;
                RefreshDashboard();
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (currentOffset >= PageSize)
            {
                currentOffset -= PageSize;
                RefreshDashboard();
            }
        }

        private void ReloadPix_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            currentOffset = 0;
            RefreshDashboard();
        }

        private void NewConsultBtn_Click(object sender, EventArgs e)
        {
            if (this.ParentForm is AdminDashboard main)
                main.addUserControl(new UC_ConsultationWizard());
            else if (this.ParentForm is ClinicStaffDashboard staffMain)
                staffMain.addUserControl(new UC_ConsultationWizard());
        }

        // MODIFIED: Handle role-based navigation
        private void CreateUserBtn_Click(object sender, EventArgs e)
        {
            if (_userRole == "Clinic Staff")
            {
                // Clinic Staff navigates to About
                if (this.ParentForm is ClinicStaffDashboard staffMain)
                    staffMain.addUserControl(new UC_About());
            }
            else
            {
                // Admin navigates to User Management
                if (this.ParentForm is AdminDashboard main)
                    main.addUserControl(new UC_UserManagement());
            }
        }
    }
}