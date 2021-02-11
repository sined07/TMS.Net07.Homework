using System;
using System.Runtime.InteropServices;


public class ConsoleRenderDrawer : Drawer
{
   
   

    public override void Draw(Shape shape)
    {
        ConsoleWriteImage();
    }

    public static void ConsoleWriteImage()
    {
        
        for (int i = 0; i < 100; i++)
        {
            for (int j = 0; j < 100; j++)
            {
                Console.ForegroundColor = 0;
                Console.Write("██");
            }
            System.Console.WriteLine();
        }
    }
}
