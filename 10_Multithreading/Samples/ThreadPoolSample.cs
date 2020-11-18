using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Diagnostics;

namespace _10_Multithreading.Samples
{
    public class ThreadPoolSample
    {
        public static void ThreadPoolSampleTest()
        {
            //ThreadPool to globalna póla wątków dostępna w ramach procesu aplikacji
            //SetMaxThreads pozwala określić liczbę wątków działających współbieżnie w ramach póli
            //Drugi parametr określa dostępną liczbę asynchronicznych procesów IO
            //Jeżeli liczba rdzeni (Environment.ProcessorCount) jest mniejsza od przekazanej liczby to zmiana się nie powiedzie
            ThreadPool.SetMaxThreads(2,2);
            Debug.WriteLine(Environment.ProcessorCount);
            ThreadPool.SetMaxThreads(Environment.ProcessorCount, Environment.ProcessorCount);

            //CountdownEvent -wysyła sygnał gdy osiągnie wartośc 0
            CountdownEvent countdownEvent = new CountdownEvent(1);
            for (int i = 0; i < 20; i++)
            {
                //Zakolejkowanie wykonania operacji w ramach póli wątków
                var text = $"Hello from thread #{i}";
                ThreadPool.QueueUserWorkItem((x) => {
                    countdownEvent.AddCount();
                    Debug.WriteLine(text);
                    System.Threading.Thread.Sleep(3000);
                    countdownEvent.Signal();
                    });
            }

            //W związku z tym że ThreadPool wykonuje zadania w tle musimy na nią samodzielnie poczekać.
            System.Threading.Thread.Sleep(100);
            countdownEvent.Signal();
            countdownEvent.Wait();
            Debug.WriteLine("Done");
        }
    }
}
