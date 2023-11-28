using System.ComponentModel.DataAnnotations;

namespace basitsatinalimuyg.Constants
{
	public class Money
	{

		public Money(decimal? amount, CurrencyEnum? currency)
		{
			Amount = amount;
			Currency = currency;
		}


		[DisplayFormat(DataFormatString = "{0:0.00}")]
		public decimal? Amount { get; set; }
		public CurrencyEnum? Currency { get; set; }

		public override string ToString()
		{
			return $"{Amount} {Currency}";
		}

	}
}
