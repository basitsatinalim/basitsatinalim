using System.Text.Json.Serialization;

namespace basitsatinalimuyg.Constants
{
    public class Money
    {

        public Money(decimal? amount, CurrencyEnum? currency)
        {
            Amount = amount;
            Currency = currency;
        }


        public decimal? Amount { get; set; }
        public CurrencyEnum? Currency { get; set; }
        public override string ToString()
        {
            return $"{Amount} {Currency}";
        }

    }
}
