using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityObject
{
    public class LeaveApplication: BrokenRule
    {
        #region Private Variable(s)
        private bool flgNew;
        private bool flgEdited;
        private bool flgDeleted;
        private bool flgLoading;

        private long dbID;
        private long leaveTypeID;
        private string leaveType;
        private long empID;
        private string empName;
        private string empDept;
        private string leaveReason;
        private DateTime dtFromDate;
        private DateTime dtToDate;
        private int totalLeavees;
        private int isLvApproved;
        private int isHRApproved;
        private int isHalfDay;
        private int isCOff;
        private string coffDate;
        
        #endregion

        #region Constructor(s)
        public LeaveApplication()
        {
            flgNew = true;
            flgEdited = false;
            flgDeleted = false;

            dbID = 0;
            leaveTypeID = 0;
            leaveType = string.Empty;
            empID = 0;
            empName = string.Empty;
            empDept = string.Empty;
            leaveReason = string.Empty;
            dtFromDate = DateTime.MinValue;
            dtToDate = DateTime.MinValue;
            totalLeavees = 0;
            isLvApproved = 0;
            isHRApproved = 0;
            isHalfDay = 0;
            isCOff = 0;
            coffDate = string.Empty;

            RuleBroken("EmpID", true);
            RuleBroken("LeaveTypeID", true);
            RuleBroken("FromDate", true);
            RuleBroken("ToDate", true);
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
                RuleBroken("LeaveTypeID", (value == 0));
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

        public long EmployeeID
        {
            get
            {
                return empID;
            }
            set
            {
                RuleBroken("EmpID", (value == 0));
                empID = value;
                flgEdited = true;
            }
        }

        public string EmpName
        {
            get
            {
                return empName;
            }
            set
            {
                empName = value.Trim().ToUpper();
                flgEdited = true;
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
                flgEdited = true;
            }
        }

        public string LeaveReason
        {
            get
            {
                return leaveReason;
            }
            set
            {
                if (!flgLoading)
                {
                    if (value.Trim().Length > 50)
                    {
                        throw new Exception("Length can not be greater than 50 character(s).");
                    }
                }
                leaveReason = value.Trim().ToUpper();
                flgEdited = true;
            }
        }
     
        public DateTime FromDate
        {
            get
            {
                return dtFromDate;
            }
            set
            {
                if (!flgLoading)
                {
                }
                RuleBroken("FromDate", (value == DateTime.MinValue));
                dtFromDate = value;
                flgEdited = true;
            }
        }

        public DateTime ToDate
        {
            get
            {
                return dtToDate;
            }
            set
            {
                if (!flgLoading)
                {
                }
                RuleBroken("ToDate", (value == DateTime.MinValue));
                dtToDate = value;
                flgEdited = true;
            }
        }

        public int TotalLeaves
        {
            get
            {
                return totalLeavees;
            }
            set
            {
                if (!flgLoading)
                {
                    if (value <= 0)
                        throw new Exception("Check From Date and To Date, as Leave Duration Can not be Less than or Equal to Zero (0).");
                }
                totalLeavees = value;
                flgEdited = true;
            }
        }

        public int IsLeaveApproved
        {
            get
            {
                return isLvApproved;
            }
            set
            {
                if (!flgLoading)
                {
                }
                isLvApproved = value;
                flgEdited = true;
            }
        }

        public int IsHRApproved
        {
            get
            {
                return isHRApproved;
            }
            set
            {
                if (!flgLoading)
                {
                }
                isHRApproved = value;
                flgEdited = true;
            }
        }

        public int IsHalfDay
        {
            get
            {
                return isHalfDay;
            }
            set
            {
                if (!flgLoading)
                {
                }
                isHalfDay = value;
                flgEdited = true;
            }
        }

        public int IsCOff
        {
            get
            {
                return isCOff;
            }
            set
            {
                if (!flgLoading)
                {
                }
                isCOff = value;
                flgEdited = true;
            }
        }

        public string COffDate
        {
            get
            {
                return coffDate;
            }
            set
            {
                if (!flgLoading)
                {
                }
                coffDate = value.Trim().ToUpper();
                flgEdited = true;
            }
        }
        #endregion
    }
}
