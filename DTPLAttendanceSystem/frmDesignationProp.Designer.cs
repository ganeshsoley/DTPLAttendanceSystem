namespace DTPLAttendanceSystem
{
    partial class frmDesignationProp
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
            this.grbDesignation = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDescr = new System.Windows.Forms.TextBox();
            this.txtDept = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grbButtons = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.grbDesignation.SuspendLayout();
            this.grbButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbDesignation
            // 
            this.grbDesignation.Controls.Add(this.label3);
            this.grbDesignation.Controls.Add(this.txtDescr);
            this.grbDesignation.Controls.Add(this.txtDept);
            this.grbDesignation.Controls.Add(this.label2);
            this.grbDesignation.Controls.Add(this.label1);
            this.grbDesignation.Location = new System.Drawing.Point(5, 0);
            this.grbDesignation.Name = "grbDesignation";
            this.grbDesignation.Size = new System.Drawing.Size(318, 76);
            this.grbDesignation.TabIndex = 2;
            this.grbDesignation.TabStop = false;
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
            // txtDescr
            // 
            this.txtDescr.Location = new System.Drawing.Point(82, 42);
            this.txtDescr.Name = "txtDescr";
            this.txtDescr.Size = new System.Drawing.Size(205, 20);
            this.txtDescr.TabIndex = 3;
            // 
            // txtDept
            // 
            this.txtDept.Location = new System.Drawing.Point(82, 16);
            this.txtDept.Name = "txtDept";
            this.txtDept.Size = new System.Drawing.Size(205, 20);
            this.txtDept.TabIndex = 2;
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
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Designation";
            // 
            // grbButtons
            // 
            this.grbButtons.Controls.Add(this.btnCancel);
            this.grbButtons.Controls.Add(this.btnSave);
            this.grbButtons.Location = new System.Drawing.Point(5, 78);
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
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(143, 17);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // frmDesignationProp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 136);
            this.Controls.Add(this.grbDesignation);
            this.Controls.Add(this.grbButtons);
            this.Name = "frmDesignationProp";
            this.Text = "Designation";
            this.grbDesignation.ResumeLayout(false);
            this.grbDesignation.PerformLayout();
            this.grbButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbDesignation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDept;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grbButtons;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDescr;
    }
}