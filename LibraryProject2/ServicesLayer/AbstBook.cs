using System;
using System.ComponentModel;
using System.Data.Linq.Mapping;

namespace ServicesLayer
{
    [Table(Name = "Books")]
    public abstract class AbstBook : IEquatable<AbstBook>
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

        private string _title;
        [Column]
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged("Title");
            }
        }

        private int _price;
        [Column]
        public int Price
        {
            get { return _price; }
            set
            {
                _price = value;
                OnPropertyChanged("Price");
            }
        }

        private string _author;
        [Column]
        public string Author
        {
            get { return _author; }
            set
            {
                _author = value;
                OnPropertyChanged("Author");
            }
        }

        private BType _type;
        [Column]
        public BType Genre
        {
            get { return _type; }
            set
            {
                _type = value;
                OnPropertyChanged("Genre");
            }
        }

        private DateTime _returnDate;
        [Column]
        public DateTime ReturnDate
        {
            get { return _returnDate; }
            set { 
                _returnDate = value;
                OnPropertyChanged("ReturnDate");
            }
        }

        private int _penaltyCost;
        [Column]
        public int PenaltyCost
        {
            get { return _penaltyCost; }
            set {
                _penaltyCost = value;
                OnPropertyChanged("PenaltyCost");
            }
        }

        public AbstBook(String t, String a, BType ty, int prd, int nid)
        {
            _title = t;
            _author = a;
            _type = ty;
            _returnDate = DateTime.Today;
            _penaltyCost = prd;
            this.Id = nid;
        }

        public AbstBook(String t, String a, BType ty, int prd)
        {
            _title = t;
            _author = a;
            _type = ty;
            _returnDate = DateTime.Today;
            _penaltyCost = prd;
            this.Id = new Random().Next();
        }

        public bool Equals(AbstBook other)
        {
            return this.Id == other.Id;
        }

    }

    public enum BType
    {
        Drama,
        Fantasy,
        History,
        Horror,
        Criminal,
        Classic,
        Scientific,
        Romance,
        SciFi,
        Thriller
    }
}
