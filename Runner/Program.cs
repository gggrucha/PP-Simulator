using Simulator.Maps;
using System.Diagnostics;

namespace Simulator;

internal class Program
{
    static void Lab4a()
    {
        Console.WriteLine("HUNT TEST\n");
        var o = new Orc() { Name = "Gorbag", Rage = 7 };
        //o.SayHi();
        for (int i = 0; i < 10; i++)
        {
            o.Hunt();
            //o.SayHi();
        }

        Console.WriteLine("\nSING TEST\n");
        var e = new Elf("Legolas", agility: 2);
        //e.SayHi();
        for (int i = 0; i < 10; i++)
        {
            e.Sing();
            //e.SayHi();
        }

        Console.WriteLine("\nPOWER TEST\n");
        Creature[] creatures = {
        o,
        e,
        new Orc("Morgash", 3, 8),
        new Elf("Elandor", 5, 3)
    };
        foreach (Creature creature in creatures)
        {
            Console.WriteLine($"{creature.Name,-15}: {creature.Power}");
        }
    }

    static void Lab4b()
    {
        object[] myObjects = {
        new Animals() { Description = "dogs"},
        new Birds { Description = "  eagles ", Size = 10 },
        new Elf("e", 15, -3),
        new Orc("morgash", 6, 4)
    };
        Console.WriteLine("\nMy objects:");
        foreach (var o in myObjects) Console.WriteLine(o);
        /*
            My objects:
            ANIMALS: Dogs <3>
            BIRDS: Eagles (fly+) <10>
            ELF: E## [10][0]
            ORC: Morgash [6][4]
        */
    }

    static void Lab5a()
    {
        try
        {
            Rectangle rect = new Rectangle(0, 0, 5, 5);
            Point p1 = new Point(2, 2);
            Point p2 = new Point(6, 6);

            Console.WriteLine(rect);  // (0, 0):(5, 5)
            Console.WriteLine(rect.Contains(p1));  // True
            Console.WriteLine(rect.Contains(p2));  // False

            Point p = new Point(10, 25);
            Console.WriteLine(p.Next(Direction.Right));          // (11, 25)
            Console.WriteLine(p.NextDiagonal(Direction.Right));  // (11, 24)
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }

        try
        {
            Console.WriteLine("Testowanie tworzenia prostokątów i metody Contains:");

            // Przypadek 1: Poprawny prostokąt
            Rectangle rect1 = new Rectangle(0, 0, 5, 5);
            Point insidePoint1 = new Point(3, 3);
            Point outsidePoint1 = new Point(6, 6);

            Console.WriteLine($"Prostokąt 1: {rect1}");
            Console.WriteLine($"Czy zawiera punkt {insidePoint1}? {rect1.Contains(insidePoint1)}");  // Oczekiwany wynik: True
            Console.WriteLine($"Czy zawiera punkt {outsidePoint1}? {rect1.Contains(outsidePoint1)}"); // Oczekiwany wynik: False

            // Przypadek 2: Prostokąt z zamienionymi współrzędnymi, automatyczne wyrównanie
            Rectangle rect2 = new Rectangle(5, 5, 0, 0);
            Console.WriteLine($"\nProstokąt 2 (zamienione współrzędne): {rect2}");
            Console.WriteLine($"Czy zawiera punkt {insidePoint1}? {rect2.Contains(insidePoint1)}");  // Oczekiwany wynik: True

            // Przypadek 3: Punkt na krawędzi prostokąta
            Point edgePoint = new Point(5, 3);
            Console.WriteLine($"\nProstokąt 1 ponownie: {rect1}");
            Console.WriteLine($"Czy zawiera punkt {edgePoint} (na krawędzi)? {rect1.Contains(edgePoint)}"); // Oczekiwany wynik: False

            // Przypadek 4: "Chudy prostokąt" - oczekiwany wyjątek
            try
            {
                Rectangle thinRect = new Rectangle(2, 2, 2, 5);
                Console.WriteLine("Utworzono chudy prostokąt, co jest błędem."); // Nie powinno się wyświetlić
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("\nPróba utworzenia chudego prostokąta:");
                Console.WriteLine(e.Message); // Powinien pojawić się komunikat o błędzie
            }

            // Przypadek 5: Testowanie metody Next() i NextDiagonal() w strukturze Point
            Console.WriteLine("\nTestowanie przesunięcia punktu:");
            Point start = new Point(10, 25);
            Console.WriteLine($"Punkt początkowy: {start}");
            Console.WriteLine($"Next(Direction.Right): {start.Next(Direction.Right)}");         // Oczekiwany wynik: (11, 25)
            Console.WriteLine($"NextDiagonal(Direction.Right): {start.NextDiagonal(Direction.Right)}"); // Oczekiwany wynik: (11, 24)
            Console.WriteLine($"Next(Direction.Up): {start.Next(Direction.Up)}");              // Oczekiwany wynik: (10, 26)
            Console.WriteLine($"NextDiagonal(Direction.Up): {start.NextDiagonal(Direction.Up)}");     // Oczekiwany wynik: (11, 26)
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Nieoczekiwany błąd: {ex.Message}");
        }
    }

