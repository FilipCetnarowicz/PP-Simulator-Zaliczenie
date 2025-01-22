namespace Simulator.Maps
{
    public class SmallMap : Map
    {
        public readonly List<IMappable>?[,] pola;
        public SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY)
        {
            if (sizeX > 20 || sizeY > 20)
                throw new ArgumentOutOfRangeException(nameof(sizeX), "Rozmiar SmallMap nie może przekraczać 20 punktów.");
        pola = new List<IMappable>?[sizeX, sizeY];       
        }

        public override void Add(IMappable mappable, Point point)
        {
            if (!Exist(point))
            {
                throw new ArgumentOutOfRangeException("Punkt, który wybrałeś nie należy do mapy");
                }

            
            if (pola[point.X, point.Y] == null)
            {
                
                pola[point.X, point.Y] = new List<IMappable>();
            }

            
            pola[point.X, point.Y].Add(mappable);
        }

      public override void Remove(IMappable mappable, Point point)
        {
            
            var creaturesAtPoint = pola[point.X, point.Y];
            if (creaturesAtPoint != null)
            {
                
                creaturesAtPoint.Remove(mappable);
            }
        }
        public override List<IMappable> At(Point point)
        {
            
            return pola[point.X, point.Y] ?? new List<IMappable>();
        }

        public override List<IMappable> At(int x, int y) { 
            return At(new Point(x, y));}
        



        public override Point Next(Point p, Direction d)
        {
            throw new NotImplementedException();
        }

        public override Point NextDiagonal(Point p, Direction d)
        {
            throw new NotImplementedException();
        }
    }
}
