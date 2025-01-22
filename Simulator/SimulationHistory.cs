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

        TurnLogs.Add(new SimulationTurnLog { Mappable = "Pozycje startowe", Move = "Pozycje startowe", Symbols = startingPosDict });
        Run();
    }

    private void Run()
    {
        while (!_simulation.Finished)
        {
            var currentMappable = _simulation.CurrentMappable;
            var currentMove = _simulation.CurrentMoveName;
            var symbolsPos = new Dictionary<Point, char>();

            _simulation.Turn();

            for (int row = 0; row < SizeY; row++)
            {
                for (int col = 0; col < SizeX; col++)
                {
                    if (_simulation.Map.At(col, row).Count > 1)
                    {
                        symbolsPos.Add(new Point(col, row), 'X');
                    }
                    else if (_simulation.Map.At(col, row).Count == 1)
                    {
                        symbolsPos.Add(new Point(col, row), _simulation.Map.At(col, row)[0].Symbol);
                    }
                }
            }
            TurnLogs.Add(new SimulationTurnLog { Mappable = currentMappable.ToString(), Move = currentMove, Symbols = symbolsPos });
        }
    }
}
