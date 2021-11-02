/*
 * Created by SharpDevelop.
 * User: Admin
 * Date: 2018-03-28
 * Time: 19:45
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Microsan
{
	/// <summary>
	/// Description of RichTextBoxLoggerControl.
	/// </summary>
	public partial class RichTextBoxLoggerControl : UserControl
	{
		public RichTextBoxLoggerControl()
		{
			InitializeComponent();
			
			rtxt_setRightClickContextMenu();
            
            rtxt.TextChanged += rtxt_TextChanged;
            
            //this.VisibleChanged += this_VisibleChanged;
		}
		
		public void SaveLog(string filePath)
		{
			rtxt.SaveFile(filePath, RichTextBoxStreamType.RichText);
		}
		
		public bool LoadLog(string filePath, bool scrollToEnd)
		{
			if (!System.IO.File.Exists(filePath))
				return false;
            
            rtxt.LoadFile(filePath, RichTextBoxStreamType.RichText);
            
            if (scrollToEnd)
            {
            	rtxt.Select(rtxt.TextLength - 1, 0);
            	rtxt.ScrollToCaret();
            }
                
            return true;
            
		}
		
		public void Clear()
        {
        	if (rtxt.InvokeRequired)
                rtxt.BeginInvoke((MethodInvoker)delegate
                {
                    rtxt.Clear();
                });
            else
                rtxt.Clear();
        }
        
        public void AppendText(string text)
        {
        	if (rtxt.InvokeRequired)
                rtxt.BeginInvoke((MethodInvoker)delegate
                {
                    rtxt.AppendText(text);
                });
            else
                rtxt.AppendText(text);
        }

        public void AppendTextLine()
        {
            AppendText("\r\n");
            
        }

        public void AppendTextLine(string line)
        {
        	AppendText(line + "\r\n");
        }
        
        public void AppendTextLine(string t, HorizontalAlignment a)
        {
        	if (rtxt.InvokeRequired)
                rtxt.BeginInvoke((MethodInvoker)delegate
                {
                    rtxt.Select(rtxt.TextLength, 0);
            		rtxt.SelectionAlignment = a;
            		rtxt.SelectedText = t + "\n";
                });
            else
            {
            	rtxt.Select(rtxt.TextLength, 0);
            	rtxt.SelectionAlignment = a;
            	rtxt.SelectedText = t + "\n";
            }
            
        }
		
		private void rtxt_TextChanged(object sender, EventArgs e)
        {
            this.Visible = true;
            rtxt.ScrollToCaret();
        }

        private void rtxt_setRightClickContextMenu()
        {
            
                ContextMenu contextMenu = new System.Windows.Forms.ContextMenu();
                MenuItem menuItem;
                //MenuItem menuItem = new MenuItem("Cut");
                //menuItem.Click += new EventHandler(CutAction);
                //contextMenu.MenuItems.Add(menuItem);
                
                menuItem = new MenuItem("Copy");
                menuItem.Click += new EventHandler(CopyAction);
                contextMenu.MenuItems.Add(menuItem);
                
                menuItem = new MenuItem("Save to file..");
                menuItem.Click += new EventHandler(tsBtnSaveToFile_Click);
                contextMenu.MenuItems.Add(menuItem);
                
                //menuItemPaste = new MenuItem("Paste");
                //menuItemPaste.Click += new EventHandler(PasteAction);
                //contextMenu.MenuItems.Add(menuItemPaste);
                
                contextMenu.Popup += new EventHandler(ContextMenu_Popup_Action);
                rtxt.ContextMenu = contextMenu;
        }
        
        private void ContextMenu_Popup_Action(object s, EventArgs ea)
        {
            //menuItemPaste.Enabled = Clipboard.ContainsText();
        }
        
        private void CutAction(object sender, EventArgs e)
        {
        //    rtxt.Cut();
        }

        private void CopyAction(object sender, EventArgs e)
        {
            //Clipboard.SetData(DataFormats.Text, fastColoredTextBox.SelectedText);
            //Clipboard.Clear();
            rtxt.Copy();
        }
        
        private void PasteAction(object sender, EventArgs e)
        {
        //    rtxtLog.Paste();
            //fastColoredTextBox.SelectedText = Clipboard.GetText();
        } 
        
        private void tsBtnSaveToFile_Click(object sender, EventArgs e)
        {
            string filePath;
            if (QuickDialogs.FileSave(Application.StartupPath, "", "RichText Files|*.rtf", out filePath))
            {
                rtxt.SaveFile(filePath, RichTextBoxStreamType.RichText);
            }
        }
        
       
        
        
	}
}
