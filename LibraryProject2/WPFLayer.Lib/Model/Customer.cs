using Prism.Commands;
using ServicesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPFLayer.Lib.ViewModel;

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

        public Customer(int _id, string _name, int _money)
        {
            CustomerId = _id;
            Name = _name;
            Money = _money;
        }

        public int CustomerId { get; set; }
        public string Name { get; set; }
        public int Money { get; set; }
      
    }
}
