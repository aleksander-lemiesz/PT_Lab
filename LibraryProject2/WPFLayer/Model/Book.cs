using Prism.Commands;
using ServicesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPFLayer.View;

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
            BookDetailsWindow bookDetailsWindow = new BookDetailsWindow(this.BookId);
            bookDetailsWindow.Show();
        }

        public ICommand BookDeleteCommand
        {
            get;
            private set;
        }

        private void BookDelete()
        {
            BookCRUD.removeBook(this.BookId);
            MessageBox.Show("Book " + Title + " by " + Author + " deleted.");
        }

        public ICommand BookEditCommand
        {
            get;
            private set;
        }

        private void BookEdit()
        {
            BookEditWindow bookEditWindow = new BookEditWindow(this.BookId);
            bookEditWindow.Show();
        }
    }
}

