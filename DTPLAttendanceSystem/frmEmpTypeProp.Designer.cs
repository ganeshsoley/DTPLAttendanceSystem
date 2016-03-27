namespace DTPLAttendanceSystem
{
    partial class frmEmpTypeProp
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
            this.grbMain = new System.Windows.Forms.GroupBox();
            this.chkMarkWOHasBothDayAbsent = new System.Windows.Forms.CheckBox();
            this.txtAbsentMins = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.chkCalculateAbsent = new System.Windows.Forms.CheckBox();
            this.txtHDMins = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.chkCalulateHalfDay = new System.Windows.Forms.CheckBox();
            this.txtEGGraceTime = new System.Windows.Forms.TextBox();
            this.txtLCGraceTime = new System.Windows.Forms.TextBox();
            this.txtMinOT = new System.Windows.Forms.TextBox();
            this.cboOTFormula = new System.Windows.Forms.ComboBox();
            this.txtEmpTypeName = new System.Windows.Forms.TextBox();
            this.txtEmpTypeCode = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grbButtons = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.grbMain.SuspendLayout();
            this.grbButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbMain
            // 
            this.grbMain.Controls.Add(this.chkMarkWOHasBothDayAbsent);
            this.grbMain.Controls.Add(this.txtAbsentMins);
            this.grbMain.Controls.Add(this.label10);
            this.grbMain.Controls.Add(this.chkCalculateAbsent);
            this.grbMain.Controls.Add(this.txtHDMins);
            this.grbMain.Controls.Add(this.label9);
            this.grbMain.Controls.Add(this.chkCalulateHalfDay);
            this.grbMain.Controls.Add(this.txtEGGraceTime);
            this.grbMain.Controls.Add(this.txtLCGraceTime);
            this.grbMain.Controls.Add(this.txtMinOT);
            this.grbMain.Controls.Add(this.cboOTFormula);
            this.grbMain.Controls.Add(this.txtEmpTypeName);
            this.grbMain.Controls.Add(this.txtEmpTypeCode);
            this.grbMain.Controls.Add(this.label8);
            this.grbMain.Controls.Add(this.label7);
            this.grbMain.Controls.Add(this.label6);
            this.grbMain.Controls.Add(this.label5);
            this.grbMain.Controls.Add(this.label4);
            this.grbMain.Controls.Add(this.label3);
            this.grbMain.Controls.Add(this.label2);
            this.grbMain.Controls.Add(this.label1);
            this.grbMain.Location = new System.Drawing.Point(3, -2);
            this.grbMain.Name = "grbMain";
            this.grbMain.Size = new System.Drawing.Size(502, 225);
            this.grbMain.TabIndex = 0;
            this.grbMain.TabStop = false;
            // 
            // chkMarkWOHasBothDayAbsent
            // 
            this.chkMarkWOHasBothDayAbsent.AutoSize = true;
            this.chkMarkWOHasBothDayAbsent.Location = new System.Drawing.Point(17, 192);
            this.chkMarkWOHasBothDayAbsent.Name = "chkMarkWOHasBothDayAbsent";
            this.chkMarkWOHasBothDayAbsent.Size = new System.Drawing.Size(405, 17);
            this.chkMarkWOHasBothDayAbsent.TabIndex = 20;
            this.chkMarkWOHasBothDayAbsent.Text = "Mark Weekly Off and Holiday as Absent if Both Prefix and Sufix Days are Absent";
            this.chkMarkWOHasBothDayAbsent.UseVisualStyleBackColor = true;
            this.chkMarkWOHasBothDayAbsent.CheckedChanged += new System.EventHandler(this.chkMarkWOHasBothDayAbsent_CheckedChanged);
            // 
            // txtAbsentMins
            // 
            this.txtAbsentMins.Location = new System.Drawing.Point(272, 166);
            this.txtAbsentMins.Name = "txtAbsentMins";
            this.txtAbsentMins.Size = new System.Drawing.Size(45, 20);
            this.txtAbsentMins.TabIndex = 19;
            this.txtAbsentMins.TextChanged += new System.EventHandler(this.txtAbsentMins_TextChanged);
            this.txtAbsentMins.Enter += new System.EventHandler(this.txtAbsentMins_Enter);
            this.txtAbsentMins.Leave += new System.EventHandler(this.txtAbsentMins_Leave);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(323, 167);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Mins";
            // 
            // chkCalculateAbsent
            // 
            this.chkCalculateAbsent.AutoSize = true;
            this.chkCalculateAbsent.Location = new System.Drawing.Point(17, 166);
            this.chkCalculateAbsent.Name = "chkCalculateAbsent";
            this.chkCalculateAbsent.Size = new System.Drawing.Size(249, 17);
            this.chkCalculateAbsent.TabIndex = 17;
            this.chkCalculateAbsent.Text = "Calculate Absent if Work Duration is Less Than";
            this.chkCalculateAbsent.UseVisualStyleBackColor = true;
            this.chkCalculateAbsent.CheckedChanged += new System.EventHandler(this.chkCalculateAbsent_CheckedChanged);
            // 
            // txtHDMins
            // 
            this.txtHDMins.Location = new System.Drawing.Point(272, 140);
            this.txtHDMins.Name = "txtHDMins";
            this.txtHDMins.Size = new System.Drawing.Size(45, 20);
            this.txtHDMins.TabIndex = 16;
            this.txtHDMins.TextChanged += new System.EventHandler(this.txtHDMins_TextChanged);
            this.txtHDMins.Enter += new System.EventHandler(this.txtHDMins_Enter);
            this.txtHDMins.Leave += new System.EventHandler(this.txtHDMins_Leave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(323, 140);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Mins";
            // 
            // chkCalulateHalfDay
            // 
            this.chkCalulateHalfDay.AutoSize = true;
            this.chkCalulateHalfDay.Location = new System.Drawing.Point(17, 140);
            this.chkCalulateHalfDay.Name = "chkCalulateHalfDay";
            this.chkCalulateHalfDay.Size = new System.Drawing.Size(254, 17);
            this.chkCalulateHalfDay.TabIndex = 14;
            this.chkCalulateHalfDay.Text = "Calculate Half Day if work Duration is Less Than";
            this.chkCalulateHalfDay.UseVisualStyleBackColor = true;
            this.chkCalulateHalfDay.CheckedChanged += new System.EventHandler(this.chkCalulateHalfDay_CheckedChanged);
            // 
            // txtEGGraceTime
            // 
            this.txtEGGraceTime.Location = new System.Drawing.Point(159, 114);
            this.txtEGGraceTime.Name = "txtEGGraceTime";
            this.txtEGGraceTime.Size = new System.Drawing.Size(45, 20);
            this.txtEGGraceTime.TabIndex = 13;
            this.txtEGGraceTime.TextChanged += new System.EventHandler(this.txtEGGraceTime_TextChanged);
            this.txtEGGraceTime.Enter += new System.EventHandler(this.txtEGGraceTime_Enter);
            this.txtEGGraceTime.Leave += new System.EventHandler(this.txtEGGraceTime_Leave);
            // 
            // txtLCGraceTime
            // 
            this.txtLCGraceTime.Location = new System.Drawing.Point(159, 87);
            this.txtLCGraceTime.Name = "txtLCGraceTime";
            this.txtLCGraceTime.Size = new System.Drawing.Size(45, 20);
            this.txtLCGraceTime.TabIndex = 12;
            this.txtLCGraceTime.TextChanged += new System.EventHandler(this.txtLCGraceTime_TextChanged);
            this.txtLCGraceTime.Enter += new System.EventHandler(this.txtLCGraceTime_Enter);
            this.txtLCGraceTime.Leave += new System.EventHandler(this.txtLCGraceTime_Leave);
            // 
            // txtMinOT
            // 
            this.txtMinOT.Location = new System.Drawing.Point(381, 55);
            this.txtMinOT.Name = "txtMinOT";
            this.txtMinOT.Size = new System.Drawing.Size(46, 20);
            this.txtMinOT.TabIndex = 11;
            this.txtMinOT.TextChanged += new System.EventHandler(this.txtMinOT_TextChanged);
            this.txtMinOT.Enter += new System.EventHandler(this.txtMinOT_Enter);
            this.txtMinOT.Leave += new System.EventHandler(this.txtMinOT_Leave);
            // 
            // cboOTFormula
            // 
            this.cboOTFormula.FormattingEnabled = true;
            this.cboOTFormula.Location = new System.Drawing.Point(86, 55);
            this.cboOTFormula.Name = "cboOTFormula";
            this.cboOTFormula.Size = new System.Drawing.Size(227, 21);
            this.cboOTFormula.TabIndex = 10;
            this.cboOTFormula.SelectedIndexChanged += new System.EventHandler(this.cboOTFormula_SelectedIndexChanged);
            this.cboOTFormula.Enter += new System.EventHandler(this.cboOTFormula_Enter);
            this.cboOTFormula.Leave += new System.EventHandler(this.cboOTFormula_Leave);
            // 
            // txtEmpTypeName
            // 
            this.txtEmpTypeName.Location = new System.Drawing.Point(319, 26);
            this.txtEmpTypeName.Name = "txtEmpTypeName";
            this.txtEmpTypeName.Size = new System.Drawing.Size(168, 20);
            this.txtEmpTypeName.TabIndex = 9;
            this.txtEmpTypeName.TextChanged += new System.EventHandler(this.txtEmpTypeName_TextChanged);
            this.txtEmpTypeName.Enter += new System.EventHandler(this.txtEmpTypeName_Enter);
            this.txtEmpTypeName.Leave += new System.EventHandler(this.txtEmpTypeName_Leave);
            // 
            // txtEmpTypeCode
            // 
            this.txtEmpTypeCode.Location = new System.Drawing.Point(86, 26);
            this.txtEmpTypeCode.Name = "txtEmpTypeCode";
            this.txtEmpTypeCode.Size = new System.Drawing.Size(118, 20);
            this.txtEmpTypeCode.TabIndex = 8;
            this.txtEmpTypeCode.TextChanged += new System.EventHandler(this.txtEmpTypeCode_TextChanged);
            this.txtEmpTypeCode.Enter += new System.EventHandler(this.txtEmpTypeCode_Enter);
            this.txtEmpTypeCode.Leave += new System.EventHandler(this.txtEmpTypeCode_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(210, 114);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Mins";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(210, 87);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Mins";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 114);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(134, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Grace Time for Early Going";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(139, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Grace Time for Late Coming";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(333, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Min OT";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "OT Formula";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(230, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "EmpType Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "EmpType";
            // 
            // grbButtons
            // 
            this.grbButtons.Controls.Add(this.btnCancel);
            this.grbButtons.Controls.Add(this.btnSave);
            this.grbButtons.Location = new System.Drawing.Point(3, 223);
            this.grbButtons.Name = "grbButtons";
            this.grbButtons.Size = new System.Drawing.Size(502, 50);
            this.grbButtons.TabIndex = 1;
            this.grbButtons.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(419, 19);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 24);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(334, 19);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 24);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmEmpTypeProp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 275);
            this.Controls.Add(this.grbButtons);
            this.Controls.Add(this.grbMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEmpTypeProp";
            this.Text = "Employee Type";
            this.Load += new System.EventHandler(this.frmEmpTypeProp_Load);
            this.grbMain.ResumeLayout(false);
            this.grbMain.PerformLayout();
            this.grbButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbMain;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grbButtons;
        private System.Windows.Forms.CheckBox chkMarkWOHasBothDayAbsent;
        private System.Windows.Forms.TextBox txtAbsentMins;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox chkCalculateAbsent;
        private System.Windows.Forms.TextBox txtHDMins;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox chkCalulateHalfDay;
        private System.Windows.Forms.TextBox txtEGGraceTime;
        private System.Windows.Forms.TextBox txtLCGraceTime;
        private System.Windows.Forms.TextBox txtMinOT;
        private System.Windows.Forms.ComboBox cboOTFormula;
        private System.Windows.Forms.TextBox txtEmpTypeName;
        private System.Windows.Forms.TextBox txtEmpTypeCode;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
    }
}