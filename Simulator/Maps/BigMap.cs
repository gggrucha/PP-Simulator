namespace Simulator.Maps;
public abstract class BigMap : Map
{
    private readonly Dictionary<Point, List<IMappable>> _fields;
    public BigMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX > 1000) { throw new ArgumentOutOfRangeException(nameof(sizeX), "Map too wide"); }

        if (sizeY > 1000) { throw new ArgumentOutOfRangeException(nameof(sizeY), "Map too high"); }

        _fields = new Dictionary<Point, List<IMappable>>();
    }

    public override void Add(IMappable mappable, Point position)
    {
        if (!Exist(position))
        {
            throw new ArgumentException($"Point {position} is out of bounds.");
        }

        if (!_fields.ContainsKey(position))
        {
            _fields[position] = new List<IMappable>();
        }

        _fields[position].Add(mappable);
    }

    public override void Remove(IMappable mappable, Point position)
    {
        if (_fields.ContainsKey(position))
        {
            _fields[position].Remove(mappable);
            if (_fields[position].Count == 0)
            {
                _fields.Remove(position);
            }
        }
    }

    public override List<IMappable> At(Point position)
    {
        //if():
        //else:
        return _fields.TryGetValue(position, out var mappables) ? mappables : new List<IMappable>();

    }
}
