using CrmBl.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrmUi
{
    public partial class CustomerForm : Form
    {
        public Customer Customer { get; set; }

        public CustomerForm()
        {
            InitializeComponent();
        }

        public CustomerForm(Customer customer) : this()
        {
            Customer = customer;
            textBox1.Text = customer.Name;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Customer != null)
            {
                Customer.Name = textBox1.Text;
            }
            else
            {
                Customer = new Customer()
                {
                    Name = textBox1.Text
                };
            }
            Close();
        }
    }
}
