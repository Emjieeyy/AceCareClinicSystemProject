using AceCareClinicSystem.Controllers;
using AceCareClinicSystem.Forms;
using AceCareClinicSystem.Services; // UserSession is here
using ReaLTaiizor.Controls;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AceCareClinicSystem.AceCare_UserControls
{
    public partial class UC_UserManagement : UserControl
    {
        AuthController auth = new AuthController();
        private string _currentUserEmail = "admin@acestagum.edu.ph";
        private string _currentUserRole = "Admin";

        public UC_UserManagement()
        {
            InitializeComponent();
            LoadData();
        }

        public UC_UserManagement(string userEmail, string userRole) : this()
        {
            _currentUserEmail = userEmail;
            _currentUserRole = userRole;
        }

        private void LoadData()
        {
            try
            {
                dgvUserManagemend.DataSource = auth.GetUserList();
                dgvAuditLogs.DataSource = auth.GetAuditLogs();
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
                string[] possibleColumnNames = { "user_id", "User ID", "UserID", "ID", "id", "userId" };

                foreach (string colName in possibleColumnNames)
                {
                    if (dgvUserManagemend.Columns.Contains(colName))
                    {
                        return Convert.ToInt32(dgvUserManagemend.SelectedRows[0].Cells[colName].Value);
                    }
                }

                return Convert.ToInt32(dgvUserManagemend.SelectedRows[0].Cells[0].Value);
            }
            return -1;
        }

        private void btnRefresh1_Click(object sender, EventArgs e)
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
                // Check if trying to delete self using UserSession
                if (UserSession.UserId > 0 && id == UserSession.UserId)
                {
                    MessageBox.Show("You cannot delete your own account.", "Action Not Allowed",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult res = MessageBox.Show("Are you sure you want to delete this user?\n\n" +
                    "This will also delete all associated audit logs for this user.",
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (res == DialogResult.Yes)
                {
                    if (auth.DeleteUser(id))
                    {
                        MessageBox.Show("User deleted successfully.", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a user to delete.", "Selection Required");
            }
        }

        private void Clearbtn_Click(object sender, EventArgs e)
        {
            // Check role from UserSession first, fallback to constructor parameter
            string userRole = !string.IsNullOrEmpty(UserSession.Role) ? UserSession.Role : _currentUserRole;

            if (userRole != "Admin")
            {
                MessageBox.Show("Only Administrators can clear audit logs.", "Access Denied",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (Form prompt = new Form())
            {
                prompt.Width = 420;
                prompt.Height = 240;
                prompt.Text = "Clear Old Audit Logs";
                prompt.StartPosition = FormStartPosition.CenterParent;
                prompt.FormBorderStyle = FormBorderStyle.FixedDialog;
                prompt.MaximizeBox = false;
                prompt.MinimizeBox = false;

                Label lbl = new Label()
                {
                    Left = 20,
                    Top = 20,
                    Width = 370,
                    Text = "Delete audit logs older than (days):",
                    Font = new Font("Segoe UI", 10)
                };

                NumericUpDown numDays = new NumericUpDown()
                {
                    Left = 20,
                    Top = 50,
                    Width = 100,
                    Value = 30,
                    Minimum = 1,
                    Maximum = 365,
                    Font = new Font("Segoe UI", 10)
                };

                Label lblWarning = new Label()
                {
                    Left = 20,
                    Top = 85,
                    Width = 370,
                    Text = "⚠️ This action cannot be undone!",
                    ForeColor = Color.Red,
                    Font = new Font("Segoe UI", 9, FontStyle.Bold)
                };

                System.Windows.Forms.Button btnConfirm = new System.Windows.Forms.Button()
                {
                    Text = "Clear Logs",
                    Left = 210,
                    Top = 140,
                    Width = 90,
                    Height = 32,
                    DialogResult = DialogResult.OK,
                    BackColor = Color.IndianRed,
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 9, FontStyle.Bold),
                    FlatStyle = FlatStyle.Flat
                };

                System.Windows.Forms.Button btnCancel = new System.Windows.Forms.Button()
                {
                    Text = "Cancel",
                    Left = 310,
                    Top = 140,
                    Width = 80,
                    Height = 32,
                    DialogResult = DialogResult.Cancel,
                    Font = new Font("Segoe UI", 9)
                };

                prompt.Controls.Add(lbl);
                prompt.Controls.Add(numDays);
                prompt.Controls.Add(lblWarning);
                prompt.Controls.Add(btnConfirm);
                prompt.Controls.Add(btnCancel);
                prompt.AcceptButton = btnConfirm;
                prompt.CancelButton = btnCancel;

                if (prompt.ShowDialog() == DialogResult.OK)
                {
                    int daysToKeep = (int)numDays.Value;
                    ClearOldLogs(daysToKeep);
                }
            }
        }

        private void ClearOldLogs(int daysToKeep)
        {
            try
            {
                int deletedCount = ClearOldAuditLogs(daysToKeep);

                MessageBox.Show($"Successfully cleared {deletedCount} audit log entries older than {daysToKeep} days.",
                    "Logs Cleared", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error clearing logs: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int ClearOldAuditLogs(int daysToKeep)
        {
            int count = 0;
            DateTime cutoffDate = DateTime.Now.AddDays(-daysToKeep);

            using (MySqlConnection conn = new DbConnection().GetConnection())
            {
                conn.Open();

                using (MySqlCommand countCmd = new MySqlCommand(
                    "SELECT COUNT(*) FROM audit_logs WHERE timestamp < @cutoff", conn))
                {
                    countCmd.Parameters.AddWithValue("@cutoff", cutoffDate);
                    count = Convert.ToInt32(countCmd.ExecuteScalar());
                }

                using (MySqlCommand deleteCmd = new MySqlCommand(
                    "DELETE FROM audit_logs WHERE timestamp < @cutoff", conn))
                {
                    deleteCmd.Parameters.AddWithValue("@cutoff", cutoffDate);
                    deleteCmd.ExecuteNonQuery();
                }
            }

            return count;
        }

        private void btnExport_Click_1(object sender, EventArgs e)
        {
            try
            {
                DataTable logs = auth.GetAuditLogs();
                if (logs == null || logs.Rows.Count == 0)
                {
                    MessageBox.Show("No logs to export.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "CSV Files (*.csv)|*.csv";
                    sfd.FileName = $"AuditLogs_{DateTime.Now:yyyyMMdd_HHmm}.csv";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        StringBuilder sb = new StringBuilder();

                        string[] columnNames = new string[logs.Columns.Count];
                        for (int i = 0; i < logs.Columns.Count; i++)
                        {
                            columnNames[i] = logs.Columns[i].ColumnName;
                        }
                        sb.AppendLine(string.Join(",", columnNames));

                        foreach (DataRow row in logs.Rows)
                        {
                            string[] cells = new string[logs.Columns.Count];
                            for (int i = 0; i < logs.Columns.Count; i++)
                            {
                                cells[i] = EscapeCsv(row[i]?.ToString() ?? "");
                            }
                            sb.AppendLine(string.Join(",", cells));
                        }

                        File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                        MessageBox.Show("Logs exported successfully!", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Export failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string EscapeCsv(string value)
        {
            if (string.IsNullOrEmpty(value)) return "\"\"";
            if (value.Contains(",") || value.Contains("\"") || value.Contains("\n") || value.Contains("\r"))
            {
                return "\"" + value.Replace("\"", "\"\"") + "\"";
            }
            return value;
        }

        // Empty methods for designer
        private void panel2_Paint(object sender, PaintEventArgs e) { }
        private void poisonDataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void txtSearch_Click(object sender, EventArgs e) { }
        private void lblTotalUser0_Click(object sender, EventArgs e) { }
        private void lblRecentLog0_Click(object sender, EventArgs e) { }
        private void poisonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void txtFilterActivity_Click(object sender, EventArgs e) { }
        private void txtSearchAudit_Click(object sender, EventArgs e) { }
        private void pictureBox2_Click(object sender, EventArgs e) { }
        private void dgvUserManagemend_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void dgvAuditLogs_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}