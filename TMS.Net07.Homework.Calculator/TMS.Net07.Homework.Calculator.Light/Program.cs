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
            PrintRatesInfo();
            while (true)
            {
                var inputValues = GetInputValues();
                Console.WriteLine(GetOutput(inputValues));
                Console.WriteLine("Try again? (yes/no):");
                if (!Console.ReadLine().Trim().ToLower().StartsWith('y'))
                {
                    return;
                }
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
                inputValues[i] = Console.ReadLine().Trim().ToUpper();
            }
            return inputValues;
        }

        private static void InitCurrenciesDictionary()
        {
            string[] currenciesCode = { "BYN", "EUR", "RUB", "USD" };
            double[] currenciesRate = { 1.0d, 3.1742d, 0.034693d, 2.6195d };
            for (int i = 0; i < currenciesCode.Length; i++)
            {
                currenciesDictionary.Add(currenciesCode[i], currenciesRate[i]);
            }
        }

        private static void PrintRatesInfo()
        {
            Console.WriteLine("Rates on 02-02-2021:");
            foreach (KeyValuePair<string, double> entry in currenciesDictionary)
            {
                Console.WriteLine(entry.Key + ": " + entry.Value);
            }
        }

        private static string GetOutput(string[] inputValues)
        {
            if (!currenciesDictionary.TryGetValue(inputValues[0], out double rateSource) ||
                !currenciesDictionary.TryGetValue(inputValues[1], out double rateTarget) ||
                !double.TryParse(inputValues[2], out double amountSource))
            {
                return "Input value is not valid.";
            }
            double amountTarget = (rateSource / rateTarget) * amountSource;
            amountTarget = Math.Round(amountTarget, 4);

            return $"Output: {amountSource} {inputValues[0]} is equal to {amountTarget} {inputValues[1]}";
        }
    }
}
