using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodFoodSystem.BusinessLayer
{
    internal class Customer
    {
        private string customerId;
        private string customerName;
        private string customeremail;
        private string customerPhoneNumber;
        private string customerAddress;
        private string creditStatus;
        private bool blacklisted;


        public Customer(string customerId, string customerName, string customerEmail, string customerPhoneNumber, string customerAddress, string creditStatus, bool blacklisted)
        : this()
        {

            this.customerId = customerId;
            this.customerName = customerName;
            customeremail = customerEmail;
            CustomerPhoneNumber = customerPhoneNumber;
            this.customerAddress = customerAddress;
            this.creditStatus = creditStatus;
            this.blacklisted = blacklisted;
        }
        public Customer()
        {
            customerAddress = null;
            creditStatus = null;
            blacklisted = false;
            customerName = null;
            customerId = null;
            customerPhoneNumber = null;
            customeremail = null;

        }

        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerAddrss { get; set; }
        public string getCreditstatus()
        {
            return creditStatus;
        }
        public void setCreditstatus(string str)
        {
            creditStatus = str;
        }
        public bool getBlacklist() { return blacklisted; }
        public void setBlackist(bool b)
        {
            blacklisted = b;
        }

        public string CustomerPhoneNumber { get => customerPhoneNumber; set => customerPhoneNumber = value; }
    }
}
