namespace AttendanceSystem
{
    partial class frmHolidayProp
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
            this.grbButtons = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.grbHoliday = new System.Windows.Forms.GroupBox();
            this.cboApplicableTo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.dtpHoliday = new System.Windows.Forms.DateTimePicker();
            this.txtHolidayName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.grbButtons.SuspendLayout();
            this.grbHoliday.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbButtons
            // 
            this.grbButtons.Controls.Add(this.btnCancel);
            this.grbButtons.Controls.Add(this.btnSave);
            this.grbButtons.Location = new System.Drawing.Point(6, 192);
            this.grbButtons.Name = "grbButtons";
            this.grbButtons.Size = new System.Drawing.Size(361, 50);
            this.grbButtons.TabIndex = 2;
            this.grbButtons.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(260, 15);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 24);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(175, 15);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 24);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // grbHoliday
            // 
            this.grbHoliday.Controls.Add(this.label7);
            this.grbHoliday.Controls.Add(this.label6);
            this.grbHoliday.Controls.Add(this.label5);
            this.grbHoliday.Controls.Add(this.cboApplicableTo);
            this.grbHoliday.Controls.Add(this.label4);
            this.grbHoliday.Controls.Add(this.txtDescription);
            this.grbHoliday.Controls.Add(this.dtpHoliday);
            this.grbHoliday.Controls.Add(this.txtHolidayName);
            this.grbHoliday.Controls.Add(this.label3);
            this.grbHoliday.Controls.Add(this.label2);
            this.grbHoliday.Controls.Add(this.label1);
            this.grbHoliday.Location = new System.Drawing.Point(6, -1);
            this.grbHoliday.Name = "grbHoliday";
            this.grbHoliday.Size = new System.Drawing.Size(361, 194);
            this.grbHoliday.TabIndex = 3;
            this.grbHoliday.TabStop = false;
            // 
            // cboApplicableTo
            // 
            this.cboApplicableTo.FormattingEnabled = true;
            this.cboApplicableTo.Location = new System.Drawing.Point(96, 81);
            this.cboApplicableTo.Name = "cboApplicableTo";
            this.cboApplicableTo.Size = new System.Drawing.Size(154, 21);
            this.cboApplicableTo.TabIndex = 7;
            this.cboApplicableTo.TextChanged += new System.EventHandler(this.cboApplicableTo_TextChanged);
            this.cboApplicableTo.Enter += new System.EventHandler(this.cboApplicableTo_Enter);
            this.cboApplicableTo.Leave += new System.EventHandler(this.cboApplicableTo_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Applicable To";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(96, 112);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(239, 76);
            this.txtDescription.TabIndex = 5;
            this.txtDescription.TextChanged += new System.EventHandler(this.txtDescription_TextChanged);
            this.txtDescription.Enter += new System.EventHandler(this.txtDescription_Enter);
            this.txtDescription.Leave += new System.EventHandler(this.txtDescription_Leave);
            // 
            // dtpHoliday
            // 
            this.dtpHoliday.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHoliday.Location = new System.Drawing.Point(96, 53);
            this.dtpHoliday.Name = "dtpHoliday";
            this.dtpHoliday.Size = new System.Drawing.Size(106, 20);
            this.dtpHoliday.TabIndex = 4;
            this.dtpHoliday.ValueChanged += new System.EventHandler(this.dtpHoliday_ValueChanged);
            this.dtpHoliday.Enter += new System.EventHandler(this.dtpHoliday_Enter);
            this.dtpHoliday.Leave += new System.EventHandler(this.dtpHoliday_Leave);
            // 
            // txtHolidayName
            // 
            this.txtHolidayName.Location = new System.Drawing.Point(96, 23);
            this.txtHolidayName.Name = "txtHolidayName";
            this.txtHolidayName.Size = new System.Drawing.Size(239, 20);
            this.txtHolidayName.TabIndex = 3;
            this.txtHolidayName.TextChanged += new System.EventHandler(this.txtHolidayName_TextChanged);
            this.txtHolidayName.Enter += new System.EventHandler(this.txtHolidayName_Enter);
            this.txtHolidayName.Leave += new System.EventHandler(this.txtHolidayName_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Description";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Holiday Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(341, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(11, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "*";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(208, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(11, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "*";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(257, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(11, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "*";
            // 
            // frmHolidayProp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 245);
            this.Controls.Add(this.grbHoliday);
            this.Controls.Add(this.grbButtons);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmHolidayProp";
            this.Text = "Holiday";
            this.Load += new System.EventHandler(this.frmHolidayProp_Load);
            this.grbButtons.ResumeLayout(false);
            this.grbHoliday.ResumeLayout(false);
            this.grbHoliday.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbButtons;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox grbHoliday;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.DateTimePicker dtpHoliday;
        private System.Windows.Forms.TextBox txtHolidayName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboApplicableTo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
    }
}