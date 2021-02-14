using System;

public class ConsoleDescriptionDrawer : Drawer
{
    public override void Draw(Shape shape)
    {
        Console.WriteLine(shape.GetInfo());
    }

    public void Draw(string prefix, Shape shape)
    {
        string info = shape.GetInfo().ToLower()
            .Replace("point", "").Replace(", radius", "").Replace("center", "")
            .Replace(":", "").Replace(", width", "").Replace(", height", "")
            .Replace("   ", " ").Replace("  ", " ").Replace("), (", ") (");
        
        Console.WriteLine(prefix + info);
    }
}
