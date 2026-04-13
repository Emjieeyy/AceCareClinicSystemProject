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

        // Event to notify main form when patient is selected for consultation
        public event Action<DataRow> PatientSelectedForConsultation;

        public UC_PatientRecords()
        {
            InitializeComponent();
            dgvPatients.AutoGenerateColumns = false;
            InitializeDropdowns();
            InitializeDatePickers();
            InitializeDeleteColumn();
            DataGridViewStyle.ApplyModernDesign(dgvPatients);

            // Wire up events
            dgvPatients.CellClick += dgvPatients_CellClick;           // Single click to edit
            dgvPatients.CellContentClick += dgvPatients_CellContentClick; // Delete button
            dgvPatients.CellDoubleClick += dgvPatients_CellDoubleClick;    

            this.Load += (s, e) => RefreshPatientTable();
        }

        private void InitializeDropdowns()
        {
            cmbCategory.Items.Clear();
            cmbCategory.Items.AddRange(new string[] {
                "Student", "Faculty", "Teaching Staff", "Non-Teaching Staff",
                "Employee", "JDVP", "Visitor"
            });

            cmbDepartment.Items.Clear();
            cmbDepartment.Items.AddRange(new string[] { "IICT", "IHTM", "IABM", "ITE", "SHS" });

            cmbYearLevel.Items.Clear();
            cmbYearLevel.Items.AddRange(new string[] {
                "1st Year", "2nd Year", "3rd Year", "4th Year", "Grade 11", "Grade 12"
            });
        }

        private void InitializeDatePickers()
        {
            dobTimePicker.Format = DateTimePickerFormat.Short;
            dobTimePicker.MaxDate = DateTime.Now;
            dobTimePicker.Value = new DateTime(2000, 1, 1);
        }

        // ADD: Delete button column to DataGridView
        private void InitializeDeleteColumn()
        {
            // Check if column already exists
            if (dgvPatients.Columns["Delete"] == null)
            {
                DataGridViewButtonColumn deleteBtn = new DataGridViewButtonColumn();
                deleteBtn.Name = "Delete";
                deleteBtn.HeaderText = "Delete";
                deleteBtn.Text = "🗑️";
                deleteBtn.UseColumnTextForButtonValue = true;
                deleteBtn.DefaultCellStyle.BackColor = Color.DarkRed;
                deleteBtn.DefaultCellStyle.ForeColor = Color.White;
                deleteBtn.Width = 60;
                dgvPatients.Columns.Add(deleteBtn);
            }
        }

        // NEW: Single click to load patient for editing
        private void dgvPatients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // Ignore header clicks
            if (e.ColumnIndex == dgvPatients.Columns["Delete"]?.Index) return; // Ignore delete column

            LoadPatientIntoForm(e.RowIndex);
        }

        // NEW: Load patient data into form for editing
        private void LoadPatientIntoForm(int rowIndex)
        {
            string patientID = dgvPatients.Rows[rowIndex].Cells["IDNumber"]?.Value?.ToString();

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

            // Fill form fields
            txtIDNumber.Text = patient["patient_number"].ToString();
            txtFirstName.Text = patient["first_name"].ToString();
            txtLastName.Text = patient["last_name"].ToString();
            txtMI.Text = patient["middle_initial"].ToString();
            txtContact.Text = patient["contact_number"].ToString();
            txtEmergency.Text = patient["emergency_contact_name"].ToString();

            cmbCategory.Text = patient["category"].ToString();
            cmbDepartment.Text = patient["department"].ToString();

            // Handle year level
            if (patient["year_level"] != DBNull.Value)
            {
                cmbYearLevel.Text = patient["year_level"].ToString();
            }
            else
            {
                cmbYearLevel.SelectedIndex = -1;
            }

            // Handle date of birth
            if (patient["date_of_birth"] != DBNull.Value && DateTime.TryParse(patient["date_of_birth"].ToString(), out DateTime dob))
            {
                dobTimePicker.Value = dob;
            }
            else
            {
                dobTimePicker.Value = new DateTime(2000, 1, 1);
            }

            // Change to Update mode
            btnSave.Text = "💾 Update";
            btnSave.Tag = patientID; // Store original ID for update
            btnSave.BackColor = Color.Orange; // Visual cue for edit mode

            // Highlight selected row
            dgvPatients.ClearSelection();
            dgvPatients.Rows[rowIndex].Selected = true;
        }

        // NEW: Delete button click handler
        private void dgvPatients_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if delete button was clicked
            if (e.ColumnIndex != dgvPatients.Columns["Delete"]?.Index || e.RowIndex < 0)
                return;

            string patientID = dgvPatients.Rows[e.RowIndex].Cells["IDNumber"]?.Value?.ToString();

            if (string.IsNullOrEmpty(patientID)) return;

            // Get patient name for confirmation message
            string patientName = dgvPatients.Rows[e.RowIndex].Cells["PatientName"]?.Value?.ToString();

            DialogResult result = MessageBox.Show(
                $"Are you sure you want to delete patient:\n\n{patientName} ({patientID})?\n\nThis action cannot be undone.",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                bool isDeleted = _patientController.DeletePatient(patientID);

                if (isDeleted)
                {
                    MessageBox.Show("Patient deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Clear form if we just deleted the patient being edited
                    if (btnSave.Tag?.ToString() == patientID)
                    {
                        ClearFields();
                        ResetSaveButton();
                    }

                    RefreshPatientTable();
                }
            }
        }

        // EXISTING: Double-click handler for consultation
        private void dgvPatients_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string patientID = dgvPatients.Rows[e.RowIndex].Cells["IDNumber"]?.Value?.ToString();

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

            // Map columns
            if (dgvPatients.Columns.Count >= 5)
            {
                dgvPatients.Columns["PatientName"].DataPropertyName = "PatientName";
                dgvPatients.Columns["IDNumber"].DataPropertyName = "IDNumber";
                dgvPatients.Columns["PatientType"].DataPropertyName = "PatientType";
                dgvPatients.Columns["Dept"].DataPropertyName = "Dept";
                dgvPatients.Columns["LastVisit"].DataPropertyName = "LastVisit";

                foreach (DataGridViewColumn col in dgvPatients.Columns)
                {
                    if (col.Name != "Delete") // Don't center delete button
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

        // MODIFIED: Handle both Save and Update
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) || string.IsNullOrWhiteSpace(txtIDNumber.Text))
            {
                MessageBox.Show("Please fill in the Name and ID Number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (IsStudentCategory(cmbCategory.Text) && cmbYearLevel.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a Year Level for Student/JDVP patients.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // CHECK: Are we in Update mode?
            if (btnSave.Text == "💾 Update" && btnSave.Tag != null)
            {
                // UPDATE existing patient
                string originalPatientID = btnSave.Tag.ToString();

                bool isUpdated = _patientController.UpdatePatient(
                    originalPatientID,
                    cmbCategory.Text,
                    txtIDNumber.Text,
                    txtFirstName.Text,
                    txtLastName.Text,
                    txtMI.Text,
                    cmbDepartment.Text,
                    txtContact.Text,
                    txtEmergency.Text,
                    cmbYearLevel.Text,
                    dobTimePicker.Value
                );

                if (isUpdated)
                {
                    MessageBox.Show("Patient updated successfully!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields();
                    ResetSaveButton();
                    RefreshPatientTable();
                }
            }
            else
            {
                // CREATE new patient
                bool isSaved = _patientController.RegisterPatient(
                    cmbCategory.Text, txtIDNumber.Text, txtFirstName.Text,
                    txtLastName.Text, txtMI.Text, cmbDepartment.Text,
                    txtContact.Text, txtEmergency.Text,
                    cmbYearLevel.Text,
                    dobTimePicker.Value
                );

                if (isSaved)
                {
                    MessageBox.Show("Patient saved successfully! ✅", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields();
                    RefreshPatientTable();
                }
            }
        }

        // NEW: Add New Patient button handler
        private void btnAddNewPatient_Click(object sender, EventArgs e)
        {
            ClearFields();
            ResetSaveButton();
        }

        // NEW: Reset button to Save mode
        private void ResetSaveButton()
        {
            btnSave.Text = "💾 Save";
            btnSave.Tag = null;
            btnSave.BackColor = Color.Green; // Back to green for add mode

            dgvPatients.ClearSelection();
        }

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

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsStudentCategory(cmbCategory.Text))
            {
                cmbYearLevel.Enabled = true;
                cmbYearLevel.BackColor = Color.White;

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
    }
}