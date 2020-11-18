using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace _10_Multithreading.Samples
{

    public class ListLockingSample
    {
        private static Random random = new Random();
        private readonly static object syncRoot = new object();

        private static List<char> text = new List<char>();
        private static System.Collections.Concurrent.ConcurrentBag<char> concurrentText = new System.Collections.Concurrent.ConcurrentBag<char>();

        public static void ListLockingSampleTest()
        {
            //Skutek braku lockowania w liście            
            var t1 = new Thread(() => AddRandomLettersWithoutLock(1000000));
            var sw1 = Stopwatch.StartNew();
            t1.Start();
            AddRandomLettersWithoutLock(1000000);
            t1.Join();
            sw1.Stop();
            Debug.WriteLine(text.Count, "AddRandomLettersWithoutLock");
            Debug.WriteLine(sw1.ElapsedMilliseconds, "AddRandomLettersWithoutLock");
            text.Clear();

            //Wersja z lockiem
            var t2 = new Thread(() => AddRandomLettersWithLock(1000000));
            var sw2 = Stopwatch.StartNew();
            t2.Start();
            AddRandomLettersWithLock(1000000);
            t2.Join();
            sw2.Stop();
            Debug.WriteLine(text.Count, "AddRandomLettersWithLock");
            Debug.WriteLine(sw2.ElapsedMilliseconds, "AddRandomLettersWithLock");
            text.Clear();

            //Wersja z ConcurrentBag
            var t3 = new Thread(() => AddRandomLettersWithConcurrentBag(1000000));
            var sw3 = Stopwatch.StartNew();
            t3.Start();
            AddRandomLettersWithConcurrentBag(1000000);
            t3.Join();
            sw3.Stop();
            Debug.WriteLine(concurrentText.Count, "AddRandomLettersWithConcurrentBag");
            Debug.WriteLine(sw3.ElapsedMilliseconds, "AddRandomLettersWithConcurrentBag");
            concurrentText.Clear();

        }

        private static void AddRandomLettersWithoutLock(int lettersCount)
        {
            for (int i = 0; i < lettersCount; i++)
            {
                try
                {
                    var @char = (char)random.Next(65, 90);
                    text.Add(@char);
                }
                catch(Exception ex)
                {
                    //Okazjonalnie może sypnać błędem - np. przy powiększaniu listy
                    Debug.WriteLine(ex);
                }
            }
        }

        private static void AddRandomLettersWithConcurrentBag(int lettersCount)
        {
            for (int i = 0; i < lettersCount; i++)
            {
                var @char = (char)random.Next(65, 90);
                concurrentText.Add(@char);
            }
        }

        private static void AddRandomLettersWithLock(int lettersCount)
        {
            for (int i = 0; i < lettersCount; i++)
            {
                var @char = (char)random.Next(65, 90);
                lock (syncRoot)
                {
                    text.Add(@char);
                }
            }
        }
    }
}
