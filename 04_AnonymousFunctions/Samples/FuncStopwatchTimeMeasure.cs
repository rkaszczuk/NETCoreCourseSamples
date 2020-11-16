using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace _04_AnonymousFunctions.Samples
{
    public class FuncStopwatchTimeMeasure
    {
        public static T RunWithLogTimeMeasure<T>(Func<T> func)
        {
            var sw = Stopwatch.StartNew();
            T result = func();
            sw.Stop();
            Debug.WriteLine(sw.ElapsedMilliseconds, "RunWithLogTimeMeasure");
            return result;
        }
        public static void RunWithLogTimeMeasure(Action func)
        {
            var sw = Stopwatch.StartNew();
            func();
            sw.Stop();
            Debug.WriteLine(sw.ElapsedMilliseconds, "RunWithLogTimeMeasure");
        }

        public static void FuncStopwatchTimeMeasureTest()
        {
            Debug.WriteLine(RunWithLogTimeMeasure(() => { 
                System.Threading.Thread.Sleep(1000); 
                return 10 * 50; }), "RunWithLogTimeMeasure<int>");

            RunWithLogTimeMeasure(() => System.Threading.Thread.Sleep(1000));
        }
    }
}
