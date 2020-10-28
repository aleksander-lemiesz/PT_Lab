using System;

namespace DataLayer
{
    public class Book : IEquatable<Book>
    {
        private String title { get; }
        private String author { get; }
        private Type type { get; }
        private Status status { get; set; }
        private int returnDate { get; set; }
        private int pricePerDayOverduedInCents { get; set; }

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
