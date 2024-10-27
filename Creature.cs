using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// powyższe do wywalenia
namespace Simulator;
internal class Creature
{
    //public string name;
    //public int level;

    public string Name { get; set; } //automatic property
    public int Level { get; set; } //automatic property

    public Creature(string name, int level=1) { //constructor
        Name = name;
        Level = level;
    }

    public Creature() //empty constructor
    { 
        
    }

    public void SayHi()
    {
        Console.WriteLine($"Hi, I'm {Name}, my level is {Level}.");
    }

    public string Info
    {
        get { return $"{Name} [{Level}]"; }
    }


}
