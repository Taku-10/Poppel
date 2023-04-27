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
using System.Configuration;
using GoodFoodSystem.DatabaseLayer;
using GoodFoodSystem.BusinessLayer;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;

namespace GoodFoodSystem.PresentationLayer
{
    public partial class CustomerForm : Form
    {
        protected SqlConnection cnMain;
        protected SqlCommand cmd;
        OrderForm1 orderForm;
        HomePage homePage;
        String id;
        private DB db;
        CustomerContoller customerContoller;
        Customer customer;



        public CustomerForm(string id)
            : this()
        {

            this.id = id;
            textBox1.Text = id;
            if (id == null)
            {
                Updatebtn.Enabled = true;
                deletebtn.Enabled = true;
            }
            else
            {
                Updatebtn.Enabled = false;
                deletebtn.Enabled = false;

                Updatebtn.BackColor = Color.LightGray;
                deletebtn.BackColor = Color.LightGray;

                textBox1.Focus();

            }


        }
        public CustomerForm()
        {
            InitializeComponent();
            customer = new Customer();
            customerContoller = new CustomerContoller();
            id = null;

        }

        private void insertCustomer_Click(object sender, EventArgs e)
        {
            if (validateTextboxes() && populate())
            {


                if (customerContoller.DataMaintenance(customer, DB.DBOperation.Add)) { 
                //Open a connection & create a new dataset object

                clearAll();

                DialogResult dialogResult = MessageBox.Show("Do you want to Order for this Customer", "", MessageBoxButtons.YesNo);



                if (dialogResult == DialogResult.Yes)
                {

                    orderForm = new OrderForm1();
                    orderForm.Show();
                    this.Hide();

                }
            }
            }

        }

        private void clearAll()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox7.Clear();
            textBox8.Clear();
        }

        private void backbtn_Click(object sender, EventArgs e)
        {
            homePage = new HomePage();
            homePage.Show();
            this.Close();
            id = null;
        }

        private void CustomerForm_Load(object sender, EventArgs e)

        {
            
            this.WindowState = FormWindowState.Maximized;
            //dataGridView1.DataSource = customerContoller.GetDataTable("Customer");
            BindingSource bindingSource = new BindingSource(customerContoller.GetDataTable("Customer"), null);
            dataGridView1.DataSource = bindingSource;
            bindingNavigator1.BindingSource = bindingSource;



            textBox1.DataBindings.Add(new Binding("Text", bindingSource, "ID", true));
            textBox2.DataBindings.Add(new Binding("Text", bindingSource, "Name", true));
            textBox3.DataBindings.Add(new Binding("Text", bindingSource, "Phone", true));
            textBox4.DataBindings.Add(new Binding("Text", bindingSource, "Email", true));
            textBox5.DataBindings.Add(new Binding("Text", bindingSource, "Address", true));
            textBox7.DataBindings.Add(new Binding("Text", bindingSource, "CreditStatus", true));
            textBox8.DataBindings.Add(new Binding("Text", bindingSource, "BlackListStatus", true));

            int numOfRows = dataGridView1.RowCount;

            if (numOfRows <= 1)
            {
                DialogResult dialogResult = MessageBox.Show("There are no Customer ", "", MessageBoxButtons.OKCancel);

            }


        }

        private void Updatebtn_Click(object sender, EventArgs e)
        {

            if (validateTextboxes() && populate())
            {
              

                customerContoller.DataMaintenance(customer, DB.DBOperation.Edit);
                
            }

        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {


            if (validateTextboxes() && populate()) { 
            
                customerContoller.DataMaintenance(customer, DB.DBOperation.Delete);
                clearAll();
            }
        }

        private bool validateTextboxes()
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox7.Text != "" && textBox8.Text != "")
            {
                textBox7.Text = textBox7.Text.ToUpper();
                if (textBox7.Text == "OK" || textBox7.Text == "NO")
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("CreditStatus must be 'OK' or 'No'");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("All textboxes must not be empty");
                return false;
            }

        }

        private bool populate()
        {
            customer.CustomerId = textBox1.Text;
            customer.CustomerName = textBox2.Text;
            customer.CustomerPhoneNumber = textBox3.Text;
            customer.CustomerEmail = textBox4.Text;
            customer.CustomerAddrss = textBox5.Text;
            customer.setCreditstatus(textBox7.Text);

            try
            {
                textBox8.Text = textBox8.Text.ToLower();
         
            
                customer.setBlackist(bool.Parse(textBox8.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "The BlackListStatus must be true or false ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            textBox1.Text = row.Cells["ID"].Value.ToString();
            textBox2.Text = row.Cells["Name"].Value.ToString();
            textBox3.Text = row.Cells["Phone"].Value.ToString();
            textBox4.Text = row.Cells["Email"].Value.ToString();
            textBox5.Text = row.Cells["Address"].Value.ToString();
            textBox7.Text = row.Cells["CreditStatus"].Value.ToString();
            textBox8.Text = row.Cells["BlackListStatus"].Value.ToString();


        }

        private void bindingNavigator1_RefreshItems(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            clearAll();
        }
    }
}


