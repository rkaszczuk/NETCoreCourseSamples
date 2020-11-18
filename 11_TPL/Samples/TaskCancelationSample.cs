using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _11_TPL.Samples
{
    public class TaskCancelationSample
    {
        public static int? SumNumbersWithCancelation(string taskName, int waitBetweenSumSeconds, 
            CancellationToken cancellationToken, params int[] numbers)
        {
            var result = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                Thread.Sleep(TimeSpan.FromSeconds(waitBetweenSumSeconds));
                result += numbers[i];
                Console.WriteLine("Current result: " + result);
                if (cancellationToken.IsCancellationRequested) 
                {
                    Console.WriteLine(taskName + " is cancelled");
                    return null; 
                }
            }
            return result;
        }
        public static void TaskCancelationSampleTest()
        {
            var cancellationTokenSource = new CancellationTokenSource();
            var t1 = Task<int>.Run(() => SumNumbersWithCancelation("T1", 1, 
                cancellationTokenSource.Token, 1, 2, 3, 4));
            Console.WriteLine("T1 result: " +t1.Result);

            var t2 = Task<int>.Run(() => SumNumbersWithCancelation("T2", 1,
                    cancellationTokenSource.Token, 1, 2, 3, 4));
            cancellationTokenSource.Cancel();
            Console.WriteLine("T2 result: " + t2.Result);

            //Jeżeli uzyjemy poprzedniej instancji cancellationTokenSource to już na starcie flaga
            //IsCancellationRequested będzie ustawiona na poprzednią wartość
            var t3 = Task<int>.Run(() => SumNumbersWithCancelation("T3", 1,
                    cancellationTokenSource.Token, 1, 2, 3, 4));
            Thread.Sleep(3000);
            cancellationTokenSource.Cancel();
            Console.WriteLine("T3 result: " + t3.Result);

            //Test z nową instancją CancellationTokenSource
            cancellationTokenSource = new CancellationTokenSource();
            var t4 = Task<int>.Run(() => SumNumbersWithCancelation("T4", 1,
                    cancellationTokenSource.Token, 1, 2, 3, 4));
            Thread.Sleep(2500);
            cancellationTokenSource.Cancel();
            Console.WriteLine("T4 result: " + t4.Result);

            //cancellationTokenSource ma wpływ tylko na task w którym jest obsługiwany
            cancellationTokenSource = new CancellationTokenSource();
            var t5 = new Task<int?>(() => SumNumbersWithCancelation("T5", 1,
                cancellationTokenSource.Token, 1, 2, 3, 4));
            var t5Continue = t5.ContinueWith(x => Console.WriteLine("T5 result: " + x.Result));
            t5.Start();
            Thread.Sleep(2500);
            cancellationTokenSource.Cancel();
            t5Continue.Wait();

        }
    }
}
