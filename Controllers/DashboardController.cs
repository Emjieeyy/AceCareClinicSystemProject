using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace AceCareClinicSystem.Controllers
{
    public class DashboardController
    {
        // Use your existing DbConnection class
        private DbConnection db = new DbConnection();

        // Fetches the most recent 5 consultations joined with Patient names
        public DataTable GetRecentConsultations(int offset = 0)
        {
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    // Fixed the column names here to match your logic
                    string query = @"SELECT 
                        CONCAT(p.first_name, ' ', p.last_name) AS 'Patients Name', 
                        c.chief_complaint AS 'Chief Complaint', 
                        DATE_FORMAT(c.visit_date, '%h:%i:%s %p') AS 'Time of Visit', 
                        c.outcome AS 'Outcome' 
                     FROM consultations c 
                     JOIN patients p ON c.patient_id = p.patient_id 
                     ORDER BY c.visit_date DESC 
                     LIMIT 5 OFFSET @offset";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@offset", offset);
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Controller Error: " + ex.Message);
            }
            return dt;
        }

        public string GetTotalPatients()
        {
            using (MySqlConnection conn = db.GetConnection())
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM patients";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                return cmd.ExecuteScalar().ToString();
            }
        }

        public string GetTodaysVisits()
        {
            using (MySqlConnection conn = db.GetConnection())
            {
                conn.Open();
                // Now using the 'visit_date' we just created
                string query = "SELECT COUNT(*) FROM consultations WHERE DATE(visit_date) = CURDATE()";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    return cmd.ExecuteScalar()?.ToString() ?? "0";
                }
            }
        }

        public string GetLowInventoryCount()
        {
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM medicines WHERE stock_quantity < 10";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    return cmd.ExecuteScalar().ToString();
                }
            }
            catch { return "0"; }
        }
    }
}