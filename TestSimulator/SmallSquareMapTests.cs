using Simulator;
using Simulator.Maps;

namespace TestSimulator
{
    public class SmallSquareMapTests
    {
        [Theory]
        // Arrange
        [InlineData(6)]
        [InlineData(15)]
        [InlineData(18)]
        public void CreateMap_WithValidSize_ShouldSucceed(int size)
        {
            // Act
            Assert.Equal(size, new SmallSquareMap(size).SizeX);
            Assert.Equal(size, new SmallSquareMap(size).SizeY);
        }

        [Theory]
        // Arrange
        [InlineData(4)]
        [InlineData(21)]
        [InlineData(0)]
        [InlineData(100)]
        public void CreateMap_WithInvalidSize_ShouldThrowException(int size) =>
            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new SmallSquareMap(size));

        [Theory]
        // Arrange
        [InlineData(10, 10, true)]  // Punkt w środku 
        [InlineData(0, 0, true)]    // Punkt w lewym górnym rogu
        [InlineData(-1, -1, false)] // Punkt poza mapą
        [InlineData(20, 20, false)] // Punkt poza mapą (granice)
        [InlineData(15, 0, true)]   // Punkt na dolnej granicy
        [InlineData(0, 19, true)]   // Punkt na prawej granicy
        public void Exist_ShouldReturnCorrectResult(int x, int y, bool expected)
        {
            var point = new Point(x, y);
            var map = new SmallSquareMap(20);
            Assert.Equal(expected, map.Exist(point));
        }

        [Theory]
        
        [InlineData(8, 8, Direction.Up, 8, 9)]          // Ruch do góry
        [InlineData(19, 19, Direction.Right, 19, 19)]   // Ruch na prawo (brzeg mapy)
        [InlineData(0, 0, Direction.Left, 0, 0)]        // Ruch w lewo (brzeg mapy)
        [InlineData(10, 10, Direction.Down, 10, 9)]     // Ruch w dół
        public void Next_ShouldReturnCorrectPoint(int startX, int startY, Direction direction, int expectedX, int expectedY)
        {
            var map = new SmallSquareMap(20);
            var point = new Point(startX, startY);
            var result = map.Next(point, direction);
            Assert.Equal(expectedX, result.X);
            Assert.Equal(expectedY, result.Y);
        }

        [Theory]
        
        [InlineData(8, 8, Direction.Up, 9, 9)]           // Ruch po przekątnej do góry
        [InlineData(19, 19, Direction.Right, 19, 19)]    // Ruch po przekątnej (brzeg mapy)
        [InlineData(0, 0, Direction.Left, 0, 0)]         // Ruch po przekątnej w lewo (brzeg mapy)
        [InlineData(5, 5, Direction.Down, 4, 4)]         // Ruch po przekątnej w dół
        [InlineData(10, 10, Direction.Up, 11, 11)]       // Ruch po przekątnej do góry
        public void NextDiagonal_ShouldReturnCorrectPoint(int startX, int startY, Direction direction, int expectedX, int expectedY)
        {
            var map = new SmallSquareMap(20);
            var point = new Point(startX, startY);
            var result = map.NextDiagonal(point, direction);
            Assert.Equal(expectedX, result.X);
            Assert.Equal(expectedY, result.Y);
        }
    }
}

