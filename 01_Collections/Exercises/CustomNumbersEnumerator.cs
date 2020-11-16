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
        public CustomNumbersEnumerator(int maxValue)
        {
                
        }

        public int Current => throw new NotImplementedException();

        object IEnumerator.Current => throw new NotImplementedException();

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }

    //Na podstawie stworzonego enumeratora należy stworzyć strukturę IEnumerable
    //Za pomocą testu jednostkowego lub w ramach aplikacji konsolowej przetestować działanie IEnumerable z wykorzystaniem pętli foreach
    public class CustomNumbersEnumerable : IEnumerable<int>
    {
        public CustomNumbersEnumerable(int maxValue)
        {

        }
        public IEnumerator<int> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

}
