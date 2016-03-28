using System;
using System.Drawing;
using System.Windows.Forms;
using EntityObject;
using EntityObject.Enum;
using BLL;

namespace DTPLAttendanceSystem
{
    public partial class frmDesignationProp : Form
    {
        #region Private Variable
        private bool flgNew;
        private bool flgLoading;

        private Designation objDesg;
        #endregion

        #region Constructor
        public frmDesignationProp()
        {
            InitializeComponent();
        }
        public frmDesignationProp(Designation objDesg)
        {
            this.objDesg = objDesg;
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
        public delegate void DesgUpdateHandler(object sender, DesgUpdateEventArgs e, DataEventType Action);

        public event DesgUpdateHandler Entry_DataChanged;
        #endregion

        #region Private Methods
        private void EnableDisableSave()
        {
            btnSave.Enabled = objDesg.IsValid;
        }

        private void Desg_OnValid(object sender, EventArgs e)
        {
            EnableDisableSave();
        }

        private void Desg_OnInValid(object sender, EventArgs e)
        {
            EnableDisableSave();
        }

        private void SubscribeToEvents()
        {
            objDesg.OnValid += new Department.EventHandler(Desg_OnValid);
            objDesg.OnInvalid += new Department.EventHandler(Desg_OnInValid);
        }
        #endregion

        #region UI Control Logic
        private void frmDesignationProp_Load(object sender, EventArgs e)
        {
            //this.Icon = new Icon("Images/DTPL.ico");
            flgLoading = true;
            Desg_OnInValid(sender, e);

            if (objDesg.IsNew)
            {
                this.Text += " [ NEW ]";
            }
            else
            {
                this.Text += " [ " + objDesg.DesigName + " ]";
            }
            txtDesignation.Text = objDesg.DesigName;
            txtDescription.Text = objDesg.Description;


            SubscribeToEvents();
            flgLoading = false;
        }
        private void frmDesignationProp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtDesignation_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!IsLoading)
                {
                    objDesg.DesigName  = Convert.ToString(txtDesignation.Text.Trim());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void txtDesignation_Leave(object sender, EventArgs e)
        {
            txtDesignation.Text = objDesg.DesigName;
        }
        private void txtDesignation_Enter(object sender, EventArgs e)
        {
            GeneralMethods.Selection(txtDesignation);
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!IsLoading)
                {
                    objDesg.Description = Convert.ToString(txtDescription.Text.Trim());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void txtDescription_Enter(object sender, EventArgs e)
        {
            GeneralMethods.Selection(txtDescription);
        }
        private void txtDescription_Leave(object sender, EventArgs e)
        {
            txtDescription.Text = objDesg.Description;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                bool flgApplyEdit;
                flgApplyEdit = DesignationManager.Save(objDesg);
                if (flgApplyEdit)
                {
                    // instance the event args and pass it value
                    DesgUpdateEventArgs args = new DesgUpdateEventArgs(objDesg.DBID, objDesg.DesigName, objDesg.Description);

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
    public class DesgUpdateEventArgs : System.EventArgs
    {
        private int mDBID;
        private string mDesig;
        private string mDescr;

        public DesgUpdateEventArgs(int sDBID, string sDesig, string sDescr)
        {
            this.mDBID = sDBID;
            this.mDesig = sDesig;
            this.mDescr = sDescr;
        }

        public int DBID
        {
            get
            {
                return mDBID;
            }
        }

        public string Desig
        {
            get
            {
                return mDesig;
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
