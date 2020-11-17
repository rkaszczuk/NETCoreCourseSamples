using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace _02_Generics.Exercises
{
    //Należy stworzyć własną generyczną strukturę, obsługujacą wewnętrzą tablicę z danymi
    //Nalezy zaimplementować wszystkie metody interfejsu ICollection<T>
    //Kolekcja powinna zawierać tylko unikalne elementy -> Add
    //W celu ułatwienia można założyć że T:IComparable

    public class CustomUniqueCollection<T> : ICollection<T> where T : IComparable, 
    {
        private T[] internalArray = new T[0];

        public int Count { get => internalArray.Length; }

        public bool IsReadOnly { get => false; }

        public void Add(T item)
        {
            if (Contains(item))
            {
                return;
            }
            else
            {
                Array.Resize(ref internalArray, internalArray.Length + 1);
                internalArray[internalArray.Length-1] = item;
            }
        }

        public void Clear()
        {
            internalArray = new T[0];
        }

        public bool Contains(T item)
        {
            foreach(var arrayItem in internalArray)
            {
                if(arrayItem.Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)internalArray).GetEnumerator();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return internalArray.GetEnumerator();
        }
    }
}
