using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public class Event
    {
        private String name;
        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        private Invoice invoice;
        public Invoice GetInvoice
        {
            get { return invoice; }
            set { invoice = value; }
        }

        public Event(String n)
        {
            name = n;
        }
    }
}
