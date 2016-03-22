using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityObject
{
    public class Shift: BrokenRule
    {
        #region Private Variable(s)
        private bool flgNew;
        private bool flgEdited;
        private bool flgDeleted;
        private bool flgLoading;
        //private bool flgUpload;

        private long dbID;
        private string shiftCode;
        private string shiftName;
        private string sBeginTime;
        private string sEndTime;
        private int shiftDuration;
        private int punchBeginMins;
        private int punchEndMins;
        private int isGraceTimeApplicable;
        private string graceTimeMins;
        #endregion

        public Shift()
        {
            flgNew = true;
            flgEdited = false;
            flgDeleted = false;

            dbID = 0;
            shiftCode = string.Empty;
            shiftName = string.Empty;
            sBeginTime = string.Empty;
            sEndTime = string.Empty;
            shiftDuration = 0;
            punchBeginMins = 0;
            punchEndMins = 0;
            isGraceTimeApplicable = 0;
            graceTimeMins = string.Empty;

            RuleBroken("ShiftCode", true);
            RuleBroken("ShiftName", true);
            RuleBroken("ShiftBeginTime", true);
            RuleBroken("ShiftEndTime", true);
        }

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

        //public bool IsUpload
        //{
        //    get
        //    {
        //        return flgUpload;
        //    }
        //    set
        //    {
        //        flgUpload = value;
        //    }
        //}

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
                    if (value.Trim().Length > 50)
                    {
                        throw new Exception("Length can not be greater than 50 character(s).");
                    }
                }
                RuleBroken("ShiftCode", (value.Trim().Length == 0));
                shiftCode = value.Trim().ToUpper();
                flgEdited = true;
            }
        }

        public string ShiftName
        {
            get
            {
                return shiftName;
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
                RuleBroken("ShiftName", (value.Trim().Length == 0));
                shiftName = value.Trim().ToUpper();
                flgEdited = true;
            }
        }

        public string ShiftBeginTime
        {
            get
            {
                return sBeginTime;
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
                RuleBroken("ShiftBeginTime", (value.Trim().Length == 0));
                sBeginTime = value.Trim().ToUpper();
                flgEdited = true;
            }
        }

        public string ShiftEndTime
        {
            get
            {
                return sEndTime;
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
                RuleBroken("ShiftEndTime", (value.Trim().Length == 0));
                sEndTime = value.Trim().ToUpper();
                flgEdited = true;
            }
        }

        public int ShiftDuration
        {
            get
            {
                return shiftDuration;
            }
            set
            {
                if (!flgLoading)
                {
                    
                }
                shiftDuration = value;
                flgEdited = true;
            }
        }

        public int PunchBeginMins
        {
            get
            {
                return punchBeginMins;
            }
            set
            {
                if (!flgLoading)
                {

                }
                punchBeginMins = value;
                flgEdited = true;
            }
        }

        public int PunchEndMins
        {
            get
            {
                return punchEndMins;
            }
            set
            {
                if (!flgLoading)
                {

                }
                punchEndMins = value;
                flgEdited = true;
            }
        }

        public int IsGraceTimeApplicable
        {
            get
            {
                return isGraceTimeApplicable;
            }
            set
            {
                if (!flgLoading)
                {

                }
                isGraceTimeApplicable = value;
                flgEdited = true;
            }
        }

        public string GraceTimeMins
        {
            get
            {
                return graceTimeMins;
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
                graceTimeMins = value.Trim().ToUpper();
                flgEdited = true;
            }
        }
        #endregion
    }
}
