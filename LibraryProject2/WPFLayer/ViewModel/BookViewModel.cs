using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using WPFLayer.Model;
using ServicesLayer;
using System.Collections.ObjectModel;

namespace WPFLayer.ViewModel
{
    public partial class ListsViewModel : INotifyPropertyChanged
    {
        private Book book;
        private ObservableCollection<Book> books;

        public int BookId
        {
            get { return book.BookId; }
            set
            {
                if (book.BookId != value)
                {
                    book.BookId = value;
                    OnPropertyChange("BookId");
                }
            }
        }

        public string Title
        {
            get { return book.Title; }
            set
            {
                if (book.Title != value)
                {
                    book.Title = value;
                    BookCRUD.updateTitle(book.BookId, value);
                    OnPropertyChange("Title");
                }
            }
        }

        public string Author
        {
            get { return book.Author; }
            set
            {
                if (book.Author != value)
                {
                    book.Author = value;
                    BookCRUD.updateAuthor(book.BookId, value);
                    OnPropertyChange("Author");
                }
            }
        }

        public string Type
        {
            get { return book.Type; }
            set
            {
                if (book.Type != value)
                {
                    book.Type = value;
                    BookCRUD.updateType(book.BookId, value);
                    OnPropertyChange("Type");
                }
            }
        }

        public int PenaltyCost
        {
            get { return book.PenaltyCost; }
            set
            {
                if (book.PenaltyCost != value)
                {
                    book.PenaltyCost = value;
                    BookCRUD.updatePenaltyCost(book.BookId, value);
                    OnPropertyChange("PenaltyCost");
                }
            }
        }

        public DateTime ReturnDate
        {
            get { return book.ReturnDate; }
            set
            {
                if (book.ReturnDate != value)
                {
                    book.ReturnDate = value;
                    BookCRUD.updateReturnDate(book.BookId, value);
                    OnPropertyChange("ReturnDate");
                }
            }
        }
        public int State
        {
            get { return book.State; }
            set
            {
                if (book.State != value)
                {
                    book.State = value;
                    BookCRUD.updateState(book.BookId, value);
                    OnPropertyChange("State");
                }
            }
        }

        public ObservableCollection<Book> Books
        {
            get { return GetBooks(); }
            set
            {
                for (int i = 0; i < Customers.Count; i++)
                {
                    if (Books[i] != value[i])
                    {
                        Books[i] = value[i];
                        BookCRUD.removeBook(Books[i].BookId);
                        OnPropertyChange("Books");
                    }
                }

            }
        }


    }
}
