/*
 * Created by SharpDevelop.
 * User: Microsan84
 * Date: 2017-03-31
 * Time: 10:12
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Microsan
{
    /// <summary>
    /// Description of RichTextBoxForm.
    /// </summary>
    public partial class RichTextBoxForm : Form
    {
    	public RichTextBoxLoggerControl rtxtLogCtrl;
    	
        public RichTextBoxForm()
        {

            InitializeComponent();
            
            rtxtLogCtrl = new RichTextBoxLoggerControl();
            
            rtxtLogCtrl.Dock = DockStyle.Fill;
            
            this.Controls.Add(rtxtLogCtrl);

            //ToolStrip ts = new ToolStrip(new ToolStripButton("Open"), new ToolStripButton("Close"));
            //ts.Dock = System.Windows.Forms.DockStyle.Top;

        }
        
        public void AppendText(string text)
        {
        	rtxtLogCtrl.AppendText(text);
        }
        
        public void AppendTextLine(string line)
        {
        	rtxtLogCtrl.AppendTextLine(line);
        }
        
        public void AppendTextLine(string t, HorizontalAlignment a)
        {
        	rtxtLogCtrl.AppendTextLine(t, a);
        }

        private void RichTextBoxForm_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.TopMost = false;
        }
        private void this_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible && this.TopLevel)
            {
                this.TopMost = true;
                this.TopMost = false;
            }
        }

    }
    
    
}
