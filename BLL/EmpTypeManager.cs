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
    public class EmpTypeManager
    {
        /// <summary>
        /// Retrieves Employee-Type List from Database.
        /// </summary>
        /// <param name="strWhere">Condition based on which List is retrieved.</param>
        /// <returns>Employee-Type List</returns>
        public static EmpTypeList GetList(string strWhere)
        {
            return EmpTypeDAL.GetList(strWhere);
        }

        /// <summary>
        /// Retrieves Employee-Type Data from Database.
        /// </summary>
        /// <param name="dbid"></param>
        /// <returns></returns>
        public static EmpType GetItem(long dbid)
        {
            return EmpTypeDAL.GetItem(dbid);
        }

        /// <summary>
        /// Save Object Data into Database.
        /// </summary>
        /// <param name="objEmpType">Employee-Type Object containing property values.</param>
        /// <returns>Employee-Type Object to be Saved.</returns>
        public static bool Save(EmpType objEmpType)
        {
            bool flgSave;
            try
            {
                using (TransactionScope objTScope = new TransactionScope(TransactionScopeOption.RequiresNew))
                {
                    if (objEmpType.IsEdited || objEmpType.IsNew)
                    {
                        EmpTypeDAL.Save(objEmpType);
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
        /// <param name="objEmpType">Object containing all data values.</param>
        /// <returns>boolean value True if Record is deleted successfully 
        /// otherwise returns False.</returns>
        public static bool Delete(EmpType objEmpType)
        {
            bool recDel;
            recDel = EmpTypeDAL.Delete(objEmpType.DBID);
            return recDel;
        }

        /// <summary>
        /// Checks whether current Record already exists or not.
        /// </summary>
        /// <param name="objEmpType">Object containing all Data Values.</param>
        /// <returns>boolean value True if Record already Exists into Database
        /// otherwise returns False.</returns>
        public static bool IsEmpTypeExist(EmpType objEmpType)
        {
            return EmpTypeDAL.IsEmpTypeExist(objEmpType);
        }

        /// <summary>
        /// Checks whether current Record already Used with Employee or not.
        /// </summary>
        /// <param name="dbid">Unique ID of the record to be Checked whether it is used or not.</param>
        /// <returns>boolean value True if Record already Exists into Database
        /// otherwise returns False.</returns>
        public static bool IsEmpTypeUsed(long dbid)
        {
            return EmpTypeDAL.IsEmpTypeUsed(dbid);
        }
    }
}
