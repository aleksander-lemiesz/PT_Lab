using DataLayer;
using LogicLayer;
using NUnit.Framework;
using System;
using System.Linq;

namespace LogicLayerTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CustomerLogicTest()
        {
            LibraryLogic logic = new LibraryLogic(new Library());

            AbstCustomer c = new Customer("Paul", 1, 10000);

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
        public void RandomCustomerLogicTest()
        {
            LibraryLogic logic = new LibraryLogic(new Library());

            AbstCustomer c = new RndIdCustomer("Paul", 10000);

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
            LibraryLogic logic = new LibraryLogic(new Library());
            var b = new Book("Dune", "Herbert", BType.SciFi, 25, 1);

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
            LibraryLogic logic = new LibraryLogic(new Library());
            var b = new Book("Dune", "Herbert", BType.SciFi, 25, 1);

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
            LibraryLogic logic = new LibraryLogic(new Library());
            AbstCustomer c = new Customer("Paul", 1, 10000);
            AbstBook b = new Book("Dune", "Herbert", BType.SciFi, 25, 1);

            Assert.IsFalse(logic.AddToBasket(c, b));

            logic.AddToCatalog(b);
            logic.AddToStock(b);

            Assert.IsFalse(logic.AddToBasket(c, logic.GetLibrary.Stock[0]));

            logic.AddCustomer(c);
            logic.RemoveFromStock(b);

            Assert.IsFalse(logic.AddToBasket(logic.GetLibrary.Customers[0], b));

            logic.AddToStock(b);

            Assert.IsTrue(logic.AddToBasket(logic.GetLibrary.Customers[0], logic.GetLibrary.Stock[0]));
            Assert.AreEqual(logic.GetLibrary.Customers[0].Basket.Count(), 1);
            Assert.AreEqual(logic.GetLibrary.Stock.Count(), 0);
        }

        [Test]
        public void BorrowTest()
        {
            LibraryLogic logic = new LibraryLogic(new Library());
            AbstCustomer c = new Customer("Paul", 1, 10000);
            AbstBook b = new Book("Dune", "Herbert", BType.SciFi, 25, 1);

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
            LibraryLogic logic = new LibraryLogic(new Library());

            DateTime pastDate = new DateTime(2020, 10, 30);
            TimeSpan diff = DateTime.Today - pastDate;

            var b = new Book("Dune", "Herbert", BType.SciFi, 1, 1);
            b.ReturnDate = pastDate;
            Assert.AreEqual(logic.BookPenalty(b), diff.Days);

            var b2 = new Book("Dune", "Herbert", BType.SciFi, 1, 1);
            Assert.AreEqual(logic.BookPenalty(b2), 0);
        }

        [Test]
        public void TotalPenaltyTest()
        {
            LibraryLogic logic = new LibraryLogic(new Library());

            DateTime pastDate = new DateTime(2020, 10, 30);
            TimeSpan diff = DateTime.Today - pastDate;

            AbstCustomer c = new Customer("Paul", 1, 10000);
            AbstBook b1 = new Book("Dune", "Herbert", BType.SciFi, 1, 1);
            AbstBook b2 = new Book("Dune's Childer", "Herbert", BType.SciFi, 1, 2);

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

            AbstCustomer c2 = new Customer("Chani", 2, 10000);
            AbstBook b3 = new Book("Dune", "Herbert", BType.SciFi, 1, 3);
            AbstBook b4 = new Book("Dune's Childer", "Herbert", BType.SciFi, 1, 4);

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
            LibraryLogic logic = new LibraryLogic(new Library());

            DateTime pastDate = new DateTime(2020, 10, 30);
            TimeSpan diff = DateTime.Today - pastDate;

            AbstCustomer c = new Customer("Paul", 1, 10000);
            AbstBook b1 = new Book("Dune", "Herbert", BType.SciFi, 1, 1);
            AbstBook b2 = new Book("Dune's Childer", "Herbert", BType.SciFi, 1, 2);

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

            AbstCustomer c2 = new Customer("Chani", 2, 10000);

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
            LibraryLogic logic = new LibraryLogic(new Library());

            DateTime pastDate = new DateTime(2020, 10, 30);
            TimeSpan diff = DateTime.Today - pastDate;

            AbstCustomer c = new Customer("Paul", 1, 10000);
            AbstBook b = new Book("Dune", "Herbert", BType.SciFi, 1, 1);

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

        [Test]
        public void EventGanerationTest()
        {
            LibraryLogic logic = new LibraryLogic(new Library());

            AbstCustomer c = new Customer("Paul", 1, 10000);
            AbstBook b = new Book("Dune", "Herbert", BType.SciFi, 1, 2);

            logic.AddCustomer(c);
            Assert.AreEqual(logic.GetLibrary.Events[0].Name, "Added customer " + c.Id);

            logic.AddToCatalog(b);
            Assert.AreEqual(logic.GetLibrary.Events[1].Name, "Added to catalog book " + b.Id);

            logic.AddToStock(b);
            Assert.AreEqual(logic.GetLibrary.Events[2].Name, "Added to stock book " + b.Id);

            logic.AddToBasket(logic.GetLibrary.Customers[0], logic.GetLibrary.Stock[0]);
            Assert.AreEqual(logic.GetLibrary.Events[3].Name, "Removed from stock book " + b.Id);
            Assert.AreEqual(logic.GetLibrary.Events[4].Name, "Added to basket of " + c.Id + " book " + b.Id);

            logic.Borrow(logic.GetLibrary.Customers[0]);
            Assert.AreEqual(logic.GetLibrary.Events[5].Name, "Borrowing books by " + c.Id);
            Assert.AreEqual(logic.GetLibrary.Events[5].GetInvoice.Books[0], b);

            Console.WriteLine("Customer c. borrowed:1 " + logic.GetLibrary.Customers[0].Borrowed.Count());
            logic.Return(logic.GetLibrary.Customers[0]);
            Console.WriteLine("Customer c. borrowed:2 " + logic.GetLibrary.Customers[0].Borrowed.Count());
            
            Assert.AreEqual(logic.GetLibrary.Events[6].Name, "Returning books by " + c.Id);
            
            Console.WriteLine(logic.GetLibrary.Events[6].GetInvoice.Books.Count());
            Assert.AreEqual(logic.GetLibrary.Events[6].GetInvoice.Books.Count(), 1);

            Assert.AreEqual(logic.GetLibrary.Events[7].Name, "Added to stock book " + b.Id);

            logic.RemoveCustomer(logic.GetLibrary.Customers[0]);
            Assert.AreEqual(logic.GetLibrary.Events[8].Name, "Removed customer " + c.Id);

            logic.RemoveFromCatalog(logic.GetLibrary.Catalog[0]);
            Assert.AreEqual(logic.GetLibrary.Events[9].Name, "Removed from catalog book " + b.Id);

        }
    }
}