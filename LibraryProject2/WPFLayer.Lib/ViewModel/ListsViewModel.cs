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

            BookViewCommand = new DelegateCommand(BookView);
            BookDeleteCommand = new DelegateCommand(BookDelete);
            BookEditCommand = new DelegateCommand(BookEdit);

            CustomerViewCommand = new DelegateCommand(CustomerView);
            CustomerDeleteCommand = new DelegateCommand(CustomerDelete);
            CustomerEditCommand = new DelegateCommand(CustomerEdit);

            ViewCommand = new DelegateCommand(ViewDetails);
            ReturnBookCommand = new DelegateCommand(ReturnBook);
            EditReturnDateCommand = new DelegateCommand(EditReturnDate);


            b = GetBooks()[1];
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
        public Lazy<IWindow> ChildWindow2 { get; set; }
        public Lazy<IWindow> ChildWindow3 { get; set; }
      
        public ICommand BorrowBookCommand
        {
            get;
            private set;
        }

        private void BorrowBook()
        {
            IWindow _child = ChildWindow.Value;
            _child.Show();
        }
       
        public ICommand BookAddCommand
        {
            get;
            private set;
        }

        private void BookAdd()
        {
            IWindow _child = ChildWindow2.Value;
            _child.Show();
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
         }
        public ICommand CustomerAddCommand
        {
            get;
            private set;
        }

        private void CustomerAdd()
        {

            IWindow _child = ChildWindow3.Value;
            _child.Show();
        }
        public ICommand CustomerSaveCommand
        {
            get;
            private set;
        }

        private void CustomerSave()
        {
            CustomerCRUD.addCustomer(this.CustomerId, this.Name, this.Money);

        }
        public Lazy<IWindow> ChildWindowBook { get; set; }
        public Lazy<IWindow> ChildWindowBook2 { get; set; }
        public ICommand BookViewCommand
        {
            get;
            private set;
        }

        private void BookView()
        {
            IWindow _child = ChildWindowBook.Value;
            _child.Show();
        }

        public ICommand BookDeleteCommand
        {
            get;
            private set;
        }

        private void BookDelete()
        {
            BookCRUD.removeBook(this.BookId);
        }

        public ICommand BookEditCommand
        {
            get;
            private set;
        }

        private void BookEdit()
        {
            IWindow _child = ChildWindowBook2.Value;
            _child.Show();
        }

        public Lazy<IWindow> ChildWindowCustomer { get; set; }
        public Lazy<IWindow> ChildWindowCustomer2 { get; set; }

        public ICommand CustomerViewCommand
        {
            get;
            private set;
        }

        private void CustomerView()
        {
            IWindow _child = ChildWindowCustomer.Value;
            _child.Show();
        }

        public ICommand CustomerDeleteCommand
        {
            get;
            private set;
        }

        private void CustomerDelete()
        {
            CustomerCRUD.removeCustomer(this.CustomerId);
        }

        public ICommand CustomerEditCommand
        {
            get;
            private set;
        }

        private void CustomerEdit()
        {
            IWindow _child = ChildWindowCustomer2.Value;
            _child.Show();
        }

        public Lazy<IWindow> ChildWindowBBook { get; set; }
        public Lazy<IWindow> ChildWindowBBook2 { get; set; }
        public ICommand ViewCommand
        {
            get;
            private set;
        }

        private void ViewDetails()
        {
            IWindow _child = ChildWindowBBook.Value;
            _child.Show();
        }

        public ICommand ReturnBookCommand
        {
            get;
            private set;
        }

        private void ReturnBook()
        {
            BorrowedBookCRUD.returnBook(BBookId);
        }

        public ICommand EditReturnDateCommand
        {
            get;
            private set;
        }

        private void EditReturnDate()
        {
            IWindow _child = ChildWindowBBook2.Value;
            _child.Show();
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
