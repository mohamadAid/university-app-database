using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace university_app
{
    public partial class Form6 : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-UO0RD8P\SQLEXPRESS;Initial Catalog=university;Integrated Security=true");
        DataTable db1 = new DataTable();
        SqlDataAdapter da;
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            db1.Clear();
            conn.Open();
            da = new SqlDataAdapter("select stud_name,sub_name,status  from student,Subject,stud_sub  where student.stud_id=stud_sub.stud_id  and Subject.sub_id=stud_sub.sub_id ", conn);
            da.Fill(db1);
            dataGridView1.DataSource = db1;
            conn.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
