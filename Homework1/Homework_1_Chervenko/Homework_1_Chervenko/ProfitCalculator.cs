namespace Homework_1_Chervenko
{
    internal static class ProfitCalculator
    {
        public static double GetProfit(Deposit deposit)
        {
            return deposit.Amount * (int)deposit.Rate / 100 + BankCondition.GetBonus();
        }
    }
}
