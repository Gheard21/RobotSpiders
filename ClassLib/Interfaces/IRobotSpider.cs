namespace RobotSpiders.ClassLib.Interfaces;

public interface IRobotSpider
{
    public void ProcessInit(string init);
    public void ProcessCommands(string commands);
}
