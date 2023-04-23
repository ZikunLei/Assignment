using OrderService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace OrderForm
{
    public partial class FormDetailEdit : Form
    {
        public OrderDetails Detail { get; set; }
        //初始化
        public FormDetailEdit()
        {
            InitializeComponent();
        }

        public FormDetailEdit(OrderDetails detail) : this()
        {
            this.Detail = detail;
            this.bdsDetail.DataSource = detail;
            using (OrderContext ctx = new OrderContext())
            {
                bdsGoods.DataSource = ctx.Goods.ToList();
            }
        }

        private void FormDetailEdit_Load(object sender, EventArgs e)
        {

        }
    }
}
