using Simulator;
namespace TestSimulator;
public class PointTests
{
    [Theory]
    [InlineData(0, 0, Direction.Up, 0, 1)]
    [InlineData(1, 1, Direction.Right, 2, 1)]
    [InlineData(2, 2, Direction.Down, 2, 1)]
    [InlineData(3, 3, Direction.Left, 2, 3)]
    public void Next_CalculatesCorrectPoint(int x, int y, Direction direction, int expectedX, int expectedY)
    {
        var point = new Point(x, y);
        var result = point.Next(direction);

        Assert.Equal(expectedX, result.X);
        Assert.Equal(expectedY, result.Y);
    }

    [Theory]
    [InlineData(0, 0, Direction.Up, 1, 1)]
    [InlineData(1, 1, Direction.Right, 2, 1)]
    [InlineData(2, 2, Direction.Left, 1, 2)]
    public void NextDiagonal_CalculatesCorrectPoint(int x, int y, Direction direction, int expectedX, int expectedY)
    {
        var point = new Point(x, y);
        var result = point.NextDiagonal(direction);

        Assert.Equal(expectedX, result.X);
        Assert.Equal(expectedY, result.Y);
    }
}
