using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using EntityObject;
using DAL;

namespace BLL
{
    public class DailyAttManager
    {
        /// <summary>
        /// Retrieves Attendance List from Database.
        /// </summary>
        /// <param name="strWhere">Condition based on which List is retrieved.</param>
        /// <returns>Attendance List</returns>
        public static DailyAttendanceList GetList(string strWhere, string strFromDate, string strToDate)
        {
            return DailyAttendanceDAL.GetList(strWhere, strFromDate, strToDate);
        }

        /// <summary>
        /// Retrieves DailyAttendance Data from Database.
        /// </summary>
        /// <param name="dbid">Unique ID based on which record will be fetched.</param>
        /// <returns>Object Daily Attendance containing data Values.</returns>
        public static DailyAttendance GetItem(long dbid)
        {
            return DailyAttendanceDAL.GetItem(dbid);
        }

        /// <summary>
        /// Save Object Data into Database.
        /// </summary>
        /// <param name="objDailyAtt">DailyAtt Object containing property values.</param>
        /// <returns>Boolean Value true if record is saved successfully
        /// otherwise returns false indicating record is not saved.</returns>
        public static bool Save(DailyAttendance objDailyAtt)
        {
            bool flgSave;
            try
            {
                using (TransactionScope objTScope = new TransactionScope(TransactionScopeOption.RequiresNew))
                {
                    if (objDailyAtt.IsEdited || objDailyAtt.IsNew)
                    {
                        DailyAttendanceDAL.Save(objDailyAtt);
                    }
                    flgSave = true;
                    objTScope.Complete();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return flgSave;
        }

        /// <summary>
        /// Deletes Record from Database.
        /// </summary>
        /// <param name="objDailyAtt">Object containing all data values.</param>
        /// <returns>boolean value True if Record is deleted successfully 
        /// otherwise returns False.</returns>
        public static bool Delete(DailyAttendance objDailyAtt)
        {
            bool recDel;
            recDel = DailyAttendanceDAL.Delete(objDailyAtt.DBID);
            return recDel;
        }

        /// <summary>
        /// Checks whether current Record already exists or not.
        /// </summary>
        /// <param name="objDailyAtt">Object containing all Data Values.</param>
        /// <returns>boolean value True if Record already Exists into Database
        /// otherwise returns False.</returns>
        public static bool IsDailyAttExist(DailyAttendance objDailyAtt)
        {
            return DailyAttendanceDAL.IsDailyAttExist(objDailyAtt);
        }
    }
}
