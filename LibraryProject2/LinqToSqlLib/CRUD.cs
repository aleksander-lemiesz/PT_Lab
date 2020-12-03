using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
namespace LinqToSqlLib
{
    public class CURD
    {
        //Insert method  
        public void Insert(string data)
        {
            LINQToSQLDataContext dataObject = new LINQToSQLDataContext();
            dataObject.TPG_TeamDetails.InsertOnSubmit(
                           new Customers
                           {
                               id = 100,
                               name = "John Smith",
                               money = 100
                           }) ;
            dataObject.SubmitChanges();
        }

        // Delete method  
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
    }

    public class UserData
    {
        public int UserID { get; set; }
    }
}
