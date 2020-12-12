using Prism.Commands;
using ServicesLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPFLayer.Model;
using WPFLayer.View;

namespace WPFLayer.ViewModel
{
    public partial class ListsViewModel : INotifyPropertyChanged
    {

        // List<Customer> customers;
        public List<Customer> GetCustomers()
        {
            customers = new List<Customer>();
            for (int i = 1; i <= CustomerCRUD.countCustomers(); i++)
            {
                Customer c = new Customer(i);
                if (c.Name != null) customers.Add(c);
            }
            return customers;
        }
        public List<Book> GetBooks()
        {
            books = new List<Book>();
            for (int i = 1; i <= BookCRUD.countBooks(); i++)
            {
                Book b = new Book(i);
                if (b.State != -1) books.Add(b);
            }
            return books;
        }

        public List<BorrowedBook> GetBorrowedBooks()
        {
            borroweds = new List<BorrowedBook>();
            for (int i = 1; i <= BorrowedBookCRUD.countBorrowedBooks(); i++)
            {
                borroweds.Add(new BorrowedBook(i));
            }
            return borroweds;
        }
        public ListsViewModel()
        {
            BorrowBookCommand = new DelegateCommand(BorrowBook);
            BookAddCommand = new DelegateCommand(BookAdd);
            CustomerAddCommand = new DelegateCommand(CustomerAdd);
            CustomerSaveCommand = new DelegateCommand(CustomerSave);
            BookSaveCommand = new DelegateCommand(BookSave);
        }

        public ListsViewModel(int _id)
        {
            book = new Book(_id);
            customer = new Customer(_id);
        }


        public ICommand BorrowBookCommand
        {
            get;
            private set;
        }

        private void BorrowBook()
        {
            BorrowBookWindow borrowedBookWindow = new BorrowBookWindow();
            borrowedBookWindow.Show();
        }

        public ICommand BookAddCommand
        {
            get;
            private set;
        }

        private void BookAdd()
        {
            BookAddWindow bookAddWindow = new BookAddWindow();
            bookAddWindow.Show();
        }
        public ICommand BookSaveCommand
        {
            get;
            private set;
        }

        private void BookSave()
        {

           /* this.Title = "title";
            this.Author = "author";
            this.Type = "type";
            this.PenaltyCost = 0;
            this.ReturnDate = DateTime.Today;
            this.State = 0;*/

            int _id = BookCRUD.getMaxId() + 1;
            BookCRUD.addBook(_id, this.Title, this.Author, this.Type, this.PenaltyCost, this.ReturnDate, this.State);
            MessageBox.Show("Book " + this.Title + " added.");

        }
        public ICommand CustomerAddCommand
        {
            get;
            private set;
        }

        private void CustomerAdd()
        {
           
            int _id = CustomerCRUD.getMaxId() + 1;
            customer = new Customer(_id, "name", 0);
            CustomerAddWindow customerAddWindow = new CustomerAddWindow();
            customerAddWindow.Show();
        }
        public ICommand CustomerSaveCommand
        {
            get;
            private set;
        }

        private void CustomerSave()
        {
            
           
            CustomerCRUD.addCustomer(this.BookId, this.Name, this.Money);
            MessageBox.Show("Customer " + this.Name + " added.");

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
