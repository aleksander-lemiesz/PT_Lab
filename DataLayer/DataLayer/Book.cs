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

        private Type type;
        public Type Genre
        {
            get { return type; }
            set { type = value; }
        }

        private Status status;
        public Status Stat
        {
            get { return status; }
            set { status = value; }
        }

        private int returnDate;
        public int ReturnDate
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

        public Book(String t, String a, Type ty, Status s, int rd, int prd)
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

    public enum Type
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

    public enum Status
    {
        Available,
        Out
    }
}
