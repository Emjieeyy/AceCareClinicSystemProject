using System.ComponentModel;
using System.Data;
using AceCareClinicSystem.Controllers;

namespace AceCareClinicSystem.Forms
{
    public partial class FormUserAddEdit : Form
    {
        private AuthController auth = new AuthController();
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int UserId { get; set; } = -1; // -1 means Add Mode

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsSuccess { get; private set; } = false;

        public FormUserAddEdit()
        {
            InitializeComponent();
            LoadRoles();
            cmbStatus.SelectedIndex = 0; // Default to Active
        }

        private void LoadRoles()
        {
            DataTable dt = auth.GetRolesDataTable();
            cmbRole.DataSource = dt;
            cmbRole.DisplayMember = "role_name";
            cmbRole.ValueMember = "role_id";
        }

        public void SetUserData(DataRow row)
        {
            UserId = Convert.ToInt32(row["user_id"]);
            txtUsername.Text = row["username"].ToString();
            txtFullName.Text = row["full_name"].ToString();
            txtEmail.Text = row["email"].ToString();
            cmbRole.SelectedValue = row["role_id"];
            cmbStatus.SelectedItem = row["status"].ToString();
            
            lblTitle.Text = "Update User";
            btnSave.Text = "Update";
            txtPassword.PlaceholderText = "(Leave blank to keep current)";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Username and Full Name are required.", "Validation Error");
                return;
            }

            if (UserId == -1 && string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Password is required for new users.", "Validation Error");
                return;
            }

            int roleId = cmbRole.SelectedValue != null ? (int)cmbRole.SelectedValue : 0;
            string status = cmbStatus.SelectedItem != null ? cmbStatus.SelectedItem.ToString() : "Active";

            bool success;
            if (UserId == -1)
            {
                success = auth.AddUser(
                    txtUsername.Text,
                    txtPassword.Text,
                    txtFullName.Text,
                    txtEmail.Text,
                    roleId,
                    status
                );
            }
            else
            {
                success = auth.UpdateUser(
                    UserId,
                    txtUsername.Text,
                    txtPassword.Text,
                    txtFullName.Text,
                    txtEmail.Text,
                    roleId,
                    status
                );
            }

            if (success)
            {
                IsSuccess = true;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
