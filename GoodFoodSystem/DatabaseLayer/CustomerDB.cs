using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoodFoodSystem.BusinessLayer;
using System.Windows.Forms;
using PoppelOrderProcessing.BusinessLayer;
using System.Collections;
using System.Drawing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Diagnostics;

namespace GoodFoodSystem.DatabaseLayer
{
    public class CustomerDB : DB
    {
        #region  Data members 
        private string table1 = "Customer";
        private string sqlLocal1 = "SELECT * FROM Customer";
        private string table2 = "CustomerOrder";
        private string sqlLocal2 = "SELECT * FROM CustomerOrder";
        private string table3 = "Orders";
        private string sqlLocal3 = "SELECT * FROM Orders";

        private string searchQuery1 = "Select * From Admin Where" + " username = '";
        private string searchQuery2 = "' AND password = '";
        private string searchQuery3 = "' AND role ='";
        private string seachbyIdquery = "Select * From Customer where Id = @Id";
        private string customerDeleteQuery;
        private string customerUpdateQuery;
        private string insertquery;
        private string query;
        private string customerOrderUpdate;
        private string custOrderDeletequery;
        private CustomerOrder CustomerOrder;
        private string insTable;

        
        //+ usernameTextBox.Text + "' AND password = '" + passwordTextBox.Text + "' AND role ='" + ad + "'";


        #endregion


        private Customer customer;
        #region Constructor
        public CustomerDB() : base()
        {
            insTable = "";
            CustomerOrder1 = null;
            customer = null;

        }
        #endregion

        #region Utility Properties

        public string SearchQuery1 { get => searchQuery1; set => searchQuery1 = value; }
        public string SearchQuery2 { get => searchQuery2; set => searchQuery2 = value; }
        public string SearchQuery3 { get => searchQuery3; set => searchQuery3 = value; }
        internal Customer Customer { get => customer; set => customer = value; }
        internal CustomerOrder CustomerOrder1 { get => CustomerOrder; set => CustomerOrder = value; }


        #endregion

        #region Database Operations CRUD
        #endregion

        #region Understanding Parameters
        /*
        2.2.1	In this program, we have been using SQL Parameter class. 
                What are the benefits of using SQL Parameters in this program.
                >>allows you to safely pass a parameter to a SqlCommand object in .NET. 
                >>A security best practice when writing .NET data access code, is to always 
                >>use parameters in SqlCommand objects (whenever parameters are required of course). 
                https://www.sqlnethub.com/blog/using-the-csharp-sqlparameter-object-writing-more-secure-code/#:~:text=C%23%20SqlParameter%20is%20a%20handy,parameters%20are%20required%20of%20course).
        
        
        2.2.2	The update command is actioned by which of the ADO.NET classes?
                >> DataAdapter 
                >>used to retrieve data from a data source and populate tables within
                >>a DataSet and resolves changes made to the DataSet back to the data source. 
                >>The DataAdapter uses the Connection object of the .NET data provider 
                >>to connect to a data source, and Command objects to retrieve data from 
                and resolve changes to the data source.
                >>The DataAdapter serves as a bridge between a DataSet and a data source for retrieving and
                >>saving data. The DataAdapter provides this bridge by mapping Fill, which changes
                >>the data in the DataSet to match the data in the data source, and Update,
                >>which changes the data in the data source to match the data in the DataSet.

        2.2.3	What is the purpose of SqlDbType enumeration in this program?
                >> to specify SQL Server-specific data type of a field, property, for use in
                >>a SqlParameter.
                >>https://docs.microsoft.com/en-us/dotnet/api/system.data.sqldbtype?view=net-6.0 
                >>Used to set the SQL Server Datatypes for a given parameter.
        */
        #endregion

        #region Build Parameters, Create Commands & Update database



        public bool Build_UPDATE_Parameters()
        {
            Create_UPDATE_Command();

            if (cnMain.State == ConnectionState.Closed)
            {
                cnMain.Open();
            }
            if (tempConn.State == ConnectionState.Closed)
            {
                tempConn.Open();
            }


            string co = sqlLocal2 + " WHERE Product Id = '" + CustomerOrder.ProductId1 + "'";

            try
            {
                if (insTable == "")
                {
                    string qp = sqlLocal1 + " WHERE ID = '" + customer.CustomerId + "'";

                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(qp, cnMain);
                    DataTable dataTable = new DataTable();
                    sqlDataAdapter.Fill(dataTable);

                    if (dataTable.Rows.Count <= 0)
                    {
                        MessageBox.Show("Invalid customer Id, Try again");
                        return false;
                    }


                    else
                    {

                        SqlCommand cmd = new SqlCommand(customerUpdateQuery, cnMain);


                        //"Update MyProduct Set Product Name=@nm, Description=@phn, Supplier=@em, Quantity=@ad, ExpiryDate=@cr, Price=@bl Where ID=@id";
                        cmd.Parameters.Add("@id", SqlDbType.NVarChar).Value = customer.CustomerId;
                        cmd.Parameters.Add("@nm", SqlDbType.NVarChar).Value = customer.CustomerName;
                        cmd.Parameters.Add("@phn", SqlDbType.NVarChar).Value = customer.CustomerPhoneNumber;
                        cmd.Parameters.Add("@em", SqlDbType.NVarChar).Value = customer.CustomerEmail;
                        cmd.Parameters.Add("@ad", SqlDbType.NVarChar).Value = customer.CustomerAddrss;
                        cmd.Parameters.Add("@cr", SqlDbType.NVarChar).Value = customer.getCreditstatus();
                        cmd.Parameters.Add("@bl", SqlDbType.NVarChar).Value = customer.getBlacklist();

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Customer Details Updated!");
                        return true;

                    }
                }

                else if (insTable == table2)
                {

                    //SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(co, tempConn);
                    //DataTable dataTable = new DataTable();
                    //sqlDataAdapter.Fill(dataTable);

                    //if (dataTable.Rows.Count <= 0)
                    //{
                    //MessageBox.Show("Invalid product Id, Try again");
                    //return false;
                    //}
                    //else
                    //{
                    Create_UPDATE_Command();
                    SqlCommand cmd = new SqlCommand(customerOrderUpdate, cnMain);
                    cmd.Parameters.Add("@id", SqlDbType.NVarChar).Value = CustomerOrder1.ProductId1;
                    cmd.Parameters.Add("@pn", SqlDbType.NVarChar).Value = CustomerOrder1.ProductName1;
                    cmd.Parameters.Add("@pr", SqlDbType.NVarChar).Value = CustomerOrder1.Price1;
                    cmd.Parameters.Add("@qn", SqlDbType.NVarChar).Value = CustomerOrder1.Quantity1;
                    cmd.Parameters.Add("@to", SqlDbType.NVarChar).Value = CustomerOrder1.Total1;
                    //}
                    //} cmd.ExecuteNonQuery();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show(" Updated!");
                    return true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

            finally
            {
                cnMain.Close();
                TempConn.Close();
            }
            return false;
        
        }

        public bool Build_DELETE_Parameters()
        {
            Create_Delete_Command();

            if (cnMain.State == ConnectionState.Closed)
            {
                cnMain.Open();
            }

            try
            {

               


                if (insTable == "")
                {
                    string customerduplicate = sqlLocal1 + " Where ID = '" + customer.CustomerId + "'";
                    //checking if we are deleting for customer table  which is true when insTable is empty
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(customerduplicate, cnMain);
                    DataTable dataTable = new DataTable();

                    sqlDataAdapter.Fill(dataTable);
                    if (dataTable.Rows.Count <= 0)
                    {
                        MessageBox.Show("Incorrect Customer ID or Customer does not exist!");
                        return false;
                    }
                    else
                    {
                        DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete the Customer?", "", MessageBoxButtons.YesNo);

                        if (dialogResult == DialogResult.Yes)
                        {

                            SqlCommand cmd = new SqlCommand(customerDeleteQuery, cnMain);
                            cmd.Parameters.Add("@id", SqlDbType.NVarChar).Value = customer.CustomerId;


                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Customer Deleted");
                            return true;
                        }


                    }
                }
                else if (insTable == table2)
                {
                    //when deleting an item in Customer Order


                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlLocal2, tempConn);
                    DataTable dataTable = new DataTable();

                    sqlDataAdapter.Fill(dataTable);
                    if (dataTable.Rows.Count <= 0)
                    {
                        MessageBox.Show("Incorrect Product ID or item does not exist!");
                        return false;
                    }
                    else
                    {
                        DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this item?", "", MessageBoxButtons.YesNo);

                        if (dialogResult == DialogResult.Yes)
                        {

                            SqlCommand cmd = new SqlCommand(customerDeleteQuery, cnMain);
                            cmd.Parameters.Add("@id", SqlDbType.NVarChar).Value = CustomerOrder.ProductId1;


                            cmd.ExecuteNonQuery();

                            MessageBox.Show("item Deleted");
                            return true;
                        }


                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:", ex.Message);
                return false;
            }

            finally
            {
                cnMain.Close();
            }


            return false;

        }
        public bool Build_INSERT_Parameters()
        {

            if (cnMain.State == ConnectionState.Closed)
            {
                // Open the connection to the database. 
                // This is the first critical step in the process.
                // If we cannot reach the db then we have connectivity problems


                // Prepare the command to be executed on the db
                cnMain.Open();
            }

            if (tempConn.State == ConnectionState.Closed)
            {
                tempConn.Open();
            }


            try
            {
                Create_INSERT_Command();

                if (insTable == "")
                {

                    cmdMain = new SqlCommand(insertquery, cnMain);


                    //Create and set the parameters
                    //@id,@nm,@phn,@em,@ad,@cr,@bl
                    cmdMain.Parameters.Add("@id", SqlDbType.NVarChar).Value = customer.CustomerId;
                    cmdMain.Parameters.Add("nm", SqlDbType.NVarChar).Value = customer.CustomerName;
                    cmdMain.Parameters.Add("@phn", SqlDbType.NVarChar).Value = customer.CustomerPhoneNumber;
                    cmdMain.Parameters.Add("@em", SqlDbType.NVarChar).Value = customer.CustomerEmail;
                    cmdMain.Parameters.Add("@ad", SqlDbType.NVarChar).Value = customer.CustomerAddrss;
                    cmdMain.Parameters.Add("@cr", SqlDbType.NVarChar).Value = customer.getCreditstatus();
                    cmdMain.Parameters.Add("@bl", SqlDbType.NVarChar).Value = customer.getBlacklist().ToString();

                    //Let's ask the db to execute the insertquery
                    int rowsAdded = cmdMain.ExecuteNonQuery();
                    if (rowsAdded > 0)
                    {
                        MessageBox.Show("Customer added!!");
                        return true;
                    }

                    else
                    {
                        //Well this should never really happen
                        MessageBox.Show("No row inserted");
                        return false;
                    }
                }
                else if (insTable == table2)
                {

                    SqlCommand cmd = new SqlCommand(query, tempConn);

                    cmd.Parameters.Add("@id", SqlDbType.NVarChar).Value = CustomerOrder1.ProductId1;
                    cmd.Parameters.Add("@pn", SqlDbType.NVarChar).Value = CustomerOrder1.ProductName1;
                    cmd.Parameters.Add("@pr", SqlDbType.NVarChar).Value = CustomerOrder1.Price1;
                    cmd.Parameters.Add("@qn", SqlDbType.NVarChar).Value = CustomerOrder1.Quantity1; ;
                    cmd.Parameters.Add("@to", SqlDbType.NVarChar).Value = CustomerOrder1.Total1;



                    // Let's ask the db to execute the insertquery
                    int rowsAdded = cmd.ExecuteNonQuery();
                    if (rowsAdded > 0)
                    {
                        MessageBox.Show("Item added!");
                        return true;
                    }
                }

            }
            catch (Exception ex)
            {
                //We should log the error somewhere,
                // for this example let's just show a message
                MessageBox.Show("ERROR:" + ex.Message);
                return false;
            }
            finally
            {
                cnMain.Close();
                tempConn.Close();
            }

            return false;
        }
        public void setInsertTable(string table)
        {
            insTable = table;
        }

        private void Create_INSERT_Command()
        {
            //Create the command that must be used to insert values into the table..
            insertquery = "insert into [Customer] ([ID], [Name], [Phone], [Email], [Address], [CreditStatus], [BlackListStatus]) values (@id,@nm,@phn,@em,@ad,@cr,@bl)";
            query = "insert into [CustomerOrder] ([Product Id], [Product Name], [Price], [Quantity], [Total]) values (@id,@pn,@pr,@qn,@to)";


        }
        private void Create_UPDATE_Command()
        {


            customerUpdateQuery = "Update [Customer] Set Name=@nm, Phone=@phn, Email=@em, Address=@ad, CreditStatus=@cr, BlackListStatus=@bl Where ID=@id";
            customerOrderUpdate = "Update [CustomerOrder] Set [Product Name]=@pn, [Price]=@pr,[Quantity]=@qn, [Total]=@to Where [Product Id]=@id";

            //@id,@pn,@pr,@qn,@to


        }
        private void Create_Delete_Command()
        {
            customerDeleteQuery = "Delete Customer Where ID=@id";
            custOrderDeletequery = "Delete [CustomerOrder] Where [Product ID]=@id";
        }


        #endregion

        #region Find dataTable and Search Methods
        public bool SearchEmp(string v, string usr, string pass)
        {

            SqlDataAdapter sqlDataAdapter;
            if (cnMain.State == ConnectionState.Closed)
            {
                cnMain.Open();
            }


            try
            {


                if (v == "Admin")
                {
                    //         private string searchQuery1 = "Select * From Admin Where" + " username = '";
                    //private string searchQuery2 = "' AND password = '";
                    //private string searchQuery3 = "' AND role ='";

                    string ad = "admin";
                    v = searchQuery1 + usr + searchQuery2 + pass + searchQuery3 + ad + "'";



                    sqlDataAdapter = new SqlDataAdapter(v, cnMain);


                    DataTable dataTable = new DataTable();
                    sqlDataAdapter.Fill(dataTable);
                    if (dataTable.Rows.Count > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                else if (v == "Customer")
                {
                    return false;
                }
            }
            catch { }
            finally { cnMain.Close(); }
            return false;

        }

        public DataTable getFindDataTable(string id)
        {


            if (cnMain.State == ConnectionState.Closed)
            {
                cnMain.Open();
            }
            try
            {
                DataTable dataTable = new DataTable("Customer");
                SqlCommand cmd = new SqlCommand(seachbyIdquery, cnMain);
                cmd.Parameters.Add("@Id", SqlDbType.NVarChar).Value = id;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dataTable);
                return dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cnMain.Close();
            }
            return null;

        }
        public DataTable getDataTable(string table)
        {

            if (cnMain.State == ConnectionState.Closed)
            {
                cnMain.Open();
            }

            if (tempConn.State == ConnectionState.Closed)
            {
                tempConn.Open();
            }


            try
            {

                if (table == table1)
                {
                    DataTable dt = new DataTable(table1);


                    SqlCommand cmd = new SqlCommand(sqlLocal1, cnMain);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                    return dt;
                }
                else if (table == table2)
                {

                    DataTable dt = new DataTable(table1);
                    SqlCommand cmd = new SqlCommand(sqlLocal2, tempConn);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                    return dt;

                }
                else if (table == table3)
                {
                    DataTable dt = new DataTable(table);
                    SqlCommand cmd = new SqlCommand(sqlLocal3, cnMain);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                    return dt;
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cnMain.Close();
                tempConn.Close();
            }
            return null;

        }
        #endregion



    }
}
