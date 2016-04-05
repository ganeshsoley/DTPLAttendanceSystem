namespace AttendanceSystem
{
    partial class frmLeaveEntryList
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
            this.grbFilter = new System.Windows.Forms.GroupBox();
            this.grbList = new System.Windows.Forms.GroupBox();
            this.grbButtons = new System.Windows.Forms.GroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.grbList.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbFilter
            // 
            this.grbFilter.Location = new System.Drawing.Point(3, 3);
            this.grbFilter.Name = "grbFilter";
            this.grbFilter.Size = new System.Drawing.Size(687, 74);
            this.grbFilter.TabIndex = 0;
            this.grbFilter.TabStop = false;
            // 
            // grbList
            // 
            this.grbList.Controls.Add(this.listView1);
            this.grbList.Location = new System.Drawing.Point(3, 76);
            this.grbList.Name = "grbList";
            this.grbList.Size = new System.Drawing.Size(687, 291);
            this.grbList.TabIndex = 1;
            this.grbList.TabStop = false;
            // 
            // grbButtons
            // 
            this.grbButtons.Location = new System.Drawing.Point(3, 369);
            this.grbButtons.Name = "grbButtons";
            this.grbButtons.Size = new System.Drawing.Size(687, 62);
            this.grbButtons.TabIndex = 2;
            this.grbButtons.TabStop = false;
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(6, 10);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(674, 275);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // frmLeaveEntryList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 444);
            this.Controls.Add(this.grbButtons);
            this.Controls.Add(this.grbList);
            this.Controls.Add(this.grbFilter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLeaveEntryList";
            this.Text = "Leave Entry List";
            this.grbList.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbFilter;
        private System.Windows.Forms.GroupBox grbList;
        private System.Windows.Forms.GroupBox grbButtons;
        private System.Windows.Forms.ListView listView1;
    }
}