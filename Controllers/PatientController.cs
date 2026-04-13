using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace AceCareClinicSystem.Controllers
{
    public class PatientController
    {
        private DbConnection db = new DbConnection();

        // CHANGED: Added DateTime dateOfBirth parameter
        public bool RegisterPatient(string category, string idNo, string fName, string lName,
            string mInitial, string department, string contact, string emergency,
            string yearLevel, DateTime dateOfBirth)
        {
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    string query = @"INSERT INTO patients 
                        (category, patient_number, first_name, last_name, middle_initial, 
                         department, contact_number, emergency_contact_name, sex, date_of_birth, year_level) 
                        VALUES 
                        (@cat, @id, @fname, @lname, @mi, @dept, @contact, @emergency, @sex, @dob, @year)";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@cat", category);
                    cmd.Parameters.AddWithValue("@id", idNo);
                    cmd.Parameters.AddWithValue("@fname", fName);
                    cmd.Parameters.AddWithValue("@lname", lName);
                    cmd.Parameters.AddWithValue("@mi", mInitial);
                    cmd.Parameters.AddWithValue("@dept", department);
                    cmd.Parameters.AddWithValue("@contact", contact);
                    cmd.Parameters.AddWithValue("@emergency", emergency);
                    cmd.Parameters.AddWithValue("@sex", "Male");

                    // CHANGED: Now uses actual date from date picker
                    cmd.Parameters.AddWithValue("@dob", dateOfBirth);

                    cmd.Parameters.AddWithValue("@year",
                        string.IsNullOrEmpty(yearLevel) ? (object)DBNull.Value : yearLevel);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
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

                    string query = @"SELECT 
                                        CONCAT(p.first_name, ' ', p.last_name) AS PatientName, 
                                        p.patient_number AS IDNumber, 
                                        p.category AS PatientType, 
                                        p.department AS Dept, 
                                        COALESCE(
                                            DATE_FORMAT(
                                                (SELECT MAX(c.visit_date) 
                                                 FROM consultations c 
                                                 WHERE c.patient_id = p.patient_id), 
                                                '%b %d, %Y %h:%i %p'
                                            ), 
                                            'New Patient'
                                        ) AS LastVisit
                                     FROM patients p
                                     WHERE p.first_name LIKE @s 
                                        OR p.last_name LIKE @s 
                                        OR p.patient_number LIKE @s
                                     ORDER BY p.last_name ASC
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

        public DataRow GetPatientById(string patientNumber)
        {
            using (MySqlConnection conn = db.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT * FROM patients WHERE patient_number = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", patientNumber);

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    return dt.Rows.Count > 0 ? dt.Rows[0] : null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Get Patient Error: " + ex.Message);
                    return null;
                }
            }
        }
    }
}