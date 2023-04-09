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

namespace OrderWinform
{
    
    public partial class FormDetailEdit : Form
    {
        
        public OrderDetails Detail { get; set; }
        public FormDetailEdit()
        {
            InitializeComponent();
        }
        public FormDetailEdit(OrderDetails detail) : this()
        {
            this.Detail = detail;
            this.bindingSource2.DataSource = detail;
            bindingSource1.Add(new Good("1", "苹果", 10.0));
            bindingSource1.Add(new Good("2", "梨子", 24.0));
        }

        private void FormDetailEdit_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormDetailEdit_Load_1(object sender, EventArgs e)
        {

        }
    }
}
