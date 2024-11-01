namespace Simulator;
public static class DirectionParser
{
    public static Direction[] Parse(string s)
    {
        var directions = new List<Direction>();

        foreach (char c in s)
        {
            if (c == 'U' || c == 'u') { }
            else if (c == 'U' || c == 'u') 
            {
                directions.Add(Direction.Up);
            }
            else if (c == 'D' || c == 'd') 
            {
                directions.Add(Direction.Down);
            }
            else if (c == 'R' || c == 'r')
            {
                directions.Add(Direction.Right);
            }
            else if (c == 'L' || c == 'l')
            {
                directions.Add(Direction.Left);
            }
        }
        return directions.ToArray();
    }

}
