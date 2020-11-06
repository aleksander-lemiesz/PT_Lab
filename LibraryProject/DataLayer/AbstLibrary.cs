using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public abstract class AbstLibrary
    {
        private List<AbstBook> stock;
        public List<AbstBook> Stock
        {
            get { return stock; }
            set { stock = value; }
        }

        private List<AbstBook> catalog;
        public List<AbstBook> Catalog
        {
            get { return catalog; }
            set { catalog = value; }
        }

        private List<AbstEvent> events;
        public List<AbstEvent> Events
        {
            get { return events; }
            set { events = value; }
        }

        private List<AbstCustomer> customers;
        public List<AbstCustomer> Customers
        {
            get { return customers; }
            set { customers = value; }
        }


        public AbstLibrary()
        {
            stock = new List<AbstBook>();
            catalog = new List<AbstBook>();
            events = new List<AbstEvent>();
            customers = new List<AbstCustomer>();
        }

        public abstract void addEvent(String s);
        
    }
}
