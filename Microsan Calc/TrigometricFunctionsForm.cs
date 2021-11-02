/*
 * Created by SharpDevelop.
 * User: Microsan84
 * Date: 2017-04-02
 * Time: 20:11
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Microsan
{
    /// <summary>
    /// Description of TrigometricFunctionsForm.
    /// </summary>
    public partial class TrigometricFunctionsForm : Form
    {
        public Action<string> FuncAppend;
        
        
        
        public TrigometricFunctionsForm(Action<string> FuncAppend_Handler)
        {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();
            
            FuncAppend = FuncAppend_Handler;
            
            btnArcCos.Click += btnFunc_Click;
            btnArcCot.Click += btnFunc_Click;
            btnArcSin.Click += btnFunc_Click;
            btnArcTan.Click += btnFunc_Click;
            btnCos.Click += btnFunc_Click;
            btnCot.Click += btnFunc_Click;
            btnSin.Click += btnFunc_Click;
            btnTan.Click += btnFunc_Click;
        }
        
        private void btnFunc_Click(object s, EventArgs e)
        {
            FuncAppend(((Button)s).Name.Substring(3).ToLower() + "()");
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
