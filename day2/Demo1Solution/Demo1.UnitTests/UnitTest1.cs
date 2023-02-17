

namespace Demo1.UnitTests;

public class UnitTest1
{


    [Fact]
    public void CanAddTwoNumbers()
    {
        // Given (Arrange)
        int a = 10, b = 20, c;
        // When (Act)
        c = a + b; // This is the thing you are actually testing.
        // Then (Assert)
        Assert.Equal(30, c);
    }

    [Theory]
    [InlineData(2, 2, 4)]
    [InlineData(8,2, 10)]
    [InlineData(40,2, 42)]
    public void CanAddTwoNumbersTheory(int a, int b, int expected)
    {

        int answer = a + b;
        Assert.Equal(expected, answer);
    }


}