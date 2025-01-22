using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using Simulator.Maps;

namespace Simulator
{
    public class Simulation
    {
        public Map Map { get; }
        public List<IMappable> Mappables { get; }
        public List<Point> Positions { get; }
        private int currentMappableIndex = 0;
        private int currentMoveIndex = 0;
        public string Moves { get; set; }
        public bool Finished { get; private set; } = false;

        /// <summary>
        /// Creature which will be moving current turn.
        /// </summary>
        public IMappable CurrentMappable => Mappables[currentMappableIndex];

        /// <summary>
        /// Lowercase name of direction which will be used in current turn.
        /// </summary>
        public string CurrentMoveName => Moves[currentMappableIndex].ToString().ToLower();

        /// <summary>
        /// Simulation constructor.
        /// Throw errors:
        /// if creatures' list is empty,
        /// if number of creatures differs from 
        /// number of starting positions.
        /// </summary>
        public Simulation(Map map, List<IMappable> mappables,
            List<Point> positions, string moves)
        {
            if (mappables.Count == 0)
                throw new ArgumentException("Lista stworów nie może być pusta.");

            if (mappables.Count != positions.Count)
                throw new ArgumentException("Liczba stworów musi odpowiadać liczbie początkowych pozycji.");

            Map = map;
            Mappables = mappables;
            Positions = positions;
            Moves = moves;

            for (int i = 0; i < mappables.Count; i++)
            {
                mappables[i].AssignToMap(map, positions[i]);
            }
        }

        public void Turn() {
            if (Finished)
                throw new InvalidOperationException("Symulacja została zakończona.");


            IMappable creature = CurrentMappable;
            Direction direction = DirectionParser.Parse(Moves)[currentMoveIndex];
            creature.Go(direction);
            //power w punkcie lokalizujac wroga
            //if(Map.At())
            //wprowadze to jak zrobie wyswietlanie lvla
                    //var Location = CurrentMappable.CurrentPosition;
                    //if (Map.At(Location).Count > 1)
                    //{
                    //    var attackerPower = Map.At(Location)[0].Power;
                    //    var ocuppierPower = CurrentMappable.Power;
                    //    //var LocationCount = Map.At(Location).Count; - mozna rozwinac do sytuacji kiedy w jednym punkcie jest wiecej stworow
                    //    if (attackerPower>=ocuppierPower)
                    //    {
                    //        Map.At(Location)[1].Upgrade();
                    //        Map.At(Location)[0].Kill();
                    //    }
                    //}
            // porownac power obu graczy 
            // zbic lvl do 0 slabszego
            // a na plaszy sie wyswietli X zgodnie z SimulationHistory TurnLog

            currentMoveIndex++;
            if (currentMoveIndex >= Moves.Length)
            {
                Finished = true;
            }

            currentMappableIndex++;
            if (currentMappableIndex >= Mappables.Count)
            {
                currentMappableIndex = 0;
            }


        }
    }
}
