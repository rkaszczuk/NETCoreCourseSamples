using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _12_Parallel.Samples
{
    public class ParallelInvokeSample
    {
        private static void RunWithDelay(string taskName, int delayMs)
        {
            Console.WriteLine(taskName + " start");
            System.Threading.Thread.Sleep(delayMs);
            Console.WriteLine(taskName + " end");
        }
        public static void ParallelInvokeSampleTest()
        {
            //Wykonanie kilku Action współbieżnie
            //Parallel wstrzymuje wątek w którym zostało użyte (w tym wypadku wątek główny)
            System.Threading.Tasks.Parallel.Invoke(() => RunWithDelay("Run #1", 5000),
                () => RunWithDelay("Run #2", 5000),
                () => RunWithDelay("Run #3", 5000),
                () => RunWithDelay("Run #4", 5000),
                () => RunWithDelay("Run #5", 5000));
            Console.WriteLine("Parallel.Invoke end");

            //Ograniczenie ilości wykonywanych współbieżnie operacji do 2
            var parallelOptions = new ParallelOptions() { MaxDegreeOfParallelism = 2 };
            Parallel.Invoke(parallelOptions, () => RunWithDelay("Run #1", 5000),
                () => RunWithDelay("Run #2", 5000),
                () => RunWithDelay("Run #3", 5000),
                () => RunWithDelay("Run #4", 5000),
                () => RunWithDelay("Run #5", 5000));
            Console.WriteLine("Parallel.Invoke with MaxDegreeOfParallelism  end");
        }
    }
}
