using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using WPFLayer.Model;
using ServicesLayer;

namespace WPFLayer.ViewModel
{
    public sealed class BookViewModel : INotifyPropertyChanged
    {
        private Book book;

        public int Id
        {
            get { return book.Id; }
            set
            {
                if (book.Id != value)
                {
                    book.Id = value;
                    OnPropertyChange("Id");
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
            get { return Id + " " + Title + " " + Author + " " + Type + " " + PenaltyCost + " " + ReturnDate + " " + State; }
        }

        public BookViewModel()
        {
            book = new Book(100);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChange(string v)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(v));
            }
        }
    }
}
