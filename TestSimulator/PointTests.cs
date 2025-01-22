using Simulator;

namespace TestSimulator
{
    public class PointTests
    {
        [Theory]
        [InlineData(0, 0, Direction.Up, 0, 1)]
        [InlineData(0, 0, Direction.Down, 0, -1)]
        [InlineData(0, 0, Direction.Left, -1, 0)]
        [InlineData(0, 0, Direction.Right, 1, 0)]
        [InlineData(5, 5, Direction.Up, 5, 6)]
        [InlineData(5, 5, Direction.Down, 5, 4)]
        [InlineData(5, 5, Direction.Left, 4, 5)]
        [InlineData(5, 5, Direction.Right, 6, 5)]
        public void Next_ShouldReturnCorrectPoint(int startX, int startY, Direction direction, int expectedX, int expectedY)
        {
            // Arrange
            var point = new Point(startX, startY);

            // Act
            var result = point.Next(direction);

            // Assert
            Assert.Equal(expectedX, result.X);
            Assert.Equal(expectedY, result.Y);
        }

        [Theory]
        [InlineData(0, 0, Direction.Up, 1, 1)]
        [InlineData(0, 0, Direction.Down, -1, -1)]
        [InlineData(0, 0, Direction.Left, -1, 1)]
        [InlineData(0, 0, Direction.Right, 1, -1)]
        [InlineData(5, 5, Direction.Up, 6, 6)]
        [InlineData(5, 5, Direction.Down, 4, 4)]
        [InlineData(5, 5, Direction.Left, 4, 6)]
        [InlineData(5, 5, Direction.Right, 6, 4)]
        public void NextDiagonal_ShouldReturnCorrectPoint(int startX, int startY, Direction direction, int expectedX, int expectedY)
        {
            // Arrange
            var point = new Point(startX, startY);

            // Act
            var result = point.NextDiagonal(direction);

            // Assert
            Assert.Equal(expectedX, result.X);
            Assert.Equal(expectedY, result.Y);
        }
    }
}
