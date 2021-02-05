using System;
using System.Collections.Generic;
using System.Net;
using System.IO;
using System.Text.Json;

namespace TMS.Net07.Homework.Calculator.Light
{
    class Program
    {
        private static Dictionary<string, double> currenciesDictionary = new Dictionary<string, double>();
        private const string outputFormat = "{0:0.0000}";

        static void Main(string[] args)
        {
            InitDictionaryFromAPI();
            while (true)
            {
                string[] inputValues = GetInputValues();
                double amount = GetOutputAmount(inputValues);
                Console.WriteLine(amount < 0 ? "You entered is not valid value!" :
                $"{inputValues[2]} {inputValues[0]} is equal to {string.Format(outputFormat, amount)} {inputValues[1]}");
                Console.WriteLine("Try again? (y/n):");
                if (!Console.ReadLine().Trim().ToLower().StartsWith('y'))
                {
                    break;
                }
            }
        }

        private static void InitDictionaryFromAPI()
        {
            String jsonRate = GetJsonRateFromAPI();
            List<CurrencyRate> listRate = null;
            try
            {
                listRate = JsonSerializer.Deserialize<List<CurrencyRate>>(jsonRate);
            }
            catch (JsonException e)
            {
                Console.WriteLine(e.Message);
            }

            if (listRate == null || listRate.Count == 0)
            {
                InitDictionaryFromHistory();
                return;
            }

            //add rates in currencies dictionary
            currenciesDictionary.Add("BYN", 1);
            String dateRate = "";
            foreach (CurrencyRate rate in listRate)
            {
                dateRate = rate.Date.ToString("dd-MM-yyyy");
                double scaleRate = Math.Round(rate.Cur_OfficialRate / rate.Cur_Scale, 4);
                currenciesDictionary.Add(rate.Cur_Abbreviation, scaleRate);
            }
            PrintRateInfo(dateRate);
        }

        private static string GetJsonRateFromAPI()
        {
            WebResponse response = null;
            String jsonRate = "";
            try
            {
                WebRequest request = WebRequest.Create("https://www.nbrb.by/api/exrates/rates?periodicity=0");
                response = request.GetResponse();
                using Stream stream = response.GetResponseStream();
                using StreamReader reader = new StreamReader(stream);
                string line = "";
                while ((line = reader.ReadLine()) != null)
                {
                    jsonRate += line;
                }

            }
            catch (WebException e)
            {
                Console.WriteLine(e.Message);
                return "";
            }
            finally
            {
                if (response != null)
                {
                    response.Close();
                }
            }
            return jsonRate;
        }

        private static void InitDictionaryFromHistory()
        {
            string dateRate = "03-02-2021";
            string[] codes = { "BYN", "EUR", "RUB", "USD" };
            double[] rates = { 1.0, 3.1762, 0.034670, 2.6293 };
            for (int i = 0; i < codes.Length; i++)
            {
                currenciesDictionary.Add(codes[i], rates[i]);
            }
            PrintRateInfo(dateRate);
        }

        private static void PrintRateInfo(string dateRate)
        {
            Console.WriteLine($"Official Exchange Rate of the Belarusian Ruble at {dateRate}:");
            foreach (KeyValuePair<string, double> entry in currenciesDictionary)
            {
                Console.WriteLine(entry.Key + ": " + string.Format(outputFormat, entry.Value));
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

    public class CurrencyRate
    {
        public int Cur_ID { get; set; }
        public DateTime Date { get; set; }
        public string Cur_Abbreviation { get; set; }
        public int Cur_Scale { get; set; }
        public string Cur_Name { get; set; }
        public double Cur_OfficialRate { get; set; }
    }
}