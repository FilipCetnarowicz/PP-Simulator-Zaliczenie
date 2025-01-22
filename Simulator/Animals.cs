using Simulator.Maps;
namespace Simulator;

public class Animals : IMappable
{
    private string description = "Unknown";
    public virtual char Symbol { get; set; } = 'A';
    public string Name { get; set; }
    public bool CanFly { get; set; }
    public Point CurrentPosition { get; set; }
    public Map CurrentMap { get; set; }

    public Animals(string name, bool canFly, string descriptio = "")
    {
        Name = name;
        Description = description;
        CanFly = canFly;
    }

    public string Description
    {
        get => description;
        init
        {
            description = Validator.Shortener(value, 3, 15, '#');
        }
    }
    public virtual string Go(Direction direction)
    {
        Point nextPosition;
        if (CanFly)
        {
            nextPosition = CurrentMap.Next(CurrentPosition, direction);
            nextPosition = CurrentMap.Next(nextPosition, direction);
        }
        else
        {
            nextPosition = CurrentMap.Next(CurrentPosition, direction);
        }

        CurrentMap.Move(this, CurrentPosition, nextPosition);
        CurrentPosition = nextPosition;

        return $"{direction.ToString().ToLower()}";
    }

    public void AssignToMap(Map map, Point point)
    {
        CurrentMap = map;
        CurrentPosition = point;
        map.Add(this, point);
    }

    public Point GetPosition()
    {
        return CurrentPosition;
    }

    public uint Size { get; set; } = 3;
    public virtual string Info => $"{Description} <{Size}>";
    public override string ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Info}";
    }

}
