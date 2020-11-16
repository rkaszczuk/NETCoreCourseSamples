using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace _01_Collections.Samples
{
    public class BitArraySample
    {
        public static void BitArrayTest()
        {
            //Stworzenie nowej tablicy BitArray o wartościach 1,0,1
            var bitArray = new System.Collections.BitArray(new[] { true, false, true });
            //Stworzenie tablicy z wartościamy przeciwnimy dla bitArray (0,1,0)
            var bitArrayNot = new System.Collections.BitArray(bitArray.Not());
            bitArray.PrintCollection("bitArray");
            bitArrayNot.PrintCollection("bitArrayNot");

            //Rozszerzanie BitArray
            bitArray.Length = 4;
            bitArray.Set(3, true);
            bitArray.PrintCollection("bitArray after resize");

            //Porównanie elementów dwóch tablic BitArray za pomocą operatora AND
            bitArray.And(bitArrayNot).PrintCollection("bitArray And");
            //Porównanie elementów dwóch tablic BitArray za pomocą operatora OR
            bitArray.Or(bitArrayNot).PrintCollection("bitArray Or");
        }
    }
}
