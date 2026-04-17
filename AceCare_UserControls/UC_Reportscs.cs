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
            LoadData();

            // Wire up search buttons
            //    SearchBtn.Click += (s, e) => LoadPatientsTable(poisonTextBox1.Text);
            //   poisonTextBox1.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) LoadPatientsTable(poisonTextBox1.Text); };

            // Panel 5 Search (Right side) - wire it to the same patient search for simplicity or general report filter
            //  hopeRoundButton1.Click += (s, e) => LoadPatientsTable(poisonTextBox2.Text);
            // poisonTextBox2.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) LoadPatientsTable(poisonTextBox2.Text); };

            // Wire up Export button
            hopeRoundButton2.Click += (s, e) => ExportToPdf();

            // Wire up Edit button (hopeRoundButton3)
            hopeRoundButton3.Click += (s, e) => EditSelectedPatient();

            // Wire up Delete button (hopeRoundButton4)
            hopeRoundButton4.Click += (s, e) => DeleteSelectedPatient();

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
                // UPDATED: Aligning with the new 7-column design
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

        private string GetSelectedPatientId()
        {
            if (poisonDataGridView1.SelectedRows.Count > 0)
            {
                return poisonDataGridView1.SelectedRows[0].Cells[1].Value?.ToString(); // Column 1 is ID No.
            }
            return null;
        }

        private void EditSelectedPatient()
        {
            string id = GetSelectedPatientId();
            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show("Please select a patient from the list to edit.", "Selection Required");
                return;
            }

            FormPatientEdit editForm = new FormPatientEdit(id);
            editForm.ShowDialog();

            if (editForm.IsSuccess)
            {
                LoadData();
            }
        }

        private void DeleteSelectedPatient()
        {
            string id = GetSelectedPatientId();
            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show("Please select a patient from the list to delete.", "Selection Required");
                return;
            }

            DialogResult result = MessageBox.Show($"Are you sure you want to delete patient record {id}? This action cannot be undone.",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                if (patientController.DeletePatient(id))
                {
                    MessageBox.Show("Patient record deleted successfully.");
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Failed to delete patient record.");
                }
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

                                document.Add(new Paragraph("\n"));

                                // Summary Section
                                document.Add(new Paragraph("Dashboard Summary").SetFont(boldFont).SetFontSize(12));
                                document.Add(new Paragraph($"Total Consultations: {label1.Text}"));
                                document.Add(new Paragraph($"Total Supplies: {label3.Text}"));
                                document.Add(new Paragraph($"Inventory Alerts: {label5.Text}"));
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
                                        table.AddCell(new Paragraph(row.Cells[i].Value?.ToString() ?? "N/A").SetFontSize(9));
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
