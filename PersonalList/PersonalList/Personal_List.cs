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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Windows.Forms.VisualStyles;

namespace PersonalList
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'societyDataSet.Persons' table. You can move, or remove it, as needed.
            this.personsTableAdapter.Fill(this.societyDataSet.Persons);

        }
        SqlConnection connection = new SqlConnection("Data Source=HP;Initial Catalog=Society;Integrated Security=True");

        public object DataGridView1 { get; private set; }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlDataAdapter da=new SqlDataAdapter("Select * From Persons",connection);
            DataSet ds=new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand newrecord= new SqlCommand("insert into Persons(Number,Name,Surname,Job,Salary,City,Tax) values(@p1,@p2,@p3,@p4,@p5,@p6,@p7)",connection ); 
            newrecord.Parameters.AddWithValue("@p1", textBox1.Text);
            newrecord.Parameters.AddWithValue("@p2", textBox2.Text);
            newrecord.Parameters.AddWithValue("@p3", textBox3.Text);
            newrecord.Parameters.AddWithValue("@p4", textBox4.Text);
            newrecord.Parameters.AddWithValue("@p5", textBox5.Text);
            newrecord.Parameters.AddWithValue("@p6", textBox6.Text);
            newrecord.Parameters.AddWithValue("@p7", textBox7.Text);
            
            newrecord.ExecuteNonQuery();
            connection.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand deleteperson = new SqlCommand("Delete from Persons where Name=@_name ", connection);
            deleteperson.Parameters.AddWithValue("@_name", textBox2.Text);
           
            deleteperson.ExecuteNonQuery(); 
            connection.Close();
        }

      
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int choosen = dataGridView1.SelectedCells[0].RowIndex;

            string number = dataGridView1.Rows[choosen].Cells[0].Value.ToString();
            string name = dataGridView1.Rows[choosen].Cells[1].Value.ToString();
            string surname = dataGridView1.Rows[choosen].Cells[2].Value.ToString();
            string job = dataGridView1.Rows[choosen].Cells[3].Value.ToString();
            string salary = dataGridView1.Rows[choosen].Cells[4].Value.ToString();
            string city = dataGridView1.Rows[choosen].Cells[5].Value.ToString();
            string tax = dataGridView1.Rows[choosen].Cells[6].Value.ToString();

            

            textBox1.Text = number;
            textBox2.Text = name;
            textBox3.Text = surname;
            textBox4.Text = job;
            textBox5.Text = salary;
            textBox6.Text = city;
            textBox7.Text = tax;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand updateperson = new SqlCommand("update Persons set  Number=@p1,Name=@p2,Surname=@p3,Job=@p4,Salary=@p5,City=@p6,Tax=@p7 where Number=@p1", connection);
            updateperson.Parameters.AddWithValue("@p1", textBox1.Text);
            updateperson.Parameters.AddWithValue("@p2", textBox2.Text);
            updateperson.Parameters.AddWithValue("@p3", textBox3.Text);
            updateperson.Parameters.AddWithValue("@p4", textBox4.Text);
            updateperson.Parameters.AddWithValue("@p5", textBox5.Text);
            updateperson.Parameters.AddWithValue("@p6", textBox6.Text);
            updateperson.Parameters.AddWithValue("@p7", textBox7.Text);

            updateperson.ExecuteNonQuery();
            connection.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
           SqlDataAdapter da=new SqlDataAdapter("Select * from Persons where  Name='"+textBox8.Text + "'", connection);
             DataSet ds=new DataSet();
             da.Fill(ds);
             dataGridView1.DataSource = ds.Tables[0];
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand avgsalary = new SqlCommand("select avg(Salary) from Persons", connection);
            SqlDataReader read = avgsalary.ExecuteReader();
            while (read.Read())
            {
                label15.Text = read[0].ToString();
            }
            connection.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand highestsalary = new SqlCommand("select max(Salary) from Persons", connection);
            SqlDataReader read=highestsalary.ExecuteReader();
            while (read.Read())
            {
                label13.Text = read[0].ToString();
            }
            connection.Close();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand totalregister = new SqlCommand("select count(name) from Persons", connection);
            SqlDataReader read = totalregister.ExecuteReader();
            while (read.Read())
            {
                label10.Text = read[0].ToString();
            }
            connection.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand totalsalary = new SqlCommand("select sum(Salary) from Persons", connection);
            SqlDataReader read = totalsalary.ExecuteReader();
            while (read.Read())
            {
                label11.Text = read[0].ToString();
            }
            connection.Close();
        }
    }
}
