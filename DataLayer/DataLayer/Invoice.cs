using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public class Invoice
    {
        private List<Book> books;
        public List<Book> Books
        {
            get { return books; }
            set { books = value; }
        }
    }
}
