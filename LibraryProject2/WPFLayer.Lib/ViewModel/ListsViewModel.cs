using Prism.Commands;
using ServicesLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPFLayer.Lib.ViewModel;
using WPFLayer.Model;

namespace WPFLayer.ViewModel
{
    public partial class ListsViewModel : INotifyPropertyChanged
    {
                // List<Customer> customers;
        public ObservableCollection<Customer> GetCustomers()
        {
            customers = new ObservableCollection<Customer>();
            for (int i = 1; i <= CustomerCRUD.getMaxId(); i++)
            {
                Customer c = new Customer(i);
                if (c.Name != null) customers.Add(c);
            }
            return customers;
        }
        public ObservableCollection<Book> GetBooks()
        {
            books = new ObservableCollection<Book>();
            for (int i = 1; i <= BookCRUD.getMaxId(); i++)
            {
                Book b = new Book(i);
                if (b.State != -1) books.Add(b);
            }
            return books;
        }

        public ObservableCollection<BorrowedBook> GetBorrowedBooks()
        {
            borroweds = new ObservableCollection<BorrowedBook>();
            for (int i = 1; i <= BorrowedBookCRUD.getMaxId(); i++)
            {
                BorrowedBook bb = new BorrowedBook(i);
                if (bb.BCustomerId != -1) borroweds.Add(bb);
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

            DisplayTextCommand = new DelegateCommand(ShowPopupWindow, () => !string.IsNullOrEmpty(m_ActionText));
            m_ActionText = "Text to be displayed on the popup";

            int _id = CustomerCRUD.getMaxId() + 1;
            customer = new Customer(_id, "name", 0);

            int _id2 = BookCRUD.getMaxId() + 1;
            book = new Book(_id2, "title", "author", "type", 0, DateTime.Today, 0);
        }

        public ListsViewModel(int _id, string _type)
        {
            if(_type == "book")
            {
                book = new Book(_id);
            }
            else
            {
                customer = new Customer(_id);
            }
        }
        public Lazy<IWindow> ChildWindow { get; set; }
        public Action<string> MessageBoxShowDelegate { get; set; } = x => throw new ArgumentOutOfRangeException($"The delegate {nameof(MessageBoxShowDelegate)} must be assigned by the view layer");

        public ICommand BorrowBookCommand
        {
            get;
            private set;
        }

        private void BorrowBook()
        {
            IWindow _child = ChildWindow.Value;
            _child.Show();
            // BorrowBookWindow borrowedBookWindow = new BorrowBookWindow();
            //  borrowedBookWindow.Show();
        }
        public ICommand DisplayTextCommand
        {
            get; private set;
        }
        private string m_ActionText;
        public string ActionText
        {
            get => m_ActionText;
            set
            {
                m_ActionText = value;/*
                DisplayTextCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged();*/
            }
        }
        private void ShowPopupWindow()
        {
            MessageBoxShowDelegate(ActionText);
        }
        public ICommand BookAddCommand
        {
            get;
            private set;
        }

        private void BookAdd()
        {
         //   BookAddWindow bookAddWindow = new BookAddWindow();
          //  bookAddWindow.Show();
        }
        public ICommand BookSaveCommand
        {
            get;
            private set;
        }

        private void BookSave()
        {
            int _id = BookCRUD.getMaxId() + 1;
            BookCRUD.addBook(_id, this.Title, this.Author, this.Type, this.PenaltyCost, this.ReturnDate, this.State);
          //  MessageBox.Show("Book " + this.Title + " added.");

        }
        public ICommand CustomerAddCommand
        {
            get;
            private set;
        }

        private void CustomerAdd()
        {
           
          //  CustomerAddWindow customerAddWindow = new CustomerAddWindow();
         //  customerAddWindow.Show();
        }
        public ICommand CustomerSaveCommand
        {
            get;
            private set;
        }

        private void CustomerSave()
        {
            CustomerCRUD.addCustomer(this.CustomerId, this.Name, this.Money);
          //  MessageBox.Show("Customer " + this.Name + " added.");

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
