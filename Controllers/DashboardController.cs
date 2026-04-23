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

        public string GetExpiringSoonCount()
        {
            try
            {
                var stats = _inventory.GetDashboardStats();
                return stats.exp;
            }
            catch { return "0"; }
        }

        public string GetLowInventoryCount()
        {
            try
            {
                var stats = _inventory.GetDashboardStats();
                return stats.low;
            }
            catch { return "0"; }
        }

        public string GetTotalUsers()
        {
            try
            {
                return _auth.GetTotalUserCount();
            }
            catch { return "0"; }
        }

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

        public int GetStockFillPercentage()
        {
            try
            {
                var stats = _inventory.GetDashboardStats();
                int currentStock = int.Parse(stats.med) + int.Parse(stats.sup);
                int maxCapacity = 200;
                int percentage = (int)((currentStock / (double)maxCapacity) * 100);
                return percentage > 100 ? 100 : percentage;
            }
            catch { return 0; }
        }

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
        // FIXED: Separate Age and Sex columns
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
                            c.patient_id AS PatientId,
                            CONCAT(COALESCE(p.first_name, ''), ' ', COALESCE(p.last_name, '')) AS 'Patients Name', 
                            COALESCE(p.age, '') AS Age,
                            COALESCE(p.sex, '') AS Sex,
                            c.chief_complaint AS 'Chief Complaint', 
                            c.visit_date AS 'Time of Visit', 
                            c.outcome AS 'Outcome',
                            c.visit_type AS VisitType,
                            CONCAT('T:', COALESCE(c.temperature, ''), ' BP:', COALESCE(c.blood_pressure, ''), ' PR:', COALESCE(c.pulse_rate, '')) AS Vitals,
                            c.symptoms_description AS Diagnosis,
                            c.medicine_name AS Medicine,
                            COALESCE(u.full_name, c.clinic_incharge) AS HandledBy
                         FROM consultations c 
                         INNER JOIN patients p ON c.patient_id = p.patient_id 
                         LEFT JOIN users u ON c.handled_by_user_id = u.user_id
                         ORDER BY c.visit_date DESC 
                         LIMIT @pageSize OFFSET @offset";
                    }
                    else
                    {
                        query = @"SELECT 
                            c.patient_id AS PatientId,
                            CONCAT(COALESCE(p.first_name, ''), ' ', COALESCE(p.last_name, '')) AS 'Patients Name', 
                            COALESCE(p.age, '') AS Age,
                            COALESCE(p.sex, '') AS Sex,
                            c.chief_complaint AS 'Chief Complaint', 
                            c.visit_date AS 'Time of Visit', 
                            c.outcome AS 'Outcome',
                            c.visit_type AS VisitType,
                            CONCAT('T:', COALESCE(c.temperature, ''), ' BP:', COALESCE(c.blood_pressure, ''), ' PR:', COALESCE(c.pulse_rate, '')) AS Vitals,
                            c.symptoms_description AS Diagnosis,
                            c.medicine_name AS Medicine,
                            COALESCE(u.full_name, c.clinic_incharge) AS HandledBy
                         FROM consultations c 
                         INNER JOIN patients p ON c.patient_id = p.patient_id 
                         LEFT JOIN users u ON c.handled_by_user_id = u.user_id
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