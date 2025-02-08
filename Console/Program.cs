using RobotSpiders.ClassLib;
using RobotSpiders.ClassLib.Factories;
using RobotSpiders.ClassLib.Interfaces;

var input = @"
10 10
5 5 Left
FRFLLFF
3 3 Right
FLFLFRF
2 2 Up
FFRFF
";

var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

// create wall
var wall = new Wall()
    .InitializeDimensions(lines[0]);

var botsText = lines.Skip(1).ToArray();

var bots = new List<IRobotSpider>();

for (var i = 0; i < botsText.Length; i += 2)
{
    var firstLine = botsText[i];
    var secondLine = botsText[i + 1];
    var splitFirstLine = firstLine.Split(' ');
    var position = string.Join(' ', splitFirstLine.Take(2));
    var direction = splitFirstLine.Last();
    var bot = RobotSpiderFactory.CreateRobotSpider(position, direction, secondLine);
    bots.Add(bot);
}

foreach (var bot in bots) 
{
    Console.WriteLine("Bot with Id {0} logs the following information...", bot.GetBotId());
    Console.Write("Initial position: ");
    bot.PrintPosition();
    bot.ExecuteCommands();
    Console.Write("Final position: ");
    bot.PrintPosition();
    bot.PrintCommandsExecuted();
}