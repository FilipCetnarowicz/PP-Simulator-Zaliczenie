using Simulator;

namespace TestSimulator
{
    public class ValidatorTests
    {
        [Theory]
        [InlineData(5, 1, 10, 5)] 
        [InlineData(0, 1, 10, 1)]  
        [InlineData(15, 1, 10, 10)] 
        public void Limiter_ShouldReturnCorrectValue(int value, int min, int max, int expected)
        {
            // Act
            var result = Validator.Limiter(value, min, max);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(null, 5, 10, '*', "*****")] 
        [InlineData("", 5, 10, '*', "*****")]   
        [InlineData("test", 5, 10, '*', "Test*")] 
        [InlineData("HelloWorld", 5, 10, '*', "HelloWorld")]
        [InlineData("This is a long string", 5, 10, '*', "This is a ")] 
        public void Shortener_ShouldReturnCorrectResult(string value, int min, int max, char placeholder, string expected)
        {
            // Act
            var result = Validator.Shortener(value, min, max, placeholder);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("hello", 5, 10, '*', "Hello")] 
        [InlineData("Hello", 5, 10, '*', "Hello")] 
        [InlineData("another test", 10, 20, '-', "Another test")]  
        public void Shortener_ShouldCapitalizeFirstLetter(string value, int min, int max, char placeholder, string expected)
        {
            // Act
            var result = Validator.Shortener(value, min, max, placeholder);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
