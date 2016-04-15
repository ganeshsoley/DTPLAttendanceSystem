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
    public partial class frmShiftList : Form
    {
        #region Private Variable(s)
        private bool flgLoading;
        private bool flgList;
        private bool flgListCancel;

        private long dbID;
        private string shiftCode;
        private string shiftName;
        private string shiftBeginTime;
        private string shiftEndTime;

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
        }

        public string ShiftCode
        {
            get
            {
                return shiftCode;
            }
        }

        public string ShiftName
        {
            get
            {
                return shiftName;
            }
        }
        
        public string ShiftBeginTime
        {
            get
            {
                return shiftBeginTime;
            }
        }

        public string ShiftEndTime
        {
            get
            {
                return shiftEndTime;
            }

        }
        #endregion

        #region Private Method(s)
        private void InitializeListView()
        {
            // Create an instance of a ListView column sorter and assign it 
            // to the ListView control.
            lvwColSorter = new ListViewColumnSorter();

            this.lvwShifts.ContextMenuStrip = conMenu;
            this.lvwShifts.FullRowSelect = true;
            this.lvwShifts.GridLines = true;
            this.lvwShifts.ListViewItemSorter = lvwColSorter;
            this.lvwShifts.MultiSelect = false;
            this.lvwShifts.View = View.Details;
        }

        private void FillList()
        {
            ShiftList objList = new ShiftList();
            objList = ShiftManager.GetList("");

            lvwShifts.Items.Clear();

            if (objList != null)
            {
                foreach (Shift objShift in objList)
                {
                    ListViewItem objLvwItem = new ListViewItem();
                    objLvwItem.Name = Convert.ToString(objShift.DBID);
                    objLvwItem.Text = objShift.ShiftName;
                    objLvwItem.SubItems.Add(objShift.ShiftCode);
                    objLvwItem.SubItems.Add(objShift.ShiftBeginTime);
                    objLvwItem.SubItems.Add(objShift.ShiftEndTime);

                    lvwShifts.Items.Add(objLvwItem);
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
        public frmShiftList()
        {
            InitializeComponent();
        }

        public frmShiftList(UserCompany objCompany, User objUser)
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
        private void conMenu_Opening(object sender, CancelEventArgs e)
        {
            if (!IsList)
            {
                if (lvwShifts.SelectedItems != null && lvwShifts.SelectedItems.Count != 0)
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
                if (lvwShifts.SelectedItems != null && lvwShifts.SelectedItems.Count != 0)
                {
                    if (IsList)
                    {
                        btnOk_Click(sender, e);
                    }
                    else
                    {
                        //if (objUIRights.ModifyRight)
                        //{
                        Shift objShift;
                        frmShiftProp objFrmProp;

                        objShift = ShiftManager.GetItem(Convert.ToInt32(lvwShifts.SelectedItems[0].Name));
                        objFrmProp = new frmShiftProp(objShift);
                        objFrmProp.MdiParent = this.MdiParent;
                        objFrmProp.Entry_DataChanged += new frmShiftProp.ShiftUpdateHandler(Entry_DataChanged);
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
                    Shift objShift;
                    frmShiftProp objFrmProp;

                    objShift = new Shift();

                    objFrmProp = new frmShiftProp(objShift);
                    objFrmProp.IsNew = true;
                    objFrmProp.MdiParent = this.MdiParent;
                    objFrmProp.Entry_DataChanged += new frmShiftProp.ShiftUpdateHandler(Entry_DataChanged);
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
                if (lvwShifts.SelectedItems != null && lvwShifts.SelectedItems.Count != 0)
                {
                    if (!IsList)
                    {
                        //if (objUIRights.DeleteRight)
                        //{
                        DialogResult dr = new DialogResult();
                        dr = MessageBox.Show("Do You Really Want to Delete Record ?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                        if (dr == DialogResult.Yes)
                        {
                            Shift objShift = new Shift();
                            objShift = ShiftManager.GetItem(Convert.ToInt32(lvwShifts.SelectedItems[0].Name));
                            ShiftManager.Delete(objShift);
                            lvwShifts.Items.Remove(lvwShifts.SelectedItems[0]);
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
        private void frmShiftList_Load(object sender, EventArgs e)
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

        private void frmShiftList_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dbID == 0)
                flgListCancel = true;
        }

        private void lvwShifts_ColumnClick(object sender, ColumnClickEventArgs e)
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
            lvwShifts.Sort();
        }

        private void lvwShifts_DoubleClick(object sender, EventArgs e)
        {
            if (lvwShifts.SelectedItems != null && lvwShifts.SelectedItems.Count != 0)
            {
                modifyToolStripMenuItem_Click(sender, e);
            }
        }

        private void lvwShifts_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (lvwShifts.SelectedItems.Count == 1 && e.KeyChar == (char)Keys.Enter)
            {
                modifyToolStripMenuItem_Click(sender, e);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsList && lvwShifts.SelectedItems != null && lvwShifts.SelectedItems.Count == 1)
                {
                    dbID = Convert.ToInt32(lvwShifts.SelectedItems[0].Name);
                    shiftName= lvwShifts.SelectedItems[0].Text;
                    shiftCode = lvwShifts.SelectedItems[0].SubItems[1].Text;
                    shiftBeginTime= lvwShifts.SelectedItems[0].SubItems[2].Text;
                    shiftEndTime = lvwShifts.SelectedItems[0].SubItems[3].Text;

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
                    shiftCode = string.Empty;
                    shiftName = string.Empty;
                    shiftBeginTime = string.Empty;
                    shiftEndTime = string.Empty;

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

        private void Entry_DataChanged(object sender, ShiftUpdateEventArgs e, DataEventType Action)
        {
            ListViewItem lvItem;
            switch (Action)
            {
                case DataEventType.INSERT_EVENT:

                    lvItem = new ListViewItem();
                    lvItem.Name = Convert.ToString(e.DBID);
                    lvItem.Text = e.ShiftName;
                    lvItem.SubItems.Add(e.ShiftCode);
                    lvItem.SubItems.Add(e.BeginTime);
                    lvItem.SubItems.Add(e.EndTime);

                    lvwShifts.Items.Add(lvItem);
                    lvwShifts.EnsureVisible(lvItem.Index);

                    break;

                case DataEventType.UPDATE_EVENT:
                    lvItem = lvwShifts.Items[lvwShifts.SelectedItems[0].Index];
                    lvItem.Text = e.ShiftName;
                    lvItem.SubItems[1].Text = e.ShiftCode;
                    lvItem.SubItems[2].Text = e.BeginTime;
                    lvItem.SubItems[3].Text = e.EndTime;

                    lvwShifts.EnsureVisible(lvwShifts.SelectedItems[0].Index);

                    break;
            }
        }
    }
}
