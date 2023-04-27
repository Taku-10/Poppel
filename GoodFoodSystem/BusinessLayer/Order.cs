using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodFoodSystem.BusinessLayer
{
    internal class Order
    {

        private string orderID;
        private DateTime orderDate;
        private decimal totalAmmount;
        private Customer customer;
        public Order()
        {
            orderDate = DateTime.Now;
            totalAmmount = 0;
            orderID=null;
        }

        public string OrderID { get => orderID; set => orderID = value; }
        public string getOrderDate()
        {
            orderDate=DateTime.Now;
            return orderDate.ToString();
        }
        public decimal TotalAmmount { get => totalAmmount; set => totalAmmount += value; }
    }
}
