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
    public class LeaveTypeDAL
    {
        #region Private Method(s)
        /// <summary>
        /// Fills values fetched from Database to Object objLeaveType.
        /// </summary>
        /// <param name="myDataRec">Record Object containing data values.</param>
        /// <returns>Returns object ObjLeaveType containing Data values from Database.</returns>
        private static LeaveType FillDataRecord(IDataRecord myDataRec)
        {
            LeaveType objLeaveType = new LeaveType();
            objLeaveType.IsLoading = true;
            objLeaveType.DBID = Convert.ToInt32(myDataRec["DBID"]);
            objLeaveType.LeaveTypeCode = Convert.ToString(myDataRec["LEAVETYPE"]);
            objLeaveType.LeaveTypeName = Convert.ToString(myDataRec["LEAVETYPENAME"]);

            if (!myDataRec.IsDBNull(myDataRec.GetOrdinal("YEARLYLIMIT")))
                objLeaveType.YearlyLimit = Convert.ToString(myDataRec["YEARLYLIMIT"]);
            if (!myDataRec.IsDBNull(myDataRec.GetOrdinal("CARRYFWDLIMIT")))
                objLeaveType.CarryFwdLimit = Convert.ToInt32(myDataRec["CARRYFWDLIMIT"]);
            objLeaveType.IsAddMonthly = Convert.ToInt32(myDataRec["ISADDMONTHLY"]);
            objLeaveType.AddMonthlyLV = Convert.ToInt32(myDataRec["ADDMONTHLYLV"]);
            objLeaveType.ApplicableGender = Convert.ToString(myDataRec["APPLICABLEGENDER"]);
            if (!myDataRec.IsDBNull(myDataRec.GetOrdinal("CONSIDERAS")))
                objLeaveType.ConsiderAs = Convert.ToString(myDataRec["CONSIDERAS"]);
            objLeaveType.IsAllowNegativeBal = Convert.ToInt32(myDataRec["ISALLOWNEGATIVEBAL"]);

            objLeaveType.IsNew = false;
            objLeaveType.IsEdited = false;
            objLeaveType.IsDeleted = false;
            objLeaveType.IsLoading = false;

            return objLeaveType;
        }
        #endregion

        /// <summary>
        /// This method retrieves "LEAVETYPE" Record, from Database.
        /// </summary>
        /// <param name="dbid">Unique ID value based on which Record will be fetched.</param>
        /// <returns>Object "LeaveType" containing Data Values.</returns>
        public static LeaveType GetItem(long dbid)
        {
            LeaveType objLeaveType = null;
            using (SqlConnection Conn = new SqlConnection(General.GetSQLConnectionString()))
            {
                using (SqlCommand objCmd = new SqlCommand())
                {
                    try
                    {
                        objCmd.Connection = Conn;
                        objCmd.CommandType = CommandType.Text;
                        objCmd.CommandText = "SELECT a.* " +
                            " FROM LEAVETYPEMAST a " +
                            " WHERE a.DBID = @mDBID ";
                        objCmd.Parameters.AddWithValue("@mDBID", dbid);

                        if (Conn.State != ConnectionState.Open)
                        {
                            Conn.Open();
                        }

                        SqlDataReader oReader = objCmd.ExecuteReader();
                        if (oReader.Read())
                        {
                            objLeaveType = FillDataRecord(oReader);
                            objLeaveType.IsNew = false;
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
            return objLeaveType;
        }

        /// <summary>
        /// This method provides List of LeaveTypes available in Database.
        /// </summary>
        /// <param name="strWhere">Specifies condition for retrieving records.</param>
        /// <returns>Collection of LeaveType Objects.</returns>
        public static LeaveTypeList GetList(string strWhere)
        {
            LeaveTypeList objList = null;
            string strSql = "SELECT A.*" +
                " FROM LeaveTypeMast A ";//(+)

            if (strWhere != string.Empty)
                strSql = strSql + " WHERE " + strWhere;
            strSql += " ORDER BY LEAVETYPE ";

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
                            objList = new LeaveTypeList();
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
        /// <param name="objLeaveType">Object containing Data values to be saved.</param>
        /// <returns>Boolean value True if Record is saved successfully
        /// otherwise returns False indicating Record is not saved.</returns>
        public static bool Save(LeaveType objLeaveType)
        {
            int result = 0;
            UserCompany CurrentCompany = new UserCompany();
            using (SqlConnection Conn = new SqlConnection(General.GetSQLConnectionString()))
            {
                string strSaveQry;
                if (objLeaveType.IsNew)
                {
                    strSaveQry = "INSERT INTO LEAVETYPEMAST(DBID, LeaveType, LeaveTypeName, YearlyLimit, " +
                        " CarryFwdLimit, IsAddMonthly, AddMonthlyLV, ApplicableGender, ConsiderAs, " +
                        " IsAllowNegativeBal, ST_DATE, MODIFY_DATE, CRBY, MODBY, MACHINENAME ) " +
                        " VALUES (@dbId, @LeaveType, @LeaveTypeName, @YearlyLimit," +
                        " @CarryFwdLimit, @IsAddMonthly, @AddMonthlyLV, @ApplicableGender, @ConsiderAs, " +
                        " @IsAllowNegativeBal, @STDate, @ModifyDate, @CrBy, @ModBy, @MachineName) ";
                }
                else
                {
                    strSaveQry = "UPDATE LEAVETYPEMAST " +
                        " SET LeaveType = @LeaveType, LeaveTypeName = @LeaveTypeName, YearlyLimit = @YearlyLimit, " +
                        " CarryFwdLimit = @CarryFwdLimit, IsAddMonthly = @IsAddMonthly, " +
                        " ApplicableGender = @ApplicableGender, ConsiderAs = @ConsiderAs, " +
                        " IsAllowNegativeBal = @IsAllowNegativeBal, MODIFY_DATE = @ModifyDate, " +
                        " MODBY = @ModBy, MACHINENAME = @MachineName " +
                        " WHERE DBID = @dbId";
                }

                try
                {
                    SqlCommand objCmd = Conn.CreateCommand();
                    objCmd.CommandType = CommandType.Text;
                    objCmd.CommandText = strSaveQry;

                    objCmd.Parameters.AddWithValue("@LeaveType", objLeaveType.LeaveTypeCode);
                    objCmd.Parameters.AddWithValue("@LeaveTypeName", objLeaveType.LeaveTypeName);
                    objCmd.Parameters.AddWithValue("@YearlyLimit", objLeaveType.YearlyLimit);
                    objCmd.Parameters.AddWithValue("@CarryFwdLimit", objLeaveType.CarryFwdLimit);
                    objCmd.Parameters.AddWithValue("@IsAddMonthly", objLeaveType.IsAddMonthly);
                    objCmd.Parameters.AddWithValue("@AddMonthlyLV", objLeaveType.AddMonthlyLV);
                    objCmd.Parameters.AddWithValue("@ApplicableGender", objLeaveType.ApplicableGender);
                    objCmd.Parameters.AddWithValue("@ConsiderAs", objLeaveType.ConsiderAs);
                    objCmd.Parameters.AddWithValue("@IsAllowNegativeBal", objLeaveType.IsAllowNegativeBal);

                    if (objLeaveType.IsNew)
                    {
                        objCmd.Parameters.AddWithValue("@StDate", DateTime.Now);
                        objCmd.Parameters.AddWithValue("@CrBy", "");        //CurrentCompany.m_UserName
                        objLeaveType.DBID = General.GenerateDBID("SEQLEAVETYPEID", Conn);
                    }
                    objCmd.Parameters.AddWithValue("@ModifyDate", DateTime.Now);
                    objCmd.Parameters.AddWithValue("@ModBy", "");           //CurrentCompany.m_UserName
                    objCmd.Parameters.AddWithValue("@MachineName", General.GetMachineName());
                    objCmd.Parameters.AddWithValue("@dbID", objLeaveType.DBID);

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
                ObjDelCmd.CommandText = "DELETE FROM LEAVETYPEMAST WHERE DBID = @dbID";
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
        /// This method Checks whether Current LeaveType already exists in Database or not.
        /// </summary>
        /// <param name="objLeaveType">Object Containing New Data Values.</param>
        /// <returns>Boolean value True if Current Record already exists
        /// otherwise returns False indicating current Record Does not exist.</returns>
        public static bool IsLeaveTypeExist(LeaveType objLeaveType)
        {
            bool IsRecordExist = false;
            using (SqlConnection Conn = new SqlConnection(General.GetSQLConnectionString()))
            {
                try
                {
                    SqlCommand objCmd = Conn.CreateCommand();
                    objCmd.CommandType = CommandType.Text;
                    objCmd.CommandText = "SELECT DBID FROM LEAVETYPEMAST " +
                        " WHERE LEAVETYPE = @mLeaveType " +
                        " AND DBID <> @dbID ";

                    objCmd.Parameters.AddWithValue("@mLeaveType", objLeaveType.LeaveTypeCode);
                    objCmd.Parameters.AddWithValue("@dbID", objLeaveType.DBID);

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
