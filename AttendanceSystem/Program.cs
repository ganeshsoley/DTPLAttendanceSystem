using System;
using System.Diagnostics;
using System.Windows.Forms;
using AttendanceSystem;

namespace AttendanceSystem
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            /// Following Code restricts multiple instances of 
            /// installed application
            Process[] process = Process.GetProcessesByName(Application.ProductName);
            if (process.Length > 1)
            {
                MessageBox.Show(Application.ProductName + " is already running. This instance will now close.",
                    Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }
            else
            {
                frmLogin objLogin = new frmLogin();
                //objLogin.ShowDialog();
                while (!(objLogin.UserID > 0 )) //& objLogin.SelectedComID > 0
                {
                    objLogin.ShowDialog();
                }
                Application.Run(new FrmMain(objLogin.UserID, objLogin.SelectedComID));
                //FrmMain objFrmMain = new FrmMain();
                //objFrmMain.Show();
            };
        }
    }
}
