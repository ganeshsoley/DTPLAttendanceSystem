using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityObject;
using DAL;

namespace DAL
{
    public class LeaveApplicationDAL
    {
        #region Private Method(s)
        /// <summary>
        /// Fills values fetched from Database to Object objHoliday.
        /// </summary>
        /// <param name="myDataRec">Record Object containing data values.</param>
        /// <returns>Returns object ObjHoliday containing Data values from Database.</returns>
        private static LeaveApplication FillDataRecord(IDataRecord myDataRec)
        {
            LeaveApplication objLVApplication = new LeaveApplication();
            objLVApplication.IsLoading = true;

            objLVApplication.DBID = Convert.ToInt32(myDataRec["DBID"]);
            objLVApplication.LeaveTypeID = Convert.ToInt32(myDataRec["LEAVETYPEID"]);
            objLVApplication.LeaveType = Convert.ToString(myDataRec["LEAVETYPE"]);
            objLVApplication.EmployeeID = Convert.ToInt32(myDataRec["EMPLOYEEID"]);
            objLVApplication.EmpName = Convert.ToString(myDataRec["EMPNAME"]);
            objLVApplication.EmpDept = Convert.ToString(myDataRec["EMPDEPT"]);
            objLVApplication.FromDate = Convert.ToDateTime(myDataRec["FROMDATE"]);
            objLVApplication.ToDate = Convert.ToDateTime(myDataRec["TODATE"]);
            objLVApplication.TotalLeaves = Convert.ToInt16(myDataRec["LEAVECOUNT"]);
            if (!myDataRec.IsDBNull(myDataRec.GetOrdinal("LEAVEREASON")))
                objLVApplication.LeaveReason = Convert.ToString(myDataRec["LEAVEREASON"]);
            objLVApplication.IsLeaveApproved = Convert.ToInt16(myDataRec["ISAPPROVED"]);
            objLVApplication.IsHRApproved = Convert.ToInt16(myDataRec["ISHRAPPROVED"]);
            objLVApplication.IsHalfDay = Convert.ToInt16(myDataRec["ISHALFDAY"]);
            objLVApplication.IsCOff = Convert.ToInt16(myDataRec["ISCOFF"]);
            if (!myDataRec.IsDBNull(myDataRec.GetOrdinal("COFFDATE")))
                objLVApplication.COffDate = Convert.ToString(myDataRec["COFFDATE"]);

            objLVApplication.IsNew = false;
            objLVApplication.IsEdited = false;
            objLVApplication.IsDeleted = false;
            objLVApplication.IsLoading = false;

            return objLVApplication;
        }
        #endregion

