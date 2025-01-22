namespace Simulator
{
    public class Birds : Animals
    {
        public Birds(string name, bool canFly)
            : base(name, canFly)
        {
           Symbol = CanFly ? 'B' : 'b';
            Symbol = CanFly ? 'B' : 'b';
        }

        public override string Info
        {
            get
            {
                string FlyStatus = CanFly ? "fly+" : "fly-";
                return $"{Description} ({FlyStatus}) <{Size}>";
            }
        }
        public override string ToString()
        {
            return $"{GetType().Name.ToUpper()}: {Info}";
        }
        public override string Go(Direction direction)
        {
            Point nextPosition;

            if (CanFly)
            {
                nextPosition = CurrentMap.Next(CurrentPosition, direction);
                nextPosition = CurrentMap.Next(nextPosition, direction); 
                nextPosition = CurrentMap.Next(nextPosition, direction); // Latające ptaki przesuwają się o trzy pola
            }
            else
            {
                nextPosition = CurrentMap.Next(CurrentPosition, direction);
                nextPosition = CurrentMap.Next(nextPosition, direction); // nieloty o dwa pola
            }

            CurrentMap.Move(this, CurrentPosition, nextPosition);
            CurrentPosition = nextPosition;

            return $"{direction.ToString().ToLower()}";
        }
    }
}
