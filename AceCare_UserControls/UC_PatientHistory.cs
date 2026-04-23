using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using AceCareClinicSystem.Controllers;
using AceCareClinicSystem.Services;
using System.ComponentModel;

namespace AceCareClinicSystem.AceCare_UserControls
{
    public partial class UC_PatientHistory : UserControl
    {
        private PatientHistoryController controller;
        private int selectedPatientId = 0;
        private bool isInitialized = false;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int SelectedPatientId
        {
            get { return selectedPatientId; }
            set { selectedPatientId = value; }
        }

        // Default constructor (for menu click)
        public UC_PatientHistory()
        {
            InitializeComponent();
            controller = new PatientHistoryController();
        }

        // Constructor with patient ID (for "View Full History")
        public UC_PatientHistory(int patientId) : this()
        {
            selectedPatientId = patientId;
        }

        // ============================================
        // NUCLEAR FIX: OnHandleCreated fires reliably
        // ============================================
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            if (isInitialized) return;
            isInitialized = true;

            // Clear designer placeholders immediately
            ClearPatientLabels();
            ClearVitalsLabels();

            // Apply design
            DataGridViewStyle.ApplyModernDesign(dgvPatientHistory);

            // Setup columns
            SetupGridColumns();

            // Load data
            LoadAllConsultations();

            // Select patient if pre-selected
            if (selectedPatientId > 0)
                SelectPatientRow(selectedPatientId);

            // Wire events
            dgvPatientHistory.CellClick += dgvPatientHistory_CellClick;
            dgvPatientHistory.CellDoubleClick += dgvPatientHistory_CellDoubleClick;
        }

        // Keep for designer compatibility (won't fire, but safe to have)
        private void UC_PatientHistory_Load(object sender, EventArgs e) { }

