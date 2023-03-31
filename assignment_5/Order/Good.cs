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
        public int goodId { get; set; }

        public string goodName { get; set; }

        private float goodPrice;

        public float Price
        {
            get { return goodPrice; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("the price must >= 0!");
                goodPrice = value;
            }
        }

        public Good() { }

        public Good(int id, string name, float price)
        {
            this.goodId = id;
            this.goodName = name;
            this.Price = price;
        }

        public override bool Equals(object obj)
        {
            var goods = obj as Good;
            return goods != null && goodId == goods.goodId;
        }

        public override string ToString()
        {
            return $"Id:{goodId}, Name:{goodName}, Value:{Price}";
        }

        public override int GetHashCode()
        {
            var hashCode = -13429889;
            hashCode = hashCode * -1521134295 + goodId.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(goodName);
            hashCode = hashCode * -1521134295 + goodPrice.GetHashCode();
            hashCode = hashCode * -1521134295 + Price.GetHashCode();
            return hashCode;
        }
    }
}
