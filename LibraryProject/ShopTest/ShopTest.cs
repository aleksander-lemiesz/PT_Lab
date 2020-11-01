using DataLayer;
using LogicLayer;
using Newtonsoft.Json.Bson;
using NUnit.Framework;
using System;
using System.Linq;

namespace ShopTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

            // Data Layer Tests
        [Test]
        public void TestBook()
        {
            Book book1 = new Book("Dune", "Frank Herbert", BType.SciFi, 25);
            Book book2 = new Book("Dune", "Frank Herbert", BType.SciFi, 25);
            Book book3 = new Book("The Last Wish", "Andrzej Sapkowski", BType.Fantasy, 25);

            Assert.AreEqual(book1.Title, "Dune");
            Assert.AreEqual(book1.Author, "Frank Herbert");
            Assert.AreEqual(book1.Genre, BType.SciFi);
            Assert.AreEqual(book1.ReturnDate, DateTime.Today);
            Assert.AreEqual(book1.PricePerDayOverduedInCents, 25);

            Assert.AreEqual(book1, book2);
            Assert.AreNotEqual(book1, book3);
        }

        [Test]
        public void TestCustomer()
        {
            Customer customer1 = new Customer("John", 1000);
            Customer customer2 = new Customer("John", 2000);
            Customer customer3 = new Customer("Paul", 3000);

            Assert.AreEqual(customer1.Name, "John");
            Assert.AreEqual(customer1.MoneyInCents, 1000);

            Assert.AreEqual(customer1, customer2);
            Assert.AreNotEqual(customer1, customer3);

            Book book1 = new Book("Dune", "Frank Herbert", BType.SciFi, 25);
            Customer customer = new Customer("Paul", 10000);

            customer.Borrowed.Add(book1);

            Assert.AreEqual(customer.Borrowed.Count, 1);
            Assert.IsTrue(customer.Borrowed.Contains(book1));

            customer.Basket.Add(book1);

            Assert.AreEqual(customer.Basket.Count, 1);
            Assert.IsTrue(customer.Basket.Contains(book1));
        }

        [Test]
        public void TestInvoice()
        {
            Book book1 = new Book("Dune", "Frank Herbert", BType.SciFi, 25);
            Book book2 = new Book("Hunger Games", "Collins", BType.SciFi, 15);
            Book book3 = new Book("The Last Wish", "Andrzej Sapkowski", BType.Fantasy, 5);

            Customer customer = new Customer("Paul", 10000);

            customer.Borrowed.Add(book1);
            customer.Borrowed.Add(book2);
            customer.Borrowed.Add(book3);

            Invoice invoice = new Invoice();
            invoice.Books = customer.Borrowed;

            Assert.AreEqual(invoice.Books, customer.Borrowed);
        }

        [Test]
        public void TestEvent()
        {
            Book book1 = new Book("Dune", "Frank Herbert", BType.SciFi, 25);
            Book book2 = new Book("Hunger Games", "Collins", BType.SciFi, 15);
            Book book3 = new Book("The Last Wish", "Andrzej Sapkowski", BType.Fantasy, 5);

            Customer customer = new Customer("Paul", 10000);

            customer.Borrowed.Add(book1);
            customer.Borrowed.Add(book2);
            customer.Borrowed.Add(book3);

            Invoice invoice = new Invoice();
            invoice.Books = customer.Borrowed;
            Event event1 = new Event("Borrowing");
            event1.GetInvoice = invoice;

            Assert.AreEqual(event1.Name, "Borrowing");
            Assert.AreEqual(event1.GetInvoice, invoice);
            Assert.AreEqual(event1.GetInvoice.Books, invoice.Books);
            Assert.AreEqual(event1.GetInvoice.Books, customer.Borrowed);
        }

        // Logic Layer Tests
        [Test]
        public void CustomerLogicTest()
        {
            LibraryLogic logic = new LibraryLogic();

            Customer c = new Customer("Paul", 10000);

            logic.AddCustomer(c);

            Assert.IsTrue(logic.GetLibrary.Customers.Contains(c));
            Assert.IsTrue(logic.IsCustomer(c));

            logic.AddCustomer(c);
            Assert.AreEqual(logic.GetLibrary.Customers.Count(), 1);

            logic.AddFunds(c, 10000);
            Assert.AreEqual(logic.GetLibrary.Customers[0].MoneyInCents, 20000);

            logic.RemoveCustomer(logic.GetLibrary.Customers[0]);
            Assert.AreEqual(logic.GetLibrary.Customers.Count(), 0);
        }

        [Test]
        public void CatalogLogicTest()
        {
            var logic = new LibraryLogic();
            var b = new Book("Dune", "Herbert", BType.SciFi, 25);

            logic.AddToCatalog(b);

            Assert.IsTrue(logic.GetLibrary.Catalog.Contains(b));
            Assert.IsTrue(logic.IsInCatalog(b));

            logic.AddToCatalog(b);
            Assert.AreEqual(logic.GetLibrary.Catalog.Count(), 1);

            logic.RemoveFromCatalog(logic.GetLibrary.Catalog[0]);
            Assert.AreEqual(logic.GetLibrary.Catalog.Count(), 0);
        }

        [Test]
        public void StockLogicTest()
        {
            var logic = new LibraryLogic();
            var b = new Book("Dune", "Herbert", BType.SciFi, 25);

            logic.AddToStock(b);

            Assert.IsTrue(logic.GetLibrary.Stock.Contains(b));
            Assert.AreEqual(logic.GetLibrary.Stock.Count(), 1);
            Assert.IsTrue(logic.IsInStock(b));

            logic.AddToStock(b);
            Assert.AreEqual(logic.GetLibrary.Stock.Count(), 1);

            logic.RemoveFromStock(logic.GetLibrary.Stock[0]);
            Assert.AreEqual(logic.GetLibrary.Stock.Count(), 0);
        }

        [Test]
        public void AddToBasketTest()
        {
            var logic = new LibraryLogic();
            var c = new Customer("Paul", 10000);
            var b = new Book("Dune", "Herbert", BType.SciFi, 25);

            Assert.IsFalse(logic.AddToBasket(c, b));

            logic.AddToCatalog(b);
            logic.AddToStock(b);

            Assert.IsFalse(logic.AddToBasket(c, logic.GetLibrary.Stock[0]));

            logic.AddCustomer(c);
            logic.RemoveFromStock(b);

            Assert.IsFalse(logic.AddToBasket(logic.GetLibrary.Customers[0], b));

            logic.AddToStock(b);

            Assert.IsTrue(logic.AddToBasket(logic.GetLibrary.Customers[0], logic.GetLibrary.Stock[0]));
            Assert.AreEqual(logic.GetLibrary.Customers[0].Basket.Count() , 1);
            Assert.AreEqual(logic.GetLibrary.Stock.Count(), 0);
        }

        [Test]
        public void BorrowTest()
        {
            var logic = new LibraryLogic();
            var c = new Customer("Paul", 10000);
            var b = new Book("Dune", "Herbert", BType.SciFi, 25);

            logic.AddCustomer(c);
            logic.AddToCatalog(b);
            logic.AddToStock(b);

            logic.AddToBasket(logic.GetLibrary.Customers[0], logic.GetLibrary.Stock[0]);

            Assert.IsTrue(logic.Borrow(logic.GetLibrary.Customers[0]));
            Assert.AreEqual(logic.GetLibrary.Customers[0].Borrowed.Count(), 1);
            Assert.AreEqual(logic.GetLibrary.Customers[0].Basket.Count(), 0);
        }

        [Test]
        public void BookPenaltyTest()
        {
            var logic = new LibraryLogic();

            DateTime pastDate = new DateTime(2020, 10, 30);
            TimeSpan diff = DateTime.Today - pastDate;

            var b = new Book("Dune", "Herbert", BType.SciFi, 1);
            b.ReturnDate = pastDate;
            Assert.AreEqual(logic.BookPenalty(b), diff.Days);

            var b2 = new Book("Dune", "Herbert", BType.SciFi, 1);
            Assert.AreEqual(logic.BookPenalty(b2), 0);
        }

        [Test]
        public void TotalPenaltyTest()
        {
            var logic = new LibraryLogic();

            DateTime pastDate = new DateTime(2020, 10, 30);
            TimeSpan diff = DateTime.Today - pastDate;

            var c = new Customer("Paul", 10000);
            var b1 = new Book("Dune", "Herbert", BType.SciFi, 1);
            var b2 = new Book("Dune's Childer", "Herbert", BType.SciFi, 1);

            logic.AddCustomer(c);
            logic.AddToCatalog(b1);
            logic.AddToCatalog(b2);
            logic.AddToStock(b1);
            logic.AddToStock(b2);

            logic.AddToBasket(logic.GetLibrary.Customers[0], logic.GetLibrary.Stock[1]);
            logic.AddToBasket(logic.GetLibrary.Customers[0], logic.GetLibrary.Stock[0]);

            logic.Borrow(logic.GetLibrary.Customers[0]);
            logic.GetLibrary.Customers[0].Borrowed[0].ReturnDate = pastDate;
            logic.GetLibrary.Customers[0].Borrowed[1].ReturnDate = pastDate;

            Assert.AreEqual(logic.TotalPenalty(logic.GetLibrary.Customers[0]), diff.Days * 2);

            var c2 = new Customer("Chani", 10000);
            var b3 = new Book("Dune", "Herbert", BType.SciFi, 1);
            var b4 = new Book("Dune's Childer", "Herbert", BType.SciFi, 1);

            logic.AddCustomer(c2);
            logic.AddToCatalog(b3);
            logic.AddToCatalog(b4);
            logic.AddToStock(b3);
            logic.AddToStock(b4);

            Assert.AreEqual(logic.GetLibrary.Stock.Count(), 2);
            Assert.AreEqual(logic.GetLibrary.Customers.Count(), 2);

            logic.AddToBasket(logic.GetLibrary.Customers[1], logic.GetLibrary.Stock[1]);
            logic.AddToBasket(logic.GetLibrary.Customers[1], logic.GetLibrary.Stock[0]);

            logic.Borrow(logic.GetLibrary.Customers[1]);

            Assert.AreEqual(logic.TotalPenalty(logic.GetLibrary.Customers[1]), 0);
        }

        [Test]
        public void PayTest()
        {
            var logic = new LibraryLogic();

            DateTime pastDate = new DateTime(2020, 10, 30);
            TimeSpan diff = DateTime.Today - pastDate;

            var c = new Customer("Paul", 10000);
            var b1 = new Book("Dune", "Herbert", BType.SciFi, 1);
            var b2 = new Book("Dune's Childer", "Herbert", BType.SciFi, 1);

            logic.AddCustomer(c);
            logic.AddToCatalog(b1);
            logic.AddToCatalog(b2);
            logic.AddToStock(b1);
            logic.AddToStock(b2);

            Assert.AreEqual(logic.GetLibrary.Stock.Count(), 2);
            Assert.AreEqual(logic.GetLibrary.Customers.Count(), 1);

            logic.AddToBasket(logic.GetLibrary.Customers[0], logic.GetLibrary.Stock[1]);
            logic.AddToBasket(logic.GetLibrary.Customers[0], logic.GetLibrary.Stock[0]);
            logic.Borrow(logic.GetLibrary.Customers[0]);

            Assert.AreEqual(logic.GetLibrary.Customers[0].Borrowed.Count(), 2);

            logic.GetLibrary.Customers[0].Borrowed[0].ReturnDate = pastDate;
            logic.GetLibrary.Customers[0].Borrowed[1].ReturnDate = pastDate;
            Assert.AreEqual(logic.TotalPenalty(logic.GetLibrary.Customers[0]), diff.Days * 2);
            logic.Pay(logic.GetLibrary.Customers[0]);
            Assert.AreEqual(logic.GetLibrary.Customers[0].MoneyInCents, 10000 - diff.Days * 2);

            var c2 = new Customer("Chani", 10000);

            logic.AddCustomer(c2);
            logic.AddToStock(b1);
            logic.AddToStock(b2);

            logic.AddToBasket(logic.GetLibrary.Customers[1], logic.GetLibrary.Stock[1]);
            logic.AddToBasket(logic.GetLibrary.Customers[1], logic.GetLibrary.Stock[0]);
            logic.Borrow(logic.GetLibrary.Customers[1]);

            Assert.AreEqual(logic.GetLibrary.Customers[1].Borrowed.Count(), 2);

            Assert.AreEqual(logic.TotalPenalty(logic.GetLibrary.Customers[1]), 0);
            logic.Pay(logic.GetLibrary.Customers[1]);
            Assert.AreEqual(logic.GetLibrary.Customers[1].MoneyInCents, 10000);

        }

        [Test]
        public void ReturnTest()
        {
            var logic = new LibraryLogic();

            DateTime pastDate = new DateTime(2020, 10, 30);
            TimeSpan diff = DateTime.Today - pastDate;

            var c = new Customer("Paul", 10000);
            var b = new Book("Dune", "Herbert", BType.SciFi, 1);

            logic.AddCustomer(c);
            logic.AddToCatalog(b);
            logic.AddToStock(b);
            Assert.AreEqual(logic.GetLibrary.Stock.Count(), 1);

            logic.AddToBasket(logic.GetLibrary.Customers[0], logic.GetLibrary.Stock[0]);
            logic.Borrow(logic.GetLibrary.Customers[0]);
            Assert.AreEqual(logic.GetLibrary.Stock.Count(), 0);

            logic.GetLibrary.Customers[0].Borrowed[0].ReturnDate = pastDate;
            Assert.AreEqual(logic.TotalPenalty(logic.GetLibrary.Customers[0]), diff.Days);

            logic.Return(logic.GetLibrary.Customers[0]);

            Assert.AreEqual(logic.GetLibrary.Customers[0].MoneyInCents, 10000 - diff.Days);
            Assert.AreEqual(logic.GetLibrary.Stock.Count(), 1);
            Assert.AreEqual(logic.GetLibrary.Customers[0].Borrowed.Count(), 0);

        }
    }

}