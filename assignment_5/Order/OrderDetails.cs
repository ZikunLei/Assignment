using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order
{
    //订单明细类
    public class OrderDetails
    {
        //货物对象
        public Good Good;

        //货物数量
        public int Quantity { get; set; }

        //明细总价
        public float TotalPrice
        {
            get => Good.Price * Quantity;
        }

        public OrderDetails() { }

        //构造函数
        public OrderDetails(Good good, int quantity)
        {
            this.Good = good;
            this.Quantity = quantity;
        }

        public override bool Equals(object obj)
        {
            var detail = obj as OrderDetails;
            return detail != null &&
                   EqualityComparer<Good>.Default.Equals(Good, detail.Good);
        }


        public override string ToString()
        {
            return $"OrderDetail:{Good},{Quantity}";
        }

        public override int GetHashCode()
        {
            var hashCode = -166633262;
            hashCode = hashCode * -1521134295 + EqualityComparer<Good>.Default.GetHashCode(Good);
            hashCode = hashCode * -1521134295 + Quantity.GetHashCode();
            hashCode = hashCode * -1521134295 + TotalPrice.GetHashCode();
            return hashCode;
        }
    }
}
