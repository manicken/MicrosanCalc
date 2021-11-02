/*
 * Created by SharpDevelop.
 * User: Admin
 * Date: 2018-03-28
 * Time: 20:08
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Microsan
{
	/// <summary>
	/// Description of MouseInputControl.
	/// </summary>
	public partial class MouseInputControl : UserControl
	{
		public Action<string> FunctionButtonPressed;
        public Action<string> InputButtonPressed;

        public MouseInputControl()
        {
        	InitializeComponent();
        }
        public MouseInputControl(Action<string> _FunctionButtonPressed, Action<string> _InputButtonPressed)
        {
            FunctionButtonPressed = _FunctionButtonPressed;
            InputButtonPressed = _InputButtonPressed;
            
            InitializeComponent();
            
            btnInputHexA.MouseDown += btnInput_MouseDown;
            btnInputHexB.MouseDown += btnInput_MouseDown;
            btnInputHexC.MouseDown += btnInput_MouseDown;
            btnInputHexD.MouseDown += btnInput_MouseDown;
            btnInputHexE.MouseDown += btnInput_MouseDown;
            btnInputHexF.MouseDown += btnInput_MouseDown;


            btnInputNr0.MouseDown += btnInput_MouseDown;
            btnInputNr1.MouseDown += btnInput_MouseDown;
            btnInputNr2.MouseDown += btnInput_MouseDown;
            btnInputNr3.MouseDown += btnInput_MouseDown;
            btnInputNr4.MouseDown += btnInput_MouseDown;
            btnInputNr5.MouseDown += btnInput_MouseDown;
            btnInputNr6.MouseDown += btnInput_MouseDown;
            btnInputNr7.MouseDown += btnInput_MouseDown;
            btnInputNr8.MouseDown += btnInput_MouseDown;
            btnInputNr9.MouseDown += btnInput_MouseDown;
            
            btnInputGB.MouseDown += btnInput_MouseDown;
            btnInputKB.MouseDown += btnInput_MouseDown;
            btnInputMB.MouseDown += btnInput_MouseDown;
            btnInputTB.MouseDown += btnInput_MouseDown;
            
            btnLeftParantesis.MouseDown += btnInput_MouseDown;
            btnRightParantesis.MouseDown += btnInput_MouseDown;
            
            btnInputComma.MouseDown += btnInput_MouseDown;
            btnInputFuncAdd.MouseDown += btnInput_MouseDown;
            btnInputFuncSub.MouseDown += btnInput_MouseDown;
            btnInputFuncDivide.MouseDown += btnInput_MouseDown;
            btnInputFuncMulti.MouseDown += btnInput_MouseDown;
            
            btnInputPi.MouseDown += btnInput_MouseDown;
            btnInputPow.MouseDown += btnInput_MouseDown;
            btnInputSquareRoot.MouseDown += btnInput_MouseDown;
            btnInputExp.MouseDown += btnInput_MouseDown;
            btnInpute.MouseDown += btnInput_MouseDown;

            btnFuncBackspace.MouseDown += btnFuncX_MouseDown;
            btnFunkEnter.MouseDown += btnFuncX_MouseDown;
            
            btnFuncLastEntry.MouseDown += btnFuncX_MouseDown;
            
            btnFuncOneDivideBy.MouseDown += btnInput_MouseDown;
            btnFuncAns.MouseDown += btnInput_MouseDown;
        }


        private void btnFuncX_Click(object s, EventArgs ea)
        {
        	//if (FunctionButtonPressed != null)
            	FunctionButtonPressed((string)((Button)s).Tag);
        }
        private void btnFuncX_MouseDown(object s, MouseEventArgs e)
        {

            //if (FunctionButtonPressed != null)

            if (e.Button != MouseButtons.Left)
                return;

            FunctionButtonPressed((string)((Button)s).Tag);
        }

        private void btnInput_Click(object s, EventArgs ea)
        {
        	//if (InputButtonPressed != null)
            	InputButtonPressed((string)((Button)s).Tag);
        }
        private void btnInput_MouseDown(object s, MouseEventArgs e)
        {
            //if (InputButtonPressed != null)
            if (e.Button != MouseButtons.Left)
                return;

            InputButtonPressed((string)((Button)s).Tag);
        }
    }
}
