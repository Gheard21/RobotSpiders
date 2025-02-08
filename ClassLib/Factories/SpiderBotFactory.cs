using RobotSpiders.ClassLib.Interfaces;

namespace RobotSpiders.ClassLib.Factories;

public static class RobotSpiderFactory
{
    public static IRobotSpider CreateRobotSpider(string position, string direction, string commands)
    {
        return new RobotSpider()
            .InitializePosition(position)
            .InitializeDirection(direction)
            .InitializeCommands(commands);
    }
}