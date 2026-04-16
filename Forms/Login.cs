using System;
using System.Windows.Forms;
using AceCareClinicSystem.Controllers;
using AceCareClinicSystem.Services; // Ensure this is where your UserSession class lives

namespace AceCareClinicSystem.Forms
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            // 1. Basic Validation: Don't even hit the DB if fields are empty
            if (string.IsNullOrWhiteSpace(txtUser.Text) || string.IsNullOrWhiteSpace(txtPass.Text))
            {
                MessageBox.Show("Please enter both username and password.", "AceCare Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            AuthController auth = new AuthController();

            // 2. Attempt Authentication
            // Your AuthController already checks for 'Active' status and populates UserSession.Role
            if (auth.ValidateLogin(txtUser.Text, txtPass.Text))
            {
                this.Hide();

                // 3. Role-Based Navigation
                // These strings must match your 'role_name' column in the 'roles' table exactly.
                if (UserSession.Role == "Admin")
                {
                    AdminDashboard adminHome = new AdminDashboard();
                    adminHome.Show();
                }
                else if (UserSession.Role == "Clinic Staff")
                {
                    // This opens your newly created Staff Dashboard
                    ClinicStaffDashboard staffHome = new ClinicStaffDashboard();
                    staffHome.Show();
                }
                else
                {
                    // Safety check for roles you haven't mapped yet
                    MessageBox.Show($"Login successful, but no dashboard is assigned to the role: '{UserSession.Role}'.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    this.Show();
                }
            }
            else
            {
                // 4. Failure Logic
                // If login fails, it's either wrong credentials or status is not 'Active'
                MessageBox.Show("Invalid Username or Password.\n\nNote: Ensure your account status is set to 'Active' in the database.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void showPassCB_CheckedChanged(object sender, EventArgs e)
        {
            // Toggle the visibility of the password characters
            txtPass.UseSystemPasswordChar = !showPassCB.Checked;
        }

        // Optional: Pressing 'Enter' on the password field triggers the login
        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoginBtn_Click(sender, e);
            }
        }
    }
}