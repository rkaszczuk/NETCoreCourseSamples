using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace _04_AnonymousFunctions.Samples
{
    public class AnonymouseDelegateSample
    {
        public delegate int ArithemticFunc(int x, int y);
        public void AnonymouseDelegateSampleTest()
        {
            ArithemticFunc Sum = delegate (int x, int y)
            {
                return x + y;
            };

            Debug.WriteLine(Sum(10, 5), "Sum(10, 5)");

            ArithemticFunc SumFunc = new ArithemticFunc(SumMethod);

            Debug.WriteLine(SumFunc(10, 5), "SumFunc(10, 5)");

            ArithemticFunc Multi = delegate (int x, int y)
            {
                return x * y;
            };

            Debug.WriteLine(Multi(10, 5), "Multi(10, 5)");

            ArithemticFunc MultiLambda = (x, y) => x * y;

            Debug.WriteLine(MultiLambda(10, 5), "MultiLambda(10, 5)");

            ArithemticFunc MultiLambdaFunc = (x, y) => MultiMethod(x,y);

            Debug.WriteLine(MultiLambdaFunc(10, 5), "MultiLambda(10, 5)");

            //Error
            //Nie da się przypisac Func do delegata
            //ArithemticFunc MultiFunc = new Func<int, int, int>((x, y) => x * y);
        }
        public int SumMethod(int x, int y)
        {
            return x + y;
        }

        public int MultiMethod(int x, int y)
        {
            return x + y;
        }
    }
}
