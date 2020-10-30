using System;

namespace DataLayer
{
    public class Book : IEquatable<Book>
    {
        private String title;
        public String Title
        {
            get { return title; }
            set { title = value; }
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

        private BStatus status;
        public BStatus Stat
        {
            get { return status; }
            set { status = value; }
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

        public Book(String t, String a, BType ty, BStatus s, DateTime rd, int prd)
        {
            title = t;
            author = a;
            type = ty;
            status = s;
            returnDate = rd;
            pricePerDayOverduedInCents = prd;
        }

        public bool Equals(Book other)
        {
            return this.title == other.title && this.author == other.author;
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

    public enum BStatus
    {
        Available,
        Out
    }
}
