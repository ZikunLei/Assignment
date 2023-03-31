using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order
{
    //顾客类
    public class Customer
    {
        public int customerId { get; set; }

        public string customerName { get; set; }

        public Customer() { }

        public Customer(int id, string name)
        {
            this.customerId = id;
            this.customerName = name;
        }

        public override string ToString()
        {
            return $"CustomerId:{customerId}, CustomerName:{customerName}";
        }

        public override bool Equals(object obj)
        {
            var customer = obj as Customer;
            return customer != null && customerId == customer.customerId;
        }

        public override int GetHashCode()
        {
            var hashCode = 262543150;
            hashCode = hashCode * -1521134295 + customerId.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(customerName);
            return hashCode;
        }
    }

    
}
