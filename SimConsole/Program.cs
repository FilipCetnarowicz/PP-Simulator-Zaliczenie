using Simulator.Maps;
using Simulator;
using System.Text;

namespace SimConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int turn = 1;
            Console.OutputEncoding = Encoding.UTF8;


            SmallTorusMap map = new SmallTorusMap(8, 6);

            
            List<IMappable> creatures = new List<IMappable>
            {
                new Orc("Gorbag"),
                new Elf("Elandor"),
                new Animals("Rabbit",false),  
                new Birds("Eagle",true),     
                new Birds("Ostrich",false)   
            };

            
            List<Point> points = new List<Point>
            {
                new(2, 2), 
                new(3, 1), 
                new(1, 3), 
                new(5, 5),
                new(6, 4)  
            };

            
            string moves = "dlrludlru"; 
            Simulation simulation = new Simulation(map, creatures, points, moves);

            
            MapVisualizer mapVisualizer = new(simulation.Map);


            mapVisualizer.Draw();

            while (!simulation.Finished)
            {
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();

                
                Console.WriteLine($"\nTurn: {turn}");
                Console.WriteLine($"{simulation.CurrentMappable} {simulation.CurrentMappable.CurrentPosition} goes {simulation.CurrentMoveName}:");

                
                simulation.Turn();

                
                mapVisualizer.Draw();

                turn++;

            }
        }
    }
}
