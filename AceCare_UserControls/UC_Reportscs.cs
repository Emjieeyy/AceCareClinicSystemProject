using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AceCareClinicSystem.Controllers;
using AceCareClinicSystem.Forms;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Kernel.Font;
using iText.IO.Font.Constants;
using System.IO;

namespace AceCareClinicSystem.AceCare_UserControls
{
    public partial class UC_Reportscs : UserControl
    {
        private DashboardController dashboardController = new DashboardController();
        private PatientController patientController = new PatientController();

        public UC_Reportscs()
        {
            InitializeComponent();
            
            // Set Default Filters: Showing Today by default
            dtpFrom.Value = DateTime.Today;
            dtpTo.Value = DateTime.Today;
            cbDataViewFilter.SelectedIndex = 0; // All Records

            // Wire up filters to reload table
            // We can reload on change or on button click
            dtpFrom.ValueChanged += (s, e) => LoadPatientsTable();
            dtpTo.ValueChanged += (s, e) => LoadPatientsTable();
            cbDataViewFilter.SelectedIndexChanged += (s, e) => LoadPatientsTable();
            
            // Search text reload
            poisonTextBox1.TextChanged += (s, e) => {
                if (poisonTextBox1.Text != "Search") LoadPatientsTable();
            };
            poisonTextBox1.Click += (s, e) => {
                if (poisonTextBox1.Text == "Search") poisonTextBox1.Text = "";
            };

            // Search text reload
            poisonTextBox1.TextChanged += (s, e) => {
                if (poisonTextBox1.Text != "Search") LoadPatientsTable();
            };
            poisonTextBox1.Click += (s, e) => {
                if (poisonTextBox1.Text == "Search") poisonTextBox1.Text = "";
            };

            // Wire up Export button
            hopeRoundButton2.Click += (s, e) => ExportToPdf();

            // Initial load
            LoadData();

            // Ensure grid row height is set
            poisonDataGridView1.RowTemplate.Height = 45;
        }

        public void LoadData()
        {
            // Load stats for cards
            label1.Text = dashboardController.GetTotalConsultations().ToString();
            label3.Text = dashboardController.GetTotalSupplies();
            label5.Text = dashboardController.GetLowInventoryCount();
            label10.Text = dashboardController.GetTotalPatients();

            // Load patients table with default filters
            LoadPatientsTable();
        }

        private void LoadPatientsTable(string search = "")
        {
            try {
                // Use DT from controls if search isn't explicitly passed
                string searchTerm = string.IsNullOrEmpty(search) ? poisonTextBox1.Text : search;
                if (searchTerm == "Search") searchTerm = "";

                string categoryFilter = cbDataViewFilter.SelectedItem?.ToString() ?? "All Records";

                // Get data from controller
                DataTable dt = patientController.GetReportData(dtpFrom.Value, dtpTo.Value, searchTerm, categoryFilter);
                
                poisonDataGridView1.Rows.Clear();

                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        poisonDataGridView1.Rows.Add(
                            row["LastVisit"],
                            row["IDNumber"],
                            row["PatientName"],
                            row["PatientType"],
                            row["Description"] ?? "N/A",
                            row["QtyDosage"] ?? "N/A",
                            row["Personnel"] ?? "N/A"
                        );
                    }
                }
            } 
            catch (Exception ex)
            {
                // Silently log or handle. Often happens during initialization.
                System.Diagnostics.Debug.WriteLine("LoadPatientsTable Error: " + ex.Message);
            }
        }

        private void ExportToPdf()
        {
            try
            {
                // check if there is data to export
                if (poisonDataGridView1.Rows.Count == 0 || (poisonDataGridView1.Rows.Count == 1 && poisonDataGridView1.Rows[0].IsNewRow))
                {
                    MessageBox.Show("No data available to export for the selected date range.", "Export Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "PDF Files (*.pdf)|*.pdf";
                    sfd.FileName = $"AceCare_Report_{DateTime.Now:yyyyMMdd_HHmm}.pdf";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        using (PdfWriter writer = new PdfWriter(sfd.FileName))
                        {
                            using (PdfDocument pdf = new PdfDocument(writer))
                            {
                                pdf.SetDefaultPageSize(iText.Kernel.Geom.PageSize.A4.Rotate());
                                Document document = new Document(pdf);

                                // Create Fonts
                                PdfFont boldFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
                                PdfFont italicFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_OBLIQUE);

                                // Header
                                document.Add(new Paragraph("AceCare Clinic Management System")
                                    .SetTextAlignment(TextAlignment.CENTER)
                                    .SetFontSize(20)
                                    .SetFont(boldFont));

                                document.Add(new Paragraph("Clinic Activity Report")
                                    .SetTextAlignment(TextAlignment.CENTER)
                                    .SetFontSize(14)
                                    .SetFont(italicFont));

                                document.Add(new Paragraph($"Period: {dtpFrom.Value:MMM dd, yyyy} - {dtpTo.Value:MMM dd, yyyy}")
                                    .SetTextAlignment(TextAlignment.CENTER)
                                    .SetFontSize(10));

                                document.Add(new Paragraph("\n"));

                                // Summary Section
                                document.Add(new Paragraph("Report Details").SetFont(boldFont).SetFontSize(12));
                                document.Add(new Paragraph($"Category Filter: {cbDataViewFilter.SelectedItem?.ToString() ?? "All"}"));
                                document.Add(new Paragraph($"Search Filter: {(string.IsNullOrEmpty(poisonTextBox1.Text) || poisonTextBox1.Text == "Search" ? "None" : poisonTextBox1.Text)}"));
                                document.Add(new Paragraph($"Total Records Found: {poisonDataGridView1.Rows.Count - (poisonDataGridView1.AllowUserToAddRows ? 1 : 0)}"));
                                document.Add(new Paragraph($"Date Generated: {DateTime.Now:MMMM dd, yyyy HH:mm}"));

                                document.Add(new Paragraph("\n"));

                                // Table Section
                                document.Add(new Paragraph("Clinic Activity Log").SetFont(boldFont).SetFontSize(12));

                                // UPDATED: 7 columns matching the new design
                                float[] columnWidths = { 15, 10, 15, 10, 20, 15, 15 };
                                Table table = new Table(UnitValue.CreatePercentArray(columnWidths)).UseAllAvailableWidth();

                                // Table Headers
                                table.AddHeaderCell(new Cell().Add(new Paragraph("Last Visit").SetFont(boldFont)));
                                table.AddHeaderCell(new Cell().Add(new Paragraph("ID No.").SetFont(boldFont)));
                                table.AddHeaderCell(new Cell().Add(new Paragraph("Patient Name").SetFont(boldFont)));
                                table.AddHeaderCell(new Cell().Add(new Paragraph("Category").SetFont(boldFont)));
                                table.AddHeaderCell(new Cell().Add(new Paragraph("Description").SetFont(boldFont)));
                                table.AddHeaderCell(new Cell().Add(new Paragraph("Qty / Dosage").SetFont(boldFont)));
                                table.AddHeaderCell(new Cell().Add(new Paragraph("Personnel").SetFont(boldFont)));

                                // Table Data
                                foreach (DataGridViewRow row in poisonDataGridView1.Rows)
                                {
                                    if (row.IsNewRow) continue;

                                    for (int i = 0; i < 7; i++)
                                    {
                                        table.AddCell(new Paragraph(row.Cells[i].Value?.ToString() ?? "N/A").SetFontSize(8));
                                    }
                                }

                                document.Add(table);
                                document.Close();
                            }
                        }

                        MessageBox.Show("Report exported successfully!", "Export PDF", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating PDF: " + ex.ToString(), "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
