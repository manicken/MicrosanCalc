/*
 * Created by SharpDevelop.
 * User: Microsan84
 * Date: 2017-05-06
 * Time: 13:57
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Microsan
{
    using System.IO;
    using System.Runtime.Remoting.Messaging;
    using System.Text;

    
    /// <summary>
    /// 
    /// </summary>
    public static class Debugger
    {
        public static Action<string> Message;
        public static Action<string> Warning;
        public static Action<string> Error;

        public static Action<string> ConsoleOutHandler;

        public static void RedirectConsoleOutput(Action<string> handler)
        {
            MemoryStream ms = new MemoryStream();
            CGS.ProgressStream ps = new CGS.ProgressStream(ms);
            ps.BytesWritten += ConsoleProgressStream_BytesWritten;
            Console.SetOut(new StreamWriter(ps));

            ConsoleOutHandler = handler;
            
        }

        private static void ConsoleProgressStream_BytesWritten(CGS.ProgressStream progressStream, CGS.ProgressStreamReportEventArgs args)
        {
            PrintMessageLine(progressStream.ReadToEnd());
        }

        public static void PrintMessageLine(string lineOfText)
        {
            if (Message != null)
                Message(lineOfText + "\n");
            else
                System.Diagnostics.Debug.WriteLine(lineOfText, "info");
            
        }
        public static void PrintWarningLine(string lineOfText)
        {
            if (Warning != null)
                Warning(lineOfText + "\n");
            else
                System.Diagnostics.Debug.WriteLine(lineOfText, "warning");
        }

        public static void PrintErrorLine(string lineOfText)
        {
            if (Error != null)
                Error(lineOfText + "\n");
            else
                System.Diagnostics.Debug.WriteLine(lineOfText, "error");
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public static class XmlDoc
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns></returns>
        public static System.IO.FileInfo GetXmlDocFile(System.Reflection.Assembly assembly)
        {
            
            string assemblyDirPath = System.IO.Path.GetDirectoryName(assembly.CodeBase);
            string fileName = System.IO.Path.GetFileNameWithoutExtension(assembly.CodeBase) + ".xml";
            assemblyDirPath = assemblyDirPath.Replace("file:\\", "");

            return new System.IO.FileInfo(assemblyDirPath + "\\" + fileName); 
            /*GetFallbackDirectories(System.Globalization.CultureInfo.CurrentCulture)
              .Select(dirName => CombinePath(assemblyDirPath, dirName, fileName))
              .Select(filePath => new System.IO.FileInfo(filePath))
              .Where(file => file.Exists)
              .First();*/
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="culture"></param>
        /// <returns></returns>
        public static IEnumerable<string> GetFallbackDirectories(System.Globalization.CultureInfo culture)
        {
            return culture
              .Enumerate(c => c.Parent.Name != c.Name ? c.Parent : null)
              .Select(c => c.Name);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="start"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        public static IEnumerable<T> Enumerate<T>(this T start, Func<T, T> next)
        {
            for (T item = start; !object.Equals(item, default(T)); item = next(item))
                yield return item;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static string CombinePath(params string[] args)
        {
            return args.Aggregate(System.IO.Path.Combine);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="docMembers"></param>
        /// <param name="member"></param>
        /// <returns></returns>
        public static System.Xml.Linq.XElement GetDocMember(IEnumerable<System.Xml.Linq.XElement> docMembers, System.Reflection.MemberInfo member)
        {
            if (docMembers == null)
                return new System.Xml.Linq.XElement("doc_file_not_found");
            string memberId = GetMemberId(member);

            foreach (System.Xml.Linq.XElement xe in docMembers)
            {
                System.Xml.Linq.XAttribute xea = xe.Attribute("name");
                if (xea == null)
                    continue;
                if (xea.Value == memberId)
                    return xe;
            }
            return new System.Xml.Linq.XElement("doc_member_not_found", memberId);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        public static string GetMemberId(System.Reflection.MemberInfo member)
        {
            char memberKindPrefix = GetMemberPrefix(member);
            string memberName = GetMemberFullName(member);
            return memberKindPrefix + ":" + memberName;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        public static char GetMemberPrefix(System.Reflection.MemberInfo member)
        {
            return member.GetType().Name
              .Replace("Runtime", "")[0];
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        public static string GetMemberFullName(System.Reflection.MemberInfo member)
        {
            string memberScope = "";
            if (member.DeclaringType != null)
                memberScope = GetMemberFullName(member.DeclaringType);
            else if (member is Type)
                memberScope = ((Type)member).Namespace;

            if (member.MemberType == System.Reflection.MemberTypes.Method)
                return memberScope + "." + (member as System.Reflection.MethodInfo).GetMethodDocName();
            else
                return memberScope + "." + member.Name;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mi"></param>
        /// <returns></returns>
        public static string GetMethodDocName(this System.Reflection.MethodInfo mi)
        {
            string mn = mi.ToString();
            int indexOf = mn.IndexOf(' ');
            if (indexOf == -1) return mn;
            return mn.Substring(indexOf + 1);
        }
    }
    
    /// <summary>
    /// Description of MicrosanExtensions.
    /// </summary>
    public static class MicrosanExtensions
    {
        /// <summary>
        /// Gets the word before the inputted index, the word can begin with any whitecharacter
        /// </summary>
        /// <param name="str"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static string WordBefore(this string str, int index)
        {
            if (index == -1) return "";

            for (int i = index - 1; i >= 0; i--)
            {
                if (str[i] == ' ' || str[i] == '\t' || str[i] == '(' || str[i] == ',')
                {
                    i++;
                    return str.Substring(i, index - i);
                }
            }
            return str.Substring(0, index);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="thisString"></param>
        /// <returns></returns>
        public static bool NullOrEmpty(this string thisString)
        {
            if (thisString == null) return true;
            return (thisString.Length == 0);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="thisString"></param>
        /// <param name="value"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static bool TryGetIndexOf(this string thisString, char value, out int index)
        {
            index = thisString.IndexOf(value);
            return (index != -1);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="thisString"></param>
        /// <param name="value"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static bool TryGetIndexOf(this string thisString, string value, out int index)
        {
            index = thisString.IndexOf(value);
            return (index != -1);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="thisComboBox"></param>
        /// <returns></returns>
        public static string[] StringItems (this System.Windows.Forms.ComboBox thisComboBox)
        {
            string[] tmp = new string[thisComboBox.Items.Count];
            for (int i = 0; i < tmp.Length; i++)
                tmp[i] = (string)thisComboBox.Items[i];
            return tmp;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="thisComboBoxItems"></param>
        /// <returns></returns>
        public static string[] ToStringArray (this System.Windows.Forms.ComboBox.ObjectCollection thisComboBoxItems)
        {
            string[] tmp = new string[thisComboBoxItems.Count];
            for (int i = 0; i < tmp.Length; i++)
                tmp[i] = (string)thisComboBoxItems[i];
            return tmp;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="thisString"></param>
        /// <param name="startIndex"></param>
        /// <param name="firstChar"></param>
        /// <param name="secondChar"></param>
        /// <param name="subString"></param>
        /// <returns></returns>
        public static bool TryGetSubstringBetween(this string thisString, int startIndex, char firstChar, char secondChar, out string subString)
        {
            subString = null;
            
            int firstIndexOf = thisString.IndexOf(firstChar, startIndex);
            if (firstIndexOf == -1) return false;
            
            int secondIndexOf = thisString.IndexOf(secondChar, firstIndexOf);
            if (secondIndexOf == -1) return false;
            
            firstIndexOf++;
            subString = thisString.Substring(firstIndexOf, secondIndexOf - firstIndexOf);
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="thisControl"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public static void MoveAndResize(this System.Windows.Forms.Control thisControl, int x, int y, int width, int height)
        {
            System.Drawing.Rectangle rect = thisControl.Bounds;
            rect.X += x;
            rect.Y += y;
            rect.Width += width;
            rect.Height += height;
            thisControl.Bounds = rect;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hec"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static List<HtmlElement> GetElementsByClass(this HtmlElementCollection hec, string name)
        {
            List<HtmlElement> elements = new List<HtmlElement>();
            for (int i = 0; i < hec.Count; i++)
            {
                if (hec[i].GetAttribute("class") == name)
                    elements.Add(hec[i]);
            }
            return elements;
        }
        
        // dont work because every child and therir childs an so on also must be checked
        /*public static HtmlElementCollection GetElementsByName(this HtmlDocument thisHtmlDoc, string name)
        {
            return thisHtmlDoc.All.GetElementsByName(name);
        }*/
        
        // dont work because every child and therir childs an so on also must be checked
        /*public static bool GetFirstElementByTagAndClass(this HtmlElementCollection hec, string tag, string className, out HtmlElement he)
        {
            
            for (int i = 0; i < hec.Count; i++)
            {
                he = hec[i];
                if (he.TagName != tag)
                    continue;
                if (he.GetAttribute("class") != className)
                    continue;
                
                return true;
            }
            he = null;
            return false;
        }*/
    }
}
namespace System.Reflection
{
    public static class MicrosanExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        public static string AdditionalInfo(this MemberInfo member)
        {
            string info = "";
            if (member.MemberType == MemberTypes.Method)
            {
                MethodInfo method = (member as MethodInfo);
                ParameterInfo[] pi = method.GetParameters();
                if (pi.Length == 0)
                    return "no parameters";
                info = "parameters:\n\n";
                for (int i = 0; i < pi.Length;  i++)
                {
                    info += pi[i].ToString() + "\n";
                }
            }
            else
            {
                info = member.MemberType + "\n" + member.Name + "\n";
            }
            return info;
        }
    }
}
namespace System.Drawing
{
    
    public static class Fonts
    {
        /// <summary>
        /// 
        /// </summary>
        public static Font CourierNew{
            get { return new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));}
        }
    }
}
namespace System.Windows.Forms
{
    public static class QuickDialogs
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="InitialDirectory"></param>
        /// <param name="Filter"></param>
        /// <param name="Title"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static bool SaveFile(string InitialDirectory, string Filter, string Title, out string filePath)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                filePath = null;
                sfd.InitialDirectory = InitialDirectory;
                sfd.OverwritePrompt = true;
                sfd.Filter = Filter;
                sfd.Title = Title;
                if (sfd.ShowDialog() == DialogResult.OK)
                    filePath = sfd.FileName;
            }
            return (filePath != null);
        }
    }
}
namespace CGS
{
    using System;
    using System.IO;
    /// <summary>
    /// Wraps another stream and provides reporting for when bytes are read or written to the stream.
    /// </summary>
    public class ProgressStream : Stream
    {
        #region Private Data Members
        private Stream innerStream;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new ProgressStream supplying the stream for it to report on.
        /// </summary>
        /// <param name="streamToReportOn">The underlying stream that will be reported on when bytes are read or written.</param>
        public ProgressStream(Stream streamToReportOn)
        {
            if (streamToReportOn != null)
            {
                this.innerStream = streamToReportOn;
            }
            else
            {
                throw new ArgumentNullException("streamToReportOn");
            }
        }
        #endregion

        #region Events
        /// <summary>
        /// Raised when bytes are read from the stream.
        /// </summary>
        public event ProgressStreamReportDelegate BytesRead;

        /// <summary>
        /// Raised when bytes are written to the stream.
        /// </summary>
        public event ProgressStreamReportDelegate BytesWritten;

        /// <summary>
        /// Raised when bytes are either read or written to the stream.
        /// </summary>
        public event ProgressStreamReportDelegate BytesMoved;

        protected virtual void OnBytesRead(int bytesMoved)
        {
            if (BytesRead != null)
            {
                var args = new ProgressStreamReportEventArgs(bytesMoved, innerStream.Length, innerStream.Position, true);
                BytesRead(this, args);
            }
        }

        protected virtual void OnBytesWritten(int bytesMoved)
        {
            if (BytesWritten != null)
            {
                var args = new ProgressStreamReportEventArgs(bytesMoved, innerStream.Length, innerStream.Position, false);
                BytesWritten(this, args);
            }
        }

        protected virtual void OnBytesMoved(int bytesMoved, bool isRead)
        {
            if (BytesMoved != null)
            {
                var args = new ProgressStreamReportEventArgs(bytesMoved, innerStream.Length, innerStream.Position, isRead);
                BytesMoved(this, args);
            }
        }
        #endregion

        #region Stream Members

        public override bool CanRead
        {
            get { return innerStream.CanRead; }
        }

        public override bool CanSeek
        {
            get { return innerStream.CanSeek; }
        }

        public override bool CanWrite
        {
            get { return innerStream.CanWrite; }
        }

        public override void Flush()
        {
            innerStream.Flush();
        }

        public override long Length
        {
            get { return innerStream.Length; }
        }

        public override long Position
        {
            get
            {
                return innerStream.Position;
            }
            set
            {
                innerStream.Position = value;
            }
        }

        public string ReadToEnd()
        {
            StreamReader sr = new StreamReader(innerStream);
            string str = sr.ReadToEnd();
            sr = null;
            return str;
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            var bytesRead = innerStream.Read(buffer, offset, count);

            OnBytesRead(bytesRead);
            OnBytesMoved(bytesRead, true);

            return bytesRead;
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            return innerStream.Seek(offset, origin);
        }

        public override void SetLength(long value)
        {
            innerStream.SetLength(value);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            innerStream.Write(buffer, offset, count);

            OnBytesWritten(count);
            OnBytesMoved(count, false);
        }

        public override void Close()
        {
            innerStream.Close();
            base.Close();
        }
        #endregion
    }

    /// <summary>
    /// Contains the pertinent data for a ProgressStream Report event.
    /// </summary>
    public class ProgressStreamReportEventArgs : EventArgs
    {
        /// <summary>
        /// The number of bytes that were read/written to/from the stream.
        /// </summary>
        public int BytesMoved { get; private set; }

        /// <summary>
        /// The total length of the stream in bytes.
        /// </summary>
        public long StreamLength { get; private set; }

        /// <summary>
        /// The current position in the stream.
        /// </summary>
        public long StreamPosition { get; private set; }

        /// <summary>
        /// True if the bytes were read from the stream, false if they were written.
        /// </summary>
        public bool WasRead { get; private set; }

        /// <summary>
        /// Default constructor for ProgressStreamReportEventArgs.
        /// </summary>
        public ProgressStreamReportEventArgs()
            : base() { }

        /// <summary>
        /// Creates a new ProgressStreamReportEventArgs initializing its members.
        /// </summary>
        /// <param name="bytesMoved">The number of bytes that were read/written to/from the stream.</param>
        /// <param name="streamLength">The total length of the stream in bytes.</param>
        /// <param name="streamPosition">The current position in the stream.</param>
        /// <param name="wasRead">True if the bytes were read from the stream, false if they were written.</param>
        public ProgressStreamReportEventArgs(int bytesMoved, long streamLength, long streamPosition, bool wasRead)
            : this()
        {
            this.BytesMoved = bytesMoved;
            this.StreamLength = streamLength;
            this.StreamPosition = streamPosition;
            this.WasRead = WasRead;
        }
    }

    /// <summary>
    /// The delegate for handling a ProgressStream Report event.
    /// </summary>
    /// <param name="sender">The object that raised the event, should be a ProgressStream.</param>
    /// <param name="args">The arguments raised with the event.</param>
    public delegate void ProgressStreamReportDelegate(ProgressStream progressStream, ProgressStreamReportEventArgs args);
}
