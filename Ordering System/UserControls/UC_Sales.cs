using DGVPrinterHelper;
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
    public partial class UC_Sales : UserControl
    {
        function fn = new function();
        String query;
        public UC_Sales()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }
        private void UC_Sales_Load(object sender, EventArgs e)
        {

            loadData();

        }
        public void loadData()
        {
            query = "select *, Price * Quantity as Total from Sales";
            DataSet ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
            int a = 0, b = 0;
            for (a = 0; a < guna2DataGridView1.Rows.Count; ++a)
            {
                b += Convert.ToInt32(guna2DataGridView1.Rows[a].Cells[6].Value);
            }
            labelTotal.Text = "PHP " + b.ToString();
        }

        private void txtSearchItem_TextChanged(object sender, EventArgs e)
        {

        }
        private void btnCalculate_Click(object sender, EventArgs e)
        {

        }
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void label7_Click(object sender, EventArgs e)
        {

        }
        private void txtItemName_TextChanged(object sender, EventArgs e)
        {
            query = "select *, Price * Quantity  as Total from Sales where Name like '" + txtItemName.Text + "%'";
            DataSet ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
            int a = 0, b = 0;
            for (a = 0; a < guna2DataGridView1.Rows.Count; ++a)
            {
                b += Convert.ToInt32(guna2DataGridView1.Rows[a].Cells[6].Value);
            }
            labelTotal.Text = "PHP " + b.ToString();
        }

        private void guna2DataGridView1_Enter(object sender, EventArgs e)
        {
            loadData();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
 
            query = "select *, Price * Quantity  as Total from Sales where OrdDate between '" + guna2DateTimePicker1.Value.ToString("yyyy-MM-dd") + "' and '" + guna2DateTimePicker2.Value.ToString("yyyy-MM-dd") + "'";
            DataSet ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
            int a = 0, b = 0;
            for (a = 0; a < guna2DataGridView1.Rows.Count; ++a)
            {
                b += Convert.ToInt32(guna2DataGridView1.Rows[a].Cells[6].Value);
            }
            labelTotal.Text = "PHP " + b.ToString();
        }


        private void btnCalculate_Click_1(object sender, EventArgs e)
        {

            
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
 
            {

                DGVPrinter printer = new DGVPrinter();
                printer.Title = "Customers Bill";
                printer.SubTitle = String.Format("Date: {0}", DateTime.Now.Date);
                printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                printer.PageNumbers = true;
                printer.PageNumberInHeader = false;
                printer.PorportionalColumns = true;
                printer.HeaderCellAlignment = StringAlignment.Near;
                printer.Footer = "Total Amount of Sales: " + labelTotal.Text;
                printer.FooterSpacing = 15;
                printer.PrintDataGridView(guna2DataGridView1);

            }
        }



        private void guna2DataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            loadData();
        }
        private void UC_Sales_Enter(object sender, EventArgs e)
        {

        }

        private void UC_Sales_Leave(object sender, EventArgs e)
        {
            labelTotal.Text = "PHP 00";
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            loadData();

            int a = 0, b = 0;
            for (a = 0; a < guna2DataGridView1.Rows.Count; ++a)
            {
                b += Convert.ToInt32(guna2DataGridView1.Rows[a].Cells[6].Value);
            }
            labelTotal.Text = "PHP " + b.ToString();
        }
    }
}
