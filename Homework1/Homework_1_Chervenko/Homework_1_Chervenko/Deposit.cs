namespace Homework_1_Chervenko
{
    public class Deposit
    {
        public double Amount { get; set; }
        public InterestRate Rate { get; }
        public Deposit(double amount)
        {
            Amount = amount;
            Rate = BankCondition.GetInterestRate(amount);
        }
        
        public double GetTotalWithBonusAndProfit()
        {
            return Amount + ProfitCalculator.GetProfit(this);
        }
    }
}
