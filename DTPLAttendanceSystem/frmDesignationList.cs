using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntityObject;
using EntityObject.Enum;
using BLL;

namespace DTPLAttendanceSystem
{
    public partial class frmDesignationList : Form
    {
        #region Private Variable
        private bool flgLoading;
        private bool flgList;
        private bool flgListCancel;

        private int dbid;
        private string designation;
        private string descr;

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
        public string Designation
        {
            get
            {
                return designation;
            }
            set
            {
                designation = value;
            }
        }
        public string Description
        {
            get
            {
                return descr;
            }
            set
            {
                descr = value;
            }
        }
        #endregion

        #region  Constructor(s)
        public frmDesignationList()
        {
            InitializeComponent();
        }
        //public frmDesignationList(UserCompany objCompany, User objUser)
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
       //    }
    #endregion

        #region Private Method(s)
    private void InitializeListView()
    {
        // Create an instance of a ListView column sorter and assign it 
        // to the ListView control.
        lvwColSorter = new ListViewColumnSorter();

        this.lvwDesignations.ContextMenuStrip = conMenu;
        this.lvwDesignations.FullRowSelect = true;
        this.lvwDesignations.GridLines = true;
        this.lvwDesignations.ListViewItemSorter = lvwColSorter;
        this.lvwDesignations.MultiSelect = false;
        this.lvwDesignations.View = View.Details;
    }
    private void FillList()
    {

        DesignationList objList = new DesignationList();
        objList = DesignationManager.GetList("");

        lvwDesignations.Items.Clear();

        if (objList != null)
        {
            foreach (Designation objDesig in objList)
            {
                ListViewItem objLvwItem = new ListViewItem();
                objLvwItem.Name = Convert.ToString(objDesig.DBID);
                objLvwItem.Text = Convert.ToString(objDesig.DesigName);
                objLvwItem.SubItems.Add(Convert.ToString(objDesig.Description));

                lvwDesignations.Items.Add(objLvwItem);
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

        #region UI Control Logic
        private void frmDesignationList_Load(object sender, EventArgs e)
        {
            flgLoading = true;
            FillList();
            SetButtonVisibility();
            if (IsList)
            {
                this.CancelButton = btnCancel;
            }
            flgLoading = false;
        }
        private void frmDesignationList_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dbid == 0)
                flgListCancel = true;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsList && lvwDesignations.SelectedItems != null && lvwDesignations.SelectedItems.Count == 1)
                {
                    dbid = Convert.ToInt32(lvwDesignations.SelectedItems[0].Name);
                    designation  = lvwDesignations.SelectedItems[0].Text;
                    descr = lvwDesignations.SelectedItems[0].SubItems[1].Text;

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
                    designation = string.Empty;
                    descr = string.Empty;

                    flgListCancel = true;
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void lvwDesignations_ColumnClick(object sender, ColumnClickEventArgs e)
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
            this.lvwDesignations.Sort();
        }
        private void lvwDesignations_DoubleClick(object sender, EventArgs e)
        {
            if (lvwDesignations.SelectedItems != null && lvwDesignations.SelectedItems.Count != 0)
            {
                modifyToolStripMenuItem_Click(sender, e);
            }
        }
        private void lvwDesignations_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (lvwDesignations.SelectedItems.Count == 1 && e.KeyChar == (char)Keys.Enter)
            {
                modifyToolStripMenuItem_Click(sender, e);
            }
        }


        #endregion

        #region Context Menu
        private void conMenu_Opening(object sender, CancelEventArgs e)
        {
            if (!IsList)
            {
                if (lvwDesignations.SelectedItems != null && lvwDesignations.SelectedItems.Count != 0)
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
                if (lvwDesignations.SelectedItems != null && lvwDesignations.SelectedItems.Count != 0)
                {
                    if (IsList)
                    {
                        btnOk_Click(sender, e);
                    }
                    else
                    {
                        if (objUIRights.ModifyRight)
                        {
                            
                            Designation objDesg;
                            frmDesignationProp objFrmProp;
                            

                            objDesg = DesignationManager.GetItem(Convert.ToInt32(lvwDesignations.SelectedItems[0].Name));
                            objFrmProp = new frmDesignationProp(objDesg);
                            objFrmProp.MdiParent = this.MdiParent;
                            objFrmProp.Entry_DataChanged += new frmDesignationProp.DesgUpdateHandler(Entry_DataChanged);
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
                        
                        Designation objDesg;
                        frmDesignationProp objFrmProp;

                        objDesg = new Designation();
                        objFrmProp = new frmDesignationProp(objDesg);
                        objFrmProp.IsNew = true;
                        objFrmProp.MdiParent = this.MdiParent;
                        objFrmProp.Entry_DataChanged += new frmDesignationProp.DesgUpdateHandler(Entry_DataChanged);
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
                if (lvwDesignations.SelectedItems != null && lvwDesignations.SelectedItems.Count != 0)
                {
                    if (!IsList)
                    {
                        if (objUIRights.DeleteRight)
                        {
                            DialogResult dr = new DialogResult();
                            dr = MessageBox.Show("Do You Really Want to Delete Record ?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                            if (dr == DialogResult.Yes)
                            {
                                Designation objDesg = new Designation();
                                objDesg = DesignationManager.GetItem(Convert.ToInt32(lvwDesignations.SelectedItems[0].Name));
                                DesignationManager.Delete(objDesg);
                                lvwDesignations.Items.Remove(lvwDesignations.SelectedItems[0]);
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
        #endregion

        private void Entry_DataChanged(object sender, DesgUpdateEventArgs e, DataEventType Action)
        {
            ListViewItem lvItem;
            switch (Action)
            {
                case DataEventType.INSERT_EVENT:

                    lvItem = new ListViewItem();
                    lvItem.Name = Convert.ToString(e.DBID);
                    lvItem.Text = e.Desig;
                    lvItem.SubItems.Add(e.Descr);

                    lvwDesignations.Items.Add(lvItem);
                    lvwDesignations.EnsureVisible(lvItem.Index);

                    break;

                case DataEventType.UPDATE_EVENT:
                    lvItem = lvwDesignations.Items[lvwDesignations.SelectedItems[0].Index];
                    lvItem.Text = e.Desig;
                    lvItem.SubItems[1].Text = e.Descr;

                    lvwDesignations.EnsureVisible(lvwDesignations.SelectedItems[0].Index);

                    break;
            }
        }

    }
}


