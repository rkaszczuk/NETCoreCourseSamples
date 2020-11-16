using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

namespace _09_Reflection.Samples
{
    public class ReflectionEmitDynamicMethodSample
    {
        public static void ReflectionEmitDynamicMethodSampleTest()
        {
            //Wyszukanie metody Console.WriteLine
            var writeLineMethod = typeof(Console).GetMethod("WriteLine", types: new Type[] { typeof(string) });

            //Wyszukanie metody String.Concat(string, string)
            var concatMethod = typeof(String).GetMethod("Concat", types: new Type[] { typeof(string), typeof(string) });

            //Tworzę dynamiczną metodę o nazwie WriteHello, zwracającą void i przyjmujacą 1 parametr typu string
            DynamicMethod writeHello = new DynamicMethod("WriteHello", typeof(void), new Type[] { typeof(string) });

            //Pobieram generator kodu IL
            //IL = wspólny kod pośredni dla środowiska .NET
            ILGenerator ilGenerator = writeHello.GetILGenerator();
            //Ładuję wartośc "Hello" typu string
            ilGenerator.Emit(OpCodes.Ldstr, "Hello ");
            //Odczytuję pierwszy parametr przekazany do metody
            ilGenerator.Emit(OpCodes.Ldarg_0);
            //Wywołują metodę Concat.String na załadowanych argumentów
            ilGenerator.Emit(OpCodes.Call, concatMethod);
            //Wywołuję metodę WriteLine dla pobranej wcześniej wartości
            ilGenerator.Emit(OpCodes.Call, writeLineMethod);
            //Return
            ilGenerator.Emit(OpCodes.Ret);

            var writeHelloAction = (Action<string>)writeHello.CreateDelegate(typeof(Action<string>));
            writeHelloAction("Rafał");
        }
    }
}
