namespace Simulator
{
    public class DirectionParser
    {
        public static List<Direction> Parse(string directions)
        {
            var result = new List<Direction>();

            foreach (var ch in directions.ToUpper())
            {
                switch (ch)
                {
                    case 'U':
                        result.Add(Direction.Up);
                        break;
                    case 'R':
                        result.Add(Direction.Right);
                        break;
                    case 'D':
                        result.Add(Direction.Down);
                        break;
                    case 'L':
                        result.Add(Direction.Left);
                        break;
                    default:
                        continue;
                }
            }
            return result;
        }
    }
}

