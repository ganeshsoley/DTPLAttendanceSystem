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
    public partial class frmLeaveEntryList : Form
    {
        #region Private Variable(s)
        private bool flgLoading;
        private bool flgList;
        private bool flgListCancel;

        private long dbID;
        private string empID;
        private string empName;
        private string empDept;
        private string leaveTypeName;
        private string fromDate;
        private string toDate;

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
        #endregion

        #region Public Leave Entry Properties
        public long DBID
        {
            get
            {
                return dbID;
            }
        }

        public string EmpID
        {
            get
            {
                return empID;
            }
        }

        public string EmpName
        {
            get
            {
                return empName;
            }
        }

        public string EmpDept
        {
            get
            {
                return empDept;
            }
        }

        public string LeaveTypeName
        {
            get
            {
                return leaveTypeName;
            }
        }

        private string FromDate
        {
            get
            {
                return fromDate;
            }
        }

        private string ToDate
        {
            get
            {
                return ToDate;
            }
        }
        #endregion

        #region Private Method(s)
        private void InitializeListView()
        {
            // Create an instance of a ListView column sorter and assign it 
            // to the ListView control.
            lvwColSorter = new ListViewColumnSorter();

            lvwLeaves.ContextMenuStrip = conMenu;
            lvwLeaves.FullRowSelect = true;
            lvwLeaves.GridLines = true;
            lvwLeaves.ListViewItemSorter = lvwColSorter;
            lvwLeaves.MultiSelect = false;
            lvwLeaves.View = View.Details;
        }

        private void FillList()
        {
            LeaveApplicationList objList = new LeaveApplicationList();
            objList = LeaveApplicationManager.GetList("");

            lvwLeaves.Items.Clear();

            if (objList != null)
            {
                foreach (LeaveApplication objLVAppln in objList)
                {
                    ListViewItem objLvwItem = new ListViewItem();
                    objLvwItem.Name = Convert.ToString(objLVAppln.DBID);
                    objLvwItem.Text = Convert.ToString(objLVAppln.FromDate);
                    objLvwItem.SubItems.Add(Convert.ToString(objLVAppln.ToDate));
                    objLvwItem.SubItems.Add(Convert.ToString(objLVAppln.EmpID));
                    objLvwItem.SubItems.Add(Convert.ToString(objLVAppln.EmpName));
                    objLvwItem.SubItems.Add(Convert.ToString(objLVAppln.EmpDept));
                    objLvwItem.SubItems.Add(Convert.ToString(objLVAppln.LeaveType));

                    lvwLeaves.Items.Add(objLvwItem);
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
        public frmLeaveEntryList()
        {
            InitializeComponent();
            InitializeListView();
        }

        public frmLeaveEntryList(UserCompany objCompany, User objUser)
        {
            objCurUser = objUser;
            objUserCompany = objCompany;

            objUIRights = new UIRights();

            InitializeComponent();
            InitializeListView();
            GeneralMethods.FormAuthenticate(Name, objUserCompany, objCurUser);

            objUIRights.AddRight = GeneralMethods.frmAddRight;
            objUIRights.ModifyRight = GeneralMethods.frmModifyRight;
            objUIRights.ViewRight = GeneralMethods.frmViewRight;
            objUIRights.DeleteRight = GeneralMethods.frmDeleteRight;
            objUIRights.PrintRight = GeneralMethods.repPrintRight;
        }
        #endregion

        #region Context Menu
        private void modifyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvwLeaves.SelectedItems != null && lvwLeaves.SelectedItems.Count != 0)
                {
                    if (IsList)
                    {
                        btnOk_Click(sender, e);
                    }
                    else
                    {
                        //if (objUIRights.ModifyRight)
                        //{
                            LeaveApplication objLeaveEntry;
                            frmLeaveEntryProp objFrmProp;

                            objLeaveEntry= LeaveApplicationManager.GetItem(Convert.ToInt32(lvwLeaves.SelectedItems[0].Name));
                            objFrmProp = new frmLeaveEntryProp(objLeaveEntry);
                            objFrmProp.MdiParent = this.MdiParent;
                            objFrmProp.Entry_DataChanged += new frmLeaveEntryProp.LeaveApplicationUpdateHandler(Entry_DataChanged);
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
                    //if (objUIRights.AddRight)
                    //{
                        LeaveApplication objLeaveEntry;
                        frmLeaveEntryProp objFrmProp;

                        objLeaveEntry = new LeaveApplication();
                        objFrmProp = new frmLeaveEntryProp(objLeaveEntry);
                        objFrmProp.IsNew = true;
                        objFrmProp.MdiParent = MdiParent;
                        objFrmProp.Entry_DataChanged += new frmLeaveEntryProp.LeaveApplicationUpdateHandler(Entry_DataChanged);
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
                if (lvwLeaves.SelectedItems != null && lvwLeaves.SelectedItems.Count != 0)
                {
                    if (!IsList)
                    {
                        //if (objUIRights.DeleteRight)
                        //{
                            DialogResult dr = new DialogResult();
                            dr = MessageBox.Show("Do You Really Want to Delete Record ?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                            if (dr == DialogResult.Yes)
                            {
                                LeaveApplication objLeaveEntry = new LeaveApplication();
                                objLeaveEntry = LeaveApplicationManager.GetItem(Convert.ToInt32(lvwLeaves.SelectedItems[0].Name));
                                LeaveApplicationManager.Delete(objLeaveEntry);
                                lvwLeaves.Items.Remove(lvwLeaves.SelectedItems[0]);
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
                if (lvwLeaves.SelectedItems != null && lvwLeaves.SelectedItems.Count != 0)
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

        private void frmLeaveEntryList_Load(object sender, EventArgs e)
        {
            Icon = new Icon("Images/DTPL.ico");
            flgLoading = true;
            FillList();
            SetButtonVisibility();
            if (IsList)
            {
                CancelButton = btnCancel;
            }
            flgLoading = false;
        }

        private void frmLeaveEntryList_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dbID == 0)
                flgListCancel = true;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsList && lvwLeaves.SelectedItems != null && lvwLeaves.SelectedItems.Count == 1)
                {
                    dbID = Convert.ToInt32(lvwLeaves.SelectedItems[0].Name);
                    fromDate = lvwLeaves.SelectedItems[0].Text;
                    toDate = lvwLeaves.SelectedItems[0].SubItems[1].Text;
                    empID = lvwLeaves.SelectedItems[0].SubItems[2].Text;
                    empName = lvwLeaves.SelectedItems[0].SubItems[3].Text;
                    empDept = lvwLeaves.SelectedItems[0].SubItems[4].Text;
                    leaveTypeName = lvwLeaves.SelectedItems[0].SubItems[5].Text;

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
                    fromDate = string.Empty;
                    toDate= string.Empty;
                    empID = string.Empty; ;
                    empName = string.Empty; ;
                    empDept = string.Empty;
                    leaveTypeName = string.Empty;

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

        private void Entry_DataChanged(object sender, LeaveApplicationUpdateEventArgs e, DataEventType Action)
        {
            ListViewItem lvItem;
            switch (Action)
            {
                case DataEventType.INSERT_EVENT:

                    lvItem = new ListViewItem();
                    lvItem.Name = Convert.ToString(e.DBID);
                    lvItem.Text = e.FromDate.ToShortDateString();
                    lvItem.SubItems.Add(e.ToDate.ToShortDateString());
                    lvItem.SubItems.Add(e.EmpID);
                    lvItem.SubItems.Add(e.EmpName);
                    lvItem.SubItems.Add(e.EmpDept);
                    lvItem.SubItems.Add(e.LeaveType);


                    lvwLeaves.Items.Add(lvItem);
                    lvwLeaves.EnsureVisible(lvItem.Index);

                    break;

                case DataEventType.UPDATE_EVENT:
                    lvItem = lvwLeaves.Items[lvwLeaves.SelectedItems[0].Index];
                    lvItem.Text = e.FromDate.ToShortDateString();
                    lvItem.SubItems[1].Text = e.ToDate.ToShortDateString();
                    lvItem.SubItems[2].Text = e.EmpID;
                    lvItem.SubItems[3].Text = e.EmpName;
                    lvItem.SubItems[4].Text = e.EmpDept;
                    lvItem.SubItems[5].Text = e.LeaveType;

                    lvwLeaves.EnsureVisible(lvwLeaves.SelectedItems[0].Index);

                    break;
            }
        }
    }

}
