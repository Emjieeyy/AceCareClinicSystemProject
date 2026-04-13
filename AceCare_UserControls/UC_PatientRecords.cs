using AceCareClinicSystem.Controllers;
using AceCareClinicSystem.Services;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AceCareClinicSystem.AceCare_UserControls
{
    public partial class UC_PatientRecords : UserControl
    {
        private PatientController _patientController = new PatientController();
        private int patientOffset = 0;
        private const int PageSize = 10;

        // NEW: Event to notify main form when patient is selected for consultation
        public event Action<DataRow> PatientSelectedForConsultation;

        public UC_PatientRecords()
        {
            InitializeComponent();
            dgvPatients.AutoGenerateColumns = false;
            InitializeDropdowns();
            InitializeDatePickers();
            DataGridViewStyle.ApplyModernDesign(dgvPatients);

            // NEW: Wire up double-click event
            dgvPatients.CellDoubleClick += dgvPatients_CellDoubleClick;

            this.Load += (s, e) => RefreshPatientTable();
        }

        private void InitializeDropdowns()
        {
            // CHANGED: Added "Visitor" to categories
            cmbCategory.Items.Clear();
            cmbCategory.Items.AddRange(new string[] {
                "Student",
                "Faculty",
                "Teaching Staff",
                "Non-Teaching Staff",
                "Employee",
                "JDVP",  // JDVP is Grade 12 student
                "Visitor"
            });

            cmbDepartment.Items.Clear();
            cmbDepartment.Items.AddRange(new string[] { "IICT", "IHTM", "IABM", "ITE", "SHS" });

            // CHANGED: Added Grade 11 and Grade 12 for SHS and JDVP
            cmbYearLevel.Items.Clear();
            cmbYearLevel.Items.AddRange(new string[] {
                "1st Year",
                "2nd Year",
                "3rd Year",
                "4th Year",
                "Grade 11",
                "Grade 12"  // JDVP is G12
            });
        }

        private void InitializeDatePickers()
        {
            dobTimePicker.Format = DateTimePickerFormat.Short;
            dobTimePicker.MaxDate = DateTime.Now;
            dobTimePicker.Value = new DateTime(2000, 1, 1);
        }

        // NEW: Double-click handler to open consultation
        private void dgvPatients_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string patientID = dgvPatients.Rows[e.RowIndex].Cells[1].Value?.ToString();

            if (string.IsNullOrEmpty(patientID))
            {
                MessageBox.Show("Could not get patient ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataRow patient = _patientController.GetPatientById(patientID);

            if (patient == null)
            {
                MessageBox.Show("Patient not found in database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PatientSelectedForConsultation?.Invoke(patient);
        }

        public void RefreshPatientTable()
        {
            DataTable dt = _patientController.GetPatients(txtSearch.Text, patientOffset);

            if (dt.Rows.Count == 0 && patientOffset > 0)
            {
                MessageBox.Show("No more records to display.", "End of List", MessageBoxButtons.OK, MessageBoxIcon.Information);
                patientOffset -= PageSize;
                return;
            }

            if (dgvPatients.Columns.Count >= 5)
            {
                dgvPatients.Columns[0].DataPropertyName = "PatientName";
                dgvPatients.Columns[1].DataPropertyName = "IDNumber";
                dgvPatients.Columns[2].DataPropertyName = "PatientType";
                dgvPatients.Columns[3].DataPropertyName = "Dept";
                dgvPatients.Columns[4].DataPropertyName = "LastVisit";

                foreach (DataGridViewColumn col in dgvPatients.Columns)
                {
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }

            BindingHelper.BindToGrid(dgvPatients, dt);
            btnPrev.Enabled = (patientOffset > 0);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            patientOffset += PageSize;
            RefreshPatientTable();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (patientOffset >= PageSize)
            {
                patientOffset -= PageSize;
                RefreshPatientTable();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            patientOffset = 0;
            RefreshPatientTable();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) || string.IsNullOrWhiteSpace(txtIDNumber.Text))
            {
                MessageBox.Show("Please fill in the Name and ID Number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // CHANGED: JDVP is now treated as student (G12)
            if (IsStudentCategory(cmbCategory.Text) && cmbYearLevel.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a Year Level for Student/JDVP patients.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool isSaved = _patientController.RegisterPatient(
                cmbCategory.Text, txtIDNumber.Text, txtFirstName.Text,
                txtLastName.Text, txtMI.Text, cmbDepartment.Text,
                txtContact.Text, txtEmergency.Text,
                cmbYearLevel.Text,
                dobTimePicker.Value
            );

            if (isSaved)
            {
                MessageBox.Show("Patient saved successfully! ✅", "Success");
                ClearFields();
                RefreshPatientTable();
            }
        }

        // CHANGED: JDVP is now included as student category
        private bool IsStudentCategory(string category)
        {
            return category == "Student" || category == "JDVP";
        }

        private void ClearFields()
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            txtIDNumber.Clear();
            txtMI.Clear();
            txtContact.Clear();
            txtEmergency.Clear();
            cmbCategory.SelectedIndex = -1;
            cmbDepartment.SelectedIndex = -1;
            cmbYearLevel.SelectedIndex = -1;
            dobTimePicker.Value = new DateTime(2000, 1, 1);

            cmbYearLevel.Enabled = true;
            cmbYearLevel.BackColor = Color.White;
        }

        // CHANGED: Enable Year Level for both Student and JDVP
        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsStudentCategory(cmbCategory.Text))
            {
                // Student or JDVP: Enable Year Level
                cmbYearLevel.Enabled = true;
                cmbYearLevel.BackColor = Color.White;

                // Auto-select Grade 12 for JDVP
                if (cmbCategory.Text == "JDVP")
                {
                    cmbYearLevel.SelectedItem = "Grade 12";
                }
                else if (cmbYearLevel.Text == "N/A")
                {
                    cmbYearLevel.SelectedIndex = -1;
                }
            }
            else
            {
                // Non-student: Disable but keep visible
                cmbYearLevel.Enabled = false;
                cmbYearLevel.BackColor = Color.LightGray;
                cmbYearLevel.SelectedIndex = -1;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            patientOffset = 0;
            RefreshPatientTable();
        }

        private void txtIDNumber_TextChanged(object sender, EventArgs e)
        {
        }

        private void dgvPatients_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}