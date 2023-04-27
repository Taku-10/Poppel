using GoodFoodSystem.DatabaseLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Deployment.Application;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoodFoodSystem.PresentationLayer
{
    public partial class LogIn : Form
    {

       
        private DB db;
        protected SqlConnection cnMain;
        protected SqlCommand cmd;
        private HomePage homePage;

     
        public LogIn()
        {
            InitializeComponent();
            db = new DB();
            cnMain = db.CnMain;

        }

        private void button2_Click(object sender, EventArgs e)
        {

                if(cnMain.State== ConnectionState.Closed)
                {
                    cnMain.Open();
                }
               
                try
                {
                    string ad = "admin";
                    string admin = db.AdminQuery + " username = '" + usernameTextBox.Text + "' AND password = '" + passwordTextBox.Text + "'";

                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(admin, cnMain);
                    DataTable dataTable = new DataTable();
                    sqlDataAdapter.Fill(dataTable);
                    if (dataTable.Rows.Count > 0)
                    {

                        MessageBox.Show("Access granted");
                        homePage = new HomePage();
                        homePage.Show();
                        this.Hide();

                    }

                    else
                    {
                        MessageBox.Show("incorrect password or username!");
                    }

                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    cnMain.Close();
                }
    
        }

        private void signUpBtn_Click(object sender, EventArgs e)
        {
            cnMain = db.CnMain;

            if (cnMain.State== ConnectionState.Closed)
            {
                cnMain.Open();

            }

            string duplicateUsername = db.AdminQuery + " username = '" + usernameTextBox.Text +"'" ;

           
            try
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(duplicateUsername, cnMain);
                DataTable dataTable = new DataTable();

                sqlDataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count > 0)
                {
                    MessageBox.Show("Username already taken!");
                }
                else
                {
                    string signUpQuery = db.SignUpQuery;
                    cmd = new SqlCommand(signUpQuery, cnMain);
                    cmd.Parameters.Add("@usn", SqlDbType.NVarChar).Value = usernameTextBox.Text;
                    cmd.Parameters.Add("@pwd", SqlDbType.NVarChar).Value = passwordTextBox.Text;

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Signed Up!");
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

            usernameTextBox.Clear();
            passwordTextBox.Clear();

        }

        private void LogIn_Load(object sender, EventArgs e)
        {

        }
    }
}
