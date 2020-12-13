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
    public class EditReturnDateViewModel : INotifyPropertyChanged, IDataErrorInfo
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
        string err = "Error:404";
        string IDataErrorInfo.Error => throw new NotImplementedException();

 
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
       // public string ErrorContent = "Please enter date with correct date format";

            /*get { return ErrorContent; }
            set
            {
                if(ErrorContent != value)
                {
                    ErrorContent = value;
                    OnPropertyChange("ErrorContent");
                }
            }*/
        
        string IDataErrorInfo.this[string columnName]
        {
            get
            {
                
                    DateTime date;
                   if (!DateTime.TryParse(this.BookReturnDate.ToString(), out date))
                   {
                         return "Please enter date with correct date format";
                    }
                

                return null;
            }
        }
    }
}
