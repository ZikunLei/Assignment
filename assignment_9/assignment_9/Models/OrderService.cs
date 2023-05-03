using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace OrderService
{
    //订单服务类
    public class OrderService
    {
        //List<Order> orderList = new List<Order>();

        ////输出打印函数，打印订单及其明细
        //void print(Order order)
        //{
        //    Console.WriteLine(order);
        //    foreach (OrderDetails item in order.orderItemList)
        //    {
        //        Console.WriteLine(item);
        //    }
        //}

        //构造函数
        public OrderService()
        {
            using (var ctx = new OrderContext())
            {
                if (ctx.Goods.Count() == 0)
                {
                    ctx.Goods.Add(new Good("apple", 100.0));
                    ctx.Goods.Add(new Good("egg", 200.0));
                    ctx.SaveChanges();
                }
                if (ctx.Customers.Count() == 0)
                {
                    ctx.Customers.Add(new Customer("li"));
                    ctx.Customers.Add(new Customer("zhang"));
                    ctx.SaveChanges();
                }
            }
        }
        //初始化订单类
        public List<Order> Orders
        {
            get
            {
                using (var ctx = new OrderContext())
                {
                    return ctx.Orders
                      .Include(o => o.Details.Select(d => d.Good))
                      .Include(o => o.Customer)
                      .ToList<Order>();
                }
            }
        }

        //添加订单
        public void AddOrder(Order order)
        {
            FixOrder(order);
            using (var ctx = new OrderContext())
            {
                ctx.Entry(order).State = EntityState.Added;
                ctx.SaveChanges();
            }
        }

        //更新订单
        public void UpdateOrder(Order order)
        {
            RemoveOrder(order.orderId);
            AddOrder(order);
        }

        //根据ID查询订单
        public Order GetOrderByOrderId(string id)
        {
            using (var ctx = new OrderContext())
            {
                return ctx.Orders
                  .Include(o => o.Details.Select(d => d.Good))
                  .Include(o => o.Customer)
                  .SingleOrDefault(o => o.orderId == id);
            }
        }
        
        //根据货物名查询订单
        public List<Order> GetOrdersByGoodName(string goodName)
        {
            using (var ctx = new OrderContext())
            {
                return ctx.Orders
                  .Include(o => o.Details.Select(d => d.Good))
                  .Include(o => o.Customer)
                  .Where(order => order.Details.Any(item => item.Good.goodName == goodName))
                  .ToList();
            }
        }

        //根据顾客名查询订单
        public List<Order> GetOrdersByCustomerName(string customerName)
        {
            using (var ctx = new OrderContext())
            {
                return ctx.Orders
                  .Include(o => o.Details.Select(d => d.Good))
                  .Include(o => o.Customer)
                  .Where(order => order.Customer.customerName== customerName)
                  .ToList();
            }
        }

        //根据总价查询订单
        public object GetByTotalAmount(float amount)
        {
            using (var ctx = new OrderContext())
            {
                return ctx.Orders
                  .Include(o => o.Details.Select(d => d.Good))
                  .Include("Customer")
                .Where(order => order.Details.Sum(d => d.Quantity * d.Good.goodPrice) > amount)
                .ToList();
            }
        }

        //删除订单
        public void RemoveOrder(string orderId)
        {
            using (var ctx = new OrderContext())
            {
                var order = ctx.Orders.Include("Details")
                  .SingleOrDefault(o => o.orderId == orderId);
                if (order == null) return;
                ctx.OrderDetails.RemoveRange(order.Details);
                ctx.Orders.Remove(order);
                ctx.SaveChanges();
            }
        }

        //避免级联添加或修改Customer和Goods
        private static void FixOrder(Order order)
        {
            order.CustomerId = order.Customer.Id;
            order.Customer = null;
            order.Details.ForEach(d => {
                d.GoodsId = d.Good.Id;
                d.Good= null;
            }
            );
        }
        

    }
}
