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

        #region UI Control Logic
        private void frmShiftProp_Load(object sender, EventArgs e)
        {
            this.Icon = new Icon("Images/DTPL.ico");
            flgLoading = true;
            Shift_OnInValid(sender, e);

            if (objShift.IsNew)
            {
                this.Text += " [ NEW ]";
            }
            else
            {
                this.Text += " [ " + objShift.ShiftName + " ]";
            }
            txtShiftName.Text = objShift.ShiftName;
            txtShiftCode.Text = objShift.ShiftCode;
            txtShiftBeginTime.Text = objShift.ShiftBeginTime;
            txtShiftEndTime.Text = objShift.ShiftEndTime;
            txtPunchBegin.Text = objShift.PunchBeginMins.ToString();
            txtPunchEnd.Text = objShift.PunchEndMins.ToString();

            if (objShift.IsGraceTimeApplicable == 1)
            {
                chkIsGrace.Checked = true;
                txtGraceTime.Text = objShift.GraceTimeMins;
            }
            else
            {
                chkIsGrace.Checked = false;
                txtGraceTime.Enabled = false;
            }

            SubscribeToEvents();
            flgLoading = false;
        }

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
            txtShiftBeginTime.SelectAll();
        }

        private void txtShiftBeginTime_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!IsLoading)
                {
                    objShift.ShiftBeginTime = txtShiftBeginTime.Text.Trim();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtShiftBeginTime_Leave(object sender, EventArgs e)
        {
            txtShiftBeginTime.Text = objShift.ShiftBeginTime;
        }

        private void txtShiftEndTime_Enter(object sender, EventArgs e)
        {
            txtShiftEndTime.SelectAll();
        }

        private void txtShiftEndTime_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!IsLoading)
                {
                    objShift.ShiftEndTime= txtShiftEndTime.Text.Trim();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtShiftEndTime_Leave(object sender, EventArgs e)
        {
            txtShiftEndTime.Text = objShift.ShiftEndTime;
        }

        private void txtPunchBegin_Enter(object sender, EventArgs e)
        {
            txtPunchBegin.SelectAll();
        }

        private void txtPunchBegin_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!IsLoading)
                {
                    objShift.PunchBeginMins = Convert.ToInt32(txtPunchBegin.Text.Trim());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtPunchBegin_Leave(object sender, EventArgs e)
        {
            txtPunchBegin.Text = objShift.PunchBeginMins.ToString();
        }

        private void txtPunchEnd_Enter(object sender, EventArgs e)
        {
            txtPunchEnd.SelectAll();
        }

        private void txtPunchEnd_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!IsLoading)
                {
                    objShift.PunchEndMins = Convert.ToInt32(txtPunchEnd.Text.Trim());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtPunchEnd_Leave(object sender, EventArgs e)
        {
            txtPunchEnd.Text = Convert.ToString(objShift.PunchEndMins);
        }

        private void chkIsGrace_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (!IsLoading)
                {
                    if (chkIsGrace.Checked)
                    {
                        objShift.IsGraceTimeApplicable = 1;
                        txtGraceTime.Enabled = true;
                    }
                    else
                    {
                        objShift.IsGraceTimeApplicable = 0;
                        txtGraceTime.Enabled = false;
                        objShift.GraceTimeMins = "";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtGraceTime_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!IsLoading)
                {
                    objShift.GraceTimeMins = txtGraceTime.Text.Trim();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtGraceTime_Enter(object sender, EventArgs e)
        {
            txtGraceTime.SelectAll();
        }

        private void txtGraceTime_Leave(object sender, EventArgs e)
        {
            txtGraceTime.Text = objShift.GraceTimeMins;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                bool flgApplyEdit;
                flgApplyEdit = ShiftManager.Save(objShift);
                if (flgApplyEdit)
                {
                    // instance the event args and pass it value
                    ShiftUpdateEventArgs args = new ShiftUpdateEventArgs(objShift.DBID, objShift.ShiftCode, objShift.ShiftName, objShift.ShiftBeginTime, objShift.ShiftEndTime);

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
