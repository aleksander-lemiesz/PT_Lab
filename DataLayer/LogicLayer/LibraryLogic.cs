using DataLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLayer
{
    public class LibraryLogic
    {
        private Library library;
        public Library GetLibrary
        {
            get { return library; }
        }

        public LibraryLogic()
        {
            library = new Library();
        }

        public bool IsCustomer(Customer c)
        {
            return library.Customers.Contains(c) ? true : false;
        }

        public void AddCustomer(Customer c)
        {
            if (!IsCustomer(c))
            {
                library.Customers.Add(c);
            }
        }

        public void AddFunds(Customer c, int moneyInCents)
        {
            c.MoneyInCents += moneyInCents;
        }

        public void RemoveCustomer(Customer c)
        {
            if (IsCustomer(c))
            {
                library.Customers.Remove(c);
            }
        }

        public bool IsInCatalog(Book b)
        {
            return library.Catalog.Contains(b) ? true : false;
        }

        public void AddToCatalog(Book b)
        {
            if (!IsInCatalog(b))
            {
                library.Catalog.Add(b);
            }
            
        }

        public void RemoveFromCatalog(Book b)
        {
            if (IsInCatalog(b))
            {
                library.Catalog.Remove(b);
            }
        }

        public bool IsInStock(Book b)
        {
            return library.Stock.Contains(b) ? true : false; 
        }

        public void AddToStock(Book b)
        {
            if (!IsInStock(b))
            {
                library.Stock.Add(b);
            }
        }

        public void RemoveFromStock(Book b)
        {
            if (IsInStock(b))
            {
                library.Stock.Remove(b);
            }
        }

        public bool AddToBasket(Customer c, Book b)
        {
            if (IsCustomer(c) && IsInStock(b))
            {
                c.Basket.Add(b);
                RemoveFromStock(b);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Borrow(Customer c)
        {
            if (c.MoneyInCents > 0)
            {
                Event anEvent = new Event("Borrowing books by " + c.Name);
                Invoice anInvoice = new Invoice();
                foreach (Book b in c.Basket)
                {
                    b.ReturnDate = DateTime.Today.AddDays(14);
                    c.Borrowed.Add(b);
                }
                anInvoice.Books = c.Borrowed;
                anEvent.GetInvoice = anInvoice;
                library.Events.Add(anEvent);
                c.Basket.Clear();
                return true;
            }
            else
            {
                return false;
            }
        }

        public int BookPenalty(Book b)
        {
            int penalty = 0;
            DateTime today = DateTime.Today;
            TimeSpan days;
            if (DateTime.Compare(today, b.ReturnDate) > 0)
            {
                days = today - b.ReturnDate;
                penalty = days.Days * b.PricePerDayOverduedInCents;
            }
            return penalty;
        }

        public int TotalPenalty(Customer c)
        {
            int penalty = 0;
            foreach (Book b in c.Borrowed)
            {
                penalty += BookPenalty(b);
            }
            return penalty;
        }

        public void Pay(Customer c)
        {
            c.MoneyInCents -= TotalPenalty(c);
        }

        public void Return(Customer c)
        {
            Event anEvent = new Event("Returning books by " + c.Name);
            Invoice anInvoice = new Invoice();
            anEvent.GetInvoice = anInvoice;
            library.Events.Add(anEvent);
            Pay(c);
            foreach(Book b in c.Borrowed)
            {
                AddToStock(b);
            }
            c.Borrowed.Clear();
        }
    }
}
