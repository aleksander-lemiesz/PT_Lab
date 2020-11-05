using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public class Book : AbstBook
    {
        public Book(string t, string a, BType ty, int prd, int nid) : base(t, a, ty, prd, nid)
        {
        }
    }
}
