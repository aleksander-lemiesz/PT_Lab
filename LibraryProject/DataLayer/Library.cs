using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public class Library
    {
        private List<Book> stock;
        public List<Book> Stock
        {
            get { return stock; }
            set { stock = value; }
        }

        private List<Book> catalog;
        public List<Book> Catalog
        {
            get { return catalog; }
            set { catalog = value; }
        }

        private List<Event> events;
        public List<Event> Events
        {
            get { return events; }
            set { events = value; }
        }

        private List<Customer> customers;
        public List<Customer> Customers
        {
            get { return customers; }
            set { customers = value; }
        }


        public Library()
        {
            stock = new List<Book>();
            catalog = new List<Book>();
            events = new List<Event>();
            customers = new List<Customer>();
        }
    }
}
