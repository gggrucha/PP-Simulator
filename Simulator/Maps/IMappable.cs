namespace Simulator.Maps;
public interface IMappable
{
    public char Symbol { get; }
    public string ToString();
    public Point Position { get; }
    void Go(Direction direction); //dopisac
    void InitMapAndPosition(Map map, Point point);
}
