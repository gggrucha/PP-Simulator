using System;

namespace Simulator;
public class Elf : Creature
{
    public override char Symbol => 'E';
    private int agility=1;
    private int SingCounter = 0;
    public int Agility { 
        get { return agility; }
        init 
        {
            agility = Validator.Limiter(value, 0, 10);
        } 
    } //= 1;

    public override int Power => 8 * Level + 2 * Agility;
    public void Sing() 
    {
        SingCounter++;
        //Console.WriteLine($"{Name} is singing.");
        if (SingCounter % 3 == 0)
        {
            if (agility < 10)
            {
                agility++;
            }
        }
    }

    //private string Name;
    //private int Level;

    public Elf()
    {
        
    }

    public Elf(string name="", int level=1, int agility=1) : base(name,level)
    {
        Agility = agility;
    }

    //public override string Greeting() {return  $"Hi, I'm {Name}, my level is {Level}, my agility is {Agility}."; }

    public override string Info => $"{Name} [{Level}][{Agility}]";
}
