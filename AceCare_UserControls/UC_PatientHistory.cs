using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using AceCareClinicSystem.Controllers;
using AceCareClinicSystem.Services;
using System.ComponentModel;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Kernel.Font;
using iText.IO.Font.Constants;

namespace AceCareClinicSystem.AceCare_UserControls
{
    public partial class UC_PatientHistory : UserControl
    {
        private PatientHistoryController controller;
        private int selectedPatientId = 0;
        private bool isInitialized = false;

        // Pagination
        private int currentPage = 1;
        private int pageSize = 7;
        private int totalRecords = 0;
        private int totalPages = 0;
        private DataTable allData;
        private DataTable filteredData;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
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

            dgvPatientHistory.Columns.Clear();
            dgvPatientHistory.AutoGenerateColumns = false;

            DataGridViewStyle.ApplyModernDesign(dgvPatientHistory);
            SetupGridColumns();

            ReloadPix.Click += ReloadPix_Click;
            btnPrev.Click += btnPrev_Click;
            btnNext.Click += btnNext_Click;
            btnSearch.Click += btnSearch_Click;

            txtSearch.KeyDown += TxtSearch_KeyDown;

            LoadAllConsultations();

            if (selectedPatientId > 0)
                SelectPatientRow(selectedPatientId);

            dgvPatientHistory.CellClick += dgvPatientHistory_CellClick;
            dgvPatientHistory.CellDoubleClick += dgvPatientHistory_CellDoubleClick;
            dgvPatientHistory.CellFormatting += dgvPatientHistory_CellFormatting;
            dgvPatientHistory.CellMouseEnter += dgvPatientHistory_CellMouseEnter;
        }

        private void UC_PatientHistory_Load(object sender, EventArgs e) { }

