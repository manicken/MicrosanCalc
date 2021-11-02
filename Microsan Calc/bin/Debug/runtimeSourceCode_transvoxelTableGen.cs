using System;
using System.Text;
using Microsan;
using OxyPlot;
    using OxyPlot.Series;

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
        
        public const int VolumeDataBits = 7;

        /// <summary>
        /// Used globally for checking the sign of a signed value
        /// <para>(should be changed if the voxelvolume datatype changes)</para>
        /// </summary>
        public const int SignMask = (1 << (VolumeDataBits-1));
        
        /// <summary>
        /// The main entry point for the runtime compile code.
        /// </summary>
        
        public static void UserFunction(MainForm form)
        {
            
            
            UserClass.form = form;
            
            ClearLog();
            
            
            
            //CalcCaseCodeTest();
            
            //form.ShowPlot();
            
            //form.plotForm.plot.Series.Add(new FunctionSeries(Math.Sin, -10, 10, 0.1, "sin(x)"));
            //form.plotForm.plot.Series.Add(new FunctionSeries(Math.Cos, -10, 10, 0.1, "cos(x)"));
            //form.plotForm.plot.Series.Add(new FunctionSeries(t => 5 * Math.Cos(t), t => 5 * Math.Sin(t), 0, 2 * Math.PI, 0.1, "cos(t),sin(t)"));
            
            CalcNewTcc();
            
            //char CharTestGet  = Tables.TestString[0];
            //char CharTestGet2 = Tables.TestString[2];
            
            //AddLineToLog(CharTestGet.ToString() + CharTestGet2.ToString());
            
            //byte dataFromTable = Tables.RegularCellClass[5];
            //AddLineToLog(dataFromTable.ToString());
            Vector3sb microsanTest_const1 = new Vector3sb(1,1,1);
            for (int i= 0; i < 18; i++)
            {
                Vector3sb microsanTest  = Vector3sb.Add(microsanTest_const1, Tables.TransitionFaceCoords3[i]);
                
                Vector3sb microsanTest2 = microsanTest_const1 + Tables.TransitionFaceCoords3[i];
                
                AddLineToLog("microsanTest: " + microsanTest.ToString() + " ; " + microsanTest2.ToString());
            }
        }
        
        public static void CalcCaseCodeTest()
        {
            sbyte[] cornerSamples = {  1, -2, 3, 4, 5, 6, 7, 8, 9 };
            
            uint txCC_1 = (uint)((cornerSamples[1] >> VolumeDataBits) & 0x01);
            
            uint transCaseCode = (uint)( 
            // note. when shifting the sign bit all the way
            // the result of the shift is either 0x00 (sign bit not set) or 0xFF (sign bit set)
            // so we can just use direct "and"-mask
            // but for the last bit we need to do it the "old" way.
            // (just to make sure that we can change the VolumeDataBits later)
              ((cornerSamples[0] >> VolumeDataBits) & 0x01) | 
              ((cornerSamples[1] >> VolumeDataBits) & 0x02) |
              ((cornerSamples[2] >> VolumeDataBits) & 0x04) |
              ((cornerSamples[5] >> VolumeDataBits) & 0x08) |
              ((cornerSamples[8] >> VolumeDataBits) & 0x10) |
              ((cornerSamples[7] >> VolumeDataBits) & 0x20) |
              ((cornerSamples[6] >> VolumeDataBits) & 0x40) |
              ((cornerSamples[3] >> VolumeDataBits) & 0x80) |
              (((cornerSamples[4] >> VolumeDataBits) & 0x01) * 0x100) );

              AddLineToLog(string.Format("transCaseCode: {0} {1}", transCaseCode, GetRawBytes(txCC_1)));
        }

          public static string GetRawBytes(uint val)
        {
            return "{" + string.Join(", ", BitConverter.GetBytes(val)) + "}";
        }
        
        public static void CalcCaseCode_LessThanZeroWay()
        {
            sbyte[] cornerSamples = {  1, -2, 3, 4, 5, 6, 7, 8, 9 };
            uint cc = 0;
            if (cornerSamples[0] < 0) cc |= 0x001;
            if (cornerSamples[1] < 0) cc |= 0x002;
            if (cornerSamples[2] < 0) cc |= 0x004;
            if (cornerSamples[3] < 0) cc |= 0x008;
            if (cornerSamples[4] < 0) cc |= 0x010;
            if (cornerSamples[5] < 0) cc |= 0x020;
            if (cornerSamples[6] < 0) cc |= 0x040;
            if (cornerSamples[7] < 0) cc |= 0x080;
            AddLineToLog(string.Format("CalcCaseCode_LessThanZeroWay: {0} {1}", cc, GetRawBytes(cc)));
        }
        
        public static void DoInDirectFunctionPointer()
        {
            //Func<int, int, int> areaOfRectangle = (int x, int y) => { return x * y;}; 
            //int bajs = areaOfRectangle(5,7);
            //AddToLog("bajs: "+ bajs);
            //AddToLog("baj2s: "+ bajs);
        }
        
        public static void AddToLog(string msg)
        {
            UserClass.form.rtxtLog.AppendText(msg);
        }
        
        public static void AddLineToLog(string msg)
        {
            UserClass.form.rtxtLog.AppendText(msg + "\n");
        }
        
        public static void ClearLog()
        {
            UserClass.form.rtxtLog.Clear();
        }
        
        static void SetElementAt(int[][][] array, int i, int j, int k, int value)
        {
            array[i][j][k] = value;
        }

        static void SetElementAt(int[,,] array, int i, int j, int k, int value)
        {
            array[i, j, k] = value;
        }
        
        //vector3.X = localX.X * tcc.X + localY.X * tcc.Y + localZ.X * tcc.Z
        //vector3.Y = localX.Y * tcc.X + localY.Y * tcc.Y + localZ.Y * tcc.Z
        //vector3.Y = localX.Z * tcc.X + localY.Z * tcc.Y + localZ.Z * tcc.Z
        public static void CalcNewTcc()
        {
            Vector3sb locX, locY, locZ;
            Vector3sb tcc, newTcc = new Vector3sb(0,0,0);
            
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("public static Vector3sb[,] TransitionDirCornerCoords = new Vector3sb[6, 13]");
            sb.AppendLine("{");
       
            
            for (int dirIndex = 0; dirIndex < 6; dirIndex++)
            {
                sb.Append("    { // dir ");
                sb.Append(dirIndex);
                sb.AppendLine();
                
                locX = Tables.TransitionFaceCoords[dirIndex, 0];
                locY = Tables.TransitionFaceCoords[dirIndex, 1];
                locZ = Tables.TransitionFaceCoords[dirIndex, 2];
                
                for (int tcci = 0; tcci < 13; tcci++)
                {
                    tcc = Tables.TransitionCornerCoords[tcci];
                    
                    newTcc.X = (sbyte)(locX.X * tcc.X + locY.X * tcc.Y + locZ.X * tcc.Z);
                    newTcc.Y = (sbyte)(locX.Y * tcc.X + locY.Y * tcc.Y + locZ.Y * tcc.Z);
                    newTcc.Z = (sbyte)(locX.Z * tcc.X + locY.Z * tcc.Y + locZ.Z * tcc.Z);
                    
                    
                    sb.Append("        new Vector3sb");
                    sb.Append(newTcc.ToString());
                    
                    if (tcci != 12)
                        sb.Append(",");
                    else
                        sb.Append(" ");
                    
                    sb.Append(" // tcc ");
                    sb.Append(tcci);
                    
                    sb.AppendLine();
                }
                
                if (dirIndex != 5)
                    sb.AppendLine("    },");
                else
                    sb.AppendLine("    }");
            }
            sb.AppendLine("};");
            AddToLog(sb.ToString());
        }
    }
    

    
    /// <summary>
    /// this uses a signed byte as storage element
    /// </summary>
    public struct Vector3sb
    {
        public int X;
        public int Y;
        public int Z;
        
        public Vector3sb(sbyte x, sbyte y, sbyte z)
        {
            X = (int)x;
            Y = (int)y;
            Z = (int)z;
        }
        public Vector3sb(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        
        public Vector3sb(UInt16 data)
        {
            if ((data & 0x0008) == 0x0008)
                X = (data & 0x0007) * -1;
            else
                X = (data & 0x0007);

            if ((data & 0x0080) == 0x0080)
                Y = ((data & 0x0070) >> 4) * -1;
            else
                Y = ((data & 0x0070) >> 4);

            if ((data & 0x0800) == 0x0800)
                Z = ((data & 0x0700) >> 8) * -1;
            else
                Z = ((data & 0x0700) >> 8);
            
        }
        public static Vector3sb operator +(Vector3sb v0, Vector3sb v1)
        {
            return new Vector3sb(v0.X + v1.X,
                                    v0.Y + v1.Y,
                                    v0.Z + v1.Z);
        }
                                
        /// <summary>
        /// Bla bla on operator plus with raw data stored in each nibble (.note th MSB nibble is unused)
        /// </summary>
        /// <param name="v0"></param>
        /// <param name="v1"></param>
        /// <returns></returns>
        public static Vector3sb operator +(Vector3sb v0, UInt16 v1)
        {
            int X,Y,Z;

            if ((v1 & 0x0008) == 0x0008)
                X = (v1 & 0x0007) * -1 + v0.X;
            else
                X = (v1 & 0x0007) + v0.X;

            if ((v1 & 0x0080) == 0x0080)
                Y = ((v1 & 0x0070) >> 4) * -1 + v0.Y;
            else
                Y = ((v1 & 0x0070) >> 4) + v0.Y;

            if ((v1 & 0x0800) == 0x0800)
                Z = ((v1 & 0x0700) >> 8) * -1 + v0.Z;
            else
                Z = ((v1 & 0x0700) >> 8) + v0.Z;
            
            v0.X *= 10;
            
            return new Vector3sb(X, Y, Z);
        }
        
        /// <summary>
        /// Bla bla on operator plus with raw data stored in each nibble (.note th MSB nibble is unused)
        /// </summary>
        /// <param name="v0"></param>
        /// <param name="v1"></param>
        /// <returns></returns>
        public static Vector3sb Add(ref Vector3sb v0, UInt16 v1)
        {
            int X,Y,Z;

            if ((v1 & 0x0008) == 0x0008)
                X = (v1 & 0x0007) * -1 + v0.X;
            else
                X = (v1 & 0x0007) + v0.X;

            if ((v1 & 0x0080) == 0x0080)
                Y = ((v1 & 0x0070) >> 4) * -1 + v0.Y;
            else
                Y = ((v1 & 0x0070) >> 4) + v0.Y;

            if ((v1 & 0x0800) == 0x0800)
                Z = ((v1 & 0x0700) >> 8) * -1 + v0.Z;
            else
                Z = ((v1 & 0x0700) >> 8) + v0.Z;
            
            //v0.X *= 10; // this actually modifies the Vector3sb field
            
            return new Vector3sb(X, Y, Z);
        }
        /// <summary>
        /// Bla bla on operator plus with raw data stored in each nibble (.note th MSB nibble is unused)
        /// </summary>
        /// <param name="v0"></param>
        /// <param name="v1"></param>
        /// <returns></returns>
        public static Vector3sb Add(Vector3sb v0, UInt16 v1)
        {
            int X,Y,Z;

            if ((v1 & 0x0008) == 0x0008)
                X = (v1 & 0x0007) * -1 + v0.X;
            else
                X = (v1 & 0x0007) + v0.X;

            if ((v1 & 0x0080) == 0x0080)
                Y = ((v1 & 0x0070) >> 4) * -1 + v0.Y;
            else
                Y = ((v1 & 0x0070) >> 4) + v0.Y;

            if ((v1 & 0x0800) == 0x0800)
                Z = ((v1 & 0x0700) >> 8) * -1 + v0.Z;
            else
                Z = ((v1 & 0x0700) >> 8) + v0.Z;
            
            
            
            return new Vector3sb(X, Y, Z);
        }
        
        public override String ToString()
        {
            return "(" + Xstring() + ", " + Ystring() + ", " + Zstring() + ")";
        }
        
        public string Xstring()
        {
            if (X >= 0)
                return " " + X;
            else
                return X.ToString();
        }
        public string Ystring()
        {
            if (Y >= 0)
                return " " + Y;
            else
                return Y.ToString();
        }
        public string Zstring()
        {
            if (Z >= 0)
                return " " + Z;
            else
                return Z.ToString();
        }
    }
    public static class Tables
    {
        public struct RegularCell
        {
            byte geometryCounts;        // High nibble is vertex count, low nibble is triangle count.
            byte[] vertexIndex;         // Groups of 3 indexes giving the triangulation.

            public RegularCell(byte gc, byte[] vi)
            {
                this.geometryCounts = gc;
                this.vertexIndex = vi;
            }

            public long GetVertexCount()
            {
                return (geometryCounts >> 4);
            }

            public long GetTriangleCount()
            {
                return (geometryCounts & 0x0F);
            }

            public byte[] Indizes()
            {
                return vertexIndex;
            }
        };
        public const string TestString = "Hello World";
        
        public static Vector3sb[] TransitionCornerCoords = new Vector3sb[] {
            new Vector3sb(0,0,0), new Vector3sb(1,0,0), new Vector3sb(2,0,0), // High-res lower row
            new Vector3sb(0,1,0), new Vector3sb(1,1,0), new Vector3sb(2,1,0), // High-res middle row
            new Vector3sb(0,2,0), new Vector3sb(1,2,0), new Vector3sb(2,2,0), // High-res upper row

            new Vector3sb(0,0,2), new Vector3sb(2,0,2), // Low-res lower row
            new Vector3sb(0,2,2), new Vector3sb(2,2,2)  // Low-res upper row
        };
        
        public static Vector3sb[][] TransitionFaceCoords2;
        public static UInt16[] TransitionFaceCoords3;
        
        static Tables()
        {
            TransitionFaceCoords2 = new Vector3sb[6][];
            TransitionFaceCoords2[0] = new Vector3sb[] {new Vector3sb(1, 0, 0), new Vector3sb(0, 1, 0), new Vector3sb(0, 0, 1)};
            TransitionFaceCoords2[1] = new Vector3sb[] {new Vector3sb(0, 0, -1),new Vector3sb(0, 1, 0), new Vector3sb(1, 0, 0)};
            TransitionFaceCoords2[2] = new Vector3sb[] {new Vector3sb(-1, 0, 0), new Vector3sb(0, 1, 0), new Vector3sb(0, 0, -1)};
            TransitionFaceCoords2[3] = new Vector3sb[] {new Vector3sb(0, 0, 1), new Vector3sb(0, 1, 0), new Vector3sb(-1, 0, 0)};
            TransitionFaceCoords2[4] = new Vector3sb[] {new Vector3sb(1, 0, 0), new Vector3sb(0, 0, 1), new Vector3sb(0, -1, 0)};
            TransitionFaceCoords2[5] = new Vector3sb[] {new Vector3sb(1, 0, 0), new Vector3sb(0, 0, -1), new Vector3sb(0, 1, 0)};
            
            
            TransitionFaceCoords3 = new UInt16[18] {
                /*TransitionFaceCoords3[0] = new UInt16[] {*/0x001, 0x010, 0x100, //};
                /*TransitionFaceCoords3[1] = new UInt16[] {*/0x900, 0x010, 0x001, //};
                /*TransitionFaceCoords3[2] = new UInt16[] {*/0x009, 0x010, 0x900, //};
                /*TransitionFaceCoords3[3] = new UInt16[] {*/0x100, 0x010, 0x009, //};
                /*TransitionFaceCoords3[4] = new UInt16[] {*/0x001, 0x100, 0x090, //};
                /*TransitionFaceCoords3[5] = new UInt16[] {*/0x001, 0x900, 0x010};
            
            //TransitionFaceCoords2[1][0] = new Vector3sb(0, 0, -1);
            //TransitionFaceCoords2[1][1] = new Vector3sb(0, 1, 0);
            //TransitionFaceCoords2[1][2] = new Vector3sb(1, 0, 0);
        }
        
        public static Vector3sb[,] TransitionFaceCoords = new Vector3sb[6, 3]
        {
            { // 0
                new Vector3sb(1, 0, 0), // ??? local X
                new Vector3sb(0, 1, 0), // ??? local Y
                new Vector3sb(0, 0, 1)/*, // ??? local Z

                new Vector3sb(0, 0, 0), // ??? origin calc
                new Vector3sb(2, -1, 0) // // Necessary to translate the intersection point to the 
                                          // high-res side so that it is transformed the same way 
                                          // as the vertices in the regular cell.
                                          */
            },
            { // 1
                new Vector3sb(0, 0, -1),
                new Vector3sb(0, 1, 0),
                new Vector3sb(1, 0, 0)/*,

                new Vector3sb(0, 0, 1),
                new Vector3sb(0, -1, 0)*/
            },
            { // 2
                new Vector3sb(-1, 0, 0),
                new Vector3sb(0, 1, 0),
                new Vector3sb(0, 0, -1)/*,

                new Vector3sb(1, 0, 1),
                new Vector3sb(2, 1, 0)*/
            },
            { // 3
                new Vector3sb(0, 0, 1),
                new Vector3sb(0, 1, 0),
                new Vector3sb(-1, 0, 0)/*,

                new Vector3sb(1, 0, 0),
                new Vector3sb(0, 1, 0)*/
            },
            { // 4
                new Vector3sb(1, 0, 0),
                new Vector3sb(0, 0, 1),
                new Vector3sb(0, -1, 0)/*,

                new Vector3sb(0, 1, 0),
                new Vector3sb(1, 1, 0)*/
            },
            { // 5
                new Vector3sb(1, 0, 0),
                new Vector3sb(0, 0, -1),
                new Vector3sb(0, 1, 0)/*,

                new Vector3sb(0, 0, 1),
                new Vector3sb(1, -1, 0)*/
            }
        };
        public static byte [] RegularCellClass = new byte[]
        {
            0x00, 0x01, 0x01, 0x03, 0x01, 0x03, 0x02, 0x04, 0x01, 0x02, 0x03, 0x04, 0x03, 0x04, 0x04, 0x03,
            0x01, 0x03, 0x02, 0x04, 0x02, 0x04, 0x06, 0x0C, 0x02, 0x05, 0x05, 0x0B, 0x05, 0x0A, 0x07, 0x04,
            0x01, 0x02, 0x03, 0x04, 0x02, 0x05, 0x05, 0x0A, 0x02, 0x06, 0x04, 0x0C, 0x05, 0x07, 0x0B, 0x04,
            0x03, 0x04, 0x04, 0x03, 0x05, 0x0B, 0x07, 0x04, 0x05, 0x07, 0x0A, 0x04, 0x08, 0x0E, 0x0E, 0x03,
            0x01, 0x02, 0x02, 0x05, 0x03, 0x04, 0x05, 0x0B, 0x02, 0x06, 0x05, 0x07, 0x04, 0x0C, 0x0A, 0x04,
            0x03, 0x04, 0x05, 0x0A, 0x04, 0x03, 0x07, 0x04, 0x05, 0x07, 0x08, 0x0E, 0x0B, 0x04, 0x0E, 0x03,
            0x02, 0x06, 0x05, 0x07, 0x05, 0x07, 0x08, 0x0E, 0x06, 0x09, 0x07, 0x0F, 0x07, 0x0F, 0x0E, 0x0D,
            0x04, 0x0C, 0x0B, 0x04, 0x0A, 0x04, 0x0E, 0x03, 0x07, 0x0F, 0x0E, 0x0D, 0x0E, 0x0D, 0x02, 0x01,
            0x01, 0x02, 0x02, 0x05, 0x02, 0x05, 0x06, 0x07, 0x03, 0x05, 0x04, 0x0A, 0x04, 0x0B, 0x0C, 0x04,
            0x02, 0x05, 0x06, 0x07, 0x06, 0x07, 0x09, 0x0F, 0x05, 0x08, 0x07, 0x0E, 0x07, 0x0E, 0x0F, 0x0D,
            0x03, 0x05, 0x04, 0x0B, 0x05, 0x08, 0x07, 0x0E, 0x04, 0x07, 0x03, 0x04, 0x0A, 0x0E, 0x04, 0x03,
            0x04, 0x0A, 0x0C, 0x04, 0x07, 0x0E, 0x0F, 0x0D, 0x0B, 0x0E, 0x04, 0x03, 0x0E, 0x02, 0x0D, 0x01,
            0x03, 0x05, 0x05, 0x08, 0x04, 0x0A, 0x07, 0x0E, 0x04, 0x07, 0x0B, 0x0E, 0x03, 0x04, 0x04, 0x03,
            0x04, 0x0B, 0x07, 0x0E, 0x0C, 0x04, 0x0F, 0x0D, 0x0A, 0x0E, 0x0E, 0x02, 0x04, 0x03, 0x0D, 0x01,
            0x04, 0x07, 0x0A, 0x0E, 0x0B, 0x0E, 0x0E, 0x02, 0x0C, 0x0F, 0x04, 0x0D, 0x04, 0x0D, 0x03, 0x01,
            0x03, 0x04, 0x04, 0x03, 0x04, 0x03, 0x0D, 0x01, 0x04, 0x0D, 0x03, 0x01, 0x03, 0x01, 0x01, 0x00
        };

    }
}