﻿using System;
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
    public partial class UC_RemoveItems : UserControl
    {
        function fn = new function();
        String query;
        public UC_RemoveItems()
        {
            InitializeComponent();
        }

        private void UC_RemoveItems_Load(object sender, EventArgs e)
        {
            DelLabel.Text = "How to Delete the Item?";
            DelLabel.ForeColor = Color.Blue;
            loadData();

        }
        public void loadData()
        {
            query = "select * from menuitems";
            DataSet ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }

        private void txtItemName_TextChanged(object sender, EventArgs e)
        {
            query = "select * from menuitems where Name like '" +txtItemName.Text+"%'";
            DataSet ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(MessageBox.Show("Do you want to Delete this Item?", "Important Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)==DialogResult.OK )
            {
                int id = int.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                query = "delete from menuitems where Id = " + id + "";
                fn.setData(query);
                loadData();
            }
        }

        private void DelLabel_Click(object sender, EventArgs e)
        {
            DelLabel.ForeColor= Color.Red;
            DelLabel.Text = "*Click on the Row to Delete the Item.";
        }

        private void UC_RemoveItems_Enter(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            query = "select * from menuitems where Category like '" + cmbCategory.Text + "%'";
            DataSet ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }
    }
}
