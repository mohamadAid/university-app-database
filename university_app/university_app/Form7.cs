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
    public partial class Form7 : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-UO0RD8P\SQLEXPRESS;Initial Catalog=university;Integrated Security=true");
        DataTable db1 = new DataTable();
        SqlDataAdapter da;
        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            db1.Clear();
            conn.Open();
            da = new SqlDataAdapter("select Branch.bran_name,faculty.fac_name,class.class_name,class.class_cost from Branch,faculty,class where Branch.bran_id=faculty.bran_id and Branch.bran_id=class.bran_id", conn);
            da.Fill(db1);
            dataGridView1.DataSource = db1;
            conn.Close();
        }
    }
}
