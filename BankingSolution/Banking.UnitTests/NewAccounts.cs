


using Banking.Domain;

namespace Banking.UnitTests;
public class NewAccounts
{

    [Fact]
    public void NewAccountsHaveTheCorrectOpeningBalance()
    {
        // Given I have a brand new bank account
        var account = new BankAccount();

        // When I ask that account for it's balance
        decimal openingBalance = account.GetBalance();

        // then it has a balance of $5,000.00
        Assert.Equal(5000M, openingBalance);
    }

}
