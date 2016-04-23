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
    public partial class frmEmpStatusProp : Form
    {
        #region Private Variable(s)
        private bool flgNew;
        private bool flgLoading;

        private EmployeeStatus objEmpStatus;
        #endregion

        #region Constructor
        public frmEmpStatusProp()
        {
            InitializeComponent();
        }

        public frmEmpStatusProp(EmployeeStatus objEmpStatus)
        {
            this.objEmpStatus = objEmpStatus;
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

        /// <summary>
        /// Contains Delegates and events available on Form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="Action"></param>
        #region Delegate & Event
        public delegate void EmpStatusUpdateHandler(object sender, EmpStatusUpdateEventArgs e, DataEventType Action);

        public event EmpStatusUpdateHandler Entry_DataChanged;
        #endregion

        #region Private Methods
        private void EnableDisableSave()
        {
            btnSave.Enabled = objEmpStatus.IsValid;
        }

        private void EmpStatus_OnValid(object sender, EventArgs e)
        {
            EnableDisableSave();
        }

        private void EmpStatus_OnInValid(object sender, EventArgs e)
        {
            EnableDisableSave();
        }

        private void SubscribeToEvents()
        {
            objEmpStatus.OnValid += new EmployeeStatus.EventHandler(EmpStatus_OnValid);
            objEmpStatus.OnInvalid += new EmployeeStatus.EventHandler(EmpStatus_OnInValid);
        }

        #endregion

        #region UI Control Logic
        private void frmEmpStatusProp_Load(object sender, EventArgs e)
        {
            Icon = new Icon("Images/DTPL.ico");
            flgLoading = true;
            EmpStatus_OnInValid(sender, e);

            if (objEmpStatus.IsNew)
            {
                Text += " [ NEW ]";
            }
            else
            {
                Text += " [ " + objEmpStatus.EmpStatus + " ]";
            }
            txtEmpStatus.Text = objEmpStatus.EmpStatus;
            txtDescription.Text = objEmpStatus.Description;

            SubscribeToEvents();
            flgLoading = false;
        }

        private void txtEmpStatus_Enter(object sender, EventArgs e)
        {
            txtEmpStatus.SelectAll();
        }

        private void txtEmpStatus_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!IsLoading)
                {
                    objEmpStatus.EmpStatus = txtEmpStatus.Text.Trim();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtEmpStatus_Leave(object sender, EventArgs e)
        {
            txtEmpStatus.Text = objEmpStatus.EmpStatus;
        }

        private void txtDescription_Enter(object sender, EventArgs e)
        {
            txtDescription.SelectAll();
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!IsLoading)
                {
                    objEmpStatus.Description = txtDescription.Text.Trim();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtDescription_Leave(object sender, EventArgs e)
        {
            txtDescription.Text = objEmpStatus.Description;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                bool flgApplyEdit;
                flgApplyEdit = EmployeeStatusManager.Save(objEmpStatus);
                if (flgApplyEdit)
                {
                    // instance the event args and pass it value
                    EmpStatusUpdateEventArgs args = new EmpStatusUpdateEventArgs(objEmpStatus.DBID, objEmpStatus.EmpStatus);

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

        private void frmEmpStatusProp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        #endregion
    }

    public class EmpStatusUpdateEventArgs : System.EventArgs
    {
        private long mDBID;
        private string mEmpStatus;

        public EmpStatusUpdateEventArgs(long sDBID, string sEmpStatus)
        {
            mDBID = sDBID;
            mEmpStatus = sEmpStatus;
        }

        public long DBID
        {
            get
            {
                return mDBID;
            }
        }

        public string EmpStatus
        {
            get
            {
                return mEmpStatus;
            }
        }
    }
}
