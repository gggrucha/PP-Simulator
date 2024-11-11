namespace Simulator;
public abstract class Creature
{
    private string name = "Unknown";
    private int level = 1;

    public string Name 
    { 
        get { return name; } 
        init 
        { 
            name = value.Trim();
            
            if (name.Length < 3)
            {
                string hash = new string('#', 3-name.Length);
                name = name + hash;
            }

            char c = name[0];
            if (char.IsLower(c)==true)
            {
                char[] znaki = name.ToCharArray();
                znaki[0] = char.ToUpper(znaki[0]); //changing 0-th element to UpperCase
                name = new string(znaki);
            }
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

    public virtual void SayHi()
    {
        Console.WriteLine($"Hi, I'm {Name}, my level is {Level}.");
    }
    public int Upgrade()
    {
        if (level < 10)
        {
            level++;
        }
        return level;
    }
    public string Info
    {
        get { return $"{Name} [{Level}]"; }
    }

    public void Go(Direction direction)
    {
        string d="";
        if (direction.ToString() == "Down") { d = "down"; }
        else if(direction.ToString() == "Up") { d = "up"; }
        else if (direction.ToString() == "Left") { d = "left"; }
        else if (direction.ToString() == "Right") { d = "right"; }
        Console.WriteLine($"{Name} goes {d}");
    }

    public void Go(Direction[] directions)
    {
        foreach (var dir in directions)
        {
            Go(dir);
        }
    }

    public void Go(string directions)
    {
        var parsedDirections = DirectionParser.Parse(directions);
        Go(parsedDirections);
    }

}
