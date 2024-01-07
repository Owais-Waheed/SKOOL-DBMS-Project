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
    public partial class Teachermain : Form
    {
        public Teachermain()
        {
            InitializeComponent();
        }
        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(userControl);
            userControl.BringToFront();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            homepage_t homepage_T = new homepage_t();   
            addUserControl(homepage_T);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            attendence_t attendence_T = new attendence_t(); 
            addUserControl(attendence_T);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            grades_t grades_T = new grades_t(); 
            addUserControl((grades_T));
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            InitialLogin sc = new InitialLogin();
            sc.Show();
            this.Close();
        }
    }
}
