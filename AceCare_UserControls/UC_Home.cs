using AceCareClinicSystem.Controllers;
using AceCareClinicSystem.Forms;
using AceCareClinicSystem.Services;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace AceCareClinicSystem.AceCare_UserControls
{
    public partial class UC_Home : UserControl
    {
        private DashboardController _dashboard = new DashboardController();
        private int currentOffset = 0;
        private int totalRecords = 0;
        private const int PageSize = 10;
        private string _userRole = "Admin";

        public UC_Home()
        {
            InitializeComponent();
            dgvRecent.AutoGenerateColumns = false;
        }

        public UC_Home(string userRole) : this()
        {
            _userRole = userRole;
        }

        private void UC_Home_Load(object sender, EventArgs e)
        {
            DataGridViewStyle.ApplyModernDesign(dgvRecent);
            SetupColumns();
            ConfigureUIBasedOnRole();
            RefreshDashboard();
        }

        private void ConfigureUIBasedOnRole()
        {
            if (_userRole == "Clinic Staff")
            {
                CreateUserBtn.Text = "About";
            }
            else
            {
                CreateUserBtn.Text = "Create User";
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
            lblTotalPatients.Text = _dashboard.GetTotalPatients();
            lblTodaysVisit.Text = _dashboard.GetTodaysVisits();
            lblLowInventory_0.Text = _dashboard.GetLowInventoryCount();

            if (_userRole == "Clinic Staff")
            {
                lblTotalUserTItle.Text = "Expiring Soon";
                lbTotalUser_0.Text = _dashboard.GetExpiringSoonCount();
                ChangeToExpiringSoonIcon();
            }
            else
            {
                lblTotalUserTItle.Text = "Total User";
                lbTotalUser_0.Text = _dashboard.GetTotalUsers();
                ChangeToTotalUserIcon();
            }

            int capacityPercent = _dashboard.GetStockFillPercentage();
            medicineCircle.ValueNumber = capacityPercent;

            if (capacityPercent < 50)
                medicineCircle.ForeColor = Color.Green;
            else if (capacityPercent < 80)
                medicineCircle.ForeColor = Color.Orange;
            else
                medicineCircle.ForeColor = Color.Red;

            DataTable dt = _dashboard.GetRecentConsultations(currentOffset, PageSize, txtSearch.Text.Trim());
            totalRecords = _dashboard.GetTotalConsultations(txtSearch.Text.Trim());

            if (dt.Rows.Count == 0 && currentOffset > 0)
            {
                currentOffset -= PageSize;
                RefreshDashboard();
                return;
            }

            BindingHelper.BindToGrid(dgvRecent, dt);
            UpdatePaginationButtons();
        }

        private void ChangeToExpiringSoonIcon()
        {
            try
            {
                // Suspend layout to prevent flickering
                this.SuspendLayout();

                // Store old image reference for disposal
                Image oldImage = picTotal.Image;

                // Completely clear the picture box
                picTotal.Image = null;
                picTotal.BackgroundImage = null;

                // Dispose old image to free resources and ensure it's gone
                if (oldImage != null)
                {
                    oldImage.Dispose();
                }

                // Force complete visual clear
                picTotal.Invalidate();
                picTotal.Update();
                Application.DoEvents();

                // Set new properties
                picTotal.SizeMode = PictureBoxSizeMode.Zoom;
                picTotal.BackColor = Color.Transparent;

                // Load new calendar icon
                picTotal.Image = Properties.Resources.calendar__2__removebg_preview;

                // Resume and refresh
                this.ResumeLayout(true);
                picTotal.Refresh();
            }
            catch
            {
                picTotal.Image = null;
                picTotal.BackColor = Color.Transparent;
            }
        }

        private void ChangeToTotalUserIcon()
        {
            try
            {
                // Suspend layout to prevent flickering
                this.SuspendLayout();

                // Store old image reference for disposal
                Image oldImage = picTotal.Image;

                // Completely clear the picture box
                picTotal.Image = null;
                picTotal.BackgroundImage = null;

                // Dispose old image to free resources
                if (oldImage != null)
                {
                    oldImage.Dispose();
                }

                // Force complete visual clear
                picTotal.Invalidate();
                picTotal.Update();
                Application.DoEvents();

                // Set new properties
                picTotal.SizeMode = PictureBoxSizeMode.Zoom;
                picTotal.BackColor = Color.Transparent;

                // Load group icon
                picTotal.Image = Properties.Resources.group;

                // Resume and refresh
                this.ResumeLayout(true);
                picTotal.Refresh();
            }
            catch
            {
                picTotal.Image = null;
                picTotal.BackColor = Color.Transparent;
            }

            lblTotalUserTItle.ForeColor = Color.Black;
            lbTotalUser_0.ForeColor = Color.Black;
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

        private void CreateUserBtn_Click(object sender, EventArgs e)
        {
            if (_userRole == "Clinic Staff")
            {
                if (this.ParentForm is ClinicStaffDashboard staffMain)
                    staffMain.addUserControl(new UC_About());
            }
            else
            {
                if (this.ParentForm is AdminDashboard main)
                    main.addUserControl(new UC_UserManagement());
            }
        }
    }
}