using System;
using System.IO;

namespace Contracts.Utils
{
    public static class Logger
    {
        private static string fullPath = @"C:\Users\Administrator\Desktop\Logs\Log.txt";

        public static void WriteLog(string msg)
        {
            File.AppendAllText(fullPath, Environment.NewLine);
            File.AppendAllText(fullPath, msg);
        }
    }
}
