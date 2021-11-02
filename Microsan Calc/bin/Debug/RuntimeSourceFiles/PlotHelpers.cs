using System;
using System.Text;
using Microsan;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
using System.Drawing;
using System.Windows.Forms;

namespace MyNamespace
{
    public static class PlotHelpers
    {
        public static PlotModel plot;
        public static PlotModel emptyPlot;
        public static PlotView plotView;
        public static FunctionSeries fsGlobal;
        public static int fsGlobalIndex=0;
        public static OxyPlot.Axes.LinearAxis Yaxis;
        public static OxyPlot.Axes.LinearAxis Yaxis2;
        public static OxyPlot.Axes.LinearAxis Xaxis;
        
        public static void Plot_SimpleFunction(int xMin, int xMax, int stepSize, MarkerType mt, LineStyle ls, Func<int, double> func, params string[] main_Xaxis_Yaxis_titles)
        {
            if (stepSize == 0) stepSize = 1;
            Setup_LinearPlot(main_Xaxis_Yaxis_titles);
            
            FunctionSeries fs = new FunctionSeries();
            
            fs.MarkerType = mt;
            fs.LineStyle  = ls;
            
            for (int i = xMin; i <= xMax; i+=stepSize)
            {
                fs.Points.Add(new DataPoint(i, func(i)));
            }
            AddToPlot(fs);
            
        }
        
        public static void Plot_SimpleFunction(double xMin, double xMax, double stepSize, MarkerType mt, LineStyle ls, Func<double, double> func, params string[] main_Xaxis_Yaxis_titles)
        {
            if (stepSize == 0.0f) stepSize = 1.0f;
            Setup_LinearPlot(main_Xaxis_Yaxis_titles);
            
            FunctionSeries fs = new FunctionSeries();
            
            fs.MarkerType = mt;
            fs.LineStyle  = ls;
            
            for (double i = xMin; i <= xMax; i+=stepSize)
            {
                fs.Points.Add(new DataPoint(i, func(i)));
            }
            AddToPlot(fs);
            
        }
        
        public static void Setup_LinearPlot(params string[] main_Xaxis_Yaxis_titles)//, string xAxisTitle, string yAxisTitle)
        {
            string mainTitle = "", xAxisTitle = "X", yAxisTitle = "Y";
            
            if (main_Xaxis_Yaxis_titles.Length == 0) { mainTitle = "Simple Function Plot"; }
            else if (main_Xaxis_Yaxis_titles.Length == 1)
            {
                mainTitle = main_Xaxis_Yaxis_titles[0];
            }
            else if (main_Xaxis_Yaxis_titles.Length == 2)
            {
                mainTitle = main_Xaxis_Yaxis_titles[0];
                xAxisTitle += " (" + main_Xaxis_Yaxis_titles[1] + ")";
            }
            else if (main_Xaxis_Yaxis_titles.Length >= 3)
            {
                mainTitle  = main_Xaxis_Yaxis_titles[0]; 
                xAxisTitle += " (" + main_Xaxis_Yaxis_titles[1] + ")";
                yAxisTitle += " (" + main_Xaxis_Yaxis_titles[2] + ")";
            }
            
            
            plot                   = new PlotModel { Title = mainTitle };
            plot.LegendPosition    = LegendPosition.RightBottom;
            plot.LegendPlacement   = LegendPlacement.Outside;
            plot.LegendOrientation = LegendOrientation.Horizontal;

            
            Yaxis = new OxyPlot.Axes.LinearAxis
            {
                Title = yAxisTitle,
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.Dot
            };
            
            Xaxis = new OxyPlot.Axes.LinearAxis
            {
                Title = xAxisTitle,
                Position    = OxyPlot.Axes.AxisPosition.Bottom, 
                //Minimum = start,
                //Maximum = end,
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.Dot
            };

            plot.Axes.Add(Yaxis);
            plot.Axes.Add(Xaxis);
            
        }
        public static void Setup_LinearPlot(string mainTitle, string xAxisTitle, string yAxisTitle, string yAxis2Title)
        {
            plot                   = new PlotModel { Title = mainTitle };
            plot.LegendPosition    = LegendPosition.RightBottom;
            plot.LegendPlacement   = LegendPlacement.Outside;
            plot.LegendOrientation = LegendOrientation.Horizontal;

            
            Yaxis = new OxyPlot.Axes.LinearAxis
            {
                Title = yAxisTitle,
                Key = "Y1",
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.Dash,
                //MinorGridlineColor = OxyPlot.OxyColor.FromRgb(255, 165, 0), // Orange
                //MajorGridlineColor = OxyPlot.OxyColor.FromRgb(255, 140, 0), // DarkOrange
                //MinorStep = 1f,
                Position = OxyPlot.Axes.AxisPosition.Left
            };
            
            Yaxis2 = new OxyPlot.Axes.LinearAxis
            {
                Title = yAxis2Title,
                Key = "Y2",
                MajorGridlineStyle = LineStyle.None,
                MinorGridlineStyle = LineStyle.None,
                //MinorGridlineColor = OxyPlot.OxyColor.FromRgb(0, 100, 0), // Green
                //MajorGridlineColor = OxyPlot.OxyColor.FromRgb(0, 140, 0), // DarkGreen
                MajorStep = 0.1f,
                MinorStep = 0.1f,
                MajorGridlineThickness = 1.0f,
                Position = OxyPlot.Axes.AxisPosition.Right
            };
            
            Xaxis = new OxyPlot.Axes.LinearAxis
            {
                Title = xAxisTitle,
                Position    = OxyPlot.Axes.AxisPosition.Bottom, 
                //Minimum = start,
                //Maximum = end,
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.Dot
            };

            plot.Axes.Add(Yaxis);
            plot.Axes.Add(Xaxis);
            plot.Axes.Add(Yaxis2);
        }
        
        public static void ClearPlot()
        {
            plot.Series.Clear();
        }
        
        public static void AddToPlot(FunctionSeries fs)
        {
            plot.Series.Add(fs);
            
            //plotView.Model = emptyPlot;
            if (plotView == null)
                Log.AddLine("plotView == null");
            else
                plotView.Model = plot;
        }
    }
}