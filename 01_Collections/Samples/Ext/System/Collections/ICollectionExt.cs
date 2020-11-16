using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace System.Collections
{
    public static class ICollectionExt
    {
        public static void PrintCollection(this ICollection collection, string label = "")
        {
            foreach (var item in collection)
            {
                if (item is DictionaryEntry)
                {
                    Debug.WriteLine(item == null ? "null" :
                        String.Format("{0} {1}", (item as DictionaryEntry?).Value.Key.ToString(),
                        (item as DictionaryEntry?).Value.Value.ToString()), label);
                }
                else
                {
                    Debug.WriteLine((item ?? "null").ToString(), label);
                }
            }
        }
    }
}
