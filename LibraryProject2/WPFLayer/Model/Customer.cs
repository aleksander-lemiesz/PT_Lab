using Prism.Commands;
using ServicesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPFLayer.View;

namespace WPFLayer.Model
{
    public class Customer
    {
        public Customer(int _id)
        {
            CustomerViewCommand = new DelegateCommand(CustomerView);
            CustomerDeleteCommand = new DelegateCommand(CustomerDelete);
            CustomerEditCommand = new DelegateCommand(CustomerEdit);

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

        public ICommand CustomerViewCommand
        {
            get;
            private set;
        }

        private void CustomerView()
        {
            CustomerDetailsWindow customerDetailsWindow = new CustomerDetailsWindow(this.CustomerId);
            customerDetailsWindow.Show();
        }

        public ICommand CustomerDeleteCommand
        {
            get;
            private set;
        }

        private void CustomerDelete()
        {
            CustomerCRUD.removeCustomer(this.CustomerId);
            if(CustomerCRUD.getName(this.CustomerId) == null)
            {
                MessageBox.Show("Customer " + Name + " deleted.");
            } else if(CustomerCRUD.getMoney(this.CustomerId) < 0)
            {
                MessageBox.Show("Cannot delete customer " + Name + ". He or she has a debt: " + Money + ".");
            } else
            {
                MessageBox.Show("Cannot delete customer " + Name + ". He or she has borrowed a book.");
            }
            
        }

        public ICommand CustomerEditCommand
        {
            get;
            private set;
        }

        private void CustomerEdit()
        {
            CustomerEditWindow customerEditWindow = new CustomerEditWindow(this.CustomerId);
            customerEditWindow.Show();
        }
    }
}
