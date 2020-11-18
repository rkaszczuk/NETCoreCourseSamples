using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Threading;

namespace _12_Parallel.Samples
{
    public class ParallelForeachLoopSample
    {
        public static void ParallelForeachLoopSampleTest()
        {
            var intNumbers = Enumerable.Range(0, 50);
            Parallel.ForEach(intNumbers, (x) => Console.WriteLine(x));

            Parallel.ForEach(intNumbers, (x) => {
                Thread.Sleep(100);
                Console.WriteLine(x);
            });

            var parallelOptions = new ParallelOptions() { MaxDegreeOfParallelism = 2 };
            Parallel.ForEach(intNumbers, parallelOptions, (x) => {
                Thread.Sleep(100);
                Console.WriteLine(x);
            });
        }
    }
}
