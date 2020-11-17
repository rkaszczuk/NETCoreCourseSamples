using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _01_Collections.Exercises
{
    //Nalezy stworzyć własny enumerator zwracający kolejne liczny całkowite >0 (1,2,3,....)
    //Enumerator powinien implementować interfejs IEnumerator<int>
    //Wartość maxValue określa limit zwracanych wartości (np. maxValue = 5 określa że enumerator zwróci 1,2,3,4,5)
    public class CustomNumbersEnumerator : IEnumerator<int>
    {
        private int maxValue;
        private int currentValue;
        public CustomNumbersEnumerator(int maxValue)
        {
            this.maxValue = maxValue;
        }

        public int Current { get => currentValue; }

        object IEnumerator.Current { get => Current; }

        public void Dispose()
        {
            return;
        }

        public bool MoveNext()
        {
            if(currentValue < maxValue)
            {
                currentValue++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Reset()
        {
            currentValue = 0;
        }
    }

    //Na podstawie stworzonego enumeratora należy stworzyć strukturę IEnumerable
    //Za pomocą testu jednostkowego lub w ramach aplikacji konsolowej przetestować działanie IEnumerable z wykorzystaniem pętli foreach
    public class CustomNumbersEnumerable : IEnumerable<int>
    {
        private CustomNumbersEnumerator enumerator;
        public CustomNumbersEnumerable(int maxValue)
        {
            enumerator = new CustomNumbersEnumerator(maxValue);
        }
        public IEnumerator<int> GetEnumerator()
        {
            return enumerator;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

}
