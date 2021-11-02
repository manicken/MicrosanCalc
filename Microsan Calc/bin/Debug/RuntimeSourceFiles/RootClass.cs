using System;
using System.Text;
using Microsan;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using SimpleWebServer;

namespace MyNamespace
{ 
    // exposed methods from MainForm:
    // public void AppendToInput(string text)
    // public void DoCalc()
    
    // exposed fields from MainForm:
    // public UserDataForm functionForm;
    // public UserDataForm variableForm;
    // public MathParserTK.MathParser mathParser;
    // public double lastAnswer;
    // public string lastEntry;
    
    public class RootClass
    {
        public static MainForm form;
        public static List<Form> forms;
        public static RichTextBoxForm rtxtForm;

        public static WebServer server;
        
        /// <summary>
        /// The main entry point for the runtime compile code.
        /// </summary>
        public static void RootMain(object rootObject)
        {
            RootClass.form        = (MainForm)rootObject;
            PlotHelpers.plotView  = RootClass.form.plotForm.plotView;
            PlotHelpers.emptyPlot = new PlotModel();
            
            GetPreviousForms();
            Init_RuntimeLogForm();
            
            //SerialPortExt.Init();
    
            Log.Clear(); RemoveLogFormUserButtons();
            
            DGV.Init();
            
            PlotHelpers.Setup_LinearPlot("WS2812b_vdrop", "meter", "volt");
            PlotHelpers.ClearPlot();
            
            //Calc_WS2812b_vdrop(4.95, 0.018, 0.06679f, 5, 25, 5); // (currVoltage, wireResistance, stepWireResistance, mainWireStep, totalMeters, stepLedCount)
            
            //Calc_WS2812b_vdrop(5, 0.01975, 0.06679f, 5, 25, 10); // (currVoltage, wireResistance, stepWireResistance, mainWireStep, totalMeters, stepLedCount)
            
            //Calc_WS2812b_vdrop(5, 0.018, 0.06679f, 5, 25, 10); // (currVoltage, wireResistance, stepWireResistance, mainWireStep, totalMeters, stepLedCount)
            
            //Calc_WS2812b_vdrop(5, 0.018, 0.06679f, 2.5, 25, 5); // (currVoltage, wireResistance, stepWireResistance, mainWireStep, totalMeters, stepLedCount)
            
            //Calc_WS2812b_step_vdrop(0, 5, 0.06679,  0.1, 5); //(meterOffset, currVoltage, mainWireResistance, mainWireStep, totalMeters)
            PlotHelpers.Xaxis.MajorStep = 1.0f;
            PlotHelpers.Xaxis.MinorStep = 0.5f;
            PlotHelpers.Yaxis.MajorStep = 0.1f;
            PlotHelpers.Yaxis.MinorStep = 0.05f;
            PlotHelpers.Yaxis.Minimum   = 3.6f;
            PlotHelpers.Yaxis.Maximum   = 5.05f;
            
            RootClass.form.ShowPlot();

            //TempSensor.Main();
            OtherCalcs.Main();

            //PrintDecTobin(Tables.charBitMap);
        }
        
        private static void Calc_WS2812b_vdrop(double currVoltage, double mainWireResistance, double stepWireResistance, double mainWireStep, int totalMeters, int stepLedCount)
        {
            int totalSteps     = (int)((double)totalMeters / mainWireStep);
            int mainStepIndex  = totalSteps;
            double current     = (double)stepLedCount * 0.06f * mainStepIndex;
            mainWireResistance = (mainWireResistance*2);
            
            Log.Add("\n@ wireResistances: main=");
            Log.AddDblRnd(mainWireResistance, 4);
            Log.Add(" ohm, step=");
            Log.AddDblRnd(stepWireResistance, 4);
            Log.AddLine("ohm");
            Log.AddLine("mainWireSteps=" + mainWireStep + ", totalMeters=" + totalMeters + ", stepLedCount=" + stepLedCount);
            Log.Add("@ 0.0m, ");
            Log.AddDblRnd(currVoltage, 3);
            Log.Add("V              , current=");
            Log.AddDblRnd(current, 2);
            Log.AddLine("A");
            
            FunctionSeries fs        = new FunctionSeries();

            fs.StrokeThickness       = 1;
            fs.MarkerType            = MarkerType.Circle;
            fs.MarkerSize            = 8;
            fs.MarkerFill            = OxyColors.Transparent;
            fs.MarkerStroke          = OxyColors.Red;
            fs.MarkerStrokeThickness = 2;
            fs.LineStyle             = LineStyle.Solid;
            fs.Color                 = OxyColors.Red;
            
            PlotHelpers.AddToPlot(fs);
            
            
            double currMeter    = (totalSteps - mainStepIndex)*mainWireStep;
            double currVdrop    = 0.0f;
            double currPwrLoss  = 0.0f;
            double totalPwrLoss = 0.0f;
            
            fs.Points.Add(new DataPoint(currMeter, currVoltage));
            
            totalPwrLoss = Calc_WS2812b_step_vdrop(0, currVoltage, stepWireResistance, mainWireStep / stepLedCount, mainWireStep);
            
            mainStepIndex--;

            while(mainStepIndex > 0)
            {
                currMeter = (totalSteps - mainStepIndex)*mainWireStep;
                
                current   = (double)mainStepIndex * (0.06f * (double)stepLedCount);
                
                currVdrop   = mainWireResistance * mainWireStep * current;
                currPwrLoss = currVdrop * current;
                totalPwrLoss += currPwrLoss;
                currVoltage = currVoltage - currVdrop;
                Log.Add("@");
                if (currMeter < 10) Log.Add(" ");
                Log.AddDblRnd(currMeter, 1);
                Log.Add("m, "); Log.AddDblRnd(currVoltage, 3);
                Log.Add("V, delta="); Log.AddDblRnd(currVdrop, 3);
                Log.Add("V, current="); Log.AddDblRnd(current, 2);
                Log.AddLine("A");
                
                fs.Points.Add(new DataPoint(currMeter, currVoltage));
                
                totalPwrLoss += Calc_WS2812b_step_vdrop(currMeter, currVoltage, stepWireResistance, mainWireStep / stepLedCount, mainWireStep);
                
                mainStepIndex--;
            }
            

            Log.AddLine("\ntotal power loss:" + MathExt.DblRnd(totalPwrLoss, 2)); 
        }
        
        private static double Calc_WS2812b_step_vdrop(double meterOffset, double currVoltage, double mainWireResistance, double mainWireStep, double totalMeters)
        {
            FunctionSeries fs  = new FunctionSeries();

            fs.StrokeThickness = 3;
            fs.MarkerType      = MarkerType.Circle;
            fs.MarkerSize      = 4;
            fs.MarkerFill      = OxyColors.Green;
            //fs.MarkerStroke          = OxyColors.Red;
            //fs.MarkerStrokeThickness = 2;
            fs.Color           = OxyColors.Green;
            
            PlotHelpers.AddToPlot(fs);
            
            mainWireResistance = (mainWireResistance*2);

            int totalSteps    = (int)((double)totalMeters / mainWireStep);
            int mainStepIndex = totalSteps;
            
            double current = (double)mainStepIndex * 0.06f;
            
            double currMeter    = (totalSteps - mainStepIndex)*mainWireStep;
            
            fs.Points.Add(new DataPoint(meterOffset + currMeter , currVoltage));
            mainStepIndex--;
            
            double currVdrop    = 0.0f;
            double currPwrLoss  = 0.0f;
            double totalPwrLoss = 0.0f;
            
            while(mainStepIndex > 0)
            {
                currMeter    = (totalSteps - mainStepIndex)*mainWireStep;
                
                current = (double)mainStepIndex * 0.06f;
                
                currVdrop   = mainWireResistance * mainWireStep * current;
                currPwrLoss = currVdrop * current;
                totalPwrLoss += currPwrLoss;
                currVoltage = currVoltage - currVdrop;
                
                /*
                if (mainStepIndex < 10) Log.Add(" ");
                Log.AddDblRnd(meterOffset + currMeter, 1);
                Log.Add("m, ");

                Log.AddDblRnd(currVoltage, 3);
                Log.Add("V, drop="); Log.AddDblRnd(currVdrop, 3);
                Log.AddLine("V");
                */
                fs.Points.Add(new DataPoint(meterOffset + currMeter, currVoltage));

                
                mainStepIndex--;
            }
            return totalPwrLoss;
        }
        
        public static void PrintDecTobin(int[] decArray)
        {
            //ClearLog();
            //string[] binStr = new string[decArray.Length];
            
            //for (int i = 0; i < decArray.Length; i++)
            //    binStr[i] = Convert.ToString(decArray[i], 2).PadLeft(8, '0'));
            
            Form f        = new Form();
            PictureBox pb = new PictureBox();
            pb.Image      = GetMonocromeBitmap(decArray, 64, -1);
            pb.SizeMode   = PictureBoxSizeMode.Zoom;
            pb.Dock       = DockStyle.Fill;
            f.Controls.Add(pb);
            f.Show();
        }
        
        public static Bitmap GetMonocromeBitmap(int[] DATA, int width, int height)
        {
            if (height == -1)
                height = (DATA.Length*8)/width;
            
            Bitmap bm = new Bitmap(width, height);// System.Drawing.PixelFormat.Format1bppIndexed);
            
            //var b            = new Bitmap(width, height, PixelFormat.Format8bppIndexed);
            //ColorPalette ncp = b.Palette;
            //for (int i = 0; i < 256; i++)
            //    ncp.Entries[i] = Color.FromArgb(255, i, i, i);
            //b.Palette = ncp;
            
            int currentByteIndex = 0;
            string currentByte   = "";
            int bitIndex         = 8;
            
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (bitIndex == 8)
                    {
                        bitIndex    = 0;
                        currentByte = Convert.ToString(DATA[currentByteIndex++], 2).PadLeft(8, '0');
                    }
                    
                    if (currentByte[bitIndex] == '1')
                        bm.SetPixel(x,y,Color.White);
                    else
                        bm.SetPixel(x,y,Color.Black);
                    
                    //int Value = DATA[x + (y * width)];
                    //Color C = ncp.Entries[Value];
                    
                    bitIndex++;
                }
            }
            return bm;
        }

        private static void InitWebServer()
        {
            server = new WebServer("htdocs", "http://192.168.10.100:80/");
            server.Run();
            
            System.Windows.Forms.ToolStrip ts = Get_RichTextLogger_ToolStrip();
            System.Windows.Forms.ToolStripButton tsBtn;

            tsBtn = Get_ToolStripButton(ts, "Close", false);
            tsBtn.Click += CloseWebServer;
            
        }
        
        private static void CloseWebServer(object s , EventArgs ea)
        {
            server.Stop();
        }
        
        public static void RemoveLogFormUserButtons()
        {
            Get_RichTextLogger_ToolStrip().Items.Clear();
        }

        public static ToolStrip Get_RichTextLogger_ToolStrip()
        {
            ToolStrip ts = null;
            for (int i = 0; i < rtxtForm.Controls.Count; i++)
            {
                if (rtxtForm.Controls[i].GetType() == typeof(System.Windows.Forms.ToolStrip))
                {    
                    return (System.Windows.Forms.ToolStrip)rtxtForm.Controls[i];
                }
            }
            ts      = new ToolStrip();
            ts.Dock = System.Windows.Forms.DockStyle.Top;
            rtxtForm.Controls.Add(ts);
            return ts;
        }
        
        public static RichTextBoxForm Get_RichTextBoxForm(string text)
        {
            for (int i = 0; i < forms.Count; i++)
            {
                if (forms[i].Text == text)
                {
                    return (RichTextBoxForm)forms[i];
                } 
            }
            RichTextBoxForm new_rtxtForm = new RichTextBoxForm();
            new_rtxtForm.Text            = text;
            forms.Add(new_rtxtForm);
            return new_rtxtForm;
        }
        public static InputForm Get_InputForm(string text)
        {
            for (int i = 0; i < forms.Count; i++)
            {
                if (forms[i].Text == text)
                {
                    return (InputForm)forms[i];
                } 
            }
            InputForm new_inForm = new InputForm();
            new_inForm.Text      = text;
            forms.Add(new_inForm);
            return new_inForm;
        }
        public static ToolStripButton Get_ToolStripButton(ToolStrip ts, string text, bool deletePrevious)
        {
            for (int i = ts.Items.Count - 1; i >= 0; i--)
            {
                if (ts.Items[i].Text == text)
                {
                    if (deletePrevious)
                        ts.Items.RemoveAt(i);
                    else
                        return (ToolStripButton)ts.Items[i];
                } 
            }
            ToolStripButton new_tsBtn = new ToolStripButton();
            new_tsBtn.Text            = text;
            ts.Items.Add(new_tsBtn);
            return new_tsBtn;
        }
        private static void GetPreviousForms()
        {
            if (RootClass.form.Tag != null)
            {
                if (RootClass.form.Tag.GetType() == typeof(List<Form>))
                {
                    forms = (List<Form>)RootClass.form.Tag;
                }
                else
                {
                    forms              = new List<Form>();
                    RootClass.form.Tag = forms;
                }
            }
            else
            {
                forms              = new List<Form>();
                RootClass.form.Tag = forms;
            }
        }

        public static void form_Closing_Cancel(object s, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            ((Form)s).Visible = false;
        }

        private static void Init_RuntimeLogForm()
        {
            rtxtForm = Get_RichTextBoxForm("Runtime Output");

            rtxtForm.Width            = 512;
            rtxtForm.Height           = 512;
            rtxtForm.Show();
            
            Log.rtxtLogCtrl = rtxtForm.rtxtLogCtrl;
        }
    }
}