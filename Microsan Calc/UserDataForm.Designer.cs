namespace Microsan
{
    partial class UserDataForm
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
            this.dgv = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip_dgv = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.insertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tabCategorys = new System.Windows.Forms.TabControl();
            this.contextMenuStrip_CategoryTabs = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage_dummy = new System.Windows.Forms.TabPage();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.chkBoxDocked = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.contextMenuStrip_dgv.SuspendLayout();
            this.tabCategorys.SuspendLayout();
            this.contextMenuStrip_CategoryTabs.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.ContextMenuStrip = this.contextMenuStrip_dgv;
            this.dgv.Location = new System.Drawing.Point(12, 34);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(363, 510);
            this.dgv.TabIndex = 0;
            this.dgv.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgv_RowsAdded);
            // 
            // contextMenuStrip_dgv
            // 
            this.contextMenuStrip_dgv.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insertToolStripMenuItem,
            this.toolStripMenuItem2});
            this.contextMenuStrip_dgv.Name = "contextMenuStrip_dgv";
            this.contextMenuStrip_dgv.Size = new System.Drawing.Size(165, 48);
            // 
            // insertToolStripMenuItem
            // 
            this.insertToolStripMenuItem.Name = "insertToolStripMenuItem";
            this.insertToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.insertToolStripMenuItem.Text = "insert data";
            this.insertToolStripMenuItem.Click += new System.EventHandler(this.insertData_ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(164, 22);
            this.toolStripMenuItem2.Text = "insert mnemonic";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // tabCategorys
            // 
            this.tabCategorys.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabCategorys.ContextMenuStrip = this.contextMenuStrip_CategoryTabs;
            this.tabCategorys.Controls.Add(this.tabPage_dummy);
            this.tabCategorys.Location = new System.Drawing.Point(12, 12);
            this.tabCategorys.Name = "tabCategorys";
            this.tabCategorys.SelectedIndex = 0;
            this.tabCategorys.Size = new System.Drawing.Size(365, 28);
            this.tabCategorys.TabIndex = 1;
            this.tabCategorys.SelectedIndexChanged += new System.EventHandler(this.tabCategorys_SelectedIndexChanged);
            // 
            // contextMenuStrip_CategoryTabs
            // 
            this.contextMenuStrip_CategoryTabs.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.renameToolStripMenuItem,
            this.toolStripMenuItem1,
            this.removeToolStripMenuItem});
            this.contextMenuStrip_CategoryTabs.Name = "contextMenuStrip_CategoryTabs";
            this.contextMenuStrip_CategoryTabs.Size = new System.Drawing.Size(115, 76);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.addToolStripMenuItem.Text = "add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // renameToolStripMenuItem
            // 
            this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            this.renameToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.renameToolStripMenuItem.Text = "rename";
            this.renameToolStripMenuItem.Click += new System.EventHandler(this.renameCategory_ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(111, 6);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.removeToolStripMenuItem.Text = "remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // tabPage_dummy
            // 
            this.tabPage_dummy.Location = new System.Drawing.Point(4, 22);
            this.tabPage_dummy.Name = "tabPage_dummy";
            this.tabPage_dummy.Size = new System.Drawing.Size(357, 2);
            this.tabPage_dummy.TabIndex = 8;
            this.tabPage_dummy.Text = "(dummy)";
            this.tabPage_dummy.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(219, 550);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(300, 550);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "save && close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // chkBoxDocked
            // 
            this.chkBoxDocked.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkBoxDocked.AutoSize = true;
            this.chkBoxDocked.Checked = true;
            this.chkBoxDocked.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBoxDocked.Location = new System.Drawing.Point(12, 556);
            this.chkBoxDocked.Name = "chkBoxDocked";
            this.chkBoxDocked.Size = new System.Drawing.Size(138, 17);
            this.chkBoxDocked.TabIndex = 4;
            this.chkBoxDocked.Text = "docked to main window";
            this.chkBoxDocked.UseVisualStyleBackColor = true;
            // 
            // UserDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 581);
            this.Controls.Add(this.chkBoxDocked);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.tabCategorys);
            this.Name = "UserDataForm";
            this.Text = "UserDataForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FunctionsForm_FormClosing);
            this.Shown += new System.EventHandler(this.FunctionsForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.contextMenuStrip_dgv.ResumeLayout(false);
            this.tabCategorys.ResumeLayout(false);
            this.contextMenuStrip_CategoryTabs.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.TabControl tabCategorys;
        private System.Windows.Forms.TabPage tabPage_dummy;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_CategoryTabs;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_dgv;
        private System.Windows.Forms.ToolStripMenuItem insertToolStripMenuItem;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.CheckBox chkBoxDocked;
    }
}