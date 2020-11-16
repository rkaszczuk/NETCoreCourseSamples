using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Diagnostics;

namespace _01_Collections.Samples
{
    public class EnumeratorArrayListSample
    {
        public static void IterateByIEnumerator()
        {
            //Iteracja za pomocą enumeratora
            List<int> list = new List<int>() { 1, 2, 3 };
            var enumerator = list.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Debug.WriteLine(enumerator.Current.ToString());
            }
        }
        public static void ArrayListSample()
        {
            var arrayList = new System.Collections.ArrayList();
            arrayList.Add(5);            
            arrayList.Add("text"); //ArrayList może przyjmować różne typy danych
            arrayList.Add(4);
            arrayList.AddRange(new[] { 1, 2, 3 });

            //W związku z użyciem różnych typów danych należy napisac własny mechanizm sortujący
            arrayList.Sort(new ArrayListComparer());

            arrayList.PrintCollection("arrayList");
            arrayList.Remove("text");
            arrayList.PrintCollection("arrayList after remove");
            Debug.WriteLine(arrayList[0], "arrayList[0]");
        }
        class ArrayListComparer : System.Collections.IComparer
        {
            /// <summary>
            /// Porównanie dwóch obiektów przy założeniu że String jest wartością najmniejszą, a Int traktujemy według kolejności wynikającej z arytmetyki
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <returns></returns>
            public int Compare(object x, object y)
            {
                if (x.GetType() == typeof(string) && y.GetType() != typeof(string))
                {
                    return -1;
                }
                else if (x.GetType() != typeof(string) && y.GetType() == typeof(string))
                {
                    return 1;
                }
                else if (x is int && y is int)
                {
                    return (x as int?).Value - (y as int?).Value;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}

