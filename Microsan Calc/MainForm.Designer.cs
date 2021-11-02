namespace Microsan
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel3 = new System.Windows.Forms.Panel();
            this.rbtnModeRadians = new System.Windows.Forms.RadioButton();
            this.rbtnModeDegrees = new System.Windows.Forms.RadioButton();
            this.cmbInput = new System.Windows.Forms.ComboBox();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageMIC = new System.Windows.Forms.TabPage();
            this.panelMIC = new System.Windows.Forms.Panel();
            this.tabPageRTP = new System.Windows.Forms.TabPage();
            this.panel3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageMIC.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.rbtnModeRadians);
            this.panel3.Controls.Add(this.rbtnModeDegrees);
            this.panel3.Location = new System.Drawing.Point(816, 8);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(142, 23);
            this.panel3.TabIndex = 11;
            // 
            // rbtnModeRadians
            // 
            this.rbtnModeRadians.AutoSize = true;
            this.rbtnModeRadians.Location = new System.Drawing.Point(74, 0);
            this.rbtnModeRadians.Name = "rbtnModeRadians";
            this.rbtnModeRadians.Size = new System.Drawing.Size(64, 17);
            this.rbtnModeRadians.TabIndex = 5;
            this.rbtnModeRadians.Text = "Radians";
            this.rbtnModeRadians.UseVisualStyleBackColor = true;
            // 
            // rbtnModeDegrees
            // 
            this.rbtnModeDegrees.AutoSize = true;
            this.rbtnModeDegrees.Checked = true;
            this.rbtnModeDegrees.Location = new System.Drawing.Point(3, 0);
            this.rbtnModeDegrees.Name = "rbtnModeDegrees";
            this.rbtnModeDegrees.Size = new System.Drawing.Size(65, 17);
            this.rbtnModeDegrees.TabIndex = 5;
            this.rbtnModeDegrees.TabStop = true;
            this.rbtnModeDegrees.Text = "Degrees";
            this.rbtnModeDegrees.UseVisualStyleBackColor = true;
            // 
            // cmbInput
            // 
            this.cmbInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbInput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInput.Font = new System.Drawing.Font("Courier New", 20.25F);
            this.cmbInput.FormattingEnabled = true;
            this.cmbInput.Location = new System.Drawing.Point(508, 0);
            this.cmbInput.MaxDropDownItems = 16;
            this.cmbInput.Name = "cmbInput";
            this.cmbInput.Size = new System.Drawing.Size(15, 38);
            this.cmbInput.TabIndex = 0;
            this.cmbInput.DropDown += new System.EventHandler(this.cmbInput_DropDown);
            this.cmbInput.SelectionChangeCommitted += new System.EventHandler(this.cmbInput_SelectionChangeCommitted);
            this.cmbInput.DropDownClosed += new System.EventHandler(this.cmbInput_DropDownClosed);
            // 
            // txtInput
            // 
            this.txtInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInput.Font = new System.Drawing.Font("Courier New", 20.25F);
            this.txtInput.Location = new System.Drawing.Point(0, 0);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(508, 38);
            this.txtInput.TabIndex = 13;
            this.txtInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInput_KeyPress);
            this.txtInput.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtInput_KeyUp);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageMIC);
            this.tabControl1.Controls.Add(this.tabPageRTP);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.ItemSize = new System.Drawing.Size(256, 21);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(534, 681);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            this.tabControl1.TabIndexChanged += new System.EventHandler(this.tabControl1_TabIndexChanged);
            // 
            // tabPageMIC
            // 
            this.tabPageMIC.Controls.Add(this.panelMIC);
            this.tabPageMIC.Controls.Add(this.txtInput);
            this.tabPageMIC.Controls.Add(this.cmbInput);
            this.tabPageMIC.Location = new System.Drawing.Point(4, 25);
            this.tabPageMIC.Name = "tabPageMIC";
            this.tabPageMIC.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMIC.Size = new System.Drawing.Size(526, 652);
            this.tabPageMIC.TabIndex = 0;
            this.tabPageMIC.Text = "Calculator";
            this.tabPageMIC.UseVisualStyleBackColor = true;
            // 
            // panelMIC
            // 
            this.panelMIC.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMIC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelMIC.Location = new System.Drawing.Point(0, 40);
            this.panelMIC.Name = "panelMIC";
            this.panelMIC.Size = new System.Drawing.Size(526, 612);
            this.panelMIC.TabIndex = 14;
            // 
            // tabPageRTP
            // 
            this.tabPageRTP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPageRTP.Location = new System.Drawing.Point(4, 25);
            this.tabPageRTP.Name = "tabPageRTP";
            this.tabPageRTP.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRTP.Size = new System.Drawing.Size(526, 652);
            this.tabPageRTP.TabIndex = 1;
            this.tabPageRTP.Text = "Programming";
            this.tabPageRTP.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 681);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel3);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Opacity = 0.98D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Microsan84 - Master Calculator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.this_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPageMIC.ResumeLayout(false);
            this.tabPageMIC.PerformLayout();
            this.ResumeLayout(false);

        }
        private System.Windows.Forms.Panel panelMIC;
        private System.Windows.Forms.TabPage tabPageRTP;
        private System.Windows.Forms.TabPage tabPageMIC;
        private System.Windows.Forms.TabControl tabControl1;

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton rbtnModeRadians;
        private System.Windows.Forms.RadioButton rbtnModeDegrees;
        private System.Windows.Forms.ComboBox cmbInput;
        private System.Windows.Forms.TextBox txtInput;
    }
}

