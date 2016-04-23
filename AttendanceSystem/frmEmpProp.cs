using System;
using System.Drawing;
using System.Windows.Forms;
using BLL;
using EntityObject;
using EntityObject.Enum;

namespace AttendanceSystem
{
    public partial class frmEmpProp : Form
    {
        #region Private Variable(s)
        private bool flgNew;
        private bool flgLoading;

        private Employee objEmp;
        private EmployeeLeave objItemSelected;
        private ListViewColumnSorter lvwColSorter;
        #endregion

        #region Constructor
        public frmEmpProp()
        {
            InitializeComponent();
            InitializeListView();
        }

        public frmEmpProp(Employee objEmp)
        {
            this.objEmp = objEmp;
            InitializeComponent();
            InitializeListView();
        }
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

        /// <summary>
        /// Contains Delegates and events available on Form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="Action"></param>

        #region Delegate & Event
        public delegate void EmpUpdateHandler(object sender, EmpUpdateEventArgs e, DataEventType Action);

        public event EmpUpdateHandler Entry_DataChanged;
        #endregion

        #region Private Methods
        private void EnableDisableSave()
        {
            btnSave.Enabled = objEmp.IsValid;
        }

        private void Emp_OnValid(object sender, EventArgs e)
        {
            EnableDisableSave();
        }

        private void Emp_OnInValid(object sender, EventArgs e)
        {
            EnableDisableSave();
        }

        private void SubscribeToEvents()
        {
            objEmp.OnValid += new Employee.EventHandler(Emp_OnValid);
            objEmp.OnInvalid += new Employee.EventHandler(Emp_OnInValid);
        }

        private void EnableDisableItemOK()
        {
            btnItemOkNew.Enabled = objItemSelected.IsValid;
            btnItemOk.Enabled = objItemSelected.IsValid;
        }

        private void EmpLeave_OnValid(object sender, EventArgs e)
        {
            EnableDisableItemOK();
        }

        private void EmpLeave_OnInvalid(object sender, EventArgs e)
        {
            EnableDisableItemOK();
        }

        private void SubscribeToEmpLeavesEvents()
        {
            objItemSelected.OnValid += new EmployeeLeave.EventHandler(EmpLeave_OnValid);
            objItemSelected.OnInvalid += new EmployeeLeave.EventHandler(EmpLeave_OnInvalid);
        }

        private void FillPlantList()
        {
            cboPlant.Items.Add("DTPL 100");
            cboPlant.Items.Add("DTPL 102");
            cboPlant.Items.Add("DTPL 103");
        }

        private void FillGenderList()
        {
            cboGender.Items.Add("MALE");
            cboGender.Items.Add("FEMALE");
            cboGender.Items.Add("OTHER");
        }

        private void LoadEmpLeaves()
        {
            EmpLeavesList objList = objEmp.EmpLeaves;

            lvwEmpLeaveBal.Items.Clear();
            if (objList != null)
            {// && objList.Count > 0
                foreach (EmployeeLeave objItem in objList)
                {
                    ListViewItem lvItem = new ListViewItem();
                    lvItem.Name = Convert.ToString(objItem.DBID);
                    lvItem.Text = Convert.ToString(objItem.LeaveType);
                    lvItem.SubItems.Add(Convert.ToString(objItem.LeavesBalance));

                    lvwEmpLeaveBal.Items.Add(lvItem);
                }
            }
        }

        private void LoadItem()
        {
            flgLoading = true;
            grbEmpLeaves.Visible = true;

            lblLeaveType.Text = objItemSelected.LeaveType;
            txtLeaveBal.Text = Convert.ToString(objItemSelected.LeavesBalance);
            btnLeaveTypeList.Focus();

            SubscribeToEmpLeavesEvents();
            flgLoading = false;
        }

        private void AddItem()
        {
            if (objItemSelected.IsNew == true)
            {
                if (objEmp.EmpLeaves != null)
                {
                    foreach (EmployeeLeave objEmpLeave in objEmp.EmpLeaves)
                    {
                        if (objEmpLeave.LeaveTypeID == objItemSelected.LeaveTypeID)
                            throw new Exception("Leave Type already Exists.");
                    }
                    objEmp.EmpLeaves.Add(objItemSelected);
                }
                else
                {
                    objEmp.EmpLeaves = new EmpLeavesList();
                    objEmp.EmpLeaves.Add(objItemSelected);
                }
            }
            else
            {
                objEmp.EmpLeaves[lvwEmpLeaveBal.SelectedIndices[0]] = objItemSelected;
            }
        }

        private void InitializeListView()
        {
            lvwColSorter = new ListViewColumnSorter();
            
            lvwEmpLeaveBal.FullRowSelect = true;
            lvwEmpLeaveBal.GridLines = true;
            lvwEmpLeaveBal.ListViewItemSorter = lvwColSorter;
            lvwEmpLeaveBal.MultiSelect = false;
            lvwEmpLeaveBal.View = View.Details;
        }
        #endregion

        private void frmEmpProp_Load(object sender, EventArgs e)
        {
            this.Icon = new Icon("Images/DTPL.ico");
            flgLoading = true;
            Emp_OnInValid(sender, e);

            FillPlantList();
            FillGenderList();
            if (objEmp.IsNew)
            {
                this.Text += " [ NEW ]";
            }
            else
            {
                this.Text += " [ " + objEmp.Initials + " ]";
                txtEmpCode.Enabled = false;
            }
            txtEmpCode.Text = objEmp.EmpCode;
            txtFName.Text = objEmp.FirstName;
            txtMidName.Text = objEmp.MiddleName;
            txtLName.Text = objEmp.LastName;
            lblInitials.Text = objEmp.Initials;
            lblDept.Text = objEmp.DeptName;
            lblDesignations.Text = objEmp.Designation;
            lblEmpType.Text = objEmp.EmpType;
            lblEmpStatus.Text = objEmp.EmpStatus;
            if (objEmp.JoinDate != DateTime.MinValue)
                dtpJoinDate.Value = objEmp.JoinDate;
            if (objEmp.JoinDate != DateTime.MinValue)
                dtpBirthDate.Value = objEmp.BirthDate;
            cboPlant.Text = objEmp.EmpPlant;

            cboGender.Text = objEmp.Gender;
            txtEMail.Text = objEmp.EMailID;
            txtMobileNo.Text = objEmp.MobileNo;
            lblBankName.Text = objEmp.BankName;
            txtAccountNo.Text = objEmp.AccountNo;
            txtPFNo.Text = objEmp.PFNo;
            txtLeftDate.Text = objEmp.LeftDate;

            if (objEmp.CalculateSalary == 1)
                chkCalSalary.Checked = true;
            else
                chkCalSalary.Checked = false;

            if (objEmp.CalculatePF == 1)
                chkCalPF.Checked = true;
            else
                chkCalPF.Checked = false;

            if (objEmp.FlgESI == 1)
                chkCalESI.Checked = true;
            else
                chkCalESI.Checked = false;

            if (objEmp.CalculatePT == 1)
                chkCalPT.Checked = true;
            else
                chkCalPT.Checked = false;

            if (objEmp.FlgLWF == 1)
                chkCalLWF.Checked = true;
            else
                chkCalLWF.Checked = false;

            if (objEmp.FlgCOff == 1)
                chkCompOff.Checked = true;
            else
                chkCompOff.Checked = false;

            if (objEmp.InActive == 1)
                chkInActive.Checked = true;
            else
                chkInActive.Checked = false;

            LoadEmpLeaves();
            grbEmpLeaves.Visible = false;
            SubscribeToEvents();
            flgLoading = false;
        }

        private void frmEmpProp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtEmpCode_Enter(object sender, EventArgs e)
        {
            GeneralMethods.Selection(txtEmpCode);
        }

        private void txtEmpCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsLetter(e.KeyChar) || Char.IsNumber(e.KeyChar) || (e.KeyChar == (char)Keys.Back) || (e.KeyChar == (char)Keys.Delete)))
                e.Handled = true;
        }

        private void txtEmpCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!IsLoading)
                {
                    objEmp.EmpCode = txtEmpCode.Text.Trim();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtEmpCode_Leave(object sender, EventArgs e)
        {
            txtEmpCode.Text = objEmp.EmpCode;
        }

        private void txtFName_Enter(object sender, EventArgs e)
        {
            GeneralMethods.Selection(txtFName);
        }

        private void txtFName_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyValue >= 48 & e.KeyValue <= 57)
            //    e.SuppressKeyPress = true;
            //else
            //    e.SuppressKeyPress = false;
        }

        private void txtFName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsLetter(e.KeyChar) || (e.KeyChar == (char)Keys.Back) || (e.KeyChar == (char)Keys.Delete) || (e.KeyChar == (char)Keys.Space)))
                e.Handled = true;
        }

        private void txtFName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!IsLoading)
                {
                    objEmp.FirstName = txtFName.Text.Trim();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtFName_Leave(object sender, EventArgs e)
        {
            txtFName.Text = objEmp.FirstName;
            lblInitials.Text = objEmp.Initials;
        }

        private void txtMidName_Enter(object sender, EventArgs e)
        {
            GeneralMethods.Selection(txtMidName);
        }

        private void txtMidName_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyValue >= 48 & e.KeyValue <= 57)
            //    e.SuppressKeyPress = true;
            //else
            //    e.SuppressKeyPress = false;
        }

        private void txtMidName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsLetter(e.KeyChar) || (e.KeyChar == (char)Keys.Back) || (e.KeyChar == (char)Keys.Delete) || (e.KeyChar == (char)Keys.Space)))
                e.Handled = true;
        }

        private void txtMidName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!IsLoading)
                {
                    objEmp.MiddleName = txtMidName.Text.Trim();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtMidName_Leave(object sender, EventArgs e)
        {
            txtMidName.Text = objEmp.MiddleName;
            lblInitials.Text = objEmp.Initials;
        }

        private void txtLName_Enter(object sender, EventArgs e)
        {
            GeneralMethods.Selection(txtLName);
        }

        private void txtLName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsLetter(e.KeyChar) || (e.KeyChar == (char)Keys.Back) || (e.KeyChar == (char)Keys.Delete) || (e.KeyChar == (char)Keys.Space)))
                e.Handled = true;
        }

        private void txtLName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!IsLoading)
                {
                    objEmp.LastName = txtLName.Text.Trim();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtLName_Leave(object sender, EventArgs e)
        {
            txtLName.Text = objEmp.LastName;
            lblInitials.Text = objEmp.Initials;
        }

        private void btnDeptList_Click(object sender, EventArgs e)
        {
            frmDeptList frmList = new frmDeptList();
            frmList.IsList = true;
            frmList.ShowDialog();

            if (!frmList.IsListCancel)
            {
                objEmp.DeptID = frmList.DBID;
                objEmp.DeptName = frmList.DeptName;

                lblDept.Text = objEmp.DeptName;
                SendKeys.Send("{TAB}");
            }
            frmList.Dispose();
        }

        private void txtEMail_Enter(object sender, EventArgs e)
        {
            txtEMail.SelectAll();
        }

        private void txtEMail_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!IsLoading)
                {
                    objEmp.EMailID = txtEMail.Text.Trim();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtEMail_Leave(object sender, EventArgs e)
        {
            txtEMail.Text = objEmp.EMailID;
        }

        private void txtMobileNo_Enter(object sender, EventArgs e)
        {
            txtMobileNo.SelectAll();
        }

        private void txtMobileNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back) || (e.KeyChar == (char)Keys.Delete)))
                e.Handled = true;
        }

        private void txtMobileNo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!IsLoading)
                {
                    objEmp.MobileNo = txtMobileNo.Text.Trim();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtMobileNo_Leave(object sender, EventArgs e)
        {
            txtMobileNo.Text = objEmp.MobileNo;
        }

        private void cboPlant_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!IsLoading)
                {
                    objEmp.EmpPlant = cboPlant.Text;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnDesigList_Click(object sender, EventArgs e)
        {
            frmDesignationList frmList = new frmDesignationList();
            frmList.IsList = true;
            frmList.ShowDialog();

            if (!frmList.IsListCancel)
            {
                objEmp.DesignationID = frmList.DBID;
                objEmp.Designation = frmList.Designation;

                lblDesignations.Text = objEmp.Designation;
                SendKeys.Send("{TAB}");
            }
            frmList.Dispose();
        }

        private void btnEmpType_Click(object sender, EventArgs e)
        {
            frmEmpTypeList frmList = new frmEmpTypeList();
            frmList.IsList = true;
            frmList.ShowDialog();

            if (!frmList.IsListCancel)
            {
                objEmp.EmpTypeID = frmList.DBID;
                objEmp.EmpType = frmList.EmpTypeName;

                lblEmpType.Text = objEmp.EmpType;
                SendKeys.Send("{TAB}");
            }
            frmList.Dispose();
        }

        private void btnEmpStatusList_Click(object sender, EventArgs e)
        {
            frmEmpStatusList frmList = new frmEmpStatusList();
            frmList.IsList = true;
            frmList.ShowDialog();

            if (!frmList.IsListCancel)
            {
                objEmp.EmpStatusID = frmList.DBID;
                objEmp.EmpStatus = frmList.EmpStatus;

                lblEmpStatus.Text = objEmp.EmpStatus;
                SendKeys.Send("{TAB}");
            }
            frmList.Dispose();
        }

        private void btnBankList_Click(object sender, EventArgs e)
        {
            frmBankList frmList = new frmBankList();
            frmList.IsList = true;
            frmList.ShowDialog();

            if (!frmList.IsListCancel)
            {
                objEmp.BankID = frmList.DBID;
                objEmp.BankName = frmList.BankName;

                lblBankName.Text = objEmp.BankName;
                SendKeys.Send("{TAB}");
            }
            frmList.Dispose();
        }

        private void dtpJoinDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (!IsLoading)
                {
                    objEmp.JoinDate = dtpJoinDate.Value;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dtpBirthDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (!IsLoading)
                {
                    objEmp.BirthDate = dtpBirthDate.Value;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtAccountNo_Enter(object sender, EventArgs e)
        {
            txtAccountNo.SelectAll();
        }

        private void txtAccountNo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!IsLoading)
                {
                    objEmp.AccountNo= txtAccountNo.Text.Trim();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtAccountNo_Leave(object sender, EventArgs e)
        {
            txtAccountNo.Text = objEmp.AccountNo;
        }

        private void txtPFNo_Enter(object sender, EventArgs e)
        {
            txtPFNo.SelectAll();
        }

        private void txtPFNo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!IsLoading)
                {
                    objEmp.PFNo = txtPFNo.Text.Trim();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtPFNo_Leave(object sender, EventArgs e)
        {
            txtPFNo.Text = objEmp.PFNo;
        }

        private void txtLeftDate_Enter(object sender, EventArgs e)
        {
            txtLeftDate.SelectAll();
        }

        private void txtLeftDate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!IsLoading)
                {
                    DateTime dt;
                    if (GeneralMethods.IsDate(txtLeftDate.Text, out dt) & txtLeftDate.Text.Trim().Length == 10)
                    {
                        objEmp.LeftDate = txtLeftDate.Text.Trim();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtLeftDate_Leave(object sender, EventArgs e)
        {
            txtLeftDate.Text = objEmp.LeftDate;
        }

        private void chkCalSalary_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (!IsLoading)
                {
                    if (chkCalSalary.Checked)
                        objEmp.CalculateSalary = 1;
                    else
                        objEmp.CalculateSalary = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void chkCalPF_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (!IsLoading)
                {
                    if (chkCalPF.Checked)
                        objEmp.CalculatePF = 1;
                    else
                        objEmp.CalculatePF = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void chkCalESI_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (!IsLoading)
                {
                    if (chkCalESI.Checked)
                        objEmp.FlgESI = 1;
                    else
                        objEmp.FlgESI = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void chkCalPT_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (!IsLoading)
                {
                    if (chkCalPT.Checked)
                        objEmp.CalculatePT = 1;
                    else
                        objEmp.CalculatePT = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void chkCalLWF_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (!IsLoading)
                {
                    if (chkCalLWF.Checked)
                        objEmp.FlgLWF = 1;
                    else
                        objEmp.FlgLWF = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void chkCompOff_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (!IsLoading)
                {
                    if (chkCompOff.Checked)
                        objEmp.FlgCOff = 1;
                    else
                        objEmp.FlgCOff = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void chkInActive_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (!IsLoading)
                {
                    if (chkInActive.Checked)
                        objEmp.InActive = 1;
                    else
                        objEmp.InActive = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                bool flgApplyEdit;
                flgApplyEdit = EmployeeManager.Save(objEmp);
                if (flgApplyEdit)
                {
                    // instance the event args and pass it value
                    EmpUpdateEventArgs args = new EmpUpdateEventArgs(objEmp.DBID, objEmp.Initials, objEmp.EmpCode, objEmp.DeptName, objEmp.EmpPlant);

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

        private void cboGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!IsLoading)
                {
                    objEmp.Gender = cboGender.Text;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void cboGender_Enter(object sender, EventArgs e)
        {
            cboGender.SelectAll();
        }

        private void cboGender_Leave(object sender, EventArgs e)
        {
            cboGender.Text = objEmp.Gender;
        }

        private void conMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (lvwEmpLeaveBal.SelectedItems != null && lvwEmpLeaveBal.SelectedItems.Count != 0)
            {
                newToolStripMenuItem.Enabled = false;
                deleteToolStripMenuItem.Visible = true;
            }
            else
            {
                newToolStripMenuItem.Enabled = true;
                deleteToolStripMenuItem.Visible = false;
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            objItemSelected = new EmployeeLeave();
            EmpLeave_OnInvalid(sender, e);
            LoadItem();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvwEmpLeaveBal.SelectedItems != null & lvwEmpLeaveBal.SelectedItems.Count != 0)
            {
                DialogResult dr = new DialogResult();
                dr = MessageBox.Show("Do You Really want to Delete Record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.Yes)
                {
                    objEmp.EmpLeaves[Convert.ToInt32(lvwEmpLeaveBal.SelectedItems[0].Index)].IsDeleted = true;
                    lvwEmpLeaveBal.SelectedItems[0].Remove();
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            newToolStripMenuItem_Click(sender, e);
        }

        private void btnLeaveTypeList_Click(object sender, EventArgs e)
        {
            frmLeaveTypeList frmList = new frmLeaveTypeList();
            frmList.IsList = true;
            frmList.ShowDialog();

            if (!frmList.IsListCancel)
            {
                objItemSelected.LeaveTypeID = frmList.DBID;
                objItemSelected.LeaveType = frmList.LeaveCode;

                lblLeaveType.Text = objItemSelected.LeaveType;
                SendKeys.Send("{TAB}");
            }
            frmList.Close();
            frmList.Dispose();
        }

        private void txtLeaveBal_Enter(object sender, EventArgs e)
        {
            txtLeaveBal.SelectAll();
        }

        private void txtLeaveBal_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!IsLoading)
                {
                    objItemSelected.LeavesBalance = Convert.ToDecimal(txtLeaveBal.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtLeaveBal_Leave(object sender, EventArgs e)
        {
            txtLeaveBal.Text = Convert.ToString(objItemSelected.LeavesBalance);
        }

        private void btnItemOkNew_Click(object sender, EventArgs e)
        {
            try
            {
                // Add Current Item To Collection
                AddItem();
                // Add an event to set Employee's Edited flag to true...
                objEmp.IsEdited = true;
                // dispose current item
                // how to dispose this item
                // initialize New Item
                newToolStripMenuItem_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnItemOk_Click(object sender, EventArgs e)
        {
            try
            {
                // Add Valid item to Collection
                AddItem();
                // Add an event to set Employee's Edited flag to true...
                objEmp.IsEdited = true;

                grbEmpLeaves.Visible = false;
                // Load items into list.
                LoadEmpLeaves();
                lvwEmpLeaveBal.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnItemCancel_Click(object sender, EventArgs e)
        {
            try
            {
                grbEmpLeaves.Visible = false;
                // Load Items into List.
                LoadEmpLeaves();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtUANNo_Enter(object sender, EventArgs e)
        {
            txtUANNo.SelectAll();
        }

        private void txtUANNo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!IsLoading)
                {
                    objEmp.UANNo = txtUANNo.Text;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtUANNo_Leave(object sender, EventArgs e)
        {
            txtUANNo.Text = objEmp.UANNo;
        }
    }

    public class EmpUpdateEventArgs : System.EventArgs
    {
        private long mDBID;
        private string mInitials;
        private string mEmpCode;
        private string mDeptName;
        private string mEmpPlant;

        public EmpUpdateEventArgs(long sDBID, string sInitials, string sEmpCode, string sDeptName, string sEmpPlant)
        {
            this.mDBID = sDBID;
            this.mInitials = sInitials;
            this.mEmpCode = sEmpCode;
            this.mDeptName = sDeptName;
            this.mEmpPlant = sEmpPlant;
        }

        public long DBID
        {
            get
            {
                return mDBID;
            }
        }

        public string Initials
        {
            get
            {
                return mInitials;
            }
        }

        public string DeptName
        {
            get
            {
                return mDeptName;
            }
        }

        public string EmpCode
        {
            get
            {
                return mEmpCode;
            }
        }

        public string EmpPlant
        {
            get
            {
                return mEmpPlant;
            }
        }
    }
}
