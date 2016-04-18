using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityObject
{
    public class EmpType: BrokenRule
    {
        #region Private Variable(s)
        private bool flgNew;
        private bool flgEdited;
        private bool flgDeleted;
        private bool flgLoading;

        private long dbID;
        private string empTypeCode;
        private string empTypeName;
        private string otFormula;
        private string minOT;
        private string lcGraceTime;
        private string egGraceTime;
        private int calculateHalfDay;
        private string halfDayMins;
        private int calculateAbsentDay;
        private string absentDayMins;
        private int markWOHasBothDayAbsent;
        #endregion

        public EmpType()
        {
            flgNew = true;
            flgEdited = false;
            flgDeleted = false;

            dbID = 0;
            empTypeCode = string.Empty;
            empTypeName = string.Empty;
            otFormula = string.Empty;
            minOT = string.Empty;
            lcGraceTime = string.Empty;
            egGraceTime = string.Empty;
            calculateHalfDay = 0;
            halfDayMins = string.Empty;
            calculateAbsentDay = 0;
            absentDayMins = string.Empty;
            markWOHasBothDayAbsent = 0;

            RuleBroken("EmpTypeCode", true);
            RuleBroken("EmpType", true);
            RuleBroken("OTFormula", true);
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

        public string EmpTypeCode
        {
            get
            {
                return empTypeCode;
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
                RuleBroken("EmpTypeCode", (value.Trim().Length == 0));
                empTypeCode = value.Trim().ToUpper();
                flgEdited = true;
            }
        }

        public string EmpTypeName
        {
            get
            {
                return empTypeName;
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
                RuleBroken("EmpType", (value.Trim().Length == 0));
                empTypeName = value.Trim().ToUpper();
                flgEdited = true;
            }
        }

        public string OTFormula
        {
            get
            {
                return otFormula;
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
                RuleBroken("OTFormula", (value.Trim().Length == 0));
                otFormula = value.Trim().ToUpper();
                flgEdited = true;
            }
        }

        public string MinOT
        {
            get
            {
                return minOT;
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
                minOT = value.Trim().ToUpper();
                flgEdited = true;
            }
        }

        public string LateComingGraceTime
        {
            get
            {
                return lcGraceTime;
            }
            set
            {
                if (!flgLoading)
                {
                    if (value.Trim().Length > 20)
                    {
                        throw new Exception("Length can not be greater than 20 character(s).");
                    }
                }
                lcGraceTime = value.Trim().ToUpper();
                flgEdited = true;
            }
        }

        public string EarlyGoingGraceTime
        {
            get
            {
                return egGraceTime;
            }
            set
            {
                if (!flgLoading)
                {
                    if (value.Trim().Length > 20)
                    {
                        throw new Exception("Length can not be greater than 20 character(s).");
                    }
                }
                egGraceTime = value.Trim().ToUpper();
                flgEdited = true;
            }
        }

        public int CalculateHalfDay
        {
            get
            {
                return calculateHalfDay;
            }
            set
            {
                if (!flgLoading)
                { }
                calculateHalfDay = value;
                flgEdited = true;
            }
        }

        public string HalfDayMins
        {
            get
            {
                return halfDayMins;
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
                halfDayMins = value;
                flgEdited = true;
            }
        }

        public int CalculateAbsentDay
        {
            get
            {
                return calculateAbsentDay;
            }
            set
            {
                if (!flgLoading)
                {

                }
                calculateAbsentDay = value;
                flgEdited = true;
            }
        }

        public string AbsentDayMins
        {
            get
            {
                return absentDayMins;
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
                absentDayMins = value;
                flgEdited = true;
            }
        }

        public int MarkWOHasBothDayAbsent
        {
            get
            {
                return markWOHasBothDayAbsent;
            }
            set
            {
                if (!flgLoading)
                {
                }
                markWOHasBothDayAbsent = value;
                flgEdited = true;
            }
        }
        #endregion
    }
}
