using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLayerSQL;

namespace ServicesLayer
{
    public static class CustomerCRUD
    {
        static public bool addCustomer(Customers customer)
        {
            LibraryLinqDataContext db = new LibraryLinqDataContext();
            db.Customers.InsertOnSubmit(customer);
            db.SubmitChanges();
            return true;
        }

        static public bool removeCustomer(int _id)
        {
            LibraryLinqDataContext db = new LibraryLinqDataContext();
            Customers customer = db.Customers.Where(p => p.id == _id).First();
            db.Customers.DeleteOnSubmit(customer);
            db.SubmitChanges();
            return true;
        }

        static public bool updateName(int _id, string _name)
        {
            LibraryLinqDataContext db = new LibraryLinqDataContext();
            Customers customer = db.Customers.Where(p => p.id == _id).First();
            customer.name = _name;
            db.SubmitChanges();
            return true;
        }
        static public bool updateMoney(int _id, int _difference)
        {
            LibraryLinqDataContext db = new LibraryLinqDataContext();
            Customers customer = db.Customers.Where(p => p.id == _id).First();
            customer.money += _difference;
            db.SubmitChanges();
            return true;
        }

        static public Customers getCustomer(int _id)
        {
            LibraryLinqDataContext db = new LibraryLinqDataContext();
            Customers customer = db.Customers.Where(p => p.id == _id).First();
            return customer;
        }
    }
}
