using System.Drawing;
using RobotSpiders.ClassLib;
using RobotSpiders.ClassLib.Enums;

namespace RobotSpiders.ClassLibTests;

public class RobotSpiderTests
{
    [Fact]
    public void InitializePosition_WithValidPositionString_SetsPosition()
    {
        // Arrange
        var robotSpider = new RobotSpider();
        var position = "1 2";

        // Act
        robotSpider.InitializePosition(position);

        // Assert
        Assert.Equal(new Point(1, 2), robotSpider.Position);
    }

    [Fact]
    public void InitializePosition_WithInvalidPositionString_ThrowsArgumentException()
    {
        // Arrange
        var robotSpider = new RobotSpider();
        var position = "1";

        // Act
        void action() => robotSpider.InitializePosition(position);

        // Assert
        Assert.Throws<ArgumentException>(action);
    }

    [Fact]
    public void InitializePosition_WithInvalidPositionStringFormat_ThrowsArgumentException()
    {
        // Arrange
        var robotSpider = new RobotSpider();
        var position = "1 a";

        // Act
        void action() => robotSpider.InitializePosition(position);

        // Assert
        Assert.Throws<ArgumentException>(action);
    }

    [Fact]
    public void InitializeDirection_WithValidDirectionString_SetsDirection()
    {
        // Arrange
        var robotSpider = new RobotSpider();
        var direction = "Up";

        // Act
        robotSpider.InitializeDirection(direction);

        // Assert
        Assert.Equal(Direction.Up, robotSpider.Direction);
    }

    [Fact]
    public void InitializeDirection_WithInvalidDirectionString_ThrowsArgumentException()
    {
        // Arrange
        var robotSpider = new RobotSpider();
        var direction = "Invalid";

        // Act
        void action() => robotSpider.InitializeDirection(direction);

        // Assert
        Assert.Throws<ArgumentException>(action);
    }

    [Fact]
    public void InitializeCommands_WithInvalidCommandsString_ThrowsArgumentException()
    {
        // Arrange
        var robotSpider = new RobotSpider();
        var commands = "LRFZ";

        // Act
        void action() => robotSpider.InitializeCommands(commands);

        // Assert
        Assert.Throws<ArgumentException>(action);
    }

    [Fact]
    public void ExecuteCommands_TurnsLeftDoesNotMove()
    {
        // Arrange
        var robotSpider = new RobotSpider()
            .InitializePosition("1 1")
            .InitializeDirection("Up")
            .InitializeCommands("L");

        // Act
        robotSpider.ExecuteCommands();

        // Assert
        Assert.Equal(new Point(1, 1), robotSpider.Position);
        Assert.Equal(Direction.Left, robotSpider.Direction);
    }

    [Fact]
    public void ExecuteCommands_TurnsRightDoesNotMove()
    {
        // Arrange
        var robotSpider = new RobotSpider()
            .InitializePosition("1 1")
            .InitializeDirection("Up")
            .InitializeCommands("R");

        // Act
        robotSpider.ExecuteCommands();

        // Assert
        Assert.Equal(new Point(1, 1), robotSpider.Position);
        Assert.Equal(Direction.Right, robotSpider.Direction);
    }

    [Fact]
    public void ExecuteCommands_MovesForward()
    {
        // Arrange
        var robotSpider = new RobotSpider()
            .InitializePosition("1 1")
            .InitializeDirection("Up")
            .InitializeCommands("F");

        // Act
        robotSpider.ExecuteCommands();

        // Assert
        Assert.Equal(new Point(1, 2), robotSpider.Position);
        Assert.Equal(Direction.Up, robotSpider.Direction);
    }

    [Fact]
    public void ExecuteCommands_ExecutesCommandsCorrectly()
    {
        // Arrange
        var robotSpider = new RobotSpider()
            .InitializePosition("1 1")
            .InitializeDirection("Up")
            .InitializeCommands("FLF");

        // Act
        robotSpider.ExecuteCommands();

        // Assert
        Assert.Equal(new Point(0, 2), robotSpider.Position);
        Assert.Equal(Direction.Left, robotSpider.Direction);
    }
}
