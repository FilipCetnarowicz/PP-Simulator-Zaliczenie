using Simulator;
using Simulator.Maps;

namespace Runner;
internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Starting Simulator!\n");
        Lab5b();

    }
    public static void Lab5b()
    {
        try
        {
            Map firstmap = new SmallSquareMap(4);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);

        }
        try
        {
            Map secondmap = new SmallSquareMap(25);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        Map map = new SmallSquareMap(10);
        Console.WriteLine("Mapa o rozmiarze 10 została utworzona.");

        Point point1 = new Point(7, 3);
        Point point2 = new Point(12, 12);

        Console.WriteLine($"Czy punkt {point1} istnieje w mapie? {map.Exist(point1)}");
        Console.WriteLine($"Czy punkt {point2} istnieje w mapie? {map.Exist(point2)}");

        Console.WriteLine($"Następny punkt po {point1} w lewo: {map.Next(point1, Direction.Left)}");
        Console.WriteLine($"Następny punkt po {point1} w lewo (przekątna): {map.NextDiagonal(point1, Direction.Left)}");
    }
}

