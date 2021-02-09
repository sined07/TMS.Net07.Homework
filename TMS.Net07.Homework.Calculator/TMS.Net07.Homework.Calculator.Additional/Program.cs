using System;

namespace TMS.Net07.Homework.Calculator.Additional
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(
            $@"Availables algoritms:
                1. {nameof(GetFactorialLoop)}
                2. {nameof(GetFactorialRecursive)}
                3. {nameof(GetFibonacciRecursive)}
                4. {nameof(GetFibonacciRecursiveEffective)}");

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
            "Please, select algoritm (1-4):",
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
                !int.TryParse(inputValues[1], out int number) || number < 0)
            {
                return "You entered is not valid integer value!";
            }
            decimal result;
            try
            {
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
                    case 4:
                        result = GetFibonacciRecursiveEffective(number, new decimal[number + 1]);
                        break;
                    default:
                        return "Algoritm is not available!";
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                result = -1;
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
                    factorial = checked(factorial * i);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return factorial;
        }

        private static decimal GetFactorialRecursive(int number)
        {
            try
            {
                return checked((number > 1) ? number * GetFactorialRecursive(number - 1) : 1);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static decimal GetFibonacciRecursive(int number)
        {
            try
            {
                return checked((number > 1) ? GetFibonacciRecursive(number - 1) + GetFibonacciRecursive(number - 2) : number);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static decimal GetFibonacciRecursiveEffective(int number, decimal[] buffer)
        {
            try
            {
                if (number < 2)
                {
                    return number;
                }
                if (buffer[number] == 0)
                {
                    buffer[number] = checked(GetFibonacciRecursiveEffective(number - 1, buffer) + GetFibonacciRecursiveEffective(number - 2, buffer));
                }
            }
            catch (Exception)
            {
                throw;
            }
            return buffer[number];
        }
    }
}