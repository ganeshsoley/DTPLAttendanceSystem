namespace AttendanceSystem
{
    partial class frmEmpProp
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.grbButtons = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.tabEmployeeInfo = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.grbEmpProp1 = new System.Windows.Forms.GroupBox();
            this.dtpBirthDate = new System.Windows.Forms.DateTimePicker();
            this.dtpJoinDate = new System.Windows.Forms.DateTimePicker();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.btnEmpStatusList = new System.Windows.Forms.Button();
            this.lblEmpStatus = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.btnEmpType = new System.Windows.Forms.Button();
            this.lblEmpType = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.btnDesigList = new System.Windows.Forms.Button();
            this.lblDesignations = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblDept = new System.Windows.Forms.Label();
            this.lblInitials = new System.Windows.Forms.Label();
            this.btnDeptList = new System.Windows.Forms.Button();
            this.cboPlant = new System.Windows.Forms.ComboBox();
            this.txtDept = new System.Windows.Forms.TextBox();
            this.txtInitials = new System.Windows.Forms.TextBox();
            this.txtLName = new System.Windows.Forms.TextBox();
            this.txtMidName = new System.Windows.Forms.TextBox();
            this.txtFName = new System.Windows.Forms.TextBox();
            this.txtEmpCode = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.grbEmpProp2 = new System.Windows.Forms.GroupBox();
            this.txtPFNo = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.txtAccountNo = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.btnBankList = new System.Windows.Forms.Button();
            this.lblBankName = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.chkCompOff = new System.Windows.Forms.CheckBox();
            this.chkCalLWF = new System.Windows.Forms.CheckBox();
            this.chkCalPT = new System.Windows.Forms.CheckBox();
            this.chkCalESI = new System.Windows.Forms.CheckBox();
            this.chkCalPF = new System.Windows.Forms.CheckBox();
            this.chkCalSalary = new System.Windows.Forms.CheckBox();
            this.chkInActive = new System.Windows.Forms.CheckBox();
            this.txtMobileNo = new System.Windows.Forms.TextBox();
            this.txtEMail = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.grbEmpProp3 = new System.Windows.Forms.GroupBox();
            this.lvwEmpLeaveBal = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grbButtons.SuspendLayout();
            this.tabEmployeeInfo.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.grbEmpProp1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.grbEmpProp2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.grbEmpProp3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(417, 19);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // grbButtons
            // 
            this.grbButtons.Controls.Add(this.btnCancel);
            this.grbButtons.Controls.Add(this.btnSave);
            this.grbButtons.Location = new System.Drawing.Point(0, 335);
            this.grbButtons.Name = "grbButtons";
            this.grbButtons.Size = new System.Drawing.Size(501, 58);
            this.grbButtons.TabIndex = 3;
            this.grbButtons.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(336, 19);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tabEmployeeInfo
            // 
            this.tabEmployeeInfo.Controls.Add(this.tabPage1);
            this.tabEmployeeInfo.Controls.Add(this.tabPage2);
            this.tabEmployeeInfo.Controls.Add(this.tabPage3);
            this.tabEmployeeInfo.Location = new System.Drawing.Point(2, 2);
            this.tabEmployeeInfo.Name = "tabEmployeeInfo";
            this.tabEmployeeInfo.SelectedIndex = 0;
            this.tabEmployeeInfo.Size = new System.Drawing.Size(499, 331);
            this.tabEmployeeInfo.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.grbEmpProp1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(491, 305);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Employee Info 1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // grbEmpProp1
            // 
            this.grbEmpProp1.Controls.Add(this.dtpBirthDate);
            this.grbEmpProp1.Controls.Add(this.dtpJoinDate);
            this.grbEmpProp1.Controls.Add(this.label25);
            this.grbEmpProp1.Controls.Add(this.label24);
            this.grbEmpProp1.Controls.Add(this.btnEmpStatusList);
            this.grbEmpProp1.Controls.Add(this.lblEmpStatus);
            this.grbEmpProp1.Controls.Add(this.label19);
            this.grbEmpProp1.Controls.Add(this.btnEmpType);
            this.grbEmpProp1.Controls.Add(this.lblEmpType);
            this.grbEmpProp1.Controls.Add(this.label17);
            this.grbEmpProp1.Controls.Add(this.btnDesigList);
            this.grbEmpProp1.Controls.Add(this.lblDesignations);
            this.grbEmpProp1.Controls.Add(this.label7);
            this.grbEmpProp1.Controls.Add(this.lblDept);
            this.grbEmpProp1.Controls.Add(this.lblInitials);
            this.grbEmpProp1.Controls.Add(this.btnDeptList);
            this.grbEmpProp1.Controls.Add(this.cboPlant);
            this.grbEmpProp1.Controls.Add(this.txtDept);
            this.grbEmpProp1.Controls.Add(this.txtInitials);
            this.grbEmpProp1.Controls.Add(this.txtLName);
            this.grbEmpProp1.Controls.Add(this.txtMidName);
            this.grbEmpProp1.Controls.Add(this.txtFName);
            this.grbEmpProp1.Controls.Add(this.txtEmpCode);
            this.grbEmpProp1.Controls.Add(this.label15);
            this.grbEmpProp1.Controls.Add(this.label14);
            this.grbEmpProp1.Controls.Add(this.label10);
            this.grbEmpProp1.Controls.Add(this.label9);
            this.grbEmpProp1.Controls.Add(this.label8);
            this.grbEmpProp1.Controls.Add(this.label6);
            this.grbEmpProp1.Controls.Add(this.label5);
            this.grbEmpProp1.Controls.Add(this.label4);
            this.grbEmpProp1.Controls.Add(this.label3);
            this.grbEmpProp1.Controls.Add(this.label2);
            this.grbEmpProp1.Controls.Add(this.label1);
            this.grbEmpProp1.Location = new System.Drawing.Point(6, 0);
            this.grbEmpProp1.Name = "grbEmpProp1";
            this.grbEmpProp1.Size = new System.Drawing.Size(480, 290);
            this.grbEmpProp1.TabIndex = 3;
            this.grbEmpProp1.TabStop = false;
            // 
            // dtpBirthDate
            // 
            this.dtpBirthDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBirthDate.Location = new System.Drawing.Point(281, 219);
            this.dtpBirthDate.Name = "dtpBirthDate";
            this.dtpBirthDate.Size = new System.Drawing.Size(81, 20);
            this.dtpBirthDate.TabIndex = 40;
            // 
            // dtpJoinDate
            // 
            this.dtpJoinDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpJoinDate.Location = new System.Drawing.Point(104, 219);
            this.dtpJoinDate.Name = "dtpJoinDate";
            this.dtpJoinDate.Size = new System.Drawing.Size(81, 20);
            this.dtpJoinDate.TabIndex = 39;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(203, 219);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(54, 13);
            this.label25.TabIndex = 38;
            this.label25.Text = "Birth Date";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(17, 219);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(52, 13);
            this.label24.TabIndex = 37;
            this.label24.Text = "Join Date";
            // 
            // btnEmpStatusList
            // 
            this.btnEmpStatusList.Image = global::AttendanceSystem.Properties.Resources.Search16x16;
            this.btnEmpStatusList.Location = new System.Drawing.Point(394, 192);
            this.btnEmpStatusList.Name = "btnEmpStatusList";
            this.btnEmpStatusList.Size = new System.Drawing.Size(23, 23);
            this.btnEmpStatusList.TabIndex = 36;
            this.btnEmpStatusList.UseVisualStyleBackColor = true;
            // 
            // lblEmpStatus
            // 
            this.lblEmpStatus.BackColor = System.Drawing.SystemColors.Control;
            this.lblEmpStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblEmpStatus.Location = new System.Drawing.Point(104, 191);
            this.lblEmpStatus.Name = "lblEmpStatus";
            this.lblEmpStatus.Size = new System.Drawing.Size(269, 18);
            this.lblEmpStatus.TabIndex = 35;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(17, 192);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(86, 13);
            this.label19.TabIndex = 34;
            this.label19.Text = "Employee Status";
            // 
            // btnEmpType
            // 
            this.btnEmpType.Image = global::AttendanceSystem.Properties.Resources.Search16x16;
            this.btnEmpType.Location = new System.Drawing.Point(394, 163);
            this.btnEmpType.Name = "btnEmpType";
            this.btnEmpType.Size = new System.Drawing.Size(23, 23);
            this.btnEmpType.TabIndex = 33;
            this.btnEmpType.UseVisualStyleBackColor = true;
            // 
            // lblEmpType
            // 
            this.lblEmpType.BackColor = System.Drawing.SystemColors.Control;
            this.lblEmpType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblEmpType.Location = new System.Drawing.Point(104, 163);
            this.lblEmpType.Name = "lblEmpType";
            this.lblEmpType.Size = new System.Drawing.Size(269, 18);
            this.lblEmpType.TabIndex = 32;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(17, 163);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(80, 13);
            this.label17.TabIndex = 31;
            this.label17.Text = "Employee Type";
            // 
            // btnDesigList
            // 
            this.btnDesigList.Image = global::AttendanceSystem.Properties.Resources.Search16x16;
            this.btnDesigList.Location = new System.Drawing.Point(394, 136);
            this.btnDesigList.Name = "btnDesigList";
            this.btnDesigList.Size = new System.Drawing.Size(23, 23);
            this.btnDesigList.TabIndex = 30;
            this.btnDesigList.UseVisualStyleBackColor = true;
            // 
            // lblDesignations
            // 
            this.lblDesignations.BackColor = System.Drawing.SystemColors.Control;
            this.lblDesignations.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDesignations.Location = new System.Drawing.Point(104, 136);
            this.lblDesignations.Name = "lblDesignations";
            this.lblDesignations.Size = new System.Drawing.Size(269, 18);
            this.lblDesignations.TabIndex = 29;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 136);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 28;
            this.label7.Text = "Designation";
            // 
            // lblDept
            // 
            this.lblDept.BackColor = System.Drawing.SystemColors.Control;
            this.lblDept.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDept.Location = new System.Drawing.Point(104, 111);
            this.lblDept.Name = "lblDept";
            this.lblDept.Size = new System.Drawing.Size(269, 18);
            this.lblDept.TabIndex = 27;
            // 
            // lblInitials
            // 
            this.lblInitials.BackColor = System.Drawing.SystemColors.Control;
            this.lblInitials.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblInitials.Location = new System.Drawing.Point(104, 86);
            this.lblInitials.Name = "lblInitials";
            this.lblInitials.Size = new System.Drawing.Size(269, 18);
            this.lblInitials.TabIndex = 26;
            // 
            // btnDeptList
            // 
            this.btnDeptList.Image = global::AttendanceSystem.Properties.Resources.Search16x16;
            this.btnDeptList.Location = new System.Drawing.Point(394, 111);
            this.btnDeptList.Name = "btnDeptList";
            this.btnDeptList.Size = new System.Drawing.Size(23, 23);
            this.btnDeptList.TabIndex = 21;
            this.btnDeptList.UseVisualStyleBackColor = true;
            // 
            // cboPlant
            // 
            this.cboPlant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPlant.FormattingEnabled = true;
            this.cboPlant.Location = new System.Drawing.Point(104, 247);
            this.cboPlant.Name = "cboPlant";
            this.cboPlant.Size = new System.Drawing.Size(128, 21);
            this.cboPlant.TabIndex = 24;
            // 
            // txtDept
            // 
            this.txtDept.Location = new System.Drawing.Point(104, 111);
            this.txtDept.Name = "txtDept";
            this.txtDept.Size = new System.Drawing.Size(269, 20);
            this.txtDept.TabIndex = 20;
            this.txtDept.Visible = false;
            // 
            // txtInitials
            // 
            this.txtInitials.Location = new System.Drawing.Point(104, 86);
            this.txtInitials.Name = "txtInitials";
            this.txtInitials.Size = new System.Drawing.Size(269, 20);
            this.txtInitials.TabIndex = 19;
            this.txtInitials.Visible = false;
            // 
            // txtLName
            // 
            this.txtLName.Location = new System.Drawing.Point(307, 60);
            this.txtLName.Name = "txtLName";
            this.txtLName.Size = new System.Drawing.Size(128, 20);
            this.txtLName.TabIndex = 18;
            // 
            // txtMidName
            // 
            this.txtMidName.Location = new System.Drawing.Point(173, 60);
            this.txtMidName.Name = "txtMidName";
            this.txtMidName.Size = new System.Drawing.Size(128, 20);
            this.txtMidName.TabIndex = 17;
            // 
            // txtFName
            // 
            this.txtFName.Location = new System.Drawing.Point(20, 60);
            this.txtFName.Name = "txtFName";
            this.txtFName.Size = new System.Drawing.Size(147, 20);
            this.txtFName.TabIndex = 16;
            // 
            // txtEmpCode
            // 
            this.txtEmpCode.Location = new System.Drawing.Point(104, 18);
            this.txtEmpCode.Name = "txtEmpCode";
            this.txtEmpCode.Size = new System.Drawing.Size(98, 20);
            this.txtEmpCode.TabIndex = 15;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Location = new System.Drawing.Point(238, 247);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(11, 13);
            this.label15.TabIndex = 14;
            this.label15.Text = "*";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(17, 247);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(31, 13);
            this.label14.TabIndex = 13;
            this.label14.Text = "Plant";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(17, 111);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Department";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(379, 111);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(11, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "*";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 86);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Initials";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(304, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Last Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(170, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Middle Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(71, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "First Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(203, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Employee Code";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.grbEmpProp2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(491, 305);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Employee Info 2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // grbEmpProp2
            // 
            this.grbEmpProp2.Controls.Add(this.txtPFNo);
            this.grbEmpProp2.Controls.Add(this.label26);
            this.grbEmpProp2.Controls.Add(this.txtAccountNo);
            this.grbEmpProp2.Controls.Add(this.label23);
            this.grbEmpProp2.Controls.Add(this.btnBankList);
            this.grbEmpProp2.Controls.Add(this.lblBankName);
            this.grbEmpProp2.Controls.Add(this.label22);
            this.grbEmpProp2.Controls.Add(this.chkCompOff);
            this.grbEmpProp2.Controls.Add(this.chkCalLWF);
            this.grbEmpProp2.Controls.Add(this.chkCalPT);
            this.grbEmpProp2.Controls.Add(this.chkCalESI);
            this.grbEmpProp2.Controls.Add(this.chkCalPF);
            this.grbEmpProp2.Controls.Add(this.chkCalSalary);
            this.grbEmpProp2.Controls.Add(this.chkInActive);
            this.grbEmpProp2.Controls.Add(this.txtMobileNo);
            this.grbEmpProp2.Controls.Add(this.txtEMail);
            this.grbEmpProp2.Controls.Add(this.label13);
            this.grbEmpProp2.Controls.Add(this.label12);
            this.grbEmpProp2.Controls.Add(this.label11);
            this.grbEmpProp2.Location = new System.Drawing.Point(6, 0);
            this.grbEmpProp2.Name = "grbEmpProp2";
            this.grbEmpProp2.Size = new System.Drawing.Size(480, 290);
            this.grbEmpProp2.TabIndex = 0;
            this.grbEmpProp2.TabStop = false;
            // 
            // txtPFNo
            // 
            this.txtPFNo.Location = new System.Drawing.Point(99, 132);
            this.txtPFNo.Name = "txtPFNo";
            this.txtPFNo.Size = new System.Drawing.Size(119, 20);
            this.txtPFNo.TabIndex = 44;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(26, 132);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(40, 13);
            this.label26.TabIndex = 43;
            this.label26.Text = "PF No.";
            // 
            // txtAccountNo
            // 
            this.txtAccountNo.Location = new System.Drawing.Point(99, 106);
            this.txtAccountNo.Name = "txtAccountNo";
            this.txtAccountNo.Size = new System.Drawing.Size(119, 20);
            this.txtAccountNo.TabIndex = 42;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(26, 106);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(67, 13);
            this.label23.TabIndex = 41;
            this.label23.Text = "Account No.";
            // 
            // btnBankList
            // 
            this.btnBankList.Image = global::AttendanceSystem.Properties.Resources.Search16x16;
            this.btnBankList.Location = new System.Drawing.Point(308, 78);
            this.btnBankList.Name = "btnBankList";
            this.btnBankList.Size = new System.Drawing.Size(23, 23);
            this.btnBankList.TabIndex = 40;
            this.btnBankList.UseVisualStyleBackColor = true;
            // 
            // lblBankName
            // 
            this.lblBankName.BackColor = System.Drawing.SystemColors.Control;
            this.lblBankName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBankName.Location = new System.Drawing.Point(99, 78);
            this.lblBankName.Name = "lblBankName";
            this.lblBankName.Size = new System.Drawing.Size(203, 18);
            this.lblBankName.TabIndex = 39;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(26, 78);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(32, 13);
            this.label22.TabIndex = 38;
            this.label22.Text = "Bank";
            // 
            // chkCompOff
            // 
            this.chkCompOff.AutoSize = true;
            this.chkCompOff.Location = new System.Drawing.Point(308, 192);
            this.chkCompOff.Name = "chkCompOff";
            this.chkCompOff.Size = new System.Drawing.Size(138, 17);
            this.chkCompOff.TabIndex = 37;
            this.chkCompOff.Text = "Applicable To Comp-Off";
            this.chkCompOff.UseVisualStyleBackColor = true;
            // 
            // chkCalLWF
            // 
            this.chkCalLWF.AutoSize = true;
            this.chkCalLWF.Location = new System.Drawing.Point(173, 192);
            this.chkCalLWF.Name = "chkCalLWF";
            this.chkCalLWF.Size = new System.Drawing.Size(96, 17);
            this.chkCalLWF.TabIndex = 36;
            this.chkCalLWF.Text = "Calculate LWF";
            this.chkCalLWF.UseVisualStyleBackColor = true;
            // 
            // chkCalPT
            // 
            this.chkCalPT.AutoSize = true;
            this.chkCalPT.Location = new System.Drawing.Point(29, 192);
            this.chkCalPT.Name = "chkCalPT";
            this.chkCalPT.Size = new System.Drawing.Size(87, 17);
            this.chkCalPT.TabIndex = 35;
            this.chkCalPT.Text = "Calculate PT";
            this.chkCalPT.UseVisualStyleBackColor = true;
            // 
            // chkCalESI
            // 
            this.chkCalESI.AutoSize = true;
            this.chkCalESI.Location = new System.Drawing.Point(308, 169);
            this.chkCalESI.Name = "chkCalESI";
            this.chkCalESI.Size = new System.Drawing.Size(90, 17);
            this.chkCalESI.TabIndex = 34;
            this.chkCalESI.Text = "Calculate ESI";
            this.chkCalESI.UseVisualStyleBackColor = true;
            // 
            // chkCalPF
            // 
            this.chkCalPF.AutoSize = true;
            this.chkCalPF.Location = new System.Drawing.Point(173, 169);
            this.chkCalPF.Name = "chkCalPF";
            this.chkCalPF.Size = new System.Drawing.Size(86, 17);
            this.chkCalPF.TabIndex = 33;
            this.chkCalPF.Text = "Calculate PF";
            this.chkCalPF.UseVisualStyleBackColor = true;
            // 
            // chkCalSalary
            // 
            this.chkCalSalary.AutoSize = true;
            this.chkCalSalary.Location = new System.Drawing.Point(29, 169);
            this.chkCalSalary.Name = "chkCalSalary";
            this.chkCalSalary.Size = new System.Drawing.Size(102, 17);
            this.chkCalSalary.TabIndex = 32;
            this.chkCalSalary.Text = "Calculate Salary";
            this.chkCalSalary.UseVisualStyleBackColor = true;
            // 
            // chkInActive
            // 
            this.chkInActive.AutoSize = true;
            this.chkInActive.Location = new System.Drawing.Point(29, 215);
            this.chkInActive.Name = "chkInActive";
            this.chkInActive.Size = new System.Drawing.Size(68, 17);
            this.chkInActive.TabIndex = 31;
            this.chkInActive.Text = "In Active";
            this.chkInActive.UseVisualStyleBackColor = true;
            // 
            // txtMobileNo
            // 
            this.txtMobileNo.Location = new System.Drawing.Point(99, 51);
            this.txtMobileNo.Name = "txtMobileNo";
            this.txtMobileNo.Size = new System.Drawing.Size(128, 20);
            this.txtMobileNo.TabIndex = 30;
            // 
            // txtEMail
            // 
            this.txtEMail.Location = new System.Drawing.Point(99, 24);
            this.txtEMail.Name = "txtEMail";
            this.txtEMail.Size = new System.Drawing.Size(203, 20);
            this.txtEMail.TabIndex = 29;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(233, 51);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(11, 13);
            this.label13.TabIndex = 28;
            this.label13.Text = "*";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(26, 51);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(58, 13);
            this.label12.TabIndex = 27;
            this.label12.Text = "Mobile No.";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(26, 24);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(36, 13);
            this.label11.TabIndex = 26;
            this.label11.Text = "E-Mail";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.grbEmpProp3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(491, 305);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Employee Leaves";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // grbEmpProp3
            // 
            this.grbEmpProp3.Controls.Add(this.lvwEmpLeaveBal);
            this.grbEmpProp3.Location = new System.Drawing.Point(6, 0);
            this.grbEmpProp3.Name = "grbEmpProp3";
            this.grbEmpProp3.Size = new System.Drawing.Size(480, 301);
            this.grbEmpProp3.TabIndex = 1;
            this.grbEmpProp3.TabStop = false;
            // 
            // lvwEmpLeaveBal
            // 
            this.lvwEmpLeaveBal.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvwEmpLeaveBal.Location = new System.Drawing.Point(12, 20);
            this.lvwEmpLeaveBal.Name = "lvwEmpLeaveBal";
            this.lvwEmpLeaveBal.Size = new System.Drawing.Size(456, 127);
            this.lvwEmpLeaveBal.TabIndex = 0;
            this.lvwEmpLeaveBal.UseCompatibleStateImageBehavior = false;
            this.lvwEmpLeaveBal.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Leave Type";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Balance";
            // 
            // frmEmpProp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 395);
            this.Controls.Add(this.tabEmployeeInfo);
            this.Controls.Add(this.grbButtons);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEmpProp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Employee";
            this.Load += new System.EventHandler(this.frmEmpProp_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmEmpProp_KeyDown);
            this.grbButtons.ResumeLayout(false);
            this.tabEmployeeInfo.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.grbEmpProp1.ResumeLayout(false);
            this.grbEmpProp1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.grbEmpProp2.ResumeLayout(false);
            this.grbEmpProp2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.grbEmpProp3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox grbButtons;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TabControl tabEmployeeInfo;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtEmpCode;
        private System.Windows.Forms.TextBox txtFName;
        private System.Windows.Forms.TextBox txtMidName;
        private System.Windows.Forms.TextBox txtLName;
        private System.Windows.Forms.TextBox txtInitials;
        private System.Windows.Forms.TextBox txtDept;
        private System.Windows.Forms.ComboBox cboPlant;
        private System.Windows.Forms.Button btnDeptList;
        private System.Windows.Forms.Label lblInitials;
        private System.Windows.Forms.Label lblDept;
        private System.Windows.Forms.GroupBox grbEmpProp1;
        private System.Windows.Forms.GroupBox grbEmpProp2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox grbEmpProp3;
        private System.Windows.Forms.DateTimePicker dtpBirthDate;
        private System.Windows.Forms.DateTimePicker dtpJoinDate;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Button btnEmpStatusList;
        private System.Windows.Forms.Label lblEmpStatus;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button btnEmpType;
        private System.Windows.Forms.Label lblEmpType;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btnDesigList;
        private System.Windows.Forms.Label lblDesignations;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPFNo;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox txtAccountNo;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Button btnBankList;
        private System.Windows.Forms.Label lblBankName;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.CheckBox chkCompOff;
        private System.Windows.Forms.CheckBox chkCalLWF;
        private System.Windows.Forms.CheckBox chkCalPT;
        private System.Windows.Forms.CheckBox chkCalESI;
        private System.Windows.Forms.CheckBox chkCalPF;
        private System.Windows.Forms.CheckBox chkCalSalary;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtEMail;
        private System.Windows.Forms.TextBox txtMobileNo;
        private System.Windows.Forms.CheckBox chkInActive;
        private System.Windows.Forms.ListView lvwEmpLeaveBal;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}