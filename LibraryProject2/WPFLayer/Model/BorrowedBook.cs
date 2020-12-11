using ServicesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
