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
    public partial class Form5 : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-UO0RD8P\SQLEXPRESS;Initial Catalog=university;Integrated Security=true");
        DataTable db1 = new DataTable();
        SqlDataAdapter da;

        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            db1.Clear();
            conn.Open();
            da = new SqlDataAdapter("select * from student  where stud_address like 'Istanbul' ", conn);
            da.Fill(db1);
            dataGridView1.DataSource = db1;
            conn.Close();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
