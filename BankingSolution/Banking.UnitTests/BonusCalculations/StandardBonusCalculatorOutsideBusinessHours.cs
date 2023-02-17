namespace Banking.UnitTests.BonusCalculations;

public class StandardBonusCalculatorOutsideBusinessHours
{

    private StandardBonusCalculator _calculator;
    public StandardBonusCalculatorOutsideBusinessHours()
    {
        var stubbedClock = new Mock<IProvideTheBusinessClock>();
        stubbedClock.Setup(c => c.IsDuringBusinessHours()).Returns(false);
        _calculator = new StandardBonusCalculator(stubbedClock.Object);
    }
    // 1. Deposits under the cutoff amount get no bonus. (5000)
    [Fact]
    public void UnderCutoffGetNoBonus()
    {
        var bonus = _calculator.GetDepositBonusFor(4999.99M, 100);
        Assert.Equal(0, bonus);
    }
    [Fact]
    public void AtCutoffGetsNoBonus()
    {
        var bonus = _calculator.GetDepositBonusFor(5000M, 100);
        Assert.Equal(0, bonus);
    }

}
