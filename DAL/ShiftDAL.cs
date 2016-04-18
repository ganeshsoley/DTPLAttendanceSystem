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
    public class ShiftDAL
    {
        #region Private Method(s)
        /// <summary>
        /// Fills values fetched from Database to Object objShift.
        /// </summary>
        /// <param name="myDataRec">Record Object containing data values.</param>
        /// <returns>Returns object ObjShift containing Data values from Database.</returns>
        private static Shift FillDataRecord(IDataRecord myDataRec)
        {
            Shift objShift= new Shift();
            objShift.IsLoading = true;
            objShift.DBID = Convert.ToInt32(myDataRec["DBID"]);
            objShift.ShiftCode = Convert.ToString(myDataRec["SHIFT"]);
            objShift.ShiftName = Convert.ToString(myDataRec["SHIFTNAME"]);

            objShift.ShiftBeginTime = Convert.ToString(myDataRec["BEGINTIME"]);
            objShift.ShiftEndTime = Convert.ToString(myDataRec["ENDTIME"]);
            objShift.ShiftDuration = Convert.ToInt32(myDataRec["SHIFTDURATION"]);
            if (!myDataRec.IsDBNull(myDataRec.GetOrdinal("PUNCHBEGIN")))
                objShift.PunchBeginMins = Convert.ToInt32(myDataRec["PUNCHBEGIN"]);
            if (!myDataRec.IsDBNull(myDataRec.GetOrdinal("PUNCHEND")))
                objShift.PunchEndMins = Convert.ToInt32(myDataRec["PUNCHEND"]);
            objShift.IsGraceTimeApplicable = Convert.ToInt32(myDataRec["ISGRACETIMEAPPLICABLE"]);
            if (!myDataRec.IsDBNull(myDataRec.GetOrdinal("GRACETIME")))
                objShift.GraceTimeMins = Convert.ToString(myDataRec["GRACETIME"]);

            objShift.IsNew = false;
            objShift.IsEdited = false;
            objShift.IsDeleted = false;
            objShift.IsLoading = false;

            return objShift;
        }
        #endregion

        /// <summary>
        /// This method retrieves "Shift" Record, from Database.
        /// </summary>
        /// <param name="dbid">Unique ID value based on which Record will be fetched.</param>
        /// <returns>Object "Shift" containing Data Values.</returns>
        public static Shift GetItem(long dbid)
        {
            Shift objShift = null;
            using (SqlConnection Conn = new SqlConnection(General.GetSQLConnectionString()))
            {
                using (SqlCommand objCmd = new SqlCommand())
                {
                    try
                    {
                        objCmd.Connection = Conn;
                        objCmd.CommandType = CommandType.Text;
                        objCmd.CommandText = "SELECT a.* " +
                            " FROM SHIFTMAST a " +
                            " WHERE a.DBID = @mDBID";

                        objCmd.Parameters.AddWithValue("@mDBID", dbid);

                        if (Conn.State != ConnectionState.Open)
                        {
                            Conn.Open();
                        }

                        SqlDataReader oReader = objCmd.ExecuteReader();
                        if (oReader.Read())
                        {
                            objShift = FillDataRecord(oReader);
                            objShift.IsNew = false;
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
            return objShift;
        }

        /// <summary>
        /// This method provides List of Shifts available in Database.
        /// </summary>
        /// <param name="strWhere">Specifies condition for retrieving records.</param>
        /// <returns>Collection of Shift Objects.</returns>
        public static ShiftList GetList(string strWhere)
        {
            ShiftList objList = null;
            string strSql = "SELECT A.* " +
                " FROM ShiftMast A " ;

            if (strWhere != string.Empty)
                strSql = strSql + " WHERE " + strWhere;
            strSql += " ORDER BY SHIFT ";

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
                            objList = new ShiftList();
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
        /// <param name="objShift">Object containing Data values to be saved.</param>
        /// <returns>Boolean value True if Record is saved successfully
        /// otherwise returns False indicating Record is not saved.</returns>
        public static bool Save(Shift objShift)
        {
            int result = 0;
            UserCompany CurrentCompany = new UserCompany();
            using (SqlConnection Conn = new SqlConnection(General.GetSQLConnectionString()))
            {
                string strSaveQry;
                if (objShift.IsNew)
                {
                    strSaveQry = "INSERT INTO SHIFTMAST(DBID, Shift, ShiftName, BeginTime, EndTime, " +
                        " ShiftDuration, PunchBegin, PunchEnd, IsGraceTimeApplicable, GraceTime, " +
                        " ST_DATE, MODIFY_DATE, CRBY, MODBY, MACHINENAME) " +
                        " VALUES (@dbId, @Shift, @ShiftName, @BeginTime, @EndTime,  " +
                        " @ShiftDuration, @PunchBegin, @PunchEnd, @IsGraceTimeApplicable, @GraceTime, " +
                        " @STDate, @ModifyDate, @CrBy, @ModBy, @MachineName) ";
                }
                else
                {
                    strSaveQry = "UPDATE SHIFTMAST " +
                        " SET Shift = @Shift, ShiftName = @ShiftName, BeginTime = @BeginTime, " +
                        " EndTime = @EndTime, ShiftDuration = @ShiftDuration, PunchBegin = @PunchBegin, " +
                        " PunchEnd = @PunchEnd, IsGraceTimeApplicable = @IsGraceTimeApplicable, " +
                        " GraceTime = @GraceTime, " +
                        " MODIFY_DATE = @ModifyDate, MODBY = @ModBy, MACHINENAME = @MachineName " +
                        " WHERE DBID = @dbId";
                }

                try
                {
                    SqlCommand objCmd = Conn.CreateCommand();
                    objCmd.CommandType = CommandType.Text;
                    objCmd.CommandText = strSaveQry;

                    objCmd.Parameters.AddWithValue("@Shift", objShift.ShiftCode);
                    objCmd.Parameters.AddWithValue("@ShiftName", objShift.ShiftName);
                    objCmd.Parameters.AddWithValue("@BeginTime", objShift.ShiftBeginTime);
                    objCmd.Parameters.AddWithValue("@EndTime", objShift.ShiftEndTime);
                    objCmd.Parameters.AddWithValue("@ShiftDuration", objShift.ShiftDuration);
                    objCmd.Parameters.AddWithValue("@PunchBegin", objShift.PunchBeginMins);
                    objCmd.Parameters.AddWithValue("@PunchEnd", objShift.PunchEndMins);
                    objCmd.Parameters.AddWithValue("@IsGraceTimeApplicable", objShift.IsGraceTimeApplicable);
                    objCmd.Parameters.AddWithValue("@GraceTime", objShift.GraceTimeMins);

                    if (objShift.IsNew)
                    {
                        objCmd.Parameters.AddWithValue("@StDate", DateTime.Now);
                        objCmd.Parameters.AddWithValue("@CrBy", "" );       //CurrentCompany.m_UserName
                        //objEmp.DBID = General.GenerateDBID(Conn, "EMPMAST");
                        objShift.DBID = General.GenerateDBID("SEQSHIFTID", Conn);
                    }
                    objCmd.Parameters.AddWithValue("@ModifyDate", DateTime.Now);
                    objCmd.Parameters.AddWithValue("@ModBy", "");       //CurrentCompany.m_UserName
                    objCmd.Parameters.AddWithValue("@MachineName", General.GetMachineName());
                    objCmd.Parameters.AddWithValue("@dbID", objShift.DBID);

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
                ObjDelCmd.CommandText = "DELETE FROM SHIFTMAST WHERE DBID = @dbID";
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
        /// This method Checks whether Current Shift already exists in Database or not.
        /// </summary>
        /// <param name="objShift">Object Containing New Data Values.</param>
        /// <returns>Boolean value True if Current Record already exists
        /// otherwise returns False indicating current Record Does not exist.</returns>
        public static bool IsShiftExist(Shift objShift)
        {
            bool IsRecordExist = false;
            using (SqlConnection Conn = new SqlConnection(General.GetSQLConnectionString()))
            {
                try
                {
                    SqlCommand objCmd = Conn.CreateCommand();
                    objCmd.CommandType = CommandType.Text;
                    objCmd.CommandText = "SELECT DBID FROM SHIFTMAST " +
                        " WHERE SHIFT = @mShift " +
                        " AND DBID <> @dbID ";

                    objCmd.Parameters.AddWithValue("@mShift", objShift.ShiftCode);
                    objCmd.Parameters.AddWithValue("@dbID", objShift.DBID);

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
    }
}
