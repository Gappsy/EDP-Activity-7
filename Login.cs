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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void sign_in_Click(object sender, EventArgs e)
        {
            // Get the username and password from the input fields
            string username = user_box.Text;
            string password = pass_box.Text;

            // Open the database connection using DatabaseHelper
            using (MySqlConnection connection = DatabaseHelper.ConnOpen())
            {
                // Query the database to check if the username and password exist
                using (MySqlCommand command = new MySqlCommand("SELECT COUNT(*) FROM account WHERE username = @Username AND password = @Password", connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);

                    int userCount = Convert.ToInt32(command.ExecuteScalar());

                    // If the username and password are in the database
                    if (userCount > 0)
                    {
                        this.Hide();
                        Dashboard dashboard = new Dashboard();
                        dashboard.Show();
                    }
                    else
                    {
                        // If the username and password are not in the database, show an error message
                        MessageBox.Show("Invalid username or password.");
                    }
                }
            }

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Pass_Recovery pass_window = new Pass_Recovery();
            this.Hide();
            pass_window.Show();
        }
    }
  }

