using System.Drawing;
using RobotSpiders.ClassLib.Enums;
using RobotSpiders.ClassLib.Interfaces;

namespace RobotSpiders.ClassLib;

public class RobotSpider : IRobotSpider
{
    private string _commands = default!;
    private readonly Dictionary<char, Action> _commandActions;
    private readonly static Dictionary<Direction, Point> _positionOffsets = new()
    {
        { Direction.Up, new Point(0, 1) },
        { Direction.Right, new Point(1, 0) },
        { Direction.Down, new Point(0 -1) },
        { Direction.Left, new Point(-1, 0) }
    };

    public Guid BotId { get; set; } = Guid.NewGuid();
    public Point Position { get; private set; }
    public Direction Direction { get; private set; }

    public RobotSpider()
    {
        _commandActions = new Dictionary<char, Action>
        {
            { 'F', MoveForward },
            { 'L', TurnLeft },
            { 'R', TurnRight }
        };
    }

    public RobotSpider InitializeDirection(string direction)
    {
        if (!Enum.TryParse(direction, out Direction parsedDirection))
            throw new ArgumentException("Invalid direction");

        Direction = parsedDirection;
        return this;
    }

    public RobotSpider InitializePosition(string position)
    {
        var splitPosition = position.Split(' ');

        if (splitPosition.Length != 2)
            throw new ArgumentException("Invalid position format");

        if (!int.TryParse(splitPosition[0], out var x) || !int.TryParse(splitPosition[1], out var y))
            throw new ArgumentException("Invalid position format");

        Position = new Point(x, y);
        return this;
    }

    public RobotSpider InitializeCommands(string commands)
    {
        foreach (var command in commands)
            if (!_commandActions.ContainsKey(command))
                throw new ArgumentException("Invalid command");

        _commands = commands;
        return this;
    }

    private void MoveForward()
    {
        var positionOffset = _positionOffsets[Direction];
        Position = new Point(Position.X + positionOffset.X, Position.Y + positionOffset.Y);
    }

    private void TurnLeft() => Direction = Direction == Direction.Up ? Direction.Left : Direction - 1;

    private void TurnRight() => Direction = Direction == Direction.Left ? Direction.Up : Direction + 1;

    public void ExecuteCommands()
    {
        foreach (var command in _commands)
            _commandActions[command]();
    }

    public void PrintPosition()
    {
        Console.WriteLine("{0} {1} {2}", Position.X, Position.Y, Direction);
    }

    public void PrintCommandsExecuted()
    {
        Console.WriteLine("Commands executed: {0}", _commands);
    }

    public Guid GetBotId() => BotId;
}
