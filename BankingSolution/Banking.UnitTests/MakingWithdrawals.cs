namespace Banking.UnitTests;
public class MakingWithdrawals
{
    private BankAccount _account;
    private decimal _openingBalance;

    public MakingWithdrawals()
    {
        _account = new BankAccount();
        _openingBalance = _account.GetBalance();
    }

    [Theory]
    [InlineData(100)]
    [InlineData(183.23)]
    public void MakingAWithdrawalDecreasesBalance(decimal amountToWithdraw)
    {

        _account.Withdraw(amountToWithdraw);

        Assert.Equal(_openingBalance - amountToWithdraw, _account.GetBalance());
    }

    [Fact]
    public void OverdraftIsNotAllowedBalanceStaysTheSame()
    {
        var amountToWithdraw = _openingBalance + .01M;
        try
        {
            _account.Withdraw(amountToWithdraw); // sus!
        }
        catch (AccountOverdraftException)
        {
            // was expecting that... carry on. 
        }
        Assert.Equal(_openingBalance, _account.GetBalance());

    }

    [Fact]
    public void OverdraftThrowsException()
    {
        Assert.Throws<AccountOverdraftException>(() =>
             _account.Withdraw(_openingBalance + .01M)
             );
       
    }


    [Fact]
    public void CanTakeEntireBalance()
    {
        _account.Withdraw(_account.GetBalance());
        Assert.Equal(0, _account.GetBalance());
    }
}
