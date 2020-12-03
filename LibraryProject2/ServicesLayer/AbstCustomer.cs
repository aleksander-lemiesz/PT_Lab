using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ServicesLayer
{
    public abstract class AbstCustomer : IEquatable<AbstCustomer>
    {
        private String name;
        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        private int id;
        public int Id
        {
            get { return id; }
        }

        private int moneyInCents;
        public int MoneyInCents
        {
            get { return moneyInCents; }
            set { moneyInCents = value; }
        }

        private List<AbstBook> borrowed; 
        public List<AbstBook> Borrowed
        {
            get { return borrowed; }
            set { borrowed = value; }
        }

        private List<AbstBook> basket;
        public List<AbstBook> Basket
        {
            get { return basket; }
            set { basket = value; }
        }

        public AbstCustomer(String n, int nid, int m)
        {
            name = n;
            moneyInCents = m;
            id = nid;
            borrowed = new List<AbstBook>();
            basket = new List<AbstBook>();
        }

        public AbstCustomer(String n, int m)
        {
            name = n;
            moneyInCents = m;
            id = new Random().Next();
            borrowed = new List<AbstBook>();
            basket = new List<AbstBook>();
        }

        public bool Equals(AbstCustomer other)
        {
            return this.id == other.id;
        }
    }
}
