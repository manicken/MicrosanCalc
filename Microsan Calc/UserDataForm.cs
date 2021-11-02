using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Microsan
{
    public partial class UserDataForm : Form
    {
        public Action<string> InsertData;

        int uniqueId = 0;
        private readonly string FILE_NAME_EXT = ".xml";
        private string FILE_NAME = "userData";
        private string DATA_TYPE_NAME = "data";
        private readonly string COL_NAME_MNEMONIC = "mnemonic";
        private readonly string COL_NAME_DESCRIPTION = "description";

        private DataSet ds;

        public bool Docked
        {
            get { return (this.Visible && chkBoxDocked.Checked); }
        }

        public UserDataForm(string dataFileName, string dataTypeName, string title)
        {
            InitializeComponent();
            DATA_TYPE_NAME = dataTypeName;
            FILE_NAME = dataFileName;

            this.Text = title;

            tabCategorys.TabPages.Clear(); // remove the dummy page


            InitData();
            
        }

        public string PreParse_ReplaceOccurrences(string input, bool recursiveSearch)
        {
            bool foundAnyOccurrences = false;
            string mnemonicTemp = "";
            uint counter = 0;
            do
            {
                foundAnyOccurrences = false;
                for (int ti = 0; ti < ds.Tables.Count; ti++)
                {
                    for (int ri = 0; ri < ds.Tables[ti].Rows.Count; ri++)
                    {
                        mnemonicTemp = ds.Tables[ti].Rows[ri][COL_NAME_MNEMONIC].ToString();
                        if (input.Contains(mnemonicTemp))
                        {
                            foundAnyOccurrences = true;
                            input = input.Replace(mnemonicTemp, "(" + ds.Tables[ti].Rows[ri][DATA_TYPE_NAME].ToString() + ")");
                        }
                    }
                }
                counter++; // recursiveSearch failsafe counter
            }while (foundAnyOccurrences && recursiveSearch && (counter != uint.MaxValue));
            return input;
        }

        private void ReadDataFromFile()
        {
            //ds.ReadXmlSchema(FILE_NAME + ".schema" + FILE_NAME_EXT);
            ds.ReadXml(FILE_NAME + FILE_NAME_EXT, XmlReadMode.Auto);

        }

        private void WriteDataToFile()
        {
            ds.WriteXml(FILE_NAME + FILE_NAME_EXT, XmlWriteMode.WriteSchema);
            //ds.WriteXmlSchema(FILE_NAME + ".schema" + FILE_NAME_EXT);
        }

        private void InitData()
        {
            ds = new DataSet(FILE_NAME);
            if (System.IO.File.Exists(FILE_NAME + FILE_NAME_EXT))
            {
                ReadDataFromFile();
                
                uniqueId = ds.Tables.Count;

                if (uniqueId == 0)
                {
                    AddNewDataTable("category" + (uniqueId++));
                    return;
                }

                for (int i = 0; i < ds.Tables.Count; i++)
                {
                    tabCategorys.TabPages.Add(ds.Tables[i].TableName);
                    uniqueId++;
                }

            }
            else
            {
                AddNewDataTable("category" + (uniqueId++));
            }
        }

        private void AddNewDataTable(string name)
        {

            DataTable dt = new DataTable(name);
            dt.Columns.Add(COL_NAME_MNEMONIC, typeof(string));
            dt.Columns.Add(DATA_TYPE_NAME, typeof(string));
            dt.Columns.Add(COL_NAME_DESCRIPTION, typeof(string));
            ds.Tables.Add(dt);
            tabCategorys.TabPages.Add("cat" + (uniqueId++), name);
            tabCategorys.SelectedIndex = tabCategorys.TabCount - 1;
            dgv.DataSource = dt;
        }

        private void FunctionsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            WriteDataToFile();
            e.Cancel = true;
            this.Visible = false;
        }

        private void tabCategorys_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabCategorys.SelectedIndex == -1)
                return;

            dgv.DataSource = ds.Tables[tabCategorys.SelectedIndex];
        }

        private bool RenameCategoryVerifyNewName(string newName)
        {
            if (ds.Tables.Contains(newName))
            {
                MessageBox.Show("A category with this name allready exist!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        private void renameCategory_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabCategorys.SelectedIndex == -1)
                return;
            

            using (InputForm inputForm = new InputForm())
            {
                inputForm.DoVerifyInput = RenameCategoryVerifyNewName;

                if (inputForm.ShowDialog("Change Category Name", "Enter the new category name:", tabCategorys.SelectedTab.Text, false, true, FormStartPosition.CenterParent) == System.Windows.Forms.DialogResult.OK)
                {
                    string newName = inputForm.InputValue;
                    tabCategorys.SelectedTab.Text = newName;
                    ds.Tables[tabCategorys.SelectedIndex].TableName = newName;
                }

                inputForm.DoVerifyInput = null;
            }

        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewDataTable("category" + (uniqueId++));
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabCategorys.SelectedIndex == -1)
                return;

            if (MessageBox.Show("Are you sure you want to delete: " + tabCategorys.SelectedTab.Text, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.No)
                return;

            ds.Tables.RemoveAt(tabCategorys.SelectedIndex);
            tabCategorys.TabPages.Remove(tabCategorys.SelectedTab);
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            WriteDataToFile();
        }

        private void insertData_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows == null)
                return;

            if (dgv.SelectedRows.Count == 0)
                return;

            if (InsertData == null)
                return;
            InsertData(dgv.Rows[dgv.SelectedRows[0].Index].Cells[DATA_TYPE_NAME].Value.ToString());
        }

        public void Show(int xPos, int yPos, int height)
        {
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(xPos, yPos);
            this.Height = height;
            this.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            WriteDataToFile();
            this.Visible = false;
        }

        private void FunctionsForm_Shown(object sender, EventArgs e)
        {
            dgv.DataSource = ds.Tables[0];
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows == null)
                return;

            if (dgv.SelectedRows.Count == 0)
                return;

            if (InsertData == null)
                return;
            InsertData(dgv.Rows[dgv.SelectedRows[0].Index].Cells[COL_NAME_MNEMONIC].Value.ToString());
        }

        private void dgv_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            /*
            for (int i = 0; i < dgv.Rows[e.RowIndex].Cells.Count; i++)
            {
                
                if (dgv.Rows[e.RowIndex].Cells[i].Value != null)
                {
                    if (dgv.Rows[e.RowIndex].Cells[i].Value.ToString() == "")
                        dgv.Rows[e.RowIndex].Cells[i].Value = "(none)";
                }
            }
            */
        }
    }
}
