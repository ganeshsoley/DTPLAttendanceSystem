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
using BLL;

namespace AttendanceSystem
{
    public partial class FrmMain : Form
    {
        #region Private Variable(s)
        private int childFormNumber = 0;
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

        public FrmMain()
        {
            InitializeComponent();
        }

        private void departmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //frmDeptList objFrmList = new frmDeptList();
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
                //frmDeptList objFrmList = new frmDeptList();
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
                //frmDeptList objFrmList = new frmDeptList();
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
                //frmDeptList objFrmList = new frmDeptList();
                frmEmployeeList objFrmList = new frmEmployeeList(CurrentCompany, CurrentUser);
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
                //frmDeptList objFrmList = new frmDeptList();
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
                //frmDeptList objFrmList = new frmDeptList();
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
                //frmDeptList objFrmList = new frmDeptList();
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

        private void userMasterToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void userRightsToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void leaveEntryToolStripMenuItem_Click(object sender, EventArgs e)
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
    }
}
