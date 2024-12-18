﻿namespace Simulator;
public class Orc : Creature
{
    public override char Symbol => 'O';
    private int rage = 1;
    private int HuntCounter = 0;

    public int Rage 
    { 
        get
        {
            return rage;
        } 
        init
        {
            rage = Validator.Limiter(value, 0, 10);
        }
    }
    public override int Power => 7 * Level + 3 * Rage;
    public void Hunt()
    {
        HuntCounter++;
        //Console.WriteLine($"{Name} is hunting.");
        if (HuntCounter % 2 == 0)
        {
            if (rage < 10)
            {
                rage++;
            }
        }
    }

    public Orc() {
        
    }

    public Orc(string name="",int level=1,int rage=1) : base(name,level)
    {
        Rage = rage;
    }

    public override string Greeting()
    {
        return $"Hi, I'm {Name}, my level is {Level}, my rage is {Rage}.";
    } 

    public override string Info => $"{Name} [{Level}][{Rage}]";
}
