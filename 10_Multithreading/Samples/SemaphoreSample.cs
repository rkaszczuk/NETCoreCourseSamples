using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace _10_Multithreading.Samples
{
    public class SemaphoreSample
    {
        class NumberPool
        {
            public NumberPool(int poolSize)
            {
                for (int i = 0; i < poolSize; i++)
                {
                    pool.Add(i);
                }
            }
            private ConcurrentBag<int> pool = new ConcurrentBag<int>();
            public int GetFromPool()
            {
                if(!pool.TryTake(out var result))
                {
                    throw new Exception("Pool is empty!");
                }
                return result;
            }

            public void ReturnToPool(int value)
            {
                pool.Add(value);
            }

        }

        
        public static void SemaphoreSampleTest()
        {
            List<Thread> threads = new List<Thread>();
            var numberPool = new NumberPool(3);
            for (int i = 0; i < 5; i++)
            {
                var thread = new Thread(() =>
                {
                    try
                    {
                        var itemFromPool = numberPool.GetFromPool();
                        //Do some job
                        Thread.Sleep(2000);
                        Debug.WriteLine(itemFromPool, "itemFromPool");
                        numberPool.ReturnToPool(itemFromPool);
                    }
                    catch(Exception ex)
                    {
                        Debug.WriteLine(ex.Message, "ERROR");
                    }
                });
                threads.Add(thread);
            }
            threads.ForEach(x => x.Start());
            threads.ForEach(x => x.Join());
            threads.Clear();

            //Określamy wartośc początkową semafora (jaki licznik jest dostępny na start) oraz wartość maksymalną
            Semaphore semaphore = new Semaphore(3, 3);
            for (int i = 0; i < 5; i++)
            {
                var thread = new Thread(() =>
                {
                    try
                    {
                        //Czekamy aż w semaforze licznik będzie >0
                        semaphore.WaitOne();
                        var itemFromPool = numberPool.GetFromPool();
                        //Symulacja zadania
                        Thread.Sleep(2000);
                        Debug.WriteLine(itemFromPool, "itemFromPool with semaphore");
                        numberPool.ReturnToPool(itemFromPool);
                        //Zwlniamy 1 licznik do semafora
                        semaphore.Release(1);
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message, "ERROR");
                    }
                });
                threads.Add(thread);
            }
            threads.ForEach(x => x.Start());
            threads.ForEach(x => x.Join());
            threads.Clear();


            //W ramach semafora dowolny wątek może zdjąć dowolną wartość licznika
            for (int i = 0; i < 5; i++)
            {
                var thread = new Thread(() =>
                {
                    try
                    {
                        //Czekamy aż w semaforze licznik będzie >0
                        semaphore.WaitOne();
                        var itemFromPool = numberPool.GetFromPool();
                        //Symulacja zadania
                        Thread.Sleep(2000);
                        Debug.WriteLine(itemFromPool, "itemFromPool with Release(3) semaphore");
                        numberPool.ReturnToPool(itemFromPool);
                        //Zwlaniamy 3
                        //Jak przekroczymy maksymalną wartość dostaniemy exception
                        semaphore.Release(3);
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message, "ERROR");
                    }
                });
                threads.Add(thread);
            }
            threads.ForEach(x => x.Start());
            threads.ForEach(x => x.Join());
            threads.Clear();
        }

    }
}
