using System;

namespace DataLayer
{
    public abstract class AbstBook : IEquatable<AbstBook>
    {
        private String title;
        public String Title
        {
            get { return title; }
            set { title = value; }
        }

        private int id;
        public int Id
        {
            get { return id; }
        }

        private String author;
        public String Author
        {
            get { return author; }
            set { author = value; }
        }

        private BType type;
        public BType Genre
        {
            get { return type; }
            set { type = value; }
        }

        private DateTime returnDate;
        public DateTime ReturnDate
        {
            get { return returnDate; }
            set { returnDate = value; }
        }

        private int pricePerDayOverduedInCents;
        public int PricePerDayOverduedInCents
        {
            get { return pricePerDayOverduedInCents; }
            set { pricePerDayOverduedInCents = value; }
        }

        public AbstBook(String t, String a, BType ty, int prd, int nid)
        {
            title = t;
            author = a;
            type = ty;
            returnDate = DateTime.Today;
            pricePerDayOverduedInCents = prd;
            this.id = nid;
        }

        public AbstBook(String t, String a, BType ty, int prd)
        {
            title = t;
            author = a;
            type = ty;
            returnDate = DateTime.Today;
            pricePerDayOverduedInCents = prd;
            this.id = new Random().Next();
        }

        public bool Equals(AbstBook other)
        {
            return this.id == other.id;
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
