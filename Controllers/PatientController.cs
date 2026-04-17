using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace AceCareClinicSystem.Controllers
{
    public class PatientController
    {
        private DbConnection db = new DbConnection();

        public bool RegisterPatient(string category, string idNo, string fName, string lName,
            string mInitial, string department, string contact, string emergencyName,
            string emergencyNumber, string yearLevel, DateTime dateOfBirth)
        {
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string query = @"INSERT INTO patients 
                        (category, patient_number, first_name, last_name, middle_initial, 
                         department, contact_number, emergency_contact_name, emergency_contact_number, sex, date_of_birth, year_level) 
                        VALUES (@cat, @id, @fname, @lname, @mi, @dept, @contact, @eName, @eNum, 'Male', @dob, @year)";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@cat", category);
                    cmd.Parameters.AddWithValue("@id", idNo);
                    cmd.Parameters.AddWithValue("@fname", fName);
                    cmd.Parameters.AddWithValue("@lname", lName);
                    cmd.Parameters.AddWithValue("@mi", mInitial);
                    cmd.Parameters.AddWithValue("@dept", department);
                    cmd.Parameters.AddWithValue("@contact", contact);
                    cmd.Parameters.AddWithValue("@eName", emergencyName);
                    cmd.Parameters.AddWithValue("@eNum", emergencyNumber);
                    cmd.Parameters.AddWithValue("@dob", dateOfBirth);
                    cmd.Parameters.AddWithValue("@year", string.IsNullOrEmpty(yearLevel) ? (object)DBNull.Value : yearLevel);

                    bool success = cmd.ExecuteNonQuery() > 0;
                    if (success) new AuthController().LogActivity(0, "Patient Registered", $"Registered: {fName} {lName} ({idNo})");
                    return success;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Register Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    // UPDATED: Now fetches details from the latest consultation for the reports table
                    string query = @"SELECT 
                        CONCAT(p.first_name, ' ', p.last_name) AS PatientName, 
                        p.patient_number AS IDNumber, 
                        p.category AS PatientType, 
                        p.department AS Dept,
                        CASE 
                            WHEN (SELECT COUNT(*) FROM consultations c WHERE c.patient_id = p.patient_id) = 0 
                            THEN 'New Patient'
                            ELSE COALESCE(
                                DATE_FORMAT((SELECT MAX(visit_date) FROM consultations WHERE patient_id = p.patient_id), '%b %d, %Y %h:%i %p'),
                                'New Patient'
                            )
                        END AS LastVisit,
                        (SELECT chief_complaint FROM consultations WHERE patient_id = p.patient_id ORDER BY visit_date DESC LIMIT 1) AS Description,
                        (SELECT CONCAT(medicine_quantity, ' (', dosage, ')') FROM consultations WHERE patient_id = p.patient_id ORDER BY visit_date DESC LIMIT 1) AS QtyDosage,
                        (SELECT clinic_incharge FROM consultations WHERE patient_id = p.patient_id ORDER BY visit_date DESC LIMIT 1) AS Personnel
                        FROM patients p 
                        WHERE p.first_name LIKE @s OR p.last_name LIKE @s OR p.patient_number LIKE @s
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
                    MessageBox.Show("GetPatients Error: " + ex.Message);
                    return new DataTable();
                }
            }
        }

        public DataRow GetPatientById(string patientNumber)
        {
            using (MySqlConnection conn = db.GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM patients WHERE patient_number = @id", conn);
                cmd.Parameters.AddWithValue("@id", patientNumber);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt.Rows.Count > 0 ? dt.Rows[0] : null;
            }
        }

        public bool UpdatePatient(string originalId, string category, string idNo, string fName, string lName,
            string mInitial, string department, string contact, string emergencyName,
            string emergencyNumber, string yearLevel, DateTime dateOfBirth)
        {
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string query = @"UPDATE patients SET category=@cat, patient_number=@id, first_name=@fname, last_name=@lname, 
                                     middle_initial=@mi, department=@dept, contact_number=@contact, 
                                     emergency_contact_name=@eName, emergency_contact_number=@eNum, date_of_birth=@dob, year_level=@year 
                                     WHERE patient_number=@originalId";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@cat", category);
                    cmd.Parameters.AddWithValue("@id", idNo);
                    cmd.Parameters.AddWithValue("@fname", fName);
                    cmd.Parameters.AddWithValue("@lname", lName);
                    cmd.Parameters.AddWithValue("@mi", mInitial);
                    cmd.Parameters.AddWithValue("@dept", department);
                    cmd.Parameters.AddWithValue("@contact", contact);
                    cmd.Parameters.AddWithValue("@eName", emergencyName);
                    cmd.Parameters.AddWithValue("@eNum", emergencyNumber);
                    cmd.Parameters.AddWithValue("@dob", dateOfBirth);
                    cmd.Parameters.AddWithValue("@year", string.IsNullOrEmpty(yearLevel) ? (object)DBNull.Value : yearLevel);
                    cmd.Parameters.AddWithValue("@originalId", originalId);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool DeletePatient(string id)
        {
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM patients WHERE patient_number = @id", conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Delete Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}