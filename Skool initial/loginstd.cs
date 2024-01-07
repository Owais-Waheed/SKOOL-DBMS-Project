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
    public partial class loginstd : Form
    {
        public static string userName;
        public static string pass;
        public loginstd()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            InitialLogin sc = new InitialLogin();
            sc.Show();
            this.Close();
        }

        private void loginstd_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            userName = textBox2.Text;
            pass = textBox1.Text;
            SqlConnection con = new SqlConnection("Data Source=LAPTOP;Initial Catalog=PERFECT;Integrated Security=True;MultipleActiveResultSets=true");         //connection
            con.Open();

            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Please enter values in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SqlCommand cmd = new SqlCommand("select * from Student where studentID = '" + userName + "' and login_credentials = '" + pass + "'", con);       //query
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    dr.Close();
                    con.Close();
                    studentmain page1 = new studentmain();
                    page1.Show();
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
