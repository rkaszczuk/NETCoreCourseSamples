using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace _09_Reflection.Samples
{
    //Weaving jest sposobem "opakowywania" wykonań poszczególnych fragmentów kodów w przygotowane wcześniej weavery
    //Można go traktować jako wraper na poziomie wykonywania kodu
    //"Prawdziwy" weaving używany jest np. w narzędziach APM oraz programowaniu aspektowym
    public class ReflectionWeavingLike
    {
        public static T RunMethodWithWrapper<T>(Func<T> func)
        {
            //Wyszukanie metody Console.WriteLine
            var writeLineMethod = typeof(Console).GetMethod("WriteLine", new Type[] { typeof(string) });

            //Tworzymy metodę dynamiczną przyjmującą Func<T> i zwracającą T
            //T RunWithMessureTime(Func<T> func)
            //
            //var sw = System.Diagnostics.Stopwatch().StartNew()
            //var result = func()
            //Console.Writeline(ElapsedMilliseconds)
            //return T


            DynamicMethod runWithMessureTime = new DynamicMethod("RunWithMessureTime", typeof(T), new Type[] { typeof(Func<T>) });
            
            //Pobieram generator kodu IL
            //IL = wspólny kod pośredni dla środowiska .NET
            ILGenerator ilGenerator = runWithMessureTime.GetILGenerator();         

            //Tworzymy nową zmienną dla Stopwatch
            ilGenerator.DeclareLocal(typeof(System.Diagnostics.Stopwatch));
            //Uruchamiamy metodę statyczną System.Diagnostics.Stopwatch.StartNew
            ilGenerator.Emit(OpCodes.Call, typeof(System.Diagnostics.Stopwatch).GetMethod("StartNew"));
            //Wynik zapisujemy do zmiennej lokalnej o indeksie 0
            ilGenerator.Emit(OpCodes.Stloc_0);

            //Odczytujemy 1 parametr metody (Func<T>)
            ilGenerator.Emit(OpCodes.Ldarg_0);
            //Deklarujemy zmienną T w której zapiszemy wynik
            ilGenerator.DeclareLocal(typeof(T));
            //Odpalamy Func
            ilGenerator.Emit(OpCodes.Callvirt, func.GetType().GetMethod("Invoke"));
            //Zapisujemy wynik do zmiennej
            ilGenerator.Emit(OpCodes.Stloc_1);

            //Ładujemy zmienną Stopwatch
            ilGenerator.Emit(OpCodes.Ldloc_0);
            //Wypisujemy do konsoli czas wykonania
            ilGenerator.Emit(OpCodes.Callvirt, typeof(System.Diagnostics.Stopwatch).GetMethod("get_ElapsedMilliseconds"));
            ilGenerator.Emit(OpCodes.Call, typeof(System.Convert).GetMethod("ToString", new Type[] { typeof(long) }));
            ilGenerator.Emit(OpCodes.Call, writeLineMethod);

            //Ładujemy wynik operacji T
            ilGenerator.Emit(OpCodes.Ldloc_1);
            //Zwracamy zmienną z strosu wykonań (załadowaną wyżej)
            ilGenerator.Emit(OpCodes.Ret);

            var runWithMessureTimeAction = (Func<Func<T>, T>)runWithMessureTime.CreateDelegate(typeof(Func<Func<T>, T>));
            return runWithMessureTimeAction(func);
        }

    }
}
