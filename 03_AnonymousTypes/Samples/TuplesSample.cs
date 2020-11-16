using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace _03_AnonymousTypes.Samples
{
    public class TuplesSample
    {
        //Tuple (ValueTuple) są typem wartościowym
        //Są typem mutable
        //Dane reprezentowane są za pomoca pól (a nie właściwości)
        //Tuple przedstawione poniżej nazywane są ValueTuple
        //Istnije również implementacja System.Tuple, która różni się swoją charakterystyką
        public static void TuplesSampleTest()
        {
            (string, int, (string, string)) user = ("Andrzej", 40, ("Marszałkowska", "Warszawa"));
            Debug.WriteLine(user.Item1, "user.Item1");
            Debug.WriteLine(user.Item3.Item2, "user.Address.City");

            //Krotki nie są readonly
            user.Item1 = "Zbigniew";

            //Error
            //var user2 = ("Andrzej", () => $"{user.Item3.Item1} {user.Item3.Item2}");
            var user2 = ("Andrzej", new Func<string>(() => $"{user.Item3.Item1} {user.Item3.Item2}"));

            Debug.WriteLine(user2.Item2(), "Func");
            Debug.WriteLine(GetTuple().Item1, "GetTuple");
            Debug.WriteLine(GetFullAddress(user.Item3), "GetFullAddress");
        }
        private static (string, int) GetTuple()
        {
            return ("Zdzisław", 50);
        }

        private static string GetFullAddress((string, string) address)
        {
            return $"{address.Item1} {address.Item2}";
        }

        //System.Tuple jest typem referencyjnym
        //Jest immutable
        //Dane reprezentowane są za pomoca właściwości (a nie pól)
        public static void SystemTuplesSampleTest()
        {
            var user = System.Tuple.Create("Andrzej", 40, System.Tuple.Create("Marszałkowska", "Warszawa"));
            Debug.WriteLine(user.Item1, "user.Item1");
            Debug.WriteLine(user.Item3.Item2, "user.Address.City");

            //Error
            //System.Tuple są immutable
            //user.Item1 = "Zbigniew";

            //Error
            //var user2 = System.Tuple.Create(() => $"{user.Item3.Item1} {user.Item3.Item2}");
            var user2 = new System.Tuple<string, Func<string>>("Andrzej", new Func<string>(() => $"{user.Item3.Item1} {user.Item3.Item2}"));
            Debug.WriteLine(user2.Item2(), "Func");
            Debug.WriteLine(GetSystemTuple().Item1, "GetTuple");

        }
        private static Tuple<string, int> GetSystemTuple()
        {
            return new Tuple<string, int>("Zdzisław", 50);
        }
    }
}
