using System;
using System.Collections.Generic;
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


    //Stworzyć nową klasę User (Name, Age) i stworzyć walidator z regułamy:
    //NotNull
    //Age i Name nie są puste
    //Age > 18
    //Name z dużej litery
    public class FluentRulesValidator
    {
    }
}
