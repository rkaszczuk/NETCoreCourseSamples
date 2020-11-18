using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace _11_TPL.Samples
{
    public class CombineTaskSample
    {
        private static void SampleTaskMethodWithDelay(string name, int delayMs)
        {            
            Console.WriteLine($"Task {name} with ThreadId: {Thread.CurrentThread.ManagedThreadId}. Is pool thread? {Thread.CurrentThread.IsThreadPoolThread}. Is backgroud? {Thread.CurrentThread.IsBackground}");
            System.Threading.Thread.Sleep(delayMs);
            Console.WriteLine($"Task {name} done");
        }
        private static string SampleTaskMethodWithResult(string taskName, string valueToUpper)
        {
            Console.WriteLine($"Task {taskName} with ThreadId: {Thread.CurrentThread.ManagedThreadId}. Is pool thread? {Thread.CurrentThread.IsThreadPoolThread}. Is backgroud? {Thread.CurrentThread.IsBackground}");
            System.Threading.Thread.Sleep(3000);
            return valueToUpper.ToUpper();
        }

        private static int SumWithDelay(int x, int y, int delayMs)
        {
            Console.WriteLine($"{x} + {y}");
            System.Threading.Thread.Sleep(delayMs);
            return x + y;
        }

        public static void CombineTaskSampleTest()
        {
            var t1 = new Task(() => SampleTaskMethodWithDelay("T1", 2000));
            var t2 = new Task(() => SampleTaskMethodWithDelay("T2", 1000));
            t1.Start();
            t2.Start();
            //Czekamy na wykonanie obu tasków
            Task.WaitAll(t1, t2);
            Console.WriteLine($"All tasks done");           

            var t3 = new Task<string>(() => SampleTaskMethodWithResult("T3","ala ma kota"));
            //Dodajemy akcję, która będzie wykonana po t3
            var continueTask3 = t3.ContinueWith(x => {
                Console.WriteLine($"Continue T3 with ThreadId: {Thread.CurrentThread.ManagedThreadId}. Is pool thread? {Thread.CurrentThread.IsThreadPoolThread}. Is backgroud? {Thread.CurrentThread.IsBackground}");
                System.Threading.Thread.Sleep(3000);
                Console.WriteLine(x.Result);
                });

            //Możemy też dopiąc się do awaitera
            continueTask3.GetAwaiter().OnCompleted(() =>
            {
                Console.WriteLine($"OnCompleted continueTask with ThreadId: {Thread.CurrentThread.ManagedThreadId}. Is pool thread? {Thread.CurrentThread.IsThreadPoolThread}. Is backgroud? {Thread.CurrentThread.IsBackground}");
                System.Threading.Thread.Sleep(3000);
                Console.WriteLine("OnCompleted - Done");
            });

            t3.Start();
            //Nie poczeka na continueTask - to nowy task, bazujący na wyniku T3
            //t3.Wait();
            //Musimy czekać na continueTask
            continueTask3.Wait();

            //Hierarchia tasków, które przekazują sobie wyniki swoich wykonań
            var t4 = new Task<int>(() => SumWithDelay(5, 10, 1000));
            var taskHierarchy = t4
                .ContinueWith<int>(x => SumWithDelay(x.Result, 10, 1000))
                .ContinueWith<int>(x => SumWithDelay(x.Result, 10, 1000))
                .ContinueWith<int>(x => SumWithDelay(x.Result, 10, 1000));
            t4.Start();
            Console.WriteLine($"taskHierarchy result: {taskHierarchy.Result}");

            //Continue w przypadku ukończenia dowolnego tasku
            var t5 = new Task<int>(() => SumWithDelay(2, 3, 1000));
            var t6 = new Task<int>(() => SumWithDelay(5, 15, 5000));
            t5.Start();
            t6.Start();
            //WhenAny pozwala na dopięcie akcji, która zostanie wykonana dla pierwszego wykonanego
            //taska z przekazanych tasków
            var whenAny = Task.WhenAny(t5, t6).ContinueWith((x) => Console.WriteLine(x.Result.Result));
            //WhenAll pozwala na dopięcie akcji, która zostanie wykonana po wszystkich przekazanych tasków
            //Dostajemy dostęp do wszystkich rezultatów tasków
            var whenAll = Task.WhenAll(t5, t6).ContinueWith((x) =>
            {
                var result = 1;
                foreach(var taskResult in x.Result)
                {
                    result = result * taskResult;
                }
                Console.WriteLine("WhenAll Result: " + result);
            });

            //Ale dalej musimy czekać na wykonanie :)
            Task.WaitAll(whenAny, whenAll);
        }
    }
}
