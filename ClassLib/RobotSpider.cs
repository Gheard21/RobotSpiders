using System.Drawing;
using RobotSpiders.ClassLib.Enums;
using RobotSpiders.ClassLib.Interfaces;

namespace RobotSpiders.ClassLib;

public class RobotSpider() : IRobotSpider
{
    public Point Position { get; private set; }
    public Direction Direction { get; set; }

    /// <summary>
    /// Initializes the RobotSpider with the specified position and direction.
    /// </summary>
    /// <param name="init">
    /// A string containing the initial position and direction in the format "X Y Direction".
    /// Example: "1 2 Up".
    /// </param>
    /// <exception cref="ArgumentException">
    /// Thrown when the initialization string is invalid or cannot be parsed.
    /// </exception>

    public void ProcessInit(string init)
    {
        var args = init.Split(' ');
        Position = new Point(int.Parse(args[0]), int.Parse(args[1]));
        Direction = Enum.Parse<Direction>(args[2]);
    }

    /// <summary>
    /// Processes a string of commands to control the RobotSpider.
    /// </summary>
    /// <param name="commands">
    /// A string containing the commands to be processed. Each character represents a command:
    /// 'F' for MoveForward, 'L' for TurnLeft, and 'R' for TurnRight.
    /// </param>
    /// <exception cref="ArgumentException">
    /// Thrown when an invalid command is encountered in the command string.
    /// </exception>

    public void ProcessCommands(string commands)
    {
        var commandActions = new Dictionary<char, Action>
        {
            { 'F', MoveForward },
            { 'L', TurnLeft },
            { 'R', TurnRight }
        };

        foreach (var command in commands)
        {
            if (commandActions.TryGetValue(command, out var action))
                action();
            else
                throw new ArgumentException($"Invalid command: {command}");
        }
    }

    private void MoveForward()
    {
        var directionOffsets = new Dictionary<Direction, Point>
        {
            { Direction.Left, new Point(-1, 0) },
            { Direction.Right, new Point(1, 0) },
            { Direction.Up, new Point(0, 1) },
            { Direction.Down, new Point(0, -1) }
        };

        var offset = directionOffsets[Direction];
        Position = new Point(Position.X + offset.X, Position.Y + offset.Y);
    }

    private void TurnLeft() =>
        Direction = (Direction)(((int)Direction + 3) % 4);

    private void TurnRight() => 
        Direction = (Direction)(((int)Direction + 1) % 4);
}
