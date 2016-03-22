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
    public class ShiftManager
    {
        /// <summary>
        /// Retrieves Shift List from Database.
        /// </summary>
        /// <param name="strWhere">Condition based on which List is retrieved.</param>
        /// <returns>Employee List</returns>
        public static ShiftList GetList(string strWhere)
        {
            return ShiftDAL.GetList(strWhere);
        }

        /// <summary>
        /// Retrieves Shift Data from Database.
        /// </summary>
        /// <param name="dbid">Unique ID based on which record will be fetched.</param>
        /// <returns>Object Shift containing Data Values.</returns>
        public static Shift GetItem(long dbid)
        {
            return ShiftDAL.GetItem(dbid);
        }

        /// <summary>
        /// Save Object Data into Database.
        /// </summary>
        /// <param name="objShift">Shift Object containing property values.</param>
        /// <returns>Shift Object to be Saved.</returns>
        public static bool Save(Shift objShift)
        {
            bool flgSave;
            try
            {
                using (TransactionScope objTScope = new TransactionScope(TransactionScopeOption.RequiresNew))
                {
                    if (objShift.IsEdited || objShift.IsNew)
                    {
                        ShiftDAL.Save(objShift);
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
        /// <param name="objShift">Object containing all data values.</param>
        /// <returns>boolean value True if Record is deleted successfully 
        /// otherwise returns False.</returns>
        public static bool Delete(Shift objShift)
        {
            bool recDel;
            recDel = ShiftDAL.Delete(objShift.DBID);
            return recDel;
        }

        /// <summary>
        /// Checks whether current Record already exists or not.
        /// </summary>
        /// <param name="objShift">Object containing all Data Values.</param>
        /// <returns>boolean value True if Record already Exists into Database
        /// otherwise returns False.</returns>
        public static bool IsShiftExist(Shift objShift)
        {
            return ShiftDAL.IsShiftExist(objShift);
        }
    }
}
