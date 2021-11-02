/*
 * Created by SharpDevelop.
 * User: Microsan84
 * Date: 2017-04-02
 * Time: 20:11
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Microsan
{
    partial class TrigometricFunctionsForm
    {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnArcSin;
        private System.Windows.Forms.Button btnArcTan;
        private System.Windows.Forms.Button btnSin;
        private System.Windows.Forms.Button btnArcCot;
        private System.Windows.Forms.Button btnTan;
        private System.Windows.Forms.Button btnArcCos;
        private System.Windows.Forms.Button btnCot;
        private System.Windows.Forms.Button btnCos;
        private System.Windows.Forms.Panel panel1;
        
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
            this.btnArcSin = new System.Windows.Forms.Button();
            this.btnArcTan = new System.Windows.Forms.Button();
            this.btnSin = new System.Windows.Forms.Button();
            this.btnArcCot = new System.Windows.Forms.Button();
            this.btnTan = new System.Windows.Forms.Button();
            this.btnArcCos = new System.Windows.Forms.Button();
            this.btnCot = new System.Windows.Forms.Button();
            this.btnCos = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // btnArcSin
            // 
            this.btnArcSin.BackgroundImage = global::Microsan.Properties.Resources.trigFunc_arcsin;
            this.btnArcSin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnArcSin.Location = new System.Drawing.Point(256, 16);
            this.btnArcSin.Name = "btnArcSin";
            this.btnArcSin.Size = new System.Drawing.Size(232, 56);
            this.btnArcSin.TabIndex = 2;
            this.btnArcSin.Tag = "arcsin";
            this.btnArcSin.UseVisualStyleBackColor = true;
            // 
            // btnArcTan
            // 
            this.btnArcTan.BackgroundImage = global::Microsan.Properties.Resources.trigFunc_arctan;
            this.btnArcTan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnArcTan.Location = new System.Drawing.Point(256, 160);
            this.btnArcTan.Name = "btnArcTan";
            this.btnArcTan.Size = new System.Drawing.Size(232, 56);
            this.btnArcTan.TabIndex = 2;
            this.btnArcTan.Tag = "arctan";
            this.btnArcTan.UseVisualStyleBackColor = true;
            // 
            // btnSin
            // 
            this.btnSin.BackgroundImage = global::Microsan.Properties.Resources.trigFunc_sin;
            this.btnSin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSin.Location = new System.Drawing.Point(9, 15);
            this.btnSin.Name = "btnSin";
            this.btnSin.Size = new System.Drawing.Size(232, 56);
            this.btnSin.TabIndex = 2;
            this.btnSin.Tag = "sin";
            this.btnSin.UseVisualStyleBackColor = true;
            // 
            // btnArcCot
            // 
            this.btnArcCot.BackgroundImage = global::Microsan.Properties.Resources.trigFunc_arccot;
            this.btnArcCot.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnArcCot.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnArcCot.Location = new System.Drawing.Point(256, 232);
            this.btnArcCot.Name = "btnArcCot";
            this.btnArcCot.Size = new System.Drawing.Size(232, 56);
            this.btnArcCot.TabIndex = 2;
            this.btnArcCot.Tag = "arccot";
            this.btnArcCot.UseVisualStyleBackColor = true;
            // 
            // btnTan
            // 
            this.btnTan.BackgroundImage = global::Microsan.Properties.Resources.trigFunc_tan;
            this.btnTan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnTan.Location = new System.Drawing.Point(8, 160);
            this.btnTan.Name = "btnTan";
            this.btnTan.Size = new System.Drawing.Size(232, 56);
            this.btnTan.TabIndex = 2;
            this.btnTan.Tag = "tan";
            this.btnTan.UseVisualStyleBackColor = true;
            // 
            // btnArcCos
            // 
            this.btnArcCos.BackgroundImage = global::Microsan.Properties.Resources.trigFunc_arccos;
            this.btnArcCos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnArcCos.Location = new System.Drawing.Point(256, 88);
            this.btnArcCos.Name = "btnArcCos";
            this.btnArcCos.Size = new System.Drawing.Size(232, 56);
            this.btnArcCos.TabIndex = 2;
            this.btnArcCos.Tag = "arccos";
            this.btnArcCos.UseVisualStyleBackColor = true;
            // 
            // btnCot
            // 
            this.btnCot.BackgroundImage = global::Microsan.Properties.Resources.trigFunc_cot;
            this.btnCot.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCot.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCot.Location = new System.Drawing.Point(8, 232);
            this.btnCot.Name = "btnCot";
            this.btnCot.Size = new System.Drawing.Size(232, 56);
            this.btnCot.TabIndex = 2;
            this.btnCot.Tag = "cot";
            this.btnCot.UseVisualStyleBackColor = true;
            // 
            // btnCos
            // 
            this.btnCos.BackgroundImage = global::Microsan.Properties.Resources.trigFunc_cos;
            this.btnCos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCos.Location = new System.Drawing.Point(8, 88);
            this.btnCos.Name = "btnCos";
            this.btnCos.Size = new System.Drawing.Size(232, 56);
            this.btnCos.TabIndex = 2;
            this.btnCos.Tag = "cos";
            this.btnCos.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::Microsan.Properties.Resources.trigFunc_triangle;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.Location = new System.Drawing.Point(40, 288);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(440, 368);
            this.panel1.TabIndex = 9;
            // 
            // TrigometricFunctionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 662);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnArcSin);
            this.Controls.Add(this.btnArcCot);
            this.Controls.Add(this.btnArcTan);
            this.Controls.Add(this.btnArcCos);
            this.Controls.Add(this.btnSin);
            this.Controls.Add(this.btnCos);
            this.Controls.Add(this.btnTan);
            this.Controls.Add(this.btnCot);
            this.Name = "TrigometricFunctionsForm";
            this.Text = "TrigometricFunctionsForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.this_FormClosing);
            this.ResumeLayout(false);

        }
    }
}
