using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E_book_Library_Management_System
{
    public partial class Admin : Form
    {
        Admin Login;
        public Admin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Login().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textA_Username.Text == "Pranto" && textA_password.Text == "123456789")

            {
                this.Hide();
                Login = new Admin();
                Login.Show();
            }

            else if (textA_Username.Text == "" && textA_password.Text == "")
            {
                MessageBox.Show("Insert Information!");
            }

            else
            {
                MessageBox.Show("Wrong Information!");
            }

            A_Dashboard b = new A_Dashboard();
            b.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
