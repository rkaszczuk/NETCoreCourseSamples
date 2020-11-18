using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace _10_Multithreading.Samples
{
    public class ResetEventSample
    {
        private static string text = String.Empty;
        public static void ResetEventSampleTest()
        {
            //ManualResetEvent - nie resetuje samodzielnie sygnału po jego ustawieniu
            ManualResetEvent preparedTextManual = new ManualResetEvent(false);
            List<Thread> threads = new List<Thread>();

            for (int i = 0; i < 3; i++)
            {
                var thread = new Thread(() =>
                {
                    //Czekamy aż dostaniemy sygnał że tekst jest przygotowany
                    Debug.WriteLine("Wating for text...");
                    preparedTextManual.WaitOne();
                    Debug.WriteLine(text);
                });
                threads.Add(thread);
            }
            threads.ForEach(x => x.Start());
            System.Threading.Thread.Sleep(1000);
            text = "Text to write";
            preparedTextManual.Set();
            threads.ForEach(x => x.Join());
            threads.Clear();

            //AutoResetEvent - samodzielnie kasuje sygnał po jego ustawieniu
            AutoResetEvent preparedTextAuto = new AutoResetEvent(false);
            AutoResetEvent printedTextAuto = new AutoResetEvent(false);
            for (int i = 0; i < 3; i++)
            {
                var thread = new Thread(() =>
                {
                    Debug.WriteLine("Wating for text...");
                    preparedTextAuto.WaitOne();
                    Debug.WriteLine(text);
                    printedTextAuto.Set();
                });
                threads.Add(thread);
            }
            threads.ForEach(x => x.Start());
            text = "Text #1 to write";
            preparedTextAuto.Set();
            printedTextAuto.WaitOne();
            text = "Text #2 to write";
            preparedTextAuto.Set();
            printedTextAuto.WaitOne();
            text = "Text #3 to write";
            preparedTextAuto.Set();
            printedTextAuto.WaitOne();
            threads.ForEach(x => x.Join());
            threads.Clear();

            //AutoResetEvent - wersja z zakleszczeniem
            for (int i = 0; i < 3; i++)
            {
                var thread = new Thread(() =>
                {
                    Debug.WriteLine("Wating for text...");
                    preparedTextAuto.WaitOne();
                    Debug.WriteLine(text);
                    //Nie informujemy wątku głównego że może pójśc dalej. Wątek główny będzie czekał na printedTextAuto
                    //natomiast reszta wątków będczie czkała na preparedTextAuto
                    //printedTextAuto.Set();
                });
                threads.Add(thread);
            }
            threads.ForEach(x => x.Start());
            text = "Text #1 to write";
            preparedTextAuto.Set();
            printedTextAuto.WaitOne();
            text = "Text #2 to write";
            preparedTextAuto.Set();
            printedTextAuto.WaitOne();
            text = "Text #3 to write";
            preparedTextAuto.Set();
            printedTextAuto.WaitOne();
            threads.ForEach(x => x.Join());
        }
    }
}
