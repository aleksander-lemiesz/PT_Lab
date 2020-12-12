﻿using Prism.Commands;
using ServicesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFLayer.View;

namespace WPFLayer.Model
{
   public class BorrowedBook
    {

     
        public BorrowedBook(int _id)
        {
            ViewCommand = new DelegateCommand(ViewDetails);
          
            BorrowedBookId = _id;
            BCustomerId = BorrowedBookCRUD.getCustomerId(_id);
            BBookId = BorrowedBookCRUD.getBookId(_id);
        }

        public int BorrowedBookId { get; set; }
        public int BCustomerId { get; set; }
        public int BBookId { get; set; }

        public string BookInfo()
        {
            return "Title: " + BookCRUD.getTitle(BBookId) + " Author: " + BookCRUD.getAuthor(BBookId) 
                + "\r\nType: " + BookCRUD.getType(BBookId) + " PenaltyCost: " + BookCRUD.getPenaltyCost(BBookId);
        }
        public string CustomerInfo()
        {
            return "Name: " + CustomerCRUD.getName(BCustomerId) + " Money: " + CustomerCRUD.getMoney(BCustomerId);
        }
        public ICommand ViewCommand
        {
            get;
            private set;
        }

        private void ViewDetails()
        {
            BorrowedBooksDetails borrowedBooksDetails = new BorrowedBooksDetails(this.BorrowedBookId);
            borrowedBooksDetails.Show();
        }

      

    }
}
