using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicLayer
{
    public class LibraryLogic
    {
        private AbstLibrary library;
        public AbstLibrary GetLibrary
        {
            get { return library; }
        }

        public LibraryLogic(AbstLibrary absLibrary)
        {
            library = absLibrary;
        }

        public bool IsCustomer(AbstCustomer c)
        {
            return library.Customers.Contains(c) ? true : false;
        }

        public void AddCustomer(AbstCustomer c)
        {
            if (!IsCustomer(c))
            {
                library.Customers.Add(c);
                addEvent("Added customer " + c.Id);
            }
        }

        public void AddFunds(AbstCustomer c, int moneyInCents)
        {
            c.MoneyInCents += moneyInCents;
            addEvent("Added " + moneyInCents + " cents to account of " + c.Id);
        }

        public void RemoveCustomer(AbstCustomer c)
        {
            if (IsCustomer(c))
            {
                addEvent("Removed customer " + c.Id);
                library.Customers.Remove(c);
            }
        }

        public bool IsInCatalog(AbstBook b)
        {
            return library.Catalog.Contains(b) ? true : false;
        }

        public void AddToCatalog(AbstBook b)
        {
            if (!IsInCatalog(b))
            {
                library.Catalog.Add(b);
                addEvent("Added to catalog book " + b.Id);
            }
            
        }

        public void RemoveFromCatalog(AbstBook b)
        {
            if (IsInCatalog(b))
            {
                addEvent("Removed from catalog book " + b.Id);
                library.Catalog.Remove(b);
            }
        }

        public bool IsInStock(AbstBook b)
        {
            return library.Stock.Contains(b) ? true : false; 
        }

        public void AddToStock(AbstBook b)
        {
            if (!IsInStock(b))
            {
                library.Stock.Add(b);
                addEvent("Added to stock book " + b.Id);
            }
        }

        public void RemoveFromStock(AbstBook b)
        {
            if (IsInStock(b))
            {
                addEvent("Removed from stock book " + b.Id);
                library.Stock.Remove(b);
            }
        }

        public bool AddToBasket(AbstCustomer c, AbstBook b)
        {
            if (IsCustomer(c) && IsInStock(b))
            {
                c.Basket.Add(b);
                RemoveFromStock(b);
                addEvent("Added to basket of " + c.Id + " book " + b.Id);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void addEvent(String s, AbstCustomer c)
        {
            library.addEvent(s + " by " + c.Id);
            int size = library.Events.Count();
            library.Events[size - 1].GetInvoice.Books = new List<AbstBook>(c.Borrowed);
            //AbstEvent anEvent = new Event(s + " by " + c.Id);
            //AbstInvoice anInvoice = new Invoice();
            //anEvent.GetInvoice = anInvoice;
            //anEvent.GetInvoice.Books = new List<AbstBook>(c.Borrowed);
            //library.Events.Add(anEvent);
        }

        public void addEvent(String s)
        {
            library.addEvent(s);
            //AbstEvent anEvent = new Event(s);
            //AbstInvoice anInvoice = new Invoice();
            //anEvent.GetInvoice = anInvoice;
            //library.Events.Add(anEvent);
        }

        public bool Borrow(AbstCustomer c)
        {
            if (c.MoneyInCents > 0)
            {
                foreach (AbstBook b in c.Basket)
                {
                    b.ReturnDate = DateTime.Today.AddDays(14);
                    c.Borrowed.Add(b);
                }
                addEvent("Borrowing books", c);
                c.Basket.Clear();
                return true;
            }
            else
            {
                return false;
            }
        }

        public int BookPenalty(AbstBook b)
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

        public int TotalPenalty(AbstCustomer c)
        {
            int penalty = 0;
            foreach (AbstBook b in c.Borrowed)
            {
                penalty += BookPenalty(b);
            }
            return penalty;
        }

        public void Pay(AbstCustomer c)
        {
            c.MoneyInCents -= TotalPenalty(c);
        }

        public void Return(AbstCustomer c)
        {
            addEvent("Returning books", c);

            Pay(c);
            foreach(AbstBook b in c.Borrowed)
            {
                AddToStock(b);
            }
            c.Borrowed.Clear();
        }
    }
}
