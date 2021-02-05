using System;
using System.Reflection;

namespace TMS.Net07.Homework.Calculator.Additional
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine(
                "Availables algoritms: " + Environment.NewLine +
                "1. " + nameof(GetFactorialLoop) + Environment.NewLine +
                "2. " + nameof(GetFactorialRecursive) + Environment.NewLine +
                "3. " + nameof(GetFibonacciRecursive));
            while (true)
            {
                string[] inputValues = GetInputValues();
                Console.WriteLine(GetResultMessage(inputValues));
                Console.WriteLine("Try again? (y/n):");
                if (!Console.ReadLine().Trim().ToLower().StartsWith('y'))
                {
                    break;
                }
            }
        }

        private static string[] GetInputValues()
        {
            string[] messages =
            {
            "Please, select algoritm (1-3):",
            "Enter positive integer value:"
            };
            string[] inputValues = new string[messages.Length];
            for (int i = 0; i < messages.Length; i++)
            {
                Console.WriteLine(messages[i]);
                inputValues[i] = Console.ReadLine().Trim().ToLower();
            }
            return inputValues;
        }

        private static string GetResultMessage(string[] inputValues)
        {
            if (!int.TryParse(inputValues[0], out int idAlgoritm) ||
                !int.TryParse(inputValues[1], out int number) ||
                idAlgoritm < 1 || idAlgoritm > 3 || number < 0)
            {
                return "You entered is not valid value!";
            }
            decimal result = -1;
            switch (idAlgoritm)
            {
                case 1:
                    result = GetFactorialLoop(number);
                    break;
                case 2:
                    result = GetFactorialRecursive(number);
                    break;
                case 3:
                    result = GetFibonacciRecursive(number);
                    break;
            }
            return "Result: " + $"{(result < 0 ? "Error!" : result.ToString())}";
        }

        private static decimal GetFactorialLoop(int number)
        {
            if (number == 0) return 1;
            decimal factorial = number;
            try
            {
                for (int i = 1; i < number; i++)
                {
                    factorial *= i;
                }
            }
            catch (OverflowException e)
            {
                Console.WriteLine(e.Message);
                return -1;
            }
            return factorial;
        }

        private static decimal GetFactorialRecursive(int number)
        {
            try
            {
                return (number > 1) ? number * GetFactorialRecursive(number - 1) : 1;
            }
            catch (OverflowException e)
            {
                Console.WriteLine(e.Message);
                return -1;
            }
        }

        private static int GetFibonacciRecursive(int number)
        {
            try
            {
                return number > 1 ? GetFibonacciRecursive(number - 1) + GetFibonacciRecursive(number - 2) : number;
            }
            catch (StackOverflowException e)
            {
                Console.WriteLine(e.Message);
                return -1;
            }
        }
    }
}