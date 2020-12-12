using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Data.Linq;
using DataLayerSQL;
using System.Data.SqlClient;

namespace TestTest
{
    [TestClass]
    public class DataLayerTest
    {
        static private string GetConnectionString()
        {
            // To avoid storing the connection string in your code,
            // you can retrieve it from a configuration file.
            return "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename =| DataDirectory |\\Library.mdf; Integrated Security = True";
        }

        private static void OpenSqlConnection()
        {
            string connectionString = GetConnectionString();

            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;

                connection.Open();

                Console.WriteLine("State: {0}", connection.State);
                Console.WriteLine("ConnectionString: {0}",
                    connection.ConnectionString);
            }
        }

        [TestMethod]
        public void AddBookToDatabase()
        {
            //OpenSqlConnection();
            
            LibraryLinqDataContext db = new LibraryLinqDataContext();

            Books book = new Books();
            book.id = 100;
            book.penaltyCost= 1;
            book.returnDate = null;
            book.state = 1;
            book.author = "God";
            book.title = "Bible";
            book.type = "Classic";



            db.Books.InsertOnSubmit(book);
            db.SubmitChanges();



            Books book1 = db.Books.FirstOrDefault(b => b.id.Equals(100));
            Assert.AreEqual(book1.id, 100);
            Assert.AreEqual(book1.penaltyCost, 1);
            Assert.IsNull(book1.returnDate);
            Assert.AreEqual(book1.author, "God");
            Assert.AreEqual(book1.title, "Bible");



            db.Books.DeleteOnSubmit(book);
            db.SubmitChanges();
        }

        [TestMethod]
        public void fetchFromDBTest()
        {
            LibraryLinqDataContext db = new LibraryLinqDataContext();

            Customers customer = db.Customers.FirstOrDefault(c => c.id.Equals(1));
            Assert.AreEqual(customer.id, 1);
            Assert.AreEqual(customer.name, "Mary Smith");
            Assert.AreEqual(customer.money, 100);

        }
    }
}
