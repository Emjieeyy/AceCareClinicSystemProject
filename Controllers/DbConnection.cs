using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AceCareClinicSystem.Controllers
{
    public class DbConnection
    {
        private readonly string connectionString =
            "server=localhost;database=acecare_db;uid=root;pwd=;";

        // OPEN CONNECTION (helper)
        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

        // =========================
        // SELECT (with parameters)
        // =========================
        public DataTable ExecuteRead(string query)
        {
            return ExecuteRead(query, null);
        }

        public DataTable ExecuteRead(string query, Dictionary<string, object> parameters)
        {
            DataTable dt = new DataTable();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    // Add parameters if provided
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                        }
                    }

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }

            return dt;
        }

        // =========================
        // INSERT / UPDATE / DELETE (with parameters)
        // =========================
        public int ExecuteWrite(string query)
        {
            return ExecuteWrite(query, null);
        }

        public int ExecuteWrite(string query, Dictionary<string, object> parameters)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    // Add parameters if provided
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                        }
                    }

                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}