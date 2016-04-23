namespace AttendanceSystem
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.mnuMainMenu = new System.Windows.Forms.MenuStrip();
            this.mastersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shiftDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.leaveTypesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.empStatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.employeeCategoriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.holidaysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.employeesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.departmentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.designationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bankMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userRightsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transactionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.leaveEntryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.attendanceLogsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calculateAttendaneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.utilityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.statusStrip.SuspendLayout();
            this.mnuMainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 431);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(632, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel.Text = "Status";
            // 
            // mnuMainMenu
            // 
            this.mnuMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mastersToolStripMenuItem,
            this.transactionsToolStripMenuItem,
            this.utilityToolStripMenuItem});
            this.mnuMainMenu.Location = new System.Drawing.Point(0, 0);
            this.mnuMainMenu.Name = "mnuMainMenu";
            this.mnuMainMenu.Size = new System.Drawing.Size(632, 24);
            this.mnuMainMenu.TabIndex = 4;
            this.mnuMainMenu.Text = "menuStrip1";
            // 
            // mastersToolStripMenuItem
            // 
            this.mastersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bankMasterToolStripMenuItem,
            this.holidaysToolStripMenuItem,
            this.departmentsToolStripMenuItem,
            this.toolStripSeparator1,
            this.shiftDetailsToolStripMenuItem,
            this.leaveTypesToolStripMenuItem,
            this.toolStripSeparator2,
            this.employeeCategoriesToolStripMenuItem,
            this.empStatusToolStripMenuItem,
            this.designationsToolStripMenuItem,
            this.employeesToolStripMenuItem,
            this.toolStripSeparator3,
            this.userMasterToolStripMenuItem,
            this.userRightsToolStripMenuItem});
            this.mastersToolStripMenuItem.Name = "mastersToolStripMenuItem";
            this.mastersToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.mastersToolStripMenuItem.Text = "Masters";
            // 
            // shiftDetailsToolStripMenuItem
            // 
            this.shiftDetailsToolStripMenuItem.Name = "shiftDetailsToolStripMenuItem";
            this.shiftDetailsToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.shiftDetailsToolStripMenuItem.Text = "Shift Details";
            this.shiftDetailsToolStripMenuItem.Click += new System.EventHandler(this.shiftDetailsToolStripMenuItem_Click);
            // 
            // leaveTypesToolStripMenuItem
            // 
            this.leaveTypesToolStripMenuItem.Name = "leaveTypesToolStripMenuItem";
            this.leaveTypesToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.leaveTypesToolStripMenuItem.Text = "Leave Types";
            this.leaveTypesToolStripMenuItem.Click += new System.EventHandler(this.leaveTypesToolStripMenuItem_Click);
            // 
            // empStatusToolStripMenuItem
            // 
            this.empStatusToolStripMenuItem.Name = "empStatusToolStripMenuItem";
            this.empStatusToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.empStatusToolStripMenuItem.Text = "Employee Status";
            this.empStatusToolStripMenuItem.Click += new System.EventHandler(this.empStatusToolStripMenuItem_Click);
            // 
            // employeeCategoriesToolStripMenuItem
            // 
            this.employeeCategoriesToolStripMenuItem.Name = "employeeCategoriesToolStripMenuItem";
            this.employeeCategoriesToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.employeeCategoriesToolStripMenuItem.Text = "Employee Types";
            this.employeeCategoriesToolStripMenuItem.Click += new System.EventHandler(this.employeeCategoriesToolStripMenuItem_Click);
            // 
            // holidaysToolStripMenuItem
            // 
            this.holidaysToolStripMenuItem.Name = "holidaysToolStripMenuItem";
            this.holidaysToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.holidaysToolStripMenuItem.Text = "Holidays";
            this.holidaysToolStripMenuItem.Click += new System.EventHandler(this.holidaysToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(173, 6);
            // 
            // employeesToolStripMenuItem
            // 
            this.employeesToolStripMenuItem.Name = "employeesToolStripMenuItem";
            this.employeesToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.employeesToolStripMenuItem.Text = "Employee Master";
            this.employeesToolStripMenuItem.Click += new System.EventHandler(this.employeesToolStripMenuItem_Click);
            // 
            // departmentsToolStripMenuItem
            // 
            this.departmentsToolStripMenuItem.Name = "departmentsToolStripMenuItem";
            this.departmentsToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.departmentsToolStripMenuItem.Text = "Department Master";
            this.departmentsToolStripMenuItem.Click += new System.EventHandler(this.departmentsToolStripMenuItem_Click);
            // 
            // designationsToolStripMenuItem
            // 
            this.designationsToolStripMenuItem.Name = "designationsToolStripMenuItem";
            this.designationsToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.designationsToolStripMenuItem.Text = "Designations";
            this.designationsToolStripMenuItem.Click += new System.EventHandler(this.designationsToolStripMenuItem_Click);
            // 
            // bankMasterToolStripMenuItem
            // 
            this.bankMasterToolStripMenuItem.Name = "bankMasterToolStripMenuItem";
            this.bankMasterToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.bankMasterToolStripMenuItem.Text = "Bank Master";
            this.bankMasterToolStripMenuItem.Click += new System.EventHandler(this.bankMasterToolStripMenuItem_Click);
            // 
            // userMasterToolStripMenuItem
            // 
            this.userMasterToolStripMenuItem.Name = "userMasterToolStripMenuItem";
            this.userMasterToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.userMasterToolStripMenuItem.Text = "User Master";
            this.userMasterToolStripMenuItem.Click += new System.EventHandler(this.userMasterToolStripMenuItem_Click);
            // 
            // userRightsToolStripMenuItem
            // 
            this.userRightsToolStripMenuItem.Name = "userRightsToolStripMenuItem";
            this.userRightsToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.userRightsToolStripMenuItem.Text = "User Rights";
            this.userRightsToolStripMenuItem.Click += new System.EventHandler(this.userRightsToolStripMenuItem_Click);
            // 
            // transactionsToolStripMenuItem
            // 
            this.transactionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.leaveEntryToolStripMenuItem,
            this.attendanceLogsToolStripMenuItem,
            this.calculateAttendaneToolStripMenuItem});
            this.transactionsToolStripMenuItem.Name = "transactionsToolStripMenuItem";
            this.transactionsToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.transactionsToolStripMenuItem.Text = "Transactions";
            // 
            // leaveEntryToolStripMenuItem
            // 
            this.leaveEntryToolStripMenuItem.Name = "leaveEntryToolStripMenuItem";
            this.leaveEntryToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.leaveEntryToolStripMenuItem.Text = "Leave Entry";
            this.leaveEntryToolStripMenuItem.Click += new System.EventHandler(this.leaveEntryToolStripMenuItem_Click);
            // 
            // attendanceLogsToolStripMenuItem
            // 
            this.attendanceLogsToolStripMenuItem.Name = "attendanceLogsToolStripMenuItem";
            this.attendanceLogsToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.attendanceLogsToolStripMenuItem.Text = "Attendance Logs";
            this.attendanceLogsToolStripMenuItem.Click += new System.EventHandler(this.attendanceLogsToolStripMenuItem_Click);
            // 
            // calculateAttendaneToolStripMenuItem
            // 
            this.calculateAttendaneToolStripMenuItem.Name = "calculateAttendaneToolStripMenuItem";
            this.calculateAttendaneToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.calculateAttendaneToolStripMenuItem.Text = "Calculate Attendance";
            this.calculateAttendaneToolStripMenuItem.Click += new System.EventHandler(this.calculateAttendaneToolStripMenuItem_Click);
            // 
            // utilityToolStripMenuItem
            // 
            this.utilityToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backUpToolStripMenuItem});
            this.utilityToolStripMenuItem.Name = "utilityToolStripMenuItem";
            this.utilityToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.utilityToolStripMenuItem.Text = "Utility";
            this.utilityToolStripMenuItem.Click += new System.EventHandler(this.utilityToolStripMenuItem_Click);
            // 
            // backUpToolStripMenuItem
            // 
            this.backUpToolStripMenuItem.Name = "backUpToolStripMenuItem";
            this.backUpToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.backUpToolStripMenuItem.Text = "Back Up";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(173, 6);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(173, 6);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 453);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.mnuMainMenu);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mnuMainMenu;
            this.Name = "FrmMain";
            this.Text = "DTPL Attendance System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.mnuMainMenu.ResumeLayout(false);
            this.mnuMainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.MenuStrip mnuMainMenu;
        private System.Windows.Forms.ToolStripMenuItem mastersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shiftDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem leaveTypesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem employeeCategoriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem holidaysToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem employeesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem departmentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem designationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bankMasterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userMasterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userRightsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transactionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem leaveEntryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem attendanceLogsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem calculateAttendaneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem utilityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backUpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem empStatusToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}



