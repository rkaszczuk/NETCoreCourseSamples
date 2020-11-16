using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Text;

namespace _05_DynamicObjects.Samples
{
    public class DynamicObjectSample
    {
        public static void DynamicObjectSampleTest()
        {
            dynamic variable = new DynamicObjectSample<int>();
            variable.int1 = 1;
            variable.int2 = 2;
            variable.int3 = 3;

            try
            {
                //Property mogą być tylko typu int
                variable.string1 = "1";
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message, "variable.string1");
            }

            Debug.WriteLine((string)variable.int1.ToString(), "variable.int1");
            Debug.WriteLine((string)variable, "variable");
        }
    }




    //DynamicObject służy do określania niestandardowych zachowań w momencie uzywania typu dynamic

    //W tym przykładzie określimy DynamicObject obsługujący wyłącznie 1 typ danych
    public class DynamicObjectSample<T> : System.Dynamic.DynamicObject
    {
        Dictionary<string, T> properties = new Dictionary<string, T>();
        //Metoda jest wywoływana w trakcie castowania typu dynamic na inny typ
        public override bool TryConvert(ConvertBinder binder, out object result)
        {
            if(binder.Type == typeof(string))
            {
                result = "Hello from dynamic object!";
                return true;
            }
            result = null;
            return false;
        }

        //Metoda jest wywoływana w momencie pobierania właściwości
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            if (properties.TryGetValue(binder.Name, out var typedObj))
            {
                result = typedObj;
                return true;
            }

            result = null;
            return false;
        }
        //Metoda wywoływana jeśli ustawiana jest nowa własiwość
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            if (value.GetType() != typeof(T))
            {
                return false;
            }

            properties[binder.Name] = (T)value;
            return true;
        }
    }
}
