using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoodFoodSystem.PresentationLayer
{
    public partial class MessageForm : Form
    {
        OrderForm1 orderForm;
        CustomerForm customerForm;

       private bool close;
        public MessageForm()

        {
            close = false;
            InitializeComponent();
        }

        public bool Close1 { get => close; set => close = value; }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void yesbtn_Click(object sender, EventArgs e)
        {

            
            
            orderForm=new OrderForm1();

            
            orderForm.Show();
            Close1=true;
            
            this.Close();
            
        }
    }
}
