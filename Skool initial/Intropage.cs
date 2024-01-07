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
    public partial class InitialLogin : Form
    {
        public InitialLogin()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            loginadmin form4 = new loginadmin();
            this.Hide();
            form4.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            loginstd form2 = new loginstd();
            this.Hide();
            form2.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            loginteacher form3 = new loginteacher();
            this.Hide();
            form3.ShowDialog();
        }
    }
}
