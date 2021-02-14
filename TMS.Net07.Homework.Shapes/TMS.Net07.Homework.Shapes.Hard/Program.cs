using System;

namespace TMS.Net07.Homework.Shapes.Hard
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleCommandDrawer drawer = new ConsoleCommandDrawer();
            drawer.Init();
        }

        public static void Test()
        {
            string[] commands =
            {
            "help",
            "square (30,50) 15",
            "circle (25,20) 10",
            "ellipse (5,9) 3 7" ,
            "triangle (1,3) (2,4) (3,4)",
            "rectangle (15,21) (35,80)",
            "log",
            "draw -1"
            };
            ConsoleCommandDrawer drawer = new ConsoleCommandDrawer();
            foreach (string command in commands)
            {
                drawer.ExecuteCommand(command);

            }
        }
    }
}
