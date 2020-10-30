using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public class Customer : IEquatable<Customer>
    {
        private String name;
        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        private int moneyInCents;
        public int MoneyInCents
        {
            get { return moneyInCents; }
            set { moneyInCents = value; }
        }

        private List<Book> borrowed; 
        public List<Book> Borrowed
        {
            get { return borrowed; }
            set { borrowed = value; }
        }


        public Customer(String n, int m)
        {
            name = n;
            moneyInCents = m;
            borrowed = new List<Book>();
        }

        public bool Equals(Customer other)
        {
            return this.name == other.name;
        }
    }
}
