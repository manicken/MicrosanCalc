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
    public class MathExt
    {
        public static double PowTo2(double x)
        {
            return Math.Pow(x, 2.0f);
        }
        
        public static double PytGetKat(double hyp, double kat)
        {
            return Math.Sqrt(PowTo2(hyp)-PowTo2(kat));
        }
        
        public static double PytGetHyp(double kat1, double kat2)
        {
            return Math.Sqrt(PowTo2(kat1)+PowTo2(kat2));
        }
        
        // parenthesis
        public static string Phss(double text)
        {
            return " (" + text + ")";
        }
        public static int[] DoubleFactorial = new int[]
        { //0,1,2,3,4, 5, 6,  7,  8,  9,  10,   11,   12,    13,   14
            1,1,2,3,8,15,48,105,384,945,3840,10395,46080,135135,645120
        };
        
        public static double Asin_aprox(double z)
        {
            int nMax   = 7;
            double res = z;
            double t   = 0.0f;
            for (int n = 1; n < nMax; n++)
            {
                t = DoubleFactorial[2*n-1]/DoubleFactorial[2*n];
                t *= Math.Pow(z, 2*n+1)/(2*n+1);
               res += t; 
            }
           return res;
        }
        
        public static double AcosAsDeg(double adj, double hyp)
        {
            double opp = PytGetKat(hyp, adj);
            //return ToDegree(Asin_aprox(opp/hyp));
            return ToDegree(Math.Asin(opp/hyp));
        }
        
        public static double ToDegree(double radianDegree)
        {
            return (radianDegree * 180.0f) / Math.PI;
        }
        
        public static string DblRnd(double val, int decimals)
        {
            return String.Format("{0:0." + GetZeroes(decimals) + "}", val).Replace(',','.');
        }
        
        public static string GetZeroes(int count)
        {
            StringBuilder sb = new StringBuilder();
            while (count > 0)
            {
                sb.Append("0");
                count--;
            }
            return sb.ToString();
        }

        
        public static string GetRawBytes(uint val)
        {
            return "{" + string.Join(", ", BitConverter.GetBytes(val)) + "}";
        }
    }
}