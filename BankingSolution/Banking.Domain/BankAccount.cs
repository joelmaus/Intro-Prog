namespace Banking.Domain;

public class BankAccount
{
    private decimal _balance = 5000M; // State - "Fields" variable.
    public void Deposit(decimal amountToDeposit)
    {
        var bonus = 0M;
        if(_balance >= 5000 && IsDuringBusinessHours())
        {
            bonus = amountToDeposit * 0.10M;
        }
        _balance += amountToDeposit + bonus;
    }

    private bool IsDuringBusinessHours()
    {
        return DateTime.Now.Hour >= 9 && DateTime.Now.Hour < 16; // bogus but good enough for now

    }

    public decimal GetBalance()
    {
        return _balance;
    }

    public void Withdraw(decimal amountToWithdraw)
    {
        if (NotOverdraft(amountToWithdraw))
        {
            _balance -= amountToWithdraw;
        } else
        {
          throw new AccountOverdraftException();
        }

    }


    // "Never type private, always refactor to it" - Corey Haines.
    private bool NotOverdraft(decimal amountToWithdraw)
    {
        return _balance >= amountToWithdraw;
    }
}