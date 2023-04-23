using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService
{
    //订单明细类
    public class OrderDetails
    {
        //ID
        public string Id { get; set; }
        //货物对象
        public Good Good { get; set; }
        //货物ID
        public string GoodsId { get; set; }
        //索引
        public int index { get; set; }
        //货物数量
        public int Quantity { get; set; }
        //货物名称
        public string goodsName { get => Good != null ? this.Good.goodName : ""; }
        //货物总价
        public double UnitPrice { get => Good != null ? this.Good.goodPrice : 0.0; }
        //订单ID
        public string OrderId;

        public OrderDetails() {
            Id = Guid.NewGuid().ToString();
        }

        //构造函数
        public OrderDetails(int index, Good good, int quantity)
        {
            this.index = index;
            this.Good = good;
            this.Quantity = quantity;
        }

        //明细总价
        public double TotalPrice
        {
            get => Good == null ? 0.0 : Good.goodPrice * Quantity;
        }

        public override bool Equals(object obj)
        {
            var detail = obj as OrderDetails;
            return detail != null &&
                   EqualityComparer<Good>.Default.Equals(Good, detail.Good);
        }


        public override string ToString()
        {
            return $"[No.:{index},goods:{goodsName},quantity:{Quantity},totalPrice:{TotalPrice}]";
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
