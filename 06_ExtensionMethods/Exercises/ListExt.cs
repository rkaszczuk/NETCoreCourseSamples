using System;
using System.Collections.Generic;
using System.Text;

namespace _06_ExtensionMethods.Exercises
{
    //Należy stworzyć metodę rozszerzająca AddUnique dla typu List<T>
    //Metoda ta powinna dodawać element do listy tylko w przypadku gdy nie istnieje on na liście
    //W przeciwnym wypadku zawartośc listy pozostaje bez zmian
    public static class ListExt
    {
        public static void AddUnique<T>(this List<T> list, T value)
        {
            if (!list.Contains(value))
            {
                list.Add(value);
            }
        }
    }
}
