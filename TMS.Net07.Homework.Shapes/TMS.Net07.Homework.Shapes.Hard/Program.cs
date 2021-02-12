using System;

namespace TMS.Net07.Homework.Shapes.Hard
{
    class Program
    {
        static void Main(string[] args)
        {           
            string command1 = "log";
            string command2 = "draw5";
            string command3 = "draw -3";

            ConsoleCommandDrawer drawer = new ConsoleCommandDrawer();
            drawer.ExecuteCommand(command1);
            drawer.ExecuteCommand(command2);
            drawer.ExecuteCommand(command3);
        }
    }
}
