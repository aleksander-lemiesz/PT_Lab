﻿using Prism.Commands;
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
    class BorrowBookActionViewModel : INotifyPropertyChanged
    {

        private Customer _scust;
        public Customer SCustomer
        {
            get { return _scust; }
            set
            {
                _scust = value;
                OnPropertyChange("SCustomer");
            }
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
            set
            {
                _sbook = value;
                OnPropertyChange("SBook");
            }
        }
        List<Book> books;
        public List<Book> GetBooks()
        {
            books = new List<Book>();
            for (int i = 1; i <= BookCRUD.countBooks(); i++)
            {
                Book b = new Book(i);
                if (b.State == 1) books.Add(b);
            }
            return books;
        }
        public BorrowBookActionViewModel()
        {
            AddBorrowBookCommand = new DelegateCommand(AddBorrowBook);

        }

        public ICommand AddBorrowBookCommand
        {
            get;
            private set;
        }

        private void AddBorrowBook()
        {
            int _id = BorrowedBookCRUD.getMaxId() + 1;
            bool res = BorrowedBookCRUD.borrowBook(_id, SCustomer.CustomerId, SBook.BookId);
            if (res == false)
            {
                if (SCustomer.Money < 0)
                {
                    MessageBox.Show("Customer " + SCustomer.Name + " does not have enough funds to borrow this book.");
                }
                else MessageBox.Show("Book already borrowed.");
            }
            else MessageBox.Show("Book " + SBook.Title + " borrowed by " + SCustomer.Name + ". It needs to be returned before " + DateTime.Today.AddDays(14) + ".");

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
