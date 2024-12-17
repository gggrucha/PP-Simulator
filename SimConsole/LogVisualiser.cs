using Simulator;
namespace SimConsole;
internal class LogVisulizer
{
    private SimulationHistory _log;

    SimulationHistory Log { get; }
    public LogVisulizer(SimulationHistory log)
    {
        _log = log;
    }

    public void Draw(int turnIndex)
    {
        if (turnIndex < 0 || turnIndex >= _log.TurnLogs.Count)
        {
            Console.WriteLine("Invalid turn number.");
            return;
        }
        var log = _log.TurnLogs[turnIndex];
        DrawMap(log.Symbols, _log.SizeX, _log.SizeY);
    }
    private void DrawMap(Dictionary<Point, char> symbols, int sizeX, int sizeY)
    {
        Console.Write(Box.TopLeft);
        for (int x = 0; x < sizeX; x++)
        {
            Console.Write(Box.Horizontal);
            if (x < sizeX - 1) Console.Write(Box.TopMid);
        }
        Console.WriteLine(Box.TopRight);
        for (int y = sizeY - 1; y >= 0; y--)
        {
            Console.Write(Box.Vertical);
            for (int x = 0; x < sizeX; x++)
            {
                var point = new Point(x, y);
                if (symbols.TryGetValue(point, out char symbol))
                {
                    Console.Write(symbol);
                }
                else
                {
                    Console.Write(' ');
                }
                if (x < sizeX - 1)
                {
                    Console.Write(Box.Vertical);
                }
            }
            Console.WriteLine(Box.Vertical);
            if (y > 0)
            {
                Console.Write(Box.MidLeft);
                for (int x = 0; x < sizeX; x++)
                {
                    Console.Write(Box.Horizontal);
                    if (x < sizeX - 1) Console.Write(Box.Cross);
                }
                Console.WriteLine(Box.MidRight);
            }
        }
        Console.Write(Box.BottomLeft);
        for (int x = 0; x < sizeX; x++)
        {
            Console.Write(Box.Horizontal);
            if (x < sizeX - 1) Console.Write(Box.BottomMid);
        }
        Console.WriteLine(Box.BottomRight);
    }
}
