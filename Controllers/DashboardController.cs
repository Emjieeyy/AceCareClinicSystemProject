using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace AceCareClinicSystem.Controllers
{
    public class DashboardController
    {
        private DbConnection db = new DbConnection();
        private AuthController _auth = new AuthController();

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

                    // ============================================
                    // FIX: Changed from MySQL CURDATE() to C# DateTime.Today
                    // to fix timezone mismatch causing 0 results
                    // ============================================

                    // OLD CODE (commented out):
                    // string query = @"SELECT COUNT(*) FROM consultations c
                    //                 INNER JOIN patients p ON c.patient_id = p.patient_id
                    //                 WHERE DATE(c.visit_date) = CURDATE()";
                    // return new MySqlCommand(query, conn).ExecuteScalar()?.ToString() ?? "0";

                    // NEW CODE:
                    // Use C# DateTime.Today to match local system date instead of MySQL server date
                    DateTime today = DateTime.Today;
                    DateTime tomorrow = today.AddDays(1);

                    // Use date range comparison to handle time components in visit_date
                    // Removed unnecessary JOIN to patients table since we only need count
                    string query = @"SELECT COUNT(*) FROM consultations 
                                    WHERE visit_date >= @today AND visit_date < @tomorrow";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        // Use parameterized query for safety
                        cmd.Parameters.AddWithValue("@today", today);
                        cmd.Parameters.AddWithValue("@tomorrow", tomorrow);

                        return cmd.ExecuteScalar()?.ToString() ?? "0";
                    }
                }
            }
            catch { return "0"; }
        }

        // LOW INVENTORY - from inventory table
        public string GetLowInventoryCount()
        {
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM inventory WHERE Quantity < 10";
                    return new MySqlCommand(query, conn).ExecuteScalar()?.ToString() ?? "0";
                }
            }
            catch { return "0"; }
        }

        // TOTAL USERS - from AuthController
        public string GetTotalUsers()
        {
            try
            {
                return _auth.GetTotalUserCount();
            }
            catch { return "0"; }
        }

        // CIRCLE - total items in inventory (shows 47)
        public int GetStockFillPercentage()
        {
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM inventory";
                    int totalItems = Convert.ToInt32(new MySqlCommand(query, conn).ExecuteScalar());
                    return totalItems > 100 ? 100 : totalItems;
                }
            }
            catch { return 0; }
        }

        public string GetTotalSupplies()
        {
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT COALESCE(SUM(Quantity), 0) FROM inventory";
                    object? res = new MySqlCommand(query, conn).ExecuteScalar();
                    return res?.ToString() ?? "0";
                }
            }
            catch { return "0"; }
        }
    }
}