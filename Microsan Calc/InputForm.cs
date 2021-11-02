using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Microsan
{
    public partial class InputForm : Form
    {
        //public delegate bool DoVerifyInputEventHandler(string msg);

        /// <summary> This function pointer is called when the user presses OK, to verify input. </summary>
        public Func<string, bool> DoVerifyInput = null;

        bool allowEmptyInput = true;

        string defaultInput = "";

        /// <summary> Gets the user input value.</summary>
        public string InputValue
        {
            get { return txtInput.Text; }
        }

        public InputForm()
        {
            InitializeComponent();
        }

        public DialogResult ShowDialog(string title, string msg, string defaultInput, bool allowEmptyInput, bool selectAll, FormStartPosition formStartPos)
        {
            this.StartPosition = formStartPos;

            int heightOffset = this.Height - lblMessage.Height;

            this.Text = title;
            this.defaultInput = defaultInput;

            txtInput.Text = defaultInput;

            if (selectAll)
                txtInput.Select(0, txtInput.TextLength);
            else
                txtInput.Select(txtInput.TextLength, 0); // deselect all and set cursor at end

            this.allowEmptyInput = allowEmptyInput;
            lblMessage.Text = msg;
            this.Height = heightOffset + lblMessage.Height;
            //this.Width = lblMessage.Width + lblMessage.Left*4;

            return this.ShowDialog();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (DoVerifyInput != null)
            {
                if (!DoVerifyInput(txtInput.Text))
                {
                    txtInput.SelectAll();
                    txtInput.Focus();
                    return;
                }
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void txtInput_TextChanged(object sender, EventArgs e)
        {
            if (txtInput.Text.Trim().Length == 0)
            {
                if (!allowEmptyInput)
                {
                    lblInputIsEmpty.Visible = true;
                    btnOK.Enabled = false;
                }
            }
            else
            {
                lblInputIsEmpty.Visible = false;
                if (txtInput.Text == defaultInput)
                    btnOK.Enabled = false;
                else
                    btnOK.Enabled = true;
            }
        }

        private void InputForm_Shown(object sender, EventArgs e)
        {
            
        }
    }
}
