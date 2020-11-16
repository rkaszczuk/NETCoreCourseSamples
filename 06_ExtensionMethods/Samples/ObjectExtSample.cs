using System;
using System.Collections.Generic;
using System.Text;

namespace _06_ExtensionMethods.Samples
{
    public static class ObjectExt
    {
        public static void SayHello(this object obj)
        {
            Console.WriteLine("Hello from " + obj.GetType().Name); ;
        }
        public static string ToJson(this object obj, int maxDepth = 3)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(obj, new Newtonsoft.Json.JsonSerializerSettings { MaxDepth = maxDepth });
        }
        
     
    }
}