        #region Public Method(s)
        /// <summary>
        /// This method retrieves "LeaveApplication" Record, from Database.
        /// </summary>
        /// <param name="dbid">Unique ID value based on which Record will be fetched.</param>
        /// <returns>Object "LeaveApplication" containing Data Values.</returns>
        public static LeaveApplication GetItem(long dbid)
        {
            LeaveApplication objLVApplication = null;
            using (SqlConnection Conn = new SqlConnection(General.GetSQLConnectionString()))
            {
                using (SqlCommand objCmd = new SqlCommand())
                {
                    try
                    {
                        objCmd.Connection = Conn;
                        objCmd.CommandType = CommandType.Text;
                        objCmd.CommandText = "SELECT a.*, B.INITIALS EMPNAME, C.LEAVETYPE " +
                            " FROM EMPLEAVEENTRIES A, EMPMAST B, LEAVETYPEMAST C " +
                            " WHERE A.EMPLOYEEID = B.DBID " +
                            " AND A.LEAVETYPEID = C.DBID " +
                            " AND a.DBID = @mDBID";

                        objCmd.Parameters.AddWithValue("@mDBID", dbid);

                        if (Conn.State != ConnectionState.Open)
                        {
                            Conn.Open();
                        }

                        SqlDataReader oReader = objCmd.ExecuteReader();
                        if (oReader.Read())
                        {
                            objLVApplication = FillDataRecord(oReader);
                            objLVApplication.IsNew = false;
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
            return objLVApplication;
        }

        /// <summary>
        /// This method provides List of LeaveApplications available in Database.
        /// </summary>
        /// <param name="strWhere">Specifies condition for retrieving records.</param>
        /// <returns>Collection of LeaveApplications Objects.</returns>
        public static LeaveApplicationList GetList(string strWhere)
        {
            LeaveApplicationList objList = null;
            string strSql = "SELECT A.*, B.INITIALS EMPNAME, C.LEAVETYPE " +
                " FROM EMPLEAVEENTRIES A, EMPMAST B, LEAVETYPEMAST C " +
                " WHERE A.EMPLOYEEID = B.DBID " +
                " AND A.LEAVETYPEID = C.DBID ";

            if (strWhere != string.Empty)
                strSql = strSql + " AND " + strWhere;
            strSql += " ORDER BY ST_DATE, B.EMPNAME ";

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
                            objList = new LeaveApplicationList();
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
        /// <param name="objLeaveApplication">Object containing Data values to be saved.</param>
        /// <returns>Boolean value True if Record is saved successfully
        /// otherwise returns False indicating Record is not saved.</returns>
        public static bool Save(LeaveApplication objLVApplication)
        {
            int result = 0;
            UserCompany CurrentCompany = new UserCompany();
            using (SqlConnection Conn = new SqlConnection(General.GetSQLConnectionString()))
            {
                string strSaveQry;
                if (objLVApplication.IsNew)
                {
                    strSaveQry = "INSERT INTO EMPLEAVEENTRIES(DBID, EmployeeID, LeaveTypeID, FromDate, ToDate, " +
                        " IsApproved, IsHRApproved, IsHalfDay, IsCOff, TotalLeaves, COFFDATE, " +
                        " LEAVEREASON, ST_DATE, MODIFY_DATE, CRBY, MODBY, MACHINENAME ) " +
                        " VALUES (@dbId, @EmployeeID, @LeaveTypeID, @FromDate, @ToDate, " +
                        " @IsApproved, @IsHRApproved, @IsHalfDay, @IsCOff, @TotalLeaves, @COffDate, " +
                        " @LeaveReason, @STDate, @ModifyDate, @CrBy, @ModBy, @MachineName )";
                }
                else
                {
                    strSaveQry = "UPDATE EMPLEAVEENTRIES " +
                        " SET EmployeeID = @EmployeeID, LeaveTypeID = @LeaveTypeID, FromDate = @FromDate, " +
                        " ToDate = @ToDate, IsApproved = @IsApproved, IsHRApproved = @IsHRApproved, " +
                        " IsHalfDay = @IsHalfDay, IsCOff= @IsCOff, TotalLeaves = @TotalLeaves, COFFDATE = @COffDate, " +
                        " LEAVEREASON = @LeaveReason, MODIFY_DATE = @ModifyDate, MODBY = @ModBy, MACHINENAME = @MachineName " +
                        " WHERE DBID = @dbId";
                }

                try
                {
                    SqlCommand objCmd = Conn.CreateCommand();
                    objCmd.CommandType = CommandType.Text;
                    objCmd.CommandText = strSaveQry;

                    objCmd.Parameters.AddWithValue("@EmployeeID", objLVApplication.EmployeeID);
                    objCmd.Parameters.AddWithValue("@LeaveTypeID", objLVApplication.LeaveTypeID);
                    objCmd.Parameters.AddWithValue("@FromDate", objLVApplication.FromDate);
                    objCmd.Parameters.AddWithValue("@ToDate", objLVApplication.ToDate);
                    objCmd.Parameters.AddWithValue("@IsApproved", objLVApplication.IsLeaveApproved);
                    objCmd.Parameters.AddWithValue("@IsHRApproved", objLVApplication.IsHRApproved);
                    objCmd.Parameters.AddWithValue("@IsHalfDay", objLVApplication.IsHalfDay);
                    objCmd.Parameters.AddWithValue("@IsCOff", objLVApplication.IsCOff);
                    objCmd.Parameters.AddWithValue("@COffDate", objLVApplication.COffDate);
                    objCmd.Parameters.AddWithValue("@TotalLeaves", objLVApplication.TotalLeaves);
                    objCmd.Parameters.AddWithValue("@LeaveReason", objLVApplication.LeaveReason);

                    if (objLVApplication.IsNew)
                    {
                        objCmd.Parameters.AddWithValue("@StDate", DateTime.Now);
                        objCmd.Parameters.AddWithValue("@CrBy", "");        //CurrentCompany.m_UserName
                        objLVApplication.DBID = General.GenerateDBID("SEQLVAPPID", Conn);
                    }
                    objCmd.Parameters.AddWithValue("@ModifyDate", DateTime.Now);
                    objCmd.Parameters.AddWithValue("@ModBy", "");           //CurrentCompany.m_UserName
                    objCmd.Parameters.AddWithValue("@MachineName", General.GetMachineName());
                    objCmd.Parameters.AddWithValue("@dbID", objLVApplication.DBID);

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
                ObjDelCmd.CommandText = "DELETE FROM EMPLEAVEENTRIES WHERE DBID = @dbID";
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
        /// This method Checks whether Current Leave Application already exists in Database or not.
        /// </summary>
        /// <param name="objLVApplication">Object Containing New Data Values.</param>
        /// <returns>Boolean value True if Current Record already exists
        /// otherwise returns False indicating current Record Does not exist.</returns>
        public static bool IsLvApplicationExist(LeaveApplication objLVApplication)
        {
            bool IsRecordExist = false;
            using (SqlConnection Conn = new SqlConnection(General.GetSQLConnectionString()))
            {
                try
                {
                    SqlCommand objCmd = Conn.CreateCommand();
                    objCmd.CommandType = CommandType.Text;
                    objCmd.CommandText = "SELECT DBID FROM EMPLEAVEENTRIES " +
                        " WHERE EMPLOYEEID = @mEmpID " +
                        " AND LEAVETYPEID = @mLeaveID " +
                        " AND FROMDATE = @mFromDate " +
                        " AND TODATE = @mTODate " +
                        " AND DBID <> @dbID ";

                    objCmd.Parameters.AddWithValue("@mEmpID", objLVApplication.EmployeeID);
                    objCmd.Parameters.AddWithValue("@mLeaveID", objLVApplication.LeaveTypeID);
                    objCmd.Parameters.AddWithValue("@mFromDate", objLVApplication.FromDate);
                    objCmd.Parameters.AddWithValue("@mTODate", objLVApplication.ToDate);
                    objCmd.Parameters.AddWithValue("@dbID", objLVApplication.DBID);

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
