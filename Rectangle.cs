namespace Simulator;
internal class Rectangle
{
    public readonly int X1; //ld
    public readonly int Y1;

    public readonly int X2; //pg
    public readonly int Y2;

    
    public Rectangle(int x1, int y1, int x2, int y2)
    {
        if (x2<x1) 
        {
            (x1, x2) = (x2, x1); //podmianka wartości
        }
        if (y2 < y1)
        {
            (y1, y2) = (y2, y1); //podmianka wartości
        }
        
        if (x1 >= x2 || y1 >= y2)
        {
            throw new ArgumentException("Nie chcemy chudych prostokątów");
        }
        
        this.X1 = x1;
        this.Y1 = y1;
        this.X2 = x2;
        this.Y2 = y2;
    }

    public Rectangle(Point p1, Point p2) : this(p1.X, p1.Y, p2.X, p2.Y)
    {
        
    }

    public bool Contains(Point point)
    {
        if (point.X > this.X1 && point.X < this.X2 && point.Y > this.Y1 && point.Y < this.Y2) { return true; }
        else { return false; }
    }

    public override string ToString()
    {
        return $"({X1}, {Y1}):({X2}, {Y2})";
    }
}

