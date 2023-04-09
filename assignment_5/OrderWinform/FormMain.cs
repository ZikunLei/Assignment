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
    public partial class FormMain : Form
    {
        OrderService orderService = new OrderService();
        public String Keyword { get; set; }
        public FormMain()
        {
            
            InitializeComponent();
            InitOrders();
            searchWayComb.SelectedIndex = 0;
            orderBindingSource.DataSource = orderService.getAll();
            searchKeyText.DataBindings.Add("Text", this, "Keyword");
        }

        private void InitOrders()
        {
            Order.Order order = new Order.Order(1, new Customer("1", "李老板"), new List<OrderDetails>());
            order.addDetails(new OrderDetails(1, new Good("1", "苹果", 10.0), 10));
            order.addDetails(new OrderDetails(2, new Good("2", "梨子", 50.0), 61));
            orderService.addOrder(order);
            Order.Order order2 = new Order.Order(2, new Customer("2", "张三"), new List<OrderDetails>());
            order2.addDetails(new OrderDetails(1, new Good("2", "梨子", 24.0), 10));
            orderService.addOrder(order2);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void searchBnt_Click(object sender, EventArgs e)
        {
            try
            {
                switch (searchWayComb.SelectedIndex)
                {
                    case 0://所有订单
                        orderBindingSource.DataSource = orderService.getAll();
                        break;
                    case 1://根据ID查询
                        int id = Convert.ToInt32(Keyword);
                        Order.Order order = orderService.getById(id);
                        List<Order.Order> result = new List<Order.Order>();
                        if (order != null) result.Add(order);
                        orderBindingSource.DataSource = result;
                        break;
                    case 2://客户名查询
                        orderBindingSource.DataSource = orderService.getByCustomerName(Keyword);
                        break;
                    case 3://货物名查询
                        orderBindingSource.DataSource = orderService.getByGoodsName(Keyword);
                        break;
                    case 4://价格查询
                        float totalPrice = Convert.ToInt32(Keyword);
                        orderBindingSource.DataSource =
                               orderService.getByTotalPrice(totalPrice);
                        break;
                }
                orderBindingSource.ResetBindings(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void addOrderBnt_Click(object sender, EventArgs e)
        {
            FormEdit formEdit = new FormEdit(new Order.Order(), false, orderService);
            formEdit.Show();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            EditOrder();
        }

        private void EditOrder()
        {
            Order.Order order = orderBindingSource.Current as Order.Order;
            if (order == null)
            {
                MessageBox.Show("请选择一个订单进行修改");
                return;
            }
            FormEdit form2 = new FormEdit(order, true, orderService);
            form2.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Order.Order order = orderBindingSource.Current as Order.Order;
            if (order == null)
            {
                MessageBox.Show("请选择一个订单进行删除");
                return;
            }
            DialogResult result = MessageBox.Show($"确认要删除Id为{order.orderId}的订单吗？", "删除", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                orderService.removeOrder(order.orderId);
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
