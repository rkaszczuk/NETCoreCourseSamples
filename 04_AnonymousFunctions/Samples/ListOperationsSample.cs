using System;
using System.Collections.Generic;
using System.Text;

namespace _04_AnonymousFunctions.Samples
{
    public class ListOperationsSample<T>
    {
        private List<T> list = new List<T>();
        public void Add(T item)
        {
            list.Add(item);
        }
        public List<T> Filter(Predicate<T> filter)
        {
            var result = new List<T>();
            foreach (var item in list)
            {
                if (filter(item))
                {
                    result.Add(item);
                }
            }
            return result;
        }
        public List<T1> Transform<T1>(Func<T, T1> transformFunc)
        {
            var result = new List<T1>();
            foreach (var item in list)
            {
                var resultItem = transformFunc(item);
                result.Add(resultItem);
            }
            return result;
        }
    }
}