        private void SetupGridColumns()
        {
            dgvPatientHistory.AutoGenerateColumns = false;
            dgvPatientHistory.Columns.Clear();

            dgvPatientHistory.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "ConsultationId", DataPropertyName = "consultation_id", HeaderText = "ConID", Width = 50, Visible = false });

            dgvPatientHistory.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "PatientId", DataPropertyName = "patient_id", HeaderText = "PID", Width = 50, Visible = false });

            dgvPatientHistory.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "DateTime", DataPropertyName = "visit_date", HeaderText = "Date & Time", Width = 140 });

            dgvPatientHistory.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "PatientName", DataPropertyName = "patient_name", HeaderText = "Patient Name", Width = 150 });

            dgvPatientHistory.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "AgeSex", DataPropertyName = "age_sex", HeaderText = "Age/Sex", Width = 80 });

            dgvPatientHistory.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "VisitType", DataPropertyName = "visit_type", HeaderText = "Visit Type", Width = 90 });

            dgvPatientHistory.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "ChiefComplaint", DataPropertyName = "chief_complaint", HeaderText = "Chief Complaint", Width = 140 });

            dgvPatientHistory.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "Vitals", DataPropertyName = "vitals_summary", HeaderText = "Vitals", Width = 150 });

            dgvPatientHistory.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "Diagnosis", DataPropertyName = "diagnosis", HeaderText = "Diagnosis", Width = 180 });

            dgvPatientHistory.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "Medicine", DataPropertyName = "medicine_name", HeaderText = "Medicine", Width = 100 });

            dgvPatientHistory.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "Outcome", DataPropertyName = "outcome", HeaderText = "Outcome", Width = 100 });

            dgvPatientHistory.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "Status", DataPropertyName = "status", HeaderText = "Status", Width = 90 });

            dgvPatientHistory.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "HandledBy", DataPropertyName = "handled_by", HeaderText = "Handled By", Width = 120 });

            dgvPatientHistory.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "Remarks", DataPropertyName = "remarks", HeaderText = "Remarks", Width = 200 });

            dgvPatientHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LoadAllConsultations()
        {
            DataTable dt = controller.GetAllConsultationsList();
            BindingHelper.BindToGrid(dgvPatientHistory, dt);
        }

        private void SelectPatientRow(int patientId)
        {
            foreach (DataGridViewRow row in dgvPatientHistory.Rows)
            {
                if (row.Cells["PatientId"].Value != null &&
                    Convert.ToInt32(row.Cells["PatientId"].Value) == patientId)
                {
                    dgvPatientHistory.ClearSelection();
                    row.Selected = true;
                    if (row.Index >= 0)
                        dgvPatientHistory.FirstDisplayedScrollingRowIndex = row.Index;
                    ShowPatientDetails(patientId);
                    break;
                }
            }
        }

        private void ClearPatientLabels()
        {
            lblPatient.Text = "-";
            lblName.Text = "-";
            lblAge.Text = "-";
            lblSex.Text = "-";
            lblDob.Text = "-";
            lblContactNo.Text = "-";
            lblAddress.Text = "-";
        }

        private void ClearVitalsLabels()
        {
            lblTemp.Text = "-";
            lblBP.Text = "-";
            lblPR.Text = "-";
            lblRR.Text = "-";
            lblOxSat.Text = "-";
            lblPF.Text = "-";
        }

        private void dgvPatientHistory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            selectedPatientId = Convert.ToInt32(dgvPatientHistory.Rows[e.RowIndex].Cells["PatientId"].Value);
            ShowPatientDetails(selectedPatientId);
        }

        private void dgvPatientHistory_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvPatientHistory_CellClick(sender, e);
        }

        private void ShowPatientDetails(int patientId)
        {
            DataTable ptInfo = controller.GetPatientInfo(patientId);
            if (ptInfo.Rows.Count > 0)
            {
                DataRow r = ptInfo.Rows[0];
                lblPatient.Text = r["patient_id"].ToString();
                lblName.Text = r["full_name"].ToString().Trim();
                lblAge.Text = r["age"] != DBNull.Value ? r["age"].ToString() : "N/A";
                lblSex.Text = r["sex"] != DBNull.Value ? r["sex"].ToString() : "N/A";
                lblDob.Text = r["date_of_birth"] != DBNull.Value
                    ? Convert.ToDateTime(r["date_of_birth"]).ToString("MMMM dd, yyyy")
                    : "N/A";
                lblContactNo.Text = r["contact_number"] != DBNull.Value ? r["contact_number"].ToString() : "N/A";
                lblAddress.Text = r["address"] != DBNull.Value ? r["address"].ToString() : "N/A";
            }
            else
            {
                ClearPatientLabels();
            }

            DataTable vitals = controller.GetRecentVitals(patientId);
            if (vitals.Rows.Count > 0)
            {
                DataRow r = vitals.Rows[0];
                lblTemp.Text = r["temperature"] != DBNull.Value ? r["temperature"].ToString() + " °C" : "N/A";
                lblBP.Text = r["blood_pressure"] != DBNull.Value ? r["blood_pressure"].ToString() : "N/A";
                lblPR.Text = r["pulse_rate"] != DBNull.Value ? r["pulse_rate"].ToString() + " bpm" : "N/A";
                lblRR.Text = r["respiratory_rate"] != DBNull.Value ? r["respiratory_rate"].ToString() + " /min" : "N/A";
                lblOxSat.Text = r["oxygen_saturation"] != DBNull.Value ? r["oxygen_saturation"].ToString() + "%" : "N/A";
                lblPF.Text = r["physical_findings"] != DBNull.Value ? r["physical_findings"].ToString() : "N/A";
            }
            else
            {
                lblTemp.Text = "No records";
                lblBP.Text = "No records";
                lblPR.Text = "No records";
                lblRR.Text = "No records";
                lblOxSat.Text = "No records";
                lblPF.Text = "No records";
            }
        }

        // Empty handlers
        private void label1_Click(object sender, EventArgs e) { }
        private void label16_Click(object sender, EventArgs e) { }
        private void lblPatient_Click(object sender, EventArgs e) { }
        private void lblName_Click(object sender, EventArgs e) { }
        private void lblAge_Click(object sender, EventArgs e) { }
        private void lblSex_Click(object sender, EventArgs e) { }
        private void lblDob_Click(object sender, EventArgs e) { }
        private void lblContactNo_Click(object sender, EventArgs e) { }
        private void lblAddress_Click(object sender, EventArgs e) { }
        private void lblTemp_Click(object sender, EventArgs e) { }
        private void lblBP_Click(object sender, EventArgs e) { }
        private void lblPR_Click(object sender, EventArgs e) { }
        private void lblRR_Click(object sender, EventArgs e) { }
        private void panel3_Paint(object sender, PaintEventArgs e) { }
        private void lblOxSat_Click(object sender, EventArgs e) { }
        private void lblPF_Click(object sender, EventArgs e) { }
    }
}