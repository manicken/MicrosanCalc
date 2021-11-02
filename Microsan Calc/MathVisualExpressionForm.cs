/*
 * Created by SharpDevelop.
 * User: Microsan84
 * Date: 2017-05-09
 * Time: 00:06
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Microsan
{
    /// <summary>
    /// Description of MathVisualExpressionForm.
    /// </summary>
    public partial class MathVisualExpressionForm : Form
    {
        public MathVisualExpressionForm()
        {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();
            
            //
            // TODO: Add constructor code after the InitializeComponent() call.
            //
        }
        void button1_Click(object sender, EventArgs e)
        {
            mathVisualDivisionMain.pnlDividend.Controls.Add(mathVisualDivisionDividend);
            mathVisualDivisionDividend.Dock = DockStyle.Fill;
        }
    }
}
