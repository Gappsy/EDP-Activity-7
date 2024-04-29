using Mikee_sFoodSys.UserControls;
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
    public partial class Dashboard : Form   
    {
        
        public Dashboard()
        {
            InitializeComponent();
        }
        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panel7.Controls.Clear();
            panel7.Controls.Add(userControl);
            userControl.BringToFront();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ucdashboard uc = new ucdashboard();
            addUserControl(uc);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dash_button(object sender, EventArgs e)
        {
            ucdashboard uc = new ucdashboard();
            addUserControl(uc);
        }

        private void mainpanel(object sender, PaintEventArgs e)
        {

        }

        private void inventory_button_Click(object sender, EventArgs e)
        {
            ucinventory uc = new ucinventory();
            addUserControl(uc);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ucemp_management uc = new ucemp_management();
            addUserControl (uc);
        }

        private void Order_button_Click(object sender, EventArgs e)
        {
            ucorders uc = new ucorders();
            addUserControl(uc);
        }
    }
}
