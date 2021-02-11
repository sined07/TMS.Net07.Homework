using System;

public class ConsoleDescriptionDrawer : Drawer
{
    public override void Draw(Shape shape)
    {
        Console.WriteLine(shape.GetInfo());
    }
}
