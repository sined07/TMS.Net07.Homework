using System;
using System.Collections.Generic;

public class ConsoleCommandDrawer
{

    private List<Shape> listShape = new List<Shape>();

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

    public void SetCommand(string command) 
    {
    
    }
    



}