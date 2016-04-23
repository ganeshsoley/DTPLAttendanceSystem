using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using System.Threading.Tasks;
using EntityObject;
using DAL;

namespace BLL
{
    public class EmployeeStatusManager
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static EmployeeStatusList GetList(string strWhere)
        {
            return EmployeeStatusDAL.GetList(strWhere);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbid"></param>
        /// <returns></returns>
        public static EmployeeStatus GetItem(int dbid)
        {
            return EmployeeStatusDAL.GetItem(dbid);
        }

        /// <summary>
        /// This Function Passes object objEmpStatus to DAL for saving changes into Database.
        /// </summary>
        /// <param name="objEmpStatus"></param>
        /// <returns>Boolean value true if record is saved successfully
        /// otherwise returns false indicating record is not saved.</returns>
        public static bool Save(EmployeeStatus objEmpStatus)
        {
            bool flgSave;
            try
            {
                using (TransactionScope objTScope = new TransactionScope(TransactionScopeOption.RequiresNew))
                {
                    if (objEmpStatus.IsEdited || objEmpStatus.IsNew)
                    {
                        EmployeeStatusDAL.Save(objEmpStatus);
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
        /// <param name="objEmployeeStatus">Object containing all data values.</param>
        /// <returns>boolean value True if Record is deleted successfully 
        /// otherwise returns False.</returns>
        public static bool Delete(EmployeeStatus objEmpStatus)
        {
            bool recDel;
            recDel = EmployeeStatusDAL.Delete(objEmpStatus.DBID);
            return recDel;
        }

        /// <summary>
        /// Checks whether current Record already exists or not.
        /// </summary>
        /// <param name="objEmpStatus">Object containing all Data Values.</param>
        /// <returns>boolean value True if Record already Exists into Database
        /// otherwise returns False.</returns>
        public static bool IsEmpStatusExist(EmployeeStatus objEmpStatus)
        {
            return EmployeeStatusDAL.IsEmployeeStatusExist(objEmpStatus);
        }
    }
}
