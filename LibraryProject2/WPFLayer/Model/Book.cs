using ServicesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFLayer.Model
{
    public class Book
    {

        public Book(int _id)
        {
            BookId = _id;
            Title = BookCRUD.getTitle(_id);
            Author = BookCRUD.getAuthor(_id);
            Type = BookCRUD.getType(_id);
            PenaltyCost = BookCRUD.getPenaltyCost(_id);
            ReturnDate = BookCRUD.getReturnDate(_id);
            State = BookCRUD.getState(_id);

        }
     
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Type { get; set; }
        public int PenaltyCost { get; set; }
        public DateTime ReturnDate { get; set; }
        public int State { get; set; }
    }
}

