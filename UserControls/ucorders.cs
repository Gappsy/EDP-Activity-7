using MySql.Data.MySqlClient;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Mikee_sFoodSys.UserControls
{
    public partial class ucorders : UserControl
    {
        public ucorders()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            using (MySqlConnection connection = DatabaseHelper.ConnOpen())
            {
                string query = "SELECT * FROM orders";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                orderGrid.DataSource = dataTable;
            }
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void insertButton_Click(object sender, EventArgs e)
        {
            string customer_id = customer_idbox.Text;
            string product_id = product_idbox.Text;
            string quantity = quantity_box.Text;

            if (string.IsNullOrEmpty(customer_id) || string.IsNullOrEmpty(product_id) || string.IsNullOrEmpty(quantity))
            {
                MessageBox.Show("Please fill in all the fields.");
                return;
            }
            using (MySqlConnection connection = DatabaseHelper.ConnOpen())
            {
                string query = "INSERT INTO orders (customer_id, product_id, quantity) VALUES (@customer_id, @product_id, @quantity)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@customer_id", customer_id);
                command.Parameters.AddWithValue("@product_id", product_id);
                command.Parameters.AddWithValue("@quantity", quantity);
                command.ExecuteNonQuery();

                MessageBox.Show("Data inserted successfully.");

                // Refresh the data grid after insertion
                LoadData();
            }
        }

        private void order_idbutton_TextChanged(object sender, EventArgs e)
        {
          
          
        }

        private void search_button_Click(object sender, EventArgs e)
        {
            string order_id = order_idtext.Text;
            if (string.IsNullOrEmpty(order_id))
            {
                MessageBox.Show("Please enter an Order ID.");
                return;
            }

            using (MySqlConnection connection = DatabaseHelper.ConnOpen())
            {
                string query = "SELECT * FROM orders WHERE order_id = @order_id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@order_id", order_id);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                orderGrid.DataSource = dataTable;
            }
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
                    ExportToExcel((DataTable)orderGrid.DataSource, saveFileDialog.FileName);
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

            Excel.Workbook workbook = excelApp.Workbooks.Open(@"C:\Users\GELAY\source\repos\Mikee'sFoodSys\WorkORD.xlsx");
            Excel.Worksheet worksheet = workbook.ActiveSheet;

            // Populate data starting from cell B4
            int row = 4;
            foreach (DataRow dataRow in dataTable.Rows)
            {
                worksheet.Cells[row, 2].Value = dataRow["order_id"];
                worksheet.Cells[row, 3].Value = dataRow["customer_id"];
                worksheet.Cells[row, 4].Value = dataRow["order_date"];
                worksheet.Cells[row, 5].Value = dataRow["product_id"];
                worksheet.Cells[row, 6].Value = dataRow["quantity"];
                worksheet.Cells[row, 7].Value = dataRow["total_amount"];
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
