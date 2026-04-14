using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AceCareClinicSystem.Controllers;
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
            LoadData();

            // Wire up search button
            SearchBtn.Click += (s, e) => LoadPatientsTable(poisonTextBox1.Text);
            poisonTextBox1.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) LoadPatientsTable(poisonTextBox1.Text); };

            // Wire up Export button
            hopeRoundButton2.Click += (s, e) => ExportToPdf();

            // Ensure grid row height is set
            poisonDataGridView1.RowTemplate.Height = 45;
        }

        public void LoadData()
        {
            // Load stats for cards
            label1.Text = dashboardController.GetTotalConsultations().ToString();
            label3.Text = dashboardController.GetTotalSupplies();
            label5.Text = dashboardController.GetLowInventoryCount();

            // Load patients table
            LoadPatientsTable();
        }

        private void LoadPatientsTable(string search = "")
        {
            DataTable dt = patientController.GetPatients(search);
            poisonDataGridView1.Rows.Clear();

            foreach (DataRow row in dt.Rows)
            {
                poisonDataGridView1.Rows.Add(
                    row["PatientName"],
                    row["IDNumber"],
                    row["PatientType"],
                    row["LastVisit"]
                );
            }
        }

        private void ExportToPdf()
        {
            try
            {
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

                                document.Add(new Paragraph("\n"));

                                // Summary Section
                                document.Add(new Paragraph("Dashboard Summary").SetFont(boldFont).SetFontSize(12));
                                document.Add(new Paragraph($"Total Consultations: {label1.Text}"));
                                document.Add(new Paragraph($"Total Supplies: {label3.Text}"));
                                document.Add(new Paragraph($"Inventory Alerts: {label5.Text}"));
                                document.Add(new Paragraph($"Date Generated: {DateTime.Now:MMMM dd, yyyy HH:mm}"));

                                document.Add(new Paragraph("\n"));

                                // Table Section
                                document.Add(new Paragraph("Patient Records List").SetFont(boldFont).SetFontSize(12));
                                
                                Table table = new Table(4).UseAllAvailableWidth();
                                
                                // Table Headers
                                table.AddHeaderCell(new Cell().Add(new Paragraph("Patient Name").SetFont(boldFont)));
                                table.AddHeaderCell(new Cell().Add(new Paragraph("ID Number").SetFont(boldFont)));
                                table.AddHeaderCell(new Cell().Add(new Paragraph("Patient Type").SetFont(boldFont)));
                                table.AddHeaderCell(new Cell().Add(new Paragraph("Last Visit").SetFont(boldFont)));

                                // Table Data
                                foreach (DataGridViewRow row in poisonDataGridView1.Rows)
                                {
                                    if (row.IsNewRow) continue;

                                    table.AddCell(new Paragraph(row.Cells[0].Value?.ToString() ?? ""));
                                    table.AddCell(new Paragraph(row.Cells[1].Value?.ToString() ?? ""));
                                    table.AddCell(new Paragraph(row.Cells[2].Value?.ToString() ?? ""));
                                    table.AddCell(new Paragraph(row.Cells[3].Value?.ToString() ?? ""));
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
    }
}
