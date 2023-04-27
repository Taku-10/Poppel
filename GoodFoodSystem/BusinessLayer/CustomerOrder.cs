using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoppelOrderProcessing.BusinessLayer
{
    internal class CustomerOrder
    {
        private string ProductId;
        private string ProductName;
        private double Price;
        private int Quantity;
        private double Total;

        public CustomerOrder()
        {
            ProductId = null;
            ProductName = null;
            Price = 0;
            Quantity = 0;
            Total = 0;
        }

        public string ProductId1 { get => ProductId; set => ProductId = value; }
        public string ProductName1 { get => ProductName; set => ProductName = value; }
        public double Price1 { get => Price; set => Price = value; }
        public int Quantity1 { get => Quantity; set => Quantity = value; }
        public double Total1 { get => Total; set => Total = value; }
    }
}
