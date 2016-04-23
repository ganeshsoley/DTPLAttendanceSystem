using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityObject;
using EntityObject.Enum;
using BLL;

namespace AttendanceSystem
{
    public partial class frmLeaveEntryProp : Form
    {
        #region Private Variable(s)
        private bool flgNew;
        private bool flgLoading;

        private LeaveApplication objLeaveApplication;
        #endregion

        #region Constructor(s)
        public frmLeaveEntryProp()
        {
            InitializeComponent();
        }

        public frmLeaveEntryProp(LeaveApplication objLVApplication)
        {
            objLeaveApplication = objLVApplication;
            InitializeComponent();
        }
        #endregion

        /// <summary>
        /// Contains Public Properties of Form that are accessible through out the Project.
        /// </summary>
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
        #endregion

        #region Delegate & Event
        public delegate void LeaveApplicationUpdateHandler(object sender, LeaveApplicationUpdateEventArgs e, DataEventType Action);

        public event LeaveApplicationUpdateHandler Entry_DataChanged;
        #endregion

        #region Private Methods
        private void EnableDisableSave()
        {
            btnSave.Enabled = objLeaveApplication.IsValid;
        }

        private void LeaveApplication_OnValid(object sender, EventArgs e)
        {
            EnableDisableSave();
        }

        private void LeaveApplication_OnInValid(object sender, EventArgs e)
        {
            EnableDisableSave();
        }

        private void SubscribeToEvents()
        {
            objLeaveApplication.OnValid += new EmpType.EventHandler(LeaveApplication_OnValid);
            objLeaveApplication.OnInvalid += new EmpType.EventHandler(LeaveApplication_OnInValid);
        }
        #endregion

        #region UI Control Logic
        private void frmLeaveEntryProp_Load(object sender, EventArgs e)
        {
            Icon = new Icon("Images/DTPL.ico");
            flgLoading = true;
            LeaveApplication_OnInValid(sender, e);

            if (objLeaveApplication.IsNew)
            {
                Text += " [ NEW ]";
            }
            else
            {
                this.Text += " [ " + objLeaveApplication.EmpName + " ]";
            }
            txtEmpID.Text = objLeaveApplication.EmpCode;
            txtEmpName.Text = objLeaveApplication.EmpName;
            txtEmpDept.Text = objLeaveApplication.EmpDept;
            txtLeaveType.Text = objLeaveApplication.LeaveType;
            dtpFromDate.Value = objLeaveApplication.FromDate;
            dtpToDate.Value = objLeaveApplication.ToDate;
            txtReason.Text = objLeaveApplication.LeaveReason;
            if (objLeaveApplication.IsHalfDay == 1)
                chkHalfDay.Checked = true;
            else
            {
                chkHalfDay.Checked = false;
            }

            if (objLeaveApplication.IsCOff == 1)
            {
                chkIsCoff.Checked = true;
                txtCOffDt.Visible = true;
                txtCOffDt.Text = objLeaveApplication.COffDate;
            }
            else
            {
                chkIsCoff.Checked = false;
                txtCOffDt.Visible = false;
            }

            SubscribeToEvents();
            flgLoading = false;
        }

        private void btnEmpList_Click(object sender, EventArgs e)
        {
            frmEmployeeList frmList = new frmEmployeeList();
            frmList.IsList = true;
            frmList.ShowDialog();

            if (!frmList.IsListCancel)
            {
                objLeaveApplication.EmployeeID = frmList.DBID;
                objLeaveApplication.EmpCode = frmList.EmpCode;
                objLeaveApplication.EmpName = frmList.Initials;
                objLeaveApplication.EmpDept = frmList.DeptName;

                txtEmpID.Text = objLeaveApplication.EmpCode;
                txtEmpName.Text = objLeaveApplication.EmpName;
                txtEmpDept.Text = objLeaveApplication.EmpDept;

                SendKeys.Send("TAB");
            }
            frmList.Dispose();
        }

        private void btnLeaveTypeList_Click(object sender, EventArgs e)
        {
            frmLeaveTypeList frmList = new frmLeaveTypeList();
            frmList.IsList = true;
            frmList.ShowDialog();

            if (!frmList.IsListCancel)
            {
                objLeaveApplication.LeaveTypeID = frmList.DBID;
                objLeaveApplication.LeaveType = frmList.LeaveCode;

                txtLeaveType.Text = objLeaveApplication.LeaveType;
                SendKeys.Send("TAB");
            }
            frmList.Dispose();
        }

