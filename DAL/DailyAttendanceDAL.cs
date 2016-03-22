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
    public class DailyAttendanceDAL
    {
        #region Private Method(s)
        /// <summary>
        /// Fills values fetched from Database to Object objDailyAtt.
        /// </summary>
        /// <param name="myDataRec">Record Object containing data values.</param>
        /// <returns>Returns object ObjDailyAtt containing Data values from Database.</returns>
        private static DailyAttendance FillDataRecord(IDataRecord myDataRec)
        {
            DailyAttendance objDailyAtt= new DailyAttendance();
            objDailyAtt.IsLoading = true;

            objDailyAtt.DBID = Convert.ToInt32(myDataRec["DBID"]);
            objDailyAtt.AttDate = Convert.ToDateTime(myDataRec["ATTDATE"]);
            objDailyAtt.EmpID = Convert.ToInt32(myDataRec["EMPLOYEEID"]);
            if (!myDataRec.IsDBNull(myDataRec.GetOrdinal("EMPNAME")))
                objDailyAtt.EmpName = Convert.ToString(myDataRec["EMPNAME"]);
            if (!myDataRec.IsDBNull(myDataRec.GetOrdinal("EMPDEPT")))
                objDailyAtt.EmpDept= Convert.ToString(myDataRec["EMPDEPT"]);
            objDailyAtt.InTime = Convert.ToString(myDataRec["INTIME"]);
            objDailyAtt.OutTime = Convert.ToString(myDataRec["OUTTIME"]);
            objDailyAtt.Duration = Convert.ToSingle(myDataRec["DURATION"]);
            objDailyAtt.LateByMins = Convert.ToInt32(myDataRec["LATEBY"]);
            objDailyAtt.EarlyByMins = Convert.ToInt32(myDataRec["EARLYBY"]);
            objDailyAtt.IsWeeklyOff = Convert.ToInt32(myDataRec["ISWEEKLYOFF"]);
            objDailyAtt.IsHoliday = Convert.ToInt32(myDataRec["ISHOLIDAY"]);
            objDailyAtt.IsOnLeave = Convert.ToInt32(myDataRec["ISONLEAVE"]);
            objDailyAtt.LeaveTypeID = Convert.ToInt32(myDataRec["LEAVETYPEID"]);
            if (!myDataRec.IsDBNull(myDataRec.GetOrdinal("LEAVETYPE")))
                objDailyAtt.LeaveType = Convert.ToString(myDataRec["LEAVETYPE"]);
            objDailyAtt.ShiftID = Convert.ToInt32(myDataRec["SHIFTID"]);
            objDailyAtt.ShiftCode = Convert.ToString(myDataRec["SHIFTCODE"]);
            objDailyAtt.ShiftBeginTime = Convert.ToString(myDataRec["SHIFTBEGINTIME"]);
            objDailyAtt.ShiftEndTime = Convert.ToString(myDataRec["SHIFTENDTIME"]);
            objDailyAtt.Present = Convert.ToSingle(myDataRec["PRESENT"]);
            objDailyAtt.Absent = Convert.ToSingle(myDataRec["ABSENT"]);
            objDailyAtt.IsOnSpecialOff = Convert.ToInt16(myDataRec["ISONSPECIALOFF"]);
            if (!myDataRec.IsDBNull(myDataRec.GetOrdinal("SPECIALOFFTYPE")))
                objDailyAtt.SpecialOffType = Convert.ToString(myDataRec["SPECIALOFFTYPE"]);

            objDailyAtt.IsNew = false;
            objDailyAtt.IsEdited = false;
            objDailyAtt.IsDeleted = false;
            objDailyAtt.IsLoading = false;

            return objDailyAtt;
        }
        #endregion

        /// <summary>
        /// This method retrieves "DailyAttendance" Record, from Database.
        /// </summary>
        /// <param name="dbid">Unique ID value based on which Record will be fetched.</param>
        /// <returns>Object "DailyAttendance" containing Data Values.</returns>
        public static DailyAttendance GetItem(long dbid)
        {
            DailyAttendance objDailyAtt = null;
            using (SqlConnection Conn = new SqlConnection(General.GetSQLConnectionString()))
            {
                using (SqlCommand objCmd = new SqlCommand())
                {
                    try
                    {
                        objCmd.Connection = Conn;
                        objCmd.CommandType = CommandType.Text;
                        objCmd.CommandText = "SELECT a.*, B.INITIALS EMPNAME, C.SHIFT SHIFTCODE, D.LEAVETYPE " +
                            " FROM EMPDAILYATTENDANCE A, EMPMAST B, SHIFTMAST C, LEAVETYPEMAST D " +
                            " WHERE A.EMPLOYEEID = B.DBID " +
                            " AND A.SHIFTID = C.DBID " + 
                            " AND A.LEAVETYPEID = D.DBID " +
                            " AND a.DBID = @mDBID";
                        objCmd.Parameters.AddWithValue("@mDBID", dbid);

                        if (Conn.State != ConnectionState.Open)
                        {
                            Conn.Open();
                        }

                        SqlDataReader oReader = objCmd.ExecuteReader();
                        if (oReader.Read())
                        {
                            objDailyAtt = FillDataRecord(oReader);
                            objDailyAtt.IsNew = false;
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
            return objDailyAtt;
        }

        /// <summary>
        /// This method provides List of DailyAttendance available in Database.
        /// </summary>
        /// <param name="strWhere">Specifies condition for retrieving records.</param>
        /// <returns>Collection of DailyAttendance Objects.</returns>
        public static DailyAttendanceList GetList(string strWhere, string strFromDate, string strToDate)
        {
            DailyAttendanceList objList = null;
            string strSql = "SELECT a.*, B.INITIALS EMPNAME, C.SHIFT SHIFTCODE, D.LEAVETYPE " +
                " FROM EMPDAILYATTENDANCE A, EMPMAST B, SHIFTMAST C, LEAVETYPEMAST D " +
                " WHERE A.EMPLOYEEID = B.DBID " +
                " AND A.SHIFTID = C.DBID " +
                " AND A.LEAVETYPEID = D.DBID " +
                " and A.ATTDATE BETWEEN @FromDate AND @ToDate ";

            if (strWhere != string.Empty)
                strSql = strSql + " AND @Where ";
            strSql += " ORDER BY ATTDATE, SHIFTCODE, EMPNAME ";

            using (SqlConnection Conn = new SqlConnection(General.GetSQLConnectionString()))
            {
                using (SqlCommand objCmd = new SqlCommand())
                {
                    objCmd.Connection = Conn;
                    objCmd.CommandType = CommandType.Text;
                    objCmd.CommandText = strSql;

                    objCmd.Parameters.AddWithValue("@FromDate", strFromDate);
                    objCmd.Parameters.AddWithValue("@ToDate", strToDate);
                    if (strWhere != string.Empty)
                        objCmd.Parameters.AddWithValue("@Where", strWhere);

                    if (Conn.State != ConnectionState.Open)
                    {
                        Conn.Open();
                    }

                    using (SqlDataReader oReader = objCmd.ExecuteReader())
                    {
                        if (oReader.HasRows)
                        {
                            objList = new DailyAttendanceList();
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
        /// <param name="objDailyAtt">Object containing Data values to be saved.</param>
        /// <returns>Boolean value True if Record is saved successfully
        /// otherwise returns False indicating Record is not saved.</returns>
        public static bool Save(DailyAttendance objDailyAtt)
        {
            int result = 0;
            UserCompany CurrentCompany = new UserCompany();
            using (SqlConnection Conn = new SqlConnection(General.GetSQLConnectionString()))
            {
                string strSaveQry;
                if (objDailyAtt.IsNew)
                {
                    strSaveQry = "INSERT INTO EMPDAILYATTENDANCE(DBID, ATTDate, EMPLOYEEID, INTIME, OUTTIME, " +
                        " DURATION, LATEBY, EARLYBY, ISWEEKLYOFF, ISHOLIDAY, ISONLEAVE, LEAVETYPEID," +
                        " SHIFTID, PRESENT, ABSENT, ISONSPECIALOFF, SPECIALOFFTYPE, " +
                        " ST_DATE, MODIFY_DATE, CRBY, MODBY, MACHINENAME) " +
                        " VALUES (@dbId, @AttDate, @EmpID, @InTime, @OutTime, " +
                        " @Duration, @LateBy, @EarlyBy, @IsWeeklyOff, @IsHoliday, @IsOnLeave, @LeaveTypeID," +
                        " @ShiftID, @Present, @Absent, @IsOnSpecialOff, @SpecialOffType, " +
                        " @STDate, @ModifyDate, @CrBy, @ModBy, @MachineName)";
                }
                else
                {
                    strSaveQry = "UPDATE EMPDAILYATTENDANCE " +
                        " SET ATTDate = @AttDate, EMPLOYEEID = @EmpID, INTIME = @InTime, OUTTIME = @OutTime, " +
                        " DURATION =  @Duration, LATEBY= @LateBy, EARLYBY= @EarlyBy, ISWEEKLYOFF = @IsWeeklyOff, " +
                        " ISHOLIDAY = @IsHoliday, ISONLEAVE = @IsOnLeave, LEAVETYPEID = @LeaveTypeID," +
                        " SHIFTID= @ShiftID, PRESENT = @Present, ABSENT =@Absent, ISONSPECIALOFF = @IsOnSpecialOff, " +
                        " SPECIALOFFTYPE = @SpecialOffType, " +
                        " MODIFY_DATE = @ModifyDate, MODBY = @ModBy, MACHINENAME = @MachineName " +
                        " WHERE DBID = @dbId";
                }

                try
                {
                    SqlCommand objCmd = Conn.CreateCommand();
                    objCmd.CommandType = CommandType.Text;
                    objCmd.CommandText = strSaveQry;

                    objCmd.Parameters.AddWithValue("@AttDate", objDailyAtt.AttDate);
                    objCmd.Parameters.AddWithValue("@EmpID", objDailyAtt.EmpID);
                    objCmd.Parameters.AddWithValue("@InTime", objDailyAtt.InTime);
                    objCmd.Parameters.AddWithValue("@OutTime", objDailyAtt.OutTime);
                    objCmd.Parameters.AddWithValue("@Duration", objDailyAtt.Duration);
                    objCmd.Parameters.AddWithValue("@LateBy", objDailyAtt.LateByMins);
                    objCmd.Parameters.AddWithValue("@EarlyBy", objDailyAtt.EarlyByMins);
                    objCmd.Parameters.AddWithValue("@IsWeeklyOff", objDailyAtt.IsWeeklyOff);
                    objCmd.Parameters.AddWithValue("@IsHoliday", objDailyAtt.IsHoliday);
                    objCmd.Parameters.AddWithValue("@IsOnLeave", objDailyAtt.IsOnLeave);
                    objCmd.Parameters.AddWithValue("@LeaveTypeID", objDailyAtt.LeaveTypeID);
                    objCmd.Parameters.AddWithValue("@ShiftID", objDailyAtt.ShiftID);
                    objCmd.Parameters.AddWithValue("@Present", objDailyAtt.Present);
                    objCmd.Parameters.AddWithValue("@Absent", objDailyAtt.Absent);
                    objCmd.Parameters.AddWithValue("@IsOnSpecialOff", objDailyAtt.IsOnSpecialOff);
                    objCmd.Parameters.AddWithValue("@SpecialOffType", objDailyAtt.SpecialOffType);

                    if (objDailyAtt.IsNew)
                    {
                        objCmd.Parameters.AddWithValue("@StDate", DateTime.Now);
                        objCmd.Parameters.AddWithValue("@CrBy", CurrentCompany.m_UserName);
                        objDailyAtt.DBID = General.GenerateDBID("SEQDAILYATTID", Conn);
                    }
                    objCmd.Parameters.AddWithValue("@ModifyDate", DateTime.Now);
                    objCmd.Parameters.AddWithValue("@ModBy", CurrentCompany.m_UserName);
                    objCmd.Parameters.AddWithValue("@MachineName", General.GetMachineName());
                    objCmd.Parameters.AddWithValue("@dbID", objDailyAtt.DBID);

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
                ObjDelCmd.CommandText = "DELETE FROM EMPDAILYATTENDANCE WHERE DBID = @dbID";
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
        /// <param name="objDailyAtt">Object Containing New Data Values.</param>
        /// <returns>Boolean value True if Current Record already exists
        /// otherwise returns False indicating current Record Does not exist.</returns>
        public static bool IsDailyAttExist(DailyAttendance objDailyAtt)
        {
            bool IsRecordExist = false;
            using (SqlConnection Conn = new SqlConnection(General.GetSQLConnectionString()))
            {
                try
                {
                    SqlCommand objCmd = Conn.CreateCommand();
                    objCmd.CommandType = CommandType.Text;
                    objCmd.CommandText = "SELECT DBID FROM DAILYATTENDANCE " +
                        " WHERE ATTDATE = @mAttDate " +
                        " AND EMPLOYEEID = @mEmpID " +
                        " AND DBID <> @dbID ";

                    objCmd.Parameters.AddWithValue("@mAttDate", objDailyAtt.AttDate);
                    objCmd.Parameters.AddWithValue("@mEmpID", objDailyAtt.EmpID);
                    objCmd.Parameters.AddWithValue("@dbID", objDailyAtt.DBID);

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
