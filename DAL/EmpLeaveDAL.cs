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
    public class EmpLeaveDAL
    {
        #region Private Method(s)
        /// <summary>
        /// Fills values fetched from Database to Object objEmpLeave.
        /// </summary>
        /// <param name="myDataRec">Record Object containing data values.</param>
        /// <returns>Returns object ObjEmpLeave containing Data values from Database.</returns>
        private static EmployeeLeave FillDataRecord(IDataRecord myDataRec)
        {
            EmployeeLeave objEmpLeave = new EmployeeLeave();
            objEmpLeave.IsLoading = true;

            objEmpLeave.DBID = Convert.ToInt32(myDataRec["DBID"]);
            objEmpLeave.EmployeeID = Convert.ToInt32(myDataRec["EMPLOYEEID"]);
            objEmpLeave.EmployeeName = Convert.ToString(myDataRec["EMPLOYEENAME"]);
            if (!myDataRec.IsDBNull(myDataRec.GetOrdinal("EMPDEPT")))
                objEmpLeave.EmpDept= Convert.ToString(myDataRec["EMPDEPT"]);
            objEmpLeave.LeaveTypeID = Convert.ToInt32(myDataRec["LEAVETYPEID"]);
            objEmpLeave.LeaveType = Convert.ToString(myDataRec["LEAVETYPE"]);
            objEmpLeave.AllowedLeaves = Convert.ToDecimal(myDataRec["ALLOWEDLEAVES"]);

            objEmpLeave.IsNew = false;
            objEmpLeave.IsEdited = false;
            objEmpLeave.IsDeleted = false;
            objEmpLeave.IsLoading = false;

            return objEmpLeave;
        }
        #endregion

        /// <summary>
        /// This method retrieves "Holiday" Record, from Database.
        /// </summary>
        /// <param name="dbid">Unique ID value based on which Record will be fetched.</param>
        /// <returns>Object "Holiday" containing Data Values.</returns>
        public static EmployeeLeave GetItem(long dbid)
        {
            EmployeeLeave objEmpLeave = null;
            using (SqlConnection Conn = new SqlConnection(General.GetSQLConnectionString()))
            {
                using (SqlCommand objCmd = new SqlCommand())
                {
                    try
                    {
                        objCmd.Connection = Conn;
                        objCmd.CommandType = CommandType.Text;
                        objCmd.CommandText = "SELECT a.* " +
                            " FROM EMPLEAVEMAST A " +
                            " WHERE a.DBID = @mDBID";
                        objCmd.Parameters.AddWithValue("@mDBID", dbid);

                        if (Conn.State != ConnectionState.Open)
                        {
                            Conn.Open();
                        }

                        SqlDataReader oReader = objCmd.ExecuteReader();
                        if (oReader.Read())
                        {
                            objEmpLeave = FillDataRecord(oReader);
                            objEmpLeave.IsNew = false;
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
            return objEmpLeave;
        }

        /// <summary>
        /// This method provides List of EmpLeaves available in Database.
        /// </summary>
        /// <param name="strWhere">Specifies condition for retrieving records.</param>
        /// <returns>Collection of EmpLeaves Objects.</returns>
        public static EmpLeavesList GetList(string strWhere)
        {
            EmpLeavesList objList = null;
            string strSql = "SELECT A.*, B.LEAVETYPE, C.INITIALS EMPNAME " +
                " FROM EMPLOYEELEAVEMAST A, LEAVETYPEMAST B, EMPMAST C " +
                " WHERE A.LEAVETYPEID = B.DBID " + 
                " AND A.EMPLOYEEID = C.DBID ";

            if (strWhere != string.Empty)
                strSql = strSql + " AND " + strWhere;
            strSql += " ORDER BY EMPNAME, LEAVETYPE ";

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
                            objList = new EmpLeavesList();
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
        /// <param name="objEmpLeaves">Object containing Data values to be saved.</param>
        /// <returns>Boolean value True if Record is saved successfully
        /// otherwise returns False indicating Record is not saved.</returns>
        public static bool Save(EmployeeLeave objEmpLeave)
        {
            int result = 0;
            UserCompany CurrentCompany = new UserCompany();
            using (SqlConnection Conn = new SqlConnection(General.GetSQLConnectionString()))
            {
                string strSaveQry;
                if (objEmpLeave.IsNew)
                {
                    strSaveQry = "INSERT INTO EMPLOYEELEAVEMAST(DBID, EMPLOYEEID, LEAVETYPEID, ALLOWEDLEAVES, " +
                        " ST_DATE, MODIFY_DATE, CRBY, MODBY, MACHINENAME ) " +
                        " VALUES (@dbId, @EmpID, @LeaveTypeID, @AllowedLeaves, " +
                        " @STDate, @ModifyDate, @CrBy, @ModBy, @MachineName )";
                }
                else
                {
                    strSaveQry = "UPDATE EMPLOYEELEAVEMAST " +
                        " SET EMPLOYEEID = @EmpID, LEAVETYPEID = @LeaveTypeID, " +
                        " ALLOWEDLEAVES = @AllowedLeaves, " +
                        " MODIFY_DATE = @ModifyDate, MODBY = @ModBy, MACHINENAME = @MachineName " +
                        " WHERE DBID = @dbId";
                }

                try
                {
                    SqlCommand objCmd = Conn.CreateCommand();
                    objCmd.CommandType = CommandType.Text;
                    objCmd.CommandText = strSaveQry;

                    objCmd.Parameters.AddWithValue("@EmpID", objEmpLeave.EmployeeID);
                    objCmd.Parameters.AddWithValue("@LeaveTypeID", objEmpLeave.LeaveTypeID);
                    objCmd.Parameters.AddWithValue("@AllowedLeaves", objEmpLeave.AllowedLeaves);

                    if (objEmpLeave.IsNew)
                    {
                        objCmd.Parameters.AddWithValue("@StDate", DateTime.Now);
                        objCmd.Parameters.AddWithValue("@CrBy", CurrentCompany.m_UserName);
                        objEmpLeave.DBID = General.GenerateDBID("SEQEMPLEAVEID", Conn);
                    }
                    objCmd.Parameters.AddWithValue("@ModifyDate", DateTime.Now);
                    objCmd.Parameters.AddWithValue("@ModBy", CurrentCompany.m_UserName);
                    objCmd.Parameters.AddWithValue("@MachineName", General.GetMachineName());
                    objCmd.Parameters.AddWithValue("@dbID", objEmpLeave.DBID);

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
                ObjDelCmd.CommandText = "DELETE FROM EMPLOYEELEAVEMAST WHERE DBID = @dbID";
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
        /// This method Checks whether Current EmpLeave already exists in Database or not.
        /// </summary>
        /// <param name="objEmpLeave">Object Containing New Data Values.</param>
        /// <returns>Boolean value True if Current Record already exists
        /// otherwise returns False indicating current Record Does not exist.</returns>
        public static bool IsEmpLeaveExist(EmployeeLeave objEmpLeave)
        {
            bool IsRecordExist = false;
            using (SqlConnection Conn = new SqlConnection(General.GetSQLConnectionString()))
            {
                try
                {
                    SqlCommand objCmd = Conn.CreateCommand();
                    objCmd.CommandType = CommandType.Text;
                    objCmd.CommandText = "SELECT DBID FROM EMPLOYEELEAVEMAST " +
                        " WHERE EMPLOYEEID = @mEmpID " +
                        " AND LEAVETYPEID = @mLeaveTypeID " +
                        " AND DBID <> @dbID ";

                    objCmd.Parameters.AddWithValue("@mEmpID", objEmpLeave.EmployeeID);
                    objCmd.Parameters.AddWithValue("@mLeaveTypeID", objEmpLeave.LeaveTypeID);
                    objCmd.Parameters.AddWithValue("@dbID", objEmpLeave.DBID);

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
