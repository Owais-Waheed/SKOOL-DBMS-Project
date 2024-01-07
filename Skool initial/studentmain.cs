using Skool_initial.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Skool_initial
{
    public partial class studentmain : Form
    {
        public studentmain()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            homepage_s homepage_S = new homepage_s();
            addUserControl(homepage_S);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            stdgrades stdgrades_1 = new stdgrades();    
            addUserControl(stdgrades_1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            std_attendence std_attendence_1 = new std_attendence(); 
            addUserControl(std_attendence_1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            InitialLogin sc = new InitialLogin();
            sc.Show();
            this.Close();
        }
    }
}
