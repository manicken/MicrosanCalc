using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.WindowsForms;

namespace Microsan
{
    
    public partial class PlotForm : Form
    {
        public PlotModel plot;
        public OxyPlot.Axes.Axis axisX;
        public OxyPlot.Axes.Axis axisY;

        public PlotForm()
        {
            InitializeComponent();

            plot = new OxyPlot.PlotModel();
            
            //FunctionSeries fs = new FuntionSeries();

            
           this.plotView.Model = plot;
        }

        public void SetupAxis(OxyPlotAxisType type, OxyPlotAxis axis)
        {
            OxyPlot.Axes.Axis newAxis = null;

            if (type == OxyPlotAxisType.Angle)
            {
                newAxis = new OxyPlot.Axes.AngleAxis();
            }
            else if (type == OxyPlotAxisType.Linear)
            {
                newAxis = new OxyPlot.Axes.LinearAxis();
            }
            else if (type == OxyPlotAxisType.Logarithmic)
            {
                newAxis = new OxyPlot.Axes.LogarithmicAxis();
            }
            else
                return;
            

            if (axis == OxyPlotAxis.X)
                this.axisX = newAxis;
            else if (axis == OxyPlotAxis.Y)
                this.axisY = newAxis;
            
            

            plot.Axes.Clear();
            plot.Axes.Add(axisX);
            plot.Axes.Add(axisY);
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
    public enum OxyPlotAxisType
    {
        Angle,
        Linear,
        Logarithmic,
    }
    public enum OxyPlotAxis
    {
        X,
        Y
    }

}

