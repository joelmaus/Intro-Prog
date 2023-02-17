
namespace StringCalculator;

public class StringCalculatorTests
{
    StringCalculator _calculator;

    public StringCalculatorTests()
    {
        _calculator = new StringCalculator();
    }
    [Fact]
    public void EmptyStringReturnsZero()
    {
       

        var result = _calculator.Add("");

        Assert.Equal(0, result);
    }

    [Theory]
    [InlineData("1", 1)]
    [InlineData("2", 2)]
    [InlineData("108", 108)]
    public void SingleDigit(string numbers, int expected)
    {
        

        var result = _calculator.Add(numbers);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("1,2", 3)]
    [InlineData("8,2", 10)]
    [InlineData("10,99", 109)]
    [InlineData("2023,1005", 2023 + 1005)]
    public void TwoDigits(string numbers, int expected)
    {
        var result = _calculator.Add(numbers);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("1,2,6", 9)]
    [InlineData("1,2,3,4,5,6,7,8,9", 45)]

    public void Arbitrary(string numbers, int expected)
    {
        var result = _calculator.Add(numbers);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("1\n2", 3)]
    [InlineData("1\n2\n3", 6)]
    [InlineData("1\n2,3", 6)]
    public void NewLineDelimeters(string numbers, int expected)
    {
        var result = _calculator.Add(numbers);
        Assert.Equal(expected, result);
    }

    // //;\n1;2

    [Theory]
    [InlineData("//;\n1;2", 3)]
    [InlineData("//;\n10;2", 12)]
    [InlineData("//*\n10*2", 12)]
    [InlineData("//*\n10*2,1\n1",14)]

    public void CustomDelimeters(string numbers, int expected)
    {
        var result = _calculator.Add(numbers);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("-1")]
    [InlineData("1\n2,-18")]
    public void ThrowsOnNegativeNumbers(string numbers)
    {
        Assert.Throws<NoNegativeNumbersException>(() => _calculator.Add(numbers));
    }
}
