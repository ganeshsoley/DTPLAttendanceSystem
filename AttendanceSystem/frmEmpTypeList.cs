using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using EntityObject;
using EntityObject.Enum;
using BLL;

namespace AttendanceSystem
{
    public partial class frmEmpTypeList : Form
    {
        #region Private Variable(s)
        private bool flgLoading;
        private bool flgList;
        private bool flgListCancel;

        private long dbID;
        private string empTypeCode;
        private string empTypeName;

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

        public string EmpTypeCode
        {
            get
            {
                return empTypeCode;
            }
            set
            {
                empTypeCode = value;
            }
        }

        public string EmpTypeName
        {
            get
            {
                return empTypeName;
            }
            set
            {
                empTypeName = value;
            }
        }
        #endregion

        #region Private Method(s)
        private void InitializeListView()
        {
            // Create an instance of a ListView column sorter and assign it 
            // to the ListView control.
            lvwColSorter = new ListViewColumnSorter();

            this.lvwEmpTypes.ContextMenuStrip = conMenu;
            this.lvwEmpTypes.FullRowSelect = true;
            this.lvwEmpTypes.GridLines = true;
            this.lvwEmpTypes.ListViewItemSorter = lvwColSorter;
            this.lvwEmpTypes.MultiSelect = false;
            this.lvwEmpTypes.View = View.Details;
        }

        private void FillList()
        {
            EmpTypeList objList = new EmpTypeList();
            objList = EmpTypeManager.GetList("");

            lvwEmpTypes.Items.Clear();

            if (objList != null)
            {
                foreach (EmpType objEmpType in objList)
                {
                    ListViewItem objLvwItem = new ListViewItem();
                    objLvwItem.Name = Convert.ToString(objEmpType.DBID);
                    objLvwItem.Text = Convert.ToString(objEmpType.EmpTypeCode);
                    objLvwItem.SubItems.Add(Convert.ToString(objEmpType.EmpTypeName));

                    lvwEmpTypes.Items.Add(objLvwItem);
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
        public frmEmpTypeList()
        {
            InitializeComponent();
            InitializeListView();
        }

        public frmEmpTypeList(UserCompany objCompany, User objUser)
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

        #region UI Control Logic
        private void frmEmpTypeList_Load(object sender, EventArgs e)
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

        private void frmEmpTypeList_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dbID == 0)
                flgListCancel = true;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsList && lvwEmpTypes.SelectedItems != null && lvwEmpTypes.SelectedItems.Count == 1)
                {
                    dbID = Convert.ToInt32(lvwEmpTypes.SelectedItems[0].Name);
                    empTypeCode = lvwEmpTypes.SelectedItems[0].Text;
                    empTypeName = lvwEmpTypes.SelectedItems[0].SubItems[1].Text;

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
                    empTypeCode = string.Empty;
                    empTypeName = string.Empty;

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

        private void lvwEmpTypes_ColumnClick(object sender, ColumnClickEventArgs e)
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
            lvwEmpTypes.Sort();
        }

        private void lvwEmpTypes_DoubleClick(object sender, EventArgs e)
        {
            if (lvwEmpTypes.SelectedItems != null && lvwEmpTypes.SelectedItems.Count != 0)
            {
                modifyToolStripMenuItem_Click(sender, e);
            }
        }

        private void lvwEmpTypes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (lvwEmpTypes.SelectedItems.Count == 1 && e.KeyChar == (char)Keys.Enter)
            {
                modifyToolStripMenuItem_Click(sender, e);
            }
        }
        #endregion

        #region Context Menu
        private void modifyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvwEmpTypes.SelectedItems != null && lvwEmpTypes.SelectedItems.Count != 0)
                {
                    if (IsList)
                    {
                        btnOk_Click(sender, e);
                    }
                    else
                    {
                        if (objUIRights.ModifyRight)
                        {
                            EmpType objEmpType;
                            frmEmpTypeProp objFrmProp;

                            objEmpType = EmpTypeManager.GetItem(Convert.ToInt32(lvwEmpTypes.SelectedItems[0].Name));
                            objFrmProp = new frmEmpTypeProp(objEmpType);
                            objFrmProp.MdiParent = this.MdiParent;
                            objFrmProp.Entry_DataChanged += new frmEmpTypeProp.EmpTypeUpdateHandler(Entry_DataChanged);
                            objFrmProp.Show();
                        }
                        else
                        {
                            throw new Exception("Not Authorised.");
                        }
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
                    if (objUIRights.AddRight)
                    {
                        EmpType objEmpType;
                        frmEmpTypeProp objFrmProp;

                        objEmpType = new EmpType();
                        objFrmProp = new frmEmpTypeProp(objEmpType);
                        objFrmProp.IsNew = true;
                        objFrmProp.MdiParent = MdiParent;
                        objFrmProp.Entry_DataChanged += new frmEmpTypeProp.EmpTypeUpdateHandler(Entry_DataChanged);
                        objFrmProp.Show();
                    }
                    else
                    {
                        throw new Exception("Not Authorised.");
                    }
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
                if (lvwEmpTypes.SelectedItems != null && lvwEmpTypes.SelectedItems.Count != 0)
                {
                    if (!IsList)
                    {
                        if (objUIRights.DeleteRight)
                        {
                            DialogResult dr = new DialogResult();
                            dr = MessageBox.Show("Do You Really Want to Delete Record ?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                            if (dr == DialogResult.Yes)
                            {
                                EmpType objEmpType = new EmpType();
                                objEmpType = EmpTypeManager.GetItem(Convert.ToInt32(lvwEmpTypes.SelectedItems[0].Name));
                                EmpTypeManager.Delete(objEmpType);
                                lvwEmpTypes.Items.Remove(lvwEmpTypes.SelectedItems[0]);
                            }
                        }
                        else
                        {
                            throw new Exception("Not Authorised.");
                        }
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
                if (lvwEmpTypes.SelectedItems != null && lvwEmpTypes.SelectedItems.Count != 0)
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

        private void Entry_DataChanged(object sender, EmpTypeUpdateEventArgs e, DataEventType Action)
        {
            ListViewItem lvItem;
            switch (Action)
            {
                case DataEventType.INSERT_EVENT:

                    lvItem = new ListViewItem();
                    lvItem.Name = Convert.ToString(e.DBID);
                    lvItem.Text = e.EmpTypeCode;
                    lvItem.SubItems.Add(e.EmpTypeName);

                    lvwEmpTypes.Items.Add(lvItem);
                    lvwEmpTypes.EnsureVisible(lvItem.Index);

                    break;

                case DataEventType.UPDATE_EVENT:
                    lvItem = lvwEmpTypes.Items[lvwEmpTypes.SelectedItems[0].Index];
                    lvItem.Text = e.EmpTypeCode;
                    lvItem.SubItems[1].Text = e.EmpTypeName;

                    lvwEmpTypes.EnsureVisible(lvwEmpTypes.SelectedItems[0].Index);

                    break;
            }
        }
    }
}
