using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order
{
    //订单服务类
    public class OrderService
    {
        List<Order> orderList = new List<Order>();

        ////输出打印函数，打印订单及其明细
        //void print(Order order)
        //{
        //    Console.WriteLine(order);
        //    foreach (OrderDetails item in order.orderItemList)
        //    {
        //        Console.WriteLine(item);
        //    }
        //}

        //添加订单
        public void addOrder(Order order)
        {
            if (orderList.Contains(order))
            {
                throw new ApplicationException($"已存在订单号为 {order.orderId} 的订单!");
            }
            orderList.Add(order);
        }

        //更新订单
        public void update(Order order)
        {
            int idx = orderList.FindIndex(o => o.orderId == order.orderId);
            if (idx < 0)
            {
                throw new ApplicationException($"订单号为 {order.orderId} 的订单不存在！");
            }
            orderList.RemoveAt(idx);
            orderList.Add(order);
        }

        //根据Id查询订单
        public Order getById(int orderId)
        {
            return orderList.FirstOrDefault(o => o.orderId == orderId);
        }

        //根据Id删除订单
        public void removeOrder(int orderId)
        {
            int idx = orderList.FindIndex(o => o.orderId == orderId);
            if (idx >= 0)
            {
                orderList.RemoveAt(idx);
            }
        }

        //查询所有订单
        public List<Order> getAll()
        {
            return orderList;
        }

        //根据客户名查询
        public List<Order> getByCustomerName(string customerName)
        {
            var query = orderList
                .Where(o => o.Customer.customerName == customerName)
                .OrderBy(o => o.TotalPrice);
            return query.ToList();
        }

        //根据货物名查询
        public List<Order> getByGoodsName(string goodsName)
        {
            var query = orderList.Where(
              o => o.orderItemList.Any(d => d.Good.goodName == goodsName))
                .OrderBy(o => o.TotalPrice);
            return query.ToList();
        }

        //根据总价查询
        public List<Order> getByTotalPrice(float totalPrice)
        {
            var query = orderList.Where(o => o.TotalPrice >= totalPrice)
                .OrderBy(o => o.TotalPrice);
            return query.ToList();
        }


        //对orders中的数据进行排序
        public void Sort(Comparison<Order> comparison)
        {
            orderList.Sort(comparison);
        }

        //根据传入的条件进行查询
        public IEnumerable<Order> Query(Predicate<Order> condition)
        {
            return orderList.Where(o => condition(o)).OrderBy(o => o.TotalPrice);
        }
        
    }
}
