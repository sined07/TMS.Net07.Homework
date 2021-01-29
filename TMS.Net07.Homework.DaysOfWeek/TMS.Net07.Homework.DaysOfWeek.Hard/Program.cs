using System;
using System.Globalization;

namespace TMS.Net07.Homework.DaysOfWeek
{

    class Program
    {
        const string datePattern = "dd.MM.yyyy";
        const string dateStringMin = "01.01.0001";
        const string dateStringMax = "31.12.2999";
        const string errorMessage = "Entered value is not valid date.";

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
                Console.WriteLine(GetDayOfWeekHard(value));
            }
        }
        private static string GetDayOfWeekHard(string dateString)
        {
            int[] dateValue = ParseDateString(dateString);
            int[] dateMin = ParseDateString(dateStringMin);
            int[] dateMax = ParseDateString(dateStringMax);
            int[] countDaysOfMonth = { 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

            //validate date value
            if (dateValue == null || dateValue.Length != 3 || dateValue[0] <= 0 || dateValue[1] <= 0 || dateValue[2] <= 0 || dateValue[1] > 12 ||
                dateValue[0] > countDaysOfMonth[dateValue[1] - 1] || (dateValue[1] == 2 && dateValue[2] % 4 != 0 && dateValue[0] > 28) ||
                dateValue[2] < dateMin[2] || dateValue[2] > dateMax[2])
            {
                return errorMessage;
            }

            //for correct calculation before 1901 require to take historical events
            if (dateValue[2] < 1901)
            {
                return "Неизвестно, необходимо учитывать исторические события";
            }

            //set count days in february
            countDaysOfMonth[1] = dateValue[2] % 4 == 0 ? 29 : 28;

            string[] daysOfWeek =
            {
                "Понедельник",
                "Вторник",
                "Среда",
                "Четверг",
                "Пятница",
                "Суббота",
                "Воскресенье"
            };

            //calculate count days use past years and count leap years
            int countYears = dateValue[2] - 1;
            int countDays = countYears * 365 + (int)(countYears / 4);

            //add count days use past monthes in current year
            for (int i = 0; i < dateValue[1] - 1; i++)
            {
                countDays += countDaysOfMonth[i];
            }

            //add count days in current month exclude current day          
            countDays += dateValue[0] - 1;

            //go to array index
            countDays -= 1;

            return daysOfWeek[(countDays % 7)];
        }

        private static int[] ParseDateString(string dateString)
        {
            string[] words = dateString.Split('.');
            int[] values = new int[words.Length];
            for (int i = 0; i < values.Length; i++)
            {
                bool ok = int.TryParse(words[i], out values[i]);
                if (!ok)
                {
                    return null;
                }
            }
            return values;
        }

        private static string GetDayOfWeekMedium(string dateString)
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
                return errorMessage;
            }
            string dayOfWeek = dateValue.ToString("dddd", ru);
            dayOfWeek = char.ToUpper(dayOfWeek[0]) + dayOfWeek.Substring(1);
            return dayOfWeek;
        }
    }
}
