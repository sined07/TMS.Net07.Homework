using System;

namespace TMS.Net07.Homework.Calculator.Medium
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is simple calculator.");
            Console.WriteLine("Supported operations: +, -, *, /, %");
            while (true)
            {
                string[] inputValues = GetInputValues();
                Console.WriteLine(GetResultMessage(inputValues));
                Console.WriteLine("Try again? (y/n):");
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
            "Enter first number:",
            "Enter second number:",
            "Enter operation:"
            };
            string[] inputValues = new string[messages.Length];
            for (int i = 0; i < messages.Length; i++)
            {
                Console.WriteLine(messages[i]);
                inputValues[i] = Console.ReadLine().Trim().Replace('.', ',');
            }
            return inputValues;
        }

        private static string GetResultMessage(string[] inputValues)
        {
            if (!double.TryParse(inputValues[0], out double num1) ||
                !double.TryParse(inputValues[1], out double num2))
            {
                return "Entered number is not valid!";
            }
            switch (inputValues[2])
            {
                case "+":
                    return ("result: " + (num1 + num2));
                case "-":
                    return ("result: " + (num1 - num2));
                case "*":
                    return ("result: " + (num1 * num2));
                case "/":
                    return (num2 == 0) ? "Error - divide by 0!" : ("result: " + (num1 / num2));
                case "%":
                    return (num2 == 0) ? "Error - remainder by 0!" : ("result: " + (num1 % num2));
            }

            return "Unsupported operation!";
        }
    }
}
