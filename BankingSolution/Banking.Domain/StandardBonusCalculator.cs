namespace Banking.Domain;

public class StandardBonusCalculator : ICanCalculateAccountBonuses
{
    private IProvideTheBusinessClock _businessClock;

    public StandardBonusCalculator(IProvideTheBusinessClock businessClock)
    {
        _businessClock = businessClock;
    }

    public decimal GetDepositBonusFor(decimal balance, decimal amountToDeposit)
    {
        return GetsBonus(balance) ? amountToDeposit * .10M : 0;
    }

    private bool GetsBonus(decimal balance)
    {
        return balance >= 5000M && _businessClock.IsDuringBusinessHours();
    }
}