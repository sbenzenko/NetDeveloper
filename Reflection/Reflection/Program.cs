using System;
using System.Configuration;
using System.IO;
using System.Reflection;

namespace Reflection
{
    class Program
    {
        public static LogWriter LogWriter { get; set; } = new LogWriter();

        static void Main(string[] args)
        {
            var filesDir = "files";
            if (ConfigurationManager.AppSettings["FilesDir"] != null)
                filesDir = ConfigurationManager.AppSettings["FilesDir"].ToString();
            var files = Directory.GetFiles(filesDir);

            ProcessFiles(files);

            DoSeparationLine();
            Console.ReadLine();
        }

        private static void ProcessFiles(string[] files)
        {
            foreach (var file in files)
            {
                DoSeparationLine();
                LogLine(0, $"Reading file: {file}");
                DoSeparationLine();
                LoadAssemblyAndShowPublicTypes(file);
            }
        }

        private static void LoadAssemblyAndShowPublicTypes(string file)
        {
            try
            {
                Assembly assembly = Assembly.LoadFrom(file);
                LogLine(0, $"Assembly: {assembly}");
                foreach (var type in assembly.GetExportedTypes())
                {
                    LogLine(0, "");
                    LogLine(2, $"Type: {type}");
                    const BindingFlags flags = BindingFlags.DeclaredOnly |
                       BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static;

                    foreach (var memberInfo in type.GetMembers(flags))
                    {
                        string typeName = memberInfo.GetType().Name.Replace("Runtime","").Replace("Rt","").Replace("Info","");
                        LogLine(3, $"{RightPad(typeName, 12)}: {memberInfo}");
                    }
                }
            }
            catch (Exception ex)
            {
                LogLine(0, $"An error has occurred:{ex.Message}");
            }
        }

        private static void DoSeparationLine()
        {
            LogLine(0, new string('=', 80));
        }

        private static string RightPad(string str, int size)
        {
            var padding = new string(' ', size - str.Length);
            return $"{str}{padding}";
        }

        private static void LogLine(int indent, string format, params object[] args)
        {
            var message = new string(' ', 2 * indent) + format;
            Console.WriteLine(message, args);
            LogWriter.Write(message);
        }
    }
}
