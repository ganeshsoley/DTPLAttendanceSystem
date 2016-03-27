using System;
using System.Drawing;
using System.Windows.Forms;
using EntityObject;
using EntityObject.Enum;
using BLL;

namespace DTPLAttendanceSystem
{
    public partial class frmDeptProp : Form
    {

        #region Private Variable
        private bool flgNew;
        private bool flgLoading;

        private Department objDept;

        #endregion

        #region Constructor

        public frmDeptProp()
        {
            InitializeComponent();
        }
        public frmDeptProp(Department objDept)
        {
            this.objDept = objDept;
            InitializeComponent();
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
        public delegate void DeptUpdateHandler(object sender, DeptUpdateEventArgs e, DataEventType Action);
        public event DeptUpdateHandler Entry_DataChanged;
        #endregion

        #region Private Methods
        private void EnableDisableSave()
        {
            btnSave.Enabled = objDept.IsValid;
        }
        private void Dept_OnValid(object sender, EventArgs e)
        {
            EnableDisableSave();
        }
        private void Dept_OnInValid(object sender, EventArgs e)
        {
            EnableDisableSave();
        }
        private void SubscribeToEvents()
        {
            objDept.OnValid += new Department.EventHandler(Dept_OnValid);
            objDept.OnInvalid += new Department.EventHandler(Dept_OnInValid);
        }
        #endregion

        #region UI Control Logic
        private void frmDeptProp_Load(object sender, EventArgs e)
        {
            //this.Icon = new Icon("Images/DTPL.ico");
            flgLoading = true;
            Dept_OnInValid(sender, e);

            if (objDept.IsNew)
            {
                this.Text += " [ NEW ]";
            }
            else
            {
                this.Text += " [ " + objDept.DeptName + " ]";
            }
            txtDept.Text = objDept.DeptName;
            txtDescr.Text = objDept.Description;
            if (objDept.IsActive)
                chkIsActive.Checked = true;
            else
                chkIsActive.Checked = false;

            SubscribeToEvents();
            flgLoading = false;
        }
        private void frmDeptProp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtDept_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!IsLoading)
                {
                    objDept.DeptName = Convert.ToString(txtDept.Text.Trim());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void txtDept_Enter(object sender, EventArgs e)
        {
            GeneralMethods.Selection(txtDept);
        }
        private void txtDept_Leave(object sender, EventArgs e)
        {
            txtDept.Text = objDept.DeptName;
        }

        private void txtDescr_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!IsLoading)
                {
                    objDept.Description = Convert.ToString(txtDescr.Text.Trim());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void txtDescr_Enter(object sender, EventArgs e)
        {
            GeneralMethods.Selection(txtDescr);
        }
        private void txtDescr_Leave(object sender, EventArgs e)
        {
            txtDescr.Text = objDept.Description;
        }

        private void txtSrNo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!IsLoading)
                {
                    objDept.SrNo  = Convert.ToInt16(txtSrNo.Text.Trim());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void txtSrNo_Enter(object sender, EventArgs e)
        {
            GeneralMethods.Selection(txtSrNo);
        }
        private void txtSrNo_Leave(object sender, EventArgs e)
        {
            txtSrNo.Text =Convert.ToString(objDept.SrNo);
        }

        private void chkIsActive_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void chkIsActive_Click(object sender, EventArgs e)
        {
            if (!IsLoading)
            {
                if (chkIsActive.Checked)
                    objDept.IsActive = true;
                else
                    objDept.IsActive = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                bool flgApplyEdit;
                flgApplyEdit = DeptManager.Save(objDept);
                if (flgApplyEdit)
                {
                    // instance the event args and pass it value
                    DeptUpdateEventArgs args = new DeptUpdateEventArgs(objDept.DBID, objDept.DeptName, objDept.Description);

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
                //this.Dispose();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        #endregion


    }
    public class DeptUpdateEventArgs : System.EventArgs
    {
        private int mDBID;
        private string mDept;
        private string mDescr;

        public DeptUpdateEventArgs(int sDBID, string sDept, string sDescr)
        {
            this.mDBID = sDBID;
            this.mDept = sDept;
            this.mDescr = sDescr;
        }

        public int DBID
        {
            get
            {
                return mDBID;
            }
        }

        public string Dept
        {
            get
            {
                return mDept;
            }
        }

        public string Descr
        {
            get
            {
                return mDescr;
            }
        }
    }
}
