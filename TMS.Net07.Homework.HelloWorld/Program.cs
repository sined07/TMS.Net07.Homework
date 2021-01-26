using System;

/*This is console application.
User enter integer value. 
Validate value is integer.
Exit from app if enter 0.*/ 


namespace TMS.Net07.Homework.HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            int number;
            string value;
            Console.WriteLine("To exit from application enter 0.");
            while (true) {                
                Console.WriteLine("Please, enter integer value:");
                value = Console.ReadLine();
                bool ok = int.TryParse(value, out number);
                string msg = ok ? "You enter integer: " + number.ToString() : "You enter: " + value + ". This is no integer! Try again.";
                Console.WriteLine(msg);
                if (ok && number == 0)
                {
                    Console.WriteLine("Exit from application.");
                    System.Environment.Exit(0);
                }
            }
        }
    }
}
