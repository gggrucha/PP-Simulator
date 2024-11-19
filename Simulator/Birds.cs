namespace Simulator;
public class Birds : Animals
{
    public bool CanFly { get; set; }=true;

    public override string Info
    {
        get
        {
            if (CanFly)
            {
                return Description + " (fly+)" + " <" + Size + ">";
            }
            else 
            {
                return Description + " (fly-)" + " <" + Size + ">";
            }
            
        }
    }
}
