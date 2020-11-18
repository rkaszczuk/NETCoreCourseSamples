using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _12_Parallel.Samples
{
    public class ParallelForLoopSample
    {
        public static void ParallelForLoopSampleTest()
        {
            //Pętla współbieżna od 0 do 50
            //Wykonanie pętli zostanie podzielona na różne wątku
            Parallel.For(0, 50, x => Console.WriteLine(x));

            Console.WriteLine("----- version with sleep ------");
            //Wersja ze sleepem dla lepszego śledzenia
            Parallel.For(0, 20, x => 
            { 
                System.Threading.Thread.Sleep(5000);
                Console.WriteLine(x); 
            }
            );

            Console.WriteLine("----- version with break ------");
            //Break pętli
            Parallel.For(0, 100, (x, loopState) =>
            {
                System.Threading.Thread.Sleep(1000);
                //LowestBreakIteration - przechowuje informację przy jakim najniższym indeksie
                //wykonano break
                if (x > loopState.LowestBreakIteration)
                {
                    return;
                }            
                Console.WriteLine(x);
                if (x == 10)
                {
                    //break
                    loopState.Break();
                }
            }
            );
            Console.WriteLine("----- version with break and MaxDegreeOfParallelism = 2------");

            //Określamy że pętla będzie wykonywana jedynie w 2 wątkach
            //Łatwo można zauważyć że pętla zostanie pocięta na zbiory 0-49, 50-100
            var parallelOptions = new ParallelOptions() { MaxDegreeOfParallelism = 2 };
            Parallel.For(0, 100, parallelOptions, (x, loopState) =>
            {
                System.Threading.Thread.Sleep(200);
                //LowestBreakIteration - przechowuje informację przy jakim najniższym indeksie
                //wykonano break
                if (x > loopState.LowestBreakIteration)
                {
                    return;
                }
                Console.WriteLine(x);
                if (x == 60)
                {
                    //break
                    loopState.Break();
                }
            });

            Console.WriteLine("----- version with cancel and MaxDegreeOfParallelism = 2------");
            //Tym razem będziemy chcieli przerwać bez czekania na wykonanie wszystkich mniejszych od indeksu
            //Warto zauważyć że zmienne zewnętrzne są dostępne wewnątrz Parallel
            var cts = new CancellationTokenSource();
            parallelOptions = new ParallelOptions() { MaxDegreeOfParallelism = 2, CancellationToken = cts.Token };
            Parallel.For(0, 100, parallelOptions, (x, loopState) =>
            {
                System.Threading.Thread.Sleep(200);
                //wykonano cancel
                if (cts.IsCancellationRequested)
                {
                    return;
                }
                Console.WriteLine(x);
                if (x == 60)
                {
                    //cancel
                    cts.Cancel();
                }
            }
);

        }
    }
}
