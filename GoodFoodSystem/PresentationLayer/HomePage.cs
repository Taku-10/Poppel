using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using GoodFoodSystem.BusinessLayer;
using GoodFoodSystem.DatabaseLayer;
using System.Runtime.CompilerServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Configuration;
using PoppelOrderProcessing.BusinessLayer;

namespace GoodFoodSystem.PresentationLayer
{
    public partial class HomePage : Form
    {
        protected SqlConnection cnMain;
        protected SqlCommand cmd;
        private OrderForm1 orderForm;
        private CustomerForm customerForm;
        private ProductController productController;
        private CustomerContoller customerContoller;
        private Product product;
        private Employee emp;
        
        private string nm;
        private string id;
        private string phone;
        private string email;
        private string address;
        private string creditstatus;
        private string blacklistatus;
        private LogIn logIn;
        private DB db;
        private bool isgranted=false;
        private bool mouseDown;
        private bool skip;
        private bool its_Product;

        public HomePage()

        {
            InitializeComponent();

            productController = new ProductController();
            customerContoller = new CustomerContoller();
            product = new Product();
            emp = new Employee();
           skip = false;
            its_Product = false;
            loMode.Visible = false;
            
        }
        




        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void button5_Click(object sender, EventArgs e)
        {
            disable_All();

            string searchId = searchTextBox.Text;
           
                
                dataGridView1.DataSource=customerContoller.FindByID(searchId);
            int numOfRows = dataGridView1.RowCount;
            if (numOfRows <= 1)

                {
                    DialogResult dialogResult = MessageBox.Show("The customer is not registered do you want register?", "", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        customerForm = new CustomerForm(searchTextBox.Text);
                        customerForm.Show();
                        this.Hide();
                    }
                }
                else {


                    //DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                   int n = dataGridView1.RowCount;
                    DataGridViewRow row = this.dataGridView1.Rows[0];
                     nm = row.Cells["Name"].Value.ToString();
                     id = row.Cells["ID"].Value.ToString();
                     phone = row.Cells["Phone"].Value.ToString();
                     email = row.Cells["Email"].Value.ToString();
                     address = row.Cells["Address"].Value.ToString();
                     creditstatus = row.Cells["CreditStatus"].Value.ToString();
                     blacklistatus = row.Cells["BlackListStatus"].Value.ToString();


                }
                
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

            if (its_Product)
            {
                idTextBox.Text = row.Cells["ID"].Value.ToString();
                productNameTextBox.Text = row.Cells["Product Name"].Value.ToString();
                descriptionTextBox.Text = row.Cells["Description"].Value.ToString();
                supplierTextBox.Text = row.Cells["Supplier"].Value.ToString();
                quantityTextBox.Text = row.Cells["Quantity"].Value.ToString();
                ExpiryTextBox.Text = row.Cells["ExpiryDate"].Value.ToString();

                priceTextBox.Text = row.Cells["Price"].Value.ToString();

                
            }


        }

        private void searchTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                searchbtn.PerformClick();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void startOrderbtn_Click(object sender, EventArgs e)
        {

            if (creditstatus == "OK" && blacklistatus == "False")
            {

                DialogResult dialogResult = MessageBox.Show("Do you want to order for " + nm + "?", "", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    orderForm = new OrderForm1(id, nm, email, phone, address, creditstatus, bool.Parse(blacklistatus));

                    
                    orderForm.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("This customer is either blackListed or the credit status is not ok!");
            }

        }

        private void viewCustomrbtn_Click(object sender, EventArgs e)
        {
            its_Product = false;
            searchbtn.Visible = true;
            searchTextBox.Visible = true;
            disable_All();


            DialogResult dialogResult1 = MessageBox.Show("Do you want to ADD or Delete or Update Customer ?", "", MessageBoxButtons.YesNo);

            if (dialogResult1 == DialogResult.Yes)
            {

                CustomerForm l = new CustomerForm();
                l.Show();
                this.Hide();



            }
            else
            {


                dataGridView1.DataSource = customerContoller.GetDataTable("Customer");

                int numOfRows = dataGridView1.RowCount;

                if (numOfRows <= 1)
                {
                    DialogResult dialogResult = MessageBox.Show("There are no Customer ", "", MessageBoxButtons.OKCancel);

                }
            }

        }

        private void HomePage_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            disable_All();
            
            adminlabel.Text = "Clerk Mode";

            searchTextBox.Text = "Search Customer by ID HERE";
            loginpanelHide();

            if (isgranted)
            {

             

                idTextBox.Enabled = true;
                productNameTextBox.Enabled = true;
                descriptionTextBox.Enabled = true;
                supplierTextBox.Enabled = true;
                quantityTextBox.Enabled = true;
                ExpiryTextBox.Enabled = true;
                priceTextBox.Enabled = true;
            }
            ExpiryTextBox.Text = "dd/mm/yyyy";


        }

