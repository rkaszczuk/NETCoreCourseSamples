using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace _07_MethodChaining.Exercises
{
    //Stworzyć bardzo prosty walidator obiektów tworzony z wykorzystaniem method chaining / fluent interface
    //Walidator powinien być generyczny i przechowywać reguły w postaci Func<T, bool>, które są dodawane są za pomocą metody AddRule
    //Każda reguła powinna mieć możliwośc ustawienia komunikatu, który zostanie zwrócony po jej niepowodzeniu
    //Dodać metody dodająca kilka bazowych walidatorów w formie metod chaining:
    //-NotNull
    //-TypeOf
    //-IsNotTypeOf
    //-IsString
    //Metodą finalizująca powinno być Validate(T obj), które sprawdza reguły walidacyjne wobec obiektu
    //Jeżeli reguła nie jest spełniona to Exception z komunikatem
    //FluentRulesValidator<string>().IsString()
    //.AddRule(x=>!String.IsNullOrEmpty(x), "String nie może być pusty).Validate("abc");

    //Stworzyć nową klasę User (Name, Age) i stworzyć walidator z regułamy:
    //NotNull
    //Age i Name nie są puste
    //Age > 18
    //Name z dużej litery
    public class FluentRulesValidator<T> //where T : IComparable
    {
        //private Dictionary<Func<T, bool>, string> rulesDic = new Dictionary<Func<T, bool>, string>();
        private List<(Func<T, bool> func, string message)> rulesList = new List<(Func<T, bool> func, string message)>();
        public FluentRulesValidator<T> AddRule(Func<T, bool> func, string message)
        {
            rulesList.Add((func, message));
            return this;
        }
        public FluentRulesValidator<T> NotNull(string message)
        {
            var notNullFunc = new Func<T, bool>((x) => x != null);
            AddRule(notNullFunc, message);
            return this;
        }

        public FluentRulesValidator<T> TypeOf<T2>(string message)
        {
            var typeOfFunc = new Func<T, bool>((x) => x.GetType() == typeof(T2));
            AddRule(typeOfFunc, message);
            return this;
        }
        public FluentRulesValidator<T> TypeOf(Type type,string message)
        {
            var typeOfFunc = new Func<T, bool>((x) => x.GetType() == type);
            AddRule(typeOfFunc, message);
            return this;
        }
        public FluentRulesValidator<T> NotTypeOf<T2>(string message)
        {
            var typeOfFunc = new Func<T, bool>((x) => x.GetType() != typeof(T2));
            AddRule(typeOfFunc, message);
            return this;
        }

        public FluentRulesValidator<T> IsString(string message)
        {
            return TypeOf<string>(message);
        }

        public void Validate(T obj)
        {
            Debug.WriteLine(obj.GetType().Name, "obj Type");
            foreach(var property in obj.GetType().GetProperties())
            {
                Debug.WriteLine($"{property.PropertyType.Name} {property.Name}", $"{obj.GetType().Name} property");
            }

            foreach(var rule in rulesList)
            {
                if (!rule.func(obj))
                {
                    throw new Exception(rule.message);
                }
            }
        }
    }
    class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string[] Cities { get; set; }

    }

}
