using System;
using System.Text;
using System.Windows.Forms;
using Microsan;

using OxyPlot;
using OxyPlot.Series;
//using OxyPlot.WindowsForms;
//using System.Collections.Generic;
//using System.Drawing;
//using System.IO.Ports;

namespace MyNamespace
{ 
    public class TempSensor
    {
        
        public static void Main()
        {
            RootClass.form.ShowPlot();
            
            //Plot_NTC_10k_3950();
            /*
            Print_NTC_temp_steinhart(12400);
            Print_NTC_temp_steinhart(12700);
            Print_NTC_difftemp_steinhart(12700, 12400);
            Log.AddLine();
            Print_NTC_temp_steinhart(12520);
            Print_NTC_temp_steinhart(12790);
            Print_NTC_difftemp_steinhart(12790, 12520);
            
            Log.AddLine();
            Print_NTC_temp_steinhart(277200,-40f); 
            Print_NTC_temp_steinhart(157200,-30f);
            Print_NTC_temp_steinhart(87430,-20f);
            Print_NTC_temp_steinhart(81820,-10f);
            Print_NTC_temp_steinhart(31770,0f);
            Print_NTC_temp_steinhart(19680,10f);
            Print_NTC_temp_steinhart(12470,20f);
            Print_NTC_temp_steinhart(62,200f);
            */
            //Plot_NTC_10k_3950();
            
            //Calc_MLX90614_Tset();
            
            //Plot_NTC575();
            //Plot_LG_Ni1000();
        }
        
        public static void Print_NTC_difftemp_steinhart(double resistance1, double resistance2)
        {
            double deltaT = Calc_NTC_Temp_steinhart(resistance1)-Calc_NTC_Temp_steinhart(resistance2);
            double deltaR = resistance1 - resistance2;
            Log.AddLine("deltaTemp " + deltaT + " @ delta " + deltaR + " ohm");
        }
        public static void Print_NTC_temp_steinhart(double resistance, double tableTemp)
        {
            Log.AddLine("Temp " + Calc_NTC_Temp_steinhart(resistance) + " @ " + resistance + " ohm, tableTemp=" + tableTemp);
        }
        public static void Print_NTC_temp_steinhart(double resistance)
        {
            Log.AddLine("Temp " + Calc_NTC_Temp_steinhart(resistance) + " @ " + resistance + " ohm");
        }
        
        public static double Calc_NTC_Temp_steinhart(double resistance)
        {
            return 1/(1/298.15f + Math.Log(resistance/10000)/3950) - 273.15f;
        }
        
        public static void Calc_MLX90614_Tset()
        {
            //double IIRset = 10.0f; // 50%
            double IIRset = 1.0f; // 100%
            
            //double FIRset = 5.184f;
            double FIRset = 1.34f;
            //double DualSens   = 1;
            
            double Tset = 9.719;
            Tset += (IIRset * (FIRset + 5.26));
            Tset += (IIRset * (FIRset + 12.542));
            //Tset += (DualSens * IIRset * (FIRset + 12.542));
        
            Log.AddLine("MLX Tset=" + Tset + "mS");
        }

        public static double NTC_10k_3950_calc(double resistance)
        {
            double r25    = 10000f;
            double kelvin = 273.15f;
            double t25    = kelvin + 25f;
            double beta   = 3950f;
            double temp   = 1f/(Math.Log(resistance/r25)/beta+1f/t25)-kelvin;
            return temp;
        }
        
        public static void Plot_NTC_10k_3950_steinhart()
        {
            Log.AddLine("temp = " + NTC_10k_3950_calc(6300));
            Log.AddLine("temp = " + NTC_10k_3950_calc(13600));
            Log.AddLine("temp = " + NTC_10k_3950_calc(13860));
            
            PlotHelpers.Setup_LinearPlot("NTC_10k_3950", "resistance", "temp");
            
            FunctionSeries fs = new FunctionSeries();
            for (int i = 5000; i < 25000; i+=100)
            {
                fs.Points.Add(new DataPoint(i, NTC_10k_3950_calc(i)));
            }
            
            PlotHelpers.AddToPlot(fs);
            RootClass.form.ShowPlot();
        }
        
