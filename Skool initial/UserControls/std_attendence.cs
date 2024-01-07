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
    public partial class std_attendence : UserControl
    {
        public static string std_username = loginstd.userName;  //useful for query
        public std_attendence()
        {
            InitializeComponent();
            SqlConnection con = new SqlConnection("Data Source=LAPTOP;Initial Catalog=PERFECT;Integrated Security=True;MultipleActiveResultSets=true");         //connection
            con.Open();
            SqlCommand cmd = new SqlCommand("select courseID from student___course_relation where student_id = ' " + std_username + " '  ", con); 
            var dr = cmd.ExecuteReader();
                DataTable tables = new DataTable();
                tables.Columns.Add("courseID", typeof(string));  //  column name
                tables.Load(dr);
                comboBox1.ValueMember = "courseID";                    //column name
                comboBox1.DataSource = tables;
            con.Close();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP;Initial Catalog=PERFECT;Integrated Security=True;MultipleActiveResultSets=true");         //connection
            con.Open();
            SqlCommand cmd = new SqlCommand("select date, course_Id, status from attendence1 where course_ID = @C_id and studentID =' " + std_username + " '  order by date", con);
            cmd.Parameters.AddWithValue("@C_id", comboBox1.Text);
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            dataGridView1.DataSource = table;
            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
