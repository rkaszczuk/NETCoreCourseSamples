using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace _04_AnonymousFunctions.Exercises
{
    //Nalezy napisac mechanizm pozwalający na retry przekazanej operacji
    //Wykonanie ma się powtórzyć w momencie wystąpienia Exception
    //Mechanizm powinien posiadać zdefiniowaną maksymalną liczbę dozwolonych powtórzeń
    public static class Retry
    {
        public static T RunWithRetry<T>(Func<T> func, int retryNumber = 3)
        {
            var retryCounter = 0;
            Exception lastException;
            T result = default(T);
            do
            {
                try
                {
                    result = func();
                    lastException = null;
                }
                catch (Exception ex)
                {
                    retryCounter++;
                    lastException = ex;
                    Debug.WriteLine(ex);
                }
            } while (lastException != null && retryCounter <= retryNumber);

            if (lastException == null)
            {
                return result;
            }
            else
            {
                throw lastException;
            }

        }

        //Funkcja do testowania
        public static bool TestFunc()
        {
            var rand = new Random();
            var value = rand.Next(100);
            if (value % 2 != 0)
            {
                throw new Exception("Number is odd!");
            }
            if (value % 3 != 0)
            {
                return false;
            }
            return true;
        }
    }
}
