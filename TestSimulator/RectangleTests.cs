
using Simulator;

namespace TestSimulator
{
    public class RectangleTests
    {
        [Fact]
        public void Constructor_ShouldCreateRectangle_WithValidPoints()
        {
            // Arrange
            int x1 = 2, y1 = 3, x2 = 5, y2 = 6;

            // Act
            var rectangle = new Rectangle(x1, y1, x2, y2);

            // Assert
            Assert.Equal(x1, rectangle.X1);
            Assert.Equal(y1, rectangle.Y1);
            Assert.Equal(x2, rectangle.X2);
            Assert.Equal(y2, rectangle.Y2);
        }

        [Fact]
        public void Constructor_ShouldSwapPoints_IfPointsAreReversed()
        {
            // Arrange
            int x1 = 5, y1 = 6, x2 = 2, y2 = 3;

            // Act
            var rectangle = new Rectangle(x1, y1, x2, y2);

            // Assert
            Assert.Equal(2, rectangle.X1);
            Assert.Equal(3, rectangle.Y1);
            Assert.Equal(5, rectangle.X2);
            Assert.Equal(6, rectangle.Y2);
        }

        [Fact]
        public void Constructor_ShouldThrowArgumentException_WhenPointsAreCollinear()
        {
            // Arrange
            int x1 = 2, y1 = 3, x2 = 2, y2 = 3; // Same point (invalid rectangle)

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Rectangle(x1, y1, x2, y2));
        }

        [Fact]
        public void Contains_ShouldReturnTrue_WhenPointIsInsideRectangle()
        {
            // Arrange
            var rectangle = new Rectangle(2, 3, 5, 6);
            var point = new Point(3, 4);

            // Act
            var result = rectangle.Contains(point);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Contains_ShouldReturnFalse_WhenPointIsOutsideRectangle()
        {
            // Arrange
            var rectangle = new Rectangle(2, 3, 5, 6);
            var point = new Point(6, 7);

            // Act
            var result = rectangle.Contains(point);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void ToString_ShouldReturnCorrectFormat()
        {
            // Arrange
            var rectangle = new Rectangle(2, 3, 5, 6);

            // Act
            var result = rectangle.ToString();

            // Assert
            Assert.Equal("(2, 3):(5, 6)", result);
        }

        
    }
}
