using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoppelOrderProcessing.BusinessLayer
{
    internal class Admin:Employee
    {
        private string role;
        public Admin() : base()
        {

        }

        public string Role { get => role; set => role = value; }
    }
}
