using System;
using System.Collections.Generic;

public class ConsoleCommandDrawer
{
    private List<Shape> _listShape = new List<Shape>();
    private ConsoleDescriptionDrawer _logger = new ConsoleDescriptionDrawer();
    private ConsoleRenderDrawer _drawer = new ConsoleRenderDrawer();
    private bool _isWork = true;
    private readonly string[,] _commands = new string[,]
    {
        { "exit", "exit" },
        { "help", "help" },
        { "log", "log" },
        { "draw", "draw 1"},
        { nameof(Square).ToLower(), "square (30,50) 15" },
        { nameof(Circle).ToLower(), "circle (25,20) 10" },
        { nameof(Ellipse).ToLower(), "ellipse (5,9) 3 7" },
        { nameof(Triangle).ToLower(), "triangle (1,3) (2,4) (3,4)" },
        { nameof(Rectangle).ToLower(), "rectangle (15,21) (35,80)" }
    };

    public void Init()
    {
        PrintHelp();
        while (_isWork)
        {
            Console.WriteLine("Enter command:");
            ExecuteCommand(Console.ReadLine().ToLower());
        }
    }

    private void ExecuteCommand(string command)
    {
        int[] args;
        Shape shape;
        int index = -1;
        switch (command)
        {
            // command exit
            case string _ when command.Contains(_commands[++index, 0]):
                _isWork = false;
                return;
            // command help
            case string _ when command.Contains(_commands[++index, 0]):
                PrintHelp();
                return;
            // command log
            case string _ when command.Contains(_commands[++index, 0]):
                PrintLog();
                return;
            // command draw
            case string _ when command.Contains(_commands[++index, 0]):
                args = GetIntArgs(command, _commands[index, 0]);
                DrawShape(args);
                return;
            // command square
            case string _ when command.Contains(_commands[++index, 0]):
                args = GetIntArgs(command, _commands[index, 0]);
                shape = (args == null || args.Length != 3) ? null :
                        new Square(new Point(args[0], args[1]), args[2]);
                break;
            // command circle
            case string _ when command.Contains(_commands[++index, 0]):
                args = GetIntArgs(command, _commands[index, 0]);
                shape = (args == null || args.Length != 3) ? null :
                        new Circle(new Point(args[0], args[1]), args[2]);
                break;
            // command ellipse
            case string _ when command.Contains(_commands[++index, 0]):
                args = GetIntArgs(command, _commands[index, 0]);
                shape = (args == null || args.Length != 4) ? null :
                        new Ellipse(new Point(args[0], args[1]),
                        args[2], args[3]);
                break;
            // command triangle
            case string _ when command.Contains((_commands[++index, 0])):
                args = GetIntArgs(command, _commands[index, 0]);
                shape = (args == null || args.Length != 6) ? null :
                        new Triangle(
                        new Point(args[0], args[1]),
                        new Point(args[2], args[3]),
                        new Point(args[4], args[5]));
                break;
            // command rectangle
            case string _ when command.Contains(_commands[++index, 0]):
                args = GetIntArgs(command, _commands[index, 0]);
                shape = (args == null || args.Length != 4) ? null :
                        new Rectangle(
                        new Point(args[0], args[1]),
                        new Point(args[2], args[3]));
                break;
            default:
                Console.WriteLine("Unsupported command!");
                return;
        }
        AddShape(shape);
    }

    private int[] GetIntArgs(string command, string separator)
    {
        string[] separators = { separator, "(", ")", ".", ",", " " };
        string[] temp = command.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        int[] args = new int[temp.Length];
        for (int i = 0; i < args.Length; i++)
        {
            bool ok = int.TryParse(temp[i], out args[i]);
            if (!ok)
            {
                return null;
            }
        }
        return args;
    }

    private void DrawShape(int[] args)
    {
        if (args == null || args.Length == 0)
        {
            Console.WriteLine("Index shape to draw is unrecognised!");
            return;
        }
        int index = args[0];
        index = (index < 0) ? _listShape.Count + index : index - 1;
        if (index < 0 || index >= _listShape.Count)
        {
            Console.WriteLine("The shape with the specified index does not exist!");
            return;
        }
        _drawer.Draw(_listShape[index]);
    }

    private void PrintLog()
    {
        if (_listShape.Count == 0)
        {
            Console.WriteLine("Log is empty!");
            return;
        }

        int i = 0;
        foreach (Shape shape in _listShape)
        {
            _logger.Draw($"{ ++i}. ", shape);
        }
    }

    private void AddShape(Shape shape)
    {
        if (shape == null)
        {
            Console.WriteLine("Unrecognised shape args!");
            return;
        }
        _listShape.Add(shape);
        _drawer.Draw(shape);
    }

    private void PrintHelp()
    {
        Console.WriteLine("Supported commands:");
        for (int i = 0; i < _commands.GetLength(0); i++)
        {
            string tab = _commands[i, 0].Length < 8 ? "\t\t" : "\t";
            Console.WriteLine($"{_commands[i, 0]}{tab}example usage: {_commands[i, 1]}");
        }
    }

    private void Test()
    {
        for (int i = _commands.GetLength(0) - 1; i >= 0; i--)
        {
            string command = _commands[i, 1];
            Console.WriteLine("Execute command: " + command);
            ExecuteCommand(command);
        }
    }
}