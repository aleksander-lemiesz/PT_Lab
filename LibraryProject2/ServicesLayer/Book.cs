using System;
using System.Collections.Generic;
using System.Text;

namespace ServicesLayer
{
    public class Book : AbstBook
    {
        public Book(string t, string a, string ty, int prd, int nid) : base(t, a, ty, prd, nid)
        {
        }

        public Book() { }
    }
}