        private void disable_All()
        {
            idTextBox.Enabled = false;
            productNameTextBox.Enabled = false;
            descriptionTextBox.Enabled = false;
            supplierTextBox.Enabled = false;
            quantityTextBox.Enabled = false;
            ExpiryTextBox.Enabled = false;
            priceTextBox.Enabled = false;
            idTextBox.Visible = false;
            productNameTextBox.Visible = false;
            descriptionTextBox.Visible = false;
            supplierTextBox.Visible = false;
            quantityTextBox.Visible = false;
            ExpiryTextBox.Visible = false;
            priceTextBox.Visible = false;
            addbtn.Visible = false;
            deletebtn.Visible = false;
            updatebtn.Visible = false;
            idLabel.Visible = false;
            priceLabel.Visible = false;
            supplierlbl.Visible = false;
            descriptionLabel.Visible = false;
            quantityLabel.Visible = false;
            expiryLabel.Visible = false;
            prodnameLabel.Visible = false;
            idLabel.Visible = false;
            updatebtn.Visible = false;
            addbtn.Visible = false;
            deletebtn.Visible = false;
            adminlabel.Visible = false;
        }

        private void loginpanelHide()
        {
            loginPanel.Visible = false;
            usernameTextBox.Visible = false;
            passwordTextBox.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;

        }

        private void logibtnb_Click(object sender, EventArgs e)
        {
            logIn = new LogIn();
            logIn.Show();
            this.Hide();
        }

        private void viewProductbtn_Click(object sender, EventArgs e)
        {
            its_Product = true;
            searchbtn.Visible = false;
            searchTextBox.Visible = false;
            dataGridView1.DataSource = productController.getDataTable("MyProduct");

            if (!skip)
            {
                int numOfRows = dataGridView1.RowCount;

            if (numOfRows <= 1)
            {
                DialogResult dialogResult = MessageBox.Show("There are no product available for sale", "", MessageBoxButtons.OKCancel);

            }

            idTextBox.Enabled = false;
            productNameTextBox.Enabled = false;
            descriptionTextBox.Enabled = false;
            supplierTextBox.Enabled = false;
            quantityTextBox.Enabled = false;
            ExpiryTextBox.Enabled = false;
            priceTextBox.Enabled= false;

            ShowAll(true);
            adminlabel.Visible=true;
           
                DialogResult dialogResult1 = MessageBox.Show("Do you want to edit products?", "", MessageBoxButtons.YesNo);

                if (dialogResult1 == DialogResult.Yes)
                {
                    loginPanel.Visible = true;
                    usernameTextBox.Visible = true;
                    passwordTextBox.Visible = true;
                    label1.Visible = true;
                    label2.Visible = true;
                    label3.Visible = true;
                    signInbtn.Visible = true;
                    cancelbtn.Visible = true;
                    loMode.Visible = true;



                }
                else
                {
                    adminlabel.Text = "Clerk Mode";
                }
            }
            skip = false;

        }

