using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using ServicesLayer;
using DataLayerSQL;

namespace ServicesTests
{
    [TestClass]
    public class BookCRUDTests
    {
        [TestMethod]
        public void AddBookToDatabase()
        {
            Books book = new Books() { id = 103, author = "Jane Austin", title = "Awesome book", type = "Classic", penaltyCost = 20, state = 1 };
            Assert.IsTrue(BookCRUD.addBook(book.id, book.title, book.author, book.type, book.penaltyCost, DateTime.Today, (int)book.state));
            Assert.AreEqual(BookCRUD.getBook(book.id).penaltyCost, 20);
            Assert.AreEqual(BookCRUD.getBook(book.id).author, "Jane Austin");
            Assert.AreEqual(BookCRUD.getBook(book.id).title, "Awesome book");
            Assert.AreEqual(BookCRUD.getBook(book.id).type, "Classic");
            Assert.AreEqual(BookCRUD.getBook(book.id).state, 1);
        }

        [TestMethod]
        public void GetBook()
        {
            Books book = new Books() { id = 110, author = "Jane Austin", title = "Awesome book", type = "Classic", penaltyCost = 20, state = 1 };
            Assert.IsTrue(BookCRUD.addBook(book.id, book.title, book.author, book.type, book.penaltyCost, DateTime.Today, (int)book.state));
            Books book1 = BookCRUD.getBook(book.id);
            Assert.AreEqual(book.id, book1.id);
            Assert.AreEqual(book.title, book1.title);
        }

        [TestMethod]
        public void DeleteBookFromDatabase()
        {
            Books book = new Books() { id = 104, author = "Jane Austin", title = "Awesome book", type = "Classic", penaltyCost = 20, state = 1 };
            Assert.IsTrue(BookCRUD.addBook(book.id, book.title, book.author, book.type, book.penaltyCost, DateTime.Today, (int)book.state));
            Assert.IsTrue(BookCRUD.removeBook(book.id));
        }

        [TestMethod]
        public void UpdateBookTitle()
        {
            Books book = new Books() { id = 105, author = "Jane Austin", title = "Awesome book", type = "Classic", penaltyCost = 20, state = 1 };
            Assert.IsTrue(BookCRUD.addBook(book.id, book.title, book.author, book.type, book.penaltyCost, DateTime.Today, (int)book.state));
            Assert.IsTrue(BookCRUD.updateTitle(book.id, "Good book"));
            book = BookCRUD.getBook(book.id);
            Assert.AreEqual(book.title, "Good book");
        }

        [TestMethod]
        public void UpdateBookAuthor()
        {
            Books book = new Books() { id = 106, author = "Jane Austin", title = "Awesome book", type = "Classic", penaltyCost = 20, state = 1 };
            Assert.IsTrue(BookCRUD.addBook(book.id, book.title, book.author, book.type, book.penaltyCost, DateTime.Today, (int)book.state));
            Assert.IsTrue(BookCRUD.updateAuthor(book.id, "J.K.Rowling"));
            book = BookCRUD.getBook(book.id);
            Assert.AreEqual(book.author, "J.K.Rowling");
        }

        [TestMethod]
        public void UpdateBookType()
        {
            Books book = new Books() { id = 107, author = "Jane Austin", title = "Awesome book", type = "Classic", penaltyCost = 20, state = 1 };
            Assert.IsTrue(BookCRUD.addBook(book.id, book.title, book.author, book.type, book.penaltyCost, DateTime.Today, (int)book.state));
            Assert.IsTrue(BookCRUD.updateType(book.id, "Fantasy"));
            book = BookCRUD.getBook(book.id);
            Assert.AreEqual(book.type, "Fantasy");
        }

        [TestMethod]
        public void UpdateBookPenaltyCost()
        {
            Books book = new Books() { id = 108, author = "Jane Austin", title = "Awesome book", type = "Classic", penaltyCost = 20, state = 1 };
            Assert.IsTrue(BookCRUD.addBook(book.id, book.title, book.author, book.type, book.penaltyCost, DateTime.Today, (int)book.state));
            Assert.IsTrue(BookCRUD.updatePenaltyCost(book.id, 10));
            book = BookCRUD.getBook(book.id);
            Assert.AreEqual(book.penaltyCost, 10);
        }

        [TestMethod]
        public void UpdateBookState()
        {
            Books book = new Books() { id = 109, author = "Jane Austin", title = "Awesome book", type = "Classic", penaltyCost = 20, state = 1 };
            Assert.IsTrue(BookCRUD.addBook(book.id, book.title, book.author, book.type, book.penaltyCost, DateTime.Today, (int)book.state));
            Assert.IsTrue(BookCRUD.updateState(book.id, 0));
            book = BookCRUD.getBook(book.id);
            Assert.AreEqual(book.state, 0);
        }

    }
}
