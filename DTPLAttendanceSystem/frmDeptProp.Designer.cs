namespace DTPLAttendanceSystem
{
    partial class frmDeptProp
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
            this.grbDept = new System.Windows.Forms.GroupBox();
            this.txtSrNo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.txtDescr = new System.Windows.Forms.TextBox();
            this.txtDept = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grbButtons.SuspendLayout();
            this.grbDept.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbButtons
            // 
            this.grbButtons.Controls.Add(this.btnCancel);
            this.grbButtons.Controls.Add(this.btnSave);
            this.grbButtons.Location = new System.Drawing.Point(12, 143);
            this.grbButtons.Name = "grbButtons";
            this.grbButtons.Size = new System.Drawing.Size(318, 54);
            this.grbButtons.TabIndex = 3;
            this.grbButtons.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(229, 17);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(143, 17);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // grbDept
            // 
            this.grbDept.Controls.Add(this.txtSrNo);
            this.grbDept.Controls.Add(this.label5);
            this.grbDept.Controls.Add(this.label4);
            this.grbDept.Controls.Add(this.label3);
            this.grbDept.Controls.Add(this.chkIsActive);
            this.grbDept.Controls.Add(this.txtDescr);
            this.grbDept.Controls.Add(this.txtDept);
            this.grbDept.Controls.Add(this.label2);
            this.grbDept.Controls.Add(this.label1);
            this.grbDept.Location = new System.Drawing.Point(12, 12);
            this.grbDept.Name = "grbDept";
            this.grbDept.Size = new System.Drawing.Size(318, 125);
            this.grbDept.TabIndex = 2;
            this.grbDept.TabStop = false;
            // 
            // txtSrNo
            // 
            this.txtSrNo.Location = new System.Drawing.Point(82, 69);
            this.txtSrNo.Name = "txtSrNo";
            this.txtSrNo.Size = new System.Drawing.Size(42, 20);
            this.txtSrNo.TabIndex = 8;
            this.txtSrNo.TextChanged += new System.EventHandler(this.txtSrNo_TextChanged);
            this.txtSrNo.Enter += new System.EventHandler(this.txtSrNo_Enter);
            this.txtSrNo.Leave += new System.EventHandler(this.txtSrNo_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Sr No";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(293, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(293, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "*";
            // 
            // chkIsActive
            // 
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Location = new System.Drawing.Point(82, 102);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(56, 17);
            this.chkIsActive.TabIndex = 4;
            this.chkIsActive.Text = "Active";
            this.chkIsActive.UseVisualStyleBackColor = true;
            this.chkIsActive.CheckedChanged += new System.EventHandler(this.chkIsActive_CheckedChanged);
            this.chkIsActive.Click += new System.EventHandler(this.chkIsActive_Click);
            // 
            // txtDescr
            // 
            this.txtDescr.Location = new System.Drawing.Point(82, 42);
            this.txtDescr.Name = "txtDescr";
            this.txtDescr.Size = new System.Drawing.Size(205, 20);
            this.txtDescr.TabIndex = 3;
            this.txtDescr.TextChanged += new System.EventHandler(this.txtDescr_TextChanged);
            this.txtDescr.Enter += new System.EventHandler(this.txtDescr_Enter);
            this.txtDescr.Leave += new System.EventHandler(this.txtDescr_Leave);
            // 
            // txtDept
            // 
            this.txtDept.Location = new System.Drawing.Point(82, 16);
            this.txtDept.Name = "txtDept";
            this.txtDept.Size = new System.Drawing.Size(205, 20);
            this.txtDept.TabIndex = 2;
            this.txtDept.TextChanged += new System.EventHandler(this.txtDept_TextChanged);
            this.txtDept.Enter += new System.EventHandler(this.txtDept_Enter);
            this.txtDept.Leave += new System.EventHandler(this.txtDept_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Description";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dept. Name";
            // 
            // frmDeptProp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 203);
            this.Controls.Add(this.grbButtons);
            this.Controls.Add(this.grbDept);
            this.Name = "frmDeptProp";
            this.Text = "frmDeptProp";
            this.Load += new System.EventHandler(this.frmDeptProp_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmDeptProp_KeyDown);
            this.grbButtons.ResumeLayout(false);
            this.grbDept.ResumeLayout(false);
            this.grbDept.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbButtons;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox grbDept;
        private System.Windows.Forms.TextBox txtSrNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkIsActive;
        private System.Windows.Forms.TextBox txtDescr;
        private System.Windows.Forms.TextBox txtDept;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}