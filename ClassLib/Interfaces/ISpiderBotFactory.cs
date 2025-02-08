namespace RobotSpiders.ClassLib.Interfaces;

public interface IRobotSpiderFactory
{
    public IRobotSpider CreateRobotSpider(string position, string direction, string commands);
}
