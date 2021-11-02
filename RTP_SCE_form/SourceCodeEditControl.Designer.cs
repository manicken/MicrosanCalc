/*
 * Created by SharpDevelop.
 * User: Admin
 * Date: 2018-03-29
 * Time: 10:35
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Microsan
{
	partial class SourceCodeEditControl
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the control.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SourceCodeEditControl));
            this.fastColoredTextBox = new FastColoredTextBoxNS.FastColoredTextBox();
            this.tsBtnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnNewFile = new System.Windows.Forms.ToolStripButton();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsSaveAs = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslblMain = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnClose = new System.Windows.Forms.Button();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBtnExec = new System.Windows.Forms.ToolStripButton();
            this.tsBtnOpen = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.tc = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.rtxtLog = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.fastColoredTextBox)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.tc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // fastColoredTextBox
            // 
            this.fastColoredTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fastColoredTextBox.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.fastColoredTextBox.AutoIndentCharsPatterns = "\r\n^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;]+);\r\n^\\s*(case|default)\\s*[^:]" +
    "*(?<range>:)\\s*(?<range>[^;]+);\r\n";
            this.fastColoredTextBox.AutoScrollMinSize = new System.Drawing.Size(531, 294);
            this.fastColoredTextBox.BackBrush = null;
            this.fastColoredTextBox.BracketsHighlightStrategy = FastColoredTextBoxNS.BracketsHighlightStrategy.Strategy2;
            this.fastColoredTextBox.CharHeight = 14;
            this.fastColoredTextBox.CharWidth = 8;
            this.fastColoredTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fastColoredTextBox.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fastColoredTextBox.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.fastColoredTextBox.IsReplaceMode = false;
            this.fastColoredTextBox.Language = FastColoredTextBoxNS.Language.CSharp;
            this.fastColoredTextBox.LeftBracket = '(';
            this.fastColoredTextBox.LeftBracket2 = '{';
            this.fastColoredTextBox.Location = new System.Drawing.Point(0, 23);
            this.fastColoredTextBox.Name = "fastColoredTextBox";
            this.fastColoredTextBox.Paddings = new System.Windows.Forms.Padding(0);
            this.fastColoredTextBox.RightBracket = ')';
            this.fastColoredTextBox.RightBracket2 = '}';
            this.fastColoredTextBox.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fastColoredTextBox.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("fastColoredTextBox.ServiceColors")));
            this.fastColoredTextBox.Size = new System.Drawing.Size(593, 396);
            this.fastColoredTextBox.TabIndex = 1;
            this.fastColoredTextBox.Text = resources.GetString("fastColoredTextBox.Text");
            this.fastColoredTextBox.Zoom = 100;
            // 
            // tsBtnSave
            // 
            this.tsBtnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnSave.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnSave.Image")));
            this.tsBtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnSave.Name = "tsBtnSave";
            this.tsBtnSave.Size = new System.Drawing.Size(36, 36);
            this.tsBtnSave.Text = "Save";
            this.tsBtnSave.Click += new System.EventHandler(this.tsBtnSave_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // tsbtnNewFile
            // 
            this.tsbtnNewFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnNewFile.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnNewFile.Image")));
            this.tsbtnNewFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnNewFile.Name = "tsbtnNewFile";
            this.tsbtnNewFile.Size = new System.Drawing.Size(36, 36);
            this.tsbtnNewFile.Text = "Save";
            this.tsbtnNewFile.Click += new System.EventHandler(this.tsbtnNewFile_Click);
            // 
            // btnClearLog
            // 
            this.btnClearLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearLog.Location = new System.Drawing.Point(416, 8);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(75, 23);
            this.btnClearLog.TabIndex = 12;
            this.btnClearLog.Text = "clear log";
            this.btnClearLog.UseVisualStyleBackColor = true;
            this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 39);
            // 
            // tsSaveAs
            // 
            this.tsSaveAs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsSaveAs.Enabled = false;
            this.tsSaveAs.Image = ((System.Drawing.Image)(resources.GetObject("tsSaveAs.Image")));
            this.tsSaveAs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsSaveAs.Name = "tsSaveAs";
            this.tsSaveAs.Size = new System.Drawing.Size(36, 36);
            this.tsSaveAs.Text = "SaveAs...";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 39);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslblMain});
            this.statusStrip1.Location = new System.Drawing.Point(0, 549);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(596, 22);
            this.statusStrip1.TabIndex = 14;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslblMain
            // 
            this.tsslblMain.Name = "tsslblMain";
            this.tsslblMain.Size = new System.Drawing.Size(118, 17);
            this.tsslblMain.Text = "toolStripStatusLabel1";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(497, 8);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(96, 23);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 39);
            // 
            // tsBtnExec
            // 
            this.tsBtnExec.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnExec.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnExec.Image")));
            this.tsBtnExec.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnExec.Name = "tsBtnExec";
            this.tsBtnExec.Size = new System.Drawing.Size(36, 36);
            this.tsBtnExec.Text = "Exec";
            this.tsBtnExec.Click += new System.EventHandler(this.tsBtnExec_Click);
            // 
            // tsBtnOpen
            // 
            this.tsBtnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnOpen.Enabled = false;
            this.tsBtnOpen.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnOpen.Image")));
            this.tsBtnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnOpen.Name = "tsBtnOpen";
            this.tsBtnOpen.Size = new System.Drawing.Size(36, 36);
            this.tsBtnOpen.Text = "Open";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // tabPage1
            // 
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(582, 0);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "file1.cs";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // toolStrip
            // 
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator2,
            this.tsBtnOpen,
            this.tsbtnNewFile,
            this.toolStripSeparator1,
            this.tsBtnSave,
            this.toolStripSeparator3,
            this.tsSaveAs,
            this.toolStripSeparator4,
            this.tsBtnExec,
            this.toolStripSeparator5});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(596, 39);
            this.toolStrip.TabIndex = 13;
            this.toolStrip.Text = "toolStrip";
            // 
            // tc
            // 
            this.tc.AllowDrop = true;
            this.tc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tc.Controls.Add(this.tabPage1);
            this.tc.Controls.Add(this.tabPage2);
            this.tc.Controls.Add(this.tabPage3);
            this.tc.Controls.Add(this.tabPage4);
            this.tc.Location = new System.Drawing.Point(0, 0);
            this.tc.Name = "tc";
            this.tc.SelectedIndex = 0;
            this.tc.Size = new System.Drawing.Size(590, 23);
            this.tc.TabIndex = 2;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(582, 0);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "file2.cs";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(582, 0);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "file3.cs";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(582, 0);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "file4.cs";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 40);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tc);
            this.splitContainer1.Panel1.Controls.Add(this.fastColoredTextBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(593, 506);
            this.splitContainer1.SplitterDistance = 417;
            this.splitContainer1.SplitterWidth = 8;
            this.splitContainer1.TabIndex = 11;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dgv);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.rtxtLog);
            this.splitContainer2.Size = new System.Drawing.Size(593, 81);
            this.splitContainer2.SplitterDistance = 321;
            this.splitContainer2.SplitterWidth = 8;
            this.splitContainer2.TabIndex = 3;
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgv.Location = new System.Drawing.Point(0, 0);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(321, 81);
            this.dgv.TabIndex = 2;
            this.dgv.SelectionChanged += new System.EventHandler(this.dgv_SelectionChanged);
            // 
            // rtxtLog
            // 
            this.rtxtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxtLog.Location = new System.Drawing.Point(0, 0);
            this.rtxtLog.Name = "rtxtLog";
            this.rtxtLog.Size = new System.Drawing.Size(264, 81);
            this.rtxtLog.TabIndex = 0;
            this.rtxtLog.Text = "";
            // 
            // SourceCodeEditControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnClearLog);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.splitContainer1);
            this.Name = "SourceCodeEditControl";
            this.Size = new System.Drawing.Size(596, 571);
            ((System.ComponentModel.ISupportInitialize)(this.fastColoredTextBox)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.tc.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		private System.Windows.Forms.RichTextBox rtxtLog;
		private System.Windows.Forms.DataGridView dgv;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.TabPage tabPage4;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabControl tc;
		private System.Windows.Forms.ToolStrip toolStrip;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton tsBtnOpen;
		private System.Windows.Forms.ToolStripButton tsBtnExec;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		public System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.ToolStripStatusLabel tsslblMain;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripButton tsSaveAs;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.Button btnClearLog;
		private System.Windows.Forms.ToolStripButton tsbtnNewFile;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton tsBtnSave;
		public FastColoredTextBoxNS.FastColoredTextBox fastColoredTextBox;
	}
}
