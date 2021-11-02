/*
 * Created by SharpDevelop.
 * User: Microsan84
 * Date: 2017-05-09
 * Time: 00:06
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Microsan
{
    partial class MathVisualExpressionForm
    {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Microsan.MathVisualDivision mathVisualDivisionMain;
        private Microsan.MathVisualDivision mathVisualDivisionDividend;
        private System.Windows.Forms.Button button1;
        
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
            this.mathVisualDivisionMain = new Microsan.MathVisualDivision();
            this.mathVisualDivisionDividend = new Microsan.MathVisualDivision();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mathVisualDivisionMain
            // 
            this.mathVisualDivisionMain.Location = new System.Drawing.Point(104, 48);
            this.mathVisualDivisionMain.Name = "mathVisualDivisionMain";
            this.mathVisualDivisionMain.Size = new System.Drawing.Size(312, 168);
            this.mathVisualDivisionMain.TabIndex = 0;
            // 
            // mathVisualDivisionDividend
            // 
            this.mathVisualDivisionDividend.Location = new System.Drawing.Point(176, 264);
            this.mathVisualDivisionDividend.Name = "mathVisualDivisionDividend";
            this.mathVisualDivisionDividend.Size = new System.Drawing.Size(104, 64);
            this.mathVisualDivisionDividend.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(56, 280);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 56);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MathVisualExpressionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 559);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.mathVisualDivisionDividend);
            this.Controls.Add(this.mathVisualDivisionMain);
            this.Name = "MathVisualExpressionForm";
            this.Text = "MathVisualExpressionForm";
            this.ResumeLayout(false);

        }
    }
}
