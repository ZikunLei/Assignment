using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService
{
    //货物类
    public class Good
    {
        //货物ID
        public string Id { get; set; }
        //货物名称
        public string goodName { get; set; }
        //货物价格
        public double goodPrice { get; set; }


        public Good() {
            Id = Guid.NewGuid().ToString();
        }

        public Good(string name, double price)
        {
            goodName = name;
            goodPrice = price;
        }

        public override bool Equals(object obj)
        {
            var goods = obj as Good;
            return goods != null && Id == goods.Id;
        }

        public override int GetHashCode()
        {
            var hashCode = -13429889;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(goodName);
            hashCode = hashCode * -1521134295 + goodPrice.GetHashCode();
            return hashCode;
        }
    }
}
