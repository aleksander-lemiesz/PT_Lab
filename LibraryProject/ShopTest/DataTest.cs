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

    }
}