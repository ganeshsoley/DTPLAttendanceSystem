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
    public partial class frmEmpStatusList : Form
    {
        #region Private Variable(s)
        private bool flgLoading;
        private bool flgList;
        private bool flgListCancel;

        private int dbid;
        private string status;

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

        public int DBID
        {
            get
            {
                return dbid;
            }
            set
            {
                dbid = value;
            }
        }

        public string EmpStatus
        {
            get
            {
                return status;
            }
        }
        #endregion

        #region Constructor(s)
        public frmEmpStatusList()
        {
            InitializeComponent();
            InitializeListView();
        }

        public frmEmpStatusList(UserCompany objCompany, User objUser)
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

        #region Private Method(s)
        private void InitializeListView()
        {
            // Create an instance of a ListView column sorter and assign it 
            // to the ListView control.
            lvwColSorter = new ListViewColumnSorter();

            lvwStatuss.ContextMenuStrip = conMenu;
            lvwStatuss.FullRowSelect = true;
            lvwStatuss.GridLines = true;
            lvwStatuss.ListViewItemSorter = lvwColSorter;
            lvwStatuss.MultiSelect = false;
            lvwStatuss.View = View.Details;
        }

        private void FillList()
        {
            EmployeeStatusList objList = new EmployeeStatusList();
            objList = EmployeeStatusManager.GetList("");

            lvwStatuss.Items.Clear();

            if (objList != null)
            {
                foreach (EmployeeStatus objEmpStatus in objList)
                {
                    ListViewItem objLvwItem = new ListViewItem();
                    objLvwItem.Name = Convert.ToString(objEmpStatus.DBID);
                    objLvwItem.Text = Convert.ToString(objEmpStatus.EmpStatus);

                    lvwStatuss.Items.Add(objLvwItem);
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

        #region Context Menu
        private void contextMenu_Opening(object sender, CancelEventArgs e)
        {
            if (!IsList)
            {
                if (lvwStatuss.SelectedItems != null && lvwStatuss.SelectedItems.Count != 0)
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
                if (lvwStatuss.SelectedItems != null && lvwStatuss.SelectedItems.Count != 0)
                {
                    if (IsList)
                    {
                        btnOk_Click(sender, e);
                    }
                    else
                    {
                        //if (objUIRights.ModifyRight)
                        //{
                        EmployeeStatus objEmpStatus;
                        frmEmpStatusProp objFrmProp;

                        objEmpStatus = EmployeeStatusManager.GetItem(Convert.ToInt32(lvwStatuss.SelectedItems[0].Name));
                        objFrmProp = new frmEmpStatusProp(objEmpStatus);
                        objFrmProp.MdiParent = this.MdiParent;
                        objFrmProp.Entry_DataChanged += new frmEmpStatusProp.EmpStatusUpdateHandler(Entry_DataChanged);
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
                    EmployeeStatus objEmpStatus;
                    frmEmpStatusProp objFrmProp;

                    objEmpStatus = new EmployeeStatus();
                    objFrmProp = new frmEmpStatusProp(objEmpStatus);
                    objFrmProp.IsNew = true;
                    objFrmProp.MdiParent = this.MdiParent;
                    objFrmProp.Entry_DataChanged += new frmEmpStatusProp.EmpStatusUpdateHandler(Entry_DataChanged);
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
                if (lvwStatuss.SelectedItems != null && lvwStatuss.SelectedItems.Count != 0)
                {
                    if (!IsList)
                    {
                        //if (objUIRights.DeleteRight)
                        //{
                        DialogResult dr = new DialogResult();
                        dr = MessageBox.Show("Do You Really Want to Delete Record ?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                        if (dr == DialogResult.Yes)
                        {
                            EmployeeStatus objEmpStatus = new EmployeeStatus();
                            objEmpStatus = EmployeeStatusManager.GetItem(Convert.ToInt32(lvwStatuss.SelectedItems[0].Name));
                            EmployeeStatusManager.Delete(objEmpStatus);
                            lvwStatuss.Items.Remove(lvwStatuss.SelectedItems[0]);
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

        private void Entry_DataChanged(object sender, EmpStatusUpdateEventArgs e, DataEventType Action)
        {
            ListViewItem lvItem;
            switch (Action)
            {
                case DataEventType.INSERT_EVENT:

                    lvItem = new ListViewItem();
                    lvItem.Name = Convert.ToString(e.DBID);
                    lvItem.Text = e.EmpStatus;

                    lvwStatuss.Items.Add(lvItem);
                    lvwStatuss.EnsureVisible(lvItem.Index);

                    break;

                case DataEventType.UPDATE_EVENT:
                    lvItem = lvwStatuss.Items[lvwStatuss.SelectedItems[0].Index];
                    lvItem.Text = e.EmpStatus;

                    lvwStatuss.EnsureVisible(lvwStatuss.SelectedItems[0].Index);

                    break;
            }
        }

        #region UI Control Logic
        private void frmEmpStatusList_Load(object sender, EventArgs e)
        {
            Icon = new Icon("Images/DTPL.ico");
            flgLoading = true;
            FillList();
            SetButtonVisibility();
            if (IsList)
            {
                this.CancelButton = btnCancel;
            }
            flgLoading = false;
        }

        private void frmEmpStatusList_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dbid == 0)
                flgListCancel = true;
        }

        private void lvwStatuss_ColumnClick(object sender, ColumnClickEventArgs e)
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
            this.lvwStatuss.Sort();
        }

        private void lvwStatuss_DoubleClick(object sender, EventArgs e)
        {
            if (lvwStatuss.SelectedItems != null && lvwStatuss.SelectedItems.Count != 0)
            {
                modifyToolStripMenuItem_Click(sender, e);
            }
        }

        private void lvwStatuss_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (lvwStatuss.SelectedItems.Count == 1 && e.KeyChar == (char)Keys.Enter)
            {
                modifyToolStripMenuItem_Click(sender, e);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsList && lvwStatuss.SelectedItems != null && lvwStatuss.SelectedItems.Count == 1)
                {
                    dbid = Convert.ToInt32(lvwStatuss.SelectedItems[0].Name);
                    status = lvwStatuss.SelectedItems[0].Text;

                    flgListCancel = false;
                }
                else
                {
                    btnCancel_Click(sender, e);
                }
                Close();
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsList)
                {
                    dbid = 0;
                    status = string.Empty;

                    flgListCancel = true;
                }
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        #endregion
    }
}
