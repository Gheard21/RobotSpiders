using System;
using RobotSpiders.ClassLib.Interfaces;

namespace RobotSpiders.ClassLib;

public class Wall : IWall
{
    public int Height { get; private set; }
    public int Width { get; private set; }

    public IWall InitializeDimensions(string dimensions)
    {
        var splitDimensions = dimensions.Split(' ');

        if (splitDimensions.Length != 2)
            throw new ArgumentException("Invalid dimensions format");

        if (!int.TryParse(splitDimensions[0], out var width) || !int.TryParse(splitDimensions[1], out var height))
            throw new ArgumentException("Invalid dimensions format");

        if (width < 1 || height < 1)
            throw new ArgumentException("Invalid dimensions");

        Width = width;
        Height = height;
        return this;
    }
}
