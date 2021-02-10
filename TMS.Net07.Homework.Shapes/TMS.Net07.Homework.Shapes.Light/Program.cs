using System;

namespace TMS.Net07.Homework.Shapes.Light
{
    class Program
    {
        static void Main(string[] args)
        {
            Test();
        }

        public static void Test()
        {
            Shape[] shapes = {
            new Point(15.1025, 10.478),
            new Rectangle(new Point(17.54, -14.23), 10.54, 20.111),
            new Square(new Point(0, 0), 19.23),
            new Ellipse(new Point(0, 0), 15.23, 0.4),
            new Circle(new Point(45.26, 51), 7.393)
            };
            foreach (Shape shape in shapes)
            {
                Console.WriteLine($"Area = {shape.GetArea()}");
            }
        }
    }
}