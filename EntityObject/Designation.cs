using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityObject
{
    public class Designation: BrokenRule
    {
        #region Private Variable(s)
        private bool flgNew;
        private bool flgEdited;
        private bool flgDeleted;
        private bool flgLoading;

        private long dbID;
        private string designation;
        private string description;
        #endregion

        #region Constructor(s)
        public Designation()
        {
            flgNew = true;
            flgEdited = false;
            flgDeleted = false;

            dbID = 0;
            designation = string.Empty;
            description = string.Empty;

            RuleBroken("Designation", true);
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

        public string DesigName
        {
            get
            {
                return designation;
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
                RuleBroken("Designation", (value.Trim().Length == 0));
                designation = value.Trim().ToUpper();
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
        #endregion
    }
}
