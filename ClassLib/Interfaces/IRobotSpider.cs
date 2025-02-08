namespace RobotSpiders.ClassLib.Interfaces;

public interface IRobotSpider
{
    public RobotSpider InitializePosition(string position);
    public RobotSpider InitializeDirection(string direction);
    public RobotSpider InitializeCommands(string commands);
    public void ExecuteCommands();
    public void PrintPosition();
    public void PrintCommandsExecuted();
    public Guid GetBotId();
}
