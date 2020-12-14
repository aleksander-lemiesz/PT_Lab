using Prism.Commands;
using ServicesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPFLayer.Lib.ViewModel;

namespace WPFLayer.Model
{
   public class BorrowedBook
    {

     
        public BorrowedBook(int _id)
        {
           
            BorrowedBookId = _id;
            BCustomerId = BorrowedBookCRUD.getCustomerId(_id);
            BBookId = BorrowedBookCRUD.getBookId(_id);
        }

        public int BorrowedBookId { get; set; }
        public int BCustomerId { get; set; }
        public int BBookId { get; set; }
       

        public string BookInfo()
        {
            return "\r\nTitle: " + BookCRUD.getTitle(BBookId) + "\r\nAuthor: " + BookCRUD.getAuthor(BBookId) 
                + "\r\nType: " + BookCRUD.getType(BBookId) + "\r\nPenalty Cost: " + BookCRUD.getPenaltyCost(BBookId)
                + "\r\nReturn Date: " + BookCRUD.getReturnDate(BBookId);
        }
        public string CustomerInfo()
        {
            return "\r\nName: " + CustomerCRUD.getName(BCustomerId) + "\r\nMoney: " + CustomerCRUD.getMoney(BCustomerId);
        }
      
    }
}