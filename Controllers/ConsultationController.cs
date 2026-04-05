using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace AceCareClinicSystem.Controllers
{
    public class ConsultationController
    {
        private string connStr = "server=localhost;port=3306;database=acecaredb;user=root;password=;Charset=utf8;SslMode=Disabled;";

        public bool SaveFullConsultation(
            int pId, string vType, string refBy, string complaint, string symptoms,
            decimal temp, string bp, int pulse, int resp, decimal oxygen,
            string physical, string injury, string nurseNotes,
            string treatment, string medName, int medQty, string dosage, DateTime expiry, string treatNotes,
            string outcome, string remarks, string incharge, int sId, string finalNotes,
            string age, string sex, string address, string guardian, string emergency)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();

                
                    string query = @"INSERT INTO consultations 
                        (patient_id, sex, age, address, guardian_name, emergency_contact, 
                         visit_type, referred_by, chief_complaint, symptoms_description, 
                         temperature, blood_pressure, pulse_rate, respiratory_rate, oxygen_saturation, 
                         physical_findings, injury_description, nurse_notes, 
                         treatment_checklist, medicine_name, medicine_quantity, dosage, medicine_expiry, 
                         treatment_notes, outcome, remarks_instructions, clinic_incharge, user_id, final_notes) 
                        VALUES 
                        (@pId, @sex, @age, @addr, @guard, @emerg, 
                         @vType, @refBy, @comp, @symp, @temp, @bp, @pulse, @resp, @oxy, 
                         @phys, @inj, @nNote, @tCheck, @mName, @mQty, @dos, @exp, 
                         @tNote, @out, @rem, @inch, @uId, @fNote)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                       
                        cmd.Parameters.AddWithValue("@sex", sex);
                        cmd.Parameters.AddWithValue("@age", age);
                        cmd.Parameters.AddWithValue("@addr", address);
                        cmd.Parameters.AddWithValue("@guard", guardian);
                        cmd.Parameters.AddWithValue("@emerg", emergency);
                        cmd.Parameters.AddWithValue("@pId", pId);
                        cmd.Parameters.AddWithValue("@vType", vType);
                        cmd.Parameters.AddWithValue("@refBy", refBy);
                        cmd.Parameters.AddWithValue("@comp", complaint);
                        cmd.Parameters.AddWithValue("@symp", symptoms);
                        cmd.Parameters.AddWithValue("@temp", temp);
                        cmd.Parameters.AddWithValue("@bp", bp);
                        cmd.Parameters.AddWithValue("@pulse", pulse);
                        cmd.Parameters.AddWithValue("@resp", resp);
                        cmd.Parameters.AddWithValue("@oxy", oxygen);
                        cmd.Parameters.AddWithValue("@phys", physical);
                        cmd.Parameters.AddWithValue("@inj", injury);
                        cmd.Parameters.AddWithValue("@nNote", nurseNotes);
                        cmd.Parameters.AddWithValue("@tCheck", treatment);
                        cmd.Parameters.AddWithValue("@mName", medName);
                        cmd.Parameters.AddWithValue("@mQty", medQty);
                        cmd.Parameters.AddWithValue("@dos", dosage); 
                        cmd.Parameters.AddWithValue("@exp", expiry.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@tNote", treatNotes);
                        cmd.Parameters.AddWithValue("@out", outcome);
                        cmd.Parameters.AddWithValue("@rem", remarks);
                        cmd.Parameters.AddWithValue("@inch", incharge);
                        cmd.Parameters.AddWithValue("@uId", sId);
                        cmd.Parameters.AddWithValue("@fNote", finalNotes);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Error: " + ex.Message);
                return false;
            }
        }
    }
}