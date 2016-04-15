using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityObject
{
    public class Bank : BrokenRule
    {
        #region Private Variable
        private bool flgNew;
        private bool flgEdited;
        private bool flgDeleted;
        private bool flgLoading;

        private int dbid;
        private string bankName;
        private string branch;
        private string ifscCode;
        #endregion

        #region Constructor
        public Bank()
        {
            flgNew = true;
            flgEdited = false;
            flgDeleted = false;

            dbid = 0;
            bankName = string.Empty;
            branch = string.Empty;
            ifscCode = string.Empty;

            RuleBroken("BankName", true);
            RuleBroken("Branch", true);
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

        public int DBID
        {
            get
            {
                return dbid;
            }
            set
            {
                dbid = value;
            }
        }
        public string BankName
        {
            get
            {
                return bankName;
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
                RuleBroken("BankName", (value.Trim().Length == 0));
                bankName = value.Trim().ToUpper();
                flgEdited = true;
            }
        }

        public string Branch
        {
            get
            {
                return branch;
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
                RuleBroken("Branch", (value.Trim().Length == 0));
                branch = value.Trim().ToUpper();
                flgEdited = true;
            }
        }

        public string IFSCCode
        {
            get
            {
                return ifscCode;
            }
            set
            {
                if (!flgLoading)
                {
                    if (value.Trim().Length > 15)
                    {
                        throw new Exception("Length can not be greater than 15 character(s).");
                    }
                }
                ifscCode = value.Trim().ToUpper();
                flgEdited = true;
            }
        }
        #endregion
    }
}
