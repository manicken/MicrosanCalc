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
    public class OtherCalcs
    {
        public static void Main()
        {
            //RootClass.form.ShowPlot();
            
            Plot_ResistorParValues();
            
            //Plot_AngleAndDistanceVs_delta();
            //Plot_SimpleFunction(0, 10000, 1, MarkerType.None, LineStyle.Solid, UC3843_RsetVsVout, "UC3843 Rset vs Vout", "Rset" , "Vout");
            
            //Plot_SimpleFunction(0, 100000, 1, MarkerType.None, LineStyle.Solid, MT3608_RsetVsVout, "MT3608 Rset vs Vout", "Rset" , "Vout");
            
            //Log.AddLine("8266.ToString(\"X2\")=" + 8266.ToString("X2"));
            //Log.AddLine("Convert.ToInt32(\"8266\", 16)=" + Convert.ToInt32("8266", 16));
            //Stellar_Starway_Calc();
            //DragonStory_NormalPlayFoodHarvestDay();
            //DragonStory_FruitionDragonSelfEarnLevelUpTime();
            
            
            //FloorHeatingRealSpiral_Calc();
            //FloorHeatingExtRealSpiral_Calc();
            //Mp3_player_key_resistances();
            //capacitor_freq();
            //GeoDomeCalc();
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

        public static void Plot_AngleAndDistanceVs_delta()
        {
            PlotHelpers.Setup_LinearPlot("AngleAndDistanceVs_delta", "angle", "delta");
            
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
            PlotHelpers.AddToPlot(fs);
        }

        public static int ResistorPar_Constant = 0;
        public static void Plot_ResistorParValues()
        {
            int start,end;
            
            ResistorPar_Constant = 820;
            start    = 500;
            end      = start + 10000;
            
            //ResistorPar_Constant = 330;
           
            //start = 5330;
            //end   = start + 1000;
            
            //ResistorPar_Constant = 470;
            //start    = 1800;
            //end      = start + 500;

            //ResistorPar_Constant = 3300;
            //start    = 0;
            //end      = 10000;
            
            //ResistorPar_Constant = 628;
            //start = 127000;
            //end = 135000;
            
            PlotHelpers.Setup_LinearPlot("resistor par values" , "pot val", "ohm");
            
            FunctionSeries fs = new FunctionSeries();

            //using function pointer
            double incr = 1.0f;
            PlotHelpers.AddToPlot(new FunctionSeries(ResistorParWithConst, start, end, incr, "resulting resistance"));
        }
        
        public static double ResistorParWithConst(double varRes)
        {
            return (ResistorPar_Constant*varRes)/(ResistorPar_Constant+varRes);
        }
        
        public static void DragonStory_FruitionDragonSelfEarnLevelUpTime()
        {
            double totalTime = 0.0f;
            totalTime   += 125/4 + 250/4 + 625/11;
            totalTime   += 1500/13 + 3750/15 + 6250/16;
            totalTime  += 15000/17 + 35000/19 + 62500/20;
            totalTime  += 75000/21 + 105000/22 + 136500/23;
            totalTime  += 177450/24 + 267500/24;
            Log.AddLine("DragonStory_FruitionDragonSelfEarnLevelUpTime: " + totalTime);
        }
        
        public static void DragonStory_NormalPlayFoodHarvestDay()
        {
            int rushrooms            = 300; // @1h
            int diamondates          = 800; // @5h
            int awakeHours           = 16;
            int sleepHours           = 24-awakeHours;
            int farmCount            = 7;
            int awaketime_food       = rushrooms*awakeHours*farmCount;
            int sleeptime_food       = diamondates*(sleepHours/5)*farmCount;
            int normalFoodHarvestDay = awaketime_food + sleeptime_food;
            
            Log.AddLine("DragonStory_NormalPlayFoodHarvestDay: " + normalFoodHarvestDay);
        }
        public static void Stellar_Starway_Calc()
        {
            int totalFoodFromLevel_7 = 3750+7750+15000+30000+42000+54500;
            Log.AddLine("totalFoodFromLevel_7: " + totalFoodFromLevel_7);
            
        }

        public static void Mp3_player_key_resistances()
        {
            double R1   = 22.0f;
            double MULT = 1.0f;
            Log.AddLine("R2/(R1+R2):" + MULT*(200.0f/(R1+200.0f)));
            Log.AddLine("R2/(R1+R2):" + MULT*(100.0f/(R1+100.0f)));
            Log.AddLine("R2/(R1+R2):" + MULT*(50.0f/(R1+51.0f)));
            Log.AddLine("R2/(R1+R2):" + MULT*(33.0f/(R1+33.0f)));
            Log.AddLine("R2/(R1+R2):" + MULT*(24.0f/(R1+24.0f)));
            Log.AddLine("R2/(R1+R2):" + MULT*(15.0f/(R1+15.0f)));
            Log.AddLine("R2/(R1+R2):" + MULT*(9.1f/(R1+9.1f)));
            Log.AddLine("R2/(R1+R2):" + MULT*(6.2f/(R1+6.2f)));
            Log.AddLine("R2/(R1+R2):" + MULT*(3.0f/(R1+3.0f)));
        }
        
        public static void capacitor_freq()
        {
            double CuF = 10f;
            double C   = CuF / 1000000;
            double I   = 0.035f;
            double V   = 9.0f;
            double R   = V/I;
            double t   = R*C;
            Log.AddLine("t = RxC = " + t);
        }
        
        public static void FloorHeatingRealSpiral_Calc()
        {
            
            double PI     = 3.1415f;
            double lenght = 0.0f;
            lenght += (0.275*11*PI)/2;
            lenght += (0.275*9*PI);
            lenght += (0.275*7*PI);
            lenght += (0.275*5*PI);
            lenght += (0.275*3*PI);
            lenght += (0.275*1*PI);
            lenght += (2.25*10) + 2*4;
            Log.AddLine("total lenght:" + lenght);
        }
        public static void FloorHeatingExtRealSpiral_Calc()
        {
            
            double PI             = 3.1415f;
            double unit           = 0.275f;
            double langSidaGround = unit*7;
            double lenght         = 0.0f;
            lenght += ((unit*PI)/4)*22;
            lenght += langSidaGround;
            lenght += (langSidaGround+unit)*2;
            lenght += (langSidaGround+unit*3)*2;
            lenght += (langSidaGround+unit*5)*2;
            lenght += (langSidaGround+unit*7)*2;
            lenght += (langSidaGround+unit*9)*2;
            lenght += (langSidaGround+unit*10);
            lenght += (unit*2)*2;
            lenght += (unit*4)*2;
            lenght += (unit*6)*2;
            lenght += (unit*8)*2;
            lenght += (unit*10);
            Log.AddLine("total lenght ext:" + lenght);
        }
        public static void GeoDomeCalc()
        {
            Log.Clear();
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
            
            double heightAB = MathExt.PytGetKat(lenA, halfLenB);
            double heightBC = MathExt.PytGetKat(lenC, halfLenB);

            double angleBA = MathExt.AcosAsDeg(halfLenB, lenA);
            //int intAngleBA = Convert.ToInt32(angleBA);
            
            double angleAA = (90.0f - angleBA)*2.0f;
            //int intAngleAA = Convert.ToInt32(angleAA);
            
            double angleBC = MathExt.AcosAsDeg(halfLenB, lenC);
            //int intAngleBC = Convert.ToInt32(angleBC);
            
            double angleCC = (90.0f - angleBC)*2.0f;
            //int intAngleCC = Convert.ToInt32(angleCC);
            
            Log.AddLine("A/B height: " + heightAB);
            Log.AddLine("B/C height: " + heightBC);
            Log.AddLine();
            //Log.AddLine("A/B rel : " + angleBArad);
            Log.AddLine("A/B angle: " + angleBA);
            Log.AddLine("A/A angle: " + angleAA);
            Log.AddLine("B/C angle: " + angleBC);
            Log.AddLine("C/C angle: " + angleCC);
            Log.AddLine();
            Log.AddLine("A/B neg angle: " + (90.0f - angleBA));
            Log.AddLine("B/C neg angle: " + (90.0f - angleBC));
        }
    }
}