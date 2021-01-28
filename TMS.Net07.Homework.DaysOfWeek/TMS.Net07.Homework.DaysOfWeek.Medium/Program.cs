using System;
using System.Globalization;

namespace TMS.Net07.Homework.DaysOfWeek
{
    //DateTime.MinValue Field = "01.01.0001"  
    //DateTime.MaxValue Field = "01.01.10000" 
    class Program
    {
        const string datePattern = "dd.MM.yyyy";
        const string stringDateMin = "01.01.0001";
        const string stringDateMax = "31.12.2999";
        private static DateTime dateValue = DateTime.Now;

        static void Main(string[] args)
        {
            
            Console.WriteLine("To exit from application enter 'exit'.");
            Console.WriteLine("Valid date range: " + stringDateMin + " - " + stringDateMax);
            while (true)
            {
                Console.WriteLine("Please, enter date use format " + datePattern + " (e.g. 01.01.2021):");
                String value = Console.ReadLine().Trim().ToLower();
                if (value == "exit")
                {
                    return;
                }
                if (IsValidDate(value))
                {
                    Console.WriteLine(GetDayOfWeek());
                    continue;
                }
                Console.WriteLine("Entered value is not valid date.");
            } 

        }

        private static bool IsValidDate(string dateString)
        {
            bool isValid = DateTime.TryParseExact(dateString, datePattern, CultureInfo.CurrentCulture, DateTimeStyles.None, out dateValue);
            if (isValid) 
            {                
                isValid = (dateValue.Ticks <= DateTime.Parse(stringDateMax).Ticks);
            }
            return isValid;
        }

        private static string GetDayOfWeek()
        {
            CultureInfo ru = new CultureInfo("ru-RU");
            string dayOfWeek = dateValue.ToString("dddd", ru);
            return char.ToUpper(dayOfWeek[0]) + dayOfWeek.Substring(1);
        }
    }

}