        private void SetupGridColumns()
        {
            dgvPatientHistory.ScrollBars = ScrollBars.Horizontal;
            dgvPatientHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvPatientHistory.AllowUserToResizeColumns = true;
            dgvPatientHistory.RowTemplate.Height = 36;
            dgvPatientHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPatientHistory.MultiSelect = false;
            dgvPatientHistory.ReadOnly = true;
            dgvPatientHistory.AllowUserToAddRows = false;
            dgvPatientHistory.AllowUserToDeleteRows = false;

            dgvPatientHistory.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "ConsultationId", DataPropertyName = "consultation_id", Visible = false });

            dgvPatientHistory.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "PatientId", DataPropertyName = "patient_id", Visible = false });

            dgvPatientHistory.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "DateTime", DataPropertyName = "visit_date", HeaderText = "Date & Time", Width = 135 });

            dgvPatientHistory.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "PatientName", DataPropertyName = "patient_name", HeaderText = "Patient Name", Width = 145 });

            dgvPatientHistory.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "AgeSex", DataPropertyName = "age_sex", HeaderText = "Age/Sex", Width = 70 });

            dgvPatientHistory.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "VisitType", DataPropertyName = "visit_type", HeaderText = "Visit Type", Width = 90 });

            dgvPatientHistory.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "ChiefComplaint", DataPropertyName = "chief_complaint", HeaderText = "Chief Complaint", Width = 130 });

            dgvPatientHistory.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "Vitals", DataPropertyName = "vitals_summary", HeaderText = "Vitals", Width = 125 });

            dgvPatientHistory.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "VitalsRecorded", DataPropertyName = "vitals_recorded_at", HeaderText = "Vitals Recorded", Width = 135 });

            dgvPatientHistory.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "Diagnosis", DataPropertyName = "diagnosis", HeaderText = "Diagnosis", Width = 150 });

            dgvPatientHistory.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "Medicine", DataPropertyName = "medicine_name", HeaderText = "Medicine", Width = 105 });

            dgvPatientHistory.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "Outcome", DataPropertyName = "outcome", HeaderText = "Outcome", Width = 100 });

            dgvPatientHistory.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "Status", DataPropertyName = "status", HeaderText = "Status", Width = 85 });

            dgvPatientHistory.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "HandledBy", DataPropertyName = "handled_by", HeaderText = "Handled By", Width = 130 });

            dgvPatientHistory.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "Remarks", DataPropertyName = "remarks", HeaderText = "Remarks", Width = 160 });

            dgvPatientHistory.Columns["Remarks"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvPatientHistory.Columns["Diagnosis"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvPatientHistory.Columns["ChiefComplaint"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvPatientHistory.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;

            dgvPatientHistory.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(30, 58, 95);
            dgvPatientHistory.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            dgvPatientHistory.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Bold);
            dgvPatientHistory.ColumnHeadersHeight = 32;
            dgvPatientHistory.EnableHeadersVisualStyles = false;
        }

        private void dgvPatientHistory_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvPatientHistory.Columns[e.ColumnIndex].Name == "Status" && e.Value != null)
            {
                string status = e.Value.ToString().ToLower();
                if (status == "completed")
                {
                    e.CellStyle.ForeColor = System.Drawing.Color.FromArgb(39, 103, 73);
                    e.CellStyle.BackColor = System.Drawing.Color.FromArgb(198, 246, 213);
                    e.CellStyle.Font = new System.Drawing.Font(dgvPatientHistory.Font, System.Drawing.FontStyle.Bold);
                }
                else if (status == "referred")
                {
                    e.CellStyle.ForeColor = System.Drawing.Color.FromArgb(192, 86, 33);
                    e.CellStyle.BackColor = System.Drawing.Color.FromArgb(254, 235, 200);
                    e.CellStyle.Font = new System.Drawing.Font(dgvPatientHistory.Font, System.Drawing.FontStyle.Bold);
                }
                else if (status == "pending")
                {
                    e.CellStyle.ForeColor = System.Drawing.Color.FromArgb(183, 121, 31);
                    e.CellStyle.BackColor = System.Drawing.Color.FromArgb(254, 252, 191);
                }
            }

            if (dgvPatientHistory.Columns[e.ColumnIndex].Name == "VisitType" && e.Value != null)
            {
                string type = e.Value.ToString().ToLower();
                if (type == "emergency")
                {
                    e.CellStyle.ForeColor = System.Drawing.Color.FromArgb(197, 48, 48);
                    e.CellStyle.BackColor = System.Drawing.Color.FromArgb(254, 215, 215);
                }
                else if (type == "consultation")
                {
                    e.CellStyle.ForeColor = System.Drawing.Color.FromArgb(43, 108, 176);
                    e.CellStyle.BackColor = System.Drawing.Color.FromArgb(235, 248, 255);
                }
                else if (type == "first aid")
                {
                    e.CellStyle.ForeColor = System.Drawing.Color.FromArgb(151, 90, 22);
                    e.CellStyle.BackColor = System.Drawing.Color.FromArgb(254, 252, 191);
                }
            }
        }

        private void dgvPatientHistory_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            string colName = dgvPatientHistory.Columns[e.ColumnIndex].Name;
            if (colName == "Remarks" || colName == "Diagnosis" || colName == "ChiefComplaint" || colName == "Medicine")
            {
                string cellText = dgvPatientHistory.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();
                if (!string.IsNullOrEmpty(cellText) && cellText.Length > 15)
                {
                    dgvPatientHistory.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = cellText;
                }
            }
        }

        private void LoadAllConsultations()
        {
            allData = controller.GetAllConsultationsList();
            filteredData = null;
            totalRecords = allData.Rows.Count;
            totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
            if (totalPages == 0) totalPages = 1;
            if (currentPage > totalPages) currentPage = totalPages;
            if (currentPage < 1) currentPage = 1;

            LoadPage();
        }

        private void LoadPage()
        {
            DataTable sourceData = filteredData ?? allData;
            totalRecords = sourceData.Rows.Count;
            totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
            if (totalPages == 0) totalPages = 1;

            DataTable pageData = sourceData.Clone();
            int startIndex = (currentPage - 1) * pageSize;
            int endIndex = Math.Min(startIndex + pageSize, totalRecords);

            for (int i = startIndex; i < endIndex; i++)
            {
                pageData.ImportRow(sourceData.Rows[i]);
            }

            dgvPatientHistory.DataSource = null;
            BindingHelper.BindToGrid(dgvPatientHistory, pageData);

            UpdatePaginationButtons();
        }

        private void UpdatePaginationButtons()
        {
            btnPrev.Enabled = currentPage > 1;
            btnNext.Enabled = currentPage < totalPages;
        }

        private void ReloadPix_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            currentPage = 1;
            filteredData = null;
            LoadAllConsultations();
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

        private void TxtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnSearch_Click(sender, e);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string search = txtSearch.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(search))
            {
                filteredData = null;
                currentPage = 1;
                LoadPage();
                return;
            }

            filteredData = allData.Clone();
            foreach (DataRow row in allData.Rows)
            {
                if (row["patient_name"].ToString().ToLower().Contains(search) ||
                    row["chief_complaint"].ToString().ToLower().Contains(search) ||
                    row["handled_by"].ToString().ToLower().Contains(search) ||
                    row["visit_type"].ToString().ToLower().Contains(search) ||
                    row["diagnosis"].ToString().ToLower().Contains(search))
                {
                    filteredData.ImportRow(row);
                }
            }

            currentPage = 1;
            LoadPage();
        }

        // ⭐ EXPORT TO PDF ONLY
        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable exportData = controller.GetAllConsultationsList();

                if (exportData.Rows.Count == 0)
                {
                    MessageBox.Show("No data to export.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "PDF Files (*.pdf)|*.pdf";
                saveDialog.FileName = $"AceCare_PatientHistory_{DateTime.Now:yyyyMMdd_HHmm}.pdf";
                saveDialog.Title = "Export Patient History";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    using (PdfWriter writer = new PdfWriter(saveDialog.FileName))
                    {
                        using (PdfDocument pdf = new PdfDocument(writer))
                        {
                            pdf.SetDefaultPageSize(iText.Kernel.Geom.PageSize.A4.Rotate());
                            Document document = new Document(pdf);

                            PdfFont boldFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
                            PdfFont normalFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

                            document.Add(new Paragraph("AceCare Clinic Management System")
                                .SetTextAlignment(TextAlignment.CENTER)
                                .SetFontSize(20)
                                .SetFont(boldFont));

                            document.Add(new Paragraph("Patient History Report")
                                .SetTextAlignment(TextAlignment.CENTER)
                                .SetFontSize(14)
                                .SetFontColor(iText.Kernel.Colors.ColorConstants.DARK_GRAY));

                            document.Add(new Paragraph($"Generated: {DateTime.Now:MMMM dd, yyyy HH:mm}")
                                .SetTextAlignment(TextAlignment.CENTER)
                                .SetFontSize(10));

                            document.Add(new Paragraph("\n"));

                            document.Add(new Paragraph($"Total Records: {exportData.Rows.Count}")
                                .SetFont(boldFont).SetFontSize(11));

                            if (filteredData != null)
                            {
                                document.Add(new Paragraph($"Search Filter: {txtSearch.Text}")
                                    .SetFontSize(10));
                            }

                            document.Add(new Paragraph("\n"));

                            float[] columnWidths = { 12, 12, 8, 10, 12, 10, 12, 12, 10, 10, 10, 12, 12 };
                            Table table = new Table(UnitValue.CreatePercentArray(columnWidths)).UseAllAvailableWidth();

                            string[] headers = { "Date & Time", "Patient Name", "Age/Sex", "Visit Type",
                                "Chief Complaint", "Vitals", "Vitals Recorded", "Diagnosis", "Medicine",
                                "Outcome", "Status", "Handled By", "Remarks" };

                            foreach (string header in headers)
                            {
                                table.AddHeaderCell(new Cell()
                                    .Add(new Paragraph(header).SetFont(boldFont).SetFontSize(8))
                                    .SetBackgroundColor(iText.Kernel.Colors.ColorConstants.LIGHT_GRAY));
                            }

                            for (int row = 0; row < exportData.Rows.Count; row++)
                            {
                                DataRow dr = exportData.Rows[row];
                                table.AddCell(new Paragraph(dr["visit_date"]?.ToString() ?? "N/A").SetFontSize(7));
                                table.AddCell(new Paragraph(dr["patient_name"]?.ToString() ?? "N/A").SetFontSize(7));
                                table.AddCell(new Paragraph(dr["age_sex"]?.ToString() ?? "N/A").SetFontSize(7));
                                table.AddCell(new Paragraph(dr["visit_type"]?.ToString() ?? "N/A").SetFontSize(7));
                                table.AddCell(new Paragraph(dr["chief_complaint"]?.ToString() ?? "N/A").SetFontSize(7));
                                table.AddCell(new Paragraph(dr["vitals_summary"]?.ToString() ?? "N/A").SetFontSize(7));
                                table.AddCell(new Paragraph(dr["vitals_recorded_at"]?.ToString() ?? "N/A").SetFontSize(7));
                                table.AddCell(new Paragraph(dr["diagnosis"]?.ToString() ?? "N/A").SetFontSize(7));
                                table.AddCell(new Paragraph(dr["medicine_name"]?.ToString() ?? "N/A").SetFontSize(7));
                                table.AddCell(new Paragraph(dr["outcome"]?.ToString() ?? "N/A").SetFontSize(7));
                                table.AddCell(new Paragraph(dr["status"]?.ToString() ?? "N/A").SetFontSize(7));
                                table.AddCell(new Paragraph(dr["handled_by"]?.ToString() ?? "N/A").SetFontSize(7));
                                table.AddCell(new Paragraph(dr["remarks"]?.ToString() ?? "N/A").SetFontSize(7));
                            }

                            document.Add(table);
                            document.Close();
                        }
                    }

                    MessageBox.Show($"Exported {exportData.Rows.Count} records to PDF successfully!",
                        "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Export failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                lblVitalsTimestamp.ForeColor = System.Drawing.Color.Gray;
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
                    lblVitalsTimestamp.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
                    lblVitalsTimestamp.Font = new System.Drawing.Font(this.Font.FontFamily, 9, System.Drawing.FontStyle.Italic);
                }
                else
                {
                    lblVitalsTimestamp.Text = "Recorded: Unknown date";
                    lblVitalsTimestamp.ForeColor = System.Drawing.Color.Gray;
                }
            }
            else
            {
                ClearVitalsLabels();
            }
        }

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
        private void txtSearch_TextChanged(object sender, EventArgs e) { }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}