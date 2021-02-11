public class Rectangle : Shape
{
    public Point Point { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }

    protected Rectangle()
    {
    }

    public Rectangle(Point point, int width, int height)
    {
        Point = point;
        Width = width;
        Height = height;
    }

    public override string GetInfo()
    {
        return $"{ToString()}: " +
            $"{Point.GetInfo()}, " +
            $"{new Point(Point.X + Width, Point.Y).GetInfo()}, " +
            $"{new Point(Point.X + Width, Point.Y + Height).GetInfo()}, " +
            $"{new Point(Point.X, Point.Y + Height).GetInfo()}";
    }
}