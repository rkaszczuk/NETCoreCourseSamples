using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace _05_DynamicObjects.Samples
{
    public class ExpandoObjectSample
    {
        public static void ExpandoObjectSampleTest()
        {
            dynamic user = new System.Dynamic.ExpandoObject();
            user.Name = "Andrzej";
            user.Age = 50;
            user.City = "Warszawa";
            Debug.WriteLine($"{user.Name} {user.Age} {user.City}", "ExpandoObject user");

            PrintExpandoObject(user);

            //Usuwanie elementów z ExpandoObject
            ((IDictionary<string, object>)user).Remove("City");

            PrintExpandoObject(user);

            dynamic counter = new System.Dynamic.ExpandoObject();
            counter.CurrentValue = 0;
            counter.Increment = new Action(() => counter.CurrentValue++);
            counter.Increment();
            counter.Increment();
            counter.Increment();
            Debug.WriteLine($"{counter.CurrentValue}", "counter.CurrentValue");



        }

        private static void PrintExpandoObject(dynamic obj)
        {
            //ExpandoObject pod spodem jest słownikiem
            foreach(var element in ((IDictionary<string, object>)obj))
            {
                Debug.WriteLine($"{element.Key} = {element.Value}");
            }
        }
    }
}
