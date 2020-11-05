using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public abstract class AbstEvent : IEquatable<AbstEvent>
    {
        private String name;
        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        private AbstInvoice invoice;
        public AbstInvoice GetInvoice
        {
            get { return invoice; }
            set { invoice = value; }
        }

        public AbstEvent(String n)
        {
            name = n;
        }

        public bool Equals(AbstEvent other)
        {
            return this.name == other.name && this.invoice.Books == other.invoice.Books;
        }
    }
}
