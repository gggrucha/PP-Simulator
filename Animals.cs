using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;
public class Animals
{
    private string description = "";
    public required string Description
    {
        get { return description; }
        init
        {
            description = Validator.Shortener(value, 3, 15, '#');
            description = char.ToUpper(description[0]) + description.Substring(1).ToLower();
        }
    } 
    public uint Size { get; set; } = 3;

    public virtual string Info
    {
        get { return Description + " <" + Size + ">"; }
    }

    public override string ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Info}";
    }
}
