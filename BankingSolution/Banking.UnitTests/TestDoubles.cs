

namespace Banking.UnitTests;
public class DummyBonusCalculator : ICanCalculateAccountBonuses
{
    public decimal GetDepositBonusFor(decimal balance, decimal amountToDeposit)
    {
        return 0;
    }
}



//public class StubbedBonusCalculator : ICanCalculateAccountBonuses
//{
//    public decimal GetDepositBonusFor(decimal balance, decimal amountToDeposit)
//    {
//        if(balance == 5000M && amountToDeposit == 118.32M)
//        {
//            return 42.18M;
//        } else
//        {
//            return 0;
//        }
//    }
//}