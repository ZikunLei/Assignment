using System;
using Order;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderWindowsFormsApp
{
    public partial class createOrder_Form2 : Form
    {
        public createOrder_Form2()
        {
            InitializeComponent();
        }

        private void createOrder1_Click(object sender, EventArgs e)
        {
            createDetails_Form6 f6 = new createDetails_Form6();
            f6.Show();
            Order.Order order = new Order.Order();
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void createOrder_Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
