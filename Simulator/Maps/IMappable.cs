namespace Simulator.Maps;
public interface IMappable
{
    void Go(Direction direction); //dopisac
    void InitMapAndpPosition(Map map, Point point);
}
