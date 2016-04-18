namespace AttendanceSystem
{
    partial class frmBankList
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
            this.components = new System.ComponentModel.Container();
            this.lvwBanks = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grbButtons = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.conMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.modifyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grbButtons.SuspendLayout();
            this.conMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvwBanks
            // 
            this.lvwBanks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvwBanks.Location = new System.Drawing.Point(5, 4);
            this.lvwBanks.Name = "lvwBanks";
            this.lvwBanks.Size = new System.Drawing.Size(458, 253);
            this.lvwBanks.TabIndex = 0;
            this.lvwBanks.UseCompatibleStateImageBehavior = false;
            this.lvwBanks.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvwBanks_ColumnClick);
            this.lvwBanks.DoubleClick += new System.EventHandler(this.lvwBanks_DoubleClick);
            this.lvwBanks.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lvwBanks_KeyPress);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Bank Name";
            this.columnHeader1.Width = 125;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Branch";
            this.columnHeader2.Width = 190;
            // 
            // grbButtons
            // 
            this.grbButtons.Controls.Add(this.btnCancel);
            this.grbButtons.Controls.Add(this.btnOk);
            this.grbButtons.Controls.Add(this.btnNew);
            this.grbButtons.Location = new System.Drawing.Point(5, 263);
            this.grbButtons.Name = "grbButtons";
            this.grbButtons.Size = new System.Drawing.Size(458, 58);
            this.grbButtons.TabIndex = 1;
            this.grbButtons.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(368, 18);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(287, 18);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "&OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(368, 18);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 2;
            this.btnNew.Text = "&New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // conMenu
            // 
            this.conMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modifyToolStripMenuItem,
            this.newToolStripMenuItem,
            this.toolStripSeparator1,
            this.deleteToolStripMenuItem});
            this.conMenu.Name = "conMenu";
            this.conMenu.Size = new System.Drawing.Size(113, 76);
            // 
            // modifyToolStripMenuItem
            // 
            this.modifyToolStripMenuItem.Name = "modifyToolStripMenuItem";
            this.modifyToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.modifyToolStripMenuItem.Text = "&Modify";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.newToolStripMenuItem.Text = "&New";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(109, 6);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.deleteToolStripMenuItem.Text = "&Delete";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "IFSC CODE";
            this.columnHeader3.Width = 100;
            // 
            // frmBankList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 323);
            this.Controls.Add(this.lvwBanks);
            this.Controls.Add(this.grbButtons);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBankList";
            this.Text = "Bank List";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmBankList_FormClosing);
            this.Load += new System.EventHandler(this.frmBankList_Load);
            this.grbButtons.ResumeLayout(false);
            this.conMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvwBanks;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.GroupBox grbButtons;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.ContextMenuStrip conMenu;
        private System.Windows.Forms.ToolStripMenuItem modifyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}