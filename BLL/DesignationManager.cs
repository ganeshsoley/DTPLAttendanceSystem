using System;
using System.Transactions;
using EntityObject;
using DAL;

namespace BLL
{
    public class DesignationManager
    {
        /// <summary>
        /// Retrieves Designation List from Database.
        /// </summary>
        /// <param name="strWhere">Condition based on which List is retrieved.</param>
        /// <returns>Designation List</returns>
        public static DesignationList GetList(string strWhere)
        {
            return DesignationDAL.GetList(strWhere);
        }

        /// <summary>
        /// Retrieves Designation Data from Database.
        /// </summary>
        /// <param name="dbid"></param>
        /// <returns></returns>
        public static Designation GetItem(long dbid)
        {
            return DesignationDAL.GetItem(dbid);
        }

        /// <summary>
        /// Save Object Data into Database.
        /// </summary>
        /// <param name="objDesig">Designation Object containing property values.</param>
        /// <returns>Designation Object to be Saved.</returns>
        public static bool Save(Designation objDesig)
        {
            bool flgSave;
            try
            {
                using (TransactionScope objTScope = new TransactionScope(TransactionScopeOption.RequiresNew))
                {
                    if (objDesig.IsEdited || objDesig.IsNew)
                    {
                        DesignationDAL.Save(objDesig);
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
        /// <param name="objDesig">Object containing all data values.</param>
        /// <returns>boolean value True if Record is deleted successfully 
        /// otherwise returns False.</returns>
        public static bool Delete(Designation objDesig)
        {
            bool recDel;
            recDel = DesignationDAL.Delete(objDesig.DBID);
            return recDel;
        }

        /// <summary>
        /// Checks whether current Record already exists or not.
        /// </summary>
        /// <param name="objDesig">Object containing all Data Values.</param>
        /// <returns>boolean value True if Record already Exists into Database
        /// otherwise returns False.</returns>
        public static bool IsDesignationExist(Designation objDesig)
        {
            return DesignationDAL.IsDesignationExist(objDesig);
        }

        /// <summary>
        /// Checks whether current Record is used or Not.
        /// </summary>
        /// <param name="objDesig">Object containing all Data Values.</param>
        /// <returns>boolean value True if Record is used in another Different
        /// otherwise returns False.</returns>
        public static bool IsDesignationUsed(Designation objDesig)
        {
            return DesignationDAL.IsDesignationUsed(objDesig.DBID);
        }
    }
}
