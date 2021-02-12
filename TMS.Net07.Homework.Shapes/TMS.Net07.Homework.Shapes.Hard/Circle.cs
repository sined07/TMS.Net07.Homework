using System;

public class Circle : Ellipse
{
    public Circle(Point point, int radius)
    {
        Point = point;
        Width = radius * 2;
        Height = radius * 2;
    }

    public override string GetInfo()
    {
        return $"{ToString()}: center {Point.GetInfo()}, radius {Width / 2}";
    }

    public override string GetStringPrototype()
    {
        return
        "  ***  " + Environment.NewLine +
        "*******" + Environment.NewLine +
        "*******" + Environment.NewLine +
        "  ***  " + Environment.NewLine;
    }
}