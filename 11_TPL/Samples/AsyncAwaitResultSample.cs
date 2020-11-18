using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _11_TPL.Samples
{
    public class AsyncAwaitResultSample
    {
        //async musi zwracać Task<T>
        //private async static string GetStringWithDelay(string name, int delayMs)
        //{
        //    Console.WriteLine(name + " start");
        //    Thread.Sleep(delayMs);
        //    return name + " done";
        //}

        //Nie musimy zwracać Task<string> - jak oznaczymy async to automatycznie "opakuje" wynik
        //Nie ma wait - będzie synchronicznie
        private async static Task<string> GetStringWithDelay(string name, int delayMs)
        {
            Console.WriteLine(name + " start");
            Thread.Sleep(delayMs);
            return name + " done";
        }

        private async static Task<string> AsyncGetStringWithDelay(string name, int delayMs)
        {
            Console.WriteLine(name + " start");
            await Task.Delay(delayMs);
            return name + " done";
        }
        public async static void AsyncAwaitResultSampleTest()
        {
            //GetStringWithDelay nie ma await - będzie synchronicznie
            //r1 będzie taskiem
            var r1 = GetStringWithDelay("Run #1", 3000);
            Console.WriteLine("After Run #1");
            //Dopiero tutaj będziemy mieli wartość
            var result1 = r1.Result;
            Console.WriteLine("After Run #1 2"); 
            Console.WriteLine(result1);

            //Wersja asynchroniczna
            //r2 będzie taskiem
            var r2 = AsyncGetStringWithDelay("Run #2", 3000);
            Console.WriteLine("After Run #2");
            //Dopiero tutaj będziemy mieli wartość
            //I tutaj też będzie wait
            var result2 = r2.Result;
            Console.WriteLine("After Run #2 2");
            Console.WriteLine(result2);

            //Wersja asynchroniczna
            //result3 będzie wynikiem
            //i tutaj też będzie czekało na wynik
            var result3 = await AsyncGetStringWithDelay("Run #3", 3000);
            Console.WriteLine("After Run #3");
            Console.WriteLine("After Run #3 2");
            Console.WriteLine(result3);

            //Wersja asynchroniczna
            //r4 będzie taskiem
            var r4 = AsyncGetStringWithDelay("Run #4", 3000);
            Console.WriteLine("After Run #4");
            //Pobranie wartości za pomocą await
            var result4 = await r4;
            Console.WriteLine("After Run #4 2");
            Console.WriteLine(result4);
        }

    }
}
