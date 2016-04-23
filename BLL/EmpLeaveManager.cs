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
    public class EmpLeaveManager
    {
        /// <summary>
        /// Retrieves EmpLeave List from Database.
        /// </summary>
        /// <param name="strWhere">Condition based on which List is retrieved.</param>
        /// <returns>EmpLeave List</returns>
        public static EmpLeavesList GetList(long EmpDBID)
        {
            return EmpLeaveDAL.GetList(EmpDBID);
        }

        /// <summary>
        /// Retrieves EmpLeave Data from Database.
        /// </summary>
        /// <param name="dbid">Unique ID based on which record will be fetched.</param>
        /// <returns>Object EmpLeave containing data Values.</returns>
        public static EmployeeLeave GetItem(long dbid)
        {
            return EmpLeaveDAL.GetItem(dbid);
        }

        /// <summary>
        /// Save Object Data into Database.
        /// </summary>
        /// <param name="objEmpLeave">EmpLeave Object containing property values.</param>
        /// <returns>EmpLeave Object to be Saved.</returns>
        public static bool Save(EmployeeLeave objEmpLeave)
        {
            bool flgSave;
            try
            {
                using (TransactionScope objTScope = new TransactionScope(TransactionScopeOption.RequiresNew))
                {
                    if (objEmpLeave.IsEdited || objEmpLeave.IsNew)
                    {
                        EmpLeaveDAL.Save(objEmpLeave);
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
        /// <param name="objEmpLeave">Object containing all data values.</param>
        /// <returns>boolean value True if Record is deleted successfully 
        /// otherwise returns False.</returns>
        public static bool Delete(EmployeeLeave objEmpLeave)
        {
            bool recDel;
            recDel = EmpLeaveDAL.Delete(objEmpLeave.DBID);
            return recDel;
        }

        /// <summary>
        /// Checks whether current Record already exists or not.
        /// </summary>
        /// <param name="objEmpLeave">Object containing all Data Values.</param>
        /// <returns>boolean value True if Record already Exists into Database
        /// otherwise returns False.</returns>
        public static bool IsEmpLeaveExist(EmployeeLeave objEmpLeave)
        {
            return EmpLeaveDAL.IsEmpLeaveExist(objEmpLeave);
        }
    }
}
