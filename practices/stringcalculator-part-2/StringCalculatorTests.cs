
using Moq;

namespace StringCalculator;

public class StringCalculatorTests
{
    private StringCalculator calculator;

    public StringCalculatorTests()
    {
        calculator = new StringCalculator(new Mock<ILogger>().Object, new Mock<IWebService>().Object);
    }
    [Fact]
    public void EmptyStringReturnsZero()
    {
       

        var result = calculator.Add("");

        Assert.Equal(0, result);
    }
    [Theory]
    [InlineData("1,2", 3)]
    [InlineData("1\n2,3,4,5,6,7,8,9", 45)]

    public void AllPartOneUpToThree(string numbers, int expected)
    {
        var result = calculator.Add(numbers);

        Assert.Equal(expected, result);
    } 
}
