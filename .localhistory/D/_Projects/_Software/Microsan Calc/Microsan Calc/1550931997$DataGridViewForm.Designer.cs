/*
 * Created by SharpDevelop.
 * User: Microsan84
 * Date: 2017-04-04
 * Time: 08:42
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Microsan
{
    partial class DataGridViewForm
    {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsBtnSaveToFile;
        private System.Windows.Forms.DataGridView dgv;
        
        /// <summary>
        /// Disposes resources used by the form.
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataGridViewForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsBtnSaveToFile = new System.Windows.Forms.ToolStripButton();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.tsBtnLoad = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnSaveToFile,
            this.tsBtnLoad});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(557, 38);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsBtnSaveToFile
            // 
            this.tsBtnSaveToFile.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnSaveToFile.Image")));
            this.tsBtnSaveToFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnSaveToFile.Name = "tsBtnSaveToFile";
            this.tsBtnSaveToFile.Size = new System.Drawing.Size(81, 35);
            this.tsBtnSaveToFile.Text = "Save To File...";
            this.tsBtnSaveToFile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsBtnSaveToFile.Click += new System.EventHandler(this.tsBtnSaveToFile_Click);
            // 
            // dgv
            // 
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(0, 40);
            this.dgv.Name = "dgv";
            this.dgv.Size = new System.Drawing.Size(557, 494);
            this.dgv.TabIndex = 3;
            // 
            // tsBtnLoad
            // 
            this.tsBtnLoad.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnLoad.Image")));
            this.tsBtnLoad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnLoad.Name = "tsBtnLoad";
            this.tsBtnLoad.Size = new System.Drawing.Size(67, 35);
            this.tsBtnLoad.Text = "Load File...";
            this.tsBtnLoad.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsBtnLoad.Click += new System.EventHandler(this.tsBtnLoad_Click);
            // 
            // DataGridViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 534);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.toolStrip1);
            this.Name = "DataGridViewForm";
            this.Text = "DataGridViewForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.this_FormClosing);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.ToolStripButton tsBtnLoad;
    }
}
