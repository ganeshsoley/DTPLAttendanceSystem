namespace DTPLAttendanceSystem
{
    partial class frmLeaveTypeProp
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkAllowNegBalance = new System.Windows.Forms.CheckBox();
            this.cboConsiderAs = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.rdbFemale = new System.Windows.Forms.RadioButton();
            this.rdbMale = new System.Windows.Forms.RadioButton();
            this.rdbAll = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMonthlyLeaves = new System.Windows.Forms.TextBox();
            this.chkAddLvsMonthly = new System.Windows.Forms.CheckBox();
            this.txtCarryFwdLimit = new System.Windows.Forms.TextBox();
            this.txtYearlyLimit = new System.Windows.Forms.TextBox();
            this.txtLeaveTypeCode = new System.Windows.Forms.TextBox();
            this.txtLeaveTypeName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkAllowNegBalance);
            this.groupBox1.Controls.Add(this.cboConsiderAs);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.rdbFemale);
            this.groupBox1.Controls.Add(this.rdbMale);
            this.groupBox1.Controls.Add(this.rdbAll);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtMonthlyLeaves);
            this.groupBox1.Controls.Add(this.chkAddLvsMonthly);
            this.groupBox1.Controls.Add(this.txtCarryFwdLimit);
            this.groupBox1.Controls.Add(this.txtYearlyLimit);
            this.groupBox1.Controls.Add(this.txtLeaveTypeCode);
            this.groupBox1.Controls.Add(this.txtLeaveTypeName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, -2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(449, 171);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // chkAllowNegBalance
            // 
            this.chkAllowNegBalance.AutoSize = true;
            this.chkAllowNegBalance.Location = new System.Drawing.Point(308, 137);
            this.chkAllowNegBalance.Name = "chkAllowNegBalance";
            this.chkAllowNegBalance.Size = new System.Drawing.Size(139, 17);
            this.chkAllowNegBalance.TabIndex = 16;
            this.chkAllowNegBalance.Text = "Allow Negative Balance";
            this.chkAllowNegBalance.UseVisualStyleBackColor = true;
            this.chkAllowNegBalance.CheckedChanged += new System.EventHandler(this.chkAllowNegBalance_CheckedChanged);
            // 
            // cboConsiderAs
            // 
            this.cboConsiderAs.FormattingEnabled = true;
            this.cboConsiderAs.Location = new System.Drawing.Point(98, 137);
            this.cboConsiderAs.Name = "cboConsiderAs";
            this.cboConsiderAs.Size = new System.Drawing.Size(191, 21);
            this.cboConsiderAs.TabIndex = 15;
            this.cboConsiderAs.SelectedIndexChanged += new System.EventHandler(this.cboConsiderAs_SelectedIndexChanged);
            this.cboConsiderAs.Enter += new System.EventHandler(this.cboConsiderAs_Enter);
            this.cboConsiderAs.Leave += new System.EventHandler(this.cboConsiderAs_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 137);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Consider As";
            // 
            // rdbFemale
            // 
            this.rdbFemale.AutoSize = true;
            this.rdbFemale.Location = new System.Drawing.Point(230, 114);
            this.rdbFemale.Name = "rdbFemale";
            this.rdbFemale.Size = new System.Drawing.Size(59, 17);
            this.rdbFemale.TabIndex = 13;
            this.rdbFemale.TabStop = true;
            this.rdbFemale.Text = "&Female";
            this.rdbFemale.UseVisualStyleBackColor = true;
            this.rdbFemale.CheckedChanged += new System.EventHandler(this.rdbFemale_CheckedChanged);
            // 
            // rdbMale
            // 
            this.rdbMale.AutoSize = true;
            this.rdbMale.Location = new System.Drawing.Point(161, 114);
            this.rdbMale.Name = "rdbMale";
            this.rdbMale.Size = new System.Drawing.Size(48, 17);
            this.rdbMale.TabIndex = 12;
            this.rdbMale.TabStop = true;
            this.rdbMale.Text = "&Male";
            this.rdbMale.UseVisualStyleBackColor = true;
            this.rdbMale.CheckedChanged += new System.EventHandler(this.rdbMale_CheckedChanged);
            // 
            // rdbAll
            // 
            this.rdbAll.AutoSize = true;
            this.rdbAll.Location = new System.Drawing.Point(98, 114);
            this.rdbAll.Name = "rdbAll";
            this.rdbAll.Size = new System.Drawing.Size(36, 17);
            this.rdbAll.TabIndex = 11;
            this.rdbAll.TabStop = true;
            this.rdbAll.Text = "&All";
            this.rdbAll.UseVisualStyleBackColor = true;
            this.rdbAll.CheckedChanged += new System.EventHandler(this.rdbAll_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Gender";
            // 
            // txtMonthlyLeaves
            // 
            this.txtMonthlyLeaves.Location = new System.Drawing.Point(150, 84);
            this.txtMonthlyLeaves.Name = "txtMonthlyLeaves";
            this.txtMonthlyLeaves.Size = new System.Drawing.Size(47, 20);
            this.txtMonthlyLeaves.TabIndex = 9;
            this.txtMonthlyLeaves.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMonthlyLeaves.TextChanged += new System.EventHandler(this.txtMonthlyLeaves_TextChanged);
            this.txtMonthlyLeaves.Enter += new System.EventHandler(this.txtMonthlyLeaves_Enter);
            this.txtMonthlyLeaves.Leave += new System.EventHandler(this.txtMonthlyLeaves_Leave);
            // 
            // chkAddLvsMonthly
            // 
            this.chkAddLvsMonthly.AutoSize = true;
            this.chkAddLvsMonthly.Location = new System.Drawing.Point(21, 84);
            this.chkAddLvsMonthly.Name = "chkAddLvsMonthly";
            this.chkAddLvsMonthly.Size = new System.Drawing.Size(123, 17);
            this.chkAddLvsMonthly.TabIndex = 8;
            this.chkAddLvsMonthly.Text = "Add Leaves Monthly";
            this.chkAddLvsMonthly.UseVisualStyleBackColor = true;
            this.chkAddLvsMonthly.CheckedChanged += new System.EventHandler(this.chkAddLvsMonthly_CheckedChanged);
            // 
            // txtCarryFwdLimit
            // 
            this.txtCarryFwdLimit.Location = new System.Drawing.Point(339, 49);
            this.txtCarryFwdLimit.Name = "txtCarryFwdLimit";
            this.txtCarryFwdLimit.Size = new System.Drawing.Size(61, 20);
            this.txtCarryFwdLimit.TabIndex = 7;
            this.txtCarryFwdLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCarryFwdLimit.TextChanged += new System.EventHandler(this.txtCarryFwdLimit_TextChanged);
            this.txtCarryFwdLimit.Enter += new System.EventHandler(this.txtCarryFwdLimit_Enter);
            this.txtCarryFwdLimit.Leave += new System.EventHandler(this.txtCarryFwdLimit_Leave);
            // 
            // txtYearlyLimit
            // 
            this.txtYearlyLimit.Location = new System.Drawing.Point(119, 49);
            this.txtYearlyLimit.Name = "txtYearlyLimit";
            this.txtYearlyLimit.Size = new System.Drawing.Size(66, 20);
            this.txtYearlyLimit.TabIndex = 6;
            this.txtYearlyLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtYearlyLimit.TextChanged += new System.EventHandler(this.txtYearlyLimit_TextChanged);
            this.txtYearlyLimit.Enter += new System.EventHandler(this.txtYearlyLimit_Enter);
            this.txtYearlyLimit.Leave += new System.EventHandler(this.txtYearlyLimit_Leave);
            // 
            // txtLeaveTypeCode
            // 
            this.txtLeaveTypeCode.Location = new System.Drawing.Point(339, 19);
            this.txtLeaveTypeCode.Name = "txtLeaveTypeCode";
            this.txtLeaveTypeCode.Size = new System.Drawing.Size(97, 20);
            this.txtLeaveTypeCode.TabIndex = 5;
            this.txtLeaveTypeCode.TextChanged += new System.EventHandler(this.txtLeaveTypeCode_TextChanged);
            this.txtLeaveTypeCode.Enter += new System.EventHandler(this.txtLeaveTypeCode_Enter);
            this.txtLeaveTypeCode.Leave += new System.EventHandler(this.txtLeaveTypeCode_Leave);
            // 
            // txtLeaveTypeName
            // 
            this.txtLeaveTypeName.Location = new System.Drawing.Point(119, 19);
            this.txtLeaveTypeName.Name = "txtLeaveTypeName";
            this.txtLeaveTypeName.Size = new System.Drawing.Size(97, 20);
            this.txtLeaveTypeName.TabIndex = 4;
            this.txtLeaveTypeName.TextChanged += new System.EventHandler(this.txtLeaveTypeName_TextChanged);
            this.txtLeaveTypeName.Enter += new System.EventHandler(this.txtLeaveTypeName_Enter);
            this.txtLeaveTypeName.Leave += new System.EventHandler(this.txtLeaveTypeName_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(237, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Carry Forward Limit";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Yearly Limit";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(237, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Short Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Leave Type Name";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnCancel);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Location = new System.Drawing.Point(3, 168);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(449, 56);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(361, 19);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 24);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(276, 19);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 24);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmLeaveTypeProp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 227);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLeaveTypeProp";
            this.Text = "Leave Type";
            this.Load += new System.EventHandler(this.frmLeaveTypeProp_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkAllowNegBalance;
        private System.Windows.Forms.ComboBox cboConsiderAs;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton rdbFemale;
        private System.Windows.Forms.RadioButton rdbMale;
        private System.Windows.Forms.RadioButton rdbAll;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMonthlyLeaves;
        private System.Windows.Forms.CheckBox chkAddLvsMonthly;
        private System.Windows.Forms.TextBox txtCarryFwdLimit;
        private System.Windows.Forms.TextBox txtYearlyLimit;
        private System.Windows.Forms.TextBox txtLeaveTypeCode;
        private System.Windows.Forms.TextBox txtLeaveTypeName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
    }
}