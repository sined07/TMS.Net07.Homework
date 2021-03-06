﻿using System;

namespace TMS.Net07.Homework.Calculator.Hard
{
    class Program
    {

        private static string[] operators = { "+", "-", "*", "/", "%", "pow", "sqrt", "sqr" };

        static void Main(string[] args)
        {
            Console.WriteLine("This is simple calculator.");
            Console.WriteLine("Supported operations: " + "[{0}]", string.Join(", ", operators));
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
            Console.WriteLine("Enter expression (e.g. '7.3 + 5', '2 pow 3', 'sqrt 9'):");
            string inputExpression = Console.ReadLine().Trim().Replace('.', ',');
            string[] inputValues = { "num1", "num2", "operator" };
            for (int i = 0; i < operators.Length; i++)
            {
                if (inputExpression.Contains(operators[i]))
                {
                    inputValues[2] = operators[i];
                    inputExpression = inputExpression.Replace(operators[i], " ");
                    string[] temp = inputExpression.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    //copy temp (user inputs) in inputValues (template array)
                    Array.Copy(temp, inputValues, (temp.Length > 2) ? 2 : temp.Length);
                    if (IsUnaryOperator(operators[i]))
                    {
                        inputValues[1] = "0";
                    }
                    break;
                }
            }
            return inputValues;
        }

        private static bool IsUnaryOperator(string op)
        {
            return (op == "sqr") || (op == "sqrt");
        }

        private static string GetResultMessage(string[] inputValues)
        {
            if (!double.TryParse(inputValues[0], out double num1) ||
                !double.TryParse(inputValues[1], out double num2))
            {
                return "Entered number is not valid!";
            }
            if (num2 == 0 && (inputValues[2] == "/" || inputValues[2] == "%"))
            {
                return "Error - divide by 0!";
            }

            double result;
            switch (inputValues[2])
            {
                case "+":
                    result = num1 + num2;
                    break;
                case "-":
                    result = num1 - num2;
                    break;
                case "*":
                    result = num1 * num2;
                    break;
                case "/":
                    result = num1 / num2;
                    break;
                case "%":
                    result = num1 % num2;
                    break;
                case "pow":
                    result = Math.Pow(num1, num2);
                    break;
                case "sqr":
                    result = num1 * num1;
                    break;
                case "sqrt":
                    result = Math.Sqrt(num1);
                    break;
                default:
                    return "Unsupported operation!";
            }
            return $"result: {result}";
        }
    }
}