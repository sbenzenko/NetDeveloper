using System;
using System.Configuration;
using System.IO;

namespace Reflection
{
    class LogWriter
    {
        protected readonly object lockObj = new object();

        public string LogPath { get; set; }
        public string FileName { get; set; }

        public LogWriter()
        {
            if (ConfigurationManager.AppSettings["LogPath"] != null)
                LogPath = ConfigurationManager.AppSettings["LogPath"].ToString();

            var fileFormat = "\testFile.txt";
            if (ConfigurationManager.AppSettings["LogFileFormat"] != null)
                fileFormat = ConfigurationManager.AppSettings["LogFileFormat"].ToString();
            var fileName = string.Format(fileFormat, DateTime.Now);
            FileName = $"{LogPath}\\{fileName}";
        }

        public void Write(string s)
        {
            try
            {
                string logfile = FileName;
                lock (lockObj)
                {
                    using (StreamWriter streamWriter = new StreamWriter(logfile, true))
                    {
                        streamWriter.WriteLine(s);
                        streamWriter.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Log to file error: {ex}");
            }
        }
        
    }
}
