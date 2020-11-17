using System;
using System.Collections.Generic;
using System.Text;

namespace _06_ExtensionMethods.Exercises
{
    //Należy stworzyć 2 metody rozszerzające dla typu DateTime
    //IsWeekend - określająca czy wskazana data jest weekendem
    //GetNextWorkingDay - zwracającą kolejny dzień powszedni (pon-pt) dla podanej daty (czw -> pt, pt -> pon, sb -> pon)
    public static class DateTimeExt
    {
        public static bool IsWeekend(this DateTime dateTime)
        {
            return (dateTime.DayOfWeek == DayOfWeek.Saturday || dateTime.DayOfWeek == DayOfWeek.Sunday);
        }
        public static DateTime GetNextWorkingDay(this DateTime dateTime)
        {
            var result = dateTime;
            do
            {
                result = result.AddDays(1);
            }
            while (result.IsWeekend());

            return result;
        }

    }
}
