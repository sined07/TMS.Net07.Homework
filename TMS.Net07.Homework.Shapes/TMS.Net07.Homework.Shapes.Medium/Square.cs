public class Square : Rectangle
{
    public Square(Point point, int width)
    {
        Point = point;
        Width = width;
        Height = width;
    }

    public override string GetStringPrototype()
    {
        return GetStringFromLines(new string[]
        {
        "*******",
        "*******",
        "*******",
        "*******"
        });
    }
}