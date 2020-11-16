using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Serialization.Formatters;
using System.Text;

namespace _01_Collections.Samples
{
    public class ArraySample
    {
        public static void ArrayDeclarations()
        {
            //Deklaracja tablicy z 10 elementami
            int[] array = new int[10];
            PrintArray(array, "Simple array 1");

            //Deklaracja tablicy z wartościami
            int[] arrayWithValues = new int[] { 1, 2, 3, 4 };
            PrintArray(arrayWithValues, "Simple array 2");

            //Deklaracja tablicy/macierzy 2x2
            int[,] multiDimArray = new int[2, 2];
            PrintArray(multiDimArray, "multiDimArray");

            //Deklaracja jagged array (tablica tablic)
            int[][] jaggedArray = new int[2][];
            jaggedArray[0] = new int[1];
            jaggedArray[1] = new int[3];
            jaggedArray[1][0] = 1;
            PrintArray(jaggedArray, "jaggedArray");
            PrintArray(jaggedArray[0], "jaggedArray[0]");
            PrintArray(jaggedArray[1], "jaggedArray[1]");

            //Domyślne wartości dla typów referencyjnych
            string[] stringArray = new string[2];
            PrintArray(stringArray, "stringArray");

            //Alternatywne deklaracje tablic - prostych
            //Array.CreateInstance korzysta z innej ściezki tworzenia tablic niż deklaracja new int[]
            //Generowany kod pośredni IL jest różny dla obu ścieżek
            //Array.CreateInstance jest szczególnie przydatne w przypadku reflekcji
            Array intArray = Array.CreateInstance(typeof(int), 5);
            intArray.SetValue(100, 0);
            PrintArray(intArray, "Array.CreateInstance");

            //Alternatywne deklaracje tablic - tablica tablic
            Array[] arrayOfArrays = new Array[2];
            arrayOfArrays[0] = Array.CreateInstance(typeof(int), 2);
            arrayOfArrays[1] = Array.CreateInstance(typeof(string), 2);
            arrayOfArrays[0].SetValue(100, 0);
            arrayOfArrays[1].SetValue("Sample string", 1);
            PrintArray(arrayOfArrays, "Array.CreateInstance - array of arrays");
        }

        public static void ArrayResize()
        {
            //Zmiana rozmiaru tablicy
            var firstArray = new int[1];
            firstArray[0] = 5;
            PrintArray(firstArray, "firstArray before resize");

            var copyRef = firstArray;
            Array.Resize(ref firstArray, 2);
            PrintArray(firstArray, "firstArray after resize");
            PrintArray(copyRef, "copyRef");
        }


        public static void PrintArray(Array array, string label = "")
        {
            Debug.WriteLine($"--------{label}--------");
            foreach (var item in array)
            {
                if (item is Array)
                {
                    PrintArray(item as Array);
                }
                else
                {
                    Debug.WriteLine((item ?? "null").ToString());
                }
            }
        }
    }
}
