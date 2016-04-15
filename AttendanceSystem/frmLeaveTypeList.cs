using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using EntityObject;
using EntityObject.Enum;
using BLL;

namespace AttendanceSystem
{
    public partial class frmLeaveTypeList : Form
    {
        #region Private Variable(s)
        private bool flgLoading;
        private bool flgList;
        private bool flgListCancel;

        private long dbID;
        private string leaveCode;
        private string leaveName;
        private string yearlyLimit;
        private int carryFwdLimit;

        private ListViewColumnSorter lvwColSorter;
        private UserCompany objUserCompany;
        private User objCurUser;
        private UIRights objUIRights;
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

        public string LeaveCode
        {
            get
            {
                return leaveCode;
            }
            set
            {
                leaveCode = value;
            }
        }

        public string LeaveName
        {
            get
            {
                return LeaveName;
            }
            set
            {
                LeaveName = value;
            }
        }

        public string YearlyLimit
        {
            get
            {
                return yearlyLimit;
            }
            set
            {
                yearlyLimit = value;
            }
        }

        public int CarryFwdLimit
        {
            get
            {
                return carryFwdLimit;
            }
            set
            {
                carryFwdLimit = value;
            }
        }
        #endregion

        #region Private Method(s)
        private void InitializeListView()
        {
            // Create an instance of a ListView column sorter and assign it 
            // to the ListView control.
            lvwColSorter = new ListViewColumnSorter();

            this.lvwLeaveTypes.ContextMenuStrip = conMenu;
            this.lvwLeaveTypes.FullRowSelect = true;
            this.lvwLeaveTypes.GridLines = true;
            this.lvwLeaveTypes.ListViewItemSorter = lvwColSorter;
            this.lvwLeaveTypes.MultiSelect = false;
            this.lvwLeaveTypes.View = View.Details;
        }

