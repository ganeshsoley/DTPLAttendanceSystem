using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityObject
{
    public class EmployeeLeave: BrokenRule
    {
        #region Private Variable(s)
        private bool flgNew;
        private bool flgEdited;
        private bool flgDeleted;
        private bool flgLoading;

        private long dbID;
        private long employeeID;
        private string employeeName;
        private string empDept;
        private long leaveTypeID;
        private string leaveType;
        private decimal allowedLeaves;
        #endregion

        #region Constructor(s)
        public EmployeeLeave()
        {
            flgNew = true;
            flgEdited = false;
            flgDeleted = false;

            dbID = 0;
            employeeID = 0;
            employeeName = string.Empty;
            empDept = string.Empty;
            leaveTypeID = 0;
            leaveType = string.Empty;
            allowedLeaves = 0;

            RuleBroken("Employee", true);
            RuleBroken("LeaveType", true);
            RuleBroken("AllowedLeaves", true);
        }
        #endregion

        #region Public Properties
        public bool IsNew
        {
            get
            {
                return flgNew;
            }
            set
            {
                flgNew = value;
            }
        }

        public bool IsDeleted
        {
            get
            {
                return flgDeleted;
            }
            set
            {
                flgDeleted = value;
            }
        }

        public bool IsEdited
        {
            get
            {
                return flgEdited;
            }
            set
            {
                flgEdited = value;
            }
        }

        public bool IsLoading
        {
            get
            {
                return flgLoading;
            }
            set
            {
                flgLoading = value;
            }
        }

        public long DBID
        {
            get
            {
                return dbID;
            }
            set
            {
                dbID = value;
            }
        }

        public long EmployeeID
        {
            get
            {
                return employeeID;
            }
            set
            {
                if (!flgLoading)
                {
                }
                RuleBroken("Employee", (value == 0));
                employeeID = value;
                flgEdited = true;
            }
        }

        public string EmployeeName
        {
            get
            {
                return employeeName;
            }
            set
            {
                employeeName = value.Trim().ToUpper();
            }
        }

        public string EmpDept
        {
            get
            {
                return empDept;
            }
            set
            {
                empDept = value.Trim().ToUpper();
            }
        }

        public long LeaveTypeID
        {
            get
            {
                return leaveTypeID;
            }
            set
            {
                if (!flgLoading)
                {

                }
                RuleBroken("LeaveType", (value == 0));
                leaveTypeID = value;
                flgEdited = true;
            }
        }

        public string LeaveType
        {
            get
            {
                return leaveType;
            }
            set
            {
                leaveType = value.Trim().ToUpper();
            }
        }

        public decimal AllowedLeaves
        {
            get
            {
                return allowedLeaves;
            }
            set
            {
                if (!flgLoading)
                {
                }
                allowedLeaves = value;
                flgEdited = true;
            }
        }
        #endregion
    }
}
