using System;
using System.Collections.Generic;

public class ConsoleCommandDrawer
{

    private List<Shape> listShape = new List<Shape>();
    private ConsoleDescriptionDrawer logger = new ConsoleDescriptionDrawer();
    private ConsoleRenderDrawer drawer = new ConsoleRenderDrawer();

    public ConsoleCommandDrawer() 
    {
        InitShapeList();
    }

    private void InitShapeList() 
    {
        listShape.Add(new Triangle(new Point(60, 25), new Point(10, 35), new Point(75, 50)));
        listShape.Add(new Rectangle(new Point(55, 85), 120, 240));
        listShape.Add(new Square(new Point(0, 0), 180));
        listShape.Add(new Ellipse(new Point(105, 95), 150, 105));
        listShape.Add(new Circle(new Point(45, 100), 80));
    }


    public void ExecuteCommand(string command)
    {        
        switch (command)
        {            
            case string _ when command.Contains("log"):
                PrintLog();
                break;
            case string _ when command.Contains("draw"):
                DrawShape(command);                
                break;
            case string _ when command.Contains("triangle"):
                CreateTriangle(command);
                break;
            case string _ when command.Contains("rectangle"):
                CreateRectangle(command);
                break;
            case string _ when command.Contains("square"):
                CreateSquare(command);
                break;
            case string _ when command.Contains("ellipse"):
                CreateEllipse(command);
                break;            
            case string _ when command.Contains("circle"):
                CreateCircle(command);
                break;
            default:
                Console.WriteLine("Unrecognised command!");
                return;
        }
    }
    

    private void CreateRectangle(string command)
    {
    }

    private void CreateSquare(string command)
    {
    }

    private void CreateEllipse(string command)
    {
    }

    private void CreateCircle(string command)
    {
    }
   

    private void CreateTriangle(string command)
    {
    }



    private void DrawShape(string command) 
    {
        command = command.Replace("draw", "").Trim();
        bool ok = int.TryParse(command, out int index);
        index = (index < 0) ? listShape.Count + index : index - 1;
        if (!ok || index < 0 || index >= listShape.Count)
        {
            Console.WriteLine("The shape with the specified index does not exist!");
            return;
        }
        drawer.Draw(listShape[index]);
    }

    private void PrintLog() {
        foreach (Shape shape in listShape)
        {
            logger.Draw(shape);
        }    
    }
}