using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace _10_Multithreading.Samples
{
    public class ThreadsPrioritySample
    {
        public static void ThreadsPrioritySampleTest()
        {
            //Priorytety wątków
            List<Thread> threads = new List<Thread>();
            for (int i = 0; i < 32; i++)
            {
                var prefix = $"Fibo from thread #{i}";
                var t = new Thread(() => FibonacciWorker(42, prefix));
                switch (i)
                {
                    case 10:
                        t.Priority = ThreadPriority.BelowNormal;
                        break;
                    case 11:
                        t.Priority = ThreadPriority.Normal;
                        break;
                    case 12:
                        t.Priority = ThreadPriority.AboveNormal;
                        break;
                    case 13:
                        t.Priority = ThreadPriority.Highest;
                        break;
                    default:
                        t.Priority = ThreadPriority.Lowest;
                        break;
                }
                threads.Add(t);
            }
            threads.ForEach(x => x.Start());
            threads.ForEach(x => x.Join());
        }
        public static void FibonacciWorker(int n, string prefix)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            var result = Fibonacci(n);
            Debug.WriteLine($"Fibonacci result: {result} in time: {stopwatch.ElapsedMilliseconds} ms", prefix);
        }
        public static int Fibonacci(int n)
        {
            if (n <= 1) return 1;
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }
    }
}
