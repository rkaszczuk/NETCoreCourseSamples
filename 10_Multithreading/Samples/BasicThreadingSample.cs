using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace _10_Multithreading.Samples
{
    public class BasicThreadingSample
    {
        public static void BasicThreadingSampleTest()
        {
            //Wykonanie logiki w dwóch wątkach - głównym oraz t1
            Thread t1 = new Thread(() => PrintNumbersWithSleep(10, "Number from Thread1"));
            t1.Start();
            PrintNumbersWithSleep(10, "Number from main thread");

            //Poczekanie na zakończenie wątku t2 w ramach głównego wątka
            Thread t2 = new Thread(() => PrintNumbersWithSleep(10, "Number from Thread2"));
            t2.Start();
            t2.Join();
            Debug.WriteLine("T2 Completed");

            //Próba zatrzymania wątka - Abort
            Thread t3 = new Thread(() => PrintNumbersWithSleep(10, "Number from Thread3"));
            t3.Start();
            System.Threading.Thread.Sleep(2);
            try
            {
                //na .NET Core Abort jest "obsolete" powoduje exception - NotSupportedPlatform
                //W starszych wersjach .NET Framework przerwanie Abort działało tylko w ramach kodu zarządzanego
                //Jeżeli wykonywany był kod niezażądzalny to przerwanie następowało w momencie przywrócenie kontroli wykonania w CLR
                t3.Abort();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            t3.Join();

            //Próba zatrzymania wątka - Interrupt
            Thread t4 = new Thread(() => PrintNumbersWithSleep(10, "Number from Thread4"));
            t4.Start();
            System.Threading.Thread.Sleep(10);
            //Interrupt zadziała tylko jeżeli wątek wejdzie w jeden ze stanów - Wait, Sleep, Join
            //Rzuca wyjątek w momencie zastopowania
            t4.Interrupt();
            t4.Join();

            //Próba zatrzymania wątka - Interrupt
            //Wątek bez sleepa
            Thread t5 = new Thread(() => PrintNumbersWOSleep(30, "Number from Thread5"));
            t5.Start();
            System.Threading.Thread.Sleep(1);
            t5.Interrupt();
            Debug.WriteLine("Interrupt Thread5");
            t5.Join();

            //Stan wątku
            Thread t6 = new Thread(() => PrintNumbersWithSleep(10, "Number from Thread6"));
            Debug.WriteLine(t6.ThreadState.ToString(), "T6 State");
            t6.Start();
            while (t6.ThreadState != System.Threading.ThreadState.Stopped)
            {
                Debug.WriteLine(t6.ThreadState.ToString(), "T6 State");
            }

            //Wątki Foreaground and background 
            Thread t7 = new Thread(() => PrintNumbersWithSleep(30, "Number from Thread7"));
            //IsBackground określa że wątek główny nie będzie czekał na zakończenie tego wątku
            t7.IsBackground = true;
            Thread t8 = new Thread(() => PrintNumbersWithSleep(15, "Number from Thread8"));
            t7.Start();
            t8.Start();


        }

        public static void PrintNumbersWithSleep(int limit, string prefix)
        {
            try
            {
                for (int i = 0; i < limit; i++)
                {
                    System.Threading.Thread.Sleep(1);
                    Debug.WriteLine(i, prefix);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public static void PrintNumbersWOSleep(int limit, string prefix)
        {
            try
            {
                for (int i = 0; i < limit; i++)
                {
                    Debug.WriteLine(i, prefix);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }


    }
}
