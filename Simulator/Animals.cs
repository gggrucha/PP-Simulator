using Simulator.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;
public class Animals : IMappable
{
    public Map? Map { get; private set; }
    public Point Position { get; set; }

    public virtual char Symbol => 'A';
    private string description = "";
    public string Description
    {
        get { return description; }
        init
        {
            description = Validator.Shortener(value, 3, 15, '#');
            description = char.ToUpper(description[0]) + description.Substring(1).ToLower();
        }
    } 
    public int Size { get; set; } = 3;

    public virtual string Info
    {
        get { return Description + " <" + Size + ">"; }
    }

    public Animals() { }
    public Animals(string description, int size)
    {
        Description = description;
        Size = size;
    }

    public virtual void Go(Direction direction)
    {
        if (Map == null)
            return;
        Point nextPosition = Map.Next(Position, direction);
        Map.Move((IMappable)this, Position, nextPosition);
        Position = nextPosition;
    }

    public void InitMapAndPosition(Map map, Point point)
    {
        Map = map;
        Position = point;
    }

    public override string ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Info}";
    }
}
