using System;
using System.Data;
using MySql.Data.MySqlClient;
using AceCareClinicSystem.Services;

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
                using (MySqlConnection? conn = db.GetConnection())
                {
                    if (conn == null) return false;
                    conn.Open();
                    string query = @"SELECT u.user_id, u.username, u.full_name, r.role_name 
                                   FROM users u 
                                   INNER JOIN roles r ON u.role_id = r.role_id 
                                   WHERE u.username = @user AND u.password = @pass AND u.status = 'Active'";
                    
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@user", username);
                        cmd.Parameters.AddWithValue("@pass", password);
                        
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                UserSession.UserId = reader.GetInt32("user_id");
                                UserSession.Username = reader.GetString("username");
                                UserSession.FullName = reader.GetString("full_name");
                                UserSession.Role = reader.GetString("role_name");
                                
                                reader.Close();
                                LogActivity(UserSession.UserId, "Login", "User logged into the system");
                                return true;
                            }
                        }
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Login Error: " + ex.Message);
                return false;
            }
        }

        // ------------------- USER MANAGEMENT -------------------
        public DataTable GetUserList()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = db.GetConnection())
            {
                // Including username and role_id for easier management
                string query = @"
                    SELECT u.user_id, u.username, u.full_name, r.role_name, u.role_id, u.email, u.status
                    FROM users u
                    INNER JOIN roles r ON u.role_id = r.role_id";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                adapter.Fill(dt);
            }
            return dt;
        }

        public bool AddUser(string username, string password, string fullName, string email, int roleId, string status)
        {
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string query = @"INSERT INTO users (username, password, full_name, email, role_id, status) 
                                   VALUES (@user, @pass, @name, @email, @role, @status)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@user", username);
                        cmd.Parameters.AddWithValue("@pass", password);
                        cmd.Parameters.AddWithValue("@name", fullName);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@role", roleId);
                        cmd.Parameters.AddWithValue("@status", status);
                        
                        bool success = cmd.ExecuteNonQuery() > 0;
                        if (success) LogActivity(0, "User Created", $"Created user: {username}"); // 0 as placeholder for current user id
                        return success;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Add User Error: " + ex.Message);
                return false;
            }
        }

        public bool UpdateUser(int userId, string username, string password, string fullName, string email, int roleId, string status)
        {
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    // Update password only if provided
                    string passClause = !string.IsNullOrEmpty(password) ? ", password = @pass" : "";
                    string query = $@"UPDATE users SET username = @user, full_name = @name, 
                                     email = @email, role_id = @role, status = @status {passClause} 
                                     WHERE user_id = @id";
                    
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", userId);
                        cmd.Parameters.AddWithValue("@user", username);
                        cmd.Parameters.AddWithValue("@name", fullName);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@role", roleId);
                        cmd.Parameters.AddWithValue("@status", status);
                        if (!string.IsNullOrEmpty(password)) cmd.Parameters.AddWithValue("@pass", password);
                        
                        bool success = cmd.ExecuteNonQuery() > 0;
                        if (success) LogActivity(0, "User Updated", $"Updated user: {username}");
                        return success;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Update User Error: " + ex.Message);
                return false;
            }
        }

        public bool DeleteUser(int userId)
        {
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string query = "DELETE FROM users WHERE user_id = @id";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", userId);
                        bool success = cmd.ExecuteNonQuery() > 0;
                        if (success) LogActivity(0, "User Deleted", $"Deleted user ID: {userId}");
                        return success;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Delete User Error: " + ex.Message);
                return false;
            }
        }

        public DataTable GetRolesDataTable()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = db.GetConnection())
            {
                string query = "SELECT role_id, role_name FROM roles";
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
        public void LogActivity(int userId, string activity, string description)
        {
            try
            {
                using (MySqlConnection? conn = db.GetConnection())
                {
                    conn.Open();
                    string query = "INSERT INTO audit_logs (user_id, activity, description) VALUES (@uid, @act, @desc)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        // Use current session ID if 0 is passed
                        int idToLog = userId == 0 ? UserSession.UserId : userId;
                        cmd.Parameters.AddWithValue("@uid", idToLog == 0 ? (object)DBNull.Value : idToLog);
                        cmd.Parameters.AddWithValue("@act", activity);
                        cmd.Parameters.AddWithValue("@desc", description);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch { /* Ignore logging errors to prevent crash */ }
        }

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