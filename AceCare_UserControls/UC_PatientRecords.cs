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

        public UC_PatientRecords()
        {
            InitializeComponent();
            dgvPatients.AutoGenerateColumns = false;
            InitializeDropdowns();
            DataGridViewStyle.ApplyModernDesign(dgvPatients);
            this.Load += (s, e) => RefreshPatientTable();
        }

        private void InitializeDropdowns()
        {
            cmbCategory.Items.Clear();
            cmbCategory.Items.AddRange(new string[] { "Student", "Faculty", "Staff", "Employee" });
            cmbDepartment.Items.Clear();
            cmbDepartment.Items.AddRange(new string[] { "IICT", "IHTM", "IABM", "ITE", "SHS" });
        }

        public void RefreshPatientTable()
        {
            DataTable dt = _patientController.GetPatients(txtSearch.Text, patientOffset);

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

            dgvPatients.DataSource = dt;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) || string.IsNullOrWhiteSpace(txtIDNumber.Text))
            {
                MessageBox.Show("Please fill in the Name and ID Number.");
                return;
            }

            bool isSaved = _patientController.RegisterPatient(
                cmbCategory.Text, txtIDNumber.Text, txtFirstName.Text,
                txtLastName.Text, txtMI.Text, cmbDepartment.Text,
                txtContact.Text, txtEmergency.Text
            );

            if (isSaved)
            {
                MessageBox.Show("Patient saved successfully!");
                ClearFields();
                RefreshPatientTable();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            patientOffset = 0;
            RefreshPatientTable();
        }

        private void ClearFields()
        {
            txtFirstName.Clear(); txtLastName.Clear(); txtIDNumber.Clear();
            txtMI.Clear(); txtContact.Clear(); txtEmergency.Clear();
            cmbCategory.SelectedIndex = -1; cmbDepartment.SelectedIndex = -1;
        }
    }
}