using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;   // upload for sql library

namespace university_app
{
    public partial class Form2 : Form
    {

        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-UO0RD8P\SQLEXPRESS;Initial Catalog=university;Integrated Security=true");
        DataTable db1 = new DataTable();
        SqlDataAdapter da;



        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand comm1 = new SqlCommand("select MAX(stud_id)+1 from student",conn);
            SqlDataReader reader1 = comm1.ExecuteReader();
            reader1.Read();
            textBox1.Text = reader1[0].ToString();
            conn.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand comm1 = new SqlCommand("insert into student values('"+textBox2.Text+"','"+textBox3.Text+"','"+textBox4.Text+"')", conn);
            comm1.ExecuteNonQuery();
            MessageBox.Show("Adding is Done..");
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            int id;
            id = int.Parse(textBox1.Text);
            id++;                           // id=id+1;
            textBox1.Text = id.ToString();
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            db1.Clear();
            conn.Open();
            da = new SqlDataAdapter("select * from student",conn);
            da.Fill(db1);
            dataGridView1.DataSource = db1;
            conn.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlCommandBuilder asd = new SqlCommandBuilder(da);
            da.Update(db1);
            MessageBox.Show("Saving is done..");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
