using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    class Customer : IEquatable<Customer>
    {
        private String name { get; }
        private int moneyInCents { get; set; }
        private List<Book> borrowed { get; set; }

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
