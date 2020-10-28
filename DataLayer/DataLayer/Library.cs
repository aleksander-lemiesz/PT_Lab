using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    class Library
    {
        private List<Book> stock { get; set; }
        private List<Book> catalog { get; set; }
        private List<Event> events { get; set; }
        private List<Customer> customers { get; set; }

        public Library()
        {
            stock = new List<Book>();
            catalog = new List<Book>();
            events = new List<Event>();
            customers = new List<Customer>();
        }
    }
}