    static void Lab5b()
    {
        try
        {
            Console.WriteLine("Testowanie klasy SmallSquareMap:");

            // Przypadek 1: Utworzenie mapy o poprawnym rozmiarze
            SmallSquareMap map = new SmallSquareMap(10);
            Console.WriteLine($"Mapa utworzona z rozmiarem: {map.Size}");

            // Przypadek 2: Sprawdzenie istnienia punktu w granicach mapy
            Point insidePoint = new Point(5, 5);
            Point outsidePoint = new Point(10, 10);
            Console.WriteLine($"Czy punkt {insidePoint} istnieje w mapie? {map.Exist(insidePoint)}");  // Oczekiwany wynik: True
            Console.WriteLine($"Czy punkt {outsidePoint} istnieje w mapie? {map.Exist(outsidePoint)}"); // Oczekiwany wynik: False

            // Przypadek 3: Ruch punktu w granicach mapy
            Point start = new Point(5, 5);
            Point next = map.Next(start, Direction.Right);
            Console.WriteLine($"Następny punkt w prawo od {start}: {next}"); // Oczekiwany wynik: (6, 5)

            // Przypadek 4: Ruch punktu poza granice mapy
            Point edgePoint = new Point(9, 5);
            next = map.Next(edgePoint, Direction.Right);
            Console.WriteLine($"Następny punkt w prawo od {edgePoint} (poza granicami): {next}"); // Oczekiwany wynik: (9, 5)

            // Przypadek 5: Ruch po skosie w granicach mapy
            Point diagonalMove = map.NextDiagonal(start, Direction.Up);
            Console.WriteLine($"Następny punkt po skosie w górę od {start}: {diagonalMove}"); // Oczekiwany wynik: (6, 6)

            // Przypadek 6: Próba ruchu po skosie poza granice mapy
            Point cornerPoint = new Point(9, 9);
            diagonalMove = map.NextDiagonal(cornerPoint, Direction.Up);
            Console.WriteLine($"Następny punkt po skosie w górę od {cornerPoint} (poza granicami): {diagonalMove}"); // Oczekiwany wynik: (9, 9)

            // Przypadek 7: Próba utworzenia mapy z rozmiarem poza zakresem
            try
            {
                SmallSquareMap invalidMap = new SmallSquareMap(25); // Oczekiwany wyjątek
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Nie można utworzyć mapy o rozmiarze spoza zakresu (5-20).");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Nieoczekiwany błąd: {ex.Message}");
        }
    }
    static void Main(string[] args)
    {
        //Lab4a();
        //Lab4b();
        //Lab5a();
        //Lab5b();
    }
}
