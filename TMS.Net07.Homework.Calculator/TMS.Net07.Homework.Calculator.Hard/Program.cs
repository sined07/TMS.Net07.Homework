using System;

namespace TMS.Net07.Homework.Calculator.Hard
{
    class Program
    {

        private static string[] operators = { "+", "-", "*", "/", "%", "pow", "sqrt", "sqr" };
        
        static void Main(string[] args)
        {
            string[] inputValues = { "10 + 3", "10-3", "10*3", "10/3", "10%3", "10 pow 3", "sqr3", "sqrt 10" };
            for (int i = 0; i < inputValues.Length; i++)
            {
                ParseStringExpression(inputValues[i]);
            }
        }

        private static void ParseStringExpression(string input) 
        {       
            for (int i = 0; i < operators.Length; i++) {
                if (input.Contains(operators[i]))
                {
                    input = input.Replace(operators[i], " ");
                    string[] words = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    Array.Resize(ref words, 3);
                    words[2] = operators[i];                    
                    Console.WriteLine("[{0}]", string.Join(", ", words));
                    if (operators[i] == "sqrt" || operators[i] == "sqr") 
                    {
                        words[1] = "0";
                    }
                    Console.WriteLine(GetResultMessage(words));
                }
            }         
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
                case "pow":
                    return ("result: " + Math.Pow(num1, num2));
                case "sqr":
                    return ("result: " + Math.Pow(num1, 2));
                case "sqrt":
                    return ("result: " + Math.Sqrt(num1));

            }

            return "Unsupported operation!";
        }
        
    }
}
