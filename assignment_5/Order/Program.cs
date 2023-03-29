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
              
        //订单金额
        public int orderSum { get; set; }

        //客户
        public string customerName { get; set; }

        //保存每一个订单的明细项目
        public List<OrderDetails> orderItemList = new List<OrderDetails>();

        public Order()
        {
            this.orderId = 0;
            this.orderSum = 0;

        }

        public Order(int orderId, int orderSum,string customerName)
        {
            this.orderId = orderId;
            this.orderSum = orderSum;
            this.customerName = customerName;
        }

        //重写ToSring方法
        public override string ToString()
        {
            return "OrderId: " + orderId + " " + "OrderSum: " + orderSum + " " + "customerName: " + customerName;
        }

        //重写Equals方法，判断订单号是否相等，相等的订单号是重复订单
        public override bool Equals(object obj)
        {
            Order order = obj as Order;
            return order.orderId == orderId;
        }

    }

    //订单明细类
    public class OrderDetails
    {
        //商品名称
        public string goodName { get; set; }
        //商品数目
        public int goodNum { get; set; }
        
        //构造函数
        public OrderDetails(string goodName, int goodNum)
        {
            this.goodName = goodName;
            this.goodNum = goodNum;
        }
        //重写ToSring方法
        public override string ToString()
        {
            return "GoodName: " + goodName + " " + "GoodNum: " + goodNum;
        }
    }

    //订单服务类
    public class OrderService
    {
        List<Order> orderList=new List<Order>();

        //输出打印函数，打印订单及其明细
        void print(Order order)
        {
            Console.WriteLine(order);
            foreach (OrderDetails item in order.orderItemList)
            {
                Console.WriteLine(item);
            }
        }
        //1、添加订单
        public void addOrder()
        {
           try
           {
                //用户输入订单信息
                Console.WriteLine("请输入订单编号：");
                int orderId = Convert.ToInt32(Console.ReadLine());
                
                //判重               
                bool isSame = false;//判断订单号是否重复的bool类型变量
                foreach (Order item in orderList)
                {
                    if (item.orderId==orderId)
                    {
                        isSame = true;
                    }
                }
                if (isSame)
                {
                    Console.WriteLine("订单号重复！");
                }
                 
                else
                {
                    //订单号未重复，创建订单对象并加入订单列表
                    Console.WriteLine("请输入货物金额：");
                    int orderSum = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("请输入客户名称：");
                    string customerName = Console.ReadLine();
                    Order myorder = new Order(orderId, orderSum,customerName);
                    

                    //继续创建订单明细
                    Console.WriteLine("请输入订单明细数目：");//订单商品种类数目（用于orderItemList数组中明细条数的确定）
                    int itemNum = Convert.ToInt32(Console.ReadLine());
                    //进入每一个myOrder对象明细条目的循环
                    while (itemNum > 0)
                    {
                        Console.WriteLine("请输入货物名称：");
                        string goodName = Console.ReadLine();
                        Console.WriteLine("请输入货物数目：");
                        int goodNum = Convert.ToInt32(Console.ReadLine());
                       
                        //创建一个明细对象
                        OrderDetails item = new OrderDetails(goodName,goodNum);
                        //加入新创建的明细项
                        myorder.orderItemList.Add(item);
                        
                        itemNum--;
                    }
                    //加入列表（管理订单的列表）
                    orderList.Add(myorder);

                }

            }
           catch
           {
               Console.WriteLine("输入错误！");
           }


        }

        //2、查询订单（按照订单号或者顾客名或者总金额）
        //按订单号查找，订单唯一
        void searchById()
        {
            try
            {
                //是否找到标志
                bool flag = false;
                Console.WriteLine("请输入查询的订单号:");
                int id = Convert.ToInt32(Console.ReadLine());
                foreach (Order order in orderList)
                {
                    if (order.orderId == id)
                    {
                        Console.WriteLine("找到订单号为" + id + "的订单，明细如下：");
                        print(order);
                        flag = true;
                    }
                }
                if (!flag)
                {
                    Console.WriteLine("未找到该订单号！");
                }
            }
            catch
            {
                Console.WriteLine("输入错误！");
            }
            
        }
        //按客户名查找
        void searchByName()
        {
            try
            {
                //是否找到标志
                bool flag = false;
                Console.WriteLine("请输入顾客名查询订单:");
                string name = Console.ReadLine();
                foreach (Order order in orderList)
                {
                    if (order.customerName == name)
                    {
                        Console.WriteLine("找到客户名为" + name + "的订单，明细如下：");
                        print(order);
                        flag = true;
                    }
                }
                if (!flag)
                {
                    Console.WriteLine("未找到该客户订单记录！");
                }
            }
            catch
            {
                Console.WriteLine("输入错误！");
            }
        }
        //按总金额查找
        void searchBySum()
        {
            try
            {
                //是否找到标志
                bool flag = false;
                Console.WriteLine("请输入金额数查询订单:");
                int sum = Convert.ToInt32(Console.ReadLine());
                foreach (Order order in orderList)
                {
                    if (order.orderSum == sum)
                    {
                        Console.WriteLine("找到总金额为" + sum + "的订单，明细如下：");
                        print(order);
                        flag = true;
                    }
                }
                if (!flag)
                {
                    Console.WriteLine("未找到该金额的订单记录！");
                }
            }
            catch
            {
                Console.WriteLine("输入错误！");
            }
        }

        //3、删除订单（按照订单号删除）
        void deleteOrder()
        {
            try
            {
                bool flag = false;
                Console.WriteLine("请输入删除的订单所对应的订单号：");
                int id = Convert.ToInt32(Console.ReadLine());
                foreach (Order order in orderList)
                {
                    if (order.orderId == id)
                    {
                        Console.WriteLine("找到订单号为" + id + "的订单，进行删除");
                        //删除
                        orderList.Remove(order);
                        flag = true;
                    }
                }
                if (!flag)
                {
                    Console.WriteLine("未找到该订单记录！");
                }
            }
            catch
            {
                Console.WriteLine("输入错误！");
            }
            
        }

        //4、排序方法
        public void sortOrderList()
        {
            orderList.Sort();
        }
        class Program
        {
            static void Main(string[] args)
            {
                OrderService myorder = new OrderService();
                myorder.addOrder();
                //myorder.addOrder();
                //myorder.searchByName();
            }
        }
    }
}