        private void FillList()
        {
            LeaveTypeList objList = new LeaveTypeList();
            objList = LeaveTypeManager.GetList("");

            lvwLeaveTypes.Items.Clear();

            if (objList != null)
            {
                foreach (LeaveType objLeaveType in objList)
                {
                    ListViewItem objLvwItem = new ListViewItem();
                    objLvwItem.Name = Convert.ToString(objLeaveType.DBID);
                    objLvwItem.Text = objLeaveType.LeaveTypeCode;
                    objLvwItem.SubItems.Add(objLeaveType.LeaveTypeName);
                    objLvwItem.SubItems.Add(objLeaveType.YearlyLimit);
                    objLvwItem.SubItems.Add(Convert.ToString(objLeaveType.CarryFwdLimit));

                    lvwLeaveTypes.Items.Add(objLvwItem);
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

        #region  Constructor(s)
        public frmLeaveTypeList()
        {
            InitializeComponent();
            InitializeListView();
        }
        public frmLeaveTypeList(UserCompany objCompany, User objUser)
        {
            this.objCurUser = objUser;
            this.objUserCompany = objCompany;

            objUIRights = new UIRights();

            InitializeComponent();
            InitializeListView();
            GeneralMethods.FormAuthenticate(this.Name, objUserCompany, objCurUser);

            objUIRights.AddRight = GeneralMethods.frmAddRight;
            objUIRights.ModifyRight = GeneralMethods.frmModifyRight;
            objUIRights.ViewRight = GeneralMethods.frmViewRight;
            objUIRights.DeleteRight = GeneralMethods.frmDeleteRight;
            objUIRights.PrintRight = GeneralMethods.repPrintRight;
        }
        #endregion

        #region Context Menu
        private void conMenu_Opening(object sender, CancelEventArgs e)
        {
            if (!IsList)
            {
                if (lvwLeaveTypes.SelectedItems != null && lvwLeaveTypes.SelectedItems.Count != 0)
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

        private void modifyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvwLeaveTypes.SelectedItems != null && lvwLeaveTypes.SelectedItems.Count != 0)
                {
                    if (IsList)
                    {
                        btnOk_Click(sender, e);
                    }
                    else
                    {
                        //if (objUIRights.ModifyRight)
                        //{
                        LeaveType objLeaveType;
                        frmLeaveTypeProp objFrmProp;

                        objLeaveType = LeaveTypeManager.GetItem(Convert.ToInt32(lvwLeaveTypes.SelectedItems[0].Name));
                        objFrmProp = new frmLeaveTypeProp(objLeaveType);
                        objFrmProp.MdiParent = this.MdiParent;
                        objFrmProp.Entry_DataChanged += new frmLeaveTypeProp.LeaveTypeUpdateHandler(Entry_DataChanged);
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
                    LeaveType objLeaveType;
                    frmLeaveTypeProp objFrmProp;

                    objLeaveType = new LeaveType();

                    objFrmProp = new frmLeaveTypeProp(objLeaveType);
                    objFrmProp.IsNew = true;
                    objFrmProp.MdiParent = this.MdiParent;
                    objFrmProp.Entry_DataChanged += new frmLeaveTypeProp.LeaveTypeUpdateHandler(Entry_DataChanged);
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
                if (lvwLeaveTypes.SelectedItems != null && lvwLeaveTypes.SelectedItems.Count != 0)
                {
                    if (!IsList)
                    {
                        //if (objUIRights.DeleteRight)
                        //{
                        DialogResult dr = new DialogResult();
                        dr = MessageBox.Show("Do You Really Want to Delete Record ?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                        if (dr == DialogResult.Yes)
                        {
                            LeaveType objLeaveType = new LeaveType();
                            objLeaveType = LeaveTypeManager.GetItem(Convert.ToInt32(lvwLeaveTypes.SelectedItems[0].Name));
                            LeaveTypeManager.Delete(objLeaveType);
                            lvwLeaveTypes.Items.Remove(lvwLeaveTypes.SelectedItems[0]);
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
        #endregion

        #region UI Control Logic
        private void frmLeaveTypeList_Load(object sender, EventArgs e)
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

        private void frmLeaveTypeList_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dbID == 0)
                flgListCancel = true;
        }

        private void lvwLeaveTypes_ColumnClick(object sender, ColumnClickEventArgs e)
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
            this.lvwLeaveTypes.Sort();
        }

        private void lvwLeaveTypes_DoubleClick(object sender, EventArgs e)
        {
            if (lvwLeaveTypes.SelectedItems != null && lvwLeaveTypes.SelectedItems.Count != 0)
            {
                modifyToolStripMenuItem_Click(sender, e);
            }
        }

        private void lvwLeaveTypes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (lvwLeaveTypes.SelectedItems.Count == 1 && e.KeyChar == (char)Keys.Enter)
            {
                modifyToolStripMenuItem_Click(sender, e);
            }

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsList && lvwLeaveTypes.SelectedItems != null && lvwLeaveTypes.SelectedItems.Count == 1)
                {
                    dbID = Convert.ToInt32(lvwLeaveTypes.SelectedItems[0].Name);
                    leaveCode = lvwLeaveTypes.SelectedItems[0].Text;
                    leaveName = lvwLeaveTypes.SelectedItems[0].SubItems[1].Text;
                    yearlyLimit = lvwLeaveTypes.SelectedItems[0].SubItems[2].Text;
                    carryFwdLimit = Convert.ToInt32(lvwLeaveTypes.SelectedItems[0].SubItems[3].Text);

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
                    leaveCode = string.Empty;
                    leaveName = string.Empty;
                    yearlyLimit = string.Empty;
                    carryFwdLimit = 0;

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
        #endregion

        private void Entry_DataChanged(object sender, LeaveTypeUpdateEventArgs e, DataEventType Action)
        {
            ListViewItem lvItem;
            switch (Action)
            {
                case DataEventType.INSERT_EVENT:

                    lvItem = new ListViewItem();
                    lvItem.Name = Convert.ToString(e.DBID);
                    lvItem.Text = e.LeaveCode;
                    lvItem.SubItems.Add(e.LeaveTypeName);
                    lvItem.SubItems.Add(e.YearlyLimit);
                    lvItem.SubItems.Add(e.CarryFwdLimit.ToString());

                    lvwLeaveTypes.Items.Add(lvItem);
                    lvwLeaveTypes.EnsureVisible(lvItem.Index);

                    break;

                case DataEventType.UPDATE_EVENT:
                    lvItem = lvwLeaveTypes.Items[lvwLeaveTypes.SelectedItems[0].Index];
                    lvItem.Text = e.LeaveCode;
                    lvItem.SubItems[1].Text = e.LeaveTypeName;
                    lvItem.SubItems[2].Text = e.YearlyLimit;
                    lvItem.SubItems[3].Text = e.CarryFwdLimit.ToString();

                    lvwLeaveTypes.EnsureVisible(lvwLeaveTypes.SelectedItems[0].Index);

                    break;
            }
        }
    }
}