        private void dtpFromDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (!IsLoading)
                {
                    objLeaveApplication.FromDate = dtpFromDate.Value;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dtpToDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (!IsLoading)
                {
                    objLeaveApplication.ToDate = dtpToDate.Value;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtReason_Enter(object sender, EventArgs e)
        {
            txtReason.SelectAll();
        }

        private void txtReason_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!IsLoading)
                {
                    objLeaveApplication.LeaveReason = txtReason.Text.Trim();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtReason_Leave(object sender, EventArgs e)
        {
            txtReason.Text = objLeaveApplication.LeaveReason;
        }

        private void chkHalfDay_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (!IsLoading)
                {
                    if (chkHalfDay.Checked)
                        objLeaveApplication.IsHalfDay = 1;
                    else
                        objLeaveApplication.IsHalfDay = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void chkIsCoff_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (!IsLoading)
                {
                    if (chkIsCoff.Checked)
                    {
                        objLeaveApplication.IsCOff = 1;
                        txtCOffDt.Enabled = true;
                    }
                    else
                    {
                        objLeaveApplication.IsCOff = 0;
                        txtCOffDt.Enabled = false;
                        txtCOffDt.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtCOffDt_Enter(object sender, EventArgs e)
        {
            txtCOffDt.SelectAll();
        }

        private void txtCOffDt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!IsLoading)
                {
                    DateTime dt;
                    if (GeneralMethods.IsDate(txtCOffDt.Text, out dt) & txtCOffDt.Text.Trim().Length == 10)
                    {
                        objLeaveApplication.COffDate = txtCOffDt.Text.Trim();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtCOffDt_Leave(object sender, EventArgs e)
        {
            txtCOffDt.Text = objLeaveApplication.COffDate;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                bool flgApplyEdit;
                flgApplyEdit = LeaveApplicationManager.Save(objLeaveApplication);
                if (flgApplyEdit)
                {
                    // instance the event args and pass it value
                    LeaveApplicationUpdateEventArgs args = new LeaveApplicationUpdateEventArgs(objLeaveApplication.DBID, objLeaveApplication.EmpCode, objLeaveApplication.EmpName, objLeaveApplication.EmpDept, objLeaveApplication.FromDate, objLeaveApplication.ToDate, objLeaveApplication.LeaveType);

                    // raise event wtth  updated 
                    if (Entry_DataChanged != null)
                    {
                        if (this.IsNew)
                        {
                            Entry_DataChanged(this, args, DataEventType.INSERT_EVENT);
                        }
                        else
                        {
                            Entry_DataChanged(this, args, DataEventType.UPDATE_EVENT);
                        }
                    }

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Record Not Saved.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        #endregion

        private void dtpFromDate_Leave(object sender, EventArgs e)
        {

        }

        private void dtpToDate_Leave(object sender, EventArgs e)
        {

        }
    }

    public class LeaveApplicationUpdateEventArgs : EventArgs
    {
        private long mDBID;
        private string mEmpID;
        private string mEmpName;
        private string mEmpDept;
        private DateTime mFromDate;
        private DateTime mToDate;
        private string mLeaveType;

        public LeaveApplicationUpdateEventArgs(long sDBID, string sEmpID, string sEmpName, string sEmpDept, DateTime sFromDate, DateTime sToDate, string sLeaveType)
        {
            mDBID = sDBID;
            mEmpID = sEmpID;
            mEmpName = sEmpName;
            mEmpDept = sEmpDept;
            mFromDate = sFromDate;
            mToDate = sToDate;
            mLeaveType = sLeaveType;
        }

        public long DBID
        {
            get
            {
                return mDBID;
            }
        }

        public string EmpID
        {
            get
            {
                return mEmpID;
            }
        }

        public string EmpName
        {
            get
            {
                return mEmpName;
            }
        }

        public string EmpDept
        {
            get
            {
                return mEmpDept;
            }
        }

        public DateTime FromDate
        {
            get
            {
                return mFromDate;
            }
        }

        public DateTime ToDate
        {
            get
            {
                return mToDate;
            }
        }

        public string LeaveType
        {
            get
            {
                return mLeaveType;
            }
        }
    }
}
