using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFLayer.Model;

namespace WPFLayer.ViewModel
{
    public partial class ListsViewModel : INotifyPropertyChanged
    {
        BorrowedBook borrowed;

        public int BorrowedBookId
        {
            get { return borrowed.BorrowedBookId; }
            set
            {
                if (borrowed.BorrowedBookId != value)
                {
                    borrowed.BorrowedBookId = value;
                    OnPropertyChange("BorrowedBookId");
                    OnPropertyChange("BorrowedBookRecord");
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
                    OnPropertyChange("BorrowedBookRecord");
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
                    OnPropertyChange("BorrowedBookRecord");
                }
            }
        }
        public string BorrowedBookRecord
        {
            get { return BorrowedBookId + " " + BBookId + " " + BCustomerId; }
        }
    }
}
