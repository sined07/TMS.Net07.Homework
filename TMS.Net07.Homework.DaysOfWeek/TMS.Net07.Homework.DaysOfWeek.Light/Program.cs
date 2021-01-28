using System;

namespace TMS.Net07.Homework.DaysOfWeek.Light
{
    class Program
    {
        static void Main(string[] args)
        {
            string value;
            bool isUpper;
            Console.WriteLine("To exit from application enter 'exit'.");
            while (true)
            {
                Console.WriteLine("Please, enter day of week (e.g. 'Monday' or 'monday'):");
                value = Console.ReadLine();
                isUpper = char.IsUpper(value[0]);
                value = value.Trim().ToLower();
                if (value == "exit") 
                {
                    return;
                }
                value = isUpper ? GetRuDaysOfWeek(value) : GetRuDaysOfWeek(value).ToLower();
                Console.WriteLine(value);
            }                
        }

        private enum DaysOfWeek
        {           
            monday,
            tuesday,
            wednesday,
            thursday,
            friday,
            saturday,
            sunday            
        }

        private static string GetRuDaysOfWeek (string engDayOfWeek)
        {
            switch (engDayOfWeek)
            {
                case nameof(DaysOfWeek.monday):
                    return "Понедельник";
                case nameof(DaysOfWeek.tuesday):
                    return "Вторник";
                case nameof(DaysOfWeek.wednesday):
                    return "Среда";
                case nameof(DaysOfWeek.thursday):
                    return "Четверг";
                case nameof(DaysOfWeek.friday):
                    return "Пятница";
                case nameof(DaysOfWeek.saturday):
                    return "Суббота";
                case nameof(DaysOfWeek.sunday):
                    return "Воскресенье";
                default:
                    return "Неизвестно";
            }
        }
    }
}