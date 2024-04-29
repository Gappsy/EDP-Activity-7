using MySql.Data.MySqlClient;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Mikee_sFoodSys.UserControls
{
    public partial class ucinventory : UserControl
    {
        public ucinventory()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            using (MySqlConnection connection = DatabaseHelper.ConnOpen())
            {
                string query = "SELECT * FROM products";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                invGrid.DataSource = dataTable;
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void export_button_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel Files|*.xlsx;*.xls|All Files|*.*";
                saveFileDialog.Title = "Save Inventory Data";
                saveFileDialog.FileName = "inventory.xlsx"; // Default file name

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ExportToExcel((DataTable)invGrid.DataSource, saveFileDialog.FileName);
                    MessageBox.Show("Inventory data exported successfully.", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while exporting inventory data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportToExcel(DataTable dataTable, string filePath)
        {
            Excel.Application excelApp = new Excel.Application();
            excelApp.Visible = false;
            excelApp.DisplayAlerts = false;

            Excel.Workbook workbook = excelApp.Workbooks.Open(@"C:\Users\GELAY\source\repos\Mikee'sFoodSys\WorkINV.xlsx");
            Excel.Worksheet worksheet = workbook.ActiveSheet;

            // Populate data starting from cell B4
            int row = 4;
            foreach (DataRow dataRow in dataTable.Rows)
            {
                worksheet.Cells[row, 2].Value = dataRow["product_id"];
                worksheet.Cells[row, 3].Value = dataRow["name"];
                worksheet.Cells[row, 4].Value = dataRow["category"];
                worksheet.Cells[row, 5].Value = dataRow["price"];
                worksheet.Cells[row, 6].Value = dataRow["supplier_id"];
                worksheet.Cells[row, 7].Value = dataRow["quantity"];
                row++;
            }

            workbook.SaveAs(filePath);
            workbook.Close();
            excelApp.Quit();

            ReleaseObject(worksheet);
            ReleaseObject(workbook);
            ReleaseObject(excelApp);
        }

        private void ReleaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occurred while releasing object: " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
