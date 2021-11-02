using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
using System.Drawing;
//using System.Linq;
//using System.Text;
using System.Windows.Forms;
using Ionic.Zip;



using System.Text;

using Crom.Controls.Docking;

namespace Microsan
{
    public partial class MainForm : Form
    {
        public readonly string MAIN_FORM_TITLE = "Microsan84 - Master ";
        public readonly string STATE_FILE_CALC_LOG = "CalcLog.rtf";
        public readonly string STATE_FILE_CALC_ENTRIES = "CalcEntries.txt";
        
        public MathParserTK.MathParser mathParser;
        public double lastAnswer = 0.0f;
        public string lastEntry = "";

        public PlotForm plotForm;
        public DataGridViewForm dgvform;
        public TrigometricFunctionsForm trigFuncForm;
        
        public RuntimeEditGuiForm runtimeEditGuiForm;
        
        public MouseInputControl miCtrl;
        public RichTextBoxLoggerControl rtxtLogCtrl;
        
//        /// <summary> Main - Dock Container </summary>
//        public DockContainer dcMain;
//        /// <summary> RunTime Programming - Dock Container </summary>
//        public DockContainer dcRTP;
//        /// <summary> Manual Input Calculator - Dock Container </summary>
//        public DockContainer dcMIC;
//        
//        public DockableFormInfo dfi_RTP;
//        public DockableFormInfo dfi_MIC;
//        
//        public DockStateSerializer dcSerializer;
//        public DockableFormInfo dfi_rtxtForm;
//        public DockableFormInfo dfi_miForm;
//        public DockableFormInfo dfi_srcEditForm;
        
        public RuntimeProgramming rtProgramming;

        public MainForm()
        {
            plotForm = new PlotForm();

            InitializeComponent();

            mathParser = new MathParserTK.MathParser('.');

            rtProgramming = new RuntimeProgramming(this);
            
            //MathNet.Numerics.Trig.Acos(0);
            
            
            
            //rtxtForm = new RichTextBoxForm();//RichTextBoxForm_WidthChanged);
            
            
            miCtrl = new MouseInputControl(MouseInput_FunctionButtonPressed, MouseInput_InputButtonPressed);
            miCtrl.btnShowTrig.Click += tsbtnShowTrigometricFuncs_Click;
            rtxtLogCtrl = new RichTextBoxLoggerControl();
            rtxtLogCtrl.rtxt.TextChanged += rtxtLog_TextChanged;
            
            trigFuncForm = new TrigometricFunctionsForm(MouseInput_InputButtonPressed);
            
            runtimeEditGuiForm = new RuntimeEditGuiForm();
            
//            dcMain = new DockContainer();
//            dcRTP = new DockContainer();
//            dcMIC = new DockContainer();
//            
//            dcSerializer = new DockStateSerializer(dcMain); // DockStateSerializer is bullshit piece of crap
//            dcSerializer.SavePath = Application.StartupPath + "\\DockSave.xml"; //
//            
//            dcMain.Dock = DockStyle.Fill;
//            dcMIC.Dock = DockStyle.Fill;
//            dcRTP.Dock = DockStyle.Fill;
//            
//            tabPageMIC.Controls.Add(dcMIC);
            
            miCtrl.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            miCtrl.Top = panelMIC.Height - miCtrl.Height;// * miCtrl.CurrentAutoScaleDimensions.Height);
            
            rtxtLogCtrl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            rtxtLogCtrl.Top = 0;
            rtxtLogCtrl.Left = 0;
            rtxtLogCtrl.Width = panelMIC.Width;
            rtxtLogCtrl.Height = panelMIC.Height - miCtrl.Height;// * miCtrl.CurrentAutoScaleDimensions.Height);
            
            panelMIC.Controls.Add(miCtrl);
            panelMIC.Controls.Add(rtxtLogCtrl);

           
            
//            dcRTP.FormClosing += dc_FormClosing;
//            dcRTP.FormClosed += dc_FormClosed;
//            dcMIC.FormClosing += dc_FormClosing;
//            dcMIC.FormClosed += dc_FormClosed;
//            
//            dfi_miForm = dcMIC.Add(miForm, zAllowedDock.All, new Guid("00000000000000000000000000000001"));     //miForm.GetType().GUID);
//            dfi_rtxtForm = dcMIC.Add(rtxtForm, zAllowedDock.All, new Guid("00000000000000000000000000000002")); //rtxtForm.GetType().GUID);
//            dfi_srcEditForm = dcRTP.Add(rtProgramming.srcEditForm, zAllowedDock.All, new Guid("00000000000000000000000000000003")); //srcEditForm.GetType().GUID);
//
//            dcRTP.DockForm(dfi_srcEditForm, DockStyle.Fill, zDockMode.Inner);
//            dcMIC.DockForm(dfi_rtxtForm, DockStyle.Fill, zDockMode.Inner);
//            dcMIC.DockForm(dfi_miForm, dfi_miForm,  DockStyle.Bottom, zDockMode.Inner);
        }

        public bool GetFirstForm(string name, out Form form)
        {
            form = null;
            for (int i = 0; i < Application.OpenForms.Count; i++)
            {
                form = Application.OpenForms[i];
                if (form.Text == name)
                    return true;
            }
            return false;
        }

        private void SaveCalcState()
        {
            rtxtLogCtrl.SaveLog(STATE_FILE_CALC_LOG);
            System.IO.File.WriteAllLines(STATE_FILE_CALC_ENTRIES, cmbInput.Items.ToStringArray());//.StringItems());
        }
        
        private void LoadCalcState()
        {
        	rtxtLogCtrl.LoadLog(STATE_FILE_CALC_LOG, true);
            
            if (System.IO.File.Exists(STATE_FILE_CALC_ENTRIES))
            {
                cmbInput.Items.Clear();
                cmbInput.Items.AddRange(System.IO.File.ReadAllLines(STATE_FILE_CALC_ENTRIES));
            }
        }

//        private void dc_FormClosed(object sender, FormEventArgs e)
//        {
//            e.Form.Close();
//        }
//
//        private void dc_FormClosing(object sender, DockableFormClosingEventArgs e)
//        {
//            //DockableFormInfo info = _docker.GetFormInfo(e.Form);
//            //if (info.Id == dfi_miForm.Id)
//            //{
//                e.Cancel = true;
//            //}
//        }
		
        private void DockMode_RefreshWindowRectangles()
        {
            Size thisSize = this.Size;
            thisSize.Width += 1;
            thisSize.Height += 1;
            this.Size = thisSize;
            thisSize.Width -= 1;
            thisSize.Height -= 1;
            this.Size = thisSize;
            //this.Width += 1; // don't work
            //this.Width -= 1; // don't work
        }
        
//        private void DockMode_LockAll()
//        {
//            tsmiDockLockAll.Enabled = false;
//            tsmiDockUnlockAll.Enabled = true;
//
//            rtProgramming.srcEditForm.FormBorderStyle = FormBorderStyle.None;
//            //rtxtForm.FormBorderStyle = FormBorderStyle.None;
//            //miForm.FormBorderStyle = FormBorderStyle.None;
//            
//            DockMode_RefreshWindowRectangles();
//        }
//
//        private void DockMode_UnlockAll()
//        {
//            tsmiDockLockAll.Enabled = true;
//            tsmiDockUnlockAll.Enabled = false;
//            
//            rtProgramming.srcEditForm.FormBorderStyle = FormBorderStyle.Fixed3D;
//            //rtxtForm.FormBorderStyle = FormBorderStyle.Fixed3D;
//            //miForm.FormBorderStyle = FormBorderStyle.Fixed3D;
//            
//            DockMode_RefreshWindowRectangles();
//        }

        private void MouseInput_FunctionButtonPressed(string func)
        {
            if (func == "backspace")
                FuncBackspace();
            else if (func == "enter")
                DoCalc();
            else if (func == "clear")
            {
                rtxtLogCtrl.Clear();
                SetInputAndFocus("");
            }
            else if (func == "clearEntry")
                SetInputAndFocus("");
            else if (func == "lastEntry")
                SetInputAndFocus(lastEntry);
        }
        
        private void FuncBackspace()
        {
            if (txtInput.SelectionStart == 0) return;
            if (txtInput.SelectionLength == 0)
            {
                txtInput.SelectionStart--;
                txtInput.SelectionLength = 1;
            }
            txtInput.SelectedText = "";
            txtInput.SelectionLength = 0;

            txtInput.Focus();
        }
        
        private void MouseInput_InputButtonPressed(string input)
        {
            string tmp = input;

            bool wasEmpty = (txtInput.Text.Length == 0);
            bool selectionIsAtEnd = (txtInput.SelectionStart == txtInput.Text.Length);
            bool isFunction = mathParser.supportedFunctions.ContainsKey(tmp);
            int selStart = txtInput.SelectionStart;
            
            if (isFunction)
                txtInput.SelectedText = tmp + "()";
            else if (tmp == "(" && selectionIsAtEnd)
                txtInput.SelectedText = tmp + ")";
            else if (tmp == "1/x")
            {
                txtInput.Text = "1/(" + txtInput.Text + ")";
                txtInput.SelectionStart = txtInput.Text.Length;
            }
            else
                txtInput.SelectedText = tmp;

            if (wasEmpty)
            {
                if (tmp == "+" || tmp == "-" || tmp == "*" || tmp == "/")
                    txtInput.Text = "Ans" + txtInput.Text;

                txtInput.SelectionStart = txtInput.Text.Length;
            }
            if (isFunction || ((tmp == "(") && selectionIsAtEnd) || (wasEmpty && (tmp == "1/x")))
                txtInput.SelectionStart--;

            txtInput.Focus();
            
            txtInput.SelectionLength = 0;
        }

        public void ShowPlot()
        {
            plotForm.Show();
            plotForm.WindowState = FormWindowState.Normal;
            plotForm.TopMost = true;
            plotForm.TopMost = false;
        }
        
        public void HidePlot()
        {
        	plotForm.Visible = false;
        }

        /// <summary> Is the inverse of UsingRadians </summary>
        public bool UsingDegrees {
            get { return rbtnModeDegrees.Checked; }
        }
        
        /// <summary> Is the inverse of UsingDegrees </summary>
        public bool UsingRadians {
            get { return rbtnModeRadians.Checked; }
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            LoadCalcState();

            //DockMode_LockAll();
			
            
            
            txtInput.Focus();
        }
        
        private void this_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveCalcState();
        }
        
//        private Form DockInitializer(Guid identifier)
//        {
//            if (identifier == miForm.GetType().GUID)
//                return miForm;
//            else if (identifier == rtxtForm.GetType().GUID)
//                return rtxtForm;
//            else if (identifier == rtProgramming.srcEditForm.GetType().GUID)
//                return rtProgramming.srcEditForm;
//            else
//                return new Form();
//        }
		
        private void txtInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ',')
                e.KeyChar = '.';
            if (txtInput.Text.Length == 0)
            {
                if (e.KeyChar == '+' || e.KeyChar == '-' || e.KeyChar == '*' || e.KeyChar == '/')
                    txtInput.Text = "Ans" + txtInput.Text;
            }
        }

        private void txtInput_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                DoCalc();
        }
        
        // TODO: Fix matching parantesis thingy, so that we can have parantesis inside function call
        public string PreParseUsingCustomFunc(string input, string funcName, Func<string, string> customfunc)
        {
          try 
          {
            int indexOfToInt = input.ToUpper().IndexOf(funcName.ToUpper());
            
            if (indexOfToInt != -1)
            {
                //rtxtForm.rtxt.AppendTextLine("preParse: " + input);
                string subParse;
                if (input.TryGetSubstringBetween(indexOfToInt + funcName.Length, '(', ')', out subParse))
                {
                    //rtxtForm.rtxt.AppendTextLine(" PreParseUsingCustomFunc:\n subParse>>>" + subParse + "<<<", HorizontalAlignment.Left);
                    
                    input = input.Remove(indexOfToInt, funcName.Length + 1 + subParse.Length + 1);
                    
                    //rtxtForm.rtxt.AppendTextLine(" PreParseUsingCustomFunc:\n input after remove>>>" + input + "<<<", HorizontalAlignment.Left);
                    
                    if (customfunc != null)
                        input = input.Insert(indexOfToInt, customfunc(subParse));
                    else
                        input.Insert(indexOfToInt, subParse);
                    
                    //rtxtForm.rtxt.AppendTextLine(" PreParseUsingCustomFunc:\n input after insert>>>" + input + "<<<", HorizontalAlignment.Left);
                }
                else
                    rtxtLogCtrl.AppendTextLine(" PreParseUsingCustomFunc:\n missing matching parantesis", HorizontalAlignment.Center);
            }
          }
          catch (Exception ex)
          {
              rtxtLogCtrl.AppendText(txtInput.Text + " = " + ex.Message + "\n");
          }
            return input;
        }
        
        public string ToInt(string subInput)
        {
            return ((int)mathParser.Parse(subInput, UsingRadians)).ToString();
        }
        public string FromHex(string subInput)
        {
            int intAgain = int.Parse(subInput, System.Globalization.NumberStyles.HexNumber);
            //rtxtForm.rtxt.AppendTextLine(" FromHex result:" + intAgain.ToString(), HorizontalAlignment.Center);
            return intAgain.ToString();
        }

        public void DoCalc()
        {
            double result = 0.0f;
            if (txtInput.Text.Trim().Length != 0)
                lastEntry = txtInput.Text;
            else if (lastEntry.Length == 0)
                return;

            if (!cmbInput.Items.Contains(txtInput.Text))
                cmbInput.Items.Add(txtInput.Text);

            string preParsedInput = lastEntry;
            
            rtxtLogCtrl.AppendTextLine(preParsedInput, HorizontalAlignment.Left);
            
            preParsedInput = PreParseUsingCustomFunc(preParsedInput, "ToInt", ToInt);
            preParsedInput = PreParseUsingCustomFunc(preParsedInput, "Hex", FromHex);
            
            preParsedInput = preParsedInput.Replace("Ans", lastAnswer.ToString().Replace(',', '.'));
            preParsedInput = preParsedInput.Replace("E", "*10^");
            preParsedInput = preParsedInput.Replace("KB", "*1024");
            preParsedInput = preParsedInput.Replace("MB", "*(1024^2)");
            preParsedInput = preParsedInput.Replace("GB", "*(1024^3)");
            preParsedInput = preParsedInput.Replace("TB", "*(1024^4)");
            
            try
            {
                result = mathParser.Parse(preParsedInput, UsingRadians);
                
                string resultStrExp = String.Format("{0:e2}", result);
                double resultExpDecimal = Convert.ToDouble(resultStrExp.Substring(0, resultStrExp.IndexOf('e')));
                int resultExpValue = Convert.ToInt32(resultStrExp.Substring(resultStrExp.IndexOf('e')+1));
                
                if (resultExpValue < -12) {
                    resultExpDecimal *= Math.Pow(10, 15-Math.Abs(resultExpValue));
                    resultExpValue = -15;
                }
                else if (resultExpValue < -9) {
                    resultExpDecimal *= Math.Pow(10, 12-Math.Abs(resultExpValue));
                    resultExpValue = -12;
                }
                else if (resultExpValue < -6) {
                    resultExpDecimal *= Math.Pow(10, 9-Math.Abs(resultExpValue));
                    resultExpValue = -9;
                }
                else if (resultExpValue < -3) {
                    resultExpDecimal *= Math.Pow(10, 6-Math.Abs(resultExpValue));
                    resultExpValue = -6;
                }
                else if (resultExpValue < 0) {
                    resultExpDecimal *= Math.Pow(10, 3-Math.Abs(resultExpValue));
                    resultExpValue = -3;
                }
                else if (resultExpValue < 3) {
                    //resultExpDecimal *= Math.Pow(10, resultExpValue);
                    resultExpValue = 0;
                }

                string resultStr = "";
                if (resultExpValue < -3)
                    resultStr = String.Format("{0:N}E{1:00}", resultExpDecimal, resultExpValue);
                else
                    resultStr = result.ToString();
                //string resultStr = String.Format("{0:F12} ({1:0.############}E{2:00})", result, resultExpDecimal, resultExpValue);

                resultStr = resultStr.Replace(',', '.');
                rtxtLogCtrl.AppendTextLine(resultStr, HorizontalAlignment.Right);

                txtInput.Text = "";
                lastAnswer = result;
            }
            catch (Exception ex)
            {
                rtxtLogCtrl.AppendText(txtInput.Text + " = " + ex.Message + "\n");
            }
        }

        private void rtxtLog_TextChanged(object sender, EventArgs e)
        {
            txtInput.Focus();
        }

        private void SetInputAndFocus(string text)
        {
            txtInput.Text = text;
            txtInput.SelectionLength = 0;
            txtInput.SelectionStart = txtInput.Text.Length;
            txtInput.Focus();
        }

        private void MakePortableExeWithEmbeddedData()
        {
//            ZipFile zip = new ZipFile();
//            SelfExtractorSaveOptions seso = new SelfExtractorSaveOptions();
//            seso.DefaultExtractDirectory = "C:\\temp\\Microsan Calc";
//            seso.ExtractExistingFile = ExtractExistingFileAction.OverwriteSilently;
//            zip.CompressionLevel = Ionic.Zlib.CompressionLevel.None;
//            seso.IconFile = "mainIcon.ico";
//            seso.Quiet = true;
//            seso.PostExtractCommandLine = "\"" + seso.DefaultExtractDirectory + "\\Microsan Calc.exe\"";
//            zip.AddFile("Microsan Calc.exe");
//            zip.AddFile("Ionic.Zip.dll");
//            zip.AddFile("variables.xml");
//            zip.AddFile("functions.xml");
//            zip.AddFile("mainIcon.ico");
//            zip.SaveSelfExtractor("Microsan Calc With Data.exe", seso);
        }

        void tsbtnShowTrigometricFuncs_Click(object sender, EventArgs e)
        {
            trigFuncForm.Show();
        }

//        void tsmiDockUnlockAll_Click(object sender, EventArgs e)
//        {
//            DockMode_UnlockAll();
//        }
//        
//        void tsmiDockLockAll_Click(object sender, EventArgs e)
//        {
//            DockMode_LockAll();
//        }
        
        void cmbInput_DropDownClosed(object sender, EventArgs e)
        {
            cmbInput.Width = (int)cmbInput.Tag;
            cmbInput.Left = txtInput.Left + txtInput.Width + 1;
        }
        void cmbInput_DropDown(object sender, EventArgs e)
        {
            cmbInput.Tag = cmbInput.Width;
            cmbInput.Width = txtInput.Width;
            cmbInput.Left = txtInput.Left;
        }
        void cmbInput_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtInput.Text = cmbInput.Text;
        }
        void MainForm_Load(object sender, EventArgs e)
        {
            // TODO: Implement MainForm_Load
        }
        void toolStripButton1_Click(object sender, EventArgs e)
        {
            MathVisualExpressionForm mveForm = new MathVisualExpressionForm();
            mveForm.Show();
        }
        
        
        void SourceCodeEditControl1Load(object sender, EventArgs e)
        {
        	
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Text = MAIN_FORM_TITLE + tabControl1.SelectedTab.Text;
            if (tabControl1.SelectedTab.Text == "Programming")
            {
                rtProgramming.InitScriptEditor_IfNeeded();

                if (!tabPageRTP.Controls.Contains(rtProgramming.srcEditCtrl))
                    tabPageRTP.Controls.Add(rtProgramming.srcEditCtrl);

                rtProgramming.srcEditCtrl.Dock = DockStyle.Fill;

                rtProgramming.ShowScriptEditor();
            }
            
        }

        private void tabControl1_TabIndexChanged(object sender, EventArgs e)
        {
            /*
            if (tabControl1.SelectedTab.Name == "Programming")
            {
                this.Text = "Programming tab";
                rtProgramming.ShowScriptEditor();
            }
            else
                rtxtLogCtrl.AppendTextLine("Programming tab not selected");
                */
        }
    }
    
}
