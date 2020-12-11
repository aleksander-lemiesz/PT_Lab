using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using WPFLayer.Model;
using ServicesLayer;

namespace WPFLayer.ViewModel
{
    public partial class ListsViewModel : INotifyPropertyChanged
    {
        private Book book;

        public int BookId
        {
            get { return book.BookId; }
            set
            {
                if (book.BookId != value)
                {
                    book.BookId = value;
                    OnPropertyChange("BookId");
                    OnPropertyChange("BookRecord");
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
                    OnPropertyChange("Title");
                    OnPropertyChange("BookRecord");
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
                    OnPropertyChange("Author");
                    OnPropertyChange("BookRecord");
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
                    OnPropertyChange("Type");
                    OnPropertyChange("BookRecord");
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
                    OnPropertyChange("PenaltyCost");
                    OnPropertyChange("BookRecord");
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
                    OnPropertyChange("ReturnDate");
                    OnPropertyChange("BookRecord");
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
                    OnPropertyChange("State");
                    OnPropertyChange("BookRecord");
                }
            }
        }

        public string BookRecord
        {
            get { return BookId + " " + Title + " " + Author + " " + Type + " " + PenaltyCost + " " + ReturnDate + " " + State; }
        }


    }
}
