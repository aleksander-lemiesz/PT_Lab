using ServicesLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFLayer.Model;

namespace WPFLayer.ViewModel
{
    public class EditReturnDateViewModel : INotifyPropertyChanged
    {
        BorrowedBook borrowed;
        Book book;
        public DateTime BookReturnDate
        {
            get { return BookCRUD.getReturnDate(borrowed.BBookId); }
            set
            {
                if (BookCRUD.getReturnDate(borrowed.BBookId) != value)
                {
                    BookCRUD.updateReturnDate(borrowed.BBookId, value);
                    OnPropertyChange("BookReturnDate");
                }
            }
        }
        
        public EditReturnDateViewModel(int _id)
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
