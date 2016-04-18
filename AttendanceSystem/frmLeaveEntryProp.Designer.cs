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
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnLeaveTypeList = new System.Windows.Forms.Button();
            this.btnEmpList = new System.Windows.Forms.Button();
            this.grbLeave = new System.Windows.Forms.GroupBox();
            this.txtCOffDt = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.chkHalfDay = new System.Windows.Forms.CheckBox();
            this.chkIsCoff = new System.Windows.Forms.CheckBox();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLeaveType = new System.Windows.Forms.TextBox();
            this.txtEmpDept = new System.Windows.Forms.TextBox();
            this.txtEmpName = new System.Windows.Forms.TextBox();
            this.txtEmpID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grbButtons = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.grbProp.SuspendLayout();
            this.grbLeave.SuspendLayout();
            this.grbButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbProp
            // 
            this.grbProp.Controls.Add(this.label10);
            this.grbProp.Controls.Add(this.label9);
            this.grbProp.Controls.Add(this.btnLeaveTypeList);
            this.grbProp.Controls.Add(this.btnEmpList);
            this.grbProp.Controls.Add(this.grbLeave);
            this.grbProp.Controls.Add(this.txtLeaveType);
            this.grbProp.Controls.Add(this.txtEmpDept);
            this.grbProp.Controls.Add(this.txtEmpName);
            this.grbProp.Controls.Add(this.txtEmpID);
            this.grbProp.Controls.Add(this.label4);
            this.grbProp.Controls.Add(this.label3);
            this.grbProp.Controls.Add(this.label2);
            this.grbProp.Controls.Add(this.label1);
            this.grbProp.Location = new System.Drawing.Point(3, 3);
            this.grbProp.Name = "grbProp";
            this.grbProp.Size = new System.Drawing.Size(388, 246);
            this.grbProp.TabIndex = 0;
            this.grbProp.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(227, 107);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(11, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "*";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(227, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(11, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "*";
            // 
            // btnLeaveTypeList
            // 
            this.btnLeaveTypeList.Image = global::AttendanceSystem.Properties.Resources.Search16x16;
            this.btnLeaveTypeList.Location = new System.Drawing.Point(242, 107);
            this.btnLeaveTypeList.Name = "btnLeaveTypeList";
            this.btnLeaveTypeList.Size = new System.Drawing.Size(23, 23);
            this.btnLeaveTypeList.TabIndex = 11;
            this.btnLeaveTypeList.UseVisualStyleBackColor = true;
            this.btnLeaveTypeList.Click += new System.EventHandler(this.btnLeaveTypeList_Click);
            // 
            // btnEmpList
            // 
            this.btnEmpList.Image = global::AttendanceSystem.Properties.Resources.Search16x16;
            this.btnEmpList.Location = new System.Drawing.Point(242, 29);
            this.btnEmpList.Name = "btnEmpList";
            this.btnEmpList.Size = new System.Drawing.Size(23, 23);
            this.btnEmpList.TabIndex = 6;
            this.btnEmpList.UseVisualStyleBackColor = true;
            this.btnEmpList.Click += new System.EventHandler(this.btnEmpList_Click);
            // 
            // grbLeave
            // 
            this.grbLeave.Controls.Add(this.txtCOffDt);
            this.grbLeave.Controls.Add(this.label12);
            this.grbLeave.Controls.Add(this.label11);
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
            this.grbLeave.Size = new System.Drawing.Size(376, 107);
            this.grbLeave.TabIndex = 12;
            this.grbLeave.TabStop = false;
            // 
            // txtCOffDt
            // 
            this.txtCOffDt.Location = new System.Drawing.Point(254, 72);
            this.txtCOffDt.Name = "txtCOffDt";
            this.txtCOffDt.Size = new System.Drawing.Size(95, 20);
            this.txtCOffDt.TabIndex = 24;
            this.txtCOffDt.TextChanged += new System.EventHandler(this.txtCOffDt_TextChanged);
            this.txtCOffDt.Enter += new System.EventHandler(this.txtCOffDt_Enter);
            this.txtCOffDt.Leave += new System.EventHandler(this.txtCOffDt_Leave);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(352, 16);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(11, 13);
            this.label12.TabIndex = 18;
            this.label12.Text = "*";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(185, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(11, 13);
            this.label11.TabIndex = 15;
            this.label11.Text = "*";
            // 
            // chkHalfDay
            // 
            this.chkHalfDay.AutoSize = true;
            this.chkHalfDay.Location = new System.Drawing.Point(44, 68);
            this.chkHalfDay.Name = "chkHalfDay";
            this.chkHalfDay.Size = new System.Drawing.Size(67, 17);
            this.chkHalfDay.TabIndex = 21;
            this.chkHalfDay.Text = "Half Day";
            this.chkHalfDay.UseVisualStyleBackColor = true;
            this.chkHalfDay.CheckedChanged += new System.EventHandler(this.chkHalfDay_CheckedChanged);
            // 
            // chkIsCoff
            // 
            this.chkIsCoff.AutoSize = true;
            this.chkIsCoff.Location = new System.Drawing.Point(126, 68);
            this.chkIsCoff.Name = "chkIsCoff";
            this.chkIsCoff.Size = new System.Drawing.Size(56, 17);
            this.chkIsCoff.TabIndex = 22;
            this.chkIsCoff.Text = "C - Off";
            this.chkIsCoff.UseVisualStyleBackColor = true;
            this.chkIsCoff.CheckedChanged += new System.EventHandler(this.chkIsCoff_CheckedChanged);
            // 
            // txtReason
            // 
            this.txtReason.Location = new System.Drawing.Point(87, 42);
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(262, 20);
            this.txtReason.TabIndex = 20;
            this.txtReason.TextChanged += new System.EventHandler(this.txtReason_TextChanged);
            this.txtReason.Enter += new System.EventHandler(this.txtReason_Enter);
            this.txtReason.Leave += new System.EventHandler(this.txtReason_Leave);
            // 
            // dtpToDate
            // 
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToDate.Location = new System.Drawing.Point(254, 16);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(95, 20);
            this.dtpToDate.TabIndex = 17;
            this.dtpToDate.ValueChanged += new System.EventHandler(this.dtpToDate_ValueChanged);
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromDate.Location = new System.Drawing.Point(87, 16);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(95, 20);
            this.dtpFromDate.TabIndex = 14;
            this.dtpFromDate.ValueChanged += new System.EventHandler(this.dtpFromDate_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(194, 72);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "C-Off Date";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Reason";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(202, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "To Date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "From Date";
            // 
            // txtLeaveType
            // 
            this.txtLeaveType.Enabled = false;
            this.txtLeaveType.Location = new System.Drawing.Point(93, 107);
            this.txtLeaveType.Name = "txtLeaveType";
            this.txtLeaveType.Size = new System.Drawing.Size(128, 20);
            this.txtLeaveType.TabIndex = 9;
            // 
            // txtEmpDept
            // 
            this.txtEmpDept.Enabled = false;
            this.txtEmpDept.Location = new System.Drawing.Point(93, 81);
            this.txtEmpDept.Name = "txtEmpDept";
            this.txtEmpDept.Size = new System.Drawing.Size(237, 20);
            this.txtEmpDept.TabIndex = 8;
            // 
            // txtEmpName
            // 
            this.txtEmpName.Enabled = false;
            this.txtEmpName.Location = new System.Drawing.Point(93, 55);
            this.txtEmpName.Name = "txtEmpName";
            this.txtEmpName.Size = new System.Drawing.Size(237, 20);
            this.txtEmpName.TabIndex = 7;
            // 
            // txtEmpID
            // 
            this.txtEmpID.Enabled = false;
            this.txtEmpID.Location = new System.Drawing.Point(93, 29);
            this.txtEmpID.Name = "txtEmpID";
            this.txtEmpID.Size = new System.Drawing.Size(128, 20);
            this.txtEmpID.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Leave Type";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Department";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Emp Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Employee ID";
            // 
            // grbButtons
            // 
            this.grbButtons.Controls.Add(this.btnCancel);
            this.grbButtons.Controls.Add(this.btnSave);
            this.grbButtons.Location = new System.Drawing.Point(3, 249);
            this.grbButtons.Name = "grbButtons";
            this.grbButtons.Size = new System.Drawing.Size(388, 53);
            this.grbButtons.TabIndex = 1;
            this.grbButtons.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(303, 19);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(66, 21);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(230, 19);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(66, 21);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmLeaveEntryProp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 303);
            this.Controls.Add(this.grbButtons);
            this.Controls.Add(this.grbProp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLeaveEntryProp";
            this.Text = "Leave Entry";
            this.Load += new System.EventHandler(this.frmLeaveEntryProp_Load);
            this.grbProp.ResumeLayout(false);
            this.grbProp.PerformLayout();
            this.grbLeave.ResumeLayout(false);
            this.grbLeave.PerformLayout();
            this.grbButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbProp;
        private System.Windows.Forms.TextBox txtLeaveType;
        private System.Windows.Forms.TextBox txtEmpDept;
        private System.Windows.Forms.TextBox txtEmpName;
        private System.Windows.Forms.TextBox txtEmpID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grbButtons;
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
        private System.Windows.Forms.Button btnLeaveTypeList;
        private System.Windows.Forms.Button btnEmpList;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtCOffDt;
    }
}