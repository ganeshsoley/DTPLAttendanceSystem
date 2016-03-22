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
    public class LeaveTypeManager
    {
        /// <summary>
        /// Retrieves LeaveType List from Database.
        /// </summary>
        /// <param name="strWhere">Condition based on which List is retrieved.</param>
        /// <returns>LeaveType List</returns>
        public static LeaveTypeList GetList(string strWhere)
        {
            return LeaveTypeDAL.GetList(strWhere);
        }

        /// <summary>
        /// Retrieves LeaveType Data from Database.
        /// </summary>
        /// <param name="dbid">Type Long Unique ID in table based on which record will be fetched.</param>
        /// <returns>LeaveType Object.</returns>
        public static LeaveType GetItem(long dbid)
        {
            return LeaveTypeDAL.GetItem(dbid);
        }

        /// <summary>
        /// Save Object Data into Database.
        /// </summary>
        /// <param name="objLeaveType">LeaveType Object containing property values.</param>
        /// <returns>Boolean value True if record is saved successfully otherwise returns
        /// false indicating record is not saved.</returns>
        public static bool Save(LeaveType objLeaveType)
        {
            bool flgSave;
            try
            {
                using (TransactionScope objTScope = new TransactionScope(TransactionScopeOption.RequiresNew))
                {
                    if (objLeaveType.IsEdited || objLeaveType.IsNew)
                    {
                        LeaveTypeDAL.Save(objLeaveType);
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
        /// <param name="objLeaveType">Object containing all data values.</param>
        /// <returns>boolean value True if Record is deleted successfully 
        /// otherwise returns False.</returns>
        public static bool Delete(LeaveType objLeaveType)
        {
            bool recDel;
            recDel = LeaveTypeDAL.Delete(objLeaveType.DBID);
            return recDel;
        }

        /// <summary>
        /// Checks whether current Record already exists or not.
        /// </summary>
        /// <param name="objLeaveType">Object containing all Data Values.</param>
        /// <returns>boolean value True if Record already Exists into Database
        /// otherwise returns False.</returns>
        public static bool IsLeaveTypeExist(LeaveType objLeaveType)
        {
            return LeaveTypeDAL.IsLeaveTypeExist(objLeaveType);
        }
    }
}
