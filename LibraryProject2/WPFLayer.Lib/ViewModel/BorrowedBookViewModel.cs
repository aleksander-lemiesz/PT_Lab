﻿using ServicesLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFLayer.Model;

namespace WPFLayer.ViewModel
{
    public partial class ListsViewModel : INotifyPropertyChanged
    {
        private BorrowedBook borrowed;
        private ObservableCollection<BorrowedBook> borroweds;
        public BorrowedBook bb
        {
            get { return borrowed; }
            set
            {
                if (borrowed != value)
                {
                    borrowed = value;
                    OnPropertyChange("bb");
                }
            }
        }
        public int BorrowedBookId
        {
            get { return borrowed.BorrowedBookId; }
            set
            {
                if (borrowed.BorrowedBookId != value)
                {
                    borrowed.BorrowedBookId = value;
                    OnPropertyChange("BorrowedBookId");
                }
            }
        }
        public int BBookId
        {
            get { return borrowed.BBookId; }
            set
            {
                if (borrowed.BBookId != value)
                {
                    borrowed.BBookId = value;
                    OnPropertyChange("BBookId");
                }
            }
        }
        public int BCustomerId
        {
            get { return borrowed.BCustomerId; }
            set
            {
                if (borrowed.BCustomerId != value)
                {
                    borrowed.BCustomerId = value;
                    OnPropertyChange("BCustomerId");
                }
            }
        }

        public ObservableCollection<BorrowedBook> BorrowedBooks
        {
            get { return GetBorrowedBooks(); }
            set
            {
                for (int i = 0; i < Customers.Count; i++)
                {
                    if (BorrowedBooks[i] != value[i])
                    {
                        BorrowedBooks[i] = value[i];
                       // BorrowedBookCRUD.returnBook(BorrowedBooks[i].BBookId);
                        OnPropertyChange("BorrowedBooks");
                    }
                }

            }
        }
    }
}
