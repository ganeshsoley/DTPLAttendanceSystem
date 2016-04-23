using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityObject
{
    public class Employee : BrokenRule
    {
        #region Private Variable(s)
        private bool flgNew;
        private bool flgEdited;
        private bool flgDeleted;
        private bool flgLoading;
        private bool flgUpload;

        private long dbID;
        private string empCode;
        private string firstName;
        private string middleName;    
        private string lastName;
        private string initials;
        private int deptID;
        private string deptName;
        private long designationID;
        private string designation;
        private long empTypeID;
        private string empType;
        private long empStatusID;
        private string empStatus;
        private DateTime joinDate;
        private DateTime birthDate;
        private string empPlant;

        private string leftDate;
        private string mobile;
        private string eMail;
        private int inActive;
        private string gender;
        private long bankID;
        private string bankName;
        private string accNo;
        private string pfNO;
        private string uanNo;
        private int flgCOff;
        private int flgLWF;
        private int flgCalSalary;
        private int flgESI;
        private int flgPF;
        private int flgPT;
        #endregion

        #region Constructor(s)
        public Employee()
        {
            flgNew = true;
            flgEdited = false;
            flgDeleted = false;

            dbID = 0;
            empCode = string.Empty;
            firstName = string.Empty;
            middleName = string.Empty;
            lastName = string.Empty;
            initials = string.Empty;
            deptID = 0;
            deptName = string.Empty;
            designationID = 0;
            designation = string.Empty;
            empTypeID = 0;
            empType = string.Empty;
            empStatusID = 0;
            empStatus = string.Empty;
            empPlant = string.Empty;

            joinDate = DateTime.MinValue;
            birthDate = DateTime.MinValue;
            leftDate = string.Empty ;
            eMail = string.Empty;
            mobile = string.Empty;
            bankID = 0;
            bankName = string.Empty;
            accNo = string.Empty;
            pfNO = string.Empty;
            uanNo = string.Empty;

            inActive = 0;
            gender = string.Empty;
            flgCOff = 0;
            flgLWF = 0;
            flgCalSalary = 0;
            flgESI = 0;
            flgPF = 0;
            flgPT = 0;

            EmpLeaves = new EmpLeavesList();

            RuleBroken("EmpCode", true);
            RuleBroken("FirstName", true);
            //RuleBroken("LastName", true);
            RuleBroken("DeptID", true);
            RuleBroken("DesignationID", true);
            RuleBroken("EmpTypeID", true);
            RuleBroken("EmpStatusID", true);
            RuleBroken("JoinDate", true);
            RuleBroken("BirthDate", true);
            RuleBroken("Mobile", true);
            RuleBroken("EmpPlant", true);
            RuleBroken("Gender", true);
            
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

        public bool IsUpload
        {
            get
            {
                return flgUpload;
            }
            set
            {
                flgUpload = value;
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

        public string EmpCode
        {
            get
            {
                return empCode;
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
                RuleBroken("EmpCode", (value.Trim().Length == 0));
                empCode = value.Trim().ToUpper();
                flgEdited = true;
            }
        }

        public string FirstName
        {
            get
            {
                return firstName;
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
                RuleBroken("FirstName", (value.Trim().Length == 0));
                firstName = value.Trim().ToUpper();
                if (MiddleName != "" )
                    Initials = value.Trim().ToUpper() + " " + MiddleName.Substring(0, 1) + " " + LastName;
                else
                    Initials = value.Trim().ToUpper() + " " + LastName;
                flgEdited = true;
            }
        }

        public string MiddleName
        {
            get
            {
                return middleName;
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
                middleName = value.Trim().ToUpper();
                if (value.Trim().Length > 0)
                    Initials = FirstName + " " + value.Substring(0, 1).ToUpper() + " " + LastName;
                else
                    Initials = FirstName + " " + LastName;
                flgEdited = true;
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
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
                //RuleBroken("LastName", (value.Trim().Length == 0));
                lastName = value.Trim().ToUpper();
                if (MiddleName != "")
                    Initials = FirstName + " " + MiddleName.Substring(0, 1) + " " + value.Trim().ToUpper();
                else
                    Initials = FirstName + " " + value.Trim().ToUpper();
                flgEdited = true;
            }
        }

        public string Initials
        {
            get
            {
                return initials;
            }
            set
            {
                if (!flgLoading)
                {
                    if (value.Trim().Length > 100)
                    {
                        throw new Exception("Length can not be greater than 100 character(s).");
                    }
                }
                initials = value.Trim().ToUpper();
                flgEdited = true;
            }
        }

        public int DeptID
        {
            get
            {
                return deptID;
            }
            set
            {
                RuleBroken("DeptID", (value == 0));
                deptID = value;
                flgEdited = true;
            }
        }

        public string DeptName
        {
            get
            {
                return deptName;
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
                deptName = value.Trim().ToUpper();
            }
        }

        public long DesignationID
        {
            get
            {
                return designationID;
            }
            set
            {
                if (!flgLoading)
                {

                }
                RuleBroken("DesignationID", (value ==0));
                designationID = value;
                flgEdited = true;
            }
        }

        public string Designation
        {
            get
            {
                return designation;
            }
            set
            {
                designation = value.ToUpper();
            }
        }

        public long EmpTypeID
        {
            get
            {
                return empTypeID;
            }
            set
            {
                if (!flgLoading)
                {
                }
                RuleBroken("EmpTypeID", (value==0));
                empTypeID = value;
                flgEdited = true;
            }
        }

        public string EmpType
        {
            get
            {
                return empType;
            }
            set
            {
                empType = value.ToUpper();
            }
        }

        public long EmpStatusID
        {
            get
            {
                return empStatusID;
            }
            set
            {
                if (!flgLoading)
                {
                }
                RuleBroken("EmpStatusID", (value==0));
                empStatusID = value;
                flgEdited = true;
            }
        }

        public string EmpStatus
        {
            get
            {
                return empStatus;
            }
            set
            {
                empStatus = value.ToUpper();
            }
        }

        public DateTime JoinDate
        {
            get
            {
                return joinDate;
            }
            set
            {
                if (!flgLoading)
                {
                }
                RuleBroken("JoinDate", (value == DateTime.MinValue));
                joinDate = value;
                flgEdited = true;
            }
        }

        public DateTime BirthDate
        {
            get
            {
                return birthDate;
            }
            set
            {
                if (!flgLoading)
                {

                }
                RuleBroken("BirthDate", (value == DateTime.MinValue));
                birthDate = value;
                flgEdited = true;
            }
        }

        public string LeftDate
        {
            get
            {
                return leftDate;
            }
            set
            {
                if (!flgLoading)
                {
                }
                leftDate = value;
                flgEdited = true;
            }
        }

        public string MobileNo
        {
            get
            {
                return mobile;
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
                RuleBroken("Mobile", (value.Trim().Length == 0));
                mobile = value;
                flgEdited = true;
            }
        }

        public string EMailID
        {
            get
            {
                return eMail;
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
                eMail = value.Trim().ToUpper();
                flgEdited = true;
            }
        }

        public int InActive
        {
            get
            {
                return inActive;
            }
            set
            {
                inActive = value;
                flgEdited = true;
            }
        }

        public string EmpPlant
        {
            get
            {
                return empPlant;
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
                RuleBroken("EmpPlant", (value.Trim().Length == 0));
                empPlant = value.Trim().ToUpper();
                flgEdited = true;
            }
        }

        public string Gender
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
                        throw new Exception("Length can not be greater than 10 Character(s).");
                    }
                }
                RuleBroken("Gender", (value.Trim().Length == 0));
                gender = value.Trim().ToUpper();
                flgEdited = true;
            }
        }

        public long BankID
        {
            get
            {
                return bankID;
            }
            set
            {
                if (!flgLoading)
                {
                }
                bankID = value;
                flgEdited = true;
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
                bankName = value.ToUpper();
            }
        }

        public string AccountNo
        {
            get
            {
                return accNo;
            }
            set
            {
                if (!flgLoading)
                {
                    if (value.Trim().Length > 30)
                    {
                        throw new Exception("Length can not be greater than 30 Character(s).");
                    }
                }
                accNo = value.Trim().ToUpper();
                flgEdited = true;
            }
        }

        public string PFNo
        {
            get
            {
                return pfNO; 
            }
            set
            {
                if (!flgLoading)
                {
                    if (value.Trim().Length > 30)
                    {
                        throw new Exception("Length can not be greater than 30 Character(s).");
                    }
                }
                pfNO = value.Trim().ToUpper();
                flgEdited = true;
            }
        }

        public string UANNo
        {
            get
            {
                return uanNo;
            }
            set
            {
                if (!flgLoading)
                {
                    if (value.Trim().Length > 15)
                    {
                        throw new Exception("Length can not be greater than 15 Character(s).");
                    }
                }
                uanNo = value.Trim().ToUpper();
                flgEdited = true;
            }
        }

        public int FlgCOff
        {
            get
            {
                return flgCOff;
            }
            set
            {
                if (!flgLoading)
                { }
                flgCOff = value;
                flgEdited = true;
            }
        }

        public int FlgLWF
        {
            get
            {
                return flgLWF;
            }
            set
            {
                if (!flgLoading)
                { }
                flgLWF = value;
                flgEdited = true;
            }
        }

        public int CalculateSalary
        {
            get
            {
                return flgCalSalary;
            }
            set
            {
                if (!flgLoading)
                { }
                flgCalSalary = value;
                flgEdited = true;
            }
        }

        public int FlgESI
        {
            get
            {
                return flgESI;
            }
            set
            {
                if (!flgLoading)
                { }
                flgESI = value;
                flgEdited = true;
            }
        }

        public int CalculatePF
        {
            get
            {
                return flgPF;
            }
            set
            {
                if (!flgLoading)
                { }
                flgPF = value;
                flgEdited = true;
            }
        }

        public int CalculatePT
        {
            get
            {
                return flgPT;
            }
            set
            {
                if (!flgLoading)
                { }
                flgPT = value;
                flgEdited = true;
            }
        }
        
        public EmpLeavesList EmpLeaves
        {
            get;
            set;
        }
        #endregion
    }
}
