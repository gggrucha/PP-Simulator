using System.Text;
using Simulator;
using Simulator.Maps;

namespace Simulator;

internal class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        ZadanieCommitMovingAnimals();
        //RunSimulation1();

        //RunSimulation2();
    }
    static void ZadanieCommitMovingAnimals()
    {
        SmallTorusMap map = new(8, 6);
        List<IMappable> mappables = new() { new Orc("Gorbag"), new Elf("Elandor"), new Animals("Rabbits", 8), new Birds("Eagle", 14, true), new Birds("Ostrich", 2, false) };
        List<Point> points = new() { new(2, 2), new(3, 1), new(4, 4), new(2, 5), new(0, 0) };
        string moves = "dlrludlrrldulru";

        Simulation simulation = new(map, mappables, points, moves);
        MapVisualizer mapVisualizer = new(simulation.Map);

        while (!simulation.Finished)
        {
            mapVisualizer.Draw();
            Console.WriteLine("\nPress any key to make a move...");
            Console.ReadKey(true);
            Console.WriteLine($"{simulation.CurrentMappable.Info} {simulation.CurrentMappable.Position} goes {simulation.CurrentMoveName}");
            simulation.Turn();
        }

        mapVisualizer.Draw();
        Console.WriteLine("\nSimulation finished!");
    }

    //static void RunSimulation1()
    //{
    //    SmallSquareMap map = new(5);
    //    List<Creature> creatures = new List<Creature> { new Orc("Gorbag"), new Elf("Elandor") };
    //    List<Point> points = new List<Point> { new Point(2, 2), new Point(3, 1) };
    //    string moves = "dlrludl";

    //    Simulation simulation = new(map, mappables, points, moves);
    //    MapVisualizer mapVisualizer = new(simulation.Map);

    //    while (!simulation.Finished)
    //    {
    //        mapVisualizer.Draw();
    //        Console.WriteLine("\nPress any key to make a move...");
    //        Console.ReadKey(true);
    //        //Console.WriteLine($"{simulation.CurrentMappable.Info} {simulation.CurrentMappable.Position} goes {simulation.CurrentMoveName}");
    //        simulation.Turn();
    //    }

    //    mapVisualizer.Draw();
    //    Console.WriteLine("\nSimulation finished!");
    //}

    //static void RunSimulation2()
    //{
    //    SmallSquareMap map = new(8);
    //    List<Creature> creatures = new List<Creature>
    //{
    //    new Orc("Thrall"),
    //    new Elf("Luthien"),
    //    new Orc("Grishnakh"),
    //    new Elf("Aerendil")
    //};
    //    List<Point> points = new List<Point>
    //{
    //    new Point(1, 1),
    //    new Point(2, 2),
    //    new Point(4, 4),
    //    new Point(5, 5)
    //};
    //    string moves = "rrdllurrdllur";

    //    Simulation simulation = new(map, creatures, points, moves);
    //    MapVisualizer mapVisualizer = new(simulation.Map);

    //    while (!simulation.Finished)
    //    {
    //        mapVisualizer.Draw();
    //        Console.WriteLine("\nPress any key to make a move...");
    //        Console.ReadKey(true);
    //        Console.WriteLine($"{simulation.CurrentMappable.Info} {simulation.CurrentMappable.Position} goes {simulation.CurrentMoveName}");
    //        simulation.Turn();
    //    }

    //    mapVisualizer.Draw();
    //    Console.WriteLine("\nSimulation finished!");
    //}


}
