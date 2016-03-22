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
    public class EmpTypeDAL
    {
        #region Private Method(s)
        /// <summary>
        /// Fills values fetched from Database to Object objEmpType.
        /// </summary>
        /// <param name="myDataRec">Record Object containing data values.</param>
        /// <returns>Returns object ObjEmpType containing Data values from Database.</returns>
        private static EmpType FillDataRecord(IDataRecord myDataRec)
        {
            EmpType objEmpType = new EmpType();
            objEmpType.IsLoading = true;

            objEmpType.DBID = Convert.ToInt32(myDataRec["DBID"]);
            objEmpType.EmpTypeCode= Convert.ToString(myDataRec["EMPTYPE"]);
            objEmpType.EmpTypeName = Convert.ToString(myDataRec["EMPTYPENAME"]);
            objEmpType.OTFormula = Convert.ToString(myDataRec["OTFORMULA"]);
            if (!myDataRec.IsDBNull(myDataRec.GetOrdinal("MINOT")))
                objEmpType.MinOT = Convert.ToString(myDataRec["MINOT"]);
            if (!myDataRec.IsDBNull(myDataRec.GetOrdinal("LATECOMINGGRACETIME")))
                objEmpType.LateComingGraceTime = Convert.ToString(myDataRec["LATECOMINGGRACETIME"]);
            if (!myDataRec.IsDBNull(myDataRec.GetOrdinal("EARLYGOINGGRACETIME")))
                objEmpType.EarlyGoingGraceTime = Convert.ToString(myDataRec["EARLYGOINGGRACETIME"]);
            objEmpType.CalculateHalfDay = Convert.ToInt16(myDataRec["CALCULATEHALFDAY"]);
            if (!myDataRec.IsDBNull(myDataRec.GetOrdinal("HALFDAYMINS")))
                objEmpType.HalfDayMins = Convert.ToString(myDataRec["HALFDAYMINS"]);
            objEmpType.CalculateAbsentDay = Convert.ToInt16(myDataRec["CALCULATEABSENTDAY"]);
            if (!myDataRec.IsDBNull(myDataRec.GetOrdinal("ABSENTDAYMINS")))
                objEmpType.AbsentDayMins = Convert.ToString(myDataRec["ABSENTDAYMINS"]);
            objEmpType.MarkWOHasBothDayAbsent = Convert.ToInt16(myDataRec["MARKWOHASBOTHDAYABSENT"]);

            objEmpType.IsNew = false;
            objEmpType.IsEdited = false;
            objEmpType.IsDeleted = false;
            objEmpType.IsLoading = false;

            return objEmpType;
        }
        #endregion

        /// <summary>
        /// This method retrieves "EmpType" Record, from Database.
        /// </summary>
        /// <param name="dbid">Unique ID value based on which Record will be fetched.</param>
        /// <returns>Object "EmpType" containing Data Values.</returns>
        public static EmpType GetItem(long dbid)
        {
            EmpType objEmpType = null;
            using (SqlConnection Conn = new SqlConnection(General.GetSQLConnectionString()))
            {
                using (SqlCommand objCmd = new SqlCommand())
                {
                    try
                    {
                        objCmd.Connection = Conn;
                        objCmd.CommandType = CommandType.Text;
                        objCmd.CommandText = "SELECT a.* " +
                            " FROM EMPType a " +
                            " WHERE a.DBID = @mDBID";
                        objCmd.Parameters.AddWithValue("@mDBID", dbid);

                        if (Conn.State != ConnectionState.Open)
                        {
                            Conn.Open();
                        }

                        SqlDataReader oReader = objCmd.ExecuteReader();
                        if (oReader.Read())
                        {
                            objEmpType = FillDataRecord(oReader);
                            objEmpType.IsNew = false;
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
            return objEmpType;
        }

        /// <summary>
        /// This method provides List of Employee-Types available in Database.
        /// </summary>
        /// <param name="strWhere">Specifies condition for retrieving records.</param>
        /// <returns>Collection of Employee-Type Objects.</returns>
        public static EmpTypeList GetList(string strWhere)
        {
            EmpTypeList objList = null;
            string strSql = "SELECT DBID, EMPTYPE, EMPTYPENAME, OTFORMULA " +
                " FROM EmpType A ";

            if (strWhere != string.Empty)
                strSql = strSql + " WHERE " + strWhere;
            strSql += " ORDER BY EMPTYPE ";

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
                            objList = new EmpTypeList();
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

        public static bool Save(EmpType objEmpType)
        {
            int result = 0;
            UserCompany CurrentCompany = new UserCompany();
            using (SqlConnection Conn = new SqlConnection(General.GetSQLConnectionString()))
            {
                string strSaveQry;
                if (objEmpType.IsNew)
                {
                    strSaveQry = "INSERT INTO EMPTYPEMAST(DBID, EmpType, EmpTypeName, OTFormula, MinOT, " +
                        " LateComingGraceTime, EarlyGoingGraceTime, CalculateHalfDay, HalfDayMins, " +
                        " CalculateAbsentDay, AbsentDayMins, MarkWOHasBothDayAbsent, " +
                        " ST_DATE, MODIFY_DATE, CRBY, MODBY, MACHINENAME) " +
                        " VALUES (@dbId, @EmpType, @EmpTypeName, @OTFormula, @MinOT, " +
                        " @LateComingGraceTime, @EarlyGoingGraceTime, @CalculateHalfDay, @HalfDayMins, " +
                        " @CalculateAbsentDay, @AbsentDayMins, @MarkWOHasBothDayAbsent, " +
                        " @STDate, @ModifyDate, @CrBy, @ModBy, @MachineName) ";
                }
                else
                {
                    strSaveQry = "UPDATE EMPTYPEMAST " +
                        " SET EmpType = @EmpType, EmpTypeName = @EmpTypeName, OTFormula = @OTFormula, " +
                        " MinOT = @MinOT, LateComingGraceTime = @LateComingGraceTime, " +
                        " EarlyGoingGraceTime = @EarlyGoingGraceTime, CalculateHalfDay = @CalculateHalfDay, " +
                        " HalfDayMins = @HalfDayMins, CalculateAbsentDay = @CalculateAbsentDay, " +
                        " AbsentDayMins = @AbsentDayMins, MarkWOHasBothDayAbsent = @MarkWOHasBothDayAbsent, " +
                        " MODIFY_DATE = @ModifyDate, MODBY = @ModBy, MACHINENAME = @MachineName " +
                        " WHERE DBID = @dbId";
                }

                try
                {
                    SqlCommand objCmd = Conn.CreateCommand();
                    objCmd.CommandType = CommandType.Text;
                    objCmd.CommandText = strSaveQry;

                    objCmd.Parameters.AddWithValue("@EmpType", objEmpType.EmpTypeCode);
                    objCmd.Parameters.AddWithValue("@EmpTypeName", objEmpType.EmpTypeName);
                    objCmd.Parameters.AddWithValue("@OTFormula", objEmpType.OTFormula);
                    objCmd.Parameters.AddWithValue("@MinOT", objEmpType.MinOT);
                    objCmd.Parameters.AddWithValue("@LateComingGraceTime", objEmpType.LateComingGraceTime);
                    objCmd.Parameters.AddWithValue("@EarlyGoingGraceTime", objEmpType.EarlyGoingGraceTime);
                    objCmd.Parameters.AddWithValue("@CalculateHalfDay", objEmpType.CalculateHalfDay);
                    objCmd.Parameters.AddWithValue("@HalfDayMins", objEmpType.HalfDayMins);
                    objCmd.Parameters.AddWithValue("@CalculateAbsentDay", objEmpType.CalculateAbsentDay);
                    objCmd.Parameters.AddWithValue("@AbsentDayMins", objEmpType.AbsentDayMins);
                    objCmd.Parameters.AddWithValue("@MarkWOHasBothDayAbsent", objEmpType.MarkWOHasBothDayAbsent);

                    if (objEmpType.IsNew)
                    {
                        objCmd.Parameters.AddWithValue("@StDate", DateTime.Now);
                        objCmd.Parameters.AddWithValue("@CrBy", CurrentCompany.m_UserName);
                        objEmpType.DBID = General.GenerateDBID("SEQEMPTYPEID", Conn);
                    }
                    objCmd.Parameters.AddWithValue("@ModifyDate", DateTime.Now);
                    objCmd.Parameters.AddWithValue("@ModBy", CurrentCompany.m_UserName);
                    objCmd.Parameters.AddWithValue("@MachineName", General.GetMachineName());
                    objCmd.Parameters.AddWithValue("@dbID", objEmpType.DBID);

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
                ObjDelCmd.CommandText = "DELETE FROM EMPTYPEMAST WHERE DBID = @dbID";
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
        /// This method Checks whether Current Employee-Type already exists in Database or not.
        /// </summary>
        /// <param name="objEmpType">Object Containing New Data Values.</param>
        /// <returns>Boolean value True if Current Record already exists
        /// otherwise returns False indicating current Record Does not exist.</returns>
        public static bool IsEmpTypeExist(EmpType objEmpType)
        {
            bool IsRecordExist = false;
            using (SqlConnection Conn = new SqlConnection(General.GetSQLConnectionString()))
            {
                try
                {
                    SqlCommand objCmd = Conn.CreateCommand();
                    objCmd.CommandType = CommandType.Text;
                    objCmd.CommandText = "SELECT DBID FROM EMPTYPEMAST " +
                        " WHERE EMPTYPE = @EmpType " +
                        " AND DBID <> @dbID ";

                    objCmd.Parameters.AddWithValue("@EmpType", objEmpType.EmpTypeCode);
                    objCmd.Parameters.AddWithValue("@dbID", objEmpType.DBID);

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
        /// This method Checks whether Employee-Type is used with Employee or not.
        /// </summary>
        /// <param name="dbid">Unique ID of the record to be Checked whether it is used or not.</param>
        /// <returns>Boolean value True if Current Record already used
        /// otherwise returns False indicating current Record Does not Used.</returns>
        public static bool IsEmpTypeUsed(long dbid)
        {
            bool IsRecordUsed = false;
            using (SqlConnection Conn = new SqlConnection(General.GetSQLConnectionString()))
            {
                try
                {
                    SqlCommand objCmd = Conn.CreateCommand();
                    objCmd.CommandType = CommandType.Text;
                    objCmd.CommandText = "SELECT DBID FROM EMPMAST " +
                        " WHERE DBID <> @dbID ";

                    objCmd.Parameters.AddWithValue("@dbID", dbid);

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
                                IsRecordUsed = true;
                            }
                        }
                        else
                        {
                            IsRecordUsed = false;
                        }
                    }
                }
                catch (ApplicationException ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return IsRecordUsed;
        }
    }
}
