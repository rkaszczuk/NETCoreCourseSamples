#define USE_CONEMU
using System;
using System.Diagnostics;
using _06_ExtensionMethods.Samples;
using _06_ExtensionMethods.Exercises;
using System.Collections.Generic;
using System.Linq;

namespace _06_ExtensionMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            #region ConEMU
#if USE_CONEMU
            ProcessStartInfo pi = new ProcessStartInfo(@"C:\Program Files\ConEmu\ConEmu\ConEmuC.exe", "/AUTOATTACH");
            pi.CreateNoWindow = false;
            pi.UseShellExecute = false;
            Process.Start(pi);
#endif
            #endregion

            #region Trace to console
            //Zrzucanie Trace/Debug do konsoli
            TextWriterTraceListener consoleTraceWriter = new
                    TextWriterTraceListener(System.Console.Out);
            Trace.Listeners.Add(consoleTraceWriter);
            #endregion

            //Start code below
            var stringList = new List<string>();
            stringList.AddUnique("Rafał");
            stringList.AddUnique("Andrzej");
            stringList.AddUnique("Rafał");

            stringList.ForEach(x => Debug.WriteLine(x));
            var query = stringList.Where(x => x == "Rafał").Select(x=>x).OrderBy(x=>x);
            query.ToArray();
            query.FirstOrDefault();
            query.Single();
            query.Count();




            //Debug.WriteLine(DateTime.Now.IsWeekend());
            //Debug.WriteLine(new DateTime(2020,11,21).IsWeekend());
            //Debug.WriteLine(new DateTime(2020,11,21).GetNextWorkingDay());
            //Debug.WriteLine(new DateTime(2020,11,20).GetNextWorkingDay());
            //Debug.WriteLine(new DateTime(2020,11,19).GetNextWorkingDay());




            //Debug.WriteLine("abc".GetType().IsNumericType());
            //Debug.WriteLine(typeof(int).IsNumericType());
            //Debug.WriteLine(typeof(int?).IsNumericType());
            //Debug.WriteLine(typeof(Nullable<int>).IsNumericType());
            //Debug.WriteLine(typeof(DateTime?).IsNumericType());


            //Debug.WriteLine("ABCBA".LetterCount('A'));
            //Debug.WriteLine("ABCBA".LetterCount('C'));
            //Debug.WriteLine("ABCBA".ReplaceFirst("B", "eeee"));





            //"xxxx".SayHello();
            //new DateTime().SayHello();
            //(string name, int age) user = ("Andrzej", 50);
            //user.SayHello();
            //Debug.WriteLine(user.ToJson());
            //Debug.WriteLine(new { name = "Andrzej", age = 50 }.ToJson());

            //dynamic user = new System.Dynamic.ExpandoObject();
            //user.Name = "Andrzej";
            //user.Age = 50;
            //user.City = "Warszawa";
            //user.SayHello();
            //((System.Collections.Generic.IDictionary<string, object>)user).SayHello();

            Console.ReadKey();
        }
    }
}
