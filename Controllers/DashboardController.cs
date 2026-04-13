using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace AceCareClinicSystem.Controllers
{
    public class DashboardController
    {
        private DbConnection db = new DbConnection();

        public DataTable GetRecentConsultations(int offset, int pageSize = 10, string searchTerm = "")
        {
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    string query;
                    using (MySqlCommand cmd = new MySqlCommand("", conn))
                    {
                        if (string.IsNullOrEmpty(searchTerm))
                        {
                            query = @"SELECT 
                                CONCAT(COALESCE(p.first_name, ''), ' ', COALESCE(p.last_name, '')) AS 'Patients Name', 
                                c.chief_complaint AS 'Chief Complaint', 
                                DATE_FORMAT(c.visit_date, '%h:%i:%s %p') AS 'Time of Visit', 
                                c.outcome AS 'Outcome' 
                             FROM consultations c 
                             INNER JOIN patients p ON c.patient_id = p.patient_id 
                             ORDER BY c.visit_date DESC 
                             LIMIT @pageSize OFFSET @offset";
                        }
                        else
                        {
                            query = @"SELECT 
                                CONCAT(COALESCE(p.first_name, ''), ' ', COALESCE(p.last_name, '')) AS 'Patients Name', 
                                c.chief_complaint AS 'Chief Complaint', 
                                DATE_FORMAT(c.visit_date, '%h:%i:%s %p') AS 'Time of Visit', 
                                c.outcome AS 'Outcome' 
                             FROM consultations c 
                             INNER JOIN patients p ON c.patient_id = p.patient_id 
                             WHERE CONCAT(COALESCE(p.first_name, ''), ' ', COALESCE(p.last_name, '')) LIKE @search 
                                OR c.chief_complaint LIKE @search
                                OR p.patient_number LIKE @search
                             ORDER BY c.visit_date DESC 
                             LIMIT @pageSize OFFSET @offset";
                            cmd.Parameters.AddWithValue("@search", "%" + searchTerm + "%");
                        }

                        cmd.CommandText = query;
                        cmd.Parameters.AddWithValue("@pageSize", pageSize);
                        cmd.Parameters.AddWithValue("@offset", offset);

                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Controller Error: " + ex.Message);
            }
            return dt;
        }

        public int GetTotalConsultations(string searchTerm = "")
        {
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string query = string.IsNullOrEmpty(searchTerm)
                        ? @"SELECT COUNT(*) FROM consultations c 
                            INNER JOIN patients p ON c.patient_id = p.patient_id"
                        : @"SELECT COUNT(*) FROM consultations c 
                            INNER JOIN patients p ON c.patient_id = p.patient_id 
                            WHERE CONCAT(COALESCE(p.first_name, ''), ' ', COALESCE(p.last_name, '')) LIKE @search 
                               OR c.chief_complaint LIKE @search
                               OR p.patient_number LIKE @search";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        if (!string.IsNullOrEmpty(searchTerm))
                            cmd.Parameters.AddWithValue("@search", "%" + searchTerm + "%");

                        return Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
            }
            catch { return 0; }
        }

        public string GetTotalPatients()
        {
            using (MySqlConnection conn = db.GetConnection())
            {
                conn.Open();
                return new MySqlCommand("SELECT COUNT(*) FROM patients", conn).ExecuteScalar()?.ToString() ?? "0";
            }
        }

        public string GetTodaysVisits()
        {
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT COUNT(*) FROM consultations c
                                    INNER JOIN patients p ON c.patient_id = p.patient_id
                                    WHERE DATE(c.visit_date) = CURDATE()";
                    return new MySqlCommand(query, conn).ExecuteScalar()?.ToString() ?? "0";
                }
            }
            catch { return "0"; }
        }

        public string GetLowInventoryCount()
        {
            using (MySqlConnection conn = db.GetConnection())
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM medicines WHERE stock_quantity < 10";
                return new MySqlCommand(query, conn).ExecuteScalar()?.ToString() ?? "0";
            }
        }
    }
}