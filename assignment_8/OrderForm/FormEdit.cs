using OrderService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderForm
{
    public partial class FormEdit : Form
    {
        private OrderService.OrderService orderService;
        public bool EditModel { get; set; }

        public Order CurrentOrder { get; set; }
        public event Action<FormEdit> CloseEditFrom;
        public FormEdit()
        {
            InitializeComponent();
        }

        //初始化
        public FormEdit(Order order, bool model, OrderService.OrderService orderService)
        {
            InitializeComponent();
            using (OrderContext ctx = new OrderContext())
            {
                bdsCustomers.DataSource = ctx.Customers.ToList();
            }
            this.orderService = orderService;
            this.EditModel = model;

            this.CurrentOrder = order;
            bdsOrders.DataSource = CurrentOrder;

            TextO.Enabled = !model;
            if (!model)
            {
                CurrentOrder.Customer = (Customer)bdsCustomers.Current;
            }
        }

        //删除按钮
        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            OrderDetails detail = bdsDetails.Current as OrderDetails;
            if (detail == null)
            {
                MessageBox.Show("进行删除:");
                return;
            }
            CurrentOrder.RemoveDetail(detail);
            bdsDetails.ResetBindings(false);
        }

        //添加按钮
        private void AddItem_Click(object sender, EventArgs e)
        {
            FormDetailEdit formItemEdit = new FormDetailEdit(new OrderDetails());
            try
            {
                if (formItemEdit.ShowDialog() == DialogResult.OK)
                {
                    int index = 0;
                    if (CurrentOrder.Details.Count != 0)
                    {
                        index = CurrentOrder.Details.Max(i => i.index) + 1;
                    }
                    formItemEdit.Detail.index = index;
                    CurrentOrder.addDetails(formItemEdit.Detail);
                    bdsDetails.ResetBindings(false);
                }
            }
            catch (Exception e2)
            {
                MessageBox.Show(e2.Message);
            }
        }

        //保存按钮
        private void Save_Click(object sender, EventArgs e)
        {
            //TODO 加上订单合法性验证
            try
            {
                if (this.EditModel)
                {
                    orderService.UpdateOrder(CurrentOrder);
                }
                else
                {
                    orderService.AddOrder(CurrentOrder);
                }
                CloseEditFrom(this);
            }
            catch (Exception e3)
            {
                MessageBox.Show(e3.InnerException.Message);
            }

        }

        //编辑明细
        private void EditItem_Click(object sender, EventArgs e)
        {
            EditDetail();
        }

        //编辑明细
        private void EditDetail()
        {
            OrderDetails detail = bdsDetails.Current as OrderDetails;
            if (detail == null)
            {
                MessageBox.Show("请选择一个订单项进行修改");
                return;
            }
            FormDetailEdit formDetailEdit = new FormDetailEdit(detail);
            if (formDetailEdit.ShowDialog() == DialogResult.OK)
            {
                bdsDetails.ResetBindings(false);
            }
        }

        

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
