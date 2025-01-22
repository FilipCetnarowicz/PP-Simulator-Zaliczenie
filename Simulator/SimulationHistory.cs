using Simulator.Maps;

namespace Simulator;

public class SimulationHistory
{
    private Simulation _simulation { get; }
    public int SizeX { get; }
    public int SizeY { get; }
    public List<SimulationTurnLog> TurnLogs { get; } = [];
    // store starting positions at index 0

    public SimulationHistory(Simulation simulation)
    {
        _simulation = simulation ??
            throw new ArgumentNullException(nameof(simulation));
        SizeX = _simulation.Map.SizeX;
        SizeY = _simulation.Map.SizeY;

        var startingPosDict = new Dictionary<Point, char>();
        for (int i = 0; i < _simulation.Mappables.Count; i++)
        {
            startingPosDict.Add(_simulation.Positions[i], _simulation.Mappables[i].Symbol);
        }
        var startingPowerDict = new Dictionary<Point, int>();
        for (int i = 0; i < _simulation.Mappables.Count; i++)
        {
            startingPowerDict.Add(_simulation.Positions[i], _simulation.Mappables[i].Power);
        }
        TurnLogs.Add(new SimulationTurnLog { Mappable = "Pozycje startowe", Move = "Pozycje startowe", Symbols = startingPosDict, Powers = startingPowerDict });
        Run();
    }

    private void Run()
    {
        while (!_simulation.Finished)
        {
            var currentMappable = _simulation.CurrentMappable;
            var currentMove = _simulation.CurrentMoveName;
            var symbolsPos = new Dictionary<Point, char>();
            var powersPos = new Dictionary<Point, int>();
            //var hisLevel = _simulation.CurrentMappable.Level;
            //var hisPower = _simulation.CurrentMappable.Power;
            
            _simulation.Turn();
            //tu juz sie pojawia X, po ruchu (czyli gdyby sie zabijaly a nie zerowaly to nie wyswietli sie X)
            for (int row = 0; row < SizeY; row++)
            {
                for (int col = 0; col < SizeX; col++)
                {
                    if (_simulation.Map.At(col, row).Count > 1)
                    {
                        symbolsPos.Add(new Point(col, row), 'X');
                        powersPos.Add(new Point(col, row), 0);

                        // tu nie ustawiam powera, bo wszystko oblicza sie i tak w silniku a przy wyswietlaniu jak jest wiecej pol to zaden power ma sie nie wyswietlac, tylko w backendzie widniec 
                    }
                    else if (_simulation.Map.At(col, row).Count == 1)
                    {
                        symbolsPos.Add(new Point(col, row), _simulation.Map.At(col, row)[0].Symbol);
                        powersPos.Add(new Point(col, row), _simulation.Map.At(col, row)[0].Power);

                    }
                }
            }
            TurnLogs.Add(new SimulationTurnLog { Mappable = currentMappable.ToString(), Move = currentMove, Symbols = symbolsPos, Powers = powersPos});
            //HisLevel =, HisPower =
        }
    }
}
