public class Ellipse : Shape
{
    public Point Point { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }

    protected Ellipse()
    {
    }

    public Ellipse(Point point, int width, int height)
    {
        Point = point;
        Width = width;
        Height = height;
    }

    public override string GetInfo()
    {
        return $"{ToString()}: center {Point.GetInfo()}, width {Width}, height {Height}";
    }
}
