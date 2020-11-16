using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Diagnostics;

namespace _01_Collections.Samples
{
    public class SortedListSample
    {
        public static void SortedListTest()
        {
            var sortedList = new System.Collections.SortedList();
            sortedList.Add("cache2", "{ name : Joe, Age : 29}");
            sortedList.Add("cache1", "{ name : Ann, Age : 25}");
            sortedList.Add("cache3", "{ name : John, Age : 41}");
            sortedList.PrintCollection("sortedList");

            //Dodanie tego samego klucza powoduje błąd
            try
            {
                sortedList.Add("cache1", "{ name : Joe, Age : 29}");
            }
            catch(Exception ex)
            {
                Debug.WriteLine("Error while adding duplicated key. Excetion:" + ex.ToString());
            }

            //Dostęp dodanych jest możliwy za pomoca indeksu oraz klucza
            Debug.WriteLine($"{sortedList["cache1"]}", "sortedList[\"cache1\"]");
            Debug.WriteLine($"{sortedList.GetByIndex(0)}", "sortedList[0]");

        }
    }
}
