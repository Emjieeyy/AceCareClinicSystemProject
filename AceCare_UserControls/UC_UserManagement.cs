using AceCareClinicSystem.Controllers;
using AceCareClinicSystem.Forms;
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
            try
            {
                // Populate Grids correctly
                dgvUserManagemend.DataSource = auth.GetUserList();
                dgvAuditLogs.DataSource = auth.GetAuditLogs();

                // Update Labels
                lblTotalUser0.Text = auth.GetTotalUserCount();
                lblRecentLog0.Text = auth.GetRecentLogCount();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        private int GetSelectedUserId()
        {
            if (dgvUserManagemend.SelectedRows.Count > 0)
            {
                return Convert.ToInt32(dgvUserManagemend.SelectedRows[0].Cells["ID"].Value);
            }
            return -1;
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
                dt.DefaultView.RowFilter = string.Format("email LIKE '%{0}%' OR activity LIKE '%{0}%'", txtSearchAudit.Text);
        }

        // Keep these empty to prevent design errors since they are linked in Designer
        private void panel2_Paint(object sender, PaintEventArgs e) { }
        private void poisonDataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void txtSearch_Click(object sender, EventArgs e) { }
        
        private void btnAddUser_Click(object sender, EventArgs e) 
        {
            FormUserAddEdit form = new FormUserAddEdit();
            form.ShowDialog();
            if (form.IsSuccess) LoadData();
        }

        private void btnUpdateUser_Click(object sender, EventArgs e) 
        {
            if (dgvUserManagemend.SelectedRows.Count > 0)
            {
                DataRow selectedRow = ((DataRowView)dgvUserManagemend.SelectedRows[0].DataBoundItem).Row;
                FormUserAddEdit form = new FormUserAddEdit();
                form.SetUserData(selectedRow);
                form.ShowDialog();
                if (form.IsSuccess) LoadData();
            }
            else
            {
                MessageBox.Show("Please select a user to update.", "Selection Required");
            }
        }

        private void btnDeleteUser_Click(object sender, EventArgs e) 
        {
            int id = GetSelectedUserId();
            if (id != -1)
            {
                DialogResult res = MessageBox.Show("Are you sure you want to delete this user?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (res == DialogResult.Yes)
                {
                    if (auth.DeleteUser(id))
                    {
                        LoadData();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a user to delete.", "Selection Required");
            }
        }

        private void lblTotalUser0_Click(object sender, EventArgs e) { }
        private void lblRecentLog0_Click(object sender, EventArgs e) { }
        private void poisonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void txtFilterActivity_Click(object sender, EventArgs e) { }
        private void txtSearchAudit_Click(object sender, EventArgs e) { }
        private void btnClear_Click(object sender, EventArgs e) { }
        private void btnExport_Click(object sender, EventArgs e) { }
    }
}