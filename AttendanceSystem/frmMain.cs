using System;
using System.Windows.Forms;
using EntityObject;
using BLL;
using System.Drawing;

namespace AttendanceSystem
{
    public partial class FrmMain : Form
    {
        #region Private Variable(s)
        //private int childFormNumber = 0;
        private Int32 curUserID;
        private string[] curUserRights;
        private User CurrentUser;

        public UserCompany CurrentCompany;
        #endregion

        public Int32 CurrentUserID
        {
            get
            {
                return curUserID;
            }
            set
            {
                curUserID = value;
            }
        }

        #region Private Method(s)
        private void DisableMenus()
        {
            DisableMasters();
            DisableTransaction();
            DisableUtilities();
            DisableButtons();
        }

        private void DisableMasters()
        {
        }

        private void DisableDefnMenus()
        {
            mastersToolStripMenuItem.Enabled = false;

        }
        private void DisableTransaction()
        {
            transactionsToolStripMenuItem.Enabled = false;

        }

        private void DisableUtilities()
        {
            utilityToolStripMenuItem.Enabled = false;

        }

        private void DisableButtons()
        {
        }

        private void EnableMenus(string[] objList)
        {
            if (objList != null)
            {
                foreach (string str in objList)
                {
                    switch (str)
                    {
                        case "D0001":
                            //defineToolStripMenuItem.Enabled = true;
                            break;
                        case "D0011":
                            //deptMasterToolStripMenuItem.Enabled = true;
                            break;
                        case "D0012":
                            //employeeMasterToolStripMenuItem.Enabled = true;
                            //btnEmployeeMaster.Enabled = true;
                            break;
                        case "D0013":
                            //visitorMasterToolStripMenuItem.Enabled = true;
                            //btnVisitorMaster.Enabled = true;
                            break;
                        case "D0014":
                            //cityMasterToolStripMenuItem.Enabled = true;
                            break;
                        case "D0015":
                            //driverMasterToolStripMenuItem.Enabled = true;
                            break;
                        case "D0016":
                            //vehicleMasterToolStripMenuItem.Enabled = true;
                            break;
                        case "T0001":
                            //transactionsToolStripMenuItem.Enabled = true;
                            break;
                        case "T0011":
                            //vehicleInOutToolStripMenuItem.Enabled = true;
                            //vehicleInOutCompanyToolStripMenuItem.Enabled = true;
                            //btnVehicleInOut.Enabled = true;
                            //btnCompanyVehInOut.Enabled = true;
                            break;
                        case "T0012":
                            //appointmentMasterToolStripMenuItem.Enabled = true;
                            //btnAppointment.Enabled = true;
                            break;
                        case "T0013":
                            //visitorGatePassToolStripMenuItem.Enabled = true;
                            //btnVisitorGatePass.Enabled = true;
                            break;
                        case "T0014":
                            //returnableDCToolStripMenuItem.Enabled = true;
                            //btnRetDC.Enabled = true;
                            break;
                        case "U0001":
                            //utilitiesToolStripMenuItem.Enabled = true;
                            break;
                        case "U0011":
                            //userRightsToolStripMenuItem.Enabled = true;
                            break;
                    }
                }
            }
        }
        #endregion

        #region Constructor(s)
        public FrmMain()
        {
            InitializeComponent();
        }
        public FrmMain(Int32 userID, Int32 companyID)
        {
            //Int32 appUserID, currentCompanyID;
            //appUserID = userID;
            //currentCompanyID = companyID;
            CurrentCompany = frmMainManager.LoadCompany(companyID);
            CurrentUser = UserManager.GetItem(userID);
            //curUserRights = UserRightsManager.GetUserRights(userID);
            InitializeComponent();
        }
        #endregion

        private void FrmMain_Load(object sender, EventArgs e)
        {
            Icon = new Icon("Images/DTPL.ico");

            DateTime now = DateTime.Now;
            string date = now.GetDateTimeFormats('d')[0];
            string time = now.GetDateTimeFormats('t')[0];

            string fd = CurrentCompany.m_FromDate.ToShortDateString();
            string td = CurrentCompany.m_ToDate.ToShortDateString();

            //DisableMenus();
        }

        private void departmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmDeptList objFrmList = new frmDeptList(CurrentCompany, CurrentUser);
                objFrmList.MdiParent = this;
                objFrmList.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void shiftDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmShiftList objFrmList = new frmShiftList(CurrentCompany, CurrentUser);
                objFrmList.MdiParent = this;
                objFrmList.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void leaveTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmLeaveTypeList objFrmList = new frmLeaveTypeList(CurrentCompany, CurrentUser);
                objFrmList.MdiParent = this;
                objFrmList.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void employeeCategoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmEmpTypeList objFrmList = new frmEmpTypeList(CurrentCompany, CurrentUser);
                objFrmList.MdiParent = this;
                objFrmList.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void holidaysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmHolidayList objFrmList = new frmHolidayList(CurrentCompany, CurrentUser);
                objFrmList.MdiParent = this;
                objFrmList.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void employeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmEmployeeList objFrmList = new frmEmployeeList(CurrentCompany, CurrentUser);
                objFrmList.MdiParent = this;
                objFrmList.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void designationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmDesignationList objFrmList = new frmDesignationList(CurrentCompany, CurrentUser);
                objFrmList.MdiParent = this;
                objFrmList.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void bankMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmBankList objFrmList = new frmBankList(CurrentCompany, CurrentUser);
                objFrmList.MdiParent = this;
                objFrmList.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void userMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmUserList objFrmList = new frmUserList(CurrentCompany, CurrentUser);
                objFrmList.MdiParent = this;
                objFrmList.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void userRightsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmUserAuthority objfrmlist = new frmUserAuthority();
                objfrmlist.MdiParent = this;
                objfrmlist.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void leaveEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmLeaveEntryList objFrmList;
                objFrmList =  new frmLeaveEntryList(CurrentCompany, CurrentUser);
                objFrmList.MdiParent = this;
                objFrmList.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void attendanceLogsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //frmDeptList objFrmList = new frmDeptList();
                //frmDeptList objFrmList = new frmDeptList(CurrentCompany, CurrentUser);
                //objFrmList.MdiParent = this;
                //objFrmList.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void calculateAttendaneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //frmDeptList objFrmList = new frmDeptList();
                //frmDeptList objFrmList = new frmDeptList(CurrentCompany, CurrentUser);
                //objFrmList.MdiParent = this;
                //objFrmList.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void empStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmEmpStatusList objFrmList;
                objFrmList = new frmEmpStatusList(CurrentCompany, CurrentUser);
                objFrmList.MdiParent = this;
                objFrmList.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void utilityToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
