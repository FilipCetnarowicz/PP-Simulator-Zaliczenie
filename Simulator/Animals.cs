using Simulator.Maps;
using System.Drawing;
using System.Reflection.Emit;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Linq;
namespace Simulator;

public class Animals : IMappable
{
    public void Win()
    {
        level = level + 1000;
    }
    public void Upgrade()
    {
        level = Math.Min(level + 1, 10);
    }
    public void Kill()
    {
        level = 1;
    }
    private int level = 1;
    public int Level
    {
        get { return level; }
        init { level = Validator.Limiter(value, 1, 10); }
    }
    public int Power => Size*level;
    private string description = "Unknown";
    public virtual char Symbol { get; set; } = 'A';
    //public string Name { get; set; }
    public bool CanFly { get; set; }
    public Point CurrentPosition { get; set; }
    public Map CurrentMap { get; set; }


    public Animals(string description, bool canFly) //string name,
    {
        //Name = name;
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
    private int size =3;
    public int Size 
    { 
        get => size;
    }
    public virtual string Info => $"Size[{Size}]";
    //public virtual string Info => $"{Description} <{Size}>";

    public override string ToString()
    {
        //return $"{GetType().Name.ToUpper()}: {Info}";
        return $"{GetType().Name.ToUpper()}: {Description} did his turn. Current stats: Level[{Level}] * {Info} => POWER[{Power}]";

    }

    public void Action()
    {
        size += 1;
    }
}
