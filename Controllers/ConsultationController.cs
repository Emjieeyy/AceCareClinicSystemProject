using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace AceCareClinicSystem.Controllers
{
    public class ConsultationController
    {
        private string connStr = "server=localhost;port=3306;database=acecaredb;user=root;password=;Charset=utf8;SslMode=Disabled;";

        /// <summary>
        /// Get patient_id from patient_number
        /// </summary>
        public int? GetPatientIdByNumber(string patientNumber)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    string query = "SELECT patient_id FROM patients WHERE patient_number = @patientNumber";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@patientNumber", patientNumber);
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                            return Convert.ToInt32(result);
                        return null;
                    }
                }
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Auto-create patient if not exists
        /// </summary>
        public int EnsurePatientExists(string patientNumber, string firstName, string lastName,
            string age, string sex, string address, string guardian, string emergency,
            string category = "Student", string department = "Unknown")
        {
            // Try to find existing patient
            int? existingId = GetPatientIdByNumber(patientNumber);
            if (existingId.HasValue)
                return existingId.Value;

            // Auto-create new patient
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    string query = @"INSERT INTO patients 
                        (patient_number, first_name, last_name, age, sex, address, 
                         guardian_name, emergency_contact_name, category, department, created_at) 
                        VALUES 
                        (@pNum, @fname, @lname, @age, @sex, @addr, 
                         @guardian, @emergency, @cat, @dept, NOW());
                        SELECT LAST_INSERT_ID();";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@pNum", patientNumber);
                        cmd.Parameters.AddWithValue("@fname", string.IsNullOrWhiteSpace(firstName) ? "Unknown" : firstName);
                        cmd.Parameters.AddWithValue("@lname", string.IsNullOrWhiteSpace(lastName) ? "Patient" : lastName);
                        cmd.Parameters.AddWithValue("@age", string.IsNullOrWhiteSpace(age) ? "0" : age);
                        cmd.Parameters.AddWithValue("@sex", string.IsNullOrWhiteSpace(sex) ? "Unknown" : sex);
                        cmd.Parameters.AddWithValue("@addr", string.IsNullOrWhiteSpace(address) ? "Not specified" : address);
                        cmd.Parameters.AddWithValue("@guardian", string.IsNullOrWhiteSpace(guardian) ? "N/A" : guardian);
                        cmd.Parameters.AddWithValue("@emergency", string.IsNullOrWhiteSpace(emergency) ? "N/A" : emergency);
                        cmd.Parameters.AddWithValue("@cat", category);
                        cmd.Parameters.AddWithValue("@dept", department);

                        int newId = Convert.ToInt32(cmd.ExecuteScalar());
                        return newId;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Auto-create patient failed: " + ex.Message, "Error");
                return -1;
            }
        }

        public bool SaveFullConsultation(
            string patientNumber, // Changed from int to string
            string vType, string refBy, string complaint, string symptoms,
            decimal temp, string bp, int pulse, int resp, decimal oxygen,
            string physical, string injury, string nurseNotes,
            string treatment, string medName, int medQty, string dosage, DateTime expiry, string treatNotes,
            string outcome, string remarks, string incharge, int sId, string finalNotes,
            string age, string sex, string address, string guardian, string emergency,
            string firstName = "", string lastName = "", string category = "Student", string department = "Unknown")
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();

                    // AUTO-CREATE PATIENT IF NOT EXISTS
                    int pId = EnsurePatientExists(patientNumber, firstName, lastName, age, sex,
                        address, guardian, emergency, category, department);

                    if (pId == -1)
                    {
                        MessageBox.Show("Failed to create or find patient.", "Error");
                        return false;
                    }

                    // SAVE CONSULTATION
                    string query = @"INSERT INTO consultations 
                        (patient_id, age, sex, address, guardian_name, emergency_contact,
                         visit_type, referred_by, chief_complaint, symptoms_description,
                         temperature, blood_pressure, pulse_rate, respiratory_rate, oxygen_saturation,
                         physical_findings, injury_description, nurse_notes,
                         treatment_checklist, medicine_name, medicine_quantity, dosage, medicine_expiry,
                         treatment_notes, outcome, remarks_instructions, clinic_incharge, user_id, final_notes)
                        VALUES 
                        (@pId, @age, @sex, @addr, @guard, @emerg,
                         @vType, @refBy, @comp, @symp,
                         @temp, @bp, @pulse, @resp, @oxy,
                         @phys, @inj, @nNote,
                         @tCheck, @mName, @mQty, @dos, @exp,
                         @tNote, @out, @rem, @inch, @uId, @fNote)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@pId", pId);
                        cmd.Parameters.AddWithValue("@age", age ?? "");
                        cmd.Parameters.AddWithValue("@sex", sex ?? "");
                        cmd.Parameters.AddWithValue("@addr", address ?? "");
                        cmd.Parameters.AddWithValue("@guard", guardian ?? "");
                        cmd.Parameters.AddWithValue("@emerg", emergency ?? "");
                        cmd.Parameters.AddWithValue("@vType", vType);
                        cmd.Parameters.AddWithValue("@refBy", refBy);
                        cmd.Parameters.AddWithValue("@comp", complaint);
                        cmd.Parameters.AddWithValue("@symp", symptoms ?? "");
                        cmd.Parameters.AddWithValue("@temp", temp);
                        cmd.Parameters.AddWithValue("@bp", bp ?? "");
                        cmd.Parameters.AddWithValue("@pulse", pulse);
                        cmd.Parameters.AddWithValue("@resp", resp);
                        cmd.Parameters.AddWithValue("@oxy", oxygen);
                        cmd.Parameters.AddWithValue("@phys", physical ?? "");
                        cmd.Parameters.AddWithValue("@inj", injury ?? "");
                        cmd.Parameters.AddWithValue("@nNote", nurseNotes ?? "");
                        cmd.Parameters.AddWithValue("@tCheck", treatment ?? "");
                        cmd.Parameters.AddWithValue("@mName", medName ?? "");
                        cmd.Parameters.AddWithValue("@mQty", medQty);
                        cmd.Parameters.AddWithValue("@dos", dosage ?? "N/A");
                        cmd.Parameters.AddWithValue("@exp", expiry.Date);
                        cmd.Parameters.AddWithValue("@tNote", treatNotes ?? "");
                        cmd.Parameters.AddWithValue("@out", outcome);
                        cmd.Parameters.AddWithValue("@rem", remarks ?? "");
                        cmd.Parameters.AddWithValue("@inch", incharge ?? "");
                        cmd.Parameters.AddWithValue("@uId", sId);
                        cmd.Parameters.AddWithValue("@fNote", finalNotes ?? "");

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0) new AuthController().LogActivity(0, "Consultation Saved", $"Saved consultation for patient ID: {pId}");
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Save Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}