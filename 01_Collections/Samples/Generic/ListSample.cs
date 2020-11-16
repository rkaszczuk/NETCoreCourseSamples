using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Diagnostics;

namespace _01_Collections.Samples.Generic
{
    public class ListSample
    {
        public static void ListTest()
        {
            List<int> intList = new List<int>() { 3 };
            intList.Add(1);
            intList.Add(2);
            intList.PrintCollection("intList");

            intList.Sort();
            intList.PrintCollection("intList sorted");

            Debug.WriteLine(intList.FindIndex(x => x == 3), "intList FindIndex");
            Debug.WriteLine(intList[2], "intList[2]");
        }

        public static void ListWithComplexTypeTest()
        {
            List<(int i, string s)> intComplexList = new List<(int i, string s)>() { (3, "Test3")};
            intComplexList.Add((1, "Test1"));
            intComplexList.Add((2, "Test2"));
            intComplexList.PrintCollection("intList");

            Debug.WriteLine(intComplexList.Find(x => x.i == 3).s, "intComplexList Find");
            Debug.WriteLine(intComplexList.FindIndex(x => x.i == 3), "intComplexList FindIndex");
            Debug.WriteLine(intComplexList[2], "intComplexList[2]");
        }
    }
}
