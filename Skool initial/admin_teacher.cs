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

namespace Skool_initial
{
    public partial class admin_teacher : UserControl
    {
        public admin_teacher()
        {
            InitializeComponent();
            SqlConnection con = new SqlConnection("Data Source=LAPTOP;Initial Catalog=PERFECT;Integrated Security=True;MultipleActiveResultSets=true");         //connection
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from teacher",con);           // query
            var reader = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            dataGridView1.DataSource = table;

            cmd = new SqlCommand("select teacherID from teacher", con);           // query
            var reading = cmd.ExecuteReader();
            DataTable tables = new DataTable();
            tables.Columns.Add("teacherID", typeof(string));  // plplp is the column name
            tables.Load(reading);
            comboBox1.ValueMember = "teacherID";                    //column name
            comboBox1.DataSource = tables;

            cmd = new SqlCommand("select course_ID from course", con);           // query
            var reads = cmd.ExecuteReader();
            DataTable tabl = new DataTable();
            tabl.Columns.Add("course_ID", typeof(string));  // plplp is the column name
            tabl.Load(reads);
            comboBox2.ValueMember = "course_ID";                    //column name
            comboBox2.DataSource = tabl;
            con.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void admin_teacher_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP;Initial Catalog=PERFECT;Integrated Security=True;MultipleActiveResultSets=true");         //connection
            con.Open();
            string sql = "insert into teacher (teacherID, first_name,last_name,login_email,login_credentials,category) values (@ID,@fname, @lname, @l_email, @password, 2)";       //query
            SqlCommand cm = new SqlCommand(sql, con);
            // Specify the value for the parameters.
            cm.Parameters.AddWithValue("@fname", textBox1.Text);
            cm.Parameters.AddWithValue("@ID", textBox2.Text);
            cm.Parameters.AddWithValue("@lname", maskedTextBox1.Text);
            cm.Parameters.AddWithValue("@password", maskedTextBox2.Text);
            cm.Parameters.AddWithValue("@l_email", maskedTextBox3.Text);
            cm.ExecuteNonQuery();
            SqlCommand cmd = new SqlCommand("select * from teacher", con);           // query
            var reader = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            dataGridView1.DataSource = table;
            con.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP;Initial Catalog=PERFECT;Integrated Security=True;MultipleActiveResultSets=true");         //connection
            con.Open();
            string sql = "Insert into teacher_course (teacherid, course_id) values (@T_id, @C_id)";       //query
            SqlCommand cm = new SqlCommand(sql, con);
            // Specify the value for the parameters.
            cm.Parameters.AddWithValue("@T_id", comboBox1.Text);
            cm.Parameters.AddWithValue("@C_id", comboBox2.Text);
            cm.ExecuteNonQuery();
            con.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void Teacher_course_delete()
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP;Initial Catalog=PERFECT;Integrated Security=True;MultipleActiveResultSets=true");         //connection
            con.Open();
            string sql = "delete from teacher_course where teacherid = @T_id";       //query
            SqlCommand cm = new SqlCommand(sql, con);
            // Specify the value for the parameters.
            cm.Parameters.AddWithValue("@T_id", maskedTextBox5.Text);
            cm.ExecuteNonQuery();
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP;Initial Catalog=PERFECT;Integrated Security=True;MultipleActiveResultSets=true");         //connection
            con.Open();
            Teacher_course_delete();
            string sql = "delete from teacher where teacherid = @T_id";       //query
            SqlCommand cm = new SqlCommand(sql, con);
            // Specify the value for the parameters.
            cm.Parameters.AddWithValue("@T_id", maskedTextBox5.Text);
            cm.ExecuteNonQuery();
            con.Close();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
