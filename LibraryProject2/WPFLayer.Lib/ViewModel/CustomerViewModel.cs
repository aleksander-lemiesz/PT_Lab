using ServicesLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
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
        public Customer c
        {
            get { return customer; }
            set
            {
                if (customer != value)
                {
                    customer = value;
                    OnPropertyChange("c");
                }
            }
        }
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
                
                    if (Customers != value)
                    {
                        Customers = value;
                       OnPropertyChange("Customers");
                        Customers.CollectionChanged += this.OnCollectionChanged;
                    }
                

            }
        }
        
        

        void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            //Get the sender observable collection
            ObservableCollection<string> obsSender = sender as ObservableCollection<string>;

            List<string> editedOrRemovedItems = new List<string>();
            foreach (string newItem in e.NewItems)
            {
                editedOrRemovedItems.Add(newItem);
            }

            foreach (string oldItem in e.OldItems)
            {
                editedOrRemovedItems.Add(oldItem);
            }

            //Get the action which raised the collection changed event
            NotifyCollectionChangedAction action = e.Action;
        }
    }
    
}