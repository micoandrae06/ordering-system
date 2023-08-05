using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ordering_System.UserControls
{
    
    public partial class UC_RecentOrders : UserControl
    {
        function fn = new function();
        String query;

        public UC_RecentOrders()
        {
            InitializeComponent();
        }
        public void loadData()
        {
            query = "SELECT TOP 10 * FROM Sales ORDER BY Id DESC";
            DataSet ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }

        public void clearAll()
        {
            cmbCat.SelectedIndex = -1;
            txtName.Clear();
            txtPrice.Clear();
            txtQuantity.Clear();

        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            
        }

        private void UC_RecentOrders_Load(object sender, EventArgs e)
        {

            loadData();
            clearAll();
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {


        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            id = int.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            String Category = guna2DataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            String Name = guna2DataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            int Quantity = int.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
            int Price = int.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());

            cmbCat.Text = Category;
            txtName.Text = Name;
            txtPrice.Text = Price.ToString();
            txtQuantity.Text = Quantity.ToString();

        }

        private void DelLabel_Click(object sender, EventArgs e)
        {

        }
        int id;
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || cmbCat.Text == "" || txtPrice.Text == "" || txtQuantity.Text == "")
            {
                MessageBox.Show("Please Select the Order you want to Remove");
            }
            else
            {

                query = "delete from Sales where Id = " + id + "";
                fn.setData(query);
                loadData();
                clearAll();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || cmbCat.Text == "" || txtPrice.Text == "" || txtQuantity.Text == "")
            {
                MessageBox.Show("Please Select the Order you want to Update");
            }
            else
            {
                query = "update Sales set Name = '" + txtName.Text + "', Category = '" + cmbCat.Text + "', Price =" + txtPrice.Text + ", Quantity =" + txtQuantity.Text + " where Id = " + id + "";
                fn.setData(query);
                loadData();
                clearAll();
            }
        }

        private void UC_RecentOrders_Leave(object sender, EventArgs e)
        {
            clearAll();
        }
    }
}
