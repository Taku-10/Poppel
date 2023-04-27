using GoodFoodSystem.BusinessLayer;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using PoppelOrderProcessing.Properties;
using System.Configuration;
using GoodFoodSystem.DatabaseLayer;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using PoppelOrderProcessing.BusinessLayer;

namespace GoodFoodSystem.PresentationLayer
{
    public partial class OrderForm1 : Form

    {
        HomePage homePage;

        protected SqlConnection cnMain;

        protected SqlConnection tempCon;
        protected SqlCommand tempCmd;



        private Customer customer1;
        private double Total;
        private DB dB;
        private Collection<Order> order;
        ProductController productController;
        CustomerContoller customerContoller;
        CustomerOrder customerOrder;
        Product product;

        public OrderForm1(string customerId, string customerName, string customerEmail, string customerPhoneNumber, string customerAddress, string creditStatus, bool blacklisted)
        : this()
        {

            customer1 = new Customer();

            customer1.CustomerAddrss = customerAddress;
            customer1.CustomerName = customerName;
            customer1.CustomerId = customerId;
            customer1.CustomerEmail = customerEmail;
            customer1.setBlackist(blacklisted);
            customer1.setCreditstatus(creditStatus);
            customer1.CustomerPhoneNumber = customerPhoneNumber;


        }

        public OrderForm1()
        {
            Total = 0;
            dB = new DB();
            InitializeComponent();
            tempCon = dB.TempConn;
            cnMain = dB.CnMain;
            productController = new ProductController();
            customerContoller = new CustomerContoller();
            customerOrder = new CustomerOrder();
            product = new Product();


        }



        private void OrderForm_Load(object sender, EventArgs e)
        {

            this.WindowState = FormWindowState.Maximized;
            supplierTextBox.Visible = false;
            supplierlbl.Visible = false;
            expiryLabel.Visible = false;
            ExpiryTextBox.Visible = false;
            panel2.Visible = false;
            dataGridView3.Visible = false;
            label8.Visible = false;
            generatePickLstbtn.Visible = false;

            idTextBox.Enabled = false;
            productNameTextBox.Enabled = false;
            priceTextBox.Enabled = false;
            supplierTextBox.Enabled = false;
            ExpiryTextBox.Enabled = false;

            refreshView();


        }



        public void refreshView()
        {


            dataGridView1.DataSource = productController.getDataTable("MyProduct"); //getting dataTable of MyProduct 
            int numOfRows = dataGridView1.RowCount;
            if (numOfRows < 0)
            {
                DialogResult dialogResult = MessageBox.Show("There are no product available for sale", "", MessageBoxButtons.OKCancel);

            }

            dataGridView2.DataSource = customerContoller.GetDataTable("customerOrder");

            dataGridView1.Columns["expirydate"].Visible = false;
            dataGridView1.Columns["supplier"].Visible = false;
            dataGridView1.Columns["expirydate"].Visible = false;
            dataGridView1.Columns["quantity"].Visible = false;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                idTextBox.Text = row.Cells["ID"].Value.ToString();
                productNameTextBox.Text = row.Cells["Product Name"].Value.ToString();
                descriptionTextBox.Text = row.Cells["Description"].Value.ToString();
                ExpiryTextBox.Text = row.Cells["ExpiryDate"].Value.ToString();
                supplierTextBox.Text = row.Cells["Supplier"].Value.ToString();
                quantityTextBox.Text = row.Cells["Quantity"].Value.ToString();
                priceTextBox.Text = row.Cells["Price"].Value.ToString();
                qntyByCustktextBox1.Focus();
            }
        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            double Tprice = Convert.ToDouble(priceTextBox.Text);
            Tprice = Convert.ToInt64(qntyByCustktextBox1.Text) * Tprice;
            productCosttextBox1.Text = Tprice.ToString();
            Total += Tprice;
            if (int.Parse(qntyByCustktextBox1.Text) > int.Parse(quantityTextBox.Text))
            {
                MessageBox.Show("There is no enough products for the specified product");
            }
            else
            {

                customerOrder.ProductId1 = idTextBox.Text;
                customerOrder.ProductName1 = productNameTextBox.Text;
                customerOrder.Price1 = double.Parse(priceTextBox.Text);
                customerOrder.Quantity1 = int.Parse(qntyByCustktextBox1.Text);
                customerOrder.Total1 = Tprice;
                customerContoller.CustomerOrder = customerOrder;
                customerContoller.DataMaintenance(customer1, DB.DBOperation.Add);

                //tempQuantity = tempQuantity - int.Parse(qntyByCustktextBox1.Text);

                //UpdateProducts(tempQuantity);




                dataGridView2.DataSource = customerContoller.GetDataTable("CustomerOrder");
                qntyByCustktextBox1.Clear();


            }





        }

