﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Runtime.ExceptionServices;
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
        public List<Point> ActionPoints = [new Point(0, 1), new Point(0, 2), new Point(0, 3)];

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
            var Location = CurrentMappable.CurrentPosition;

            // --------------------------------------
            // wchodzenie w point action
            if (ActionPoints.Contains(Location))
            {
                CurrentMappable.Action();
                int actionPointsNumber = ActionPoints.Count;
                for (int i = 0; i < actionPointsNumber; i++)
                {
                    if (Location.Equals(ActionPoints[i]))
                    {
                        ActionPoints.Remove(ActionPoints[i]);
                        break;
                    }
                }
            }
                
            // ----------------------------------------
            // walka w zaleznosci od power
            if (Map.At(Location).Count == 2)
            {
                var attackerPower = Map.At(Location)[1].Power;
                var ocuppierPower = Map.At(Location)[0].Power;
                if (attackerPower >= ocuppierPower)
                {
                    Map.At(Location)[1].Upgrade();
                    Map.At(Location)[0].Kill();
                }
                else
                {
                    Map.At(Location)[0].Upgrade();
                    Map.At(Location)[1].Kill();
                }
            }
            int fighters = Map.At(Location).Count;
            if (fighters > 2)
            {
                Map.At(Location)[fighters-1].Upgrade();
                for (int i=0;i<fighters-1;i++)
                {
                    Map.At(Location)[i].Kill();
                }
            }

                currentMoveIndex++;

            // ------------------------------------------
            // wygrywanie po 10 rundzie (super duzy power)
            int fourCycles = Mappables.Count * 4;
            if (currentMoveIndex==fourCycles)
            {
                IMappable winner = Mappables[0];
                int j = Mappables.Count;
                for (int i = 1; i < j; i++)
                {
                    if (Mappables[i].Power > Mappables[i - 1].Power) winner = Mappables[i];
                }
                winner.Win();
            }

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
