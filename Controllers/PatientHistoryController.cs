using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AceCareClinicSystem.Controllers
{
    public class PatientHistoryController
    {
        private string connectionString = "Server=127.0.0.1;Database=acecare_db;Uid=root;Pwd=;";

        public DataTable GetAllConsultationsList()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT 
                c.id AS consultation_id,
                c.patient_id,
                DATE_FORMAT(c.visit_date, '%b %d, %Y %h:%i %p') AS visit_date,
                CONCAT(p.first_name, ' ', p.last_name) AS patient_name,
                CONCAT(COALESCE(c.age,'?'), '/', COALESCE(c.sex,'?')) AS age_sex,
                COALESCE(c.visit_type, 'N/A') AS visit_type,
                COALESCE(c.chief_complaint, 'N/A') AS chief_complaint,
                CONCAT('T:', COALESCE(c.temperature,'-'), ' BP:', COALESCE(c.blood_pressure,'-'), ' PR:', COALESCE(c.pulse_rate,'-')) AS vitals_summary,
                COALESCE(c.physical_findings, 'N/A') AS diagnosis,
                COALESCE(c.medicine_name, 'None') AS medicine_name,
                COALESCE(c.outcome, 'Pending') AS outcome,
                CASE 
                    WHEN c.outcome LIKE '%Refer%' THEN 'Referred'
                    WHEN c.outcome LIKE '%Home%' THEN 'Completed'
                    ELSE 'Pending'
                END AS status,
                COALESCE(c.remarks_instructions, '') AS remarks,
                COALESCE(u.full_name, c.clinic_incharge, 'N/A') AS handled_by
            FROM consultations c
            INNER JOIN patients p ON c.patient_id = p.patient_id
            LEFT JOIN users u ON c.handled_by_user_id = u.user_id
            ORDER BY c.visit_date DESC";

                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("GetAllConsultationsList Error: " + ex.Message);
                return new DataTable();
            }
        }

        public DataTable GetPatientInfo(int patientId)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string sql = @"
                    SELECT 
                        patient_id,
                        CONCAT(first_name, ' ', last_name) AS full_name,
                        age,
                        sex,
                        date_of_birth,
                        address,
                        contact_number
                    FROM patients
                    WHERE patient_id = @patientId";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@patientId", patientId);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            return dt;
        }

        public DataTable GetRecentVitals(int patientId)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string sql = @"
                    SELECT 
                        temperature,
                        blood_pressure,
                        pulse_rate,
                        respiratory_rate,
                        oxygen_saturation,
                        physical_findings
                    FROM consultations
                    WHERE patient_id = @patientId
                    ORDER BY visit_date DESC
                    LIMIT 1";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@patientId", patientId);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            return dt;
        }
    }
}