using System;

namespace EF_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new CurrencyContext();
            for (int i = 0; i < 19; i++)
            {
                double rate = GetRandomNumber(0, 10);
                Currency curr = new Currency
                {
                    Date = Convert.ToDateTime($"5/{i + 1}/2020"),
                    Rate = (decimal)rate,
                    FromCurrency = "USD",
                    ToCurrency = "GEL"
                };
                context.Add(curr);
                context.SaveChanges();
            }
        }

        public static double GetRandomNumber(double minimum, double maximum)
        {
            Random random = new Random();
            return random.NextDouble() * (maximum - minimum) + minimum;
        }
    }
}
