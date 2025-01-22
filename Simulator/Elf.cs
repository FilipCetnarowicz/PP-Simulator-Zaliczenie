namespace Simulator;

public class Elf : Creature
{
    private int agility;
    public int Agility
    {
        get { return agility; }
        init { agility = Validator.Limiter(value, 0, 10); }
    }

    public Elf() : base() { }
    public override char Symbol => 'E';

    public Elf(string name = "Unknown", int level = 1, int agility = 1) : base(name, level)
    {
        Agility = agility;
    }

    public override string Greeting()

    {
        return $"Hi, I am {Name}, an Elf with {Agility} agility!";
    }

    private int singCount = 0;
    public void Sing()
    {
        singCount++;

        if (singCount % 3 == 0)
        {
            agility++;
            Console.WriteLine($"{Name}'s agility increased to {Agility}!");
        }
    }

    public override string Info => $"[{Agility}]";
    public override int Power => (Level * 8) + (Agility * 2);
}
