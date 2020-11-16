using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Diagnostics;

namespace _01_Collections.Samples
{
    public class HashtableSample
    {
        public static void HashcodeTest()
        {
            //Porównanie wartości hashcode dla intów
            int int1 = 1;
            int int1_2 = 1;
            int int2 = 2;
            Debug.WriteLine($"int = 1 Hashcode {int1.GetHashCode()} {int1_2.GetHashCode()}");
            Debug.WriteLine($"int = 2 Hashcode: {int2.GetHashCode()}");

            //Porównanie wartości hashcode dla stringów
            string s1 = "Test1";
            string s1_2 = "Test1";
            string s2 = "Test2";
            Debug.WriteLine($"string = Test1 Hashcode: {s1.GetHashCode()} {s1_2.GetHashCode()}");
            Debug.WriteLine($"string = Test2 Hashcode: {s2.GetHashCode()}");

            //Porównanie wartości hashcode dla obiektów
            var objectCacheKey1 = new CacheKey() { CacheName = "SampleCache", EntityId = 1 };
            var objectCacheKey1_2 = new CacheKey() { CacheName = "SampleCache", EntityId = 1 };
            var objectCacheKey2 = new CacheKey() { CacheName = "SampleCache", EntityId = 3 };
            Debug.WriteLine($"objectCacheKey1 Hashcode: {objectCacheKey1.GetHashCode()} {objectCacheKey1_2.GetHashCode()}");
            Debug.WriteLine($"objectCacheKey2 Hashcode: {objectCacheKey2.GetHashCode()}");

            //Wartośc hashcode po zmianie wartości w obiekcie
            objectCacheKey1.EntityId = 2;
            Debug.WriteLine($"objectCacheKey1 changed EntityId Hashcode: {objectCacheKey1.GetHashCode()}");
        }


        public static void HashtableTest()
        {
            var hashtable = new System.Collections.Hashtable();
            hashtable.Add("cache2", "{ name : Joe, Age : 29}");
            Debug.WriteLine(hashtable["cache2"].ToString(), "Hashtable single value (string key)");

            var objectCacheKey = new CacheKey() { CacheName = "SampleCache", EntityId = 1 };
            hashtable.Add(objectCacheKey, "{ name : Ann, Age : 25}");

            hashtable.Add("cache1", "{ name : John, Age : 41}");
            //Wyniki sortowane po HashCode
            hashtable.PrintCollection("hashtable");

            Debug.WriteLine(hashtable[objectCacheKey].ToString(), "Hashtable single value (object key)");

            objectCacheKey.EntityId = 2;
            Debug.WriteLine(hashtable.ContainsKey(objectCacheKey), "Hashtable - is key exist");

            var objectAnotherCacheKey = new CacheKey() { CacheName = "SampleCache", EntityId = 1 };
            Debug.WriteLine(hashtable.ContainsKey(objectAnotherCacheKey), "Hashtable - is another key exist: ");

            Debug.WriteLine(String.Format("{0} {1}", objectCacheKey.GetHashCode(), objectAnotherCacheKey.GetHashCode()));
            //UWAGA - wartości GetHashCode mogą mieć różną wartośc pomiędzy środowiskami CLR
            Debug.WriteLine(String.Format("{0} {1}", "cache".GetHashCode(), "cache".GetHashCode()));


            var cacheKey1 = new CacheKeyWithHashCode() { CacheName = "SampleCache", EntityId = 1 };
            var cacheKey2 = new CacheKeyWithHashCode() { CacheName = "SampleCache", EntityId = 1 };

            Debug.WriteLine(String.Format("{0} {1}", cacheKey1.GetHashCode(), cacheKey2.GetHashCode()));
        }

        class CacheKey
        {
            public string CacheName { get; set; }
            public int EntityId { get; set; }
        }

        class CacheKeyWithHashCode
        {
            public string CacheName { get; set; }
            public int EntityId { get; set; }
            /// <summary>
            /// Obliczanie HashCode na podstawie properties. 
            /// UWAGA: Metoda nie powinna nigdy zwracać Exception
            /// UWAGA2: Porównywanie obiektów następuje w wykorzystaniem GetHashCode
            /// UWAGA3: Wartośc zwracana z GetHashCode nie powinna ulegać zmianie
            /// </summary>
            /// <returns></returns>
            public override int GetHashCode()
            {
                return CacheName.GetHashCode() + EntityId.GetHashCode();
            }
        }
    }
}
