using Simulator.Maps;
using Simulator;

namespace SimConsole;

public class MapVisualizer
{
    private readonly Map _map;
    public MapVisualizer(Map map)
    {
        _map = map;
    }

    public void Draw()
    {
        Console.Write(Box.TopLeft);
        for (int i = 0; i < _map.SizeX - 1; i++)
        {
            Console.Write($"{Box.Horizontal}{Box.TopMid}");
        }
        Console.WriteLine($"{Box.Horizontal}{Box.TopRight}");

        for (int row = 0; row < _map.SizeY; row++)
        {
            Console.Write(Box.Vertical);
            for (int col = 0; col < _map.SizeX; col++)
            {
                if (_map.At(col, row).Count > 1)
                {
                    Console.Write($"X{Box.Vertical}");
                }
                else if (_map.At(col, row).Count == 1)
                {
                    Console.Write($"{_map.At(col, row)[0].Symbol}{Box.Vertical}");
                }
                else
                    Console.Write($" {Box.Vertical}");
            }

            Console.WriteLine();

            if (row < _map.SizeY - 1)
            {
                Console.Write(Box.MidLeft);
                for (int col = 0; col < _map.SizeX - 1; col++)
                {
                    Console.Write($"{Box.Horizontal}{Box.Cross}");
                }
                Console.WriteLine($"{Box.Horizontal}{Box.MidRight}");
            }
        }
        Console.Write(Box.BottomLeft);
        for (int i = 0; i < _map.SizeX - 1; i++)
        {
            Console.Write($"{Box.Horizontal}{Box.BottomMid}");
        }
        Console.WriteLine($"{Box.Horizontal}{Box.BottomRight}");
    }
}

