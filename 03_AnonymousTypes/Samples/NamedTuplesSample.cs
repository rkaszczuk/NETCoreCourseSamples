using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace _03_AnonymousTypes.Samples
{
    public class NamedTuplesSample
    {
        public static void NamedTuplesSampleTest()
        {
            
            (string name, int age ,(string street, string city) address) user = ("Andrzej", 40, ("Marszałkowska", "Warszawa"));
            Debug.WriteLine(user.name, "user.name");
            //Do elementów można się odwoływać jak do zwykłych tupi - intellisense jednak tego nie podpowiada
            Debug.WriteLine(user.Item1, "user.Item1");

            Debug.WriteLine(user.address.city, "user.address.City");

            //Nie są readonly
            user.name = "Zbigniew";

            (string name, Func<string> getFullAddress) user2 = ("Andrzej", new Func<string>(() => $"{user.Item3.Item1} {user.Item3.Item2}"));

            Debug.WriteLine(user2.getFullAddress(), "Func");
            Debug.WriteLine(GetTuple().name, "GetTuple");
            //Tuple moga być też argumentami metody - nazwy nie są ważne, ale typy musza się zgadzać
            Debug.WriteLine(GetFullAddress(user.address), "GetFullAddress");

            
            //Dekonstrukcja - przypisywanie do osobnych zmiennych (moga to być też inne tuple)
            string name;
            int age;
            (string street, string city) address;
            (name, age, address) = ("Andrzej", 40, ("Marszałkowska", "Warszawa"));
            Debug.WriteLine(name, "name");
            Debug.WriteLine(address.city, "address.city");

            //Lub krócej
            (string name2, int age2, (string street2, string city2) address2) = ("Andrzej", 40, ("Marszałkowska", "Warszawa"));
            Debug.WriteLine(name2, "name2");
            Debug.WriteLine(address2.city2, "address2.city2");

            //Lub nawet wykorzystać var,
            (var name3, var age3, (var street3, var city3)) = ("Andrzej", 40, ("Marszałkowska", "Warszawa"));
            Debug.WriteLine(name3, "name3");
            Debug.WriteLine(city3, "city3");
            //Error
            //Ale wtedy nie można używać nazwanych zagnieżdżonych krotek
            //(var name4, var age4, (var street4, var city4) address4) = ("Andrzej", 40, ("Marszałkowska", "Warszawa"));

            //Ale można jeszcze krócej
            var (name5, age5, (street5, city5)) = ("Andrzej", 40, ("Marszałkowska", "Warszawa"));
            Debug.WriteLine(name5, "name5");
            Debug.WriteLine(city5, "city5");

            //Albo bez deklarowania typu
            var user6 = (name: "Andrzej", age : 40, address : (street : "Marszałkowska", city: "Warszawa"));
            Debug.WriteLine(user6.name, "user6");
            Debug.WriteLine(user6.address.city, "user6.address.city");

            //Tuple mogą być przypisywane do siebie, jeśli mają tą samą strukturę
            user = user6;

            var user7 = (name: "Andrzej", age: 40);
            //Error
            //Struktura się różni
            //user7 = user;
            //user = user7;

            //Nazwy pól nie mają znaczenia - porównywane są typu - pod spodem to dalej Item1, Item2, Item3,....
            var user8 = (imie: "Andrzej", wiek: 40, address: (street: "Marszałkowska", city: "Warszawa"));
            user = user8;


            var user9 = ( age: 40, name: "Andrzej", address: (street: "Marszałkowska", city: "Warszawa"));
            //Error
            //Kolejnośc pól ma za to znaczenie
            //user = user9;

            //Możemy też przypisywać do osobnych zmiennych dane zwracane z metod
            (string name10, string pesel10, string email10, string phone10, int age10) = GetTupleWithExtraData();

            //Jeśli nie potrzebujemy wszystkich danych możemy użyć _
            (string name11, _, _, _, int age11) = GetTupleWithExtraData();

            //I trochę magii :)
            var user12 = new User();
            (string name12, _, _, _, int age12) = user12;

            //Error
            //Ale jak nie ma metody Deconstruct to już nie zadziała
            var user13 = new UserWODeconstruct();
            //(string name13, _, _, _, int age13) = user13;
        }

        private static (string name, int age) GetTuple()
        {
            return ("Zdzisław", 50);
        }

        private static (string name, string pesel, string email, string phone, int age) GetTupleWithExtraData()
        {
            return ("Zdzisław", "800000000", "zdzisiek@buziaczek.pl", "6000000", 50);
        }



        private static string GetFullAddress((string ulica, string miasto) address)
        {
            return $"{address.ulica} {address.miasto}";
        }
    }
    public class User
    {
        public void Deconstruct(out string name, out string pesel, out string email, out string phone, out int age)
        {
            name = "Zdzisław";
            pesel = "800000000";
            email = "zdzisiek@buziaczek.pl";
            phone = "6000000";
            age = 50;
        }
    }
    public class UserWODeconstruct
    {
        public void WrongDeconstruct(out string name, out string pesel, out string email, out string phone, out int age)
        {
            name = "Zdzisław";
            pesel = "800000000";
            email = "zdzisiek@buziaczek.pl";
            phone = "6000000";
            age = 50;
        }
    }

}
