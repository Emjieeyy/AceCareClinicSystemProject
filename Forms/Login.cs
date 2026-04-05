using System;
using System.Windows.Forms;
using AceCareClinicSystem.Controllers; // Step 1: Add this!

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
            AuthController auth = new AuthController();

            if (auth.ValidateLogin(txtUser.Text, txtPass.Text))
            {
               
                this.Hide();

                AdminDashboard adminHome = new AdminDashboard();
                adminHome.Show();
                
            }
            else
            {
                MessageBox.Show("Invalid Username or Password.", "AceCare Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } 

        private void showPassCB_CheckedChanged(object sender, EventArgs e)
        {
           
            txtPass.UseSystemPasswordChar = !showPassCB.Checked;
        }
    } 
}