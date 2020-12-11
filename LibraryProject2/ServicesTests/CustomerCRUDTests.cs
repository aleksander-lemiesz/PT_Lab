using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DataLayerSQL;
using ServicesLayer;
using System.Linq;

namespace ServicesTests
{
    [TestClass]
    public class CustomerCRUDTests
    {
        [TestMethod]
        public void AddCustomerToDatabase()
        {
            Customers c = new Customers() { id = 101, name = "Paul", money = 100 };
            Assert.IsTrue(CustomerCRUD.addCustomer(c.id, c.name, c.money));
        }

        [TestMethod]
        public void DeleteCustomerFromDatabase()
        {
            Customers c = new Customers() { id = 102, name = "Paul", money = 100 };
            Assert.IsTrue(CustomerCRUD.addCustomer(c.id, c.name, c.money));
            Assert.IsTrue(CustomerCRUD.removeCustomer(c.id));
        }

        [TestMethod]
        public void GetCustomer()
        {
            Customers c = new Customers() { id = 103, name = "Paul", money = 100 };
            Assert.IsTrue(CustomerCRUD.addCustomer(c.id, c.name, c.money));
            Customers c1 = CustomerCRUD.getCustomer(c.id);
            Assert.AreEqual(c.id, c1.id);
            Assert.AreEqual(c.name, c1.name);
        }

        [TestMethod]
        public void UpdateCustomerName()
        {
            Customers c = new Customers() { id = 104, name = "Paul", money = 100 };
            Assert.IsTrue(CustomerCRUD.addCustomer(c.id, c.name, c.money));
            Assert.IsTrue(CustomerCRUD.updateName(c.id, "Shawn"));
            c = CustomerCRUD.getCustomer(c.id);
            Assert.AreEqual(c.name, "Shawn");
        }

        [TestMethod]
        public void UpdateCustomerMoney()
        {
            Customers c = new Customers() { id = 105, name = "Paul", money = 100 };
            Assert.IsTrue(CustomerCRUD.addCustomer(c.id, c.name, c.money));
            Assert.IsTrue(CustomerCRUD.updateMoney(c.id, 300));
            c = CustomerCRUD.getCustomer(c.id);
            Assert.AreEqual(c.money, 400);
        }
    }
}
