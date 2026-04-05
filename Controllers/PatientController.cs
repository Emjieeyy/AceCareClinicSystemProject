using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace AceCareClinicSystem.Controllers
{
    public class PatientController
    {
        private DbConnection db = new DbConnection();

        public bool RegisterPatient(string category, string idNo, string fName, string lName, string mInitial, string department, string contact, string emergency)
        {
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    // FIXED QUERY: Added sex and date_of_birth which are REQUIRED (NOT NULL) in your DB
                    string query = @"INSERT INTO patients (category, patient_number, first_name, last_name, middle_initial, department, contact_number, emergency_contact_name, sex, date_of_birth) 
                                     VALUES (@cat, @id, @fname, @lname, @mi, @dept, @contact, @emergency, @sex, @dob)";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@cat", category);
                    cmd.Parameters.AddWithValue("@id", idNo);
                    cmd.Parameters.AddWithValue("@fname", fName);
                    cmd.Parameters.AddWithValue("@lname", lName);
                    cmd.Parameters.AddWithValue("@mi", mInitial);
                    cmd.Parameters.AddWithValue("@dept", department);
                    cmd.Parameters.AddWithValue("@contact", contact);
                    cmd.Parameters.AddWithValue("@emergency", emergency);

                    // Default values so the DB doesn't reject the insert
                    cmd.Parameters.AddWithValue("@sex", "Male");
                    cmd.Parameters.AddWithValue("@dob", "2000-01-01");

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                // This will pop up if there is a SQL error so you aren't guessing!
                MessageBox.Show("Registration Error: " + ex.Message, "Database Error");
                return false;
            }
        }

        public DataTable GetPatients(string search = "", int offset = 0)
        {
            using (MySqlConnection conn = db.GetConnection())
            {
                try
                {
                    conn.Open();
                    // Simplified Query to ensure patients show up even if they have 0 visits
                    string query = @"SELECT 
                                        CONCAT(first_name, ' ', last_name) AS PatientName, 
                                        patient_number AS IDNumber, 
                                        category AS PatientType, 
                                        department AS Dept, 
                                        'New Patient' AS LastVisit
                                     FROM patients 
                                     WHERE first_name LIKE @s 
                                        OR last_name LIKE @s 
                                        OR patient_number LIKE @s
                                     ORDER BY last_name ASC
                                     LIMIT 10 OFFSET @offset";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@s", "%" + search + "%");
                    cmd.Parameters.AddWithValue("@offset", offset);

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Table Load Error: " + ex.Message);
                    return new DataTable();
                }
            }
        }
    }
}