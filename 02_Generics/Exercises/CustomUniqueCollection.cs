using System;
using System.Collections.Generic;
using System.Text;

namespace _02_Generics.Exercises
{
    //Należy stworzyć własną generyczną strukturę, obsługujacą wewnętrzą tablicę z danymi
    //Nalezy zaimplementować wszystkie metody interfejsu ICollection<T>
    //Kolekcja powinna zawierać tylko unikalne elementy
    //W celu ułatwienia można założyć że T:IComparable

    public class CustomUniqueCollection<T> //: ICollection<T> where T:IComparable
    {
        private T[] internalArray = new T[0];
    }
}
