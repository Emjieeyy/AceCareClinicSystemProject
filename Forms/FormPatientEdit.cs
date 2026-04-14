using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using AceCareClinicSystem.Controllers;
using ReaLTaiizor.Forms;
using ReaLTaiizor.Controls;

namespace AceCareClinicSystem.Forms
{
    public partial class FormPatientEdit : PoisonForm
    {
        private PatientController _patientController = new PatientController();
        private string _originalId;
        
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public bool IsSuccess { get; private set; } = false;

        public FormPatientEdit(string patientId = "")
        {
            InitializeComponent();
            _originalId = patientId;
            InitializeDropdowns();
            
            if (!string.IsNullOrEmpty(_originalId))
            {
                LoadPatientData();
            }
        }

        private void InitializeDropdowns()
        {
            cmbCategory.Items.AddRange(new string[] { "Student", "Faculty", "Teaching Staff", "Non-Teaching Staff", "Employee", "JDVP", "Visitor" });
            cmbDepartment.Items.AddRange(new string[] { "IICT", "IHTM", "IABM", "ITE", "SHS" });
            cmbYearLevel.Items.AddRange(new string[] { "1st Year", "2nd Year", "3rd Year", "4th Year", "Grade 11", "Grade 12" });
        }

        private void LoadPatientData()
        {
            DataRow patient = _patientController.GetPatientById(_originalId);
            if (patient != null)
            {
                txtIDNumber.Text = patient["patient_number"].ToString();
                txtFirstName.Text = patient["first_name"].ToString();
                txtLastName.Text = patient["last_name"].ToString();
                txtMI.Text = patient["middle_initial"].ToString();
                txtContact.Text = patient["contact_number"].ToString();
                txtEmergencyName.Text = patient["emergency_contact_name"].ToString();
                txtEmergencyNumber.Text = patient["emergency_contact_number"].ToString();
                cmbCategory.Text = patient["category"].ToString();
                cmbDepartment.Text = patient["department"].ToString();
                cmbYearLevel.Text = patient["year_level"]?.ToString() ?? "";
                
                if (DateTime.TryParse(patient["date_of_birth"].ToString(), out DateTime dob))
                    dobPicker.Value = dob;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) || string.IsNullOrWhiteSpace(txtIDNumber.Text))
            {
                MessageBox.Show("Please fill in required fields.");
                return;
            }

            bool success = _patientController.UpdatePatient(
                _originalId,
                cmbCategory.Text,
                txtIDNumber.Text,
                txtFirstName.Text,
                txtLastName.Text,
                txtMI.Text,
                cmbDepartment.Text,
                txtContact.Text,
                txtEmergencyName.Text,
                txtEmergencyNumber.Text,
                cmbYearLevel.Text,
                dobPicker.Value
            );

            if (success)
            {
                IsSuccess = true;
                MessageBox.Show("Patient records updated successfully!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to update patient records.");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
