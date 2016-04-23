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
    public class EmployeeStatusDAL
    {
        #region Private Method(s)
        /// <summary>
        /// Fills values fetched from Database to Object objEmpStatus.
        /// </summary>
        /// <param name="myDataRec">Record Object containing data values.</param>
        /// <returns>Returns object ObjEmpStatus containing Data values from Database.</returns>
        private static EmployeeStatus FillDataRecord(IDataRecord myDataRec)
        {
            EmployeeStatus objEmpStatus = new EmployeeStatus();
            objEmpStatus.IsLoading = true;
            objEmpStatus.DBID = Convert.ToInt32(myDataRec["DBID"]);
            objEmpStatus.EmpStatus = Convert.ToString(myDataRec["EMPSTATUSNAME"]);
            if (!myDataRec.IsDBNull(myDataRec.GetOrdinal("DESCRIPTION")))
                objEmpStatus.Description = Convert.ToString(myDataRec["DESCRIPTION"]);

            objEmpStatus.IsNew = false;
            objEmpStatus.IsEdited = false;
            objEmpStatus.IsDeleted = false;
            objEmpStatus.IsLoading = false;

            return objEmpStatus;
        }
        #endregion

        #region Public Method(s)
        /// <summary>
        /// This method retrieves "EmployeeStatus" Record, which is retrieved from Database.
        /// </summary>
        /// <param name="dbid">Unique ID value based on which Record will be fetched from Database.</param>
        /// <returns>Object "EmployeeStatus" containing Data Values.</returns>
        public static EmployeeStatus GetItem(int dbid)
        {
            EmployeeStatus objEmpStatus = null;
            using (SqlConnection Conn = new SqlConnection(General.GetSQLConnectionString()))
            {
                using (SqlCommand objCmd = new SqlCommand())
                {
                    try
                    {
                        objCmd.Connection = Conn;
                        objCmd.CommandType = CommandType.Text;
                        objCmd.CommandText = "SELECT * FROM EMPSTATUSMAST " +
                            " WHERE DBID = @DBID";
                        objCmd.Parameters.AddWithValue("@DBID", dbid);

                        if (Conn.State != ConnectionState.Open)
                        {
                            Conn.Open();
                        }

                        SqlDataReader oReader = objCmd.ExecuteReader();
                        if (oReader.Read())
                        {
                            objEmpStatus = FillDataRecord(oReader);
                            objEmpStatus.IsNew = false;
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
            return objEmpStatus;
        }

        /// <summary>
        /// This method provides List of EmployeeStatus available in Database.
        /// </summary>
        /// <param name="strWhere">Specifies condition for retrieving records.</param>
        /// <returns>Collection of EmployeeStatus Objects.</returns>
        public static EmployeeStatusList GetList(string strWhere)
        {

            EmployeeStatusList objList = null;

            string strSql = "Select * from EMPSTATUSMAST ";

            if (strWhere != string.Empty)
                strSql = strSql + " WHERE " + strWhere;
            strSql += " ORDER BY EMPSTATUSNAME";

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
                            objList = new EmployeeStatusList();
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
        /// <param name="objEmployeeStatus">Object containing Data values to be saved.</param>
        /// <returns>Boolean value True if Record is saved successfully
        /// otherwise returns False indicating Record is not saved.</returns>
        public static bool Save(EmployeeStatus objEmpStatus)
        {
            int result = 0;
            UserCompany CurrentCompany = new UserCompany();
            using (SqlConnection Conn = new SqlConnection(General.GetSQLConnectionString()))
            {
                string strSaveQry;
                if (objEmpStatus.IsNew)
                {
                    strSaveQry = "INSERT INTO EMPSTATUSMAST(DBID, EMPSTATUSNAME, DESCRIPTION, " +
                        " ST_DATE, MODIFY_DATE, CRBY, MODBY, MACHINENAME) " +
                        " VALUES (@dbId, @Status, @Description, " +
                        " @STDate, @ModifyDate, @CrBy, @ModBy, @MachineName)";
                }
                else
                {
                    strSaveQry = "UPDATE EMPSTATUSMAST " +
                        "SET EMPSTATUSNAME = @Status, DESCRIPTION = @Description, " +
                        " MODIFY_DATE = @ModifyDate, MODBY = @ModBy, MACHINENAME = @MachineName " +
                        "WHERE DBID = @dbId";
                }

                try
                {
                    SqlCommand objCmd = Conn.CreateCommand();
                    objCmd.CommandType = CommandType.Text;
                    objCmd.CommandText = strSaveQry;

                    objCmd.Parameters.AddWithValue("@Status", objEmpStatus.EmpStatus);
                    objCmd.Parameters.AddWithValue("@Description", objEmpStatus.Description);

                    if (objEmpStatus.IsNew)
                    {
                        objCmd.Parameters.AddWithValue("@StDate", DateTime.Now);
                        objCmd.Parameters.AddWithValue("@CrBy", "");        //CurrentCompany.m_UserName
                        objEmpStatus.DBID = General.GenerateDBID(Conn, "EMPSTATUSMAST");
                    }
                    objCmd.Parameters.AddWithValue("@ModifyDate", DateTime.Now);
                    objCmd.Parameters.AddWithValue("@ModBy", "");           //CurrentCompany.m_UserName
                    objCmd.Parameters.AddWithValue("@MachineName", General.GetMachineName());
                    objCmd.Parameters.AddWithValue("@dbID", objEmpStatus.DBID);

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
                ObjDelCmd.CommandText = "DELETE FROM EMPSTATUSMAST WHERE DBID = @dbID";
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
        /// This method Checks whether Current EmployeeStatus already exists in Database or not.
        /// </summary>
        /// <param name="objEmployeeStatus">Object Containing New Data Values.</param>
        /// <returns>Boolean value True if Current Record already exists
        /// otherwise returns False indicating current Record Does not exist.</returns>
        public static bool IsEmployeeStatusExist(EmployeeStatus objEmpStatus)
        {
            bool IsRecordExist = false;
            using (SqlConnection Conn = new SqlConnection(General.GetSQLConnectionString()))
            {
                try
                {
                    SqlCommand objCmd = Conn.CreateCommand();
                    objCmd.CommandType = CommandType.Text;
                    objCmd.CommandText = "SELECT DBID FROM EMPSTATUSMAST " +
                        " WHERE STATUS = @Status " +
                        " AND DBID <> @dbID ";

                    objCmd.Parameters.AddWithValue("@Status", objEmpStatus.EmpStatus);
                    objCmd.Parameters.AddWithValue("@dbID", objEmpStatus.DBID);

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
