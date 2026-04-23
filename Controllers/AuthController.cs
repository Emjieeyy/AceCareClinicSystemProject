using System;
using System.Data;
using MySql.Data.MySqlClient;
using AceCareClinicSystem.Services;

namespace AceCareClinicSystem.Controllers
{
    public class AuthController
    {
        private DbConnection db = new DbConnection();

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
                                UserSession.IsLoggedIn = true;  // <-- CHANGED: Added this line

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

        // ============================================
        // ALL OTHER METHODS UNCHANGED BELOW
        // ============================================

        public DataTable GetUserList()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = db.GetConnection())
            {
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
                        if (success) LogActivity(0, "User Created", $"Created user: {username}");
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

                    using (var transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            string deleteLogsQuery = "DELETE FROM audit_logs WHERE user_id = @id";
                            using (MySqlCommand deleteLogsCmd = new MySqlCommand(deleteLogsQuery, conn, transaction))
                            {
                                deleteLogsCmd.Parameters.AddWithValue("@id", userId);
                                deleteLogsCmd.ExecuteNonQuery();
                            }

                            string deleteUserQuery = "DELETE FROM users WHERE user_id = @id";
                            using (MySqlCommand deleteUserCmd = new MySqlCommand(deleteUserQuery, conn, transaction))
                            {
                                deleteUserCmd.Parameters.AddWithValue("@id", userId);
                                int rowsAffected = deleteUserCmd.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    transaction.Commit();
                                    LogActivity(0, "User Deleted", $"Deleted user ID: {userId}");
                                    return true;
                                }
                                else
                                {
                                    transaction.Rollback();
                                    return false;
                                }
                            }
                        }
                        catch (Exception)
                        {
                            transaction.Rollback();
                            throw;
                        }
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
                        int idToLog = userId == 0 ? UserSession.UserId : userId;
                        cmd.Parameters.AddWithValue("@uid", idToLog == 0 ? (object)DBNull.Value : idToLog);
                        cmd.Parameters.AddWithValue("@act", activity);
                        cmd.Parameters.AddWithValue("@desc", description);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch { }
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