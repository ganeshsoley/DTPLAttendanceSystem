using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DTPLAttendanceSystem
{
    public partial class frmMain : Form
    {
        private int childFormNumber = 0;

        public frmMain()
        {
            InitializeComponent();
        }

        public frmMain(Int32 userID, Int32 companyID)
        {
            //Int32 appUserID, currentCompanyID;
            //appUserID = userID;
            //currentCompanyID = companyID;
            //CurrentCompany = frmMainManager.LoadCompany(companyID);
            //CurrentUser = UserManager.GetItem(userID);
            //curUserRights = UserRightsManager.GetUserRights(userID);
            InitializeComponent();
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }
    }
}
