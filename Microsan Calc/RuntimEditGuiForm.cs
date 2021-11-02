/*
 * Created by SharpDevelop.
 * User: Microsan84
 * Date: 2017-04-04
 * Time: 11:55
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using UserRectDemo;

namespace Microsan
{
    /// <summary>
    /// Description of RuntimEditGuiForm.
    /// </summary>
    public partial class RuntimeEditGuiForm : Form
    {
        public UserRect rect;
        public UserRect rect2;
        
        public RuntimeEditGuiForm()
        {
            InitializeComponent();
            
            rect = new UserRect(new Rectangle(10, 10, 20, 20));
            
            rect.SetPictureBox(panelRootGui);
            
            rect2 = new UserRect(new Rectangle(10, 50, 20, 20));
            
            rect2.SetPictureBox(panelRootGui);
        }
        
        private void this_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Visible = false;
            }
        }
    }
}
