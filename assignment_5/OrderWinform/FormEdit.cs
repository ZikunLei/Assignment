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
    public partial class FormEdit : Form
    {
        private OrderService orderService;
        public bool EditModel { get; set; }
        public Order.Order CurrentOrder { get; set; }
        public FormEdit(Order.Order order, bool model, OrderService orderService)
        {
            InitializeComponent();
            customerBindingSource.Add(new Customer("1", "李老板"));
            customerBindingSource.Add(new Customer("2", "张三"));
            this.orderService = orderService;
            this.EditModel = model;

            //深克隆
            this.CurrentOrder = order;
            orderBindingSource.DataSource = CurrentOrder;
            orderIdText.Enabled = !model;
        }

        private void FormEdit_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void addDetalisBnt_Click(object sender, EventArgs e)
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
                    detailsBindingSource.ResetBindings(false);
                }
            }
            catch (Exception e2)
            {
                MessageBox.Show(e2.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           
            try
            {
                if (this.EditModel)
                {
                    orderService.update(CurrentOrder);
                }
                else
                {
                    orderService.addOrder(CurrentOrder);
                }
                this.Close();
            }
            catch (Exception e3)
            {
                MessageBox.Show(e3.Message);
            }

        }

        private void btnEditItem_Click(object sender, EventArgs e)
        {
            EditDetail();
        }

        private void EditDetail()
        {
            OrderDetails detail = detailsBindingSource.Current as OrderDetails;
            if (detail == null)
            {
                MessageBox.Show("请选择一个订单项进行修改");
                return;
            }
            FormDetailEdit formDetailEdit = new FormDetailEdit(detail);
            if (formDetailEdit.ShowDialog() == DialogResult.OK)
            {
                detailsBindingSource.ResetBindings(false);
            }
        }

        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            OrderDetails detail = detailsBindingSource.Current as OrderDetails;
            if (detail == null)
            {
                MessageBox.Show("请选择一个订单项进行删除");
                return;
            }
            CurrentOrder.RemoveDetail(detail);
            detailsBindingSource.ResetBindings(false);
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (this.EditModel)
                {
                    orderService.update(CurrentOrder);
                }
                else
                {
                    orderService.addOrder(CurrentOrder);
                }
                this.Close();
            }
            catch (Exception e3)
            {
                MessageBox.Show(e3.Message);
            }
        }
    }
}
