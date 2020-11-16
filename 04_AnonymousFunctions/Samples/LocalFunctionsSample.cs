using System;
using System.Collections.Generic;
using System.Text;

namespace _04_AnonymousFunctions.Samples
{
    public class LocalFunctionsSample
    {
        public int Div(int x, int y)
        {
            if (isNot0(y))
            {
                throw new DivideByZeroException();
            }
            return x / y;

            bool isNot0(int x)
            {
                if(x == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
    }
}
