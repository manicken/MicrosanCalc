/*
 * Created by SharpDevelop.
 * User: Microsan84
 * Date: 2017-04-04
 * Time: 08:42
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;

namespace Microsan
{
    /// <summary>
    /// Description of DataGridViewForm.
    /// </summary>
    public partial class DataGridViewForm : Form
    {
        public DataTable dataTable;
        
        public DataGridViewForm()
        {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();
            
            dataTable = new DataTable();
            
        }
        
        private void tsBtnSaveToFile_Click(object sender, EventArgs e)
        {
            if (dataTable == null)
                return;
            string filePath;
            if (QuickDialogs.FileSave(Application.StartupPath, "", "Xml Files|*.xml", out filePath))
            {
                dataTable.WriteXml(filePath);
            }
        }
        
        private void this_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Visible = false;
            }
        }

        private void tsBtnLoad_Click(object sender, EventArgs e)
        {
            string filePath;
            if (QuickDialogs.FileOpen(Application.StartupPath, "", "Xml Files|*.xml", out filePath))
            {
                dataTable.WriteXml(filePath);
            }
        }
    }
}
