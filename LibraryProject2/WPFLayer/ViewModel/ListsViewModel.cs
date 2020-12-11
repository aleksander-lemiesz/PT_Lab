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
        public ListsViewModel()
        {
            customer = new Customer(100);
            book = new Book(100);
            borrowed = new BorrowedBook(100);
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
