using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace _10_Multithreading.Samples
{
    public class IntLockingSample
    {
        private static int counter = 0;
        //Zmienna używana to lockowania powinna być immutable - żeby nikt nie zmienił referencji
        private readonly static object syncRoot = new object();
        //Volatile sprawia że operacje zapisu/odczytu są thread-safe
        private volatile static int counterVolatile = 0;

        //Nie jest możliwe używanie volatile z typami double / long
        //Obsługiwane typy to typy referencyjne, sbyte, byte, short, ushort, int, uint, char, float, bool, enum
        //ERROR
        //private volatile static double volatileCounterDouble = 0;

        public static void LockingSampleTest()
        {
            //Skutek braku lockowania zmiennych wartościowych
            var t1 = new Thread(() => IncrementCounterWithoutLock(1000000));
            t1.Start();
            IncrementCounterWithoutLock(1000000);
            t1.Join();
            Debug.WriteLine(counter, "IncrementCounterWithoutLock");
            counter = 0;

            //Wersja z lockiem
            var t2 = new Thread(() => IncrementCounterWithLock(1000000));
            t2.Start();
            IncrementCounterWithLock(1000000);
            t2.Join();
            Debug.WriteLine(counter, "IncrementCounterWithLock");
            counter = 0;

            //Wersja z volatile
            var t3 = new Thread(() => IncrementCounterWithVolatile(1000000));
            t3.Start();
            IncrementCounterWithVolatile(1000000);
            t3.Join();
            Debug.WriteLine(counterVolatile, "IncrementCounterWithVolatile");

            //Wersja z Interlocked
            var t4 = new Thread(() => IncrementCounterWithInterlocked(1000000));
            t4.Start();
            IncrementCounterWithInterlocked(1000000);
            t4.Join();
            Debug.WriteLine(counter, "IncrementCounterWithInterlocked");
        }

        public static void IncrementCounterWithoutLock(int incrementCount)
        {
            for (int i = 0; i < incrementCount; i++)
            {
                //Nie jest thread-safe - nie jest operacją atomową!
                //counter = counter + 1
                //pobrana wartośc counter może się zmienić przed przypisaniem nowej wartości
                counter++;
            }           
        }
        public static void IncrementCounterWithLock(int incrementCount)
        {
            for (int i = 0; i < incrementCount; i++)
            {
                //Tylko 1 wątek może być w locku
                //Lock pod spodem zamieniany jest na Monitor
                lock (syncRoot)
                {
                    counter++;
                }
            }
        }
        public static void IncrementCounterWithVolatile(int incrementCount)
        {
            for (int i = 0; i < incrementCount; i++)
            {
                //volatile nie pomoże poniewać odczyt i zapis to osobne instrukcje
                //volatile pozwala również na dostęp do realnej wartości z pominięciem cache procesora
                counterVolatile++;
            }
        }

        public static void IncrementCounterWithInterlocked(int incrementCount)
        {
            for (int i = 0; i < incrementCount; i++)
            {
                Interlocked.Increment(ref counter);
                Interlocked.Decrement(ref counter);
                Interlocked.Add(ref counter, 1);
                //Atomowa operacje modyfikacji danych
                //Ustawienia zmienną counter na 10 i zwraca poprzednią wartość
                //var oldValue = Interlocked.Exchange(ref counter, 10);
            }
        }

    }
}
