using System;
using System.Collections.Generic;
using System.Text;

namespace _04_AnonymousFunctions.Samples
{
    public class UniversalDecorator
    {
        public Action RunBefore { get; set; }
        public Action RunAfter { get; set; }
        public T Run<T>(Func<T> func)
        {
            RunBefore();
            var result = func();
            RunAfter();
            return result;
        }
        public void Run(Action func)
        {
            RunBefore();
            func();
            RunAfter();
        }
    }
}
