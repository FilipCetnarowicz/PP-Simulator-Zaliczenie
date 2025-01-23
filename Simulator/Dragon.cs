using Simulator.Maps;
using System.Drawing;
using System.Numerics;
using System.Reflection.Emit;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Linq;
namespace Simulator;

public class Dragon
{
    private int power = 1000;
    public int Power
    {
        get { return power; }
        set { power = value; }
    }

    public Dragon(int power=1000) 
    {
        Power = power;
    }
}
