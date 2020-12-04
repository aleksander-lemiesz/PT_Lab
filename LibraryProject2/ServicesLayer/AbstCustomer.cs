using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq.Mapping;
using System.Runtime.CompilerServices;
using System.Text;

namespace ServicesLayer
{
    [Table(Name = "Customers")]
    public abstract class AbstCustomer : IEquatable<AbstCustomer>
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        [Column(IsPrimaryKey = true, IsDbGenerated = true)] internal int Id { get; set; }

        private string _name;
        [Column]
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }
        private int _money;
        [Column]
        public int Money
        {
            get { return _money; }
            set
            {
                _money = value;
                OnPropertyChanged("Money");
            }
        }
       
        private List<AbstBook> borrowed; 
        public List<AbstBook> Borrowed
        {
            get { return borrowed; }
            set { borrowed = value; }
        }

        private List<AbstBook> basket;
        public List<AbstBook> Basket
        {
            get { return basket; }
            set { basket = value; }
        }

        public AbstCustomer(String n, int nid, int m)
        {
            _name = n;
            _money = m;
            Id = nid;
            borrowed = new List<AbstBook>();
            basket = new List<AbstBook>();
        }

        public AbstCustomer(String n, int m)
        {
            _name = n;
            _money = m;
            Id = new Random().Next();
            borrowed = new List<AbstBook>();
            basket = new List<AbstBook>();
        }

        public bool Equals(AbstCustomer other)
        {
            return this.Id == other.Id;
        }
    }
}
