using AceCareClinicSystem.Controllers;
using ReaLTaiizor.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AceCareClinicSystem.AceCare_UserControls
{
    public partial class UC_UserManagement : UserControl
    {
        AuthController auth = new AuthController();

        public UC_UserManagement()
        {
            InitializeComponent();
            LoadData(); // Load data on startup
        }

        private void LoadData()
        {
            // Populate Grids
            dgvUserManagemend.DataSource = auth.GetUserList();
            dgvUserManagemend.DataSource = auth.GetAuditLogs();

            // Update Labels
            lblTotalUser0.Text = auth.GetTotalUserCount();
            lblRecentLog0.Text = auth.GetRecentLogCount();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)dgvUserManagemend.DataSource;
            if (dt != null)
                dt.DefaultView.RowFilter = string.Format("full_name LIKE '%{0}%'", txtSearch.Text);
        }

        private void btnSearchAudit_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)dgvAuditLogs.DataSource;
            if (dt != null)
                dt.DefaultView.RowFilter = string.Format("email LIKE '%{0}%' OR action LIKE '%{0}%'", txtSearchAudit.Text);
        }

        // Keep these empty to prevent design errors since they are linked in Designer
        private void panel2_Paint(object sender, PaintEventArgs e) { }
        private void poisonDataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void txtSearch_Click(object sender, EventArgs e) { }
        private void btnAddUser_Click(object sender, EventArgs e) { /* Your Add Logic */ }
        private void btnUpdateUser_Click(object sender, EventArgs e) { /* Your Update Logic */ }
        private void btnDeleteUser_Click(object sender, EventArgs e) { /* Your Delete Logic */ }
        private void lblTotalUser0_Click(object sender, EventArgs e) { }
        private void lblRecentLog0_Click(object sender, EventArgs e) { }
        private void poisonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void txtFilterActivity_Click(object sender, EventArgs e) { }
        private void txtSearchAudit_Click(object sender, EventArgs e) { }
        private void btnClear_Click(object sender, EventArgs e) { }
        private void btnExport_Click(object sender, EventArgs e) { }
    }
}