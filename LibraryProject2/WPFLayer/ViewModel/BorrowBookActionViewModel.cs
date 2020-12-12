using ServicesLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFLayer.Model;

namespace WPFLayer.ViewModel
{
    class BorrowBookActionViewModel : INotifyPropertyChanged
    {
        private Customer _scust;
        public Customer SCustomer
        {
            get { return _scust; }
            set { _scust = value; }
        }
        List<Customer> customers;
        public List<Customer> GetCustomers()
        {
            customers = new List<Customer>();
            for (int i = 1; i <= CustomerCRUD.countCustomers(); i++)
            {
                customers.Add(new Customer(i));
            }
            return customers;
        }

        private Book _sbook;
        public Book SBook
        {
            get { return _sbook; }
            set { _sbook = value; }
        }
        List<Book> books;
        public List<Book> GetBooks()
        {
            books = new List<Book>();
            for (int i = 1; i <= BookCRUD.countBooks(); i++)
            {
                books.Add(new Book(i));
            }
            return books;
        }
        public BorrowBookActionViewModel()
        {

            
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
