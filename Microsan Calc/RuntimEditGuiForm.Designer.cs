/*
 * Created by SharpDevelop.
 * User: Microsan84
 * Date: 2017-04-04
 * Time: 11:55
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Microsan
{
    partial class RuntimeEditGuiForm
    {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelRootGui;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.ToolStrip toolStrip1;
        
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
            this.panelRootGui = new System.Windows.Forms.Panel();
            this.button13 = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.panelRootGui.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelRootGui
            // 
            this.panelRootGui.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelRootGui.BackColor = System.Drawing.Color.Transparent;
            this.panelRootGui.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelRootGui.Controls.Add(this.button13);
            this.panelRootGui.Location = new System.Drawing.Point(0, 32);
            this.panelRootGui.Name = "panelRootGui";
            this.panelRootGui.Size = new System.Drawing.Size(496, 441);
            this.panelRootGui.TabIndex = 11;
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(23, 31);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(75, 23);
            this.button13.TabIndex = 0;
            this.button13.Text = "button13";
            this.button13.UseVisualStyleBackColor = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(496, 25);
            this.toolStrip1.TabIndex = 12;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // RuntimeEditGuiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 473);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panelRootGui);
            this.Name = "RuntimeEditGuiForm";
            this.Text = "RuntimeEditGui - Form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.this_FormClosing);
            this.panelRootGui.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
