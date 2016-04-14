using System;
using System.Drawing;
using System.Windows.Forms;
using EntityObject;
using EntityObject.Enum;
using BLL;

namespace AttendanceSystem
{
    public partial class frmEmpTypeProp : Form
    {
        #region Private Variable(s)
        private bool flgNew;
        private bool flgLoading;

        private EmpType objEmpType;
        #endregion

        #region Constructor(s)
        public frmEmpTypeProp()
        {
            InitializeComponent();
        }

        public frmEmpTypeProp(EmpType objEmpType)
        {
            this.objEmpType = objEmpType;
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
        public delegate void EmpTypeUpdateHandler(object sender, EmpTypeUpdateEventArgs e, DataEventType Action);

        public event EmpTypeUpdateHandler Entry_DataChanged;
        #endregion

        #region Private Methods
        private void EnableDisableSave()
        {
            btnSave.Enabled = objEmpType.IsValid;
        }

        private void EmpType_OnValid(object sender, EventArgs e)
        {
            EnableDisableSave();
        }

        private void EmpType_OnInValid(object sender, EventArgs e)
        {
            EnableDisableSave();
        }

        private void SubscribeToEvents()
        {
            objEmpType.OnValid += new EmpType.EventHandler(EmpType_OnValid);
            objEmpType.OnInvalid += new EmpType.EventHandler(EmpType_OnInValid);
        }

        private void FillOTFormula()
        {
            cboOTFormula.Items.Add("OT Not Applicable");
            cboOTFormula.Items.Add("OutPunch - ShiftEndTime");
            cboOTFormula.Items.Add("Total Duration - Shift Hrs");
            cboOTFormula.Items.Add("Early Coming + Late Going");
        }
        #endregion

        #region UI Control Logic
        private void frmEmpTypeProp_Load(object sender, EventArgs e)
        {
            this.Icon = new Icon("Images/DTPL.ico");
            flgLoading = true;
            EmpType_OnInValid(sender, e);

            FillOTFormula();
            if (objEmpType.IsNew)
            {
                this.Text += " [ NEW ]";
            }
            else
            {
                this.Text += " [ " + objEmpType.EmpTypeName + " ]";
            }
            txtEmpTypeCode.Text = objEmpType.EmpTypeCode;
            txtEmpTypeName.Text = objEmpType.EmpTypeName;
            cboOTFormula.Text = objEmpType.OTFormula;
            txtMinOT.Text = objEmpType.MinOT;
            txtLCGraceTime.Text = objEmpType.LateComingGraceTime;
            txtEGGraceTime.Text = objEmpType.EarlyGoingGraceTime;
            if (objEmpType.CalculateAbsentDay == 1)
            {
                chkCalculateAbsent.Checked = true;
                txtAbsentMins.Text = objEmpType.AbsentDayMins;
            }
            else
                chkCalculateAbsent.Checked = false;

            if (objEmpType.CalculateHalfDay == 1)
            {
                chkCalulateHalfDay.Checked = true;
                txtHDMins.Text = objEmpType.HalfDayMins;
            }
            else
                chkCalulateHalfDay.Checked = false;

            if (objEmpType.MarkWOHasBothDayAbsent == 1)
                chkMarkWOHasBothDayAbsent.Checked = true;

            SubscribeToEvents();
            flgLoading = false;
        }

        private void txtEmpTypeCode_Enter(object sender, EventArgs e)
        {
            txtEmpTypeCode.SelectAll();
        }

        private void txtEmpTypeCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!IsLoading)
                {
                    objEmpType.EmpTypeCode = txtEmpTypeCode.Text.Trim();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtEmpTypeCode_Leave(object sender, EventArgs e)
        {
            txtEmpTypeCode.Text = objEmpType.EmpTypeCode;
        }

        private void txtEmpTypeName_Enter(object sender, EventArgs e)
        {
            txtEmpTypeName.SelectAll();
        }

        private void txtEmpTypeName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!IsLoading)
                {
                    objEmpType.EmpTypeName = txtEmpTypeName.Text.Trim();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtEmpTypeName_Leave(object sender, EventArgs e)
        {
            txtEmpTypeName.Text = objEmpType.EmpTypeName;
        }

        private void cboOTFormula_Enter(object sender, EventArgs e)
        {
            cboOTFormula.SelectAll();
        }

        private void cboOTFormula_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!IsLoading)
                {
                    objEmpType.OTFormula = cboOTFormula.Text.Trim();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void cboOTFormula_Leave(object sender, EventArgs e)
        {
            cboOTFormula.Text = objEmpType.OTFormula;
        }

        private void txtMinOT_Enter(object sender, EventArgs e)
        {
            txtMinOT.SelectAll();
        }

        private void txtMinOT_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!IsLoading)
                {
                    objEmpType.MinOT = txtMinOT.Text.Trim();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtMinOT_Leave(object sender, EventArgs e)
        {
            txtMinOT.Text = objEmpType.MinOT;
        }

        private void txtLCGraceTime_Enter(object sender, EventArgs e)
        {
            txtLCGraceTime.SelectAll();
        }

        private void txtLCGraceTime_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!IsLoading)
                {
                    objEmpType.LateComingGraceTime = txtLCGraceTime.Text.Trim();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtLCGraceTime_Leave(object sender, EventArgs e)
        {
            txtLCGraceTime.Text = objEmpType.LateComingGraceTime;
        }

        private void txtEGGraceTime_Enter(object sender, EventArgs e)
        {
            txtEGGraceTime.SelectAll();
        }

        private void txtEGGraceTime_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!IsLoading)
                {
                    objEmpType.EarlyGoingGraceTime = txtEGGraceTime.Text.Trim();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtEGGraceTime_Leave(object sender, EventArgs e)
        {
            txtEGGraceTime.Text = objEmpType.EarlyGoingGraceTime;
        }

        private void txtHDMins_Enter(object sender, EventArgs e)
        {
            txtHDMins.SelectAll();
        }

        private void txtHDMins_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!IsLoading)
                {
                    objEmpType.HalfDayMins = txtHDMins.Text.Trim();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtHDMins_Leave(object sender, EventArgs e)
        {
            txtHDMins.Text = objEmpType.HalfDayMins;
        }

        private void txtAbsentMins_Enter(object sender, EventArgs e)
        {
            txtAbsentMins.SelectAll();
        }

        private void txtAbsentMins_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!IsLoading)
                {
                    objEmpType.AbsentDayMins = txtAbsentMins.Text.Trim();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtAbsentMins_Leave(object sender, EventArgs e)
        {
            txtAbsentMins.Text = objEmpType.AbsentDayMins;
        }

        private void chkCalulateHalfDay_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (!IsLoading)
                {
                    if (chkCalulateHalfDay.Checked == true)
                    {
                        objEmpType.CalculateHalfDay = 1;
                        txtHDMins.Enabled = true;
                    }
                    else
                    {
                        objEmpType.CalculateHalfDay = 0;
                        txtHDMins.Enabled = false;
                        objEmpType.HalfDayMins = "";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void chkCalculateAbsent_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (!IsLoading)
                {
                    if (chkCalculateAbsent.Checked == true)
                    {
                        objEmpType.CalculateAbsentDay = 1;
                        txtAbsentMins.Enabled = true;
                    }
                    else
                    {
                        objEmpType.CalculateAbsentDay = 0;
                        txtAbsentMins.Enabled = false;
                        objEmpType.AbsentDayMins = "";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void chkMarkWOHasBothDayAbsent_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (!IsLoading)
                {
                    if (chkMarkWOHasBothDayAbsent.Checked == true)
                        objEmpType.MarkWOHasBothDayAbsent = 1;
                    else
                        objEmpType.MarkWOHasBothDayAbsent = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                bool flgApplyEdit;
                flgApplyEdit = EmpTypeManager.Save(objEmpType);
                if (flgApplyEdit)
                {
                    // instance the event args and pass it value
                    EmpTypeUpdateEventArgs args = new EmpTypeUpdateEventArgs(objEmpType.DBID, objEmpType.EmpTypeCode, objEmpType.EmpTypeName);

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

    public class EmpTypeUpdateEventArgs : EventArgs
    {
        private long mDBID;
        private string mEmpTypeCode;
        private string mEmpTypeName;

        public EmpTypeUpdateEventArgs(long sDBID, string sEmpTypeCode, string sEmpTypeName)
        {
            this.mDBID = sDBID;
            this.mEmpTypeCode = sEmpTypeCode;
            this.mEmpTypeName = sEmpTypeName;
        }

        public long DBID
        {
            get
            {
                return mDBID;
            }
        }

        public string EmpTypeCode
        {
            get
            {
                return mEmpTypeCode;
            }
        }

        public string EmpTypeName
        {
            get
            {
                return mEmpTypeName;
            }
        }
    }
}
