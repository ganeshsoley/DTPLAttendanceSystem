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
    public class LeaveApplicationManager
    {
        /// <summary>
        /// Retrieves LeaveApplication List from Database.
        /// </summary>
        /// <param name="strWhere">Condition based on which List is retrieved.</param>
        /// <returns>LeaveApplication List</returns>
        public static LeaveApplicationList GetList(string strWhere)
        {
            return LeaveApplicationDAL.GetList(strWhere);
        }

        /// <summary>
        /// Retrieves LeaveApplication Data from Database.
        /// </summary>
        /// <param name="dbid">Unique ID based on which record will be fetched.</param>
        /// <returns>Object LeaveApplication containing data Values.</returns>
        public static LeaveApplication GetItem(long dbid)
        {
            return LeaveApplicationDAL.GetItem(dbid);
        }

        /// <summary>
        /// Save Object Data into Database.
        /// </summary>
        /// <param name="objLvApplication">LeaveApplication Object containing property values.</param>
        /// <returns>boolean value true if record is saved successfully otherwise
        /// returns false indicating Object to be Saved.</returns>
        public static bool Save(LeaveApplication objLvApplication)
        {
            bool flgSave;
            try
            {
                using (TransactionScope objTScope = new TransactionScope(TransactionScopeOption.RequiresNew))
                {
                    if (objLvApplication.IsEdited || objLvApplication.IsNew)
                    {
                        LeaveApplicationDAL.Save(objLvApplication);
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
        /// <param name="objLvApplication">Object containing all data values.</param>
        /// <returns>boolean value True if Record is deleted successfully 
        /// otherwise returns False.</returns>
        public static bool Delete(LeaveApplication objLvApplication)
        {
            bool recDel;
            recDel = LeaveApplicationDAL.Delete(objLvApplication.DBID);
            return recDel;
        }

        /// <summary>
        /// Checks whether current Record already exists or not.
        /// </summary>
        /// <param name="objLeaveApplication">Object containing all Data Values.</param>
        /// <returns>boolean value True if Record already Exists into Database
        /// otherwise returns False.</returns>
        public static bool IsLeaveApplicationExist(LeaveApplication objLvApplication)
        {
            return LeaveApplicationDAL.IsLvApplicationExist(objLvApplication);
        }
    }
}
