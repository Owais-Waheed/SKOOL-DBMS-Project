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

namespace Skool_initial.UserControls
{
    public partial class homepage_t : UserControl
    {
        public static string t_username = loginteacher.teacher_userName;  //useful for query
        public static string teacher_name;
        public static string teacher_ID;

        public homepage_t()
        {
            InitializeComponent();
            SqlConnection con = new SqlConnection("Data Source=LAPTOP;Initial Catalog=PERFECT;Integrated Security=True;MultipleActiveResultSets=true");         //connection
            con.Open();

            SqlCommand cmd = new SqlCommand("select Course_id, course_title from course where course_ID in (select course_id from Teacher_course where teacherid = ' " + t_username + " ' ) ", con);
            var reader = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            dataGridView1.DataSource = table;

            cmd = new SqlCommand("select First_Name from teacher where teacherid = ' " + t_username + " '", con); // query for name
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox1.Text = dr.GetValue(0).ToString();
            }

            cmd = new SqlCommand("select teacherID from teacher where teacherid = ' " + t_username + " '", con); // query for ID 
            SqlDataReader dre = cmd.ExecuteReader();
            if (dre.Read())
            {
                textBox2.Text = dre.GetValue(0).ToString();
            }

            con.Close();
        }

        private void homepage_t_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
