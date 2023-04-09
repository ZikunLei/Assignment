using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order
{
    //货物类
    public class Good
    {
        public string goodId { get; set; }

        public string goodName { get; set; }

        public double goodPrice { get; set; }


        public Good() { }

        public Good(string id, string name, double price)
        {
            goodId = id;
            goodName = name;
            goodPrice = price;
        }

        public override bool Equals(object obj)
        {
            var goods = obj as Good;
            return goods != null && goodId == goods.goodId;
        }

        public override int GetHashCode()
        {
            var hashCode = -13429889;
            hashCode = hashCode * -1521134295 + goodId.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(goodName);
            hashCode = hashCode * -1521134295 + goodPrice.GetHashCode();
            return hashCode;
        }
    }
}
