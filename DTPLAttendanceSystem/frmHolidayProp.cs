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
            this.Icon = new Icon("Images/DTPL.ico");
            flgLoading = true;
            Holiday_OnInValid(sender, e);

            if (objHoliday.IsNew)
            {
                this.Text += " [ NEW ]";
            }
            else
            {
                this.Text += " [ " + objHoliday.HolidayDate + " ]";
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

        }

        private void txtHolidayName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtHolidayName_Leave(object sender, EventArgs e)
        {

        }

        private void dtpHoliday_Enter(object sender, EventArgs e)
        {

        }

        private void dtpHoliday_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtpHoliday_Leave(object sender, EventArgs e)
        {

        }

        private void cboApplicableTo_Enter(object sender, EventArgs e)
        {

        }

        private void cboApplicableTo_TextChanged(object sender, EventArgs e)
        {

        }

        private void cboApplicableTo_Leave(object sender, EventArgs e)
        {

        }

        private void txtDescription_Enter(object sender, EventArgs e)
        {

        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDescription_Leave(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
