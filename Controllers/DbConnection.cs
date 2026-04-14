using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AceCareClinicSystem.Controllers
{
    public class DbConnection
    {
        private string connectionString = "server=localhost;database=acecaredb;uid=root;pwd=;";

        public MySqlConnection GetConnection() => new MySqlConnection(connectionString);

        public DataTable ExecuteRead(string query, Dictionary<string, object> parameters = null)
        {
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection conn = GetConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        if (parameters != null)
                            foreach (var param in parameters) cmd.Parameters.AddWithValue(param.Key, param.Value);
                        conn.Open();
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd)) { adapter.Fill(dt); }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Database Read Error: " + ex.Message); }
            return dt;
        }

        public bool ExecuteWrite(string query, Dictionary<string, object> parameters)
        {
            try
            {
                using (MySqlConnection conn = GetConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        foreach (var param in parameters) cmd.Parameters.AddWithValue(param.Key, param.Value);
                        conn.Open();
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Database Write Error: " + ex.Message); return false; }
        }
    }
}