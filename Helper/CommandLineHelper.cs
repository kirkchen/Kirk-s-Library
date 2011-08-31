using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace KirkChen.Library.Helper
{
    public sealed class CommandLineHelper
    {        
        public static int ProcessFile(string filePath, string arguments)
        {
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = filePath; 
            start.Arguments = arguments;
            start.UseShellExecute = false;
            start.CreateNoWindow = true;

            using (Process process = Process.Start(start))
            {
                process.WaitForExit();

                return process.ExitCode == 0 ? 0 : 1;
            }
        }
    }
}
