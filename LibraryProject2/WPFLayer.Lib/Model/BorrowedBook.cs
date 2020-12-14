using Prism.Commands;
using ServicesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WPFLayer.Model
{
   public class BorrowedBook
    {

     
        public BorrowedBook(int _id)
        {
            ViewCommand = new DelegateCommand(ViewDetails);
            ReturnBookCommand = new DelegateCommand(ReturnBook);
            EditReturnDateCommand = new DelegateCommand(EditReturnDate);
          
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
        public ICommand ViewCommand
        {
            get;
            private set;
        }

        private void ViewDetails()
        {
          //  BorrowedBooksDetails borrowedBooksDetails = new BorrowedBooksDetails(this.BorrowedBookId);
          //  borrowedBooksDetails.Show();
        }

        public ICommand ReturnBookCommand
        {
            get;
            private set;
        }

        private void ReturnBook()
        {
            if (BorrowedBookCRUD.returnBook(BBookId) == true)
            {
              //  MessageBox.Show("Borrow record deleted\r\nCurrent customer funds: " + CustomerCRUD.getMoney(BCustomerId));
            }
           // else MessageBox.Show("Couldn't return book.");
        }

        public ICommand EditReturnDateCommand
        {
            get;
            private set;
        }

        private void EditReturnDate()
        {
           // EditReturnDateWindow editReturnDateWindow = new EditReturnDateWindow(this.BorrowedBookId);
           // editReturnDateWindow.Show();
        }
    }
}