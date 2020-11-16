using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace _05_DynamicObjects.Samples
{
    public class DynamicSample
    {
        public static void DynamicSampleTest()
        {
            dynamic variable = (int)1;
            try
            {
                //Debug.WriteLine nie jest w stanie okreslić którego przeładowania użyć
                Debug.WriteLine(variable, "dynamic int");
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message, "Debug.WriteLine without cast");
            }

            variable = "10";
            Debug.WriteLine((string)variable, "dynamic string");
            variable = DateTime.Now;
            Debug.WriteLine((string)variable.ToString(), "dynamic DateTime");
            try
            {
                //Jeżeli nie ma danej metody to będzie exception
                variable.MethodNotExist();
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message, "MethodNotExist");
            }

            dynamic user = new User();
            user.Name = "Andrzej";
            user.Age = 40;
            Debug.WriteLine($"{user.Name} {user.Age}", "dynamic user");
            try
            {
                //Jeżeli nie ma danej property/pola to będzie exception
                user.City = "Warszawa";
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message, "Property not exist");
            }
        }

        public class User
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
    }
}
