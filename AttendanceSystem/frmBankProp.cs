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
    public partial class frmBankProp : Form
    {
        #region Private Variable(s)
        private bool flgNew;
        private bool flgLoading;

        private Bank objBank;
        #endregion

        #region Constructor
        public frmBankProp()
        {
            InitializeComponent();
        }

        public frmBankProp(Bank objBank)
        {
            this.objBank = objBank;
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
        public delegate void BankUpdateHandler(object sender, BankUpdateEventArgs e, DataEventType Action);

        public event BankUpdateHandler Entry_DataChanged;
        #endregion

        #region Private Methods
        private void EnableDisableSave()
        {
            btnSave.Enabled = objBank.IsValid;
        }

        private void Bank_OnValid(object sender, EventArgs e)
        {
            EnableDisableSave();
        }

        private void Bank_OnInValid(object sender, EventArgs e)
        {
            EnableDisableSave();
        }

        private void SubscribeToEvents()
        {
            objBank.OnValid += new Bank.EventHandler(Bank_OnValid);
            objBank.OnInvalid += new Bank.EventHandler(Bank_OnInValid);
        }
        #endregion

        private void frmBankProp_Load(object sender, EventArgs e)
        {
            Icon = new Icon("Images/DTPL.ico");
            flgLoading = true;
            Bank_OnInValid(sender, e);

            if (objBank.IsNew)
            {
                Text += " [ NEW ]";
            }
            else
            {
                Text += " [ " + objBank.BankName + " ]";
            }
            txtBankName.Text = objBank.BankName;
            txtBranch.Text = objBank.Branch;
            txtIFSCCode.Text = objBank.IFSCCode;

            SubscribeToEvents();
            flgLoading = false;
        }

        private void txtBankName_Enter(object sender, EventArgs e)
        {
            txtBankName.SelectAll();
        }

        private void txtBankName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!IsLoading)
                {
                    objBank.BankName= txtBankName.Text.Trim();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtBankName_Leave(object sender, EventArgs e)
        {
            txtBankName.Text = objBank.BankName;
        }

        private void txtBranch_Enter(object sender, EventArgs e)
        {
            txtBranch.SelectAll();
        }

        private void txtBranch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!IsLoading)
                {
                    objBank.Branch= txtBranch.Text.Trim();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtBranch_Leave(object sender, EventArgs e)
        {
            txtBranch.Text = objBank.Branch;
        }

        private void txtIFSCCode_Enter(object sender, EventArgs e)
        {
            txtIFSCCode.SelectAll();
        }

        private void txtIFSCCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!IsLoading)
                {
                    objBank.IFSCCode= txtIFSCCode.Text.Trim();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtIFSCCode_Leave(object sender, EventArgs e)
        {
            txtIFSCCode.Text = objBank.IFSCCode;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                bool flgApplyEdit;
                flgApplyEdit = BankManager.Save(objBank);
                if (flgApplyEdit)
                {
                    // instance the event args and pass it value
                    BankUpdateEventArgs args = new BankUpdateEventArgs(objBank.DBID, objBank.BankName, objBank.Branch, objBank.IFSCCode);

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
    }

    public class BankUpdateEventArgs : System.EventArgs
    {
        private int mDBID;
        private string mBankName;
        private string mBranch;
        private string mIFSCCode;

        public BankUpdateEventArgs(int sDBID, string sBankName, string sBranch, string sIFSCCode)
        {
            mDBID = sDBID;
            mBankName = sBankName;
            mBranch = sBranch;
            mIFSCCode = sIFSCCode;
        }

        public int DBID
        {
            get
            {
                return mDBID;
            }
        }

        public string BankName
        {
            get
            {
                return mBankName;
            }
        }

        public string Branch
        {
            get
            {
                return mBranch;
            }
        }

        public string IFSCCode
        {
            get
            {
                return mIFSCCode;
            }
        }
    }
}
