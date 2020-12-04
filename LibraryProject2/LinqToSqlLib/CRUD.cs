/*using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
namespace LinqToSqlLib
{
    public class CRUD
    {
        //Insert method  
        public void Insert(int _id, string _name, int _money)
        {
            LibraryDataContext dataObject = new LibraryDataContext();
            dataObject.Customers.InsertOnSubmit(
                           new Customers
                           {
                               id = _id,
                               name = _name,
                               money = _money
                           });
            dataObject.SubmitChanges();
        }

        */
/* // Delete method  
         public void Delete(int teamMemberID)
         {
             LINQToSQLDataContext dataObject = new LINQToSQLDataContext();
             TPG_TeamDetail TPG_TeamDetailDO =
                       dataObject.TPG_TeamDetails.Where(p => p.TeamMemberID == teamMemberID).First();
             dataObject.TPG_TeamDetails.DeleteOnSubmit(TPG_TeamDetailDO);
             dataObject.SubmitChanges();
         }

         // Select method  
         public List<UserData> Select()
         {
             LINQToSQLDataContext dataObject = new LINQToSQLDataContext();
             return
            (from s in dataObject.TPG_TeamDetails
             select new UserData { UserID = s.UserID }
             ).ToList<UserData>();

         }

         // Update method  
         public void Update(int teamMemberID, int internalProjectID, int userID)
         {
             LINQToSQLDataContext dataObject = new LINQToSQLDataContext();
             TPG_TeamDetail teamDetailDO =
              dataObject.TPG_TeamDetails.Where(p => p.TeamMemberID == teamMemberID).First();
             teamDetailDO.InternalProjectID = internalProjectID;
             teamDetailDO.UserID = userID;
             dataObject.SubmitChanges();
         }
     }*//*
    }
    public class UserData
    {
        public int UserID { get; set; }
    }
}
*/


/*********************************************************************
 * A LINQ Tutorial: WPF Data Binding with LINQ to SQL
 * By: Abby Fichtner, http://www.TheHackerChickBlog.com
 * Article URL: http://www.codeproject.com/KB/linq/linqtutorial3.aspx
 * Licensed under The Code Project Open License (CPOL)
 *********************************************************************/

using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;

namespace LinqToSqlLib

{
#pragma warning disable 0169, 0649        // disable never used/assigned warnings for fields that are being used by LINQ

    [Database(Name = "Database")]
    public class CRUD: DataContext
    {
        private static DataContext contextForRemovedRecords = null;

        public CRUD( ) : base("Database.mdf") { }
        public Table<Customers> customers;
        public Table<Books> books;
        public Table<BorrowedBooks> borrowedBooks;
        public Table<Catalog> catalogedBooks;

        public static void RemoveRecord<T>(T recordToRemove) where T : class
        {
            if (contextForRemovedRecords == null)
                contextForRemovedRecords = new CRUD();

            Table<T> tableData = contextForRemovedRecords.GetTable<T>();
            var deleteRecord = tableData.SingleOrDefault(record => record == recordToRemove);
            if (deleteRecord != null)
            {
                tableData.DeleteOnSubmit(deleteRecord);
            }
        }

        public void CancelChanges()
        {
            if (contextForRemovedRecords != null)
            {
                contextForRemovedRecords = null;
            }
        }

        public new void SubmitChanges()
        {
            if (contextForRemovedRecords != null)
            {
                contextForRemovedRecords.SubmitChanges();
            }
            base.SubmitChanges();
        }
    }
}
