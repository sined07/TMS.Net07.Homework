using System;
using System.Globalization;

namespace TMS.Net07.Homework.DaysOfWeek
{

    class Program
    {
        const string datePattern = "dd.MM.yyyy";
        const string dateStringMin = "01.01.0001";
        const string dateStringMax = "31.12.2999";

        static void Main(string[] args)
        {
            Console.WriteLine("To exit from application enter 'exit'.");
            Console.WriteLine("Valid date range: " + dateStringMin + " - " + dateStringMax);
            while (true)
            {
                Console.WriteLine("Please, enter date use format " + datePattern + " (e.g. 01.01.2021):");
                String value = Console.ReadLine().Trim().ToLower();
                if (value == "exit")
                {
                    return;
                }
                Console.WriteLine(GetDayOfWeek(value));
            }
        }

        private static string GetDayOfWeek(string dateString)
        {
            CultureInfo ru = new CultureInfo("ru-RU");
            bool isValid = DateTime.TryParseExact(dateString, datePattern, ru, DateTimeStyles.None, out DateTime dateValue);
            if (isValid)
            {
                // check is valid range datetime
                isValid = dateValue.Ticks <= DateTime.Parse(dateStringMax).Ticks &&
                    dateValue.Ticks >= DateTime.Parse(dateStringMin).Ticks;
            }
            if (!isValid)
            {
                return "Entered value is not valid date.";
            }
            string dayOfWeek = dateValue.ToString("dddd", ru);
            dayOfWeek = char.ToUpper(dayOfWeek[0]) + dayOfWeek.Substring(1);
            return dayOfWeek;
        }
    }
}
