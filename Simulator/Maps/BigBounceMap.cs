namespace Simulator.Maps;
public class BigBounceMap : BigMap
{
    public BigBounceMap(int sizeX, int sizeY) : base(sizeX, sizeY) 
    {
        if (sizeX > 1000) { throw new ArgumentOutOfRangeException(nameof(sizeX), "Map too wide"); }

        if (sizeY > 1000) { throw new ArgumentOutOfRangeException(nameof(sizeY), "Map too high"); }

        //_fields = new Dictionary<Point, List<IMappable>>();
    }

    protected override List<IMappable>?[,] Fields => throw new NotImplementedException();

    public override void Move(IMappable mappable, Point from, Point to)
    {
        if (!Exist(to))
        {
            // Calculate bounce direction
            Direction bounceDirection = CalculateBounceDirection(from, to);
            Point bounceBack = Next(from, bounceDirection);

            // Only move to bounceBack if it's valid, otherwise stay in place
            if (Exist(bounceBack))
            {
                base.Move(mappable, from, bounceBack);
            }
            else
            {
                // Remain in the same place
            }
        }
        else
        {
            base.Move(mappable, from, to);
        }
    }

    public override Point Next(Point p, Direction d)
    {
        Point nextPoint = p.Next(d);
        return d switch
        {
            Direction.Up => Exist(nextPoint) ? nextPoint : p.Next(Direction.Down),
            Direction.Right => Exist(nextPoint) ? nextPoint : p.Next(Direction.Left),
            Direction.Down => Exist(nextPoint) ? nextPoint : p.Next(Direction.Up),
            Direction.Left => Exist(nextPoint) ? nextPoint : p.Next(Direction.Right),
            _ => default,
        };
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        Point nextPoint = p.NextDiagonal(d);
        return d switch
        {
            Direction.Up => Exist(nextPoint) ? nextPoint : p.NextDiagonal(Direction.Down),
            Direction.Right => Exist(nextPoint) ? nextPoint : p.NextDiagonal(Direction.Left),
            Direction.Down => Exist(nextPoint) ? nextPoint : p.NextDiagonal(Direction.Up),
            Direction.Left => Exist(nextPoint) ? nextPoint : p.NextDiagonal(Direction.Right),
            _ => default,
        };
    }

    private Direction CalculateBounceDirection(Point from, Point to)
    {
        if (to.X < 0 || to.X >= SizeX)
        {
            return to.X < 0 ? Direction.Right : Direction.Left;
        }
        else if (to.Y < 0 || to.Y >= SizeY)
        {
            return to.Y < 0 ? Direction.Down : Direction.Up;
        }

        throw new InvalidOperationException("Bounce calculation error");
    }
}