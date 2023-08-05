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
    public partial class UC_Stocks : UserControl
    {
        function fn = new function();
        String query;
        public UC_Stocks()
        {
            InitializeComponent();
        }
        public void loadData()
        {
            query = "select *, UnitPrice * Available as Total from Stock";
            DataSet ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
            guna2DataGridView1.ColumnHeadersVisible = true;
        }
        public void clearAll()
        {
            txtCategory.SelectedIndex = -1;
            txtName.Clear();
            txtPrice.Clear();
            txtStatus.SelectedIndex = -1;
            txtQuantity.Clear();

        }
        private void UC_Stocks_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtCategory.Text == "" || txtPrice.Text == "" || txtStatus.Text == "" || txtQuantity.Text == "")
            {
                MessageBox.Show("Please Fill in the Blank");
            }
            else
            {
                query = "insert into Stock (Name, Category, Available, UnitPrice, Status) values('" + txtName.Text + "', '" + txtCategory.Text + "', '" + txtQuantity.Text + "', " + txtPrice.Text + ", '" + txtStatus.Text + "')";
                fn.setData(query);
                clearAll();
                loadData();
            }
        }

        private void UC_Stocks_Enter(object sender, EventArgs e)
        {
            loadData();

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2DataGridView1_Enter(object sender, EventArgs e)
        {
            loadData();
        }

        private void txtItemName_TextChanged(object sender, EventArgs e)
        {
            query = "select *, UnitPrice * Available  as Total from Stock where Name like '" + txtSerch.Text + "%'";
            DataSet ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
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
            printer.FooterSpacing = 15;
            printer.PrintDataGridView(guna2DataGridView1);
        }

        private void UC_Stocks_Leave(object sender, EventArgs e)
        {
            clearAll();
        }

        int id;
        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = int.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            String Category = guna2DataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            String Name = guna2DataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            int Price = int.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
            int Available = int.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
            String Status = guna2DataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();

            txtCategory.Text = Category;
            txtName.Text = Name;
            txtPrice.Text = Price.ToString();
            txtQuantity.Text = Available.ToString();
            txtStatus.Text = Status;

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtCategory.Text == "" || txtPrice.Text == "" || txtStatus.Text == "" || txtQuantity.Text == "")
            {
                MessageBox.Show("Please Select the Item you want to Edit");
            }
            else
            {
                query = "update Stock set Name = '" + txtName.Text + "', Category = '" + txtCategory.Text + "', UnitPrice =" + txtPrice.Text + ", Available =" + txtQuantity.Text + ", Status ='" + txtStatus.Text + "' where Id = " + id + "";
                fn.setData(query);
                loadData();
                clearAll();
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            loadData();
            clearAll();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtCategory.Text == "" || txtPrice.Text == "" || txtStatus.Text == "" || txtQuantity.Text == "")
            {
                MessageBox.Show("Please Select the Item you want to Delete");
            }
            else
            {
                query = "delete from Stock where Id = " + id + "";
                fn.setData(query);
                loadData();
                clearAll();
            }
        }
    }
}
