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
    public partial class frmHolidayList : Form
    {
        #region Private Variable(s)
        private bool flgLoading;
        private bool flgList;
        private bool flgListCancel;

        private long dbID;
        private DateTime holidayDate;
        private string holidayName;

        private ListViewColumnSorter lvwColSorter;
        //private UserCompany objUserCompany;
        //private User objCurUser;
        //private UIRights objUIRights;
        #endregion

        #region Public Properties
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

        public bool IsList
        {
            get
            {
                return flgList;
            }
            set
            {
                flgList = value;
            }
        }

        public bool IsListCancel
        {
            get
            {
                return flgListCancel;
            }
            set
            {
                flgListCancel = value;
            }
        }

        public long DBID
        {
            get
            {
                return dbID;
            }
            set
            {
                dbID = value;
            }
        }

        public DateTime HolidayDate
        {
            get
            {
                return holidayDate;
            }
            set
            {
                holidayDate = value;
            }
        }

        public string HolidayName
        {
            get
            {
                return holidayName;
            }
            set
            {
                holidayName = value;
            }
        }
        #endregion

        #region Private Method(s)
        private void InitializeListView()
        {
            // Create an instance of a ListView column sorter and assign it 
            // to the ListView control.
            lvwColSorter = new ListViewColumnSorter();

            this.lvwHolidays.ContextMenuStrip = conMenu;
            this.lvwHolidays.FullRowSelect = true;
            this.lvwHolidays.GridLines = true;
            this.lvwHolidays.ListViewItemSorter = lvwColSorter;
            this.lvwHolidays.MultiSelect = false;
            this.lvwHolidays.View = View.Details;
        }

        private void FillList()
        {
            HolidayList objList = new HolidayList();
            objList = HolidayManager.GetList("");

            lvwHolidays.Items.Clear();

            if (objList != null)
            {
                foreach (Holiday objHoliday in objList)
                {
                    ListViewItem objLvwItem = new ListViewItem();
                    objLvwItem.Name = Convert.ToString(objHoliday.DBID);
                    objLvwItem.Text = Convert.ToString(objHoliday.HolidayDate);
                    objLvwItem.SubItems.Add(Convert.ToString(objHoliday.HolidayName));

                    lvwHolidays.Items.Add(objLvwItem);
                }
            }
        }

        private void SetButtonVisibility()
        {
            btnOk.Visible = IsList;
            btnCancel.Visible = IsList;
            btnNew.Visible = !IsList;
        }
        #endregion

        #region Constructor(s)
        public frmHolidayList()
        {
            InitializeComponent();
            InitializeListView();
        }


        //public frmHolidayList(UserCompany objCompany, User objUser)
        //{
        //    this.objCurUser = objUser;
        //    this.objUserCompany = objCompany;

        //    objUIRights = new UIRights();

        //    InitializeComponent();
        //    InitializeListView();
        //    GeneralMethods.FormAuthenticate(this.Name, objUserCompany, objCurUser);

        //    objUIRights.AddRight = GeneralMethods.frmAddRight;
        //    objUIRights.ModifyRight = GeneralMethods.frmModifyRight;
        //    objUIRights.ViewRight = GeneralMethods.frmViewRight;
        //    objUIRights.DeleteRight = GeneralMethods.frmDeleteRight;
        //    objUIRights.PrintRight = GeneralMethods.repPrintRight;
        //}
        #endregion

        #region Context Menu
        private void modifyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvwHolidays.SelectedItems != null && lvwHolidays.SelectedItems.Count != 0)
                {
                    if (IsList)
                    {
                        btnOk_Click(sender, e);
                    }
                    else
                    {
                        //if (objUIRights.ModifyRight)
                        //{
                        Holiday objHoliday;
                        frmHolidayProp objFrmProp;

                        objHoliday = HolidayManager.GetItem(Convert.ToInt32(lvwHolidays.SelectedItems[0].Name));
                        objFrmProp = new frmHolidayProp(objHoliday);
                        objFrmProp.MdiParent = this.MdiParent;
                        objFrmProp.Entry_DataChanged += new frmHolidayProp.HolidayUpdateHandler(Entry_DataChanged);
                        objFrmProp.Show();
                        //}
                        //else
                        //{
                        //    throw new Exception("Not Authorised.");
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsList)
                {
                    //                    if (objUIRights.AddRight)
                    //                    {
                    Holiday objHoliday;
                    frmHolidayProp objFrmProp;

                    objHoliday = new Holiday();
                    objFrmProp = new frmHolidayProp(objHoliday);
                    objFrmProp.IsNew = true;
                    objFrmProp.MdiParent = this.MdiParent;
                    objFrmProp.Entry_DataChanged += new frmHolidayProp.HolidayUpdateHandler(Entry_DataChanged);
                    objFrmProp.Show();
                    //}
                    //else
                    //{
                    //    throw new Exception("Not Authorised.");
                    //}
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvwHolidays.SelectedItems != null && lvwHolidays.SelectedItems.Count != 0)
                {
                    if (!IsList)
                    {
                        //if (objUIRights.DeleteRight)
                        //{
                        DialogResult dr = new DialogResult();
                        dr = MessageBox.Show("Do You Really Want to Delete Record ?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                        if (dr == DialogResult.Yes)
                        {
                            Holiday objHoliday = new Holiday();
                            objHoliday = HolidayManager.GetItem(Convert.ToInt32(lvwHolidays.SelectedItems[0].Name));
                            HolidayManager.Delete(objHoliday);
                            lvwHolidays.Items.Remove(lvwHolidays.SelectedItems[0]);
                        }
                        //}
                        //else
                        //{
                        //    throw new Exception("Not Authorised.");
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void conMenu_Opening(object sender, CancelEventArgs e)
        {
            if (!IsList)
            {
                if (lvwHolidays.SelectedItems != null && lvwHolidays.SelectedItems.Count != 0)
                {
                    modifyToolStripMenuItem.Visible = true;
                    newToolStripMenuItem.Enabled = false;
                    toolStripSeparator1.Visible = true;
                    deleteToolStripMenuItem.Visible = true;
                }
                else
                {
                    modifyToolStripMenuItem.Visible = false;
                    newToolStripMenuItem.Enabled = true;
                    toolStripSeparator1.Visible = false;
                    deleteToolStripMenuItem.Visible = false;
                }
            }
        }
        #endregion

        #region UI Control Logic
        private void frmHolidayList_Load(object sender, EventArgs e)
        {
            this.Icon = new Icon("Images/DTPL.ico");
            flgLoading = true;
            FillList();
            SetButtonVisibility();
            if (IsList)
            {
                this.CancelButton = btnCancel;
            }
            flgLoading = false;
        }

        private void frmHolidayList_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dbID == 0)
                flgListCancel = true;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsList && lvwHolidays.SelectedItems != null && lvwHolidays.SelectedItems.Count == 1)
                {
                    dbID = Convert.ToInt32(lvwHolidays.SelectedItems[0].Name);
                    holidayDate = Convert.ToDateTime(lvwHolidays.SelectedItems[0].Text);
                    holidayName = lvwHolidays.SelectedItems[0].SubItems[1].Text;

                    flgListCancel = false;
                }
                else
                {
                    btnCancel_Click(sender, e);
                }
                this.Close();
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
                if (IsList)
                {
                    dbID = 0;
                    holidayDate = DateTime.MinValue ;
                    holidayName = string.Empty;

                    flgListCancel = true;
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (!IsList)
            {
                newToolStripMenuItem_Click(sender, e);
            }
        }

        private void lvwHolidays_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == lvwColSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColSorter.Order == SortOrder.Ascending)
                {
                    lvwColSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColSorter.SortColumn = e.Column;
                lvwColSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.lvwHolidays.Sort();
        }

        private void lvwHolidays_DoubleClick(object sender, EventArgs e)
        {
            if (lvwHolidays.SelectedItems != null && lvwHolidays.SelectedItems.Count != 0)
            {
                modifyToolStripMenuItem_Click(sender, e);
            }
        }

        private void lvwHolidays_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (lvwHolidays.SelectedItems.Count == 1 && e.KeyChar == (char)Keys.Enter)
            {
                modifyToolStripMenuItem_Click(sender, e);
            }
        }
        #endregion

        private void Entry_DataChanged(object sender, HolidayUpdateEventArgs e, DataEventType Action)
        {
            ListViewItem lvItem;
            switch (Action)
            {
                case DataEventType.INSERT_EVENT:

                    lvItem = new ListViewItem();
                    lvItem.Name = Convert.ToString(e.DBID);
                    lvItem.Text = e.HolidayDate.ToShortDateString();
                    lvItem.SubItems.Add(e.HolidayName);

                    lvwHolidays.Items.Add(lvItem);
                    lvwHolidays.EnsureVisible(lvItem.Index);

                    break;

                case DataEventType.UPDATE_EVENT:
                    lvItem = lvwHolidays.Items[lvwHolidays.SelectedItems[0].Index];
                    lvItem.Text = e.HolidayDate.ToShortDateString();
                    lvItem.SubItems[1].Text = e.HolidayName;

                    lvwHolidays.EnsureVisible(lvwHolidays.SelectedItems[0].Index);

                    break;
            }
        }
    }
}
