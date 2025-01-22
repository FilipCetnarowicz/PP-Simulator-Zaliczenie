using System.Drawing;

namespace Simulator.Maps;

public class SmallTorusMap : SmallMap
{

    public SmallTorusMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        
    }

    

    public override Point Next(Point p, Direction d)
    {
        var nextPoint = p.Next(d);

        int wrappedX = (nextPoint.X + SizeX) % SizeX;
        int wrappedY = (nextPoint.Y + SizeY) % SizeY;

        return new Point(wrappedX, wrappedY);
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        var nextPoint = p.NextDiagonal(d);

        int wrappedX = (nextPoint.X + SizeX) % SizeX;
        int wrappedY = (nextPoint.Y + SizeY) % SizeY;

        return new Point(wrappedX, wrappedY);
    }
}