        private void UpdateProducts(int tempQuantity)
        {


            product.ProductName = productNameTextBox.Text;
            product.Id = idTextBox.Text;
            product.Prodescription = descriptionTextBox.Text;
            product.Supplier = supplierTextBox.Text;
            product.Quantity = tempQuantity;
            product.ExpiryDate = ExpiryTextBox.Text;
            product.Price = customerOrder.Price1;





            productController.DataMaintenance(product, DB.DBOperation.Edit);

            refreshView();


        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void backbtn_Click(object sender, EventArgs e)
        {
            homePage = new HomePage();
            homePage.Show();
            this.Close();
        }

        private void updatebtn_Click(object sender, EventArgs e)
        {

            double Tprice = Convert.ToDouble(priceTextBox.Text);
            Tprice = Convert.ToInt64(qntyByCustktextBox1.Text) * Tprice;
            productCosttextBox1.Text = Tprice.ToString();
            Total += Tprice;
            if (int.Parse(qntyByCustktextBox1.Text) > int.Parse(quantityTextBox.Text))
            {
                MessageBox.Show("There is no enough products for the specified product");
            }
            else
            {
                int tempQuantity = Convert.ToInt32(quantityTextBox.Text);

                customerOrder.ProductId1 = idTextBox.Text;
                customerOrder.ProductName1 = productNameTextBox.Text;
                customerOrder.Price1 = double.Parse(priceTextBox.Text);
                customerOrder.Quantity1 = int.Parse(qntyByCustktextBox1.Text);
                customerOrder.Total1 = Tprice;


                customerContoller.DataMaintenance(customer1, DB.DBOperation.Edit);
                dataGridView2.DataSource = customerContoller.GetDataTable("CustomerOrder");
                refreshView();
                dataGridView2.Refresh();

            }

        }

        private void deletebtn_Click(object sender, EventArgs e)
        {

        }

        private void confirmbtn_Click(object sender, EventArgs e)
        {
            DataGridViewRow row2;
            DataGridViewRow row1;
            for (int j = 0; j < dataGridView2.RowCount; j++)

            {
                row2 = this.dataGridView2.Rows[j];//CustomerOrder row

                product.Id = row2.Cells["Product Id"].Value.ToString();
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    if (dataGridView1.Rows[i].Cells["ID"].Value == null)
                    {
                        break;
                    }
                    string id = dataGridView1.Rows[i].Cells["ID"].Value.ToString();
                    if (product.Id == id)
                    {
                        product.ProductName = dataGridView1.Rows[i].Cells["Product Name"].Value.ToString();
                        product.Prodescription = dataGridView1.Rows[i].Cells["Description"].Value.ToString();
                        product.Supplier = dataGridView1.Rows[i].Cells["Supplier"].Value.ToString();
                        int tempQ = int.Parse(dataGridView1.Rows[i].Cells["Quantity"].Value.ToString());
                        tempQ = tempQ - int.Parse(row2.Cells["Quantity"].Value.ToString());
                        product.Quantity = tempQ;
                        product.ExpiryDate = dataGridView1.Rows[i].Cells["ExpiryDate"].Value.ToString();
                        product.Price = double.Parse(dataGridView1.Rows[i].Cells["Price"].Value.ToString());

                        productController.DataMaintenance(product, DB.DBOperation.Edit);
                        refreshView();


                    }



                }

            }

            DialogResult dialogResult = MessageBox.Show("Order Confirmed! \nDo you want to generate PickingList?", "", MessageBoxButtons.OKCancel);
            if (dialogResult == DialogResult.OK)
            {
                dataGridView3.DataSource = customerContoller.GetDataTable("CustomerOrder");

                dataGridView3.Columns["Total"].Visible = false;
                dataGridView3.Columns["Price"].Visible = false;
                panel2.Visible = true;
                dataGridView3.Visible = true;
                label8.Visible = true;
                cancelbtn.Visible = true;
            }
        }

        private void generatePickLstbtn_Click(object sender, EventArgs e)
        {



        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            dataGridView3.Visible = false;
            label8.Visible = false;
            cancelbtn.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            customerOrder.ProductId1 = idTextBox.Text;
            if (customerContoller.DataMaintenance(customer1, DB.DBOperation.Delete))
            {
                dataGridView2.DataSource = customerContoller.GetDataTable("CustomerOrder");
                dataGridView2.Refresh();

            }

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView2.Rows[e.RowIndex];
                deleteId.Text = row.Cells["Product Id"].Value.ToString();
            }
        }
    }
}

