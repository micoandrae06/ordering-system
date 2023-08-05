using DGVPrinterHelper;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Ordering_System.UserControls
{
    public partial class UC_PlaceOrder : UserControl
    {


        function fn = new function();
        String query;

        public UC_PlaceOrder()
        {
            InitializeComponent();
        }


        private void comboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            String category = comboCategory.Text;
            query = "select Name from menuitems where Category = '" + category + "'";
            showItemList(query);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            String category = comboCategory.Text;
            query = "select Name from menuitems where Category = '" + category + "'and Name like '" + txtSearch.Text + "%'";
            showItemList(query);
        }
        private void showItemList(String query)
        {
            listBox1.Items.Clear();
            DataSet ds = fn.getData(query);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                listBox1.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtQuantity.ResetText();
            txtTotal.Clear();

            String text = listBox1.GetItemText(listBox1.SelectedItem);
            txtItemName.Text = text;


            query = "select Price from menuitems where Name = '" + text + "' ";
            DataSet ds = fn.getData(query);

            try
            {
                txtPrice.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            catch { }
        }

        private void txtQuantity_ValueChanged(object sender, EventArgs e)
        {

            quan();

        }
        public void quan()
        {
            Int64 quan = Int64.Parse(txtQuantity.Value.ToString());
            Int64 price = Int64.Parse(txtPrice.Text);
            txtTotal.Text = (quan * price).ToString();
        }

        protected int number, total = 0;


        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void btnRemove_Click(object sender, EventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "Customers Bill";
            printer.SubTitle = String.Format("Date: {0}", DateTime.Now.Date);
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "Total Payable Amount: " + labelTotalAmount.Text;
            printer.FooterSpacing = 15;
            printer.PrintDataGridView(guna2DataGridView1);

            total = 0;
            guna2DataGridView1.Rows.Clear();
            labelTotalAmount.Text = "PHP " + total;
        }



        private void UC_PlaceOrder_Load(object sender, EventArgs e)
        { 
            labelDate.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");
        }

        private void labelTotalAmount_Click(object sender, EventArgs e)
        {

        }

        private void btnBuy_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void btnRemove_Click_1(object sender, EventArgs e)
        {


        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                guna2DataGridView1.SelectAll();
                guna2DataGridView1.Rows.Clear();
                guna2DataGridView1.Refresh();
            }
            catch
            { }
            total = 0;
            labelTotalAmount.Text = "PHP " + total;
        }


        private void guna2DataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSelect_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void txtStatus_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelDate_Click(object sender, EventArgs e)
        {

        }

        private void btnBuyNow_Click(object sender, EventArgs e)
        {
            query = "insert into Sales (Name, Category, Quantity, OrdDate ,Price) values('" + txtItemName.Text + "', '" + comboCategory.Text + "', '" + txtQuantity.Text + "' ,'" + labelDate.Text + "' , " + txtPrice.Text + ")";
            fn.setData(query);
            if (txtTotal.Text != "0" && txtTotal.Text != "")
            {
                number = guna2DataGridView1.Rows.Add();
                guna2DataGridView1.Rows[number].Cells[0].Value = txtItemName.Text;
                guna2DataGridView1.Rows[number].Cells[1].Value = txtPrice.Text;
                guna2DataGridView1.Rows[number].Cells[2].Value = txtQuantity.Text;
                guna2DataGridView1.Rows[number].Cells[3].Value = txtTotal.Text;

                total = total + int.Parse(txtTotal.Text);
                labelTotalAmount.Text = "PHP " + total;
            }

            else
            {
                MessageBox.Show("Minimun Quantity need to be 1", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
    }
}
