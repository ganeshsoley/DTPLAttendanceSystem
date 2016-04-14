using System;
using System.Drawing;
using System.Windows.Forms;
using EntityObject;
using EntityObject.Enum;
using BLL;

namespace AttendanceSystem
{
    public partial class frmDesignationProp : Form
    {
        #region Private Variable(s)
        private bool flgNew;
        private bool flgLoading;

        private Designation objDesignation;
        #endregion

        #region Constructor(s)
        public frmDesignationProp()
        {
            InitializeComponent();
        }

        public frmDesignationProp(Designation objDesignation)
        {
            this.objDesignation = objDesignation;
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
        public delegate void DesignationUpdateHandler(object sender, DesignationUpdateEventArgs e, DataEventType Action);

        public event DesignationUpdateHandler Entry_DataChanged;
        #endregion

        #region Private Methods
        private void EnableDisableSave()
        {
            btnSave.Enabled = objDesignation.IsValid;
        }

        private void Designation_OnValid(object sender, EventArgs e)
        {
            EnableDisableSave();
        }

        private void Designation_OnInValid(object sender, EventArgs e)
        {
            EnableDisableSave();
        }

        private void SubscribeToEvents()
        {
            objDesignation.OnValid += new Designation.EventHandler(Designation_OnValid);
            objDesignation.OnInvalid += new Designation.EventHandler(Designation_OnInValid);
        }
        #endregion

        private void frmDesignationProp_Load(object sender, EventArgs e)
        {
            this.Icon = new Icon("Images/DTPL.ico");
            flgLoading = true;
            Designation_OnInValid(sender, e);

            if (objDesignation.IsNew)
            {
                this.Text += " [ NEW ]";
            }
            else
            {
                this.Text += " [ " + objDesignation.DesigName + " ]";
            }

            txtDesignation.Text = objDesignation.DesigName;
            txtDescr.Text = objDesignation.Description;

            SubscribeToEvents();
            flgLoading = false;
        }

        private void txtDesignation_Enter(object sender, EventArgs e)
        {
            txtDesignation.SelectAll();
        }

        private void txtDesignation_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!IsLoading)
                {
                    objDesignation.DesigName = txtDesignation.Text.Trim();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtDesignation_Leave(object sender, EventArgs e)
        {
            txtDesignation.Text = objDesignation.DesigName;
        }

        private void txtDescr_Enter(object sender, EventArgs e)
        {
            txtDescr.SelectAll();
        }

        private void txtDescr_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!IsLoading)
                {
                    objDesignation.Description = txtDescr.Text.Trim();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtDescr_Leave(object sender, EventArgs e)
        {
            txtDescr.Text = objDesignation.Description;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                bool flgApplyEdit;
                flgApplyEdit = DesignationManager.Save(objDesignation);
                if (flgApplyEdit)
                {
                    // instance the event args and pass it value
                    DesignationUpdateEventArgs args = new DesignationUpdateEventArgs(objDesignation.DBID, objDesignation.DesigName);

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
    }

    public class DesignationUpdateEventArgs: EventArgs
    {
        private long mDBID;
        private string mDesignation;

        public DesignationUpdateEventArgs(long sDBID, string sDesignation)
        {
            this.mDBID = sDBID;
            this.mDesignation = sDesignation;
        }

        public long DBID
        {
            get
            {
                return mDBID;
            }
        }

        public string Designation
        {
            get
            {
                return mDesignation;
            }
        }

    }
}
