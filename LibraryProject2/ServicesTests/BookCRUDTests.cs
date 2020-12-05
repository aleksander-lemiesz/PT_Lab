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
            Assert.IsTrue(BookCRUD.addBook(book));
        }

        [TestMethod]
        public void DeleteBookFromDatabase()
        {
            Books book = new Books() { id = 103, author = "Jane Austin", title = "Awesome book", type = "Classic", penaltyCost = 20, state = 1 };
            Assert.IsTrue(BookCRUD.addBook(book));
            Assert.IsTrue(BookCRUD.removeBook(book.id));
        }

       /* [TestMethod]
        public void AddBookToDatabase()
        {
            Books book = new Books() { id = 103, author = "Jane Austin", title = "Awesome book", type = "Classic", penaltyCost = 20, state = 1 };
            Assert.IsTrue(BookCRUD.addBook(book));
        }*/

    }
}
