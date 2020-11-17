#define USE_CONEMU
using _07_MethodChaining.Exercises;
using _07_MethodChaining.Samples;
using System;
using System.Diagnostics;

namespace _07_MethodChaining
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
            //var validator1 = new FluentRulesValidator<string>();
            //validator1
            //    .NotNull("String nie może być null!")
            //    .AddRule((x) => x.Contains('X'), "Musi zawierać X!")
            //    .Validate("abcX");


            //var user = new User() { Name = "Andrzej", Age = 20 };
            //var validator2 = new FluentRulesValidator<User>();
            //validator2
            //    .NotNull("User nie może być NULL")
            //    .AddRule((x) => !string.IsNullOrEmpty(x.Name), "Name nie może być puste")
            //    .AddRule((x) => x.Age != default(int), "Age nie może być domyślne (0)")
            //    .AddRule((x) => x.Age > 18, "User musi być pełnoletni")
            //    .AddRule((x) => x.Name[0] == x.Name.ToUpper()[0], "Name musi być z dużej litery")
            //    .Validate(user);











            //MailBuilderSample.Init("Test title", "rafal@foo.com")
            //    .AddToAddress("rafal@yahoo.com")
            //    .SetFromAddress("veryimportantmail@microsoft.com")
            //    .SetIsHtml()
            //    .SetBody("Sample body")
            //    .SendMail();

            Console.ReadKey();
        }
    }
}
