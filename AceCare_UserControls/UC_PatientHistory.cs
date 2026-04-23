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

<<<<<<< HEAD
        // ⭐ Pagination variables
        private int currentPage = 1;
        private int pageSize = 7;        // Show 7 rows per page (fits your screen)
        private int totalRecords = 0;
        private int totalPages = 0;
        private DataTable allData;       // Store all data for pagination

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
=======
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
>>>>>>> ce99f27ccf54fdef208917347df673532355d7e7
        public int SelectedPatientId
        {
            get { return selectedPatientId; }
            set { selectedPatientId = value; }
        }

        public UC_PatientHistory()
        {
            InitializeComponent();
            controller = new PatientHistoryController();
        }

        public UC_PatientHistory(int patientId) : this()
        {
            selectedPatientId = patientId;
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            if (isInitialized) return;
            isInitialized = true;

            ClearPatientLabels();
            ClearVitalsLabels();

            // ⭐ CRITICAL: Clear designer columns first to avoid conflicts
            dgvPatientHistory.Columns.Clear();
            dgvPatientHistory.AutoGenerateColumns = false;

            // Apply design
            DataGridViewStyle.ApplyModernDesign(dgvPatientHistory);

            // Setup columns
            SetupGridColumns();

            // Setup pagination buttons
            SetupPaginationButtons();

            // Load data with pagination
            LoadAllConsultations();

            if (selectedPatientId > 0)
                SelectPatientRow(selectedPatientId);

            // Wire events
            dgvPatientHistory.CellClick += dgvPatientHistory_CellClick;
            dgvPatientHistory.CellDoubleClick += dgvPatientHistory_CellDoubleClick;
            dgvPatientHistory.CellFormatting += dgvPatientHistory_CellFormatting;
        }

        private void UC_PatientHistory_Load(object sender, EventArgs e) { }

        // ⭐ SETUP PAGINATION BUTTONS
        private void SetupPaginationButtons()
        {
            // Clear existing handlers to avoid duplicates
            ReloadPix.Click -= ReloadPix_Click;
            btnPrev.Click -= btnPrev_Click;
            btnNext.Click -= btnNext_Click;

            ReloadPix.Click += ReloadPix_Click;
            btnPrev.Click += btnPrev_Click;
            btnNext.Click += btnNext_Click;

            UpdatePaginationButtons();
        }

        private void SetupGridColumns()
        {
            // ⭐ IMPORTANT: Set these BEFORE adding columns
            dgvPatientHistory.ScrollBars = ScrollBars.Horizontal;  // Horizontal only since we paginate vertically
            dgvPatientHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvPatientHistory.AllowUserToResizeColumns = true;
            dgvPatientHistory.AllowUserToOrderColumns = true;
            dgvPatientHistory.RowTemplate.Height = 36;            // Taller rows
            dgvPatientHistory.DefaultCellStyle.WrapMode = DataGridViewTriState.False;  // No wrap for clean rows
            dgvPatientHistory.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
            dgvPatientHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPatientHistory.MultiSelect = false;
            dgvPatientHistory.ReadOnly = true;
            dgvPatientHistory.AllowUserToAddRows = false;
            dgvPatientHistory.AllowUserToDeleteRows = false;

            // Hidden columns
            dgvPatientHistory.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "ConsultationId", DataPropertyName = "consultation_id", HeaderText = "ConID", Visible = false });

            dgvPatientHistory.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "PatientId", DataPropertyName = "patient_id", HeaderText = "PID", Visible = false });

            // ⭐ VISIBLE COLUMNS — calculated widths to fit your screen (~1050px usable width)
            // Total: 50+140+75+95+130+140+140+160+110+85+130+180 = 1435px → need horizontal scroll

            dgvPatientHistory.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "DateTime", DataPropertyName = "visit_date", HeaderText = "Date & Time", Width = 135, MinimumWidth = 120 });

            dgvPatientHistory.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "PatientName", DataPropertyName = "patient_name", HeaderText = "Patient Name", Width = 145, MinimumWidth = 130 });

            dgvPatientHistory.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "AgeSex", DataPropertyName = "age_sex", HeaderText = "Age/Sex", Width = 70, MinimumWidth = 65 });

            dgvPatientHistory.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "VisitType", DataPropertyName = "visit_type", HeaderText = "Visit Type", Width = 90, MinimumWidth = 80 });

            dgvPatientHistory.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "ChiefComplaint", DataPropertyName = "chief_complaint", HeaderText = "Chief Complaint", Width = 130, MinimumWidth = 110 });

            dgvPatientHistory.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "Vitals", DataPropertyName = "vitals_summary", HeaderText = "Vitals", Width = 125, MinimumWidth = 110 });

            // ⭐ NEW: Vitals Recorded timestamp column
            dgvPatientHistory.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "VitalsRecorded", DataPropertyName = "vitals_recorded_at", HeaderText = "Vitals Recorded", Width = 135, MinimumWidth = 120 });

            dgvPatientHistory.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "Diagnosis", DataPropertyName = "diagnosis", HeaderText = "Diagnosis", Width = 150, MinimumWidth = 130 });

            dgvPatientHistory.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "Medicine", DataPropertyName = "medicine_name", HeaderText = "Medicine", Width = 105, MinimumWidth = 90 });

            dgvPatientHistory.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "Outcome", DataPropertyName = "outcome", HeaderText = "Outcome", Width = 100, MinimumWidth = 85 });

            dgvPatientHistory.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "Status", DataPropertyName = "status", HeaderText = "Status", Width = 85, MinimumWidth = 75 });

            dgvPatientHistory.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "HandledBy", DataPropertyName = "handled_by", HeaderText = "Handled By", Width = 130, MinimumWidth = 110 });

            dgvPatientHistory.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "Remarks", DataPropertyName = "remarks", HeaderText = "Remarks", Width = 160, MinimumWidth = 140 });

            // Header style
            dgvPatientHistory.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 58, 95);  // AceCare dark blue
            dgvPatientHistory.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvPatientHistory.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            dgvPatientHistory.ColumnHeadersHeight = 32;
            dgvPatientHistory.EnableHeadersVisualStyles = false;
        }

        // ⭐ COLOR CODING
        private void dgvPatientHistory_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvPatientHistory.Columns[e.ColumnIndex].Name == "Status" && e.Value != null)
            {
                string status = e.Value.ToString().ToLower();
                if (status == "completed")
                {
                    e.CellStyle.ForeColor = Color.FromArgb(39, 103, 73);
                    e.CellStyle.BackColor = Color.FromArgb(198, 246, 213);
                    e.CellStyle.Font = new Font(dgvPatientHistory.Font, FontStyle.Bold);
                }
                else if (status == "referred")
                {
                    e.CellStyle.ForeColor = Color.FromArgb(192, 86, 33);
                    e.CellStyle.BackColor = Color.FromArgb(254, 235, 200);
                    e.CellStyle.Font = new Font(dgvPatientHistory.Font, FontStyle.Bold);
                }
                else if (status == "pending")
                {
                    e.CellStyle.ForeColor = Color.FromArgb(183, 121, 31);
                    e.CellStyle.BackColor = Color.FromArgb(254, 252, 191);
                }
            }

            if (dgvPatientHistory.Columns[e.ColumnIndex].Name == "VisitType" && e.Value != null)
            {
                string type = e.Value.ToString().ToLower();
                if (type == "emergency")
                {
                    e.CellStyle.ForeColor = Color.FromArgb(197, 48, 48);
                    e.CellStyle.BackColor = Color.FromArgb(254, 215, 215);
                }
                else if (type == "consultation")
                {
                    e.CellStyle.ForeColor = Color.FromArgb(43, 108, 176);
                    e.CellStyle.BackColor = Color.FromArgb(235, 248, 255);
                }
                else if (type == "first aid")
                {
                    e.CellStyle.ForeColor = Color.FromArgb(151, 90, 22);
                    e.CellStyle.BackColor = Color.FromArgb(254, 252, 191);
                }
            }
        }

        // ⭐ PAGINATION METHODS
        private void LoadAllConsultations()
        {
            allData = controller.GetAllConsultationsList();
            totalRecords = allData.Rows.Count;
            totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            if (totalPages == 0) totalPages = 1;
            if (currentPage > totalPages) currentPage = totalPages;
            if (currentPage < 1) currentPage = 1;

            LoadPage();
        }

        private void LoadPage()
        {
            DataTable pageData = allData.Clone();

            int startIndex = (currentPage - 1) * pageSize;
            int endIndex = Math.Min(startIndex + pageSize, totalRecords);

            for (int i = startIndex; i < endIndex; i++)
            {
                pageData.ImportRow(allData.Rows[i]);
            }

            dgvPatientHistory.DataSource = null;
            BindingHelper.BindToGrid(dgvPatientHistory, pageData);

            UpdatePaginationButtons();
        }

        private void UpdatePaginationButtons()
        {
            btnPrev.Enabled = currentPage > 1;
            btnNext.Enabled = currentPage < totalPages;

            // Optional: Show page info on ReloadPix or a label
            // lblPageInfo.Text = $"Page {currentPage} of {totalPages} ({totalRecords} records)";
        }

        // ⭐ BUTTON HANDLERS
        private void ReloadPix_Click(object sender, EventArgs e)
        {
            currentPage = 1;
            LoadAllConsultations();

            // Clear selection
            dgvPatientHistory.ClearSelection();
            ClearPatientLabels();
            ClearVitalsLabels();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadPage();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;
                LoadPage();
            }
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
            if (lblVitalsTimestamp != null)
            {
                lblVitalsTimestamp.Text = "No records";
                lblVitalsTimestamp.ForeColor = Color.Gray;
            }
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

                if (r["visit_date"] != DBNull.Value)
                {
                    DateTime recordedAt = Convert.ToDateTime(r["visit_date"]);
                    lblVitalsTimestamp.Text = "Recorded: " + recordedAt.ToString("MMM dd, yyyy @ hh:mm tt");
                    lblVitalsTimestamp.ForeColor = Color.FromArgb(100, 116, 139);
                    lblVitalsTimestamp.Font = new Font(this.Font.FontFamily, 9, FontStyle.Italic);
                }
                else
                {
                    lblVitalsTimestamp.Text = "Recorded: Unknown date";
                    lblVitalsTimestamp.ForeColor = Color.Gray;
                }
            }
            else
            {
                ClearVitalsLabels();
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