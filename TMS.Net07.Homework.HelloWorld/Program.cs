using System;

/*This is console application.
User entered integer value. 
Validate value is integer.
Exit from app if enter 0.*/ 


namespace TMS.Net07.Homework.HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            bool ok;
            int number;
            string value;            
            Console.WriteLine("To exit from application enter 0.");
            while (true) {                
                Console.WriteLine("Please, enter integer value:");
                value = Console.ReadLine();
                ok = int.TryParse(value, out number);                
                Console.WriteLine($"You entered: {value}{(ok ? "": ". This is not integer! Try again.")}");              
                if (ok && number == 0)
                {
                    Console.WriteLine("Exit from application.");
                    return;
                }
            }
        }
    }
}
