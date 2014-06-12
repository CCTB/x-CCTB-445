using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace DesktopApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += Application_ThreadException;

            Application.Run(new MainForm());
        }

        const string message = "An unhandled exception occurred in the DesktopApp.{0}{1}";
        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            // Handle Exception
            string exceptionDetail = "Top-Level Exception: {1} {0}{0}Root Exception: {2}{0}{3}";
            Exception root = e.Exception;
            while (root.InnerException != null)
                root = root.InnerException;
            exceptionDetail = string.Format(exceptionDetail, Environment.NewLine, e.Exception.Message, root.Message, root.StackTrace);

            LogMessage(string.Format(message, Environment.NewLine, exceptionDetail));
        }

        // Source: http://www.dotnetspider.com/resources/34984-Log-error-messages-text-file-WINDOWS.aspx
        public static void LogMessage(string errorMessage)
        {
            try
            {
                //Logs the error in the Log file - separate file for each day
                string path = "Error" + DateTime.Today.ToString("dd-mm-yy") + ".txt";
                //Check for the file exists, or create a new file
                if (!File.Exists(System.IO.Path.GetFullPath(path)))
                {
                    File.Create(System.IO.Path.GetFullPath(path)).Close();
                }
                using (StreamWriter w = File.AppendText(System.IO.Path.GetFullPath(path)))
                {
                    // using the stream writer class write
                    // log message in a file.
                    w.WriteLine("\r\nLog Entry : ");
                    w.WriteLine("{0}", DateTime.Now.ToString(CultureInfo.InvariantCulture));
                    string err = "Error Message:" + errorMessage;
                    w.WriteLine(err);
                    w.WriteLine("____________________________________________________________________");
                    w.Flush();
                    w.Close();
                }
            }
            catch (Exception ex)
            {
                LogMessage(ex.StackTrace);
            }
        }
    }
}
