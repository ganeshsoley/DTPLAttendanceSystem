using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using EntityObject;
using DAL;

namespace BLL
{
    public class EmployeeManager
    {
        /// <summary>
        /// Retrieves Employee List from Database.
        /// </summary>
        /// <param name="strWhere">Condition based on which List is retrieved.</param>
        /// <returns>Employee List</returns>
        public static EmployeeList GetList(string strWhere)
        {
            return EmployeeDAL.GetList(strWhere);
        }

        /// <summary>
        /// Retrieves Employee Data from Database.
        /// </summary>
        /// <param name="dbid"></param>
        /// <returns></returns>
        public static Employee GetItem(long dbid)
        {
            Employee objEmp;
            objEmp = EmployeeDAL.GetItem(dbid);
            if (objEmp != null)
            {
                objEmp.EmpLeaves = EmpLeaveDAL.GetList(objEmp.DBID);
            }
            return objEmp;
        }

        /// <summary>
        /// Save Object Data into Database.
        /// </summary>
        /// <param name="objEmp">Employee Object containing property values.</param>
        /// <returns>Employee Object to be Saved.</returns>
        public static bool Save(Employee objEmp)
        {
            bool flgSave;
            try
            {
                using (TransactionScope objTScope = new TransactionScope(TransactionScopeOption.RequiresNew))
                {
                    if (objEmp.IsEdited || objEmp.IsNew)
                    {
                        EmployeeDAL.Save(objEmp);
                    }
                    if (objEmp.EmpLeaves != null)
                    {
                        foreach (EmployeeLeave objEmpLeave in objEmp.EmpLeaves)
                        {
                            if (objEmpLeave.IsDeleted && !objEmpLeave.IsNew)
                            {
                                EmpLeaveDAL.Delete(objEmpLeave.DBID);
                            }
                            else if ((objEmpLeave.IsEdited || objEmpLeave.IsNew) && !objEmpLeave.IsDeleted)
                            {
                                objEmpLeave.EmployeeID = objEmp.DBID;
                                objEmpLeave.EmployeeName = objEmp.Initials;
                                objEmpLeave.EmpDept = objEmp.DeptName;
                                EmpLeaveDAL.Save(objEmpLeave);
                            }
                        }
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
        /// <param name="objEmp">Object containing all data values.</param>
        /// <returns>boolean value True if Record is deleted successfully 
        /// otherwise returns False.</returns>
        public static bool Delete(Employee objEmp)
        {
            bool recDel;
            recDel = EmployeeDAL.Delete(objEmp.DBID);
            return recDel;
        }

        /// <summary>
        /// Checks whether current Record already exists or not.
        /// </summary>
        /// <param name="objEmp">Object containing all Data Values.</param>
        /// <returns>boolean value True if Record already Exists into Database
        /// otherwise returns False.</returns>
        public static bool IsEmployeeExist(Employee objEmp)
        {
            return EmployeeDAL.IsEmployeeExist(objEmp);
        }

    }
}
