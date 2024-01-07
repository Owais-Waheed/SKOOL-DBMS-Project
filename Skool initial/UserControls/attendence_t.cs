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

namespace Skool_initial.UserControls
{
    public partial class attendence_t : UserControl
    {
        public static string datecheck;

        public string t_username = loginteacher.teacher_userName;  //useful for query
        public attendence_t()
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

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            datecheck = textBox1.Text;
            SqlConnection con = new SqlConnection("Data Source=LAPTOP;Initial Catalog=PERFECT;Integrated Security=True;MultipleActiveResultSets=true");         //connection
            con.Open();
            SqlCommand pp = new SqlCommand("select * from attendence1 where date = '" + datecheck + "' ", con);
            SqlDataReader dr = pp.ExecuteReader();
            if (dr.Read())
            {
                SqlCommand cmd = new SqlCommand("select date, studentid, status from attendence1 where course_ID = (select course_id from course where course_title = @C_id) and [date] = @date", con);
                cmd.Parameters.AddWithValue("@C_id", comboBox1.Text);
                cmd.Parameters.AddWithValue("@date", textBox1.Text);
                var reader = cmd.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(reader);
                dataGridView1.DataSource = table;
            }
            else
            {
                MessageBox.Show("Attendance for this date is not marked. Update the attendance below.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                


            }

                con.Close();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP;Initial Catalog=PERFECT;Integrated Security=True;MultipleActiveResultSets=true");         //connection
            con.Open();
            string sql = "insert into attendence1 (date, status,course_id,studentid) values (@date,@status, @cid, @sid)";       //query
            SqlCommand cm = new SqlCommand(sql, con);
            // Specify the value for the parameters.
            cm.Parameters.AddWithValue("@sid", textBox2.Text);
            cm.Parameters.AddWithValue("@date", textBox3.Text);
            cm.Parameters.AddWithValue("@cid", maskedTextBox3.Text);
            cm.Parameters.AddWithValue("@status", maskedTextBox2.Text);
            cm.ExecuteNonQuery();
            SqlCommand cmd = new SqlCommand("select date, studentid, status from attendence1 where course_ID = (select course_id from course where course_title = @C_id) and [date] = @date", con);
            cmd.Parameters.AddWithValue("@C_id", comboBox1.Text);
            cmd.Parameters.AddWithValue("@date", textBox1.Text);
            var reader = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            dataGridView1.DataSource = table;
            con.Close();
        }
    }
}
