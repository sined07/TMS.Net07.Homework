using System.Text;

public abstract class Shape
{
    public virtual string GetInfo()
    {
        return string.Empty;
    }
    public virtual string GetStringPrototype()
    {
        return string.Empty;
    }

    protected string GetStringFromLines(string[] lines)
    {
        StringBuilder builder = new StringBuilder();
        foreach (string line in lines)
        {
            builder.AppendLine(line);
        }
        return builder.ToString();
    }
}