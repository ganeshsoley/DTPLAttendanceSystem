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
    public class DesignationDAL
    {
        #region Private Method(s)
        /// <summary>
        /// Fills values fetched from Database to Object objDept.
        /// </summary>
        /// <param name="myDataRec">Record Object containing data values.</param>
        /// <returns>Returns object ObjEmployee containing Data values from Database.</returns>
        private static Designation FillDataRecord(IDataRecord myDataRec)
        {
            Designation objDesig = new Designation();
            objDesig.IsLoading = true;
            objDesig.DBID = Convert.ToInt32(myDataRec["DBID"]);
            objDesig.DesigName = Convert.ToString(myDataRec["DESIGNATION"]);
            objDesig.Description = Convert.ToString(myDataRec["DESCRIPTION"]);

            objDesig.IsNew = false;
            objDesig.IsEdited = false;
            objDesig.IsDeleted = false;
            objDesig.IsLoading = false;

            return objDesig;
        }
        #endregion

        /// <summary>
        /// This method retrieves "Designation" Record, from Database.
        /// </summary>
        /// <param name="dbid">Unique ID value based on which Record will be fetched.</param>
        /// <returns>Object "Designation" containing Data Values.</returns>
        public static Designation GetItem(long dbid)
        {
            Designation objDesig = null;
            using (SqlConnection Conn = new SqlConnection(General.GetSQLConnectionString()))
            {
                using (SqlCommand objCmd = new SqlCommand())
                {
                    try
                    {
                        objCmd.Connection = Conn;
                        objCmd.CommandType = CommandType.Text;
                        objCmd.CommandText = "SELECT a.* " +
                            " FROM DesignationMast a " +
                            " WHERE a.DBID = @mDBID";
                        objCmd.Parameters.AddWithValue("@mDBID", dbid);

                        if (Conn.State != ConnectionState.Open)
                        {
                            Conn.Open();
                        }

                        SqlDataReader oReader = objCmd.ExecuteReader();
                        if (oReader.Read())
                        {
                            objDesig = FillDataRecord(oReader);
                            objDesig.IsNew = false;
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
            return objDesig;
        }

        /// <summary>
        /// This method provides List of Designations available in Database.
        /// </summary>
        /// <param name="strWhere">Specifies condition for retrieving records.</param>
        /// <returns>Collection of Designation Objects.</returns>
        public static DesignationList GetList(string strWhere)
        {
            DesignationList objList = null;
            string strSql = "SELECT DBID, DESIGNATION, DESCRIPTION " +
                " FROM DesignationMast A ";

            if (strWhere != string.Empty)
                strSql = strSql + " AND " + strWhere;
            strSql += " ORDER BY DESIGNATION";

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
                            objList = new DesignationList();
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
        /// <param name="objDesig">Object containing Data values to be saved.</param>
        /// <returns>Boolean value True if Record is saved successfully
        /// otherwise returns False indicating Record is not saved.</returns>
        public static bool Save(Designation objDesig)
        {
            int result = 0;
            UserCompany CurrentCompany = new UserCompany();
            using (SqlConnection Conn = new SqlConnection(General.GetSQLConnectionString()))
            {
                string strSaveQry;
                if (objDesig.IsNew)
                {
                    strSaveQry = "INSERT INTO DESIGNATIONMAST(DBID, DESIGNATION, DESCRIPTION, " +
                        " ST_DATE, MODIFY_DATE, CRBY, MODBY, MACHINENAME) " +
                        " VALUES (@dbId, @Desig, @Descr, " +
                        " @STDate, @ModifyDate, @CrBy, @ModBy, @MachineName)";
                }
                else
                {
                    strSaveQry = "UPDATE DESIGNATIONMAST " +
                        " SET DESIGNATION = @Desig, DESCRIPTION = @Descr, " +
                        " MODIFY_DATE = @ModifyDate, MODBY = @ModBy, MACHINENAME = @MachineName " +
                        " WHERE DBID = @dbId";
                }

                try
                {
                    SqlCommand objCmd = Conn.CreateCommand();
                    objCmd.CommandType = CommandType.Text;
                    objCmd.CommandText = strSaveQry;

                    objCmd.Parameters.AddWithValue("@Desig", objDesig.DesigName);
                    objCmd.Parameters.AddWithValue("@Descr", objDesig.Description);

                    if (objDesig.IsNew)
                    {
                        objCmd.Parameters.AddWithValue("@StDate", DateTime.Now);
                        objCmd.Parameters.AddWithValue("@CrBy", "");        //CurrentCompany.m_UserName
                        objDesig.DBID = General.GenerateDBID("SEQDESIGID", Conn);
                    }
                    objCmd.Parameters.AddWithValue("@ModifyDate", DateTime.Now);
                    objCmd.Parameters.AddWithValue("@ModBy", "");           //CurrentCompany.m_UserName
                    objCmd.Parameters.AddWithValue("@MachineName", General.GetMachineName());
                    objCmd.Parameters.AddWithValue("@dbID", objDesig.DBID);

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
                ObjDelCmd.CommandText = "DELETE FROM DESIGNATIONMAST WHERE DBID = @dbID";
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
        /// This method Checks whether Current Employee already exists in Database or not.
        /// </summary>
        /// <param name="objEmp">Object Containing New Data Values.</param>
        /// <returns>Boolean value True if Current Record already exists
        /// otherwise returns False indicating current Record Does not exist.</returns>
        public static bool IsDesignationExist(Designation objDesig)
        {
            bool IsRecordExist = false;
            using (SqlConnection Conn = new SqlConnection(General.GetSQLConnectionString()))
            {
                try
                {
                    SqlCommand objCmd = Conn.CreateCommand();
                    objCmd.CommandType = CommandType.Text;
                    objCmd.CommandText = "SELECT DBID FROM DESIGNATIONMAST " +
                        " WHERE DESIGNATION = @mDesig " +
                        " AND DBID <> @dbID ";

                    objCmd.Parameters.AddWithValue("@mDesig", objDesig.DesigName);
                    objCmd.Parameters.AddWithValue("@dbID", objDesig.DBID);

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

        /// <summary>
        /// This method Checks whether Current Employee already exists in Database or not.
        /// </summary>
        /// <param name="objEmp">Object Containing New Data Values.</param>
        /// <returns>Boolean value True if Current Record already exists
        /// otherwise returns False indicating current Record Does not exist.</returns>
        public static bool IsDesignationUsed(long DesigID)
        {
            bool IsRecordExist = false;
            using (SqlConnection Conn = new SqlConnection(General.GetSQLConnectionString()))
            {
                try
                {
                    SqlCommand objCmd = Conn.CreateCommand();
                    objCmd.CommandType = CommandType.Text;
                    objCmd.CommandText = "SELECT DBID FROM EMPMAST " +
                        " WHERE DESIGNATIONID = @dbID ";

                    objCmd.Parameters.AddWithValue("@dbID", DesigID);

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
