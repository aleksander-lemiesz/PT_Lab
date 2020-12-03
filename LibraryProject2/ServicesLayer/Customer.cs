using System;
using System.Collections.Generic;
using System.Text;

namespace ServicesLayer
{
    public class Customer : AbstCustomer
    {
        public Customer(string n, int nid, int m) : base(n, nid, m)
        {
        }
    }
}
