using Prism.Commands;
using ServicesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WPFLayer.Model
{
    public class Book
    {

        public Book(int _id)
        {
            BookViewCommand = new DelegateCommand(BookView);
            BookDeleteCommand = new DelegateCommand(BookDelete);
            BookEditCommand = new DelegateCommand(BookEdit);

            BookId = _id;
            Title = BookCRUD.getTitle(_id);
            Author = BookCRUD.getAuthor(_id);
            Type = BookCRUD.getType(_id);
            PenaltyCost = BookCRUD.getPenaltyCost(_id);
            ReturnDate = BookCRUD.getReturnDate(_id);
            State = BookCRUD.getState(_id);

        }

        public Book(int _id, string _title, string _author, string _type, int _penaltyCost, DateTime _returnDate, int _state)
        {
            BookId = _id;
            Title = _title;
            Author = _author;
            Type = _type;
            PenaltyCost = _penaltyCost;
            ReturnDate = _returnDate;
            State = _state;
        }

        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Type { get; set; }
        public int PenaltyCost { get; set; }
        public DateTime ReturnDate { get; set; }
        public int State { get; set; }

        public ICommand BookViewCommand
        {
            get;
            private set;
        }

        private void BookView()
        {
           // BookDetailsWindow bookDetailsWindow = new BookDetailsWindow(this.BookId);
           // bookDetailsWindow.Show();
        }

        public ICommand BookDeleteCommand
        {
            get;
            private set;
        }

        private void BookDelete()
        {
            BookCRUD.removeBook(this.BookId);
            if (BookCRUD.getTitle(this.BookId) == null)
            {
               // MessageBox.Show("Book " + Title + " by " + Author + " deleted.");
            }
            else
            {
              // MessageBox.Show("Cannot delete a book " + Title + ". It is currently borrowed to a customer.");
            }
            
        }

        public ICommand BookEditCommand
        {
            get;
            private set;
        }

        private void BookEdit()
        {
            //BookEditWindow bookEditWindow = new BookEditWindow(this.BookId);
           // bookEditWindow.Show();
        }
    }
}

