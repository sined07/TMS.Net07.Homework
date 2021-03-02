using System;

public class ConsoleRenderDrawer : Drawer
{
    public override void Draw(Shape shape)
    {
        Console.WriteLine(shape.GetStringPrototype());
    }
}