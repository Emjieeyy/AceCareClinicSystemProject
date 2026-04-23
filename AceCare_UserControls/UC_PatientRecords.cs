using AceCareClinicSystem.Controllers;
using AceCareClinicSystem.Forms;
using AceCareClinicSystem.Services;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace AceCareClinicSystem.AceCare_UserControls
{
    public partial class UC_PatientRecords : UserControl
    {
        private PatientController _patientController = new PatientController();
        private int patientOffset = 0;
        private const int PageSize = 10;
        private bool _isProcessing = false;

        public UC_PatientRecords()
        {
            InitializeComponent();

            dgvPatients.AutoGenerateColumns = false;
            DataGridViewStyle.ApplyModernDesign(dgvPatients);

            InitializeDropdowns();
            InitializeDatePickers();
            InitializeDeleteColumn();

            dgvPatients.CellClick += dgvPatients_CellClick;
            dgvPatients.CellDoubleClick += dgvPatients_CellDoubleClick;
            dgvPatients.CellFormatting += dgvPatients_CellFormatting;
            cmbCategory.SelectedIndexChanged += cmbCategory_SelectedIndexChanged;

            this.Load += (s, e) =>
            {
                SetAddMode();
                RefreshPatientTable();
            };
        }

        // ===========================
        // MODE HANDLING
        // ===========================
        private void SetAddMode()
        {
            btnSave.Text = "Save";
            btnSave.Tag = null;
            btnSave.BackColor = Color.LimeGreen;

            btnClear.Text = "Clear";
            btnClear.BackColor = Color.OrangeRed;
            btnClear.Enabled = true;

            dgvPatients.ClearSelection();
        }

        private void SetEditMode(string patientID)
        {
            btnSave.Text = "Update";
            btnSave.Tag = patientID;
            btnSave.BackColor = Color.DodgerBlue;

            btnClear.Text = "Cancel";
            btnClear.BackColor = Color.Orange;
        }

        // ===========================
        // DELETE COLUMN (RED X)
        // ===========================
        private void InitializeDeleteColumn()
        {
            if (dgvPatients.Columns["Delete"] == null)
            {
                DataGridViewButtonColumn deleteBtn = new DataGridViewButtonColumn();
                deleteBtn.Name = "Delete";
                deleteBtn.HeaderText = "";
                deleteBtn.Text = "X";
                deleteBtn.UseColumnTextForButtonValue = true;
                deleteBtn.FlatStyle = FlatStyle.Flat;
                deleteBtn.Width = 40;

                deleteBtn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                deleteBtn.DefaultCellStyle.ForeColor = Color.Red;
                deleteBtn.DefaultCellStyle.SelectionForeColor = Color.Red;
                deleteBtn.DefaultCellStyle.BackColor = Color.White;
                deleteBtn.DefaultCellStyle.SelectionBackColor = Color.LightPink;
                deleteBtn.DefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);

                dgvPatients.Columns.Add(deleteBtn);
            }
            dgvPatients.Columns["Delete"].DisplayIndex = dgvPatients.Columns.Count - 1;
        }

        // ===========================
        // LOAD TABLE
        // ===========================
        public void RefreshPatientTable()
        {
            DataTable dt = _patientController.GetPatients(txtSearch.Text, patientOffset);

            if (dt.Rows.Count == 0 && patientOffset > 0)
            {
                MessageBox.Show("No more records to display.", "End of List");
                patientOffset -= PageSize;
                return;
            }

            BindingHelper.BindToGrid(dgvPatients, dt);

            if (dgvPatients.Columns.Count >= 5)
            {
                dgvPatients.Columns["PatientName"].DataPropertyName = "PatientName";
                dgvPatients.Columns["IDNumber"].DataPropertyName = "IDNumber";
                dgvPatients.Columns["PatientType"].DataPropertyName = "PatientType";
                dgvPatients.Columns["Dept"].DataPropertyName = "Dept";
                dgvPatients.Columns["LastVisit"].DataPropertyName = "LastVisit";

                foreach (DataGridViewColumn col in dgvPatients.Columns)
                {
                    if (col.Name != "Delete")
                        col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }

            InitializeDeleteColumn();
            btnPrev.Enabled = (patientOffset > 0);
        }

        // ===========================
        // GRID EVENTS
        // ===========================
        private void dgvPatients_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvPatients.Columns[e.ColumnIndex].Name == "Delete" && e.RowIndex >= 0)
            {
                e.Value = "X";
                e.CellStyle.ForeColor = Color.Red;
                e.CellStyle.SelectionForeColor = Color.DarkRed;
                e.CellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                e.FormattingApplied = true;
            }
        }

        private void dgvPatients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvPatients.Columns[e.ColumnIndex].Name == "Delete")
            {
                string id = dgvPatients.Rows[e.RowIndex].Cells["IDNumber"]?.Value?.ToString();
                string name = dgvPatients.Rows[e.RowIndex].Cells["PatientName"]?.Value?.ToString();

                if (string.IsNullOrEmpty(id)) return;

                if (MessageBox.Show($"Delete {name} ({id})?", "Confirm Delete",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (_patientController.DeletePatient(id))
                    {
                        MessageBox.Show("Deleted successfully.", "Success");

                        if (btnSave.Tag?.ToString() == id)
                        {
                            ClearFields();
                            SetAddMode();
                        }

                        RefreshPatientTable();
                    }
                }
                return;
            }

            LoadPatientIntoForm(e.RowIndex);
        }

        private void dgvPatients_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string id = dgvPatients.Rows[e.RowIndex].Cells["IDNumber"]?.Value?.ToString();
            DataRow p = _patientController.GetPatientById(id);
            if (p == null) return;

            UC_ConsultationWizard wizard = new UC_ConsultationWizard();

            wizard.LoadPatientData(
                patientID: p["patient_number"].ToString(),
                firstName: p["first_name"].ToString(),
                lastName: p["last_name"].ToString(),
                middleInitial: p["middle_initial"].ToString(),
                category: p["category"].ToString(),
                department: p["department"]?.ToString() ?? "",
                dateOfBirth: p["date_of_birth"] != DBNull.Value ? Convert.ToDateTime(p["date_of_birth"]) : DateTime.Now,
                contact: p["contact_number"].ToString(),
                emergencyContactNumber: p["emergency_contact_number"].ToString(),
                emergencyContactName: p["emergency_contact_name"].ToString(),
                yearLevel: p["year_level"]?.ToString() ?? "",
                age: p["age"] != DBNull.Value ? Convert.ToInt32(p["age"]) : (int?)null,
                sex: p["sex"]?.ToString() ?? "",
                address: p["address"]?.ToString() ?? ""
            );

            if (this.ParentForm is AdminDashboard adminMain)
            {
                adminMain.addUserControl(wizard);
            }
            else if (this.ParentForm is ClinicStaffDashboard staffMain)
            {
                staffMain.addUserControl(wizard);
            }
        }

        // ===========================
        // LOAD FORM DATA
        // ===========================
        private void LoadPatientIntoForm(int rowIndex)
        {
            string patientID = dgvPatients.Rows[rowIndex].Cells["IDNumber"]?.Value?.ToString();
            DataRow patient = _patientController.GetPatientById(patientID);
            if (patient == null) return;

            txtIDNumber.Text = patient["patient_number"].ToString();
            txtFirstName.Text = patient["first_name"].ToString();
            txtLastName.Text = patient["last_name"].ToString();
            txtMI.Text = patient["middle_initial"].ToString();
            txtContact.Text = patient["contact_number"].ToString();
            txtEmergencyContactName.Text = patient["emergency_contact_name"].ToString();
            txtEmergencyContactNo.Text = patient["emergency_contact_number"].ToString();
            cmbCategory.Text = patient["category"].ToString();
            cmbDepartment.Text = patient["department"]?.ToString() ?? "";

            // Age, Sex, Address — matching your DB types
            txtAge.Text = patient["age"] != DBNull.Value ? patient["age"].ToString() : "";
            cmbSex.Text = patient["sex"] != DBNull.Value ? patient["sex"].ToString() : "";
            txtAddress.Text = patient["address"] != DBNull.Value ? patient["address"].ToString() : "";

            if (patient["year_level"] != DBNull.Value)
                cmbYearLevel.Text = patient["year_level"].ToString();
            else
                cmbYearLevel.SelectedIndex = -1;

            if (patient["date_of_birth"] != DBNull.Value &&
                DateTime.TryParse(patient["date_of_birth"].ToString(), out DateTime dob))
                dobTimePicker.Value = dob;
            else
                dobTimePicker.Value = new DateTime(2000, 1, 1);

            ApplyCategoryRules(cmbCategory.Text);
            SetEditMode(patientID);

            dgvPatients.ClearSelection();
            dgvPatients.Rows[rowIndex].Selected = true;
        }

        // ===========================
        // BUTTON EVENTS
        // ===========================
        private void btnAddNewPatient_Click(object sender, EventArgs e)
        {
            if (_isProcessing) return;
            ClearFields();
            SetAddMode();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (_isProcessing) return;
            ClearFields();
            SetAddMode();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_isProcessing) return;
            _isProcessing = true;

            try
            {
                if (string.IsNullOrWhiteSpace(txtFirstName.Text) || string.IsNullOrWhiteSpace(txtIDNumber.Text))
                {
                    MessageBox.Show("Please fill in Name and ID Number.", "Validation Error");
                    return;
                }

                if (IsStudentCategory(cmbCategory.Text) && cmbYearLevel.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select Year Level.", "Validation Error");
                    return;
                }

                if (RequiresDepartment(cmbCategory.Text) && string.IsNullOrWhiteSpace(cmbDepartment.Text))
                {
                    MessageBox.Show("Please select Department.", "Validation Error");
                    return;
                }

                bool success = false;
                string yearLevelValue = IsStudentCategory(cmbCategory.Text) ? cmbYearLevel.Text : "";
                string departmentValue = RequiresDepartment(cmbCategory.Text) ? cmbDepartment.Text : "N/A";

                // Parse age as int (matches your DB schema int(11))
                int? ageValue = null;
                if (!string.IsNullOrWhiteSpace(txtAge.Text) && int.TryParse(txtAge.Text.Trim(), out int parsedAge))
                    ageValue = parsedAge;

                string sexValue = cmbSex.Text;
                string addressValue = txtAddress.Text.Trim();

                if (btnSave.Text == "Update" && btnSave.Tag != null)
                {
                    string originalID = btnSave.Tag.ToString();
                    success = _patientController.UpdatePatient(
                        originalID,
                        cmbCategory.Text,
                        txtIDNumber.Text.Trim(),
                        txtFirstName.Text.Trim(),
                        txtLastName.Text.Trim(),
                        txtMI.Text.Trim(),
                        departmentValue,
                        txtContact.Text.Trim(),
                        txtEmergencyContactName.Text.Trim(),
                        txtEmergencyContactNo.Text.Trim(),
                        yearLevelValue,
                        dobTimePicker.Value,
                        sexValue,
                        ageValue,
                        addressValue
                    );
                }
                else
                {
                    var existing = _patientController.GetPatientById(txtIDNumber.Text.Trim());
                    if (existing != null)
                    {
                        MessageBox.Show($"Patient ID '{txtIDNumber.Text}' already exists!", "Duplicate ID",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    success = _patientController.RegisterPatient(
                        cmbCategory.Text,
                        txtIDNumber.Text.Trim(),
                        txtFirstName.Text.Trim(),
                        txtLastName.Text.Trim(),
                        txtMI.Text.Trim(),
                        departmentValue,
                        txtContact.Text.Trim(),
                        txtEmergencyContactName.Text.Trim(),
                        txtEmergencyContactNo.Text.Trim(),
                        yearLevelValue,
                        dobTimePicker.Value,
                        sexValue,
                        ageValue,
                        addressValue
                    );
                }

                if (success)
                {
                    MessageBox.Show(btnSave.Text == "Update" ? "Updated successfully!" : "Saved successfully!", "Success");
                    ClearFields();
                    SetAddMode();
                    RefreshPatientTable();
                }
            }
            finally
            {
                _isProcessing = false;
            }
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            patientOffset = 0;
            RefreshPatientTable();
        }

        private void ReloadPix_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            patientOffset = 0;
            RefreshPatientTable();
        }

        // ===========================
        // CATEGORY HANDLING
        // ===========================
        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyCategoryRules(cmbCategory.Text);
        }

        private void ApplyCategoryRules(string category)
        {
            if (IsDepartmentDisabled(category))
            {
                cmbDepartment.Enabled = false;
                cmbDepartment.BackColor = Color.LightGray;
                cmbDepartment.SelectedIndex = -1;
            }
            else
            {
                cmbDepartment.Enabled = true;
                cmbDepartment.BackColor = Color.White;
            }

            if (IsStudentCategory(category))
            {
                cmbYearLevel.Enabled = true;
                cmbYearLevel.BackColor = Color.White;

                if (category == "JDVP")
                    cmbYearLevel.SelectedItem = "Grade 12";
            }
            else
            {
                cmbYearLevel.Enabled = false;
                cmbYearLevel.BackColor = Color.LightGray;
                cmbYearLevel.SelectedIndex = -1;
            }
        }

        private bool IsDepartmentDisabled(string category)
        {
            return category == "JDVP" ||
                   category == "Teaching Staff" ||
                   category == "Non-Teaching Staff" ||
                   category == "Employee" ||
                   category == "Visitor";
        }

        private bool RequiresDepartment(string category)
        {
            return category == "Student" || category == "Faculty";
        }

        private bool IsStudentCategory(string category)
        {
            return category == "Student" || category == "JDVP";
        }

        // ===========================
        // HELPERS
        // ===========================
        private void InitializeDropdowns()
        {
            cmbCategory.Items.AddRange(new string[] {
                "Student", "Faculty", "Teaching Staff",
                "Non-Teaching Staff", "Employee", "JDVP", "Visitor"
            });

            cmbDepartment.Items.AddRange(new string[] {
                "IICT", "IHTM", "IABM", "ITE", "SHS"
            });

            cmbYearLevel.Items.AddRange(new string[] {
                "1st Year", "2nd Year", "3rd Year",
                "4th Year", "Grade 11", "Grade 12"
            });

            cmbSex.Items.AddRange(new string[] { "Male", "Female" });
        }

        private void InitializeDatePickers()
        {
            dobTimePicker.Format = DateTimePickerFormat.Short;
            dobTimePicker.MaxDate = DateTime.Now;
            dobTimePicker.Value = new DateTime(2000, 1, 1);
        }

        private void ClearFields()
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            txtIDNumber.Clear();
            txtMI.Clear();
            txtContact.Clear();
            txtEmergencyContactName.Clear();
            txtEmergencyContactNo.Clear();
            txtAge.Clear();
            txtAddress.Clear();
            cmbSex.SelectedIndex = -1;

            cmbCategory.SelectedIndex = -1;
            cmbDepartment.SelectedIndex = -1;
            cmbYearLevel.SelectedIndex = -1;

            cmbDepartment.Enabled = true;
            cmbDepartment.BackColor = Color.White;
            cmbYearLevel.Enabled = true;
            cmbYearLevel.BackColor = Color.White;

            dobTimePicker.Value = new DateTime(2000, 1, 1);
        }

        private void txtIDNumber_TextChanged(object sender, EventArgs e) { }
        private void label8_Click(object sender, EventArgs e) { }
        private void label12_Click(object sender, EventArgs e) { }
    }
}