using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServicesLayer;
using System;
using WPFLayer.Model;

namespace WPFLayerTests
{
    [TestClass]
    public class BorrowedBookTests
    {
        [TestMethod]
        public void GetBookInfoTest()
        {

            BorrowedBook b = new BorrowedBook(1);
            Assert.AreEqual(b.BookInfo(), "\r\nTitle: " + BookCRUD.getTitle(1) + "\r\nAuthor: " + BookCRUD.getAuthor(1)
                + "\r\nType: " + BookCRUD.getType(1) + "\r\nPenalty Cost: " + BookCRUD.getPenaltyCost(1)
                + "\r\nReturn Date: " + BookCRUD.getReturnDate(1));

        }
        [TestMethod]
        public void GetCustomerInfoTest()
        {
            BorrowedBook b = new BorrowedBook(2);
            Assert.AreEqual(b.CustomerInfo(), "\r\nName: " + CustomerCRUD.getName(2) + "\r\nMoney: " + CustomerCRUD.getMoney(2));

        }
    }
}
