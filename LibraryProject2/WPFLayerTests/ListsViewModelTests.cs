using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServicesLayer;
using System;
using System.Collections.ObjectModel;
using WPFLayer.Model;
using WPFLayer.ViewModel;

namespace WPFLayerTests
{
    [TestClass]
    public class ListsViewModelTests
    {
        [TestMethod]
        public void CreateCustomersCollection()
        {
            ListsViewModel listsViewModel = new ListsViewModel();
            ObservableCollection<Customer> customers = listsViewModel.GetCustomers();
            Assert.AreEqual(customers.Count, CustomerCRUD.countCustomers());
        }
        [TestMethod]
        public void CreateBooksCollection()
        {
            ListsViewModel listsViewModel = new ListsViewModel();
            ObservableCollection<Book> books = listsViewModel.GetBooks();
            Assert.AreEqual(books.Count, BookCRUD.countBooks());
        }
        [TestMethod]
        public void CreateBorrowedBooksCollection()
        {
            ListsViewModel listsViewModel = new ListsViewModel();
            ObservableCollection<BorrowedBook> books = listsViewModel.GetBorrowedBooks();
            Assert.AreEqual(books.Count, BorrowedBookCRUD.countBorrowedBooks());
        }

        [TestMethod]
        public void CheckContentOfCustomersCollection()
        {
            ListsViewModel listsViewModel = new ListsViewModel();
            ObservableCollection<Customer> customers = listsViewModel.GetCustomers();
            for (int i = 0; i < customers.Count; i++)
            {
                Assert.AreEqual(customers[i].Name, CustomerCRUD.getName(customers[i].CustomerId));
                Assert.AreEqual(customers[i].Money, CustomerCRUD.getMoney(customers[i].CustomerId));
            }
        }
        [TestMethod]
        public void CheckContentOfBooksCollection()
        {
            ListsViewModel listsViewModel = new ListsViewModel();
            ObservableCollection<Book> books = listsViewModel.GetBooks();
            for (int i = 0; i < books.Count; i++)
            {
                Assert.AreEqual(books[i].Title, BookCRUD.getTitle(books[i].BookId));
                Assert.AreEqual(books[i].Author, BookCRUD.getAuthor(books[i].BookId));
            }
        }
        [TestMethod]
        public void CheckContentOfBorrowedBooksCollection()
        {
            ListsViewModel listsViewModel = new ListsViewModel();
            ObservableCollection<BorrowedBook> books = listsViewModel.GetBorrowedBooks();
            for(int i = 0; i < books.Count; i++)
            {
                Assert.AreEqual(books[i].BBookId, BorrowedBookCRUD.getBookId(books[i].BorrowedBookId));
                Assert.AreEqual(books[i].BCustomerId, BorrowedBookCRUD.getCustomerId(books[i].BorrowedBookId));
            }
            
        }

    }
}
