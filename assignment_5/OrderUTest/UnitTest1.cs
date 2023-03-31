using Microsoft.VisualStudio.TestTools.UnitTesting;
using Order;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
namespace Order.Tests
{

    [TestClass]
    public class OrderServiceTests
    {

        OrderService orderService = new OrderService();

        Good apple = new Good(1, "apple", 10.0f);
        Good egg = new Good(2, "egg", 1.2f);
        Good milk = new Good(3, "milk", 50f);
        Customer customer1 = new Customer(1, "Customer1");
        Customer customer2 = new Customer(2, "Customer2");

        [TestInitialize]
        public void Init()
        {

            Order order1 = new Order(1, customer1, new DateTime(2021, 3, 21));
            order1.addDetails(new OrderDetails(apple, 80));
            order1.addDetails(new OrderDetails(egg, 200));
            order1.addDetails(new OrderDetails(milk, 10));

            Order order2 = new Order(2, customer2, new DateTime(2021, 3, 21));
            order2.addDetails(new OrderDetails(egg, 200));
            order2.addDetails(new OrderDetails(milk, 10));

            Order order3 = new Order(3, customer2, new DateTime(2021, 3, 21));
            order3.addDetails(new OrderDetails(apple, 80));
            order3.addDetails(new OrderDetails(milk, 10));

            orderService = new OrderService();
            orderService.addOrder(order1);
            orderService.addOrder(order2);
            orderService.addOrder(order3);
        }

        [TestMethod]
        public void AddOrderTest()
        {
            Order order4 = new Order(4, customer2, new DateTime(2021, 3, 21));
            order4.addDetails(new OrderDetails(milk, 10));
            orderService.addOrder(order4);
            List<Order> orders = orderService.getAll();
            Assert.IsNotNull(orders);
            Assert.AreEqual(4, orders.Count);
            CollectionAssert.Contains(orders, order4);
        }


        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void AddOrderTest2()
        {
            Order order3 = new Order(3, customer2, new DateTime(2021, 3, 21));
            orderService.addOrder(order3);
        }


        [TestMethod]
        public void RemoveOrderTest()
        {
            orderService.removeOrder(3);
            List<Order> orders = orderService.getAll();
            Assert.AreEqual(2, orders.Count);
            orderService.removeOrder(100);
            Assert.AreEqual(2, orderService.getAll().Count);
        }

        [TestMethod]
        public void UpdateOrderTest()
        {
            Order order3 = new Order(3, customer1, new DateTime(2021, 3, 21));
            order3.addDetails(new OrderDetails(milk, 200));
            orderService.update(order3);

            List<Order> orders = orderService.getAll();
            Assert.IsNotNull(orders);
            Assert.AreEqual(3, orders.Count);
            Order o = orderService.getById(3);
            Assert.AreEqual(customer1, o.Customer);
        }


        [TestMethod]
        public void QueryOrderByIdTest()
        {
            Order order2 = orderService.getById(2);
            Assert.IsNotNull(order2);
            Assert.AreEqual(2, order2.orderId);
            Assert.AreEqual(customer2, order2.Customer);
            List<OrderDetails> details = new List<OrderDetails>()
        { new OrderDetails(egg, 200), new OrderDetails(milk, 10) };
            CollectionAssert.AreEqual(details, order2.orderItemList);

            Order order4 = orderService.getById(4);
            Assert.IsNull(order4);
        }


        [TestMethod]
        public void QueryOrdersByGoodsNameTest()
        {
            Assert.AreEqual(2, orderService.getByGoodsName("apple").Count);
            Assert.AreEqual(2, orderService.getByGoodsName("egg").Count);
            Assert.AreEqual(3, orderService.getByGoodsName("milk").Count);
            Assert.AreEqual(0, orderService.getByGoodsName("orange").Count);
        }

        [TestMethod]
        public void QueryOrdersByCustomerNameTest()
        {
            Assert.AreEqual(1, orderService.getByCustomerName("Customer1").Count);
            Assert.AreEqual(2, orderService.getByCustomerName("Customer2").Count);
            Assert.AreEqual(0, orderService.getByCustomerName("Customer3").Count);
        }

    }
}
