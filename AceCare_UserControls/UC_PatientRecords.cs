using AceCareClinicSystem.Controllers;
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

        public event Action<DataRow> PatientSelectedForConsultation;

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

            btnClear.Click += btnClear_Click;
            btnSave.Click += btnSave_Click;
            btnNext.Click += btnNext_Click;
            btnPrev.Click += btnPrev_Click;
            btnSearch.Click += btnSearch_Click;
            btnAddNewPatient.Click += btnAddNewPatient_Click;

            this.Load += (s, e) =>
            {
                SetAddMode(); // 🔥 default mode
                RefreshPatientTable();
            };
        }

        // ===========================
        // 🔥 MODE HANDLING
        // ===========================
        private void SetAddMode()
        {
            btnSave.Text = "Save";
            btnSave.Tag = null;
            btnSave.BackColor = Color.LimeGreen;

            btnClear.Text = "Clear";
            btnClear.BackColor = Color.OrangeRed;

            dgvPatients.ClearSelection();
        }

        private void SetEditMode(string patientID)
        {
            btnSave.Text = "Update";
            btnSave.Tag = patientID;
            btnSave.BackColor = Color.LightBlue;

            btnClear.Text = "Cancel";
            btnClear.BackColor = Color.Orange;
        }

        // ===========================
        // 🔥 DELETE COLUMN
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
                deleteBtn.DefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);

                dgvPatients.Columns.Add(deleteBtn);
            }

            dgvPatients.Columns["Delete"].DisplayIndex = dgvPatients.Columns.Count - 1;
        }

        // ===========================
        // 🔥 LOAD TABLE
        // ===========================
        public void RefreshPatientTable()
        {
            DataTable dt = _patientController.GetPatients(txtSearch.Text, patientOffset);
            BindingHelper.BindToGrid(dgvPatients, dt);

            InitializeDeleteColumn();

            btnPrev.Enabled = (patientOffset > 0);
        }

        // ===========================
        // 🔥 GRID EVENTS
        // ===========================
        private void dgvPatients_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvPatients.Columns[e.ColumnIndex].Name == "Delete" && e.RowIndex >= 0)
            {
                e.Value = "X"; // 🔥 FIX
                e.CellStyle.ForeColor = Color.Red;
                e.CellStyle.SelectionForeColor = Color.Red;
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

                if (MessageBox.Show($"Delete patient {id}?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (_patientController.DeletePatient(id))
                        RefreshPatientTable();
                }
                return;
            }

            LoadPatientIntoForm(e.RowIndex);
        }

        private void dgvPatients_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string id = dgvPatients.Rows[e.RowIndex].Cells["IDNumber"]?.Value?.ToString();
                DataRow p = _patientController.GetPatientById(id);
                if (p != null) PatientSelectedForConsultation?.Invoke(p);
            }
        }

        // ===========================
        // 🔥 LOAD FORM DATA
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
            cmbDepartment.Text = patient["department"].ToString();
            cmbYearLevel.Text = patient["year_level"]?.ToString() ?? "";

            if (DateTime.TryParse(patient["date_of_birth"].ToString(), out DateTime dob))
                dobTimePicker.Value = dob;

            // 🔥 SWITCH TO EDIT MODE
            SetEditMode(patientID);

            dgvPatients.ClearSelection();
            dgvPatients.Rows[rowIndex].Selected = true;
        }

        // ===========================
        // 🔥 BUTTON EVENTS
        // ===========================
        private void btnAddNewPatient_Click(object sender, EventArgs e)
        {
            ClearFields();
            SetAddMode();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
            SetAddMode();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) || string.IsNullOrWhiteSpace(txtIDNumber.Text))
                return;

            bool success;

            if (btnSave.Text == "Update" && btnSave.Tag != null)
            {
                success = _patientController.UpdatePatient(
                    btnSave.Tag.ToString(),
                    cmbCategory.Text,
                    txtIDNumber.Text,
                    txtFirstName.Text,
                    txtLastName.Text,
                    txtMI.Text,
                    cmbDepartment.Text,
                    txtContact.Text,
                    txtEmergencyContactName.Text,
                    txtEmergencyContactNo.Text,
                    cmbYearLevel.Text,
                    dobTimePicker.Value
                );
            }
            else
            {
                success = _patientController.RegisterPatient(
                    cmbCategory.Text,
                    txtIDNumber.Text,
                    txtFirstName.Text,
                    txtLastName.Text,
                    txtMI.Text,
                    cmbDepartment.Text,
                    txtContact.Text,
                    txtEmergencyContactName.Text,
                    txtEmergencyContactNo.Text,
                    cmbYearLevel.Text,
                    dobTimePicker.Value
                );
            }

            if (success)
            {
                MessageBox.Show("Record updated/saved!");
                ClearFields();
                SetAddMode(); // 🔥 instant reset
                RefreshPatientTable();
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

        // ===========================
        // 🔥 HELPERS
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
        }

        private void InitializeDatePickers()
        {
            dobTimePicker.Format = DateTimePickerFormat.Short;
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

            cmbCategory.SelectedIndex = -1;
            cmbDepartment.SelectedIndex = -1;
            cmbYearLevel.SelectedIndex = -1;

            dobTimePicker.Value = new DateTime(2000, 1, 1);
        }

        private void txtIDNumber_TextChanged(object sender, EventArgs e) { }
        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e) { }
        private void label8_Click(object sender, EventArgs e) { }
    }
}