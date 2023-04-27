using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodFoodSystem.BusinessLayer
{
    public class Product
    {
        #region Data Member
        //encapsulation
        private string id;
        private string productName;
        private string prodescription;
        private int quantity;
        private string supplier;
        private string expiryDate;
        private double price;
        #endregion

        #region Property Methods
        

        public string ExpiryDate { get => expiryDate; set => expiryDate = value; }
        public string Id { get => id; set => id = value; }
        public string ProductName { get => productName; set => productName = value; }
        public string Prodescription { get => prodescription; set => prodescription = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public string Supplier { get => supplier; set => supplier = value; }
        public double Price { get => price; set => price = value; }
        #endregion

        #region Constructor
        public Product() : base()
        {
            
            quantity = 0;
            id = null;
            prodescription  = null;
            supplier = null;
            expiryDate = null;

        }
        #endregion

       
    }
}
