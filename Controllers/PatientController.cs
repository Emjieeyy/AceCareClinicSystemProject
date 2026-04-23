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
            string emergencyNumber, string yearLevel, DateTime dateOfBirth,
            string sex, int? age, string address)
        {
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string query = @"INSERT INTO patients 
                        (patient_number, first_name, last_name, middle_initial, category,
                         department, year_level, age, date_of_birth, sex, address,
                         contact_number, emergency_contact_name, emergency_contact_number) 
                        VALUES (@id, @fname, @lname, @mi, @cat, @dept, @year, @age, @dob, @sex, @address,
                                @contact, @eName, @eNum)";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", idNo);
                    cmd.Parameters.AddWithValue("@fname", fName);
                    cmd.Parameters.AddWithValue("@lname", lName);
                    cmd.Parameters.AddWithValue("@mi", mInitial);
                    cmd.Parameters.AddWithValue("@cat", category);
                    cmd.Parameters.AddWithValue("@dept", department);
                    cmd.Parameters.AddWithValue("@year", string.IsNullOrEmpty(yearLevel) ? (object)DBNull.Value : yearLevel);
                    cmd.Parameters.AddWithValue("@age", age.HasValue ? (object)age.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@dob", dateOfBirth);
                    cmd.Parameters.AddWithValue("@sex", sex);
                    cmd.Parameters.AddWithValue("@address", string.IsNullOrEmpty(address) ? (object)DBNull.Value : address);
                    cmd.Parameters.AddWithValue("@contact", string.IsNullOrEmpty(contact) ? (object)DBNull.Value : contact);
                    cmd.Parameters.AddWithValue("@eName", string.IsNullOrEmpty(emergencyName) ? (object)DBNull.Value : emergencyName);
                    cmd.Parameters.AddWithValue("@eNum", string.IsNullOrEmpty(emergencyNumber) ? (object)DBNull.Value : emergencyNumber);

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

        public DataTable GetPatients(string search = "", int offset = 0, DateTime? startDate = null, DateTime? endDate = null)
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
                        CASE 
                            WHEN (SELECT COUNT(*) FROM consultations c WHERE c.patient_id = p.patient_id) = 0 
                            THEN 'New Patient'
                            ELSE COALESCE(
                                DATE_FORMAT((SELECT MAX(visit_date) FROM consultations WHERE patient_id = p.patient_id), '%m/%d/%Y %h:%i %p'),
                                'New Patient'
                            )
                        END AS LastVisit,
                        (SELECT chief_complaint FROM consultations WHERE patient_id = p.patient_id ORDER BY visit_date DESC LIMIT 1) AS Description,
                        (SELECT CONCAT(medicine_quantity, ' (', dosage, ')') FROM consultations WHERE patient_id = p.patient_id ORDER BY visit_date DESC LIMIT 1) AS QtyDosage,
                        (SELECT clinic_incharge FROM consultations WHERE patient_id = p.patient_id ORDER BY visit_date DESC LIMIT 1) AS Personnel
                        FROM patients p 
                        WHERE (p.first_name LIKE @s OR p.last_name LIKE @s OR p.patient_number LIKE @s)";

                    if (startDate.HasValue && endDate.HasValue)
                    {
                        query += @" AND EXISTS (
                            SELECT 1 FROM consultations c 
                            WHERE c.patient_id = p.patient_id 
                            AND c.visit_date >= @start AND c.visit_date <= @end
                        )";
                    }

                    query += " ORDER BY p.last_name ASC LIMIT 10 OFFSET @offset";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@s", "%" + search + "%");
                    cmd.Parameters.AddWithValue("@offset", offset);
                    if (startDate.HasValue) cmd.Parameters.AddWithValue("@start", startDate.Value.Date);
                    if (endDate.HasValue) cmd.Parameters.AddWithValue("@end", endDate.Value.Date.AddDays(1).AddTicks(-1));

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
            string emergencyNumber, string yearLevel, DateTime dateOfBirth,
            string sex, int? age, string address)
        {
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string query = @"UPDATE patients SET 
                        patient_number=@id, first_name=@fname, last_name=@lname, 
                        middle_initial=@mi, category=@cat, department=@dept, 
                        year_level=@year, age=@age, date_of_birth=@dob, sex=@sex, address=@address,
                        contact_number=@contact, emergency_contact_name=@eName, emergency_contact_number=@eNum
                        WHERE patient_number=@originalId";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", idNo);
                    cmd.Parameters.AddWithValue("@fname", fName);
                    cmd.Parameters.AddWithValue("@lname", lName);
                    cmd.Parameters.AddWithValue("@mi", mInitial);
                    cmd.Parameters.AddWithValue("@cat", category);
                    cmd.Parameters.AddWithValue("@dept", department);
                    cmd.Parameters.AddWithValue("@year", string.IsNullOrEmpty(yearLevel) ? (object)DBNull.Value : yearLevel);
                    cmd.Parameters.AddWithValue("@age", age.HasValue ? (object)age.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@dob", dateOfBirth);
                    cmd.Parameters.AddWithValue("@sex", sex);
                    cmd.Parameters.AddWithValue("@address", string.IsNullOrEmpty(address) ? (object)DBNull.Value : address);
                    cmd.Parameters.AddWithValue("@contact", string.IsNullOrEmpty(contact) ? (object)DBNull.Value : contact);
                    cmd.Parameters.AddWithValue("@eName", string.IsNullOrEmpty(emergencyName) ? (object)DBNull.Value : emergencyName);
                    cmd.Parameters.AddWithValue("@eNum", string.IsNullOrEmpty(emergencyNumber) ? (object)DBNull.Value : emergencyNumber);
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

        public DataTable GetReportData(DateTime fromDate, DateTime toDate, string search = "", string category = "All Records")
        {
            using (MySqlConnection conn = db.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT 
                        DATE_FORMAT(c.visit_date, '%d-%b-%y %H:%i') AS LastVisit,
                        p.patient_number AS IDNumber, 
                        CONCAT(p.first_name, ' ', p.last_name) AS PatientName, 
                        p.category AS PatientType, 
                        c.chief_complaint AS Description,
                        CONCAT(c.medicine_quantity, ' (', c.dosage, ')') AS QtyDosage,
                        c.clinic_incharge AS Personnel
                        FROM consultations c
                        INNER JOIN patients p ON c.patient_id = p.patient_id
                        WHERE (c.visit_date >= @from AND c.visit_date <= @to)
                        AND (p.first_name LIKE @s OR p.last_name LIKE @s OR p.patient_number LIKE @s)";

                    if (category != "All Records" && !string.IsNullOrEmpty(category))
                    {
                        query += " AND p.category = @cat";
                    }

                    query += " ORDER BY c.visit_date DESC";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@from", fromDate.Date);
                    cmd.Parameters.AddWithValue("@to", toDate.Date.AddDays(1).AddTicks(-1));
                    cmd.Parameters.AddWithValue("@s", "%" + search.Trim() + "%");

                    if (category != "All Records" && !string.IsNullOrEmpty(category))
                    {
                        cmd.Parameters.AddWithValue("@cat", category);
                    }

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("GetReportData Error: " + ex.Message);
                    return new DataTable();
                }
            }
        }
    }
}