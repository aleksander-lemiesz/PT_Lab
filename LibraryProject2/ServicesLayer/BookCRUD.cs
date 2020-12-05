﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLayerSQL;

namespace ServicesLayer
{
    public static class BookCRUD
    {
        static public bool addBook(Books book)
        {
            LibraryLinqDataContext db = new LibraryLinqDataContext();
            db.Books.InsertOnSubmit(book);
            db.SubmitChanges();
            return true;
        }

        static public bool removeBook(int _id)
        {
            LibraryLinqDataContext db = new LibraryLinqDataContext();
            Books book = db.Books.Where(p => p.id == _id).First();
            db.Books.DeleteOnSubmit(book);
            db.SubmitChanges();
            return true;
        }

        static public bool updateTitle(int _id, string _title)
        {
            LibraryLinqDataContext db = new LibraryLinqDataContext();
            Books book = db.Books.Where(p => p.id == _id).FirstOrDefault();
            book.title = _title;

            db.SubmitChanges();
            return true;
        }

        static public bool updateAuthor(int _id, string _author)
        {
            LibraryLinqDataContext db = new LibraryLinqDataContext();
            Books book = db.Books.Where(p => p.id == _id).First();
            book.author = _author;
            db.SubmitChanges();
            return true;
        }

        static public bool updateType(int _id, string _type)
        {
            LibraryLinqDataContext db = new LibraryLinqDataContext();
            Books book = db.Books.Where(p => p.id == _id).First();
            book.type = _type;
            db.SubmitChanges();
            return true;
        }
        static public bool updatePenaltyCost(int _id, int _penaltyCost)
        {
            LibraryLinqDataContext db = new LibraryLinqDataContext();
            Books book = db.Books.Where(p => p.id == _id).First();
            book.penaltyCost = 10;
            db.SubmitChanges();
            return true;
        }
        static public bool updateReturnDate(int _id, DateTime _returnDate)
        {
            LibraryLinqDataContext db = new LibraryLinqDataContext();
            Books book = db.Books.Where(p => p.id == _id).First();
            book.returnDate = _returnDate;
            db.SubmitChanges();
            return true;
        }

        static public bool updateState(int _id, int _state)
        {
            LibraryLinqDataContext db = new LibraryLinqDataContext();
            Books book = db.Books.Where(p => p.id == _id).First();
            book.state = _state;
            db.SubmitChanges();
            return true;
        }

        static public Books getBook(int _id)
        {
            LibraryLinqDataContext db = new LibraryLinqDataContext();
            try
            {
                Books book = db.Books.Where(p => p.id == _id).First();
                return book;
            } catch (System.InvalidOperationException)
            {
                return null;
            }
        }
    }
}
