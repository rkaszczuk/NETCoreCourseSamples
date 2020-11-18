using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _11_TPL.Samples
{
    public class AsyncAwaitVoidSample
    {
        private async static void RunWithDelay(string name, int delayMs)
        {
            Console.WriteLine(name + " start");
            Thread.Sleep(delayMs);
            Console.WriteLine(name + " done");
        }

        private async static void RunAwaitWithDelay(string name, int delayMs)
        {
            Console.WriteLine(name + " start");
            //await można użyć tylko na async/Task
            //await Thread.Sleep(delayMs);

            //Mamy helper dla sleepa w ramach taska
            await Task.Delay(delayMs);
            Console.WriteLine(name + " done");
        }

        //Nie robimy return dla Task
        //Metoda wygląda identycznie jak dla void, ale zwraca uchwyt na swoje wykonanie
        private async static Task RunRealAwaitWithDelay(string name, int delayMs)
        {
            Console.WriteLine(name + " start");
            //await można użyć tylko na async/Task
            //await Thread.Sleep(delayMs);

            //Mamy helper dla sleepa w ramach taska
            await Task.Delay(delayMs);
            Console.WriteLine(name + " done");
        }


        //async może zwracać wyłącznie void, Task, Task<T>
        //ERROR
        //private async static string RunResultWithDelay(string name, int delayMs)
        //{
        //    Console.WriteLine(name + " start");
        //    Thread.Sleep(delayMs);
        //    return name + " done";
        //}

        public async static void AsyncAwaitVoidSampleTest()
        {
            //Zostanie wykonane synchronicznie, bo RunWithDelay nie ma await
            RunWithDelay("Run #1", 2000);
            Console.WriteLine("After Run #1");

            //Zostanie wykonane asynchronicznie, ale nie poczeka na RunAwaitWithDelay
            //Funkcje async void są typu fire and forgot
            RunAwaitWithDelay("Run #2", 2000);
            Console.WriteLine("After Run #2");

            //Zostanie wykonane asynchronicznie i poczeka na RunRealAwaitWithDelay
            RunRealAwaitWithDelay("Run #3", 2000).Wait();
            Console.WriteLine("After Run #3");

            //Jeśli metoda jest async to możemy zamiast wait uzyć await
            await RunRealAwaitWithDelay("Run #4", 2000);
            Console.WriteLine("After Run #4");

            //Możemy też zrobić coś w trakcie czekania
            var run4Task = RunRealAwaitWithDelay("Run #4", 2000);
            Thread.Sleep(500);
            Console.WriteLine("Do some job while Run #4...");
            await run4Task;
            Console.WriteLine("After Run #4");
        }
    }
}
