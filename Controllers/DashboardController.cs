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
        private InventoryController _inventory = new InventoryController();

        // ============================================
        // Get Expiring Soon Count
        // ============================================
        public string GetExpiringSoonCount()
        {
            try
            {
                var stats = _inventory.GetDashboardStats();
                return stats.exp;
            }
            catch { return "0"; }
        }

        // ============================================
        // Get Low Inventory Count
        // ============================================
        public string GetLowInventoryCount()
        {
            try
            {
                var stats = _inventory.GetDashboardStats();
                return stats.low;
            }
            catch { return "0"; }
        }

        // ============================================
        // Get Total Users (for Admin)
        // ============================================
        public string GetTotalUsers()
        {
            try
            {
                return _auth.GetTotalUserCount();
            }
            catch { return "0"; }
        }

        // ============================================
        // Get Total Patients
        // ============================================
        public string GetTotalPatients()
        {
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    return new MySqlCommand("SELECT COUNT(*) FROM patients", conn)
                        .ExecuteScalar()?.ToString() ?? "0";
                }
            }
            catch { return "0"; }
        }

        // ============================================
        // Get Today's Visits
        // ============================================
        public string GetTodaysVisits()
        {
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    DateTime today = DateTime.Today;
                    DateTime tomorrow = today.AddDays(1);

                    string query = @"SELECT COUNT(*) FROM consultations 
                                    WHERE visit_date >= @today AND visit_date < @tomorrow";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@today", today);
                        cmd.Parameters.AddWithValue("@tomorrow", tomorrow);
                        return cmd.ExecuteScalar()?.ToString() ?? "0";
                    }
                }
            }
            catch { return "0"; }
        }

        // ============================================
        // CAPACITY PERCENTAGE (NEW)
        // ============================================
        public int GetStockFillPercentage()
        {
            try
            {
                var stats = _inventory.GetDashboardStats();
                int currentStock = int.Parse(stats.med) + int.Parse(stats.sup); // 119 + 19 = 138

                int maxCapacity = 200; // ADJUST THIS to your clinic's max capacity!

                int percentage = (int)((currentStock / (double)maxCapacity) * 100);
                return percentage > 100 ? 100 : percentage;
            }
            catch { return 0; }
        }

        // ============================================
        // Get Total Supplies (for Reports)
        // ============================================
        public string GetTotalSupplies()
        {
            try
            {
                var stats = _inventory.GetDashboardStats();
                return stats.sup;
            }
            catch { return "0"; }
        }

        // ============================================
        // Get Recent Consultations Table
        // ============================================
        public DataTable GetRecentConsultations(int offset, int pageSize = 10, string searchTerm = "")
        {
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    string query;
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
                    }

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@pageSize", pageSize);
                        cmd.Parameters.AddWithValue("@offset", offset);

                        if (!string.IsNullOrEmpty(searchTerm))
                            cmd.Parameters.AddWithValue("@search", "%" + searchTerm + "%");

                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading consultations: " + ex.Message);
            }
            return dt;
        }

        // ============================================
        // Get Total Consultations Count
        // ============================================
        public int GetTotalConsultations(string searchTerm = "")
        {
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string query = string.IsNullOrEmpty(searchTerm)
                        ? @"SELECT COUNT(*) FROM consultations"
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
    }
}