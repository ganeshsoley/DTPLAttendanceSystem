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
    public partial class frmShiftProp : Form
    {
        #region Private Variable(s)
        private bool flgNew;
        private bool flgLoading;

        private Shift objShift;
        #endregion

        #region Constructor(s)
        public frmShiftProp()
        {
            InitializeComponent();
        }

        public frmShiftProp(Shift objShift)
        {
            this.objShift = objShift;
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
        public delegate void ShiftUpdateHandler(object sender, ShiftUpdateEventArgs e, DataEventType Action);

        public event ShiftUpdateHandler Entry_DataChanged;
        #endregion

        #region Private Methods
        private void EnableDisableSave()
        {
            btnSave.Enabled = objShift.IsValid;
        }

        private void Shift_OnValid(object sender, EventArgs e)
        {
            EnableDisableSave();
        }

        private void Shift_OnInValid(object sender, EventArgs e)
        {
            EnableDisableSave();
        }

        private void SubscribeToEvents()
        {
            objShift.OnValid += new Shift.EventHandler(Shift_OnValid);
            objShift.OnInvalid += new Shift.EventHandler(Shift_OnInValid);
        }
        #endregion

        private void txtShiftName_Enter(object sender, EventArgs e)
        {
            txtShiftName.SelectAll();
        }

        private void txtShiftName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!IsLoading)
                {
                    objShift.ShiftName = txtShiftName.Text.Trim();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtShiftName_Leave(object sender, EventArgs e)
        {
            txtShiftName.Text = objShift.ShiftName;
        }

        private void txtShiftCode_Enter(object sender, EventArgs e)
        {
            txtShiftCode.SelectAll();
        }

        private void txtShiftCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!IsLoading)
                {
                    objShift.ShiftCode = txtShiftCode.Text.Trim();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtShiftCode_Leave(object sender, EventArgs e)
        {
            txtShiftCode.Text = objShift.ShiftCode;
        }

        private void txtShiftBeginTime_Enter(object sender, EventArgs e)
        {

        }

        private void txtShiftBeginTime_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtShiftBeginTime_Leave(object sender, EventArgs e)
        {

        }

        private void txtShiftEndTime_Enter(object sender, EventArgs e)
        {

        }

        private void txtShiftEndTime_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtShiftEndTime_Leave(object sender, EventArgs e)
        {

        }

        private void txtPunchBegin_Enter(object sender, EventArgs e)
        {

        }

        private void txtPunchBegin_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPunchBegin_Leave(object sender, EventArgs e)
        {

        }

        private void txtPunchEnd_Enter(object sender, EventArgs e)
        {

        }

        private void txtPunchEnd_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPunchEnd_Leave(object sender, EventArgs e)
        {

        }

        private void chkIsGrace_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtGraceTime_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtGraceTime_Enter(object sender, EventArgs e)
        {

        }

        private void txtGraceTime_Leave(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }

    public class ShiftUpdateEventArgs : EventArgs
    {
        private long mDBID;
        private string mShiftCode;
        private string mShiftName;
        private string mBeginTime;
        private string mEndTime;

        public ShiftUpdateEventArgs(long sDBID, string sShiftCode, string sShiftName, string sBeginTime, string sEndTime)
        {
            mDBID = sDBID;
            mShiftCode = sShiftCode;
            mShiftName = sShiftName;
            mBeginTime = sBeginTime;
            mEndTime = sEndTime;
        }

        public long DBID
        {
            get
            {
                return mDBID;
            }
        }

        public string ShiftCode
        {
            get
            {
                return mShiftCode;
            }
        }

        public string ShiftName
        {
            get
            {
                return mShiftName;
            }
        }

        public string BeginTime
        {
            get
            {
                return mBeginTime;
            }
        }

        public string EndTime
        {
            get
            {
                return mEndTime;
            }
        }
    }
}
