using Simulator;
namespace TestSimulator;
public class RectangleTests
{
    [Fact]
    public void Constructor_SwapsCoordinates_WhenGivenOutOfOrder()
    {
        var rect = new Rectangle(5, 5, 1, 1);

        Assert.Equal(1, rect.X1);
        Assert.Equal(1, rect.Y1);
        Assert.Equal(5, rect.X2);
        Assert.Equal(5, rect.Y2);
    }

    [Fact]
    public void Constructor_ThrowsArgumentException_ForThinRectangle()
    {
        Assert.Throws<ArgumentException>(() => new Rectangle(1, 1, 1, 2));
        Assert.Throws<ArgumentException>(() => new Rectangle(1, 1, 2, 1));
    }

    [Theory]
    [InlineData(2, 2, 5, 5, 3, 3, true)]  // Punkt wewnątrz
    [InlineData(2, 2, 5, 5, 5, 5, false)] // Punkt na krawędzi
    [InlineData(2, 2, 5, 5, 6, 6, false)] // Punkt na zewnątrz
    public void Contains_ReturnsCorrectValue(int x1, int y1, int x2, int y2, int px, int py, bool expected)
    {
        var rect = new Rectangle(x1, y1, x2, y2);
        var point = new Point(px, py);

        Assert.Equal(expected, rect.Contains(point));
    }
}
