using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace Kernel32_IniFileWrapper
{
    class IniFile   // revision 11
    {
        string Path;
        string EXE = System.IO.Path.GetFileNameWithoutExtension(System.Windows.Forms.Application.ExecutablePath);

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern long WritePrivateProfileString(string Section, string Key, string Value, string FilePath);

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern int GetPrivateProfileString(string Section, string Key, string Default, StringBuilder RetVal, int Size, string FilePath);

        public IniFile()
        {
            Path = new FileInfo(EXE + ".ini").FullName.ToString();
        }
        
        public IniFile(string IniPath)
        {
            Path = new FileInfo(IniPath + ".ini").FullName.ToString();
        }
        
        /// <summary>
        /// the section is the name of the exec name
        /// </summary>
        /// <param name="Key"></param>
        /// <returns></returns>
        public string Read(string Key)
        {
            StringBuilder RetVal = new StringBuilder(255);
            GetPrivateProfileString(EXE, Key, "", RetVal, 255, Path);
            return RetVal.ToString();
        }
        
        /// <summary>
        /// the section is the name of the exec name
        /// </summary>
        /// <param name="Key"></param>
        /// <param name="Value"></param>
        public void Write(string Key, string Value)
        {
            WritePrivateProfileString(EXE, Key, Value, Path);
        }
        
        /// <summary>
        /// the section is the name of the exec name
        /// </summary>
        /// <param name="Key"></param>
        public void DeleteKey(string Key)
        {
            Write(Key, null, EXE);
        }
        
        /// <summary>
        /// deletes the section with the name of the exec name
        /// </summary>
        public void DeleteSection()
        {
            Write(null, null, EXE);
        }
        
        /// <summary>
        /// the section is the name of the exec name
        /// </summary>
        /// <param name="Key"></param>
        /// <returns></returns>
        public bool KeyExists(string Key)
        {
            return Read(Key, null).Length > 0;
        }
        
        public string Read(string Key, string Section)
        {
            StringBuilder RetVal = new StringBuilder(255);
            GetPrivateProfileString(Section, Key, "", RetVal, 255, Path);
            return RetVal.ToString();
        }
        
        public void Write(string Key, string Value, string Section)
        {
            WritePrivateProfileString(Section, Key, Value, Path);
        }

        public void DeleteKey(string Key, string Section)
        {
            Write(Key, null, Section);
        }

        public void DeleteSection(string Section)
        {
            Write(null, null, Section);
        }

        public bool KeyExists(string Key, string Section)
        {
            return Read(Key, Section).Length > 0;
        }
    }
}
