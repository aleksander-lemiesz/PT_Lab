﻿using Prism.Commands;
using ServicesLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                customers.Add(new Customer(i));
            }
            return customers;
        }
        public List<Book> GetBooks()
        {
            books = new List<Book>();
            for (int i = 1; i <= BookCRUD.countBooks(); i++)
            {
                books.Add(new Book(i));
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
            //CustomersList.ItemsSource = customers;


            //book = new Book(100);
            //borrowed = new BorrowedBook(100);
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
