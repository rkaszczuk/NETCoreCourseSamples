#define USE_CONEMU
using _05_DynamicObjects.Exercises;
using _05_DynamicObjects.Samples;
using System;
using System.Diagnostics;

namespace _05_DynamicObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            #region ConEMU
#if USE_CONEMU
            ProcessStartInfo pi = new ProcessStartInfo(@"C:\Program Files\ConEmu\ConEmu\ConEmuC.exe", "/AUTOATTACH");
            pi.CreateNoWindow = false;
            pi.UseShellExecute = false;
            Process.Start(pi);
#endif
            #endregion

            #region Trace to console
            //Zrzucanie Trace/Debug do konsoli
            TextWriterTraceListener consoleTraceWriter = new
                    TextWriterTraceListener(System.Console.Out);
            Trace.Listeners.Add(consoleTraceWriter);
            #endregion

            //Start code below

            DynamicMath dynamicMath = new DynamicMath();
            Debug.WriteLine((string)dynamicMath.Sum(10, 5).ToString());
            Debug.WriteLine((string)dynamicMath.Multi(10, 2.5).ToString());
            Debug.WriteLine((string)dynamicMath.Sum("10", 2.5).ToString());


            Console.ReadKey();

        }
    }
}
