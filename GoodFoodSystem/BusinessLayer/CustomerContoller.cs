using GoodFoodSystem.BusinessLayer;
using GoodFoodSystem.DatabaseLayer;
using System.Collections.ObjectModel;
using System;
using System.Data.SqlClient;
using PoppelOrderProcessing.BusinessLayer;
using System.Data;

namespace GoodFoodSystem.PresentationLayer
{
    internal class CustomerContoller
    {
        #region Data Members
        private CustomerDB customerDB;//make reference 
        
        private CustomerOrder customerOrder;
        #endregion

        #region Properties
    

        internal CustomerOrder CustomerOrder { get => customerOrder; set => customerOrder = value; }
        #endregion

        #region Constructor
        public CustomerContoller()
        {
            //***instantiate the EmployeeDB object to communicate with the database
            CustomerOrder = null;
            

            customerDB = new CustomerDB();
        }
        #endregion

        #region Database Communication.
        public bool DataMaintenance(Customer cust, DB.DBOperation operation)
        {
            //calling method to do the insert
            switch (operation)
            {
                case DB.DBOperation.Add:

                    if (customerOrder == null)
                    {


                        
                        customerDB.Customer = cust;
                       return customerDB.Build_INSERT_Parameters();

                    }
                    else
                    {
                        customerDB.setInsertTable("CustomerOrder");
                        customerDB.CustomerOrder1=customerOrder;
                      return  customerDB.Build_INSERT_Parameters();
                    }


                   

                   
                case DB.DBOperation.Edit:


                    if (customerOrder == null)
                    {
                        customerDB.Customer = cust;
                    }
                    else
                    {
                        customerDB.setInsertTable("CustomerOrder");
                    }
                   return customerDB.Build_UPDATE_Parameters();
                   
                case DB.DBOperation.Delete:
                    if (customerOrder == null)
                    {
                        customerDB.Customer = cust;
                    }
                    else
                    {
                        customerDB.setInsertTable("CustomerOrder");

                    }
                    return customerDB.Build_DELETE_Parameters();
            }
            return false;
        }

        //***Commit the changes to the database
        //public bool FinalizeChanges(ProductList employee)
        //{
        //    //***call the EmployeeDB method that will commit the changes to the database
        //    return prodDB.UpdateDataSource(employee);

        //}
        #endregion

        #region Search Methods
        //This method  (function) searched through all the employess to finds onlly those with the required role
       
       
       

       

        public bool FindEmp(string v,string usr,string pass)
        {


            return customerDB.SearchEmp(v, usr,pass);
            
        }

        public DataTable FindByID(string query)
        {
            return customerDB. getFindDataTable(query);
        }
        #endregion
        public DataTable GetDataTable(string t)
        {
            return customerDB.getDataTable(t);
        }
    }

}