using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLayerSQL;

namespace ServicesLayer
{
    public static class BorrowedBookCRUD
    {
        public static bool borrowBook(int _id, Customers customer, Books book)
        {
            if ((BookCRUD.getBook(book.id) == null) || (book.state == 0) || (customer.money <= 0)) return false;

            BookCRUD.updateState(book.id, 0); // 1-book in stock, 0-book not in stock
            BookCRUD.updateReturnDate(book.id, DateTime.Today.AddDays(14));
            
            LibraryLinqDataContext db = new LibraryLinqDataContext();
            BorrowedBooks borrowed = new BorrowedBooks();
            borrowed.id = _id;
            borrowed.bookId = book.id;
            borrowed.customerId = customer.id;
            db.BorrowedBooks.InsertOnSubmit(borrowed);
            db.SubmitChanges();
            return true;
        }

        public static bool returnBook(int _bookId)
        {
            LibraryLinqDataContext db = new LibraryLinqDataContext();
            BorrowedBooks borrowed = db.BorrowedBooks.Where(p => p.bookId == _bookId).First();
            if (DateTime.Compare(DateTime.Today, (DateTime)BookCRUD.getBook(_bookId).returnDate) > 0)
            {
                TimeSpan days = DateTime.Today - (DateTime)BookCRUD.getBook(_bookId).returnDate;
                int penalty = -(BookCRUD.getBook(_bookId).penaltyCost * days.Days);
                CustomerCRUD.updateMoney(borrowed.customerId, penalty);
            }
            BookCRUD.updateState(_bookId, 1); // 1 - book back in stock 
            db.BorrowedBooks.DeleteOnSubmit(borrowed);
            db.SubmitChanges();
            return true;
        }
       
        public static BorrowedBooks getBorrowedBooks(int _bookId)
        {
            LibraryLinqDataContext db = new LibraryLinqDataContext();
            BorrowedBooks borrowed = db.BorrowedBooks.Where(p => p.bookId == _bookId).First();
            return borrowed;
        }
    }
}
