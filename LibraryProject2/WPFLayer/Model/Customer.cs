using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServicesLayer;

namespace WPFLayer.Model
{
    public class Customer
    {
        public Customer(int _id)
        {
            CustomerId = _id;
            Name = CustomerCRUD.getName(_id);
            Money = CustomerCRUD.getMoney(_id);
        }

        public int CustomerId { get; set; }
        public string Name { get; set; }
        public int Money { get; set; }
    }
}
