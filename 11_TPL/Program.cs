//#define USE_CONEMU
using _11_TPL.Samples;
using System;

namespace _11_TPL
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


            Console.ReadKey();
        }
    }
}
