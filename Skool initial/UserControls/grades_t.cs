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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Skool_initial.UserControls
{
    public partial class grades_t : UserControl
    {
        public string t_username = loginteacher.teacher_userName;  //useful for query
        public grades_t()
        {
            InitializeComponent();
            SqlConnection con = new SqlConnection("Data Source=LAPTOP;Initial Catalog=PERFECT;Integrated Security=True;MultipleActiveResultSets=true");         //connection
            con.Open();
            SqlCommand cmd = new SqlCommand("select course_title from Course where course_id in (select course_ID from teacher_course where teacherid = ' " + t_username + " '  )", con);
            var dr = cmd.ExecuteReader();
             DataTable tables = new DataTable();
                tables.Columns.Add("course_title", typeof(string));  //  column name
                tables.Load(dr);
                comboBox1.ValueMember = "course_title";                    //column name
                comboBox1.DataSource = tables;
                con.Close();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP;Initial Catalog=PERFECT;Integrated Security=True;MultipleActiveResultSets=true");         //connection
            con.Open();
            SqlCommand cmd = new SqlCommand("select student_id, grades from student___course_relation where courseID = (select course_id from course where course_title = @C_id)", con);
            cmd.Parameters.AddWithValue("@C_id", comboBox1.Text);
            var reader = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            dataGridView1.DataSource = table;
            con.Close();
        }

        private void grades_t_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
