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

namespace E_book_Library_Management_System
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Reader().Show();
        }
      
        string connectionString = "Data Source=DESKTOP-9MVTQGQ;Initial Catalog=E_Book;Integrated Security=True";
        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "insert into Reader(First_Name, Last_Name,E_mail,Username,Password, Re_write_password,Phone_Number,Country,Present_Address,Permanent_Address,Occupation) values('" + textFirst_Name.Text + "', '" + textLast_Name.Text + "', '" + textE_mail.Text + "', '" + textUsername.Text + "', '" + textPassword.Text + "', '" + textRe_write_password.Text + "', '" + textPhone_Number.Text + "', '" + textCountry.Text + "', '" + textPresent_Address.Text + "', '" + textPermanent_Address.Text + "', '" + textOccupation.Text + "')";
            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("done!");

            }
            else { MessageBox.Show("Error!"); }
            con.Close();

            Reader b = new Reader();
            b.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("update Reader set  Last_Name=@LN, EMAIL=@E, Username=@U, Password=@P, Rewritepassword=@RWP, PhoneNumber=@PN,Country=@C, PresentAddress=@PA,PermanentAddress=@P,Occupation=@O where First_Name=@FM", connection);


            connection.Open();
            cmd.Parameters.AddWithValue("@FM", textFirst_Name.Text);
            cmd.Parameters.AddWithValue("@LN", textLast_Name.Text);
            cmd.Parameters.AddWithValue("@E", textE_mail.Text);
            cmd.Parameters.AddWithValue("@U", textUsername.Text);
            cmd.Parameters.AddWithValue("@P", textPassword.Text);
            cmd.Parameters.AddWithValue("@RWP", textRe_write_password.Text);
            cmd.Parameters.AddWithValue("@PN", textPhone_Number.Text);
            cmd.Parameters.AddWithValue("@C", textCountry.Text);
            cmd.Parameters.AddWithValue("@PA", textPresent_Address.Text);
            cmd.Parameters.AddWithValue("@P", textPermanent_Address.Text);
            cmd.Parameters.AddWithValue("@O", textOccupation.Text);
            /* SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
             DataTable dt = new DataTable();
             sqlDataAdapter.Fill(dt);*/
            int p = cmd.ExecuteNonQuery();
            if (p > 0)
            {
                MessageBox.Show("UPDATED SUCCESSFULLY");

            }

            else
            {
                MessageBox.Show("UPDATE FAILED", "Enter another valide information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string query = "select *FROM Reader";
            SqlDataAdapter a = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            a.Fill(data);
            dataGridView1.DataSource = data;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("delete Reader where First_Name=@FM", connection);


            connection.Open();
            cmd.Parameters.AddWithValue("@FM", textFirst_Name.Text);


            int p = cmd.ExecuteNonQuery();
            if (p > 0)
            {

                MessageBox.Show("REMOVE DATA");


            }

            else
            {
                MessageBox.Show("REMOVE FAILED", "Enter another valide information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();

        }
    }
}
