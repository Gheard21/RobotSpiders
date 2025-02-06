using RobotSpiders.ClassLib;
using RobotSpiders.ClassLib.Enums;

namespace RobotSpiders.ClassLibTests;

public class RobotSpiderTests
{
    [Fact]
    public void RobotSpider_OnInstantiation_CoordinatesAndDirectionSetCorrectly()
    {
        // Arrange
        var initString = "1 2 Left";
        var robotSpider = new RobotSpider();

        // Act
        robotSpider.ProcessInit(initString);

        // Assert
        Assert.Equal(1, robotSpider.Position.X);
        Assert.Equal(2, robotSpider.Position.Y);
    }

    [Fact]
    public void RobotSpider_TurnLeftWhenLeft_SetsDirectionToDown()
    {
        // Arrange
        var initString = "1 2 Left";
        var commandString = "L";
        var robotSpider = new RobotSpider();


        // Act
        robotSpider.ProcessInit(initString);
        robotSpider.ProcessCommands(commandString);

        // Assert
        Assert.Equal(Direction.Down, robotSpider.Direction);
    }

    [Fact]
    public void RobotSpider_TurnRightWhenLeft_SetsDirectionToUp()
    {
        // Arrange
        var initString = "1 2 Left";
        var commandString = "R";
        var robotSpider = new RobotSpider();

        // Act
        robotSpider.ProcessInit(initString);
        robotSpider.ProcessCommands(commandString);

        // Assert
        Assert.Equal(Direction.Up, robotSpider.Direction);
    }

    [Fact]
    public void RobotSpider_MoveForwardWhenLeft_DecrementsXCoordinate()
    {
        // Arrange
        var initString = "1 2 Left";
        var commandString = "F";
        var robotSpider = new RobotSpider();

        // Act
        robotSpider.ProcessInit(initString);
        robotSpider.ProcessCommands(commandString);

        // Assert
        Assert.Equal(0, robotSpider.Position.X);
    }

    [Fact]
    public void RobotSpider_MoveForwardWhenRight_IncrementsXCoordinate()
    {
        // Arrange
        var initString = "1 2 Right";
        var commandString = "F";
        var robotSpider = new RobotSpider();

        // Act
        robotSpider.ProcessInit(initString);
        robotSpider.ProcessCommands(commandString);

        // Assert
        Assert.Equal(2, robotSpider.Position.X);
    }

    [Fact]
    public void RobotSpider_MoveForwardWhenUp_IncrementsYCoordinate()
    {
        // Arrange
        var initString = "1 2 Up";
        var commandString = "F";
        var robotSpider = new RobotSpider();

        // Act
        robotSpider.ProcessInit(initString);
        robotSpider.ProcessCommands(commandString);

        // Assert
        Assert.Equal(3, robotSpider.Position.Y);
    }

    [Fact]
    public void RobotSpider_MoveForwardWhenDown_DecrementsYCoordinate()
    {
        // Arrange
        var initString = "1 2 Down";
        var commandString = "F";
        var robotSpider = new RobotSpider();

        // Act
        robotSpider.ProcessInit(initString);
        robotSpider.ProcessCommands(commandString);

        // Assert
        Assert.Equal(1, robotSpider.Position.Y);
    }
}
