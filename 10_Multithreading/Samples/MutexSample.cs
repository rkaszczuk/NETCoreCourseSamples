using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace _10_Multithreading.Samples
{
    public class MutexSample
    {
        //Mutex pozwala na synchronizację wątków między procesami
        //W tym przykładzie pozwalamy na działanie jednego wątku w tym samym czasie
        public static void MutexSampleTest()
        {
            //Ustawienie true sprawi że będzie oczekiwał na zwolnienie murexu o tej nazwie - to samo co WaitOne()
            var mutex = new Mutex(false, "Only1Thread");
            mutex.WaitOne();
            Console.WriteLine("Only 1 thread can see this at the same time");
            Console.ReadKey();
            Console.WriteLine("Exiting...");
            mutex.ReleaseMutex();
        }
    }
}
