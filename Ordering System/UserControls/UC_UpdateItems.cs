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
    public partial class UC_UpdateItems : UserControl
    {
        function fn = new function();
        String query;
        public UC_UpdateItems()
        {
            InitializeComponent();
        }


        public void clearAll()
        {
            cmbCat.SelectedIndex = -1;
            txtItemName.Clear();
            txtPrice.Clear();
        }
        private void UC_UpdateItems_Load(object sender, EventArgs e)
        {
            
            loadData();
        }
        public void loadData()
        {
            query = "select * from menuitems";
            DataSet ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
            guna2DataGridView1.ColumnHeadersVisible = true;
        }

        private void txtSearchItem_TextChanged(object sender, EventArgs e)
        {
            query = "select * from menuitems where Name like '"+txtSearchItem.Text+"%'";
            DataSet ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }

        int id;
        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = int.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            String Category = guna2DataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            String Name = guna2DataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            int Price = int.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());


            cmbCat.Text = Category;
            txtItemName.Text = Name;
            txtPrice.Text = Price.ToString();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            query = "update menuitems set Name = '" + txtItemName.Text + "', Category = '" + cmbCat.Text + "', Price =" + txtPrice.Text + " where Id = " + id + "";
            fn.setData(query);
            loadData();
            clearAll();
  
        }

        private void UC_UpdateItems_Enter(object sender, EventArgs e)
        {
            loadData();
        }

        private void cmbCat_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void UC_UpdateItems_Leave(object sender, EventArgs e)
        {
            clearAll();
            loadData();
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            query = "select * from menuitems where Category like '" + cmbCategory.Text + "%'";
            DataSet ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
