namespace Simulator.Maps;
public interface IMappable
{
    public char Symbol { get; }
    void Go(Direction direction); //dopisac
    void InitMapAndPosition(Map map, Point point);
}
