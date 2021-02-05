using System;
using System.Collections.Generic;

namespace TMS.Net07.Homework.Calculator.Light
{
    class Program
    {

        private static Dictionary<string, double> currenciesDictionary = new Dictionary<string, double>();

        static void Main(string[] args)
        {
            InitCurrenciesDictionary();
            while (true)
            {
                string[] inputValues = GetInputValues();
                double amount = GetOutputAmount(inputValues);
                Console.WriteLine(amount < 0 ? "You entered is not valid value!" :
                                  $"{inputValues[2]} {inputValues[0]} is equal to {amount} {inputValues[1]}");
                Console.WriteLine("Try again? (y/n):");
                if (!Console.ReadLine().Trim().ToLower().StartsWith('y'))
                {
                    break;
                }
            }
        }

        private static void InitCurrenciesDictionary()
        {
            string dateRate = "03-02-2021";
            string[] code = { "BYN", "EUR", "RUB", "USD" };
            double[] rate = { 1.0, 3.1762, 0.034670, 2.6293 };
            for (int i = 0; i < code.Length; i++)
            {
                currenciesDictionary.Add(code[i], rate[i]);
            }
            PrintRateInfo(dateRate);
        }

        private static void PrintRateInfo(string dateRate)
        {
            Console.WriteLine($"Official Exchange Rate of the Belarusian Ruble at {dateRate}:");
            foreach (KeyValuePair<string, double> entry in currenciesDictionary)
            {
                Console.WriteLine(entry.Key + ": " + entry.Value);
            }
        }

        private static string[] GetInputValues()
        {
            string[] messages =
            {
            "Input source currency:",
            "Input target currency:",
            "Input amount:"
            };
            string[] inputValues = new string[messages.Length];
            for (int i = 0; i < messages.Length; i++)
            {
                Console.WriteLine(messages[i]);
                inputValues[i] = Console.ReadLine().Trim().ToUpper().Replace('.', ',');
            }
            return inputValues;
        }

        private static double GetOutputAmount(string[] inputValues)
        {
            if (!currenciesDictionary.TryGetValue(inputValues[0], out double rateSource) ||
                !currenciesDictionary.TryGetValue(inputValues[1], out double rateTarget) ||
                !double.TryParse(inputValues[2], out double amountSource))
            {
                return -1;
            }
            double amountTarget = (rateSource / rateTarget) * amountSource;
            return Math.Round(amountTarget, 4);
        }
    }
}
