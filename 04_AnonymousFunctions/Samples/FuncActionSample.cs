using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace _04_AnonymousFunctions.Samples
{
    public class FuncActionSample
    {
        public static void FuncSampleTest()
        {
            Func<int, int, int> sum = (x, y) => x + y;
            Debug.WriteLine(sum(10, 5), "Sum(10, 5)");
            Func<int, int, int> multi = (x, y) => x * y;
            Debug.WriteLine(multi(10, 5), "Multi(10, 5)");

            Debug.WriteLine(SumRepeateOperations(sum, 10, 5, 10), "Sum(10, 5) x 10");

            //Action w odróżnieniu od Func nie zwraca wyniku
            Action<int, int> writeSum = (x, y) => Debug.WriteLine(x + y, "writeSum");
            writeSum(10, 5);
        }

        private static int SumRepeateOperations(Func<int, int, int> operation, int x, int y, int numberOfReplicates)
        {
            int result = 0;
            for (int i = 0; i < numberOfReplicates; i++)
            {
                result += operation(x, y);
            }
            return result;
        }


    }
}
