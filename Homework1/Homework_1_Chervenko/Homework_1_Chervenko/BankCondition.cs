namespace Homework_1_Chervenko
{
    public static class BankCondition
    {
        private static readonly int additionalBonus = 15;

        public static InterestRate GetInterestRate(double amount)
        {
            if (amount < 100)
            {
                return InterestRate.Low;
            }
            else if (amount <= 200)
            {
                return InterestRate.Medium;
            }
            else return InterestRate.High;
        }
        public static int GetBonus()
        {
            return additionalBonus;
        }
    }
}
