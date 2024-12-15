namespace Simulator.Maps;
public abstract class SmallMap : Map
{
    //private readonly List<Creature>?[,] _fields; //tablica dwuwymiarowa ktorej elementem jest lista stworów (typ generyczny)
    protected SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX > 20 ) { throw new ArgumentOutOfRangeException(nameof(sizeX), "Map too wide"); }

        if (sizeY>20) { throw new ArgumentOutOfRangeException(nameof(sizeY), "Map too high"); }

        //_fields = new List<Creature>?[sizeX, sizeY];
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
