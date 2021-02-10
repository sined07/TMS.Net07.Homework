using System;

public abstract class Shape
{
    public abstract double GetArea();
}

public class Point : Shape
{
    public double X { get; set; }
    public double Y { get; set; }

    public Point(double x, double y)
    {
        X = x;
        Y = y;
    }
    public override double GetArea()
    {
        return 0;
    }
}

public class Rectangle : Shape
{
    public Point Point { get; set; }
    public double Width { get; set; }
    public double Height { get; set; }

    protected Rectangle()
    {
    }

    public Rectangle(Point point, double width, double height)
    {
        Point = point;
        Width = width;
        Height = height;
    }

    public Rectangle(double x, double y, double width, double height)
    {
        Point = new Point(x, y);
        Width = width;
        Height = height;
    }

    public override double GetArea()
    {
        return Width * Height;
    }
}

public class Square : Rectangle
{
    public Square(Point point, double width)
    {
        Point = point;
        Width = width;
        Height = width;
    }
    public Square(double x, double y, double width)
    {
        Point = new Point(x, y);
        Width = width;
        Height = width;
    }
}

public class Ellipse : Shape
{
    public Point Point { get; set; }
    public double Width { get; set; }
    public double Height { get; set; }

    protected Ellipse()
    {
    }

    public Ellipse(Point point, double width, double height)
    {
        Point = point;
        Width = width;
        Height = height;
    }

    public Ellipse(double x, double y, double width, double height)
    {
        Point = new Point(x, y);
        Width = width;
        Height = height;
    }

    public override double GetArea()
    {
        return Math.PI * Width * Height;
    }
}

public class Circle : Ellipse
{
    public Circle(Point point, double radius)
    {
        Point = point;
        Width = radius;
        Height = radius;
    }
    public Circle(double x, double y, double radius)
    {
        Point = new Point(x, y);
        Width = radius;
        Height = radius;
    }
}