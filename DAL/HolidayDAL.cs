using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityObject;

namespace DAL
{
    public class HolidayDAL
    {
        #region Private Method(s)
        /// <summary>
        /// Fills values fetched from Database to Object objHoliday.
        /// </summary>
        /// <param name="myDataRec">Record Object containing data values.</param>
        /// <returns>Returns object ObjHoliday containing Data values from Database.</returns>
        private static Holiday FillDataRecord(IDataRecord myDataRec)
        {
            Holiday objHoliday = new Holiday();
            objHoliday.IsLoading = true;

            objHoliday.DBID = Convert.ToInt32(myDataRec["DBID"]);
            objHoliday.HolidayDate = Convert.ToDateTime(myDataRec["HOLIDAYDATE"]);
            objHoliday.HolidayName = Convert.ToString(myDataRec["HOLIDAYNAME"]);
            if (!myDataRec.IsDBNull(myDataRec.GetOrdinal("DESCRIPTION")))
                objHoliday.Description = Convert.ToString(myDataRec["DESCRIPTION"]);
            objHoliday.ApplicableTo = Convert.ToString(myDataRec["APPLICABLETO"]);

            objHoliday.IsNew = false;
            objHoliday.IsEdited = false;
            objHoliday.IsDeleted = false;
            objHoliday.IsLoading = false;

            return objHoliday;
        }
        #endregion

        #region Public Method(s)
        /// <summary>
        /// This method retrieves "Holiday" Record, from Database.
        /// </summary>
        /// <param name="dbid">Unique ID value based on which Record will be fetched.</param>
        /// <returns>Object "Holiday" containing Data Values.</returns>
        public static Holiday GetItem(long dbid)
        {
            Holiday objHoliday = null;
            using (SqlConnection Conn = new SqlConnection(General.GetSQLConnectionString()))
            {
                using (SqlCommand objCmd = new SqlCommand())
                {
                    try
                    {
                        objCmd.Connection = Conn;
                        objCmd.CommandType = CommandType.Text;
                        objCmd.CommandText = "SELECT a.* " +
                            " FROM HOLIDAYMAST A " +
                            " WHERE a.DBID = @mDBID";
                        objCmd.Parameters.AddWithValue("@mDBID", dbid);

                        if (Conn.State != ConnectionState.Open)
                        {
                            Conn.Open();
                        }

                        SqlDataReader oReader = objCmd.ExecuteReader();
                        if (oReader.Read())
                        {
                            objHoliday = FillDataRecord(oReader);
                            objHoliday.IsNew = false;
                        }
                        oReader.Close();
                        oReader.Dispose();
                    }
                    catch
                    {
                        throw;
                    }
                }
            }
            return objHoliday;
        }

        /// <summary>
        /// This method provides List of Employees available in Database.
        /// </summary>
        /// <param name="strWhere">Specifies condition for retrieving records.</param>
        /// <returns>Collection of Employee Objects.</returns>
        public static HolidayList GetList(string strWhere)
        {
            HolidayList objList = null;
            string strSql = "SELECT A.* " +
                " FROM HOLIDAYMAST A " ;//(+)

            if (strWhere != string.Empty)
                strSql = strSql + " WHERE " + strWhere;
            strSql += " ORDER BY HOLIDAYDATE ";

            using (SqlConnection Conn = new SqlConnection(General.GetSQLConnectionString()))
            {
                using (SqlCommand objCmd = new SqlCommand())
                {
                    objCmd.Connection = Conn;
                    objCmd.CommandType = CommandType.Text;
                    objCmd.CommandText = strSql;

                    if (Conn.State != ConnectionState.Open)
                    {
                        Conn.Open();
                    }

                    using (SqlDataReader oReader = objCmd.ExecuteReader())
                    {
                        if (oReader.HasRows)
                        {
                            objList = new HolidayList();
                            while (oReader.Read())
                            {
                                objList.Add(FillDataRecord(oReader));
                            }
                        }
                        oReader.Close();
                        oReader.Dispose();
                    }
                }
            }
            return objList;
        }

        /// <summary>
        /// This method Saves Record into Database.
        /// </summary>
        /// <param name="objHoliday">Object containing Data values to be saved.</param>
        /// <returns>Boolean value True if Record is saved successfully
        /// otherwise returns False indicating Record is not saved.</returns>
        public static bool Save(Holiday objHoliday)
        {
            int result = 0;
            UserCompany CurrentCompany = new UserCompany();
            using (SqlConnection Conn = new SqlConnection(General.GetSQLConnectionString()))
            {
                string strSaveQry;
                if (objHoliday.IsNew)
                {
                    strSaveQry = "INSERT INTO HOLIDAYMAST(DBID, HolidayDate, HolidayName, Description, ApplicableTo, " +
                        " ST_DATE, MODIFY_DATE, CRBY, MODBY, MACHINENAME ) " +
                        " VALUES (@dbId, @HolidayDate, @HolidayName, @Description, @ApplicableTo, " +
                        " @STDate, @ModifyDate, @CrBy, @ModBy, @MachineName )";
                }
                else
                {
                    strSaveQry = "UPDATE HOLIDAYMAST " +
                        " SET HolidayDate = @HolidayDate, HolidayName = @HolidayName, " +
                        " Description = @Description, ApplicableTo = @ApplicableTo " +
                        " MODIFY_DATE = @ModifyDate, MODBY = @ModBy, MACHINENAME = @MachineName " +
                        " WHERE DBID = @dbId";
                }

                try
                {
                    SqlCommand objCmd = Conn.CreateCommand();
                    objCmd.CommandType = CommandType.Text;
                    objCmd.CommandText = strSaveQry;

                    objCmd.Parameters.AddWithValue("@HolidayDate", objHoliday.HolidayDate);
                    objCmd.Parameters.AddWithValue("@HolidayName", objHoliday.HolidayName);
                    objCmd.Parameters.AddWithValue("@Description", objHoliday.Description);
                    objCmd.Parameters.AddWithValue("@ApplicableTo", objHoliday.ApplicableTo);
                    
                    if (objHoliday.IsNew)
                    {
                        objCmd.Parameters.AddWithValue("@StDate", DateTime.Now);
                        objCmd.Parameters.AddWithValue("@CrBy", "");        //CurrentCompany.m_UserName
                        objHoliday.DBID = General.GenerateDBID("SEQHOLIDAYID", Conn);
                    }
                    objCmd.Parameters.AddWithValue("@ModifyDate", DateTime.Now);
                    objCmd.Parameters.AddWithValue("@ModBy", "");           //CurrentCompany.m_UserName
                    objCmd.Parameters.AddWithValue("@MachineName", General.GetMachineName());
                    objCmd.Parameters.AddWithValue("@dbID", objHoliday.DBID);

                    if (Conn.State != ConnectionState.Open)
                    {
                        Conn.Open();
                    }
                    result = objCmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return (result > 0);
        }

        /// <summary>
        /// This Method Deletes the record from Database based on ID Specified.
        /// </summary>
        /// <param name="id">Unique ID value for Record.</param>
        /// <returns>Boolean value True if record is Deleted successfully
        /// otherwise returns False indicating record is not Deleted.</returns>
        public static bool Delete(long id)
        {
            int result = 0;

            using (SqlConnection Conn = new SqlConnection(General.GetSQLConnectionString()))
            {
                SqlCommand ObjDelCmd = Conn.CreateCommand();
                ObjDelCmd.CommandType = CommandType.Text;
                ObjDelCmd.CommandText = "DELETE FROM HOLIDAYMAST WHERE DBID = @dbID";
                ObjDelCmd.Parameters.AddWithValue("@dbID", id);

                if (Conn.State != ConnectionState.Open)
                {
                    Conn.Open();
                }

                result = ObjDelCmd.ExecuteNonQuery();
                ObjDelCmd.Dispose();
            }
            return (result > 0);
        }

        /// <summary>
        /// This method Checks whether Current Holiday already exists in Database or not.
        /// </summary>
        /// <param name="objHoliday">Object Containing New Data Values.</param>
        /// <returns>Boolean value True if Current Record already exists
        /// otherwise returns False indicating current Record Does not exist.</returns>
        public static bool IsHolidayExist(Holiday objHoliday)
        {
            bool IsRecordExist = false;
            using (SqlConnection Conn = new SqlConnection(General.GetSQLConnectionString()))
            {
                try
                {
                    SqlCommand objCmd = Conn.CreateCommand();
                    objCmd.CommandType = CommandType.Text;
                    objCmd.CommandText = "SELECT DBID FROM HOLIDAYMAST " +
                        " WHERE HOLIDAYDATE = @mHolidayDate " +
                        " AND DBID <> @dbID ";

                    objCmd.Parameters.AddWithValue("@mHolidayDate", objHoliday.HolidayDate);
                    objCmd.Parameters.AddWithValue("@dbID", objHoliday.DBID);

                    if (Conn.State != ConnectionState.Open)
                    {
                        Conn.Open();
                    }

                    using (SqlDataReader objReader = objCmd.ExecuteReader())
                    {
                        if (objReader.HasRows)
                        {
                            while (objReader.Read())
                            {
                                IsRecordExist = true;
                            }
                        }
                        else
                        {
                            IsRecordExist = false;
                        }
                    }
                }
                catch (ApplicationException ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return IsRecordExist;
        }
        #endregion
    }
}
