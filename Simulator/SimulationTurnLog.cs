using Simulator.Maps;

namespace Simulator;

/// <summary>
/// State of map after single simulation turn.
/// </summary>
public class SimulationTurnLog
{
    /// <summary>
    /// Text representastion of moving object in this turn.
    /// CurrentMappable.ToString()
    /// </summary>
    public required string Mappable { get; init; }
    
    // public ()

    /// <summary>
    /// Text representation of move in this turn.
    /// CurrentMoveName.ToString();
    /// </summary>
    public required string Move { get; init; }
    public (Point, string) DragonLog { get; init; }
    public Dictionary<Point, string> ActionPoints { get; init; }
    public Dictionary<Point, string> DeadlyPoints { get; init; }
    public required Dictionary<Point, char> Symbols { get; init; }
    public required Dictionary<Point, string> Powers { get; init; }
}
