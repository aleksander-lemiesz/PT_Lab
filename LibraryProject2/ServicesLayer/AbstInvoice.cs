using System;
using System.Collections.Generic;
using System.Text;

namespace ServicesLayer
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
