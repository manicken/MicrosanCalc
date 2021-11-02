/*
 * Created by SharpDevelop.
 * User: Microsan84
 * Date: 2017-05-09
 * Time: 00:01
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Microsan
{
    partial class MathVisualDivision
    {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        public System.Windows.Forms.Panel pnlDividend;
        public System.Windows.Forms.Panel pnlDivisor;
        
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
            this.pnlDividend = new System.Windows.Forms.Panel();
            this.pnlDivisor = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pnlDividend
            // 
            this.pnlDividend.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDividend.BackColor = System.Drawing.Color.White;
            this.pnlDividend.Location = new System.Drawing.Point(0, 0);
            this.pnlDividend.Name = "pnlDividend";
            this.pnlDividend.Size = new System.Drawing.Size(128, 64);
            this.pnlDividend.TabIndex = 0;
            // 
            // pnlDivisor
            // 
            this.pnlDivisor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDivisor.BackColor = System.Drawing.Color.White;
            this.pnlDivisor.Location = new System.Drawing.Point(0, 65);
            this.pnlDivisor.Name = "pnlDivisor";
            this.pnlDivisor.Size = new System.Drawing.Size(128, 64);
            this.pnlDivisor.TabIndex = 1;
            // 
            // MathVisualDivision
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.pnlDivisor);
            this.Controls.Add(this.pnlDividend);
            this.Name = "MathVisualDivision";
            this.Size = new System.Drawing.Size(128, 129);
            this.ResumeLayout(false);

        }
    }
}
