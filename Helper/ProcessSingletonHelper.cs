using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace KirkChen.Library.Helper
{
    public sealed  class ProcessSingletonHelper
    {
        public static bool IsProcessing(ProcessCheckRange type)
        {
            string moduleName = Process.GetCurrentProcess().MainModule.ModuleName;
            string mutexRange = string.Empty;
            bool isCreated = false;

            switch (type)
            {
                case ProcessCheckRange.Global:
                default:
                    mutexRange = "Global\\";
                    break;
                case ProcessCheckRange.Local:
                    mutexRange = "Local\\";
                    break;
            }

            System.Threading.Mutex mutex = new System.Threading.Mutex(true, mutexRange + moduleName, out isCreated);

            return isCreated;
        }
    }

    public enum ProcessCheckRange
    {
        Global,
        Local
    }
}
