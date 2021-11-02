using System;
using System.Text;
using System.Windows.Forms;
using Microsan;

//using OxyPlot;
//using OxyPlot.Series;
//using OxyPlot.WindowsForms;
//using System.Collections.Generic;
//using System.Drawing;
//using System.IO.Ports;

namespace MyNamespace
{ 
    public class Log
    {
        public static RichTextBoxLoggerControl rtxtLogCtrl;
        
        public static void Add(string msg)
        {
            rtxtLogCtrl.AppendText(msg); // invoke is inside
        }
        
        public static void AddLine(string msg)
        {
            rtxtLogCtrl.AppendTextLine(msg); // invoke is inside
        }
        
        public static void AddDblRnd(double val, int decimals)
        {
            rtxtLogCtrl.AppendText(MathExt.DblRnd(val, decimals));  // invoke is inside
        }
        
        public static void AddLines(params string[] msg)
        {
            for (int i = 0; i < msg.Length; i++)
                rtxtLogCtrl.AppendTextLine(msg[i]); // invoke is inside
        }
        
        public static void AddLine()
        {
            rtxtLogCtrl.AppendTextLine(); // invoke is inside
        }
        
        public static void Clear()
        {
            rtxtLogCtrl.Clear(); // invoke is inside
        }
    }
}