using GoodFoodSystem.DatabaseLayer;
using System;
using System.Collections.ObjectModel;
using System.Data;

namespace GoodFoodSystem.BusinessLayer
{
    public class ProductController
    {
        #region Data Members
        private  ProductDB prodDB;//make reference 
       
        private  Customer customer;
        private CustomerDB customerDB;
        #endregion

        #region Properties
       
        #endregion

        #region Constructor
        public ProductController()
        {
            //***instantiate the EmployeeDB object to communicate with the database
           prodDB = new ProductDB();
            
        }
        #endregion

        #region Database Communication.
        public void DataMaintenance(Product prod, DB.DBOperation operation)
        {
           //calling method to do the insert
            switch (operation)
            {
                case DB.DBOperation.Add:
                    prodDB.Build_INSERT_Parameters(prod);
                   
                    break;
                case DB.DBOperation.Edit:
                    prodDB.Build_UPDATE_Parameters(prod);
                    break;
                case DB.DBOperation.Delete:
                    prodDB.Build_DELETE_Parameters(prod);

                    break;
            }
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
      

      
      
        public DataTable getDataTable(string table)
        {
            return prodDB.getDataTable(table);
        }

       
        #endregion
    }
}
