namespace Banking.UnitTests;
public class MakingDeposits
{

    [Fact]
    public void DepositingMoneyIncreasesTheBalance()
    {
        // Given
        var account = new BankAccount(new DummyBonusCalculator());
        var openingBalance = account.GetBalance();
        var amountToDeposit = 100M;
        // When

        account.Deposit(amountToDeposit);
        // Then
        Assert.Equal(openingBalance + amountToDeposit, account.GetBalance());
    }
}
