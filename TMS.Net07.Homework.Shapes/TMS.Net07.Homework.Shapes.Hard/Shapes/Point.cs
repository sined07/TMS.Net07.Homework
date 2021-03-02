using System;

public class Point
{
    public int X { get; set; }
    public int Y { get; set; }

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    public string GetInfo()
    {
        return $"{ToString()}({X}, {Y})";
    }

    public double getDistance(Point p)
    {
        return Math.Sqrt(Math.Pow((p.X - X), 2) + Math.Pow((p.Y - Y), 2));
    }
}