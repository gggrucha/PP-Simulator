using Simulator.Maps;

namespace Simulator;

public class Simulation
{
    /// <summary>
    /// Simulation's map.
    /// </summary>
    public Map Map { get; }

    /// <summary>
    /// Creatures moving on the map.
    /// </summary>
    public List<IMappable> IMappables { get; }

    /// <summary>
    /// Starting positions of creatures.
    /// </summary>
    public List<Point> Positions { get; }

    /// <summary>
    /// Cyclic list of creatures moves. 
    /// Bad moves are ignored - use DirectionParser.
    /// First move is for first creature, second for second and so on.
    /// When all creatures make moves, 
    /// next move is again for first creature and so on.
    /// </summary>
    public string Moves { get; set; }

    /// <summary>
    /// Has all moves been done?
    /// </summary>
    public bool Finished { get; private set; } = false;

    private List<Direction> FilteredMoves { get; }
    public int _currentIndex = 0;

    public IMappable CurrentMappable => IMappables[_currentIndex % IMappables.Count];
    /// <summary>
    /// Creature which will be moving current turn.
    /// </summary>
    //public Creature CurrentMappable => FilteredMoves.Count > _currentMoveIndex ? FilteredMoves[_currentMoveIndex].ToString().ToLower() : string.Empty;

    /// <summary>
    /// Lowercase name of direction which will be used in current turn.
    /// </summary>
    public string CurrentMoveName => FilteredMoves.Count > _currentIndex ? FilteredMoves[_currentIndex].ToString().ToLower() : string.Empty;

    /// <summary>
    /// Simulation constructor.
    /// Throw errors:
    /// if creatures' list is empty,
    /// if number of creatures differs from 
    /// number of starting positions.
    /// </summary>
    public Simulation(Map map, List<IMappable> mappables, List<Point> positions, string moves)
    {
        if (mappables == null || mappables.Count == 0)
        {
            throw new ArgumentException("List of creatures cannot be empty.");
        }
        if (mappables.Count != positions.Count)
        {
            throw new ArgumentException("Number of creatures must match the number of starting positions.");
        }

        Map = map ?? throw new ArgumentNullException(nameof(map));
        IMappables = mappables;
        Positions = positions;
        Moves = moves ?? throw new ArgumentNullException(nameof(moves));

        FilteredMoves = Moves
            .Select(c => DirectionParser.Parse(c.ToString().ToLower()))
            .Where(d => d != null && d.Count > 0)
            .Select(d => d[0])
            .ToList();

        for (int i = 0; i < mappables.Count; i++)
        {
            var mappable = mappables[i];
            var position = positions[i];

            if (!map.Exist(position))
            {
                throw new ArgumentException($"Position {position} is outside the bounds of the map.");
            }
            mappable.InitMapAndPosition(map, position);
            map.Add(mappable, position);
        }
    }

    /// <summary>
    /// Makes one move of current creature in current direction.
    /// Throw error if simulation is finished.
    /// </summary>
    public void Turn()
    {
        if (Finished)
        {
            throw new InvalidOperationException("The simulation is already finished.");
        }

        if (string.IsNullOrEmpty(Moves))
        {
            Finished = true;
            return;
        }

        //char currentMoveChar = Moves[0];
        //Moves = Moves.Substring(1); 

        //var directions = DirectionParser.Parse(currentMoveChar.ToString());
        //if (directions.Count > 0) 
        //{
        //    Direction direction = directions[0];
        //    CurrentMappable.Go(direction);
        //}
        Direction direction = FilteredMoves[_currentIndex];
        CurrentMappable.Go(direction);
        _currentIndex++;

        //if (string.IsNullOrEmpty(Moves))
        //{
        //    Finished = true;
        //}
        if (_currentIndex >= FilteredMoves.Count)
        {
            Finished = true;
        }
    }
}
