namespace Banking.UnitTests;
public class BankAccountDepositsUseTheBonusCalculator
{
    [Fact]
    public void BonusAppliedToDeposit()
    {
        // Given
        var stubbedBonusCalculator = new Mock<ICanCalculateAccountBonuses>();
        var account = new BankAccount(stubbedBonusCalculator.Object);
        var openingBalance = account.GetBalance();
        var amountToDeposit = 118.32M;
        stubbedBonusCalculator.Setup(calculator =>
               calculator.GetDepositBonusFor(openingBalance, amountToDeposit)
        ).Returns(42.18M);


        // When
        account.Deposit(amountToDeposit); // <- THIS IS THE SYSTEM UNDER TEST
        // Then
        Assert.Equal(openingBalance + amountToDeposit + 42.18M, account.GetBalance());
    }
}
