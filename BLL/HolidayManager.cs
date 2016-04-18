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
    public class HolidayManager
    {
        /// <summary>
        /// Retrieves Holiday List from Database.
        /// </summary>
        /// <param name="strWhere">Condition based on which List is retrieved.</param>
        /// <returns>Holiday List</returns>
        public static HolidayList GetList(string strWhere)
        {
            return HolidayDAL.GetList(strWhere);
        }

        /// <summary>
        /// Retrieves Holiday Data from Database.
        /// </summary>
        /// <param name="dbid">Unique ID based on which record will be fetched.</param>
        /// <returns>Object Holiday containing data Values.</returns>
        public static Holiday GetItem(long dbid)
        {
            return HolidayDAL.GetItem(dbid);
        }

        /// <summary>
        /// Save Object Data into Database.
        /// </summary>
        /// <param name="objHoliday">Holiday Object containing property values.</param>
        /// <returns>Holiday Object to be Saved.</returns>
        public static bool Save(Holiday objHoliday)
        {
            bool flgSave;
            try
            {
                using (TransactionScope objTScope = new TransactionScope(TransactionScopeOption.RequiresNew))
                {
                    if (objHoliday.IsEdited || objHoliday.IsNew)
                    {
                        HolidayDAL.Save(objHoliday);
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
        /// <param name="objHoliday">Object containing all data values.</param>
        /// <returns>boolean value True if Record is deleted successfully 
        /// otherwise returns False.</returns>
        public static bool Delete(Holiday objHoliday)
        {
            bool recDel;
            recDel = HolidayDAL.Delete(objHoliday.DBID);
            return recDel;
        }

        /// <summary>
        /// Checks whether current Record already exists or not.
        /// </summary>
        /// <param name="objHoliday">Object containing all Data Values.</param>
        /// <returns>boolean value True if Record already Exists into Database
        /// otherwise returns False.</returns>
        public static bool IsHolidayExist(Holiday objHoliday)
        {
            return HolidayDAL.IsHolidayExist(objHoliday);
        }

        
    }
}
