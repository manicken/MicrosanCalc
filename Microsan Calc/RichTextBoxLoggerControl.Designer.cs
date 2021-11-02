/*
 * Created by SharpDevelop.
 * User: Admin
 * Date: 2018-03-28
 * Time: 19:45
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Microsan
{
	partial class RichTextBoxLoggerControl
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
			this.rtxt = new System.Windows.Forms.RichTextBox();
			this.SuspendLayout();
			// 
			// rtxt
			// 
			this.rtxt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.rtxt.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rtxt.Location = new System.Drawing.Point(0, 3);
			this.rtxt.Name = "rtxt";
			this.rtxt.ReadOnly = true;
			this.rtxt.Size = new System.Drawing.Size(536, 513);
			this.rtxt.TabIndex = 2;
			this.rtxt.Text = "";
			// 
			// RichTextBoxLoggerControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.Controls.Add(this.rtxt);
			this.Name = "RichTextBoxLoggerControl";
			this.Size = new System.Drawing.Size(540, 515);
			this.ResumeLayout(false);
		}
		public System.Windows.Forms.RichTextBox rtxt;
	}
}
