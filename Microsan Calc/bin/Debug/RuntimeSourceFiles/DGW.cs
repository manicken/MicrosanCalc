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
    public class DGV
    {
        public static DataGridViewForm dgvForm;
        
        public static void Init()
        {
            if (GetPrevFormIfExist())
            {
                dgvForm.dataTable.TableName = "PSU";
                return;
            }
            dgvForm = new DataGridViewForm();
            
            dgvForm.Init("PSU","Wires", "Volt", "Descr.");
            dgvForm.Show();
            
            
        }
        
        public static bool GetPrevFormIfExist()
        {
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.Text == "DataGridViewForm")
                {
                    dgvForm = (DataGridViewForm)frm;
                    return true;
                }
            }
            return false;
        }
    }
}