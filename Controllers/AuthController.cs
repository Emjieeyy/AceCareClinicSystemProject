using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace AceCareClinicSystem.Controllers
{
    public class AuthController
    {
        private DbConnection db = new DbConnection();

        // ------------------- LOGIN -------------------
        public bool ValidateLogin(string username, string password)
        {
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM users WHERE username = @user AND password = @pass AND status = 'Active'";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@user", username);
                        cmd.Parameters.AddWithValue("@pass", password);
                        return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        // ------------------- USER MANAGEMENT -------------------
        public DataTable GetUserList()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = db.GetConnection())
            {
                string query = @"
                    SELECT u.user_id, u.full_name, r.role_name, u.email, u.status
                    FROM users u
                    INNER JOIN roles r ON u.role_id = r.role_id";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                adapter.Fill(dt);
            }
            return dt;
        }

        public string GetTotalUserCount()
        {
            using (MySqlConnection conn = db.GetConnection())
            {
                conn.Open();
                return new MySqlCommand("SELECT COUNT(*) FROM users", conn).ExecuteScalar().ToString();
            }
        }

        // ------------------- AUDIT LOGS -------------------
        public DataTable GetAuditLogs()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = db.GetConnection())
            {
                string query = @"
                    SELECT a.timestamp, u.email, a.activity, a.description
                    FROM audit_logs a
                    LEFT JOIN users u ON a.user_id = u.user_id
                    ORDER BY a.timestamp DESC";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                adapter.Fill(dt);
            }
            return dt;
        }

        public string GetRecentLogCount()
        {
            using (MySqlConnection conn = db.GetConnection())
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM audit_logs WHERE DATE(timestamp) = CURDATE()";
                return new MySqlCommand(query, conn).ExecuteScalar().ToString();
            }
        }
    }
}