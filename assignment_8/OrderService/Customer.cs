using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService
{
    //顾客类
    public class Customer
    {
        //顾客ID
        public string Id { get; set; }
        //顾客名
        public string customerName { get; set; }

        public Customer() {
            Id = Guid.NewGuid().ToString();
        }

        public Customer(string name):this()
        {
            this.customerName = name;
        }

        public override string ToString()
        {
            return $"{customerName}";
        }

        public override bool Equals(object obj)
        {
            var customer = obj as Customer;
            return customer != null && Id == customer.Id;
        }

        public override int GetHashCode()
        {
            var hashCode = 262543150;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(customerName);
            return hashCode;
        }
    }
}
