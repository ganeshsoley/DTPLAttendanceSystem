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
    public partial class frmBankList : Form
    {
        #region Private Variable(s)
        private bool flgLoading;
        private bool flgList;
        private bool flgListCancel;

        private int dbid;
        private string bankName;
        private string branch;
        private string ifscCode;

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

        public string BankName
        {
            get
            {
                return bankName;
            }
            set
            {
                bankName = value;
            }
        }

        public string Branch
        {
            get
            {
                return branch;
            }
            set
            {
                branch = value;
            }
        }

        public string IFSCCode
        {
            get
            {
                return ifscCode;
            }
            set
            {
                ifscCode = value;
            }
        }
        #endregion

        #region Constructor(s)
        public frmBankList()
        {
            InitializeComponent();
            InitializeListView();
        }

        public frmBankList(UserCompany objCompany, User objUser)
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

            lvwBanks.ContextMenuStrip = conMenu;
            lvwBanks.FullRowSelect = true;
            lvwBanks.GridLines = true;
            lvwBanks.ListViewItemSorter = lvwColSorter;
            lvwBanks.MultiSelect = false;
            lvwBanks.View = View.Details;
        }

        private void FillList()
        {
            BankList objList = new BankList();
            objList = BankManager.GetList("");

            lvwBanks.Items.Clear();

            if (objList != null)
            {
                foreach (Bank objBank in objList)
                {
                    ListViewItem objLvwItem = new ListViewItem();
                    objLvwItem.Name = Convert.ToString(objBank.DBID);
                    objLvwItem.Text = Convert.ToString(objBank.BankName);
                    objLvwItem.SubItems.Add(objBank.Branch);
                    objLvwItem.SubItems.Add(objBank.IFSCCode);

                    lvwBanks.Items.Add(objLvwItem);
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
        private void frmBankList_Load(object sender, EventArgs e)
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

        private void frmBankList_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dbid == 0)
                flgListCancel = true;
        }

        private void lvwBanks_ColumnClick(object sender, ColumnClickEventArgs e)
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
            this.lvwBanks.Sort();
        }

        private void lvwBanks_DoubleClick(object sender, EventArgs e)
        {
            if (lvwBanks.SelectedItems != null && lvwBanks.SelectedItems.Count != 0)
            {
                modifyToolStripMenuItem_Click(sender, e);
            }
        }

        private void lvwBanks_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (lvwBanks.SelectedItems.Count == 1 && e.KeyChar == (char)Keys.Enter)
            {
                modifyToolStripMenuItem_Click(sender, e);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsList && lvwBanks.SelectedItems != null && lvwBanks.SelectedItems.Count == 1)
                {
                    dbid = Convert.ToInt32(lvwBanks.SelectedItems[0].Name);
                    bankName = lvwBanks.SelectedItems[0].Text;
                    branch = lvwBanks.SelectedItems[0].SubItems[1].Text;
                    ifscCode = lvwBanks.SelectedItems[0].SubItems[2].Text;

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
                    bankName = string.Empty;
                    branch = string.Empty;
                    ifscCode = string.Empty;

                    flgListCancel = true;
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        #endregion

        #region Context Menu
        private void contextMenu_Opening(object sender, CancelEventArgs e)
        {
            if (!IsList)
            {
                if (lvwBanks.SelectedItems != null && lvwBanks.SelectedItems.Count != 0)
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
                if (lvwBanks.SelectedItems != null && lvwBanks.SelectedItems.Count != 0)
                {
                    if (IsList)
                    {
                        btnOk_Click(sender, e);
                    }
                    else
                    {
                        //if (objUIRights.ModifyRight)
                        //{
                            Bank objBank;
                            frmBankProp objFrmProp;

                            objBank = BankManager.GetItem(Convert.ToInt32(lvwBanks.SelectedItems[0].Name));
                            objFrmProp = new frmBankProp(objBank);
                            objFrmProp.MdiParent = this.MdiParent;
                            objFrmProp.Entry_DataChanged += new frmBankProp.BankUpdateHandler(Entry_DataChanged);
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
                        Bank objBank;
                        frmBankProp objFrmProp;

                        objBank = new Bank();
                        objFrmProp = new frmBankProp(objBank);
                        objFrmProp.IsNew = true;
                        objFrmProp.MdiParent = this.MdiParent;
                        objFrmProp.Entry_DataChanged += new frmBankProp.BankUpdateHandler(Entry_DataChanged);
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
                if (lvwBanks.SelectedItems != null && lvwBanks.SelectedItems.Count != 0)
                {
                    if (!IsList)
                    {
                        //if (objUIRights.DeleteRight)
                        //{
                            DialogResult dr = new DialogResult();
                            dr = MessageBox.Show("Do You Really Want to Delete Record ?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                            if (dr == DialogResult.Yes)
                            {
                                Bank objBank = new Bank();
                                objBank = BankManager.GetItem(Convert.ToInt32(lvwBanks.SelectedItems[0].Name));
                                BankManager.Delete(objBank);
                                lvwBanks.Items.Remove(lvwBanks.SelectedItems[0]);
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

        private void Entry_DataChanged(object sender, BankUpdateEventArgs e, DataEventType Action)
        {
            ListViewItem lvItem;
            switch (Action)
            {
                case DataEventType.INSERT_EVENT:

                    lvItem = new ListViewItem();
                    lvItem.Name = Convert.ToString(e.DBID);
                    lvItem.Text = e.BankName;
                    lvItem.SubItems.Add(e.Branch);
                    lvItem.SubItems.Add(e.IFSCCode);

                    lvwBanks.Items.Add(lvItem);
                    lvwBanks.EnsureVisible(lvItem.Index);

                    break;

                case DataEventType.UPDATE_EVENT:
                    lvItem = lvwBanks.Items[lvwBanks.SelectedItems[0].Index];
                    lvItem.Text = e.BankName;
                    lvItem.SubItems[1].Text = e.Branch;
                    lvItem.SubItems[2].Text = e.IFSCCode;

                    lvwBanks.EnsureVisible(lvwBanks.SelectedItems[0].Index);

                    break;
            }
        }

    }
}
