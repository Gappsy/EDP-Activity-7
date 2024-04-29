using MySql.Data.MySqlClient;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Mikee_sFoodSys.UserControls
{
    public partial class ucemp_management : UserControl
    {
        public ucemp_management()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            using (MySqlConnection connection = DatabaseHelper.ConnOpen())
            {
                string query = "SELECT * FROM account";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                accountsGrid.DataSource = dataTable;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private bool IsEmployeeIDDuplicate(string employeeID)
        {
            using (MySqlConnection connection = DatabaseHelper.ConnOpen())
            {
                string query = "SELECT COUNT(*) FROM account WHERE account_id = @employeeID";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@employeeID", employeeID);

                int count = Convert.ToInt32(command.ExecuteScalar());
                return count > 0;
            }
        }

        private void insertButton_Click_1(object sender, EventArgs e)
        {
            string employeeID = idBox.Text;
            string username = usernameBox.Text;
            string status = statusBox.Text;
            string password = passwordBox.Text;
            string email = emailBox.Text;

            if (string.IsNullOrEmpty(employeeID) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(status) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please fill in all the fields.");
                return;
            }
            if (IsEmployeeIDDuplicate(employeeID))
            {
                MessageBox.Show("Employee ID already exists. Please use a different Employee ID.");
                return;
            }

            using (MySqlConnection connection = DatabaseHelper.ConnOpen())
            {
                string query = "INSERT INTO account (account_id, username, password, email, status) VALUES (@employeeID, @username, @password, @email, @status)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@employeeID", employeeID);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@status", status);
                command.ExecuteNonQuery();

                MessageBox.Show("Data inserted successfully.");

                // Refresh the data grid after insertion
                LoadData();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string employeeID = idBox.Text;
            if (string.IsNullOrEmpty(employeeID))
            {
                MessageBox.Show("Please enter an employee ID.");
                return;
            }

            using (MySqlConnection connection = DatabaseHelper.ConnOpen())
            {
                string query = "SELECT * FROM account WHERE account_id = @employeeID";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@employeeID", employeeID);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                accountsGrid.DataSource = dataTable;
            }
        }

        private void updateButton_Click_1(object sender, EventArgs e)
        {
            string employeeID = idBox.Text;
            string username = usernameBox.Text;
            string status = statusBox.Text;
            string password = passwordBox.Text;
            string email = emailBox.Text;

            if (string.IsNullOrEmpty(employeeID) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(status) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please fill in all the fields.");
                return;
            }

            using (MySqlConnection connection = DatabaseHelper.ConnOpen())
            {
                string query = "UPDATE account SET username = @username, password = @password, email = @email, status = @status WHERE account_id = @employeeID";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@employeeID", employeeID);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@status", status);
                command.Parameters.AddWithValue("@password", password);
                command.Parameters.AddWithValue("@email", email);

                command.ExecuteNonQuery();

                MessageBox.Show("Data updated successfully.");

                // Refresh the data grid after update
                LoadData();
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
                    ExportToExcel((DataTable)accountsGrid.DataSource, saveFileDialog.FileName);
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

            Excel.Workbook workbook = excelApp.Workbooks.Open(@"C:\Users\GELAY\source\repos\Mikee'sFoodSys\WorkEMP.xlsx");
            Excel.Worksheet worksheet = workbook.ActiveSheet;

            // Populate data starting from cell B4
            int row = 4;
            foreach (DataRow dataRow in dataTable.Rows)
            {
                worksheet.Cells[row, 2].Value = dataRow["account_id"];
                worksheet.Cells[row, 3].Value = dataRow["username"];
                worksheet.Cells[row, 4].Value = dataRow["password"];
                worksheet.Cells[row, 5].Value = dataRow["email"];
                worksheet.Cells[row, 6].Value = dataRow["created_at"];
                worksheet.Cells[row, 7].Value = dataRow["status"];
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


