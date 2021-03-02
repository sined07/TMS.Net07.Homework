using System;

namespace TMS.Net07.Homework.Shapes.Light
{
    class Program
    {
        static void Main(string[] args)
        {
            Shape[] shapes = {
            new Triangle(new Point(60, 25), new Point(10, 35), new Point(75, 50)),
            new Rectangle(new Point(55, 85), new Point(120, 240)),
            new Square(new Point(0, 0), 180),
            new Ellipse(new Point(105, 95), 150, 105),
            new Circle(new Point(45, 100), 80)
            };
            ConsoleDescriptionDrawer drawer = new ConsoleDescriptionDrawer();
            foreach (Shape shape in shapes)
            {
                drawer.Draw(shape);
            }
        }
    }
}