/*
 * Created by SharpDevelop.
 * User: Admin
 * Date: 2018-03-29
 * Time: 10:35
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using FastColoredTextBoxNS;
using System.Text.RegularExpressions;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Microsan
{
	/// <summary>
	/// Description of SourceCodeEditControl.
	/// </summary>
	public partial class SourceCodeEditControl : UserControl
	{
        public Action<string> Save = null;
        public Action SaveAll = null;
        public Action Execute = null;

        TextStyle BlueStyle = new TextStyle(Brushes.Blue, null, FontStyle.Regular);
        TextStyle BoldStyle = new TextStyle(null, null, FontStyle.Bold | FontStyle.Underline);
        TextStyle GrayStyle = new TextStyle(Brushes.Gray, null, FontStyle.Regular);
        TextStyle MagentaStyle = new TextStyle(Brushes.Magenta, null, FontStyle.Regular);
        TextStyle GreenStyle = new TextStyle(Brushes.Green, null, FontStyle.Italic);
        TextStyle BrownStyle = new TextStyle(Brushes.Brown, null, FontStyle.Italic);
        TextStyle MaroonStyle = new TextStyle(Brushes.Maroon, null, FontStyle.Regular);
        MarkerStyle SameWordsStyle = new MarkerStyle(new SolidBrush(Color.FromArgb(40, Color.Gray)));

        private DataTable dtLog;
        
        MenuItem menuItemPaste;

        public bool docked = false;
        
        private bool init = false;
        
        private List<SourceFile> sourceFilesRef;

        public Autocomplete ac;
        
        public SourceCodeEditControl() : this(Language.CSharp)
		{
			
		}
		
		public SourceCodeEditControl(Language language)
		{
			InitializeComponent();

            fctb.Language = language;

            dtLog = new DataTable();
            dtLog.Columns.Add("Filename", typeof(string));
            dtLog.Columns.Add("Row", typeof(int));
            dtLog.Columns.Add("Col", typeof(int));
            dtLog.Columns.Add("Description", typeof(string));
            

            dgv.DataSource = dtLog;
            fastColoredTextBox_setRightClickContextMenu();
            
            tc.DragOver += tc_DragOver;
            tc.MouseDown += tc_MouseDown;
            tc.MouseMove += tc_MouseMove;
            tc.MouseUp += tc_MouseUp;
            tc.Selected += tc_Selected;
            tc.SelectedIndexChanged += tc_SelectedIndexChanged;
            dgv.CellClick += dgv_CellClick;

            ac = new Autocomplete(fctb);
            ac.Debug = ac_Debug;

        }

        private void ac_Debug(string text)
        {
            rtxtLog.AppendLine_ThreadSafe(text, true);
        }
		
		private ContextMenu GetTabPageCM(string title, int index)
        {
            ContextMenu cm = new ContextMenu();
           // MenuItem mi = new MenuItem("close file", tcContextMenuCloseFile_Click);
          //  mi.Tag = index;
          //  cm.MenuItems.Add(mi);
            return cm;
        }
        private void tcContextMenuCloseFile_Click(object sender, EventArgs e)
        {
            int index = (int)((MenuItem)sender).Tag;
            tc.TabPages.RemoveAt(index);
        }

        public void Show(List<SourceFile> sourceFiles, string fileName_main)
        {
            sourceFilesRef = sourceFiles;
            
            tsBtnSave.Enabled = (Save != null);
            tsSaveAll.Enabled = (SaveAll != null);
            tsBtnExec.Enabled = (Execute != null) && (SaveAll != null);
            init = true;
            tc.TabPages.Clear();
            
            for (int i = 0; i < sourceFiles.Count; i++)
            {
                string fileNameTemp = sourceFiles[i].FileName;
                tc.TabPages.Add(fileNameTemp, fileNameTemp);
                
            }
            
            this.Show();

            SelectFileTab(fileName_main);
            SelectFile(fileName_main);
            init = false;
        }

        public void AddToDgvLog(string fileName, int linePos, int colPos, string logMessage)
        {
            dtLog.Rows.Add(fileName, linePos, colPos, logMessage);
        }

        public void ClearLog()
        {
            dtLog.Rows.Clear();
            rtxtLog.Clear();
            ResetSelections();
        }

        public void SelectCharAtPos(int linePos, int colPos)
        {
            try
            {
                FastColoredTextBoxNS.Range range = fctb.GetLine(linePos);
                range.Start = new FastColoredTextBoxNS.Place(colPos - 1, linePos - 1);
                range.End = new FastColoredTextBoxNS.Place(colPos, linePos - 1);
                fctb.Selection = range;

                fctb.DoSelectionVisible(); // scroll to selection
            }
            catch (Exception ex)
            {
                rtxtLog.AppendText("exception @ SelectCharAtPos: line=" + linePos + ", col=" + colPos + "\r\n");
                //rtxtLog.AppendText(ex.ToString() + "\r\n");
            }
        }

        public void ResetSelections()
        {
            fctb.Selection = new Range(fctb, Place.Empty, Place.Empty);
        }

        public void AppendLineToLog(string logMessage)
        {
            rtxtLog.AppendText(logMessage + "\n");
        }

        private void tsBtnSave_Click(object sender, EventArgs e)
        {
            ((SourceFile)fctb.Tag).Contents = fctb.Text;
            Save(tc.SelectedTab.Name);
        }
        private void tsSaveAll_Click(object sender, EventArgs e)
        {
            ((SourceFile)fctb.Tag).Contents = fctb.Text;
            SaveAll();
        }
        private void tsBtnExec_Click(object sender, EventArgs e)
        {
            ((SourceFile)fctb.Tag).Contents = fctb.Text;
            SaveAll();
            Execute();
        }


        public void AppendText(string text)
        {
            fctb.SelectedText = text;
        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            rtxtLog.Clear();
            rtxtLog.ClearUndo();
        }

        private void fastColoredTextBox_TextChanged(object sender, FastColoredTextBoxNS.TextChangedEventArgs e)
        {
            switch (fctb.Language)
            {
                case Language.CSharp:
                    //For sample, we will highlight the syntax of C# manually, although could use built-in highlighter
                    CSharpSyntaxHighlight(e);//custom highlighting
                    break;
                case Language.JS:
                    JavascriptSyntaxHighlight(e);
                    break;
                default:
                    break;//for highlighting of other languages, we using built-in FastColoredTextBox highlighter
            }
        }


		private void fastColoredTextBox_setRightClickContextMenu()
        {
            ContextMenu contextMenu = new System.Windows.Forms.ContextMenu();
            MenuItem menuItem;
                
            menuItem = new MenuItem("Redo");
            menuItem.Click += delegate (object sender, EventArgs e) { fctb.Redo(); };
            contextMenu.MenuItems.Add(menuItem);
            menuItem = new MenuItem("Undo");
            menuItem.Click += delegate (object sender, EventArgs e) { fctb.Undo(); };
            contextMenu.MenuItems.Add(menuItem);
                
            contextMenu.MenuItems.Add(new MenuItem("-"));

            menuItem = new MenuItem("Increase Line Indent");
            menuItem.Click += delegate (object sender, EventArgs e) { fctb.IncreaseIndent(); };
            contextMenu.MenuItems.Add(menuItem);
            menuItem = new MenuItem("Decrease Line Indent");
            menuItem.Click += delegate (object sender, EventArgs e) { fctb.DecreaseIndent(); };
            contextMenu.MenuItems.Add(menuItem);

            contextMenu.MenuItems.Add(new MenuItem("-"));

            menuItem = new MenuItem("Cut");
            menuItem.Click += delegate (object sender, EventArgs e) { fctb.Cut(); };
            contextMenu.MenuItems.Add(menuItem);
                
            menuItem = new MenuItem("Copy");
            menuItem.Click += delegate (object sender, EventArgs e) { fctb.Copy(); };
            contextMenu.MenuItems.Add(menuItem);
                
            menuItemPaste = new MenuItem("Paste");
            menuItemPaste.Click += delegate (object sender, EventArgs e) { fctb.Paste(); };
            contextMenu.MenuItems.Add(menuItemPaste);
                
            contextMenu.MenuItems.Add(new MenuItem("-"));
                
            menuItem = new MenuItem("Delete");
            menuItem.Click += delegate (object sender, EventArgs e) { fctb.SelectedText = ""; };
            contextMenu.MenuItems.Add(menuItem);

            contextMenu.Popup += new EventHandler(ContextMenu_Popup_Action);
            fctb.ContextMenu = contextMenu;
        }

		void ContextMenu_Popup_Action(object s, EventArgs ea)
		{
			menuItemPaste.Enabled = Clipboard.ContainsText();
		}
       
        private void JavascriptSyntaxHighlight(TextChangedEventArgs e)
        {
             // old edition
             //Range range = e.ChangedRange;

             //new edition
             Range range = fctb.VisibleRange;//or (sender as 
                                                           //FastColoredTextBox).Range

            //clear style of changed range
            range.ClearStyle(GreenStyle);
            //comment highlighting
            range.SetStyle(GreenStyle, @"//.*$", RegexOptions.Multiline);
            range.SetStyle(GreenStyle, @"(/\*.*?\*/)|(/\*.*)", RegexOptions.Singleline);
            range.SetStyle(GreenStyle, @"(/\*.*?\*/)|(.*\*/)", RegexOptions.Singleline |
                        RegexOptions.RightToLeft);
        }

        private void CSharpSyntaxHighlight(TextChangedEventArgs e)
        {
            fctb.LeftBracket = '(';
            fctb.RightBracket = ')';
            fctb.LeftBracket2 = '\x0';
            fctb.RightBracket2 = '\x0';
            //clear style of changed range
            e.ChangedRange.ClearStyle(BlueStyle, BoldStyle, GrayStyle, MagentaStyle, GreenStyle, BrownStyle);

            //string highlighting
            e.ChangedRange.SetStyle(BrownStyle, @"""""|@""""|''|@"".*?""|(?<!@)(?<range>"".*?[^\\]"")|'.*?[^\\]'");
            //comment highlighting
            e.ChangedRange.SetStyle(GreenStyle, @"//.*$", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(GreenStyle, @"(/\*.*?\*/)|(/\*.*)", RegexOptions.Singleline);
            e.ChangedRange.SetStyle(GreenStyle, @"(/\*.*?\*/)|(.*\*/)", RegexOptions.Singleline | RegexOptions.RightToLeft);
            //number highlighting
            e.ChangedRange.SetStyle(MagentaStyle, @"\b\d+[\.]?\d*([eE]\-?\d+)?[lLdDfF]?\b|\b0x[a-fA-F\d]+\b");
            //attribute highlighting
            e.ChangedRange.SetStyle(GrayStyle, @"^\s*(?<range>\[.+?\])\s*$", RegexOptions.Multiline);
            //class name highlighting
            e.ChangedRange.SetStyle(BoldStyle, @"\b(class|struct|enum|interface)\s+(?<range>\w+?)\b");
            //keyword highlighting
            e.ChangedRange.SetStyle(BlueStyle, @"\b(abstract|as|base|bool|break|byte|case|catch|char|checked|class|const|continue|decimal|default|delegate|do|double|else|enum|event|explicit|extern|false|finally|fixed|float|for|foreach|goto|if|implicit|in|int|interface|internal|is|lock|long|namespace|new|null|object|operator|out|override|params|private|protected|public|readonly|ref|return|sbyte|sealed|short|sizeof|stackalloc|static|string|struct|switch|this|throw|true|try|typeof|uint|ulong|unchecked|unsafe|ushort|using|virtual|void|volatile|while|add|alias|ascending|descending|dynamic|from|get|global|group|into|join|let|orderby|partial|remove|select|set|value|var|where|yield)\b|#region\b|#endregion\b");

            //clear folding markers
            e.ChangedRange.ClearFoldingMarkers();

            //set folding markers
            e.ChangedRange.SetFoldingMarkers("{", "}");//allow to collapse brackets block
            e.ChangedRange.SetFoldingMarkers(@"#region\b", @"#endregion\b");//allow to collapse #region blocks
            e.ChangedRange.SetFoldingMarkers(@"/\*", @"\*/");//allow to collapse comment block
        }

        private void fastColoredTextBox_SelectionChangedDelayed(object sender, EventArgs e)
        {
            fctb.VisibleRange.ClearStyle(SameWordsStyle);
            if (!fctb.Selection.IsEmpty)
                return;//user selected diapason

            //get fragment around caret
            var fragment = fctb.Selection.GetFragment(@"\w");
            string text = fragment.Text;
            if (text.Length == 0)
                return;
            //highlight same words
            var ranges = fctb.VisibleRange.GetRanges("\\b" + text + "\\b").ToArray();
            if (ranges.Length > 1)
                foreach (var r in ranges)
                    r.SetStyle(SameWordsStyle);
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectLogItem(e.RowIndex);
        }

        public void SelectLogItem(int rowIndex)
        {
            string fileName = (string)dtLog.Rows[rowIndex]["Filename"];
            int textRow = (int)dtLog.Rows[rowIndex]["Row"];
            int textCol = (int)dtLog.Rows[rowIndex]["Col"];
            rtxtLog.Text = (string)dtLog.Rows[rowIndex]["Description"];
            if ((textRow < 1) || (textCol < 1))
                return;

            init = true;
            SelectFileTab(fileName);
            SelectFile(fileName);
            init = false;

            SelectCharAtPos(textRow, textCol);
        }
        private void SelectFileTab(string fileName)
        {
            fileName = fileName.ToLower();
            for (int i = 0; i < tc.TabCount; i++)
            {
                if (tc.TabPages[i].Name.ToLower() == fileName)
                {
                    tc.SelectedTab = tc.TabPages[i];
                    return;
                }
            }
        }
        private void tc_MouseDown(object sender, MouseEventArgs e)
        {
            // store clicked tab
            TabControl tc = (TabControl)sender;
            int hover_index = this.getHoverTabIndex(tc);
            if (hover_index >= 0) { tc.Tag = tc.TabPages[hover_index]; }
             tc.ContextMenu = GetTabPageCM(tc.TabPages[hover_index].Text, hover_index);
        }
        private void tc_MouseUp(object sender, MouseEventArgs e)
        {
            // clear stored tab
            TabControl tc = (TabControl)sender;
            tc.Tag = null;
        }
        private void tc_MouseMove(object sender, MouseEventArgs e)
        {           
            // mouse button down? tab was clicked?
            TabControl tc = (TabControl)sender;
            
           
            if ((e.Button != MouseButtons.Left) || (tc.Tag == null)) return;
            TabPage clickedTab = (TabPage)tc.Tag;
            int clicked_index = tc.TabPages.IndexOf(clickedTab);

            // start drag n drop
            tc.DoDragDrop(clickedTab, DragDropEffects.All);
        }
        private void tc_DragOver(object sender, DragEventArgs e)
        {
            TabControl tc = (TabControl)sender;

            // a tab is draged?
            if (e.Data.GetData(typeof(TabPage)) == null) return;
            TabPage dragTab = (TabPage)e.Data.GetData(typeof(TabPage));
            int dragTab_index = tc.TabPages.IndexOf(dragTab);

            // hover over a tab?
            int hoverTab_index = this.getHoverTabIndex(tc);
            if (hoverTab_index < 0) { e.Effect = DragDropEffects.None; return; }
            TabPage hoverTab = tc.TabPages[hoverTab_index];
            e.Effect = DragDropEffects.Move;

            // start of drag?
            if (dragTab == hoverTab) return;

            // swap dragTab & hoverTab - avoids toggeling
            Rectangle dragTabRect = tc.GetTabRect(dragTab_index);
            Rectangle hoverTabRect = tc.GetTabRect(hoverTab_index);

            if (dragTabRect.Width < hoverTabRect.Width)
            {
                Point tcLocation = tc.PointToScreen(tc.Location);

                if (dragTab_index < hoverTab_index)
                {
                    if ((e.X - tcLocation.X) > ((hoverTabRect.X + hoverTabRect.Width) - dragTabRect.Width))
                        this.swapTabPages(tc, dragTab, hoverTab);
                }
                else if (dragTab_index > hoverTab_index)
                {
                    if ((e.X - tcLocation.X) < (hoverTabRect.X + dragTabRect.Width))
                        this.swapTabPages(tc, dragTab, hoverTab);
                }
            }
            else this.swapTabPages(tc, dragTab, hoverTab);

            // select new pos of dragTab
            tc.SelectedIndex = tc.TabPages.IndexOf(dragTab);
        }

        private int getHoverTabIndex(TabControl tc)
        {
            for (int i = 0; i < tc.TabPages.Count; i++)
            {
                if (tc.GetTabRect(i).Contains(tc.PointToClient(Cursor.Position)))
                    return i;
            }

            return -1;
        }

        private void swapTabPages(TabControl tc, TabPage src, TabPage dst)
        {
            int index_src = tc.TabPages.IndexOf(src);
            int index_dst = tc.TabPages.IndexOf(dst);
            tc.TabPages[index_dst] = src;
            tc.TabPages[index_src] = dst;
            tc.Refresh();
        }
        void tc_Selected(object sender, TabControlEventArgs e)
        {
            
        }
        private void tc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tc.SelectedTab == null)
                return;
            if (init) return;

            SelectFile(tc.SelectedTab.Text);
            //tc.SelectedTab.Font = new Font(tc.SelectedTab.Font, FontStyle.Bold);
        }
        
        private void SelectFile(string fileName)
        {
            fileName = fileName.ToLower();
            for (int i = 0; i < sourceFilesRef.Count; i++)
            {
                if (sourceFilesRef[i].FileName.ToLower() == fileName)
                {

                    if (fctb.Tag != null)
                    {
                        SourceFile sf = (SourceFile)fctb.Tag;
                        sf.Contents = fctb.Text;

                        sf.editorSelectionStart = fctb.SelectionStart;
                        sf.editorSelectionLength = fctb.SelectionLength;

                        sf.editorVerticalScrollValue = fctb.VerticalScroll.Value;
                        sf.editorHorizontalScrollValue = fctb.HorizontalScroll.Value;
                        
                    }
                    
                    fctb.Text = sourceFilesRef[i].Contents;
                    fctb.Tag = sourceFilesRef[i];
                    fctb.SelectionStart = sourceFilesRef[i].editorSelectionStart;
                    fctb.SelectionLength = sourceFilesRef[i].editorSelectionLength;
                    
                    fctb.HorizontalScroll.Value = sourceFilesRef[i].editorHorizontalScrollValue;
                    fctb.VerticalScroll.Value = sourceFilesRef[i].editorVerticalScrollValue;
                    fctb.UpdateScrollbars();

                    
                    //rtxtLog.AppendText("ok @ SelectFile: fileName=" + fileName + "\r\n");
                    return;
                }
            }
            rtxtLog.AppendText("error @ SelectFile: fileName=" + fileName + "\r\n");
        }
        private void fastColoredTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //tc.Enabled = false;
            //tsslblMain.Text =  "(text changed, you need to save before switch tabs)";
        }
        private void tsbtnNewFile_Click(object sender, EventArgs e)
        {
            string filePath = "";
            if (!QuickDialogs.FileSave(Application.StartupPath + "\\" + RuntimeProgramming.SOURCE_FILES_DIR_NAME, "Select the filename..", "C# files|*.cs", out filePath))
                return;

            SourceFile sf = new SourceFile(filePath);
            sf.Contents = RuntimeProgramming.GetEmbeddedTemplateResource(RuntimeProgramming.RES_NAME_NEW_CLASS_TEMPLATE).Replace("NewClass", sf.FileNameWithoutExt);
            sf.SaveFile();
            
            sourceFilesRef.Add(sf);
            
            tc.TabPages.Add(sf.FileName, sf.FileName);
            sf = null;
        }

        
    }
}
