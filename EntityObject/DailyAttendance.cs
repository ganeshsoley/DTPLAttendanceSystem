using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityObject
{
    public class DailyAttendance: BrokenRule
    {
        #region Private Variable(s)
        private bool flgNew;
        private bool flgEdited;
        private bool flgDeleted;
        private bool flgLoading;

        private long dbID;
        private DateTime attDate;
        private long empID;
        private string empName;
        private string empDept;
        private string inTime;
        private string outTime;
        private float duration;
        private int lateBy;
        private int earlyBy;
        private int isWeeklyOff;
        private int isHoliday;
        private int isOnLeave;
        private long leaveTypeID;
        private string leaveType;
        private long shiftID;
        private string shiftCode;
        private string shiftBeginTime;
        private string shiftEndTime;
        private float present;
        private float absent;
        private int isOnSpecialOff;
        private string specialOffType;

        #endregion

        #region Constructor(s)
        public DailyAttendance()
        {
            flgNew = true;
            flgEdited = false;
            flgDeleted = false;

            dbID = 0;
        }
        #endregion

        #region PUblic Properties
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

        public DateTime AttDate
        {
            get
            {
                return attDate;
            }
            set
            {
                if (!flgLoading)
                {
                }
                RuleBroken("AttDate", (value == DateTime.MinValue));
                attDate = value;
                flgEdited = true;
            }
        }

        public long EmpID
        {
            get
            {
                return empID;
            }
            set
            {
                if (!flgLoading)
                {
                }
                RuleBroken("Employee", (value == 0));
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
                if (!flgLoading)
                {
                }
                empName = value.Trim().ToUpper();
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
        public string InTime
        {
            get
            {
                return inTime;
            }
            set
            {
                if (!flgLoading)
                {
                }
                inTime = value;
                flgEdited = true;
            }
        }

        public string OutTime
        {
            get
            {
                return outTime;
            }
            set
            {
                if (!flgLoading)
                {
                }
                outTime = value;
                flgEdited = true;
            }
        }

        public float Duration
        {
            get
            {
                return duration;
            }
            set
            {
                if (!flgLoading)
                {
                }
                duration = value;
                flgEdited = true;
            }
        }

        public int LateByMins
        {
            get
            {
                return lateBy;
            }
            set
            {
                if (!flgLoading)
                {
                }
                lateBy = value;
                flgEdited = true;
            }
        }
        public int EarlyByMins
        {
            get
            {
                return earlyBy;
            }
            set
            {
                if (!flgLoading)
                {
                }
                earlyBy = value;
                flgEdited = true;
            }
        }

        public int IsWeeklyOff
        {
            get
            {
                return isWeeklyOff;
            }
            set
            {
                if (!flgLoading)
                {
                }
                isWeeklyOff = value;
                flgEdited = true;
            }
        }

        public int IsHoliday
        {
            get
            {
                return isHoliday;
            }
            set
            {
                if (!flgLoading)
                {
                }
                isHoliday = value;
                flgEdited = true;
            }
        }

        public int IsOnLeave
        {
            get
            {
                return isOnLeave;
            }
            set
            {
                if (!flgLoading)
                {
                }
                isOnLeave = value;
                flgEdited = true;
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
                LeaveTypeID = value;
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
                if (!flgLoading)
                {
                }
                leaveType = value;
            }
        }

        public long ShiftID
        {
            get
            {
                return shiftID;
            }
            set
            {
                if (!flgLoading)
                {
                }
                shiftID = value;
                flgEdited = true;
            }
        }

        public string ShiftCode
        {
            get
            {
                return shiftCode;
            }
            set
            {
                if (!flgLoading)
                {
                }
                shiftCode = value;
            }
        }

        public string ShiftBeginTime
        {
            get
            {
                return shiftBeginTime;
            }
            set
            {
                if (!flgLoading)
                {
                }
                shiftBeginTime = value;
                flgEdited = true;
            }
        }

        public string ShiftEndTime
        {
            get
            {
                return shiftEndTime;
            }
            set
            {
                if (!flgLoading)
                {
                }
                shiftEndTime = value;
                flgEdited = true;
            }
        }

        public float Present
        {
            get
            {
                return present;
            }
            set
            {
                if (!flgLoading)
                {
                }
                present = value;
                flgEdited = true;
            }
        }

        public float Absent
        {
            get
            {
                return absent;
            }
            set
            {
                if (!flgLoading)
                {
                }
                absent = value;
                flgEdited = true;
            }
        }

        public int IsOnSpecialOff
        {
            get
            {
                return isOnSpecialOff;
            }
            set
            {
                if (!flgLoading)
                {
                }
                isOnSpecialOff = value;
                flgEdited = true;
            }
        }

        public string SpecialOffType
        {
            get
            {
                return specialOffType;
            }
            set
            {
                if (!flgLoading)
                {
                }
                specialOffType = value;
                flgEdited = true;
            }
        }
        #endregion
    }
}
