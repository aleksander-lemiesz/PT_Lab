using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DataLayerSQL;
using ServicesLayer;
using System.Linq;

namespace ServicesTests
{
    [TestClass]
    public class BorrowedBookCRUDTests
    {   
        [TestMethod]
        public void BorrowExistingBookToCustomerWithMoney()
        {
            Books book = new Books() { id = 201, author = "Jane Austin", title = "Awesome book", type = "Classic", penaltyCost = 20, state = 1 };
            Assert.IsTrue(BookCRUD.addBook(book));
            Customers c = new Customers() { id = 201, name = "Paul", money = 100 };
            Assert.IsTrue(CustomerCRUD.addCustomer(c));
            Assert.IsTrue(BorrowedBookCRUD.borrowBook(101, c, book));
            Assert.AreEqual(BookCRUD.getBook(book.id).returnDate, DateTime.Today.AddDays(14));
            Assert.AreEqual(BorrowedBookCRUD.getBorrowedBooks(book.id).customerId, c.id);
        }

        [TestMethod]
        public void BorrowExistingBookToCustomerWithoutMoney()
        {
            Books book = new Books() { id = 202, author = "Jane Austin", title = "Awesome book", type = "Classic", penaltyCost = 20, state = 1 };
            Assert.IsTrue(BookCRUD.addBook(book));
            Customers c = new Customers() { id = 202, name = "Paul", money = 0 };
            Assert.IsTrue(CustomerCRUD.addCustomer(c));
            Assert.IsFalse(BorrowedBookCRUD.borrowBook(102, c, book));
        }

        [TestMethod]
        public void BorrowNonExistingBookToCustomerWithMoney()
        {
            Books book = new Books() { id = 203, author = "Jane Austin", title = "Awesome book", type = "Classic", penaltyCost = 20, state = 1 };
            Customers c = new Customers() { id = 203, name = "Paul", money = 100 };
            Assert.IsTrue(CustomerCRUD.addCustomer(c));
            Assert.IsFalse(BorrowedBookCRUD.borrowBook(103, c, book));
        }

        [TestMethod]
        public void BorrowBorrowedBookToCustomerWithMoney()
        {
            Books book = new Books() { id = 204, author = "Jane Austin", title = "Awesome book", type = "Classic", penaltyCost = 20, state = 0 };
            Assert.IsTrue(BookCRUD.addBook(book));
            Customers c = new Customers() { id = 204, name = "Paul", money = 100 };
            Assert.IsTrue(CustomerCRUD.addCustomer(c));
            Assert.IsFalse(BorrowedBookCRUD.borrowBook(104, c, book));
        }
    }
}
