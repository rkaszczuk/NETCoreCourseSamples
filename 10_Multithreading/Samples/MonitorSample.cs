using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace _10_Multithreading.Samples
{
    public class MonitorSample
    {
        private static int counter = 0;
        private readonly static object syncRoot = new object();
        private static Random random = new Random();

        public static void MonitorSampleTest()
        {
            //Wersja z lockiem
            var t1 = new Thread(() => IncrementCounterWithLock(1000000));
            t1.Start();
            IncrementCounterWithLock(1000000);
            t1.Join();
            Debug.WriteLine(counter, "IncrementCounterWithLock");
            counter = 0;

            //Wersja z monitorem
            var t2 = new Thread(() => IncrementCounterWithMonitor(1000000));
            t2.Start();
            IncrementCounterWithMonitor(1000000);
            t2.Join();
            Debug.WriteLine(counter, "IncrementCounterWithMonitor");
            counter = 0;

            //Wersja z monitorem z timeoutem
            var t3 = new Thread(() => IncrementCounterWithTimeoutMonitor(2000));
            t3.Start();
            IncrementCounterWithTimeoutMonitor(2000);
            t3.Join();
            Debug.WriteLine(counter, "IncrementCounterWithTimeoutMonitor");
            counter = 0;
        }


        public static void IncrementCounterWithLock(int incrementCount)
        {
            for (int i = 0; i < incrementCount; i++)
            {
                lock (syncRoot)
                {
                    counter++;
                }
            }
        }

        public static void IncrementCounterWithMonitor(int incrementCount)
        {
            for (int i = 0; i < incrementCount; i++)
            {
                //W rzeczywistości lock jest zamieniany na następujący Monitor
                bool lockWasTaken = false;
                var temp = syncRoot;
                try
                {
                    //Założenie "locka"
                    Monitor.Enter(temp, ref lockWasTaken);
                    counter++;
                }
                finally
                {
                    if (lockWasTaken)
                    {
                        //Zwolnienie "locka"
                        Monitor.Exit(temp);
                    }
                }
            }
        }

        public static void IncrementCounterWithTimeoutMonitor(int incrementCount)
        {
            for (int i = 0; i < incrementCount; i++)
            {
                //W rzeczywistości lock jest zamieniany na następujący Monitor
                bool lockWasTaken = false;
                var temp = syncRoot;
                try
                {
                    //Założenie "locka", który czeka 2 ms
                    Monitor.TryEnter(temp, 2, ref lockWasTaken);
                    System.Threading.Thread.Sleep(random.Next(0, 5));
                    counter++;
                }
                finally
                {
                    if (lockWasTaken)
                    {
                        //Zwolnienie "locka"
                        Monitor.Exit(temp);
                    }
                }
            }
        }
    }
}
