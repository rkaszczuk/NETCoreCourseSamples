using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace _10_Multithreading.Samples
{
    //Żeby uzyskać odpowiedni resultat trzeba odpalić aplikację w trybie Release - na Debug wszystko będzie ok
    public class VolatileSample
    {
        private static bool whileInProgress = true;
        private volatile static bool whileInProgressVolatile = true;

        //Problem wiąże się z cachowanie wartości whileInProgress w ramach wątku/rdzenia dla cache procesora lub cache CLR
        public static void VolatileSampleEndlessLoop()
        {
            var t = new Thread(() =>
            {
                System.Threading.Thread.Sleep(1000);
                whileInProgress = false;
                Console.WriteLine("whileInProgress = false");
            });
            t.Start();

            while (whileInProgress)
            {

            }
            Console.WriteLine("END");
        }

        public static void VolatileSampleVolatileLoop()
        {
            var t = new Thread(() =>
            {
                System.Threading.Thread.Sleep(1000);
                whileInProgressVolatile = false;
                Console.WriteLine("whileInProgressVolatile = false");
            });
            t.Start();

            while (whileInProgressVolatile)
            {

            }
            Console.WriteLine("END");
        }

    }
}
