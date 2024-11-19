using Simulator;
using Simulator.Maps;
namespace TestSimulator;
public class SmallSquareMapTests
{
    [Fact]
    public void Constructor_ThrowsArgumentOutOfRangeException_ForInvalidSize()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new SmallSquareMap(4)); // Zbyt mały
        Assert.Throws<ArgumentOutOfRangeException>(() => new SmallSquareMap(21)); // Zbyt duży
    }

    [Fact]
    public void Exist_ReturnsTrue_ForPointInsideBoundaries()
    {
        var map = new SmallSquareMap(5);
        var point = new Point(2, 2);

        Assert.True(map.Exist(point));
    }

    [Fact]
    public void Exist_ReturnsFalse_ForPointOutsideBoundaries()
    {
        var map = new SmallSquareMap(5);
        var point = new Point(5, 5);

        Assert.False(map.Exist(point));
    }

    [Theory]
    [InlineData(0, 0, Direction.Up, 0, 1)]
    [InlineData(4, 4, Direction.Right, 4, 4)] // Poza granicami - brak zmian
    public void Next_ReturnsCorrectPoint(int x, int y, Direction direction, int expectedX, int expectedY)
    {
        var map = new SmallSquareMap(5);
        var point = new Point(x, y);
        var result = map.Next(point, direction);

        Assert.Equal(expectedX, result.X);
        Assert.Equal(expectedY, result.Y);
    }
}
