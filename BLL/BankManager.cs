using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using System.Threading.Tasks;
using DAL;
using EntityObject;

namespace BLL
{
    public class BankManager
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static BankList GetList(string strWhere)
        {
            return BankDAL.GetList(strWhere);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbid"></param>
        /// <returns></returns>
        public static Bank GetItem(int dbid)
        {
            return BankDAL.GetItem(dbid);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objBank"></param>
        /// <returns></returns>
        public static bool Save(Bank objBank)
        {
            bool flgSave;
            try
            {
                using (TransactionScope objTScope = new TransactionScope(TransactionScopeOption.RequiresNew))
                {
                    if (objBank.IsEdited || objBank.IsNew)
                    {
                        BankDAL.Save(objBank);
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
        /// <param name="objBank">Object containing all data values.</param>
        /// <returns>boolean value True if Record is deleted successfully 
        /// otherwise returns False.</returns>
        public static bool Delete(Bank objBank)
        {
            bool recDel;
            recDel = BankDAL.Delete(objBank.DBID);
            return recDel;
        }

        /// <summary>
        /// Checks whether current Record already exists or not.
        /// </summary>
        /// <param name="objBank">Object containing all Data Values.</param>
        /// <returns>boolean value True if Record already Exists into Database
        /// otherwise returns False.</returns>
        public static bool IsBankExist(Bank objBank)
        {
            return BankDAL.IsBankExist(objBank);
        }
    }
}
