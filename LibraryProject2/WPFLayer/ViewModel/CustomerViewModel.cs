using ServicesLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFLayer.Model;

namespace WPFLayer.ViewModel
{
    public partial class ListsViewModel : INotifyPropertyChanged
    {
        private Customer customer;
        private ObservableCollection<Customer> customers;
        public int CustomerId
        {
            get { return customer.CustomerId; }
            set
            {
                if (customer.CustomerId != value)
                {
                    customer.CustomerId = value;
                    OnPropertyChange("CustomerId");
                }
            }
        }
        public string Name
        {
            get { return customer.Name; }
            set
            {
                if (customer.Name != value)
                {
                    customer.Name = value;
                    CustomerCRUD.updateName(customer.CustomerId, value);
                    OnPropertyChange("Name");
                }
            }
        }
        public int Money
        {
            get { return customer.Money; }
            set
            {
                if (customer.Money != value)
                {
                    customer.Money = value;
                    CustomerCRUD.updateMoney(customer.CustomerId, value);
                    OnPropertyChange("Money");
                }
            }
        }

        public ObservableCollection<Customer> Customers
        {
            get { return GetCustomers(); }
            set
            {
                for(int i = 0; i < Customers.Count; i++)
                {
                    if (Customers[i] != value[i])
                    {
                        Customers[i] = value[i];
                        CustomerCRUD.removeCustomer(Customers[i].CustomerId);
                        OnPropertyChange("Customers");
                    }
                }
               
            }
        }
    }
}