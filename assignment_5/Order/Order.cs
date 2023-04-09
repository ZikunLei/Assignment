using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order
{
    //订单类
    public class Order
    {
        //订单号
        public int orderId { get; set; }

        //客户
        public Customer Customer { get; set; }

        //创建时间
        public DateTime DateTime { get; set; }

        //保存每一个订单的明细项目
        private List<OrderDetails> orderItemList;

        //总价
        public double TotalPrice
        {
            get => orderItemList.Sum(d => d.TotalPrice);
        }

        public Order()
        {
            DateTime = DateTime.Now;
            orderItemList = new List<OrderDetails>();
        }

        //构造函数
        public Order(int orderId, Customer Customer, List<OrderDetails> items)
        {
            this.orderId = orderId;
            this.Customer = Customer;
            this.DateTime = DateTime.Now;
            this.orderItemList = (items == null) ? new List<OrderDetails>() : items;
        }

        public List<OrderDetails> Details
        {
            get { return orderItemList; }
        }

        //添加明细
        public void addDetails(OrderDetails orderDetail)
        {
            if (orderItemList.Contains(orderDetail))
            {
                throw new ApplicationException($"The goods ({orderDetail.Good.goodName}) exist in order {orderId}");
            }
            orderItemList.Add(orderDetail);
        }

        //删除明细
        public void deleteDetails(int num)
        {
            orderItemList.RemoveAt(num);
        }

        //删除项
        public void RemoveDetail(OrderDetails orderItem)
        {
            Details.Remove(orderItem);
        }

        //重写ToSring方法
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append($"orderId:{orderId}, customer:({Customer})");
            orderItemList.ForEach(detail => result.Append("\n\t" + detail));
            return result.ToString();
        }

        //重写Equals方法，判断订单号是否相等，相等的订单号是重复订单
        public override bool Equals(object obj)
        {
            Order order = obj as Order;
            return order.orderId == orderId;
        }

        public override int GetHashCode()
        {
            var hashCode = -1931143691;
            hashCode = hashCode * -1521134295 + orderId.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Customer>.Default.GetHashCode(Customer);
            hashCode = hashCode * -1521134295 + DateTime.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<List<OrderDetails>>.Default.GetHashCode(orderItemList);
            hashCode = hashCode * -1521134295 + TotalPrice.GetHashCode();
            return hashCode;
        }
    }
}
