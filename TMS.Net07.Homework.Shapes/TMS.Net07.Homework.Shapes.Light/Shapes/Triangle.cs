﻿public class Triangle : Shape
{
    public Point Point1 { get; set; }
    public Point Point2 { get; set; }
    public Point Point3 { get; set; }

    protected Triangle()
    {
    }

    public Triangle(Point point1, Point point2, Point point3)
    {
        Point1 = point1;
        Point2 = point2;
        Point3 = point3;
    }

    public override string GetInfo()
    {
        return $"{ToString()}: {Point1.GetInfo()}, {Point2.GetInfo()}, {Point3.GetInfo()}";
    }
}
