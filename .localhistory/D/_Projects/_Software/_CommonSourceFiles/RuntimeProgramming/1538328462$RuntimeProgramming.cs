/*
 * Created by SharpDevelop.
 * User: Microsan84
 * Date: 2017-05-11
 * Time: 12:29
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using Microsoft.CSharp;
using System.IO;
using System.Reflection;
using System.CodeDom.Compiler;

namespace Microsan
{
    /// <summary>
    /// Description of RuntimeProgramming.
    /// </summary>
    public class RuntimeProgramming
    {
        public const string RES_NAME_ROOT_CLASS_TEMPLATE = "Microsan.RuntimeProgramming.RootClass_Template.cs"; // embedded resource
        public const string RES_NAME_NEW_CLASS_TEMPLATE = "Microsan.RuntimeProgramming.NewClass_Template.cs"; // embedded resource

        public const string SOURCE_FILES_DIR_NAME = "RuntimeSourceFiles";
        public const string COMPILE_TEMP_OUT_DIR_NAME = "RuntimeCompiles";
        public const string RootNameSpace = "MyNamespace";
        public const string RootClassName = "RootClass";
        public const string RootMainMethodName = "RootMain";
        
        public List<SourceFile> sourceFiles;
        
        public static string RuntimeCompileOutputFolder = System.IO.Directory.GetCurrentDirectory() + "\\" + COMPILE_TEMP_OUT_DIR_NAME + "\\";
        public static string currDir = System.IO.Directory.GetCurrentDirectory() + "\\";
        public int RuntimeCompileCurrentIndex = 0;

        //public SourceCodeEditForm srcEditForm;

        public SourceCodeEditControl srcEditCtrl;
        
        public CSharpCodeProvider csSharpCodeProvider;
        public CompilerParameters compilerParams;
        
        public object RootObject = null;
        
        private Action<object> MainMethodDelegate;
        
        //public static System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SourceCodeEditForm));
            
        public void ListEmbeddedResources()
        {
            Assembly a = Assembly.GetExecutingAssembly();
            string[] ar = a.GetManifestResourceNames();

            srcEditCtrl.AppendLineToLog("embedded resources:");
            for (int i = 0; i < ar.Length; i++)
                srcEditCtrl.AppendLineToLog("  " + ar[i]);
        }

        public RuntimeProgramming(object rootObject)
        {
            if (rootObject == null)
                this.RootObject = this;
            else
                this.RootObject = rootObject;
            sourceFiles = new List<SourceFile>();
            
            if (!System.IO.Directory.Exists(currDir + SOURCE_FILES_DIR_NAME))
                System.IO.Directory.CreateDirectory(currDir + SOURCE_FILES_DIR_NAME);

            if (!System.IO.File.Exists(currDir + SOURCE_FILES_DIR_NAME + "\\" + RootClassName + ".cs"))
                CreateNewRootSourceFile();
                
            string[] files = System.IO.Directory.GetFiles(currDir + SOURCE_FILES_DIR_NAME, "*.cs");
            for (int i = 0; i < files.Length; i++)
            {
                sourceFiles.Add(new SourceFile(files[i], true));
            }
            EmptyRuntimeCompileOutputFolder();

            csSharpCodeProvider = new CSharpCodeProvider();
            compilerParams = new CompilerParameters();
            
            Init_CSSharpRuntimeCompiler();
            //InitScriptEditor();
            
        }
        
        public static string GetEmbeddedTemplateResource(string name)
        {
            Assembly a = Assembly.GetExecutingAssembly();
            using (Stream s = a.GetManifestResourceStream(name))
            using (StreamReader sr = new StreamReader(s))
            {
                return sr.ReadToEnd();
            }
        }

        private void CreateNewRootSourceFile()
        {
            SourceFile sf = new SourceFile(currDir + SOURCE_FILES_DIR_NAME + "\\" + RootClassName + ".cs");
            sf.Contents = GetEmbeddedTemplateResource(RES_NAME_ROOT_CLASS_TEMPLATE);
            if (sf.Contents.Length != 0)
                sf.SaveFile();
        }
        
        private void Init_CSSharpRuntimeCompiler()
        {
            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                try
                {
                    string location = assembly.Location;
                    if (!String.IsNullOrEmpty(location))
                    {
                        compilerParams.ReferencedAssemblies.Add(location);
                    }
                }
                catch (NotSupportedException)
                {
                    // this happens for dynamic assemblies, so just ignore it. 
                }
            }
            // Reference to System.Drawing library
            //compilerParams.ReferencedAssemblies.Add("System.Drawing.dll");
            // True - memory generation, false - external file generation
            compilerParams.GenerateInMemory = false;
            // True - exe file generation, false - dll file generation
            compilerParams.GenerateExecutable = false;
            compilerParams.IncludeDebugInformation = true;
            //compilerParams.CompilerOptions = " /doc:" + currentSourceFile + ".xml";
            // compilerParams.IncludeDebugInformation = true;
        }
        
        private void EmptyRuntimeCompileOutputFolder()
        {
            if (System.IO.Directory.Exists(RuntimeCompileOutputFolder))
            {
                string[] files = System.IO.Directory.GetFiles(RuntimeCompileOutputFolder);
                for (int i = 0 ; i < files.Length ; i++)
                {
                    System.IO.File.Delete(files[i]);
                }
            }
            else
            {
                System.IO.Directory.CreateDirectory(RuntimeCompileOutputFolder);
            }
        }
        /// <summary>
        /// Creates new instance of SourceCodeEditControl if not done before.
        /// <para>And initialize it.</para>
        /// </summary>
        public void InitScriptEditor_IfNeeded()
        {
            if (srcEditCtrl != null) return;
        	srcEditCtrl = new SourceCodeEditControl(FastColoredTextBoxNS.Language.CSharp);
            srcEditCtrl.Save += srcEditCtrl_Save;
            srcEditCtrl.Execute += srcEditCtrl_ExecuteCode;

            srcEditCtrl.btnClose.Visible = false;
            //srcEditCtrl.docked = true;
        }
        public void ShowScriptEditor()
        {
            srcEditCtrl.Show(sourceFiles, RootClassName + ".cs");

            
        }
        
        /*public void ShowScriptEditForm()
        {
            //srcEditCtrl.StartPosition = FormStartPosition.CenterScreen;
        }*/
        
        /*private void InitScriptEditForm()
        {
            
        }*/
        
        private void srcEditCtrl_Save(string fileName)
        {
            fileName = fileName.ToLower();
            for (int i = 0; i < sourceFiles.Count; i++)
            {
                if (sourceFiles[i].FileName.ToLower() == fileName)
                {
                    sourceFiles[i].SaveFile();
                }
            }
            //sourceCode = code;
            //System.IO.File.WriteAllText(currentSourceFile, sourceCode);
        }
        
        
        
        private void srcEditCtrl_ExecuteCode()
        {
            srcEditCtrl.ClearLog();
            
            if (compilerParams.GenerateExecutable)
                compilerParams.OutputAssembly = RuntimeCompileOutputFolder + "RC_" + RuntimeCompileCurrentIndex++ + ".exe";
            else
                compilerParams.OutputAssembly = RuntimeCompileOutputFolder + "RC_" + RuntimeCompileCurrentIndex++ + ".dll";
            
            string[] sourceFilePaths = new string[sourceFiles.Count];
            for (int i = 0; i < sourceFilePaths.Length; i++)
                sourceFilePaths[i] = sourceFiles[i].FullFilePath;
            
            CompilerResults results = csSharpCodeProvider.CompileAssemblyFromFile(compilerParams, sourceFilePaths);

            if (results.Errors.HasErrors)
            {
                //StringBuilder sb = new StringBuilder();

                foreach (CompilerError error in results.Errors)
                {
                    srcEditCtrl.AddToDgvLog(System.IO.Path.GetFileName(error.FileName), error.Line, error.Column, "Error (" + error.ErrorNumber + "): " + error.ErrorText);
                    //sb.AppendLine(String.Format("[ScriptError]\n  pos (row:{0},col:{1}) errNr:{2}; {3}", error.Line, error.Column, error.ErrorNumber, error.ErrorText));
                }
                //srcEditForm.AppendLineToLog(sb.ToString());
            }
            else
            {
                Type binaryFunction = results.CompiledAssembly.GetType(RootNameSpace + "." + RootClassName);
                if (binaryFunction == null) { srcEditCtrl.AddToDgvLog("", -1, -1, "error: " + RootNameSpace + "." + RootClassName + " is not found"); return; }

                MethodInfo methodInfo = binaryFunction.GetMethod(RootMainMethodName);
                if (methodInfo == null) { srcEditCtrl.AddToDgvLog("", -1, -1, "error: " + RootMainMethodName + " is not found"); return; }

                try
                {
                    MainMethodDelegate = (Action<object>)Delegate.CreateDelegate(typeof(Action<object>), methodInfo);
                
                    MainMethodDelegate(RootObject);
                }
                catch (Exception ex)
                {
                    srcEditCtrl.AddToDgvLog("", -1, -1, "Exception: " + ex);
                }
            }
        }
    }
    
    public class SourceFile
    {
        public string FileName = "";
        public string FileDirPath = "";
        public string Contents = "";
        public int editorSelectionStart = 0;
        public int editorSelectionLength = 0;
        public FastColoredTextBoxNS.Range editorSelectionRange = null;
        public int editorVerticalScrollValue = 0;
        public int editorHorizontalScrollValue = 0;
        
        public string FileNameWithoutExt
        {
            get { return System.IO.Path.GetFileNameWithoutExtension(FileName); }
        }
        
        public string FullFilePath 
        {
            get {
                if (FileDirPath == "")
                    return FileName;
                else
                    return FileDirPath + "\\" + FileName;
            }
            set{
                FileName = System.IO.Path.GetFileName(value);
                FileDirPath = System.IO.Path.GetDirectoryName(value);
            }
        }
        
        /// <summary>
        /// Creates new empty source file, it also creates an empty file on the disk 
        /// </summary>
        /// <param name="filePath"></param>
        public SourceFile(string filePath)
        {
            FullFilePath = filePath;
            System.IO.File.WriteAllText(filePath, "");
        }
        
        public SourceFile(string filePath, bool readFile)
        {
            FullFilePath = filePath;
            if (readFile)
                ReadFile();
        }
        
        public void ReadFile()
        {
            if (System.IO.File.Exists(FullFilePath))
            {
                Contents = System.IO.File.ReadAllText(FullFilePath);
            }
        }
        
        public void SaveFile()
        {
            System.IO.File.WriteAllText(FullFilePath, Contents);
        }
    }
}
