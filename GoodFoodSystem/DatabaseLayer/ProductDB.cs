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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GoodFoodSystem.DatabaseLayer
{
    public class ProductDB : DB
    {
        #region  Data members 
        private string table1 = "MyProduct";
        private string sqlLocal1 = "SELECT * FROM MyProduct";
        private string duplicateProductQuery = "Select * From MyProduct Where";
        private string insertProductQuery;
        private string queryProd = "Select * From MyProduct";
        private string productsUpdateQuery = "Update MyProduct Set [Product Name]=@nm, Description=@phn, Supplier=@em, Quantity=@ad, ExpiryDate=@cr, Price=@bl Where ID=@id";
        private string deleteProductQuery = "DELETE MyProduct Where ID = @id";

   
        #endregion

        #region Property Method: Collection
      
        #endregion

        #region Constructor
        public ProductDB() : base()
        {
           

        }
        #endregion

        #region Utility Methods
        public SqlConnection GetSqlConnection()
        {
            return CnMain;
        }
      
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
        public void Build_INSERT_Parameters(Product prod)
        {

            if (cnMain.State == ConnectionState.Closed)
            {
                cnMain.Open();
            }


            string duplicateProductId = duplicateProductQuery + " ID = '" + prod.Id + "'";


            try
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(duplicateProductId, cnMain);
                DataTable dataTable = new DataTable();

                sqlDataAdapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    MessageBox.Show("Product exists already!");
                }

                else
                {
                    Create_INSERT_Command();
                    cmdMain = new SqlCommand(insertProductQuery, cnMain);


                    //Create and set the parameters

                    cmdMain.Parameters.Add("@id", SqlDbType.NVarChar).Value = prod.Id;
                    cmdMain.Parameters.Add("nm", SqlDbType.NVarChar).Value = prod.ProductName;
                    cmdMain.Parameters.Add("@ds", SqlDbType.NVarChar).Value = prod.Prodescription;
                    cmdMain.Parameters.Add("@sp", SqlDbType.NVarChar).Value = prod.Supplier;
                    cmdMain.Parameters.Add("@qn", SqlDbType.Int).Value = prod.Quantity;
                    cmdMain.Parameters.Add("@xp", SqlDbType.Date).Value = DateTime.Parse(prod.ExpiryDate);
                    cmdMain.Parameters.Add("@pr", SqlDbType.Money).Value = prod.Price;

                    //Let's ask the db to execute the insertquery
                    int rowsAdded = cmdMain.ExecuteNonQuery();
                    if (rowsAdded > 0)
                        MessageBox.Show("Product added!!");
                    else
                        //Well this should never really happen
                        MessageBox.Show("No row inserted");
                }
            }
            catch (Exception ex)
            {
                //We should log the error somewhere,
                // for this example let's just show a message
                MessageBox.Show("ERROR:" + ex.Message);
            }
            finally
            {
                cnMain.Close();
            }

        }


        private void Create_INSERT_Command()
        {
            //Create the command that must be used to insert values into the table..
            insertProductQuery = "insert into [MyProduct] ([ID], [Product Name], [Description], [Supplier], [Quantity], [ExpiryDate], [Price]) values (@id,@nm,@ds,@sp,@qn,@xp,@pr)";


        }


        private void Create_UPDATE_Command()
        {
            //Create the command that must be used to insert values into one of the three tables
            //Assumption is that the ID and EMPID cannot be changed

            productsUpdateQuery = "Update MyProduct Set [Product Name]=@nm, Description=@phn, Supplier=@em, Quantity=@ad, ExpiryDate=@cr, Price=@bl Where ID=@id";

        }
      

        public DataTable getDataTable(string table)
        {

            if (cnMain.State == ConnectionState.Closed)
            {
                cnMain.Open();
            }
            try
            {

                if (table == table1)
                {
                    DataTable dt = new DataTable(table1);


                    SqlCommand cmd = new SqlCommand(queryProd, cnMain);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                    return dt;
                }
                else if(table == "expiry")
                {
                   DataTable dt = new DataTable(table1);

                    string expiredProducts = queryProd + " Where DATEDIFF(DAY, GETDATE(), ExpiryDate) <= 0 ";


                    SqlCommand cmd = new SqlCommand(expiredProducts, cnMain);
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
            }
            return null;

        }

        public bool Build_UPDATE_Parameters(Product prod)
        {
            Create_UPDATE_Command();

            if (cnMain.State == ConnectionState.Closed)
            {
                cnMain.Open();
            }


            string qp = queryProd + " WHERE ID = '" + prod.Id + "'";

            try
            {

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(qp, cnMain);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                if (dataTable.Rows.Count <= 0)
                {
                    MessageBox.Show("Invalid product Id, Try again");
                    return false;
                }


                else
                {

                    SqlCommand cmd = new SqlCommand(productsUpdateQuery, cnMain);


                    //"Update MyProduct Set Product Name=@nm, Description=@phn, Supplier=@em, Quantity=@ad, ExpiryDate=@cr, Price=@bl Where ID=@id";
                    cmd.Parameters.Add("@id", SqlDbType.NVarChar).Value = prod.Id;
                    cmd.Parameters.Add("@nm", SqlDbType.NVarChar).Value = prod.ProductName;
                    cmd.Parameters.Add("@phn", SqlDbType.NVarChar).Value = prod.Prodescription;
                    cmd.Parameters.Add("@em", SqlDbType.NVarChar).Value = prod.Supplier;
                    cmd.Parameters.Add("@ad", SqlDbType.Int).Value = prod.Quantity;
                    cmd.Parameters.Add("@cr", SqlDbType.Date).Value = DateTime.Parse(prod.ExpiryDate);
                    cmd.Parameters.Add("@bl", SqlDbType.Money).Value = prod.Price;

                    cmd.ExecuteNonQuery();

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
            }
return false;
        }

        public void Build_DELETE_Parameters(Product prod)
        {


            if (cnMain.State == ConnectionState.Closed)
            {
                cnMain.Open();
            }

            string duplicateproductid = duplicateProductQuery + " ID = '" + prod.Id + "'";


            //// Select * from MyProduct Where"
            //string productNotFound = db.DuplicateProductQuery + " ID = '" + idTextBox.Text + "'";

            try
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(duplicateproductid, cnMain);
                DataTable dataTable = new DataTable();

                sqlDataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count <= 0)
                {
                    MessageBox.Show("Incorrect product ID or product does not exist!");
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete the product?", "", MessageBoxButtons.YesNo);

                    if (dialogResult == DialogResult.Yes)
                    {

                        SqlCommand cmd = new SqlCommand(deleteProductQuery, cnMain);
                        cmd.Parameters.Add("@id", SqlDbType.NVarChar).Value = prod.Id;


                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Product Deleted");
                    }


                }



            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:", ex.Message);
            }

            finally
            {
                cnMain.Close();
            }




        }
    }

    #endregion


}
