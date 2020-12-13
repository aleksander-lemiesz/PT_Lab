using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLayerSQL;

namespace ServicesLayer
{
    public static class CustomerCRUD
    {
        static public bool addCustomer(int _id, string _name, int _money)
        {
            try
            {
                Customers customer = new Customers();
                customer.id = _id;
                customer.name = _name;
                customer.money = _money;
                LibraryLinqDataContext db = new LibraryLinqDataContext();
                db.Customers.InsertOnSubmit(customer);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }



        }

        static public bool removeCustomer(int _id)
        {
            try
            {
                LibraryLinqDataContext db = new LibraryLinqDataContext();
                Customers customer = db.Customers.Where(p => p.id == _id).First();
                if (customer.money < 0) return false;
                db.Customers.DeleteOnSubmit(customer);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        static public bool updateName(int _id, string _name)
        {
            try
            {
                LibraryLinqDataContext db = new LibraryLinqDataContext();
                Customers customer = db.Customers.Where(p => p.id == _id).First();
                customer.name = _name;
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        static public bool updateMoney(int _id, int _difference)
        {
            try
            {
                LibraryLinqDataContext db = new LibraryLinqDataContext();
                Customers customer = db.Customers.Where(p => p.id == _id).First();
                customer.money += _difference;
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        static public Customers getCustomer(int _id)
        {
            try
            {
                LibraryLinqDataContext db = new LibraryLinqDataContext();
                Customers customer = db.Customers.Where(p => p.id == _id).First();
                return customer;
            }
            catch (Exception)
            {
                return null;
            }

        }

        static public string getName(int _id)
        {
            try
            {
                LibraryLinqDataContext db = new LibraryLinqDataContext();
                Customers customer = db.Customers.Where(p => p.id == _id).First();
                return customer.name;
            }
            catch (System.InvalidOperationException)
            {
                return null;
            }
        }
        static public int getMoney(int _id)
        {

            try
            {
                LibraryLinqDataContext db = new LibraryLinqDataContext();
                Customers customer = db.Customers.Where(p => p.id == _id).First();
                return customer.money;
            }
            catch (System.InvalidOperationException)
            {
                return -1;
            }
        }
        static public int countCustomers()
        {
            LibraryLinqDataContext db = new LibraryLinqDataContext();
            return db.Customers.Count();
        }
        static public int getMaxId()
        {
            LibraryLinqDataContext db = new LibraryLinqDataContext();
            if (countCustomers() == 0) return 0;
            else return db.Customers.OrderByDescending(p => p.id).First().id;
        }
    }
}
