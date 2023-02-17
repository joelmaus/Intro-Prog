namespace Banking.Domain;

// A Job description. Any class that implements this interface is promising it "Can Do" this job description
public interface ICanCalculateAccountBonuses
{
    decimal GetDepositBonusFor(decimal balance, decimal amountToDeposit);
}