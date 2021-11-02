using System;
using System.Text;
using System.Windows.Forms;
using Microsan;

using OxyPlot;
using OxyPlot.Series;
//using OxyPlot.WindowsForms;
//using System.Collections.Generic;
//using System.Drawing;
using System.IO.Ports;

namespace MyNamespace
{ 
    public class SerialPortExt
    {
        public static SerialPort uart;
        
        public static void DataReceivedHandler(object s, SerialDataReceivedEventArgs e)
        {
            string indata = uart.ReadLine();
            int indexOf   = indata.IndexOf("O:");
            if (indexOf != -1)
            {
                double dval = 0.0f;
                string ss   = indata.Substring(indexOf+2).Replace('.', ',');
                if (double.TryParse(ss, out dval))
                {
                    Log.AddLine(dval.ToString());
                    lock (PlotHelpers.plot.SyncRoot)
                    {
                        PlotHelpers.fsGlobal.Points.Add(new DataPoint(PlotHelpers.fsGlobalIndex++, dval));
                    }
                    PlotHelpers.plot.InvalidatePlot(true);
                    try{
                    //if autopan is on and actually neccessary
                    if ((PlotHelpers.fsGlobalIndex > PlotHelpers.plot.Axes[1].Maximum))
                    {
                        //the pan is the actual max position of the observed Axis minus the maximum data position times the scaling factor
                        var xPan = (PlotHelpers.plot.Axes[1].ActualMaximum - PlotHelpers.plot.Axes[1].DataMaximum) * PlotHelpers.plot.Axes[1].Scale;
                        PlotHelpers.plot.Axes[1].Pan(xPan);
                    }  
                    }
                    catch(Exception ex)
                    {
                        Log.AddLine(ex.ToString());
                    }
                }
                else
                    Log.AddLine(ss + "parse error");
            }
            else
                Log.AddLine(indata);
        }
        
        public static void btnOpenClose_Click(object s , EventArgs ea)
        {
            System.Windows.Forms.ToolStripButton b = (System.Windows.Forms.ToolStripButton)s;
            try {
            if (b.Text == "Open")
                uart.Open();
            else if (b.Text == "Close")
                uart.Close();
            }
            catch (Exception ex)
            {
                Log.AddLine(ex.ToString());
            }
            
        }
        
        public static void Init()
        {
            Get_SerialPort();
            uart.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
            
            InputForm inForm;
            
            inForm = RootClass.Get_InputForm("Serial Port Send1");
            inForm.Closing += RootClass.form_Closing_Cancel;
            inForm.DoVerifyInput = UartSendDataForm;
            inForm.Show();
            
            inForm = RootClass.Get_InputForm("Serial Port Send2");
            inForm.Closing += RootClass.form_Closing_Cancel;
            inForm.DoVerifyInput = UartSendDataForm;
            inForm.Show();
            
            inForm = RootClass.Get_InputForm("Serial Port Send3");
            inForm.Closing += RootClass.form_Closing_Cancel;
            inForm.DoVerifyInput = UartSendDataForm;
            inForm.Show();
            
            System.Windows.Forms.ToolStrip ts = RootClass.Get_RichTextLogger_ToolStrip();
            System.Windows.Forms.ToolStripButton tsBtn;

            tsBtn = RootClass.Get_ToolStripButton(ts, "Open", false);
            tsBtn.Click += btnOpenClose_Click;
            tsBtn = RootClass.Get_ToolStripButton(ts, "Close", false);
            tsBtn.Click += btnOpenClose_Click;
                    
            try{
                RootClass.form.ShowPlot();
            PlotHelpers.Setup_LinearPlot("temp", "temp", "temp");
            PlotHelpers.plot.Axes[1].Maximum = 40;
            PlotHelpers.fsGlobal      = new FunctionSeries();
            PlotHelpers.fsGlobalIndex = 0;
            PlotHelpers.AddToPlot(PlotHelpers.fsGlobal);
            
            }
            catch(Exception ex)
            {
                Log.AddLine(ex.ToString()); 
            }
        }

        public static void Get_SerialPort()
        {
            if (RootClass.rtxtForm.Tag != null)
            {
                if (RootClass.rtxtForm.Tag.GetType() == typeof(System.IO.Ports.SerialPort))
                {
                    uart = (SerialPort)RootClass.rtxtForm.Tag;
                    Log.AddLine("found exiting uart");
                    return;
                }
            }
            uart         = new SerialPort("COM21", 9600);
            RootClass.rtxtForm.Tag = uart;
        }
        
        public static bool UartSendDataForm(string data)
        {
            if (uart.IsOpen)
            {
                Log.AddLine("data sent >>>" + data + "<<<");
                uart.WriteLine(data);
            }
            else
            {
                Log.AddLine("Data not sent (port not open)");
            }
            return true;
        }
        
    }
}