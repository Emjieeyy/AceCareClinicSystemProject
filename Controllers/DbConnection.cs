using System;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace AceCareClinicSystem.Controllers
{
    public class DbConnection
    {
        // 1. Define the connection string as a variable
        private string connectionString = "server=localhost;database=acecaredb;uid=root;pwd=;";

        // 2. Wrap the connection logic inside a METHOD
        public MySqlConnection GetConnection()
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            try
            {
                // We don't open it here yet, we just return the object
                return conn;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection Error: " + ex.Message);
                return null;
            }
        }
    }
}