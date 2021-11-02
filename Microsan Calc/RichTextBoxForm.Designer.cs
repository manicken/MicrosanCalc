/*
 * Created by SharpDevelop.
 * User: Microsan84
 * Date: 2017-03-31
 * Time: 10:12
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Microsan
{
    partial class RichTextBoxForm
    {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        
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
            this.SuspendLayout();
            // 
            // RichTextBoxForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(248, 239);
            this.Name = "RichTextBoxForm";
            this.Opacity = 0.96D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Output";
            this.Load += new System.EventHandler(this.RichTextBoxForm_Load);
            this.Click += new System.EventHandler(this.RichTextBoxForm_Load);
            this.ResumeLayout(false);

        }
    }
}
