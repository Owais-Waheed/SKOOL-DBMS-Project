using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Skool_initial.UserControls
{
    public partial class homepage_s : UserControl
    {
        public static string std_username = loginstd.userName;  //useful for query

        public homepage_s()
        {
            InitializeComponent();
            SqlConnection con = new SqlConnection("Data Source=LAPTOP;Initial Catalog=PERFECT;Integrated Security=True;MultipleActiveResultSets=true");         //connection
            con.Open();
            SqlCommand cmd = new SqlCommand("select course_title, course_id from course where course_id in (select courseId from Student___course_relation where student_id = ' " + std_username + " '  )", con);
            var reader = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            dataGridView1.DataSource = table;

            cmd = new SqlCommand("select First_Name from Student where studentid = ' " + std_username + " '", con); // query for name
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox1.Text = dr.GetValue(0).ToString();
            }

            cmd = new SqlCommand("select StudentID from Student where studentid = ' " + std_username + " '", con); // query for ID 
            SqlDataReader dre = cmd.ExecuteReader();
            if (dre.Read())
            {
                textBox2.Text = dre.GetValue(0).ToString();
            }

            cmd = new SqlCommand("select [Batch/class] from Student where studentid = ' " + std_username + " '", con); // query for class
            SqlDataReader dry = cmd.ExecuteReader();
            if (dry.Read())
            {
                textBox3.Text = dry.GetValue(0).ToString();
            }

            con.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