        private void ShowAll(bool v)
        {

            idTextBox.Visible = v;
            productNameTextBox.Visible = v;
            descriptionTextBox.Visible = v;
            supplierTextBox.Visible = v;
            quantityTextBox.Visible = v;
            ExpiryTextBox.Visible = v;
            priceTextBox.Visible = v;
            idLabel.Visible = v;
            priceLabel.Visible = v;
            supplierlbl.Visible = v;
            descriptionLabel.Visible = v;
            quantityLabel.Visible = v;
            prodnameLabel.Visible = v;
            expiryLabel.Visible = v;

        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            cancelbtn.Visible = false;
            loginPanel.Visible = false;
            signInbtn.Visible = false;
            label1.Visible=false;
            label2.Visible = false; 
            label3.Visible=false;   
            passwordTextBox.Visible = false;
            usernameTextBox.Visible = false;
            
        }

        private void loginPanel_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
        }

        private void loginPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                int mousex= MousePosition.X - 400;
                int mousey = MousePosition.Y - 20;
               
            }

        }

        private void signInbtn_Click(object sender, EventArgs e)
        {

            emp.Username = usernameTextBox.Text;
            emp.Password = passwordTextBox.Text;

            if (customerContoller.FindEmp("Admin", emp.Username, emp.Password))
            {
                MessageBox.Show("Access granted!");
                idTextBox.Enabled = true;
                productNameTextBox.Enabled = true;
                descriptionTextBox.Enabled = true;
                supplierTextBox.Enabled = true;
                quantityTextBox.Enabled = true;
                ExpiryTextBox.Enabled = true;
                priceTextBox.Enabled = true;
                adminlabel.Visible = true;
                adminlabel.Text = "Admin Mode";
                usernameTextBox.Clear();
                passwordTextBox.Clear();
                updatebtn.Visible = true;
                addbtn.Visible = true;
                deletebtn.Visible = true;

                loginpanelHide();
            }
            else
            {
                MessageBox.Show("incorrect password or username!");
                adminlabel.Text = "Clerk Mode";

            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            disable_All();
            adminlabel.Text = "Clerk Mode";
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            product.Id = idTextBox.Text;
            productController.DataMaintenance(product, DB.DBOperation.Delete);

            skip = true;
            viewProductbtn.PerformClick();
            idTextBox.Clear();
            productNameTextBox.Clear();
            descriptionTextBox.Clear();
            supplierTextBox.Clear();
            quantityTextBox.Clear();
            ExpiryTextBox.Clear();
            priceTextBox.Clear();


        }


        private void addbtn_Click(object sender, EventArgs e)
        {
            
            product.Id = idTextBox.Text;
            product.ProductName = productNameTextBox.Text;
            product.Prodescription= descriptionTextBox.Text;
            product.Supplier=  supplierTextBox.Text;
            product.Quantity = int.Parse(quantityTextBox.Text);
            product.ExpiryDate= ExpiryTextBox.Text;
            product.Price = double.Parse(priceTextBox.Text);

            productController.DataMaintenance(product, DB.DBOperation.Add);
            skip=true;
            viewProductbtn.PerformClick();



        }

        private void updatebtn_Click(object sender, EventArgs e)
        {

            product.Id = idTextBox.Text;
            product.ProductName = productNameTextBox.Text;
            product.Prodescription = descriptionTextBox.Text;
            product.Supplier = supplierTextBox.Text;
            product.Quantity = int.Parse(quantityTextBox.Text);
            product.ExpiryDate = ExpiryTextBox.Text;
            product.Price = double.Parse(priceTextBox.Text);

            productController.DataMaintenance(product, DB.DBOperation.Edit);
            idTextBox.Clear();
            productNameTextBox.Clear();
            descriptionTextBox.Clear();
            supplierTextBox.Clear();
            quantityTextBox.Clear();
            ExpiryTextBox.Clear();
            priceTextBox.Clear();
            skip = true;
            viewProductbtn.PerformClick();//calling viewProduction_Click Method

        }

        private void expiredProductsBtn_Click(object sender, EventArgs e)
        {

            dataGridView1.DataSource = productController.getDataTable("expiry");

            int numOfRows = dataGridView1.RowCount;

            if (numOfRows < 0)
            {
                MessageBox.Show("There are no expired products");

            }


        }
    }
    }

