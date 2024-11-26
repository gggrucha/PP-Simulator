﻿using Simulator.Maps;
namespace Simulator;
public abstract class Creature
{
    public Map? Map { get; private set; } //? czyli może być null bo mapa nie musi być od razu przypisana do stwora 
    public Point Position { get; private set; }//pamieta w ktorym jest miejscu //private czyli zeby nikt nie mogl zmienic

    

    public void InitMapAndPosition(Map map, Point position) //ustawianie stwora na mapie
    {
        Map = map;
        Position = position;
    }
    private string name = "Unknown";
    private int level = 1;

    public string Name 
    { 
        get { return name; } 
        init 
        {
            name = Validator.Shortener(value, 3, 25, '#');
            name = char.ToUpper(name[0]) + name.Substring(1).ToLower();
        }
    }  //automatic property
    public int Level 
    { 
        get { return level; } 
        init 
        { 
            if (value > 10)
            {
                level = 10;
            }
            else if(value < 1)
            {
                level = 1;
            }
            else
            {
                level = value;
            }
        } 
    } //automatic property
    
    public Creature(string name, int level=1) { //constructor
        Name = name;
        Level = level;
    }

    public abstract int Power { get; }
    public Creature() //empty constructor
    { 
        
    }

    public virtual string Greeting()
    {
        return $"Hi, I'm {Name}, my level is {Level}.";
    }
    public int Upgrade()
    {
        if (level < 10)
        {
            level++;
        }
        return level;
    }
    //public string Info
    //{
    //    get { return $"{Name} [{Level}]"; }
    //}

    public string Go(Direction direction) => $"{direction.ToString().ToLower()}"; //out

    public string[] Go(Direction[] directions)
    {
        //Map.Next(); //next zapewnia ze istnieje
        //Map.Next() == Position //nie robimy ruchu
        //Mao.Move() //tu będzie ruch
        //add i remove abstrakcyjne, move (remove ze starego i add do nowego, na poziomie mapy)
        var result = new string[directions.Length];
        for (int i=0; i<directions.Length; i++)
        {
            
            result[i] = Go(directions[i]);
        }
        return result;
    }

    public void Go(string directions) //out
    {
        var parsedDirections = DirectionParser.Parse(directions);
        Go(parsedDirections.ToArray());
    }

    public abstract string Info { get; }
    public override string ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Info}";
    }
}
