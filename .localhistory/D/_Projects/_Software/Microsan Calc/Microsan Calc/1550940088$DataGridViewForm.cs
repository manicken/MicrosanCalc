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
        public ToolStripButton tsBtnRemoveCol;
        
        public DataGridViewForm()
        {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();
            
            dataTable = new DataTable();

            dgv.DataSource = null;
            dgv.DataSource = dataTable;

            ContextMenuStrip cms = new ContextMenuStrip();
            cms.Items.Add("Add New Col", null, addNewCol_Click);
            tsBtnRemoveCol = new ToolStripButton("Remove Col",null, removeCol_Click);
            cms.Items.Add(tsBtnRemoveCol);
            cms.Opening += Cms_Opening;
            dgv.ContextMenuStrip = cms;
            dgv.CellMouseDown += Dgv_CellMouseDown;
            
            dgv.ColumnAdded += Dgv_ColumnAdded;
        }

        private void Dgv_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1) // column header
            {
                if (dgv.Rows.Count == 0) return;
                dgv.ClearSelection();
                dgv.Rows[0].Cells[e.ColumnIndex].Selected = true;
            }
        }

        private void Dgv_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
            
        }

        private void Dgv_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            e.Column.SortMode = DataGridViewColumnSortMode.Programmatic;
        }

        private void Cms_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //tsBtnRemoveCol.Enabled = (dgv.SelectedColumns.Count != 0);
        }


        public void addNewCol_Click(object s, EventArgs ea)
        {
            using (InputForm iform = new InputForm())
            {
                DialogResult dr = iform.ShowDialog("Add new Col", "Column name input", "col" + dataTable.Columns.Count, false, false, FormStartPosition.CenterParent);
                if (dr != DialogResult.OK)
                    return;
                if (dataTable.Columns.Contains(iform.InputValue))
                {
                    MessageBox.Show("This columnname is allready exist!");
                    return;
                }
                dataTable.Columns.Add(iform.InputValue);
            }
        }
        public void removeCol_Click(object s, EventArgs ea)
        {
            if (dgv.SelectedCells.Count != 1) { MessageBox.Show("column not selected!"); return; }

            string colName = dgv.SelectedCells[0].OwningColumn.Name;
            if (System.Windows.Forms.QuickDialogs.MessageBoxVerifyAction("Verify", "Are you sure you want to remove the column "+ colName +"?"))
            {
                dataTable.Columns.Remove(colName);
            }
        }
        public void Init(string name, params string[] columns)
        {
            dgv.DataSource = null;
            dataTable.Clear();
            dataTable.TableName = name;
            for (int i = 0; i < columns.Length; i++)
            {
                dataTable.Columns.Add(columns[i]);
            }
            dgv.DataSource = dataTable;
        }
        
        private void tsBtnSaveToFile_Click(object sender, EventArgs e)
        {
            if (dataTable == null)
                return;
            string filePath;
            if (QuickDialogs.FileSave(Application.StartupPath, "", "Xml Files|*.xml", out filePath))
            {
                
                dataTable.WriteXml(filePath, XmlWriteMode.WriteSchema);
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
                dataTable = new DataTable();
                dataTable.ReadXmlSchema(filePath);
                dataTable.ReadXml(filePath);
                dgv.DataSource = null;
                dgv.DataSource = dataTable;

            }
        }

        private void dgv_DataSourceChanged(object sender, EventArgs e)
        {
            for (int i = 0; i< dgv.Columns.Count; i++)
            {
                dgv.Columns[i].SortMode = DataGridViewColumnSortMode.Programmatic;
            }
        }
    }
}
