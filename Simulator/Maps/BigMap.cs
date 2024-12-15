namespace Simulator.Maps;
public abstract class BigMap : Map
{
    private readonly Dictionary<Point, List<IMappable>> _fields;
    public BigMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX > 1000) { throw new ArgumentOutOfRangeException(nameof(sizeX), "Map too wide"); }

        if (sizeY > 1000) { throw new ArgumentOutOfRangeException(nameof(sizeY), "Map too high"); }

        //_fields = new Dictionary<Point, List<IMappable>>();
    }
    public override Point Next(Point p, Direction d)
    {
        return p.Next(d);
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        return p.NextDiagonal(d);
    }
}
