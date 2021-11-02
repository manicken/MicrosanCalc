using System;
using System.Text;
using Microsan;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
using System.Drawing;
using System.Windows.Forms;


namespace UserNamespace
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
    
    public class UserClass
    {
        private static MainForm form;
        private static PlotModel plot;
        private static PlotModel emptyPlot;
        private static PlotView plotView;
        private static OxyPlot.Axes.LinearAxis Yaxis;
        private static OxyPlot.Axes.LinearAxis Yaxis2;
        private static OxyPlot.Axes.LinearAxis XAxis;
        
        /// <summary>
        /// The main entry point for the runtime compile code.
        /// </summary>
        
        public static void UserMain(object rootObject)
        {
            UserClass.form = (MainForm)rootObject;
            
            plotView       = UserClass.form.plotForm.plotView;
            emptyPlot      = new PlotModel();
            
            GeoDomeCalc();
            
            //UserClass.form.ShowPlot();
            
            //UserClass.form.rtxtForm.rtxt.AppendText("Hello World");
  
            //PrintDecTobin(Tables.charBitMap);
            //Plot_ResistorParValues();
            //Plot_NTC575();
            //Plot_LG_Ni1000();
            //Plot_AngleAndDistanceVs_delta();
            //Plot_SimpleFunction(0, 10000, 1, MarkerType.None, LineStyle.Solid, UC3843_RsetVsVout, "UC3843 Rset vs Vout", "Rset" , "Vout");
            
            //Plot_SimpleFunction(0, 100000, 1, MarkerType.None, LineStyle.Solid, MT3608_RsetVsVout, "MT3608 Rset vs Vout", "Rset" , "Vout");
        }
        
        public static void GeoDomeCalc()
        {
            ClearLog();
            //double lenA = 0.87138f; // red
            //double lenB = 1.00888f; // blue
            //double lenC = 1.03093f; // green
            
            //double lenA = 0.871f; // red
            //double lenB = 1.008f; // blue
            //double lenC = 1.031f; // green
            
            double lenA = 0871f;//.38f; // red
            double lenB = 1008f;//.88f; // blue
            double lenC = 1030f;//.93f; // green
            
            double halfLenB = lenB/2.0f;
            
            //double angleBArad = halfLenB/lenA;
            
            double heightAB = PytGetKat(lenA, halfLenB);
            double heightBC = PytGetKat(lenC, halfLenB);

            double angleBA = AcosAsDeg(halfLenB, lenA);
            //int intAngleBA = Convert.ToInt32(angleBA);
            
            double angleAA = (90.0f - angleBA)*2.0f;
            //int intAngleAA = Convert.ToInt32(angleAA);
            
            double angleBC = AcosAsDeg(halfLenB, lenC);
            //int intAngleBC = Convert.ToInt32(angleBC);
            
            double angleCC = (90.0f - angleBC)*2.0f;
            //int intAngleCC = Convert.ToInt32(angleCC);
            
            AddLineToLog("A/B height: " + heightAB);
            AddLineToLog("B/C height: " + heightBC);
            AddLineToLog();
            //AddLineToLog("A/B rel : " + angleBArad);
            AddLineToLog("A/B angle: " + angleBA);
            AddLineToLog("A/A angle: " + angleAA);
            AddLineToLog("B/C angle: " + angleBC);
            AddLineToLog("C/C angle: " + angleCC);
            AddLineToLog();
            AddLineToLog("A/B neg angle: " + (90.0f - angleBA));
            AddLineToLog("B/C neg angle: " + (90.0f - angleBC));
        }
        
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
        
        public static void PrintDecTobin(int[] decArray)
        {
            //ClearLog();
            //string[] binStr = new string[decArray.Length];
            
            //for (int i = 0; i < decArray.Length; i++)
            //    binStr[i] = Convert.ToString(decArray[i], 2).PadLeft(8, '0'));
            
            Form f        = new Form();
            PictureBox pb = new PictureBox();
            pb.Image      = GetMonocromeBitmap(decArray, 80, -1);
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
        
        public static double MT3608_RsetVsVout(int Rset)
        {
            return 0.6f * (1.0f + (double)Rset/(2200.0f+330));
        }
        
        public static double UC3843_RsetVsVout(int Rset)
        {
            Rset += 3300;
            
            return 2.5f * (1.0f + (double)Rset/(1000.0f));
        }
        
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
        
        public static void Plot_AngleAndDistanceVs_delta()
        {
            Setup_LinearPlot("AngleAndDistanceVs_delta", "angle", "delta");
            
            FunctionSeries fs = new FunctionSeries();
            
            fs.MarkerType = MarkerType.Circle;
            fs.LineStyle  = LineStyle.Solid;
            
            double asDegree        = (Math.PI/180);
            for (double i = 0; i < 45; i+=0.5f)
            {
                double calc = (Math.Tan((i+0.5f) * asDegree)*4) - (Math.Tan(i * asDegree)*4);
                
                fs.Points.Add(new DataPoint(i, calc));
                //if (i < 30.0f) i+=0.5f;
            }
            AddToPlot(fs);
        }
        
        public static void Plot_NTC575()
        {
            Setup_LinearPlot("NTC 575", "temp", "Vin", "ohm diff");
            
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
            AddToPlot(fsNTC575_diff);
            AddToPlot(fsNTC575_ohm);
            Yaxis.Minimum = 0;
            Yaxis.Maximum = 4;
            //Yaxis.MajorStep  = 0.01f;
            //Yaxis.MinorStep  = 0.001f;
            Yaxis2.MajorStep = 0.1f;
        }
        
        public static void Plot_LG_Ni1000()
        {
            Setup_LinearPlot("LG-Ni1000", "temp", "resistance");
            
            FunctionSeries fsLG_Ni1000 = new FunctionSeries();
            for (int i = 0; i < Tables.LG_Ni1000.Length; i+=2)
            {
                fsLG_Ni1000.Points.Add(new DataPoint(Tables.LG_Ni1000[i], Tables.LG_Ni1000[i+1]));
            }
            
            AddToPlot(fsLG_Ni1000);
        }
        
        
        public static void Plot_ResistorParValues()
        {
            int constant,start,end;
            
            constant = 820;
            start    = 500;
            end      = start + 10000;
            
            //constant = 330;
           
            //start = 5330;
            //end   = start + 1000;
            
            //constant = 470;
            //start    = 1800;
            //end      = start + 500;

            //constant = 3300;
            //start    = 0;
            //end      = 10000;
            
            //constant = 628;
            //start = 127000;
            //end = 135000;
            
            Setup_LinearPlot("resistor par values" , "pot val", "ohm");
            
            FunctionSeries fs = new FunctionSeries();
            
            double dec_constant = (double)constant;
            
            for (int x = start; x <= end; x++)
            {
                double xd   = (double)x;
                double dTmp = (dec_constant*xd)/(dec_constant+xd);
                
                fs.Points.Add(new DataPoint(x, (double)dTmp));
            }
            //AddToPlot(fs);
            // example using function pointer
            double incr = 1.0f;
            AddToPlot(new FunctionSeries(ResistorParWithConst, start, end, incr, "resulting resistance"));
        }
        
        public static double ResistorParWithConst(double varRes)
        {
            double constant = 1000;
            return (constant*varRes)/(constant+varRes);
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
            
            XAxis = new OxyPlot.Axes.LinearAxis
            {
                Title = xAxisTitle,
                Position    = OxyPlot.Axes.AxisPosition.Bottom, 
                //Minimum = start,
                //Maximum = end,
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.Dot
            };

            plot.Axes.Add(Yaxis);
            plot.Axes.Add(XAxis);
            
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
            
            XAxis = new OxyPlot.Axes.LinearAxis
            {
                Title = xAxisTitle,
                Position    = OxyPlot.Axes.AxisPosition.Bottom, 
                //Minimum = start,
                //Maximum = end,
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.Dot
            };

            plot.Axes.Add(Yaxis);
            plot.Axes.Add(XAxis);
            plot.Axes.Add(Yaxis2);
        }
        
        public static void AddToPlot(FunctionSeries fs)
        {
            plot.Series.Add(fs);
            
            //plotView.Model = emptyPlot;
            plotView.Model = plot;
        }

        public static void AddToLog(string msg)
        {
            UserClass.form.rtxtForm.rtxt.AppendText(msg);
        }
        
        public static void AddLineToLog(string msg)
        {
            UserClass.form.rtxtForm.rtxt.AppendText(msg + "\n");
        }
        
        public static void AddLineToLog()
        {
            UserClass.form.rtxtForm.rtxt.AppendText("\n");
        }
        
        public static void ClearLog()
        {
            UserClass.form.rtxtForm.rtxt.Clear();
        }
        public static string GetRawBytes(uint val)
        {
            return "{" + string.Join(", ", BitConverter.GetBytes(val)) + "}";
        }
    }
    public static class Tables
    {
        public static double[] NTC575 = 
        {
            -40, 675.1,
            -39, 674.6,
            -38, 674.1,
            -37, 673.5,
            -36, 672.8,
            -35, 672.1,
            -34, 671.4,
            -33, 670.6,
            -32, 669.8,
            -31, 669.0,
            -30, 668.1,
            -29, 667.2,
            -28, 666.3,
            -27, 665.3,
            -26, 664.3,
            -25, 663.2,
            -24, 662.1,
            -23, 661.0,
            -22, 659.8,
            -21, 658.6,
            -20, 657.3,
            -19, 656.0,
            -18, 654.7,
            -17, 653.3,
            -16, 651.9,
            -15, 650.4,
            -14, 648.9,
            -13, 647.3,
            -12, 645.7,
            -11, 644.1,
            -10, 642.4,
            -9, 640.7,
            -8, 638.9,
            -7, 637.1,
            -6, 635.2,
            -5, 633.3,
            -4, 631.4,
            -3, 629.4,
            -2, 627.4,
            -1, 625.3,
             0, 623.2,
             1, 621.1,
             2, 618.9,
             3, 616.7,
             4, 614.5,
             5, 612.2,
             6, 610.0,
             7, 607.7,
             8, 605.3,
             9, 603.0,
            10, 600.6,
            11, 598.2,
            12, 595.8,
            13, 593.3,
            14, 590.9,
            15, 588.4,
            16, 585.9,
            17, 583.5,
            18, 581.0,
            19, 578.5,
            20, 576.0,
            21, 573.5,
            22, 571.0,
            23, 568.5,
            24, 566.0,
            25, 563.5,
            26, 561.0,
            27, 558.6,
            28, 556.1,
            29, 553.6,
            30, 551.2,
            31, 548.8,
            32, 546.4,
            33, 544.0,
            34, 541.6,
            35, 539.3,
            36, 537.0,
            37, 534.7,
            38, 532.4,
            39, 530.1,
            40, 527.8
        };
        
        public static double[] LG_Ni1000 =
        {
             0, 1000.0,
             1, 1004.4,
             2, 1008.9,
             3, 1013.3,
             4, 1017.8,
             5, 1022.3,
             6, 1026.7,
             7, 1031.2,
             8, 1035.7,
             9, 1040.3,
             10, 1044.8,
             11, 1049.3,
             12, 1053.9,
             13, 1058.4,
             14, 1063.0,
             15, 1067.6,
             16, 1072.2,
             17, 1076.8,
             18, 1081.4,
             19, 1086.0,
             20, 1090.7,
             21, 1095.3,
             22, 1100.0,
             23, 1104.6,
             24, 1109.3,
             25, 1114.0,
             26, 1118.7,
             27, 1123.4,
             28, 1128.1,
             29, 1132.9,
             30, 1137.6,
             31, 1142.4,
             32, 1147.1,
             33, 1151.9,
             34, 1156.7,
             35, 1161.5,
             36, 1166.3,
             37, 1171.2,
             38, 1176.0,
             39, 1180.9,
             40, 1185.7,
             41, 1190.6,
             42, 1195.5,
             43, 1200.4,
             44, 1205.3,
             45, 1210.2,
             46, 1215.1,
             47, 1220.1,
             48, 1225.0,
             49, 1230.0,
             50, 1235.0,
             51, 1240.0,
             52, 1245.0,
             53, 1250.0,
             54, 1255.0,
             55, 1260.1,
             56, 1265.1,
             57, 1270.2,
             58, 1275.3,
             59, 1280.3,
             60, 1285.4,
             61, 1290.6,
             62, 1295.7,
             63, 1300.8,
             64, 1306.0,
             65, 1311.1,
             66, 1316.3,
             67, 1321.5,
             68, 1326.7,
             69, 1331.9,
             70, 1337.1,
             71, 1342.4,
             72, 1347.6,
             73, 1352.9,
             74, 1358.2,
             75, 1363.5,
             76, 1368.8,
             77, 1374.1,
             78, 1379.4,
             79, 1384.8,
             80, 1390.1,
             81, 1395.5,
             82, 1400.9,
             83, 1406.3,
             84, 1411.7,
             85, 1417.1,
             86, 1422.5,
             87, 1428.0,
             88, 1433.4,
             89, 1438.9,
             90, 1444.4,
             91, 1449.9,
             92, 1455.4,
             93, 1460.9,
             94, 1466.5,
             95, 1472.0,
             96, 1477.6,
             97, 1483.2,
             98, 1488.8,
             99, 1494.4,
             100, 1500.0
        }; 
        public static int[] charBitMap =
        {
            
0,0,0,0,0,0,0,0,255,148,0,0,0,0,0,0,0,
0,255,148,0,0,0,0,0,0,0,0,255,148,0,0,0,0,0,0,0,0,255,148,0,0,0,0,0,0,0,0,255,
148,0,0,0,0,0,0,0,0,255,148,0,0,0,0,0,0,0,0,255,148,0,0,0,0,0,0,0,0,255,148,0,
0,0,0,0,0,0,0,255,148,0,0,0,0,0,0,0,0,255,148,0,0,0,0,0,0,0,0,0,0,0,0,0,
0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,255,148,0,0,0,0,0,0,0,0,255,148,0,0,0,0,0,
0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
0,0,0,0,0,0,0,0,0,0,255,148,0,255,148,0,0,0,0,0,255,148,0,255,148,0,0,0,0,0,255,148,
0,255,148,0,0,0,0,0,255,148,0,255,148,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,108,255,
0,0,255,148,0,0,0,0,108,255,0,0,255,148,0,0,0,0,108,255,0,0,255,148,0,0,0,0,108,255,0,0,
255,148,0,0,0,255,255,255,255,148,255,255,255,0,0,255,255,255,255,148,255,255,255,0,0,0,108,255,0,0,255,148,
0,0,0,0,108,255,0,0,255,148,0,0,0,255,255,255,255,148,255,255,255,0,0,255,255,255,255,148,255,255,255,0,
0,0,108,255,0,0,255,148,0,0,0,0,108,255,0,0,255,148,0,0,0,0,108,255,0,0,255,148,0,0,0,0,
108,255,0,0,255,148,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,108,255,255,148,255,148,0,0,0,0,108,255,255,148,
255,148,0,0,0,0,108,255,0,0,255,148,0,0,0,0,108,255,0,0,255,148,0,0,0,0,108,255,0,0,255,148,
0,0,0,0,108,255,0,0,255,148,0,0,0,0,108,255,0,0,255,148,0,0,0,0,108,255,0,0,255,148,0,0,
0,0,108,255,0,0,255,148,0,0,0,0,108,255,0,0,255,148,0,0,0,0,108,255,0,0,255,148,0,0,0,0,
108,255,0,0,255,148,0,0,0,255,255,255,0,0,255,255,255,0,0,255,255,255,0,0,255,255,255,0,0,0,0,0,
0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
0,0,0,0,0,255,255,255,0,0,0,0,0,0,0,255,255,255,0,0,0,0,0,0,0,255,255,255,0,0,0,108,
        };
    }
}