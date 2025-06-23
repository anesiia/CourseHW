using System;

namespace Homework_1_Chervenko
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // першу частину зробила без ооп, бо вона простіша
            Console.WriteLine("Write your start deposit:");
            
            var input = Convert.ToDouble(Console.ReadLine());
            double profit = 0;

            // думала ще зробити перевірку введеного на те, чи взагалі там число
            // і чи успішно воно конвернутвалося, але це треба юзати double.TryParse тому не стала
            // бо у завданя написано Convert.ToDouble обовязково
            if (input <= 0)
            {
                Console.WriteLine("Restart and enter correct deposit!");
            }
            else if (input < 100)
            {
                profit = (input / 100) * 5;
            }
            else if (input <= 200)
            {
                profit = (input / 100) * 7;
            }
            else profit = (input / 100) * 10;

            Console.WriteLine("Your input with expected profit is: ");
            Console.WriteLine($"1.  {input + profit}");

            // друга частина завдання вже з використанням ооп

            var deposit = new Deposit(input);
            Console.WriteLine($"2. {deposit.GetTotalWithBonusAndProfit()}");

            // третє завдання
            Console.WriteLine("\r\nTASK 3\r\n");
            Console.WriteLine("Result: Bar.Quux(object)\r\nBaz.Quux(params T[])");
            Console.WriteLine("Я не дуже зрозумiла це завдання, але напевно сенс був " +
                "розiбратися в перевизначеннi та перевантаженнi, я розiбралася " +
                "(спочатку Bar перевизначає метод Quux з Foo та робить перевантаження шляхом прийняття параметру object. " +
                "А метод Baz вже перевизначає той самий перевизначений метод з Bar та знов робить перевантаження " +
                "змiнюючи аргумент з object на дженерiк params T[].\r\n " +
                "Як я зрозумiла, коли ми запустимо програму то спочатку буде викликано метод Bar.Quux(object) " +
                "бо саме метод з цим параметром було оголошено в класi напряму, а не переписано." +
                "Тому воно надає йому бiльший прiорiтет, хоча фактично якщо його прибрати, то спрацює перший метод через iнт." +
                "А у другий раз буде Baz.Quux(params T[]) бо це дженерiк метод який бiльш унiверсальний, тому" +
                "компiлятор надає теж йому перевагу i знов таки бо вiн оголошен у класi, а не успадкований" +
                " але знов з iнтовим вхiдним числом)");

        }
    }
}