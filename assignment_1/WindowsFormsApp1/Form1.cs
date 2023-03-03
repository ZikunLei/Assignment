using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        //结果
        int res = 0;

        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //button1 : +
        //button2 : -
        //button3 : *
        //button4 : /
        //button5 : calculate
        private void button1_Click(object sender, EventArgs e)
        {
            res = Int32.Parse(textBox1.Text) + Int32.Parse(textBox2.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            res = Int32.Parse(textBox1.Text) - Int32.Parse(textBox2.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            res = Int32.Parse(textBox1.Text) * Int32.Parse(textBox2.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            res = Int32.Parse(textBox1.Text) / Int32.Parse(textBox2.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox3.Text = res.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
