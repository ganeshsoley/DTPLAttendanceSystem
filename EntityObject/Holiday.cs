using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityObject
{
    public class Holiday: BrokenRule
    {
        #region Private Variable(s)
        private bool flgNew;
        private bool flgEdited;
        private bool flgDeleted;
        private bool flgLoading;

        private long dbID;
        private DateTime holidayDate;
        private string holidayName;
        private string description;
        private string applicableTo;
        #endregion

        #region Constructor(s)
        public Holiday()
        {
            flgNew = true;
            flgEdited = false;
            flgDeleted = false;

            dbID = 0;
            holidayDate = DateTime.MinValue;
            holidayName = string.Empty;
            description = string.Empty;
            applicableTo = string.Empty;

            RuleBroken("HolidayDate", true);
            RuleBroken("HolidayName", true);
            RuleBroken("ApplicableTo", true);
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

        public DateTime HolidayDate
        {
            get
            {
                return holidayDate;
            }
            set
            {
                if (!flgLoading)
                {
                }
                RuleBroken("HolidayDate", (value == DateTime.MinValue));
                holidayDate = value;
                flgEdited = true;
            }
        }

        public string HolidayName
        {
            get
            {
                return holidayName;
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
                RuleBroken("HolidayName", (value.Trim().Length == 0));
                holidayName = value.Trim().ToUpper();
                flgEdited = true;
            }
        }

        public string Description
        {
            get
            {
                return description;
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
                description = value.Trim().ToUpper();
                flgEdited = true;
            }
        }

        public string ApplicableTo
        {
            get
            {
                return applicableTo;
            }
            set
            {
                if (!flgLoading)
                {
                    if (value.Trim().Length > 30)
                    {
                        throw new Exception("Length can not be greater than 30 character(s).");
                    }
                }
                RuleBroken("ApplicableTo", (value.Trim().Length == 0));
                applicableTo = value.Trim().ToUpper();
                flgEdited = true;
            }
        }
        #endregion
    }
}
