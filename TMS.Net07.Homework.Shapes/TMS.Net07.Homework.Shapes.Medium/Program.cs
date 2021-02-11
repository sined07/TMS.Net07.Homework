using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Net07.Homework.Shapes.Medium
{
    class Program
    {
        [DllImport("kernel32.dll", EntryPoint = "GetConsoleWindow", SetLastError = true)]
        private static extern IntPtr GetConsoleHandle();


        static void Main(string[] args)
        {

            DrawInConsoleFromGraphics();
            Console.ReadLine();
        }
        


        static void DrawInConsoleFromGraphics()
        {
            var handler = GetConsoleHandle();

            string directory = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
            string filePath = Path.Combine(directory, @"..\..\..\images\triangle.jpg");

            using (var graphics = Graphics.FromHwnd(handler))                
            using (var image = Image.FromFile(filePath))
                graphics.DrawImage(image, 50, 50, 250, 200);
        }



        static void Test()
        {
            Shape[] shapes = {
            new Triangle(new Point(60, 25), new Point(10, 35), new Point(75, 50)),
            new Rectangle(new Point(55, 85), 120, 240),
            new Square(new Point(0, 0), 180),
            new Ellipse(new Point(105, 95), 150, 105),
            new Circle(new Point(45, 100), 80)
            };
            ConsoleRenderDrawer drawer = new ConsoleRenderDrawer();
            ConsoleDescriptionDrawer desc = new ConsoleDescriptionDrawer();
            foreach (Shape shape in shapes)
            {
                drawer.Draw(shape);
                desc.Draw(shape);
                break;
            }
        }
        
    }
}
