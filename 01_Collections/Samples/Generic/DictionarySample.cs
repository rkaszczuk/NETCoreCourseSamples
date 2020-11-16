using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Diagnostics;
using System.IO;

namespace _01_Collections.Samples.Generic
{
    public class DictionarySample
    {
        public static void DictionaryTest()
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>()
            {
                {"cache2", "{ name : Joe, Age : 29}" },
                {"cache3", "{ name : Ann, Age : 25}" },
            };

            dictionary.Add("cache1", "{ name: John, Age: 41}");



            dictionary.PrintCollection("dictionary");
            dictionary.Keys.PrintCollection("dictionary Keys");
            dictionary.Values.PrintCollection("dictionary Values");

            //Próba dodanie elementu o takim samym kluczu
            try
            {
                dictionary.Add("cache1", "");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex, "Duplicated key");
            }

            Debug.WriteLine(dictionary.ContainsValue("{ name : Joe, Age : 29}"), "ContainsValue");

            //Próba pobrania nieistniejącego klucza
            try
            {
                Debug.WriteLine(dictionary["someKey"]);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex, "Key doesn't exits error");
            }

            //Próba pobrania nieistniejacego klucza ze sprawdzeniem
            if (dictionary.ContainsKey("someKey"))
            {
                var r = dictionary["someKey"];
                Debug.WriteLine(r, "Key not exitsts");
            }


            //Klucz zostanie pobrany tylko jeśli istnieje
            string result;
            dictionary.TryGetValue("cache1", out result);
            Debug.WriteLine(result, "TryGetValue - result");

            //Użycie out-variable (C# 7)
            dictionary.TryGetValue("cache2", out var result2);
            Debug.WriteLine(result2, "TryGetValue out variable - result");

            //Pobranie nieistniejącego klucza (null)
            dictionary.TryGetValue("someKey", out var result3);
            Debug.WriteLine(result3 ?? "null", "TryGetValue - Key not exitsts");

            dictionary.Remove("cache2");

            dictionary.PrintCollection("dictionary after remove");
        }
    }
}
