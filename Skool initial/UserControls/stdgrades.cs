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
    public partial class stdgrades : UserControl
    {
        public static string std_username = loginstd.userName;  //useful for query
        public stdgrades()
        {
            InitializeComponent();
            SqlConnection con = new SqlConnection("Data Source=LAPTOP;Initial Catalog=PERFECT;Integrated Security=True;MultipleActiveResultSets=true");         //connection
            con.Open();
            SqlCommand cmd = new SqlCommand("select courseID, grades from Student___course_relation  where student_id = ' " + std_username + " ' ", con);
            var dr = cmd.ExecuteReader();
            DataTable table = new DataTable();
                table.Load(dr);
                dataGridView1.DataSource = table;
            

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
