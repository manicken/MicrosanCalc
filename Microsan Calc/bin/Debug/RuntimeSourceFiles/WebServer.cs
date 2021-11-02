using System;
using System.Net;
using System.Threading;
using System.Linq;
using System.Text;
using System.IO;
using MyNamespace;

//using Microsan.FSdata.DomainIpUpdater;
 
namespace SimpleWebServer
{
    public class WebServer
    {
        public const string DEFAULT_PREFIX = "http://localhost:8080/";
        private readonly HttpListener _listener = new HttpListener();
        public Func<HttpListenerRequest, byte[]> ResponderHandler;
        public string RootPath = "";
        
        //private RootClass root;
 
        public WebServer(Func<HttpListenerRequest, byte[]> method, string rootPath, params string[] prefixes) : this(rootPath, prefixes)
        {
            this.ResponderHandler = method;
        }
        
        public WebServer(string rootPath, params string[] prefixes)
        {
            //root = rootClass;
            
            if (!HttpListener.IsSupported)
                throw new NotSupportedException(
                    "Needs Windows XP SP2, Server 2003 or later.");
            
                    //if (logForm == null)
                    //   throw new ArgumentException("logForm cannot be null");
                
            if (prefixes == null || prefixes.Length == 0)
            {
                Log.AddLine("warning, prefixes was not set!");
                prefixes = new string[] {DEFAULT_PREFIX};
            }
            Log.AddLine("prefixes:");
            foreach (string s in prefixes)
            {
                Log.AddLine(" " + s);
                _listener.Prefixes.Add(s);
            }
            // this.logForm = logForm;
            this.RootPath = rootPath;
            
            _listener.Start();
        }
 
         public void Run()
        {
            ThreadPool.QueueUserWorkItem((o) =>
            {
                Log.AddLine("Webserver running...");
                try
                {
                    while (_listener.IsListening)
                    {
                        ThreadPool.QueueUserWorkItem((c) =>
                        {
                            var ctx = c as HttpListenerContext;
                            try
                            {
                                //string rstr = default_Handler(ctx.Request);
                                //byte[] buf = Encoding.UTF8.GetBytes(rstr);
                                byte[] buf = default_Handler(ctx.Request);
                                ctx.Response.ContentLength64 = buf.Length;
                                ctx.Response.OutputStream.Write(buf, 0, buf.Length);
                            }
                            catch (Exception ex) { Log.AddLine("exception\n" + ex.ToString()); }
                            finally
                            {
                                // always close the stream
                                ctx.Response.OutputStream.Close();
                            }
                        }, _listener.GetContext());
                    }
                }
                catch (Exception ex) { Log.AddLine("exception\n" + ex.ToString()); }
            });
        }
         public void ShowRequestData (HttpListenerRequest request)
{
    if (!request.HasEntityBody)
    {
        Log.AddLine("No client data was sent with the request.");
        return;
    }
    System.IO.Stream body = request.InputStream;
    System.Text.Encoding encoding = request.ContentEncoding;
    System.IO.StreamReader reader = new System.IO.StreamReader(body, encoding);
    if (request.ContentType != null)
    {
        Log.AddLine("Client data content type "+ request.ContentType);
    }
    Log.AddLine("Client data content length "+ request.ContentLength64);
   
    Log.AddLine("Start of client data:");
    // Convert the data to a string and display it on the console.
    string s = reader.ReadToEnd();
    Log.AddLine(s);
    Log.AddLine("End of client data:");
    body.Close();
    reader.Close();
    // If you are finished with the request, it should be closed also.
}
        private byte[] default_Handler(HttpListenerRequest request)
        {
           // var context = listener.GetContext();
           // var request = context.Request;
            string text;
            using (var reader = new StreamReader(request.InputStream,
                                                 request.ContentEncoding))
            {
                text = reader.ReadToEnd();
            }
            if (request.ContentType != null)
    {
        Log.AddLine("Client data content type "+ request.ContentType);
    }
            //ShowRequestData(request);
            string WindowsFilePath = request.RawUrl.Replace('/', '\\');
            string urlParams = "";
            int index = WindowsFilePath.LastIndexOf('?');
            if (index != -1)
            {
                urlParams = WindowsFilePath.Substring(index + 1);
                WindowsFilePath = WindowsFilePath.Substring(0, index);
            }
            if (WindowsFilePath == "\\")
                WindowsFilePath = "\\index.htm";

            if (System.IO.File.Exists( RootPath + WindowsFilePath))
            {
                Log.AddLines(
                            "file found:" + RootPath + WindowsFilePath,
                            " url: " + WindowsFilePath,
                            " urlParams:" + urlParams,
                            " Request:" + text, 
                            "");
                return System.IO.File.ReadAllBytes( RootPath + WindowsFilePath);
            }
            Log.AddLines(
                        "file not found:" + RootPath + WindowsFilePath,
                        " url: " + WindowsFilePath,
                        " urlParams:" + urlParams,
                        " Request:" + text, 
                        "");

            if (ResponderHandler != null)
                return ResponderHandler(request);
            
            return Encoding.UTF8.GetBytes("<html><body>File not found:" + WindowsFilePath + "</body></html>");
        }
 
        public void Stop()
        {
            _listener.Stop();
            _listener.Close();
        }
    }
}