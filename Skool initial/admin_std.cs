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

namespace Skool_initial
{
    public partial class admin_std : UserControl
    {
        public admin_std()
        {
            InitializeComponent();
            SqlConnection con = new SqlConnection("Data Source=LAPTOP;Initial Catalog=PERFECT;Integrated Security=True;MultipleActiveResultSets=true");         //connection
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from student", con);           // query
            var reader = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            dataGridView1.DataSource = table;

            cmd = new SqlCommand("select studentid from student", con);           // query
            var reading = cmd.ExecuteReader();
            DataTable tables = new DataTable();
            tables.Columns.Add("studentid", typeof(string));  // plplp is the column name
            tables.Load(reading);
            comboBox1.ValueMember = "studentid";                    //column name
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP;Initial Catalog=PERFECT;Integrated Security=True;MultipleActiveResultSets=true");         //connection
            con.Open();
            string sql = "insert into student (studentId, first_name,last_name,login_email,login_credentials,[Batch/class]) values (@ID,@fname, @lname, @l_email, @password, @class)";       //query
            SqlCommand cm = new SqlCommand(sql, con);
            // Specify the value for the parameters.
            cm.Parameters.AddWithValue("@fname", maskedTextBox2.Text);
            cm.Parameters.AddWithValue("@lname", maskedTextBox1.Text);
            cm.Parameters.AddWithValue("@ID", maskedTextBox6.Text);
            cm.Parameters.AddWithValue("@class", maskedTextBox4.Text);
            cm.Parameters.AddWithValue("@password", maskedTextBox5.Text);
            cm.Parameters.AddWithValue("@l_email", maskedTextBox3.Text);
            cm.ExecuteNonQuery();
            SqlCommand cmd = new SqlCommand("select * from student", con);           // query
            var reader = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            dataGridView1.DataSource = table;
            con.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP;Initial Catalog=PERFECT;Integrated Security=True;MultipleActiveResultSets=true");         //connection
            con.Open();
            string sql = "Insert into student___course_relation (student_id, courseid) values (@S_id, @C_id)";       //query
            SqlCommand cm = new SqlCommand(sql, con);
            // Specify the value for the parameters.
            cm.Parameters.AddWithValue("@S_id", comboBox1.Text);
            cm.Parameters.AddWithValue("@C_id", comboBox2.Text);
            cm.ExecuteNonQuery();
            con.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void maskedTextBox3_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
        private void Student_course_delete()
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP;Initial Catalog=PERFECT;Integrated Security=True;MultipleActiveResultSets=true");         //connection
            con.Open();
            string sql = "delete from student___course_relation where student_id = @S_id";       //query
            SqlCommand cm = new SqlCommand(sql, con);
            // Specify the value for the parameters.
            cm.Parameters.AddWithValue("@S_id", maskedTextBox7.Text);
            cm.ExecuteNonQuery();
            con.Close();
        }
        private void Student_attendence_delete()
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP;Initial Catalog=PERFECT;Integrated Security=True;MultipleActiveResultSets=true");         //connection
            con.Open();
            string sql = "delete from attendence where studentid = @S_id";       //query
            SqlCommand cm = new SqlCommand(sql, con);
            // Specify the value for the parameters.
            cm.Parameters.AddWithValue("@S_id", maskedTextBox7.Text);
            cm.ExecuteNonQuery();
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP;Initial Catalog=PERFECT;Integrated Security=True;MultipleActiveResultSets=true");         //connection
            con.Open();
            Student_course_delete();
            Student_attendence_delete();
            string sql = "delete from student where student = @T_id";       //query
            SqlCommand cm = new SqlCommand(sql, con);
            // Specify the value for the parameters.
            cm.Parameters.AddWithValue("@T_id", maskedTextBox5.Text);
            cm.ExecuteNonQuery();
            con.Close();
        }

        private void maskedTextBox7_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
