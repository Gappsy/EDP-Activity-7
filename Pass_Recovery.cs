using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mikee_sFoodSys
{
    public partial class Pass_Recovery : Form
    {
        public Pass_Recovery()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string email = emailBox.Text;

            // Check if the email is not empty
            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Please enter an email address.");
                return;
            }

            // Insert the email into the pass_reset_req table
            using (MySqlConnection connection = DatabaseHelper.ConnOpen())
            {
                string query = "INSERT INTO pass_reset_req (username) VALUES (@email)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@email", email);

                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Request Sent!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error inserting email: " + ex.Message);
                }
            }

            Login log = new Login();
            this.Hide();
            log.Show();
        }
    }
}
