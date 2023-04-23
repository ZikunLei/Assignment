using System;
using OrderService;
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
    public partial class MainForm : Form
    {
        OrderService.OrderService orderService;
        BindingSource bdsFields = new BindingSource();
        public event Action<FormEdit> ShowEditForm;
        public String Keyword { get; set; }

        //初始化
        public MainForm()
        {
            InitializeComponent();
            orderService = new OrderService.OrderService();
            bdsOrders.DataSource = orderService.Orders;
            CombName.SelectedIndex = 0;
            TextKey.DataBindings.Add("Text", this, "Keyword");
        }

        //添加按钮
        private void Add_Click(object sender, EventArgs e)
        {
            FormEdit formEdit = new FormEdit(new Order(), false, orderService);
            ShowEditForm(formEdit);
        }

        //查询所有
        public void QueryAll()
        {
            bdsOrders.DataSource = orderService.Orders;
            bdsOrders.ResetBindings(false);
        }

        //修改按钮
        private void Modify_Click(object sender, EventArgs e)
        {
            EditOrder();
        }


        //编辑按钮
        private void EditOrder()
        {
            Order order = bdsOrders.Current as Order;
            if (order == null)
            {
                MessageBox.Show("请选择一个订单进行修改");
                return;
            }
            FormEdit form2 = new FormEdit(order, true, orderService);
            ShowEditForm(form2);
        }

        //删除按钮
        private void Delete_Click(object sender, EventArgs e)
        {
            Order order = bdsOrders.Current as Order;
            if (order == null)
            {
                MessageBox.Show("请选择一个订单进行删除");
                return;
            }
            orderService.RemoveOrder(order.orderId);
            QueryAll();
        }

       
        //查询按钮
        private void Query_Click(object sender, EventArgs e)
        {
            switch (CombName.SelectedIndex)
            {
                case 0://所有订单
                    bdsOrders.DataSource = orderService.Orders;
                    break;
                case 1://根据ID查询
                    Order order = orderService.GetOrderByOrderId(Keyword);
                    List<Order> result = new List<Order>();
                    if (order != null) result.Add(order);
                    bdsOrders.DataSource = result;
                    break;
                case 2://根据客户查询
                    bdsOrders.DataSource = orderService.GetOrdersByCustomerName(Keyword);
                    break;
                case 3://根据货物查询
                    bdsOrders.DataSource = orderService.GetOrdersByGoodName(Keyword);
                    break;
                case 4://根据总价格查询（大于某个总价）
                    float.TryParse(Keyword, out float totalPrice);
                    bdsOrders.DataSource =
                           orderService.GetByTotalAmount(totalPrice);
                    break;
            }
            bdsOrders.ResetBindings(false);

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
