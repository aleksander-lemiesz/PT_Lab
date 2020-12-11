using ServicesLayer;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Text;

namespace PresentationLayer.Model
{
    public sealed class Book
    {
        
       public Book(int _id)
        {
            Title = BookCRUD.getTitle(_id);

        }
        public Book(int _id, string _title/*, string _author, string _type, int _penaltyCost, DateTime _returnDate, int _state*/) 
        {
            Id = _id;
            Title = _title;
           /* Author = _author;
            Type = _type;
            PenaltyCost = _penaltyCost;
            ReturnDate = _returnDate;
            State = _state;*/
        }
        public int Id { get; set; }
        public string Title { get; set; }
       /* public string Author { get; set; }
        public string Type { get; set; }
        public int PenaltyCost { get; set; }
        public DateTime ReturnDate { get; set; }
        public int State { get; set; }*/
    }
}
