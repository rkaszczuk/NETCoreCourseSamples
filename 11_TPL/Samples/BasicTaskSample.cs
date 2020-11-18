using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _11_TPL.Samples
{
    public class BasicTaskSample
    {
        private static void SampleTaskMethod(string name)
        {
            Console.WriteLine($"Task {name} with ThreadId: {Thread.CurrentThread.ManagedThreadId}. Is pool thread? {Thread.CurrentThread.IsThreadPoolThread}. Is backgroud? {Thread.CurrentThread.IsBackground}");
        }

        private static string SampleTaskMethodWithResult(string taskName, string valueToUpper)
        {
            Console.WriteLine($"Task {taskName} with ThreadId: {Thread.CurrentThread.ManagedThreadId}. Is pool thread? {Thread.CurrentThread.IsThreadPoolThread}. Is backgroud? {Thread.CurrentThread.IsBackground}");
            System.Threading.Thread.Sleep(3000);
            return valueToUpper.ToUpper();
        }

        public static void  BasicTaskSampleTest()
        {
            //Tworzenie nowego taska i jego uruchamianie
            var t1 = new System.Threading.Tasks.Task(() => SampleTaskMethod("T1"));
            t1.Start();
            //Krótsza wersja
            var t2 = Task.Run(() => SampleTaskMethod("T2"));
            //I wersja z wykorzystaniem factory
            //efekt będzie taki sam jeśli nie krozystamy z własnego schedulera
            //Domyślnym schedulerem jest ThreadPoolTaskScheduler
            //Jest on oparty o póle wątków ThreadPool
            //W ramach ThreadPool istnieją dwie kolejki Global - przechowujaca kolejkę wątków głównych
            //Local - przechowujacą kolejkę wątków zależnych
            var t3 = Task.Factory.StartNew(() => SampleTaskMethod("T3"));

            //Możemy dać informację do Schedulera że tak będzie długi, 
            //żeby odpowiednie zoptymalizował zasoby - nie wykorzystuje wtedy póli wątków
            var t4 = Task.Factory.StartNew(() => SampleTaskMethod("T4"), TaskCreationOptions.LongRunning);

            //Czekamy na wykonanie - taski są backgroud, więc zostaną obite gdy zakończy się główny wątek
            System.Threading.Thread.Sleep(1000);

            //Task zwracający rezultat
            Task<string> t5 = new Task<string>(() => SampleTaskMethodWithResult("T5", "ala ma kota"));
            t5.Start();
            Console.WriteLine("Start waiting...");
            //Czekamy na wynik...
            var result5 = t5.Result;
            Console.WriteLine($"Task done with result {result5}");


            //Task zwracający rezultat
            Task<string> t6 = new Task<string>(() => SampleTaskMethodWithResult("T6", "kot ma ale"));
            t6.Start();
            Console.WriteLine("Start waiting...");
            //Task jest asynchroniczny - możemy działac z głównego wątku
            Console.WriteLine("Some job while wating...");
            //Czekamy na wynik...
            var result6 = t6.Result;
            Console.WriteLine($"Task done with result {result6}");

            //Task zwracający rezultat
            Task<string> t7 = new Task<string>(() => SampleTaskMethodWithResult("T7", "kot"));
            //Task odpalony synchronicznie - dopóki się nie skończy to nie pójdzie dalej
            t7.RunSynchronously();
            Console.WriteLine("Start waiting...");
            Console.WriteLine("Some job while wating...");
            //Czekamy na wynik...
            var result7 = t7.Result;
            Console.WriteLine($"Task done with result {result7}");

            //Task zwracający rezultat
            Task<string> t8 = new Task<string>(() => SampleTaskMethodWithResult("T8", "ala"));
            //Task odpalony synchronicznie - dopóki się nie skończy to nie pójdzie dalej
            t8.Start();
            Console.WriteLine("Start waiting...");
            //Czekamy na wykonanie..
            t8.Wait();
            Console.WriteLine("Some job while wating...");
            var result8 = t8.Result;
            Console.WriteLine($"Task done with result {result8}");
        }
    }
}
