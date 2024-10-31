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
            description = value.Trim();
            if (description.Length < 3)
            {
                description = description.PadRight(3, '#');
            }
            if (description.Length > 15)
            {
                description = description.Substring(0, 15);
                description = description.Trim();
                if (description.Length < 3)
                {
                    description = description.PadRight(3, '#');
                }
            }
            description = char.ToUpper(description[0]) + description.Substring(1);
        }
    } 
    public uint Size { get; set; } = 3;

    public string Info
    {
        get { return Description + " <" + Size + ">"; }
    }
 }
