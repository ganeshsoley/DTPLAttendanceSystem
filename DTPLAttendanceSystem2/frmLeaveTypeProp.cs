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

namespace DTPLAttendanceSystem
{
    public partial class frmLeaveTypeProp : Form
    {
        #region Private Variable(s)
        private bool flgNew;
        private bool flgLoading;

        private LeaveType objLeaveType;
        #endregion

        #region Constructor(s)
        public frmLeaveTypeProp()
        {
            InitializeComponent();
        }

        public frmLeaveTypeProp(LeaveType objLeaveType)
        {
            this.objLeaveType = objLeaveType;
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
            btnSave.Enabled = objLeaveType.IsValid;
        }

        private void LeaveType_OnValid(object sender, EventArgs e)
        {
            EnableDisableSave();
        }

        private void LeaveType_OnInValid(object sender, EventArgs e)
        {
            EnableDisableSave();
        }

        private void SubscribeToEvents()
        {
            objLeaveType.OnValid += new EmpType.EventHandler(LeaveType_OnValid);
            objLeaveType.OnInvalid += new EmpType.EventHandler(LeaveType_OnInValid);
        }

        private void FillOTFormula()
        {
            cboOTFormula.Items.Add("OT Not Applicable");
            cboOTFormula.Items.Add("OutPunch - ShiftEndTime");
            cboOTFormula.Items.Add("Total Duration - Shift Hrs");
            cboOTFormula.Items.Add("Early Coming + Late Going");
        }
        #endregion

        private void frmLeaveTypeProp_Load(object sender, EventArgs e)
        {
            this.Icon = new Icon("Images/DTPL.ico");
            flgLoading = true;
            LeaveType_OnInValid(sender, e);

            if (objLeaveType.IsNew)
            {
                this.Text += " [ NEW ]";
            }
            else
            {
                this.Text += " [ " + objLeaveType.LeaveTypeName + " ]";
            }

            txtLeaveTypeName.Text = objLeaveType.LeaveTypeName;
            txtLeaveTypeCode.Text = objLeaveType.LeaveTypeName;
            txtYearlyLimit.Text = objLeaveType.YearlyLimit;
            txtCarryFwdLimit.Text = Convert.ToString(objLeaveType.CarryFwdLimit);
            if (objLeaveType.IsAddMonthly == 1)
            {
                chkAddLvsMonthly.Checked = true;
            }
            else
            {
                chkAddLvsMonthly.Checked = false;
            }
            txtMonthlyLeaves.Text = Convert.ToString(objLeaveType.AddMonthlyLV);
            if (objLeaveType.ApplicableGender == "All")
                rdbAll.Checked = true;
            else if (objLeaveType.ApplicableGender == "Male")
                rdbMale.Checked = true;
            else if (objLeaveType.ApplicableGender == "Female")
                rdbFemale.Checked = true;

            cboConsiderAs.Text = objLeaveType.ConsiderAs;
            if (objLeaveType.IsAllowNegativeBal == 1)
                chkAllowNegBalance.Checked = true;
            else
                chkAllowNegBalance.Checked = false;

            SubscribeToEvents();
            flgLoading = false;
        }

        private void txtLeaveTypeName_Enter(object sender, EventArgs e)
        {
            txtLeaveTypeName.SelectAll();
        }

        private void txtLeaveTypeName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!IsLoading)
                {
                    objLeaveType.LeaveTypeName = txtLeaveTypeCode.Text.Trim();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtLeaveTypeName_Leave(object sender, EventArgs e)
        {
            txtLeaveTypeName.Text = objLeaveType.LeaveTypeName;
        }

        private void txtLeaveTypeCode_Enter(object sender, EventArgs e)
        {
            txtLeaveTypeCode.SelectAll();
        }

        private void txtLeaveTypeCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!IsLoading)
                {
                    objLeaveType.LeaveTypeCode = txtLeaveTypeCode.Text.Trim();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtLeaveTypeCode_Leave(object sender, EventArgs e)
        {
            txtLeaveTypeCode.Text = objLeaveType.LeaveTypeCode;
        }

        private void txtYearlyLimit_Enter(object sender, EventArgs e)
        {
            txtYearlyLimit.SelectAll();
        }

        private void txtYearlyLimit_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!IsLoading)
                {
                    objLeaveType.YearlyLimit = txtYearlyLimit.Text.Trim();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtYearlyLimit_Leave(object sender, EventArgs e)
        {
            txtYearlyLimit.Text = objLeaveType.YearlyLimit;
        }

        private void txtCarryFwdLimit_Enter(object sender, EventArgs e)
        {
            txtCarryFwdLimit.SelectAll();
        }

        private void txtCarryFwdLimit_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!IsLoading)
                {
                    objLeaveType.CarryFwdLimit = Convert.ToInt32(txtCarryFwdLimit.Text.Trim());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtCarryFwdLimit_Leave(object sender, EventArgs e)
        {
            txtCarryFwdLimit.Text = Convert.ToString(objLeaveType.CarryFwdLimit);
        }

        private void chkAddLvsMonthly_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAddLvsMonthly.Checked == true)
                objLeaveType.IsAddMonthly = 1;
            else
                objLeaveType.IsAddMonthly = 0;
        }

        private void txtMonthlyLeaves_Enter(object sender, EventArgs e)
        {
            txtMonthlyLeaves.SelectAll();
        }

        private void txtMonthlyLeaves_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!IsLoading)
                {
                    objLeaveType.AddMonthlyLV = Convert.ToInt32(txtMonthlyLeaves.Text.Trim());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtMonthlyLeaves_Leave(object sender, EventArgs e)
        {
            txtMonthlyLeaves.Text = Convert.ToString(objLeaveType.AddMonthlyLV);
        } 

        private void rdbAll_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rdbMale_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rdbFemale_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cboConsiderAs_Enter(object sender, EventArgs e)
        {

        }

        private void cboConsiderAs_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboConsiderAs_Leave(object sender, EventArgs e)
        {

        }

        private void chkAllowNegBalance_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
