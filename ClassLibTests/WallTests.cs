using System;
using RobotSpiders.ClassLib;

namespace RobotSpiders.ClassLibTests;

public class WallTests
{
    [Fact]
    public void InitializeDimensions_WithValidDimensions_ShouldSetWidthAndHeight()
    {
        // Arrange
        var wall = new Wall();
        var dimensions = "5 5";

        // Act
        wall.InitializeDimensions(dimensions);

        // Assert
        Assert.Equal(5, wall.Width);
        Assert.Equal(5, wall.Height);
    }

    [Fact]
    public void InitializeDimensions_WithInvalidDimensionsFormat_ShouldThrowArgumentException()
    {
        // Arrange
        var wall = new Wall();
        var dimensions = "5";

        // Act
        Action act = () => wall.InitializeDimensions(dimensions);

        // Assert
        var exception = Assert.Throws<ArgumentException>(act);
        Assert.Equal("Invalid dimensions format", exception.Message);
    }
}
