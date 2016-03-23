namespace DTPLAttendanceSystem
{
    partial class frmShiftProp
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
            this.grbShift = new System.Windows.Forms.GroupBox();
            this.txtGraceTime = new System.Windows.Forms.TextBox();
            this.txtPunchEnd = new System.Windows.Forms.TextBox();
            this.txtPunchBegin = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.chkIsGrace = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtShiftMins = new System.Windows.Forms.TextBox();
            this.txtShiftHrs = new System.Windows.Forms.TextBox();
            this.txtShiftEndTime = new System.Windows.Forms.TextBox();
            this.txtShiftBeginTime = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtShiftCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtShiftName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grbButtons = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.grbShift.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grbButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbShift
            // 
            this.grbShift.Controls.Add(this.txtGraceTime);
            this.grbShift.Controls.Add(this.txtPunchEnd);
            this.grbShift.Controls.Add(this.txtPunchBegin);
            this.grbShift.Controls.Add(this.label15);
            this.grbShift.Controls.Add(this.label13);
            this.grbShift.Controls.Add(this.label12);
            this.grbShift.Controls.Add(this.chkIsGrace);
            this.grbShift.Controls.Add(this.label11);
            this.grbShift.Controls.Add(this.label10);
            this.grbShift.Controls.Add(this.label9);
            this.grbShift.Controls.Add(this.groupBox1);
            this.grbShift.Controls.Add(this.txtShiftCode);
            this.grbShift.Controls.Add(this.label2);
            this.grbShift.Controls.Add(this.txtShiftName);
            this.grbShift.Controls.Add(this.label1);
            this.grbShift.Location = new System.Drawing.Point(3, 1);
            this.grbShift.Name = "grbShift";
            this.grbShift.Size = new System.Drawing.Size(572, 231);
            this.grbShift.TabIndex = 0;
            this.grbShift.TabStop = false;
            this.grbShift.Enter += new System.EventHandler(this.grbShift_Enter);
            // 
            // txtGraceTime
            // 
            this.txtGraceTime.Location = new System.Drawing.Point(128, 197);
            this.txtGraceTime.Name = "txtGraceTime";
            this.txtGraceTime.Size = new System.Drawing.Size(50, 20);
            this.txtGraceTime.TabIndex = 18;
            // 
            // txtPunchEnd
            // 
            this.txtPunchEnd.Location = new System.Drawing.Point(128, 169);
            this.txtPunchEnd.Name = "txtPunchEnd";
            this.txtPunchEnd.Size = new System.Drawing.Size(50, 20);
            this.txtPunchEnd.TabIndex = 17;
            // 
            // txtPunchBegin
            // 
            this.txtPunchBegin.Location = new System.Drawing.Point(128, 144);
            this.txtPunchBegin.Name = "txtPunchBegin";
            this.txtPunchBegin.Size = new System.Drawing.Size(50, 20);
            this.txtPunchBegin.TabIndex = 16;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(213, 197);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(245, 13);
            this.label15.TabIndex = 15;
            this.label15.Text = "(Default value comes from Employee Type Setting)";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(180, 197);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 13);
            this.label13.TabIndex = 14;
            this.label13.Text = "Mins";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(180, 169);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 13);
            this.label12.TabIndex = 13;
            this.label12.Text = "Mins";
            // 
            // chkIsGrace
            // 
            this.chkIsGrace.AutoSize = true;
            this.chkIsGrace.Location = new System.Drawing.Point(23, 197);
            this.chkIsGrace.Name = "chkIsGrace";
            this.chkIsGrace.Size = new System.Drawing.Size(81, 17);
            this.chkIsGrace.TabIndex = 12;
            this.chkIsGrace.Text = "Grace Time";
            this.chkIsGrace.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(20, 169);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(85, 13);
            this.label11.TabIndex = 11;
            this.label11.Text = "Punch End After";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(180, 144);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "Mins";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 144);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(102, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Punch Begin Before";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtShiftMins);
            this.groupBox1.Controls.Add(this.txtShiftHrs);
            this.groupBox1.Controls.Add(this.txtShiftEndTime);
            this.groupBox1.Controls.Add(this.txtShiftBeginTime);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(9, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(555, 77);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // txtShiftMins
            // 
            this.txtShiftMins.Location = new System.Drawing.Point(172, 45);
            this.txtShiftMins.Name = "txtShiftMins";
            this.txtShiftMins.Size = new System.Drawing.Size(57, 20);
            this.txtShiftMins.TabIndex = 14;
            // 
            // txtShiftHrs
            // 
            this.txtShiftHrs.Location = new System.Drawing.Point(87, 45);
            this.txtShiftHrs.Name = "txtShiftHrs";
            this.txtShiftHrs.Size = new System.Drawing.Size(50, 20);
            this.txtShiftHrs.TabIndex = 13;
            // 
            // txtShiftEndTime
            // 
            this.txtShiftEndTime.Location = new System.Drawing.Point(351, 16);
            this.txtShiftEndTime.Name = "txtShiftEndTime";
            this.txtShiftEndTime.Size = new System.Drawing.Size(74, 20);
            this.txtShiftEndTime.TabIndex = 12;
            // 
            // txtShiftBeginTime
            // 
            this.txtShiftBeginTime.Location = new System.Drawing.Point(87, 16);
            this.txtShiftBeginTime.Name = "txtShiftBeginTime";
            this.txtShiftBeginTime.Size = new System.Drawing.Size(74, 20);
            this.txtShiftBeginTime.TabIndex = 11;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(235, 45);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(29, 13);
            this.label14.TabIndex = 10;
            this.label14.Text = "Mins";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(143, 45);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(23, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Hrs";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Shift Duration";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(431, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "HH MM 24 Hr Format";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(293, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "End Time";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(169, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "HH MM 24 Hr Format";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Begin Time";
            // 
            // txtShiftCode
            // 
            this.txtShiftCode.Location = new System.Drawing.Point(322, 26);
            this.txtShiftCode.Name = "txtShiftCode";
            this.txtShiftCode.Size = new System.Drawing.Size(125, 20);
            this.txtShiftCode.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(244, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Shift Code";
            // 
            // txtShiftName
            // 
            this.txtShiftName.Location = new System.Drawing.Point(96, 26);
            this.txtShiftName.Name = "txtShiftName";
            this.txtShiftName.Size = new System.Drawing.Size(120, 20);
            this.txtShiftName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Shift Name";
            // 
            // grbButtons
            // 
            this.grbButtons.Controls.Add(this.btnCancel);
            this.grbButtons.Controls.Add(this.btnSave);
            this.grbButtons.Location = new System.Drawing.Point(3, 232);
            this.grbButtons.Name = "grbButtons";
            this.grbButtons.Size = new System.Drawing.Size(572, 58);
            this.grbButtons.TabIndex = 1;
            this.grbButtons.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(483, 19);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(65, 24);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(406, 19);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(65, 24);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // frmShiftProp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 291);
            this.Controls.Add(this.grbButtons);
            this.Controls.Add(this.grbShift);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmShiftProp";
            this.Text = "Shift";
            this.grbShift.ResumeLayout(false);
            this.grbShift.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grbButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbShift;
        private System.Windows.Forms.GroupBox grbButtons;
        private System.Windows.Forms.TextBox txtShiftCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtShiftName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtGraceTime;
        private System.Windows.Forms.TextBox txtPunchEnd;
        private System.Windows.Forms.TextBox txtPunchBegin;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox chkIsGrace;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtShiftMins;
        private System.Windows.Forms.TextBox txtShiftHrs;
        private System.Windows.Forms.TextBox txtShiftEndTime;
        private System.Windows.Forms.TextBox txtShiftBeginTime;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
    }
}