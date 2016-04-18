using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityObject
{
    public class LeaveType: BrokenRule
    {
        #region Private Variable(s)
        private bool flgNew;
        private bool flgEdited;
        private bool flgDeleted;
        private bool flgLoading;

        private long dbID;
        private string leaveTypeCode;
        private string leaveTypeName;
        private string yearlyLimit;
        private int carryFwdLimit;
        private int flgAddMonthly;
        private int addMonthlyLV;
        private string gender;
        private string considerAs;
        private int isAllowNegativeBal;
        #endregion

        #region Constructor(s)
        public LeaveType()
        {
            flgNew = true;
            flgEdited = false;
            flgDeleted = false;

            dbID = 0;
            leaveTypeCode = string.Empty;
            leaveTypeName = string.Empty;
            yearlyLimit = string.Empty;
            carryFwdLimit = 0;
            flgAddMonthly = 0;
            addMonthlyLV = 0;
            gender = string.Empty;
            considerAs = string.Empty;
            isAllowNegativeBal = 0;

            RuleBroken("LeaveTypeCode", true);
            RuleBroken("LeaveTypeName", true);
            RuleBroken("YearlyLimit", true);
            RuleBroken("ConsiderAs", true);
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

        public string LeaveTypeCode
        {
            get
            {
                return leaveTypeCode;
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
                RuleBroken("LeaveTypeCode", (value.Trim().Length == 0));
                leaveTypeCode = value.Trim().ToUpper();
                flgEdited = true;
            }
        }

        public string LeaveTypeName
        {
            get
            {
                return leaveTypeName;
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
                RuleBroken("LeaveTypeName", (value.Trim().Length == 0));
                leaveTypeName = value.Trim().ToUpper();
                flgEdited = true;
            }
        }

        public string YearlyLimit
        {
            get
            {
                return yearlyLimit;
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
                RuleBroken("YearlyLimit", (value.Trim().Length == 0));
                yearlyLimit = value.Trim().ToUpper();
                flgEdited = true;
            }
        }

        public int CarryFwdLimit
        {
            get
            {
                return carryFwdLimit;
            }
            set
            {
                if (!flgLoading)
                {
                }
                carryFwdLimit = value;
                flgEdited = true;
            }
        }

        public int IsAddMonthly
        {
            get
            {
                return flgAddMonthly;
            }
            set
            {
                if (!flgLoading)
                {
                }
                flgAddMonthly = value;
                flgEdited = true;
            }
        }

        public int AddMonthlyLV
        {
            get
            {
                return addMonthlyLV;
            }
            set
            {
                if (!flgLoading)
                {
                }
                addMonthlyLV = value;
                flgEdited = true;
            }
        }

        public string ApplicableGender
        {
            get
            {
                return gender;
            }
            set
            {
                if (!flgLoading)
                {
                    if (value.Trim().Length > 10)
                    {
                        throw new Exception("Length can not be greater than 10 character(s).");
                    }
                }
                gender = value.Trim().ToUpper();
                flgEdited = true;
            }
        }

        public string ConsiderAs
        {
            get
            {
                return considerAs;
            }
            set
            {
                if (!flgLoading)
                {
                    if (value.Trim().Length > 255)
                    {
                        throw new Exception("Length can not be greater than 255 character(s).");
                    }
                }
                RuleBroken("ConsiderAs", (value.Trim().Length == 0));
                considerAs = value.Trim().ToUpper();
                flgEdited = true;
            }
        }

        public int IsAllowNegativeBal
        {
            get
            {
                return isAllowNegativeBal;
            }
            set
            {
                if (!flgLoading)
                {
                }
                isAllowNegativeBal = value;
                flgEdited = true;
            }
        }
        #endregion
    }
}