        public static void Plot_NTC575()
        {
            PlotHelpers.Setup_LinearPlot("NTC 575", "temp", "Vin", "ohm diff");
            
            FunctionSeries fsNTC575_ohm  = new FunctionSeries();
            FunctionSeries fsNTC575_diff = new FunctionSeries();
            //fsNTC575_ohm.Title           = "temp vs. resistance";
            //fsNTC575_diff.Title          = "resistance diff between temps";
            fsNTC575_ohm.Selectable     = true;
            fsNTC575_diff.Selectable    = true;
            fsNTC575_ohm.SelectionMode  = OxyPlot.SelectionMode.All;
            fsNTC575_diff.SelectionMode = OxyPlot.SelectionMode.All;
            
            // MarkerTypes: 
            // None, Circle, Diamond, Square, Triangle
            // (non working) Cross, Custom, Plus, Star
            
            fsNTC575_ohm.MarkerType          = MarkerType.Circle;
            fsNTC575_ohm.LineStyle           = LineStyle.Solid;
            fsNTC575_ohm.BrokenLineStyle     = LineStyle.None;
            fsNTC575_ohm.BrokenLineThickness = 2.0f;
            fsNTC575_ohm.BrokenLineColor     = OxyColor.FromRgb(128, 128, 128);
            
            // LineStyles:
            // None, Automatic, Dot, Dash, LongDash, Solid,
            // DashDashDot, DashDashDotDot, DashDot, DashDotDot,
            // LongDashDot, LongDashDotDot
            
            
            fsNTC575_diff.MarkerType = MarkerType.Circle;
            fsNTC575_diff.LineStyle  = LineStyle.Dot;
            
            fsNTC575_ohm.YAxisKey       = "Y1";
            fsNTC575_diff.YAxisKey      = "Y2";
            
            int count      = Tables.NTC575.Length;
            bool transLine = true;
            for (int i = 0; i < count; i+=2)
            {
                double temp = Tables.NTC575[i];
                double ohm  = Tables.NTC575[i+1];
                if (i < (count - 2))
                {
                    double ohmDiff = ohm - Tables.NTC575[i+3];
                    fsNTC575_diff.Points.Add(new DataPoint(temp + 0.5f, ohmDiff));
                }
                double mA   = 5f;
                double volt = ohm * (mA/1000);
                
                
                if (volt > 3.0f)
                    volt -= 2.99f;
                else
                {
                    if (transLine)
                    {
                        fsNTC575_ohm.Points.Add(DataPoint.Undefined); // breaks the line
                        transLine = false;
                    }
                    volt -= 2.6f;
                }
                volt = 10*volt;
                fsNTC575_ohm.Points.Add(new DataPoint(temp, volt));
                //fsNTC575_ohm.Points.Add(new DataPoint(temp, ohm));
            }
            PlotHelpers.AddToPlot(fsNTC575_diff);
            PlotHelpers.AddToPlot(fsNTC575_ohm);
            PlotHelpers.Yaxis.Minimum = 0;
            PlotHelpers.Yaxis.Maximum = 4;
            //Yaxis.MajorStep  = 0.01f;
            //Yaxis.MinorStep  = 0.001f;
            PlotHelpers.Yaxis2.MajorStep = 0.1f;
        }
        
        public static void Plot_LG_Ni1000()
        {
            PlotHelpers.Setup_LinearPlot("LG-Ni1000", "temp", "resistance");
            
            FunctionSeries fsLG_Ni1000 = new FunctionSeries();
            for (int i = 0; i < Tables.LG_Ni1000.Length; i+=2)
            {
                fsLG_Ni1000.Points.Add(new DataPoint(Tables.LG_Ni1000[i], Tables.LG_Ni1000[i+1]));
            }
            
            PlotHelpers.AddToPlot(fsLG_Ni1000);
        }
        public static void Plot_NTC_10k_3950()
        {
            PlotHelpers.Setup_LinearPlot("NTC_10k_3950", "temp", "resistance");
            
            FunctionSeries fs = new FunctionSeries();
            for (int i = 2; i < Tables.NTC_10k_3950.Length; i+=2)
            {
                int val = Tables.NTC_10k_3950[i+1-2] - Tables.NTC_10k_3950[i+1];
                fs.Points.Add(new DataPoint(Tables.NTC_10k_3950[i], val));
            }
            
            PlotHelpers.AddToPlot(fs);
        }
    }
}