using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public abstract class AbstInvoice
    {
        private List<AbstBook> books;
        public List<AbstBook> Books
        {
            get { return books; }
            set { books = value; }
        }
    }
}
