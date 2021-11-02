/*
 * Created by SharpDevelop.
 * User: Microsan84
 * Date: 2017-04-26
 * Time: 23:18
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Microsan
{
    /// <summary>
    /// Description of MouseInputForm.
    /// </summary>
    public partial class MouseInputForm : Form
    {
        public Action<string> FunctionButtonPressed;
        public Action<string> InputButtonPressed;
        
        public MouseInputForm(Action<string> _FunctionButtonPressed, Action<string> _InputButtonPressed)
        {
            FunctionButtonPressed = _FunctionButtonPressed;
            InputButtonPressed = _InputButtonPressed;
            
            InitializeComponent();
            
            btnInputHexA.Click += btnInput_Click;
            btnInputHexB.Click += btnInput_Click;
            btnInputHexC.Click += btnInput_Click;
            btnInputHexD.Click += btnInput_Click;
            btnInputHexE.Click += btnInput_Click;
            btnInputHexF.Click += btnInput_Click;
   
            btnInputNr0.Click += btnInput_Click;
            btnInputNr1.Click += btnInput_Click;
            btnInputNr2.Click += btnInput_Click;
            btnInputNr3.Click += btnInput_Click;
            btnInputNr4.Click += btnInput_Click;
            btnInputNr5.Click += btnInput_Click;
            btnInputNr6.Click += btnInput_Click;
            btnInputNr7.Click += btnInput_Click;
            btnInputNr8.Click += btnInput_Click;
            btnInputNr9.Click += btnInput_Click;
            
            btnInputGB.Click += btnInput_Click;
            btnInputKB.Click += btnInput_Click;
            btnInputMB.Click += btnInput_Click;
            btnInputTB.Click += btnInput_Click;
            
            btnLeftParantesis.Click += btnInput_Click;
            btnRightParantesis.Click += btnInput_Click;
            
            btnInputComma.Click += btnInput_Click;
            btnInputFuncAdd.Click += btnInput_Click;
            btnInputFuncSub.Click += btnInput_Click;
            btnInputFuncDivide.Click += btnInput_Click;
            btnInputFuncMulti.Click += btnInput_Click;
            
            btnInputPi.Click += btnInput_Click;
            btnInputPow.Click += btnInput_Click;
            btnInputSquareRoot.Click += btnInput_Click;
            btnInputExp.Click += btnInput_Click;
            btnInpute.Click += btnInput_Click;

            btnFuncBackspace.Click += btnFuncX_Click;
            btnFuncClearEntry.Click += btnFuncX_Click;
            btnFunkEnter.Click += btnFuncX_Click;
            
            btnFuncLastEntry.Click += btnFuncX_Click;
            
            btnFuncOneDivideBy.Click += btnInput_Click;
            btnFuncAns.Click += btnInput_Click;
        }
        
        private void btnFuncX_Click(object s, EventArgs ea)
        {
            FunctionButtonPressed((string)((Button)s).Tag);
        }
        
        private void btnInput_Click(object s, EventArgs ea)
        {
            InputButtonPressed((string)((Button)s).Tag);
        }
        void MouseInputForm_Load(object sender, EventArgs e)
        {
            // TODO: Implement MouseInputForm_Load
        }
    }
}
