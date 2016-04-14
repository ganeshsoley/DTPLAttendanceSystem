using System;
using System.Drawing;
using System.Windows.Forms;
using EntityObject;
using EntityObject.Enum;
using BLL;

namespace AttendanceSystem
{
    public partial class frmHolidayProp : Form
    {
        #region Private Variable(s)
        private bool flgNew;
        private bool flgLoading;

        private Holiday objHoliday;
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

        #region Constructor(s)
        public frmHolidayProp()
        {
            InitializeComponent();
        }

        public frmHolidayProp(Holiday objHoliday)
        {
            this.objHoliday = objHoliday;
            InitializeComponent();
        }
        #endregion

        #region Delegate & Event
        public delegate void HolidayUpdateHandler(object sender, HolidayUpdateEventArgs e, DataEventType Action);

        public event HolidayUpdateHandler Entry_DataChanged;
        #endregion

        #region Private Methods
        private void EnableDisableSave()
        {
            btnSave.Enabled = objHoliday.IsValid;
        }

        private void Holiday_OnValid(object sender, EventArgs e)
        {
            EnableDisableSave();
        }

        private void Holiday_OnInValid(object sender, EventArgs e)
        {
            EnableDisableSave();
        }

        private void SubscribeToEvents()
        {
            objHoliday.OnValid += new Holiday.EventHandler(Holiday_OnValid);
            objHoliday.OnInvalid += new Holiday.EventHandler(Holiday_OnInValid);
        }
        #endregion

        #region UI Control Logic
        private void frmHolidayProp_Load(object sender, EventArgs e)
        {
            Icon = new Icon("Images/DTPL.ico");
            flgLoading = true;
            Holiday_OnInValid(sender, e);

            if (objHoliday.IsNew)
            {
                this.Text += " [ NEW ]";
            }
            else
            {
                this.Text += " [ " + objHoliday.HolidayName + " ]";
            }
            dtpHoliday.Value = objHoliday.HolidayDate;
            txtHolidayName.Text = objHoliday.HolidayName;
            cboApplicableTo.Text = objHoliday.ApplicableTo;
            txtDescription.Text = objHoliday.Description;

            SubscribeToEvents();
            flgLoading = false;
        }

        private void txtHolidayName_Enter(object sender, EventArgs e)
        {
            txtHolidayName.SelectAll();
        }

        private void txtHolidayName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!IsLoading)
                {
                    objHoliday.HolidayName = txtHolidayName.Text.Trim();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtHolidayName_Leave(object sender, EventArgs e)
        {
            txtHolidayName.Text = objHoliday.HolidayName;
        }

        private void dtpHoliday_Enter(object sender, EventArgs e)
        {
            dtpHoliday.Select();
        }

        private void dtpHoliday_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (!IsLoading)
                {
                    objHoliday.HolidayDate = dtpHoliday.Value;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dtpHoliday_Leave(object sender, EventArgs e)
        {

        }

        private void cboApplicableTo_Enter(object sender, EventArgs e)
        {
            cboApplicableTo.SelectAll();
        }

        private void cboApplicableTo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!IsLoading)
                {
                    objHoliday.ApplicableTo = cboApplicableTo.Text.Trim();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void cboApplicableTo_Leave(object sender, EventArgs e)
        {
            cboApplicableTo.Text = objHoliday.ApplicableTo;
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
                    objHoliday.Description = txtDescription.Text.Trim();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtDescription_Leave(object sender, EventArgs e)
        {
            txtDescription.Text = objHoliday.Description;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                bool flgApplyEdit;
                flgApplyEdit = HolidayManager.Save(objHoliday);
                if (flgApplyEdit)
                {
                    // instance the event args and pass it value
                    HolidayUpdateEventArgs args = new HolidayUpdateEventArgs(objHoliday.DBID, objHoliday.HolidayDate, objHoliday.HolidayName);

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

    public class HolidayUpdateEventArgs : EventArgs
    {
        private long mDBID;
        private DateTime mHolidayDate;
        private string mHolidayName;

        public HolidayUpdateEventArgs(long sDBID, DateTime sHolidayDate, string sHolidayName)
        {
            mDBID = sDBID;
            mHolidayDate = sHolidayDate;
            mHolidayName= sHolidayName;
        }

        public long DBID
        {
            get
            {
                return mDBID;
            }
        }

        public DateTime HolidayDate
        {
            get
            {
                return mHolidayDate;
            }
        }

        public string HolidayName
        {
            get
            {
                return mHolidayName;
            }
        }
    }
}
