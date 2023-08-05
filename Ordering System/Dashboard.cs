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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        public Dashboard(String user)
        {
            InitializeComponent();

            if(user == "Admin")
            {
                btnPlace.Show();
                btnAdd.Show();
                btnUpdate.Show();   
                btnRemove.Show();   
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkLogout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login fm = new Login();
            this.Hide();
            fm.Show();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            uC_AddItems1.Visible = false;
            uC_PlaceOrder1.Visible = false;
            uC_UpdateItems2.Visible = false;
            uC_RemoveItems1.Visible = false;
            uC_Sales1.Visible =    false;
            uC_Stocks1.Visible = false;
            uC_RecentOrders1.Visible = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            uC_AddItems1.Visible = true;
            uC_AddItems1.BringToFront();
        }

        private void btnPlace_Click(object sender, EventArgs e)
        {
            uC_PlaceOrder1.Visible = true;
            uC_PlaceOrder1.BringToFront();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
           uC_UpdateItems2.Visible = true;
            uC_UpdateItems2.BringToFront();
        }

        private void uC_RemoveItems1_Load(object sender, EventArgs e)
        {

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            uC_RemoveItems1.Visible = true;
            uC_RemoveItems1.BringToFront();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            uC_Sales1.Visible = true;
            uC_Sales1.BringToFront();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            uC_Stocks1.Visible = true;
            uC_Stocks1.BringToFront();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            uC_RecentOrders1.Visible = true;
            uC_RecentOrders1.BringToFront();
        }
    }
}
