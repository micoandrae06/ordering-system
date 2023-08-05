using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ordering_System
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "admin" && txtPassword.Text == "password")
            {
                Dashboard ds = new Dashboard("Admin");
                ds.Show();
                this.Hide();
            }
            else if (string.IsNullOrEmpty(this.txtUsername.Text))
            {
                MessageBox.Show("Please provide your Username");
            }

            else if (string.IsNullOrEmpty(this.txtPassword.Text))
            {
                MessageBox.Show("Please provide your Password");
            }
            else if (this.txtUsername.Text != "".ToString())
            {
                MessageBox.Show("Invalid Username or Password");
            }

            else if  (this.txtPassword.Text != "".ToString())
            {
                MessageBox.Show("Invalid Password or Password");
            }

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '*';
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
