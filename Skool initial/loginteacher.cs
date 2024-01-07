using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Skool_initial
{
    public partial class loginteacher : Form
    {
        public static string teacher_userName ;
        public static string teacher_pass ;
        public loginteacher()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            InitialLogin sc = new InitialLogin();
            sc.Show();
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            teacher_userName = textBox2.Text;
            teacher_pass = textBox1.Text;
            SqlConnection con = new SqlConnection("Data Source=LAPTOP;Initial Catalog=PERFECT;Integrated Security=True;MultipleActiveResultSets=true");         //connection
            con.Open();

            if (string.IsNullOrEmpty(teacher_userName) || string.IsNullOrEmpty(teacher_pass))
            {
                MessageBox.Show("Please enter values in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SqlCommand cmd = new SqlCommand("select * from Teacher where teacherID = '" + teacher_userName + "' and login_credentials = '" + teacher_pass + "'", con);       //query
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    dr.Close();
                    con.Close();
                    Teachermain teachermain = new Teachermain();
                    teachermain.Show();
                    this.Close();
                }
                else
                {
                    dr.Close();
                    MessageBox.Show("No account available with this username and password ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
