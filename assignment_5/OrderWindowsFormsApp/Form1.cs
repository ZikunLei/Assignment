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
    public partial class Form1 : Form
    {
        OrderService orderService = new OrderService();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void change_Click(object sender, EventArgs e)
        {
            change_Form4 f4 = new change_Form4();
            f4.Show();
        }

        private void createOrder_Click(object sender, EventArgs e)
        {
            createOrder_Form2 f2 = new createOrder_Form2();
            f2.Show();
        }

        private void search_Click(object sender, EventArgs e)
        {
            search_Form3 f3 = new search_Form3();
            f3.Show();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            delete_Form5 f5 = new delete_Form5();
            f5.Show();
        }
    }
}
