namespace AttendanceSystem
{
    partial class frmLeaveEntryProp
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
            this.grbProp = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtLeaveType = new System.Windows.Forms.TextBox();
            this.txtDepartment = new System.Windows.Forms.TextBox();
            this.txtEmpName = new System.Windows.Forms.TextBox();
            this.txtEmpID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grbButtons = new System.Windows.Forms.GroupBox();
            this.grbLeave = new System.Windows.Forms.GroupBox();
            this.dtpCOff = new System.Windows.Forms.DateTimePicker();
            this.chkHalfDay = new System.Windows.Forms.CheckBox();
            this.chkIsCoff = new System.Windows.Forms.CheckBox();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.grbProp.SuspendLayout();
            this.grbLeave.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbProp
            // 
            this.grbProp.Controls.Add(this.grbLeave);
            this.grbProp.Controls.Add(this.label9);
            this.grbProp.Controls.Add(this.txtLeaveType);
            this.grbProp.Controls.Add(this.txtDepartment);
            this.grbProp.Controls.Add(this.txtEmpName);
            this.grbProp.Controls.Add(this.txtEmpID);
            this.grbProp.Controls.Add(this.label4);
            this.grbProp.Controls.Add(this.label3);
            this.grbProp.Controls.Add(this.label2);
            this.grbProp.Controls.Add(this.label1);
            this.grbProp.Location = new System.Drawing.Point(3, 3);
            this.grbProp.Name = "grbProp";
            this.grbProp.Size = new System.Drawing.Size(742, 370);
            this.grbProp.TabIndex = 0;
            this.grbProp.TabStop = false;
            this.grbProp.Enter += new System.EventHandler(this.grbProp_Enter);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(135, 309);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Reason";
            // 
            // txtLeaveType
            // 
            this.txtLeaveType.Location = new System.Drawing.Point(108, 107);
            this.txtLeaveType.Name = "txtLeaveType";
            this.txtLeaveType.Size = new System.Drawing.Size(128, 20);
            this.txtLeaveType.TabIndex = 11;
            // 
            // txtDepartment
            // 
            this.txtDepartment.Location = new System.Drawing.Point(108, 81);
            this.txtDepartment.Name = "txtDepartment";
            this.txtDepartment.Size = new System.Drawing.Size(205, 20);
            this.txtDepartment.TabIndex = 10;
            // 
            // txtEmpName
            // 
            this.txtEmpName.Location = new System.Drawing.Point(108, 55);
            this.txtEmpName.Name = "txtEmpName";
            this.txtEmpName.Size = new System.Drawing.Size(205, 20);
            this.txtEmpName.TabIndex = 9;
            // 
            // txtEmpID
            // 
            this.txtEmpID.Location = new System.Drawing.Point(108, 29);
            this.txtEmpID.Name = "txtEmpID";
            this.txtEmpID.Size = new System.Drawing.Size(128, 20);
            this.txtEmpID.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Leave Type";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Department";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Emp Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Employee ID";
            // 
            // grbButtons
            // 
            this.grbButtons.Location = new System.Drawing.Point(3, 396);
            this.grbButtons.Name = "grbButtons";
            this.grbButtons.Size = new System.Drawing.Size(552, 61);
            this.grbButtons.TabIndex = 1;
            this.grbButtons.TabStop = false;
            this.grbButtons.Text = "groupBox2";
            // 
            // grbLeave
            // 
            this.grbLeave.Controls.Add(this.dtpCOff);
            this.grbLeave.Controls.Add(this.chkHalfDay);
            this.grbLeave.Controls.Add(this.chkIsCoff);
            this.grbLeave.Controls.Add(this.txtReason);
            this.grbLeave.Controls.Add(this.dtpToDate);
            this.grbLeave.Controls.Add(this.dtpFromDate);
            this.grbLeave.Controls.Add(this.label8);
            this.grbLeave.Controls.Add(this.label7);
            this.grbLeave.Controls.Add(this.label6);
            this.grbLeave.Controls.Add(this.label5);
            this.grbLeave.Location = new System.Drawing.Point(6, 133);
            this.grbLeave.Name = "grbLeave";
            this.grbLeave.Size = new System.Drawing.Size(452, 123);
            this.grbLeave.TabIndex = 19;
            this.grbLeave.TabStop = false;
            // 
            // dtpCOff
            // 
            this.dtpCOff.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCOff.Location = new System.Drawing.Point(263, 79);
            this.dtpCOff.Name = "dtpCOff";
            this.dtpCOff.Size = new System.Drawing.Size(95, 20);
            this.dtpCOff.TabIndex = 28;
            // 
            // chkHalfDay
            // 
            this.chkHalfDay.AutoSize = true;
            this.chkHalfDay.Location = new System.Drawing.Point(51, 79);
            this.chkHalfDay.Name = "chkHalfDay";
            this.chkHalfDay.Size = new System.Drawing.Size(67, 17);
            this.chkHalfDay.TabIndex = 27;
            this.chkHalfDay.Text = "Half Day";
            this.chkHalfDay.UseVisualStyleBackColor = true;
            // 
            // chkIsCoff
            // 
            this.chkIsCoff.AutoSize = true;
            this.chkIsCoff.Location = new System.Drawing.Point(132, 79);
            this.chkIsCoff.Name = "chkIsCoff";
            this.chkIsCoff.Size = new System.Drawing.Size(56, 17);
            this.chkIsCoff.TabIndex = 26;
            this.chkIsCoff.Text = "C - Off";
            this.chkIsCoff.UseVisualStyleBackColor = true;
            // 
            // txtReason
            // 
            this.txtReason.Location = new System.Drawing.Point(87, 47);
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(271, 20);
            this.txtReason.TabIndex = 25;
            // 
            // dtpToDate
            // 
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToDate.Location = new System.Drawing.Point(263, 19);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(95, 20);
            this.dtpToDate.TabIndex = 24;
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromDate.Location = new System.Drawing.Point(87, 20);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(95, 20);
            this.dtpFromDate.TabIndex = 23;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(202, 79);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "C-Off Date";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Reason";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(202, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "To Date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "From Date";
            // 
            // frmLeaveEntryProp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 469);
            this.Controls.Add(this.grbButtons);
            this.Controls.Add(this.grbProp);
            this.Name = "frmLeaveEntryProp";
            this.Text = "Leave Entry";
            this.Load += new System.EventHandler(this.frmLeaveEntryProp_Load);
            this.grbProp.ResumeLayout(false);
            this.grbProp.PerformLayout();
            this.grbLeave.ResumeLayout(false);
            this.grbLeave.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbProp;
        private System.Windows.Forms.TextBox txtLeaveType;
        private System.Windows.Forms.TextBox txtDepartment;
        private System.Windows.Forms.TextBox txtEmpName;
        private System.Windows.Forms.TextBox txtEmpID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grbButtons;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox grbLeave;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.CheckBox chkIsCoff;
        private System.Windows.Forms.CheckBox chkHalfDay;
        private System.Windows.Forms.DateTimePicker dtpCOff;
    }
}