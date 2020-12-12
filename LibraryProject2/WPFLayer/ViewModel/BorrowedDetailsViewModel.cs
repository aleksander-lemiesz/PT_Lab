using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFLayer.Model;

namespace WPFLayer.ViewModel
{
    public class BorrowedDetailsViewModel : INotifyPropertyChanged
    {
        BorrowedBook borrowed;
        public string BookInfo
        {
            get { return borrowed.BookInfo(); }
           
        }
        public string CustomerInfo
        {
            get { return borrowed.CustomerInfo(); }

        }

        public BorrowedDetailsViewModel(int _id)
        {
           
           borrowed = new BorrowedBook(_id);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChange(string v)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(v));
            }
        }
    }
}
