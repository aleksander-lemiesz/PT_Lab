using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLayerSQL;

namespace ServicesLayer
{
    public static class BookCRUD
    {
        static public bool addBook(int _id, string _title, string _author, string _type, int _penaltyCost, DateTime _returnDate, int _state)
        {
            try
            {
                Books book = new Books();
                book.id = _id;
                book.title = _title;
                book.author = _author;
                book.type = _type;
                book.penaltyCost = _penaltyCost;
                book.returnDate = _returnDate;
                book.state = _state;

                LibraryLinqDataContext db = new LibraryLinqDataContext();
                db.Books.InsertOnSubmit(book);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        static public bool removeBook(int _id)
        {
            try
            {
                LibraryLinqDataContext db = new LibraryLinqDataContext();
                Books book = db.Books.Where(p => p.id == _id).First();
                db.Books.DeleteOnSubmit(book);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        static public bool updateTitle(int _id, string _title)
        {
            try
            {
                LibraryLinqDataContext db = new LibraryLinqDataContext();
                Books book = db.Books.Where(p => p.id == _id).FirstOrDefault();
                book.title = _title;

                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        static public bool updateAuthor(int _id, string _author)
        {
            try
            {
                LibraryLinqDataContext db = new LibraryLinqDataContext();
                Books book = db.Books.Where(p => p.id == _id).First();
                book.author = _author;
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        static public bool updateType(int _id, string _type)
        {
            try
            {
                LibraryLinqDataContext db = new LibraryLinqDataContext();
                Books book = db.Books.Where(p => p.id == _id).First();
                book.type = _type;
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        static public bool updatePenaltyCost(int _id, int _penaltyCost)
        {
            try
            {
                LibraryLinqDataContext db = new LibraryLinqDataContext();
                Books book = db.Books.Where(p => p.id == _id).First();
                book.penaltyCost = 10;
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        static public bool updateReturnDate(int _id, DateTime _returnDate)
        {
            try
            {
                LibraryLinqDataContext db = new LibraryLinqDataContext();
                Books book = db.Books.Where(p => p.id == _id).First();
                book.returnDate = _returnDate;
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        static public bool updateState(int _id, int _state)
        {
            try
            {
                LibraryLinqDataContext db = new LibraryLinqDataContext();
                Books book = db.Books.Where(p => p.id == _id).First();
                book.state = _state;
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        static public Books getBook(int _id)
        {
            LibraryLinqDataContext db = new LibraryLinqDataContext();
            try
            {
                Books book = db.Books.Where(p => p.id == _id).First();
                return book;
            }
            catch (System.InvalidOperationException)
            {
                return null;
            }
        }
        static public string getTitle(int _id)
        {
            LibraryLinqDataContext db = new LibraryLinqDataContext();
            try
            {
                Books book = db.Books.Where(p => p.id == _id).First();
                return book.title;
            }
            catch (System.InvalidOperationException)
            {
                return null;
            }
        }
        static public string getAuthor(int _id)
        {
            LibraryLinqDataContext db = new LibraryLinqDataContext();
            try
            {
                Books book = db.Books.Where(p => p.id == _id).First();
                return book.author;
            }
            catch (System.InvalidOperationException)
            {
                return null;
            }
        }
        static public string getType(int _id)
        {
            LibraryLinqDataContext db = new LibraryLinqDataContext();
            try
            {
                Books book = db.Books.Where(p => p.id == _id).First();
                return book.type;
            }
            catch (System.InvalidOperationException)
            {
                return null;
            }
        }
        static public int getPenaltyCost(int _id)
        {
            LibraryLinqDataContext db = new LibraryLinqDataContext();
            try
            {
                Books book = db.Books.Where(p => p.id == _id).First();
                return book.penaltyCost;
            }
            catch (System.InvalidOperationException)
            {
                return 0;
            }
        }
        static public DateTime getReturnDate(int _id)
        {
            LibraryLinqDataContext db = new LibraryLinqDataContext();
            try
            {
                Books book = db.Books.Where(p => p.id == _id).First();
                return (DateTime)book.returnDate;
            }
            catch (System.InvalidOperationException)
            {
                return DateTime.Today;
            }
        }
        static public int getState(int _id)
        {
            LibraryLinqDataContext db = new LibraryLinqDataContext();
            try
            {
                Books book = db.Books.Where(p => p.id == _id).First();
                return (int)book.state;
            }
            catch (System.InvalidOperationException)
            {
                return -1;
            }
        }
        static public int countBooks()
        {
            LibraryLinqDataContext db = new LibraryLinqDataContext();
            return db.Books.Count();
        }
        static public int getMaxId()
        {
            LibraryLinqDataContext db = new LibraryLinqDataContext();
            if (countBooks() == 0) return 0;
            else return db.Books.OrderByDescending(p => p.id).First().id;
        }

    }
}
