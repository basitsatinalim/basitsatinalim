using basitsatinalimuyg.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Text.Json;

namespace basitsatinalimuyg.Utils
{
	public static class ModelBuilderExtensions
	{
		public static void ApplyMoneyValueConverter(this ModelBuilder modelBuilder)
		{
			var entityTypeList = modelBuilder.Model.GetEntityTypes().ToList();

			foreach (var entityType in entityTypeList)
			{
				var properties = entityType.ClrType.GetProperties()
					.Where(p => p.PropertyType == typeof(Money));

				foreach (var property in properties)
				{
					var entityBuilder = modelBuilder.Entity(entityType.ClrType);
					var propertyBuilder = entityBuilder.Property(property.PropertyType, property.Name);

					propertyBuilder.HasConversion(new MoneyValueConverter())
									 .HasColumnType("jsonb");
				}
			}
		}

		public static void ApplyPaymentValueConverter(this ModelBuilder modelBuilder)
		{
			var entityTypeList = modelBuilder.Model.GetEntityTypes().ToList();

			foreach (var entityType in entityTypeList)
			{
				var properties = entityType.ClrType.GetProperties()
					.Where(p => p.PropertyType == typeof(Payment));

				foreach (var property in properties)
				{
					var entityBuilder = modelBuilder.Entity(entityType.ClrType);
					var propertyBuilder = entityBuilder.Property(property.PropertyType, property.Name);

					propertyBuilder.HasConversion(new PaymentConverter())
									 .HasColumnType("jsonb");
				}
			}
		}
	}

	public class MoneyValueConverter : ValueConverter<Money, string>
	{
		private static readonly JsonSerializerOptions _jsonOptions = new()
		{
			PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
			WriteIndented = false
		};

		public MoneyValueConverter() : base(
			v => ConvertToString(v),
			v => ConvertToMoney(v))
		{
		}

		private static string ConvertToString(Money value)
		{
			return JsonSerializer.Serialize(value, _jsonOptions);
		}

		private static Money ConvertToMoney(string value)
		{
			return JsonSerializer.Deserialize<Money>(value, new JsonSerializerOptions
			{
				PropertyNamingPolicy = JsonNamingPolicy.CamelCase
			}) ?? new Money(10, CurrencyEnum.TRY);
		}
	}


	public class PaymentConverter : ValueConverter<Payment, string>
	{
		private static readonly JsonSerializerOptions _jsonOptions = new()
		{
			PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
			WriteIndented = false
		};

		public PaymentConverter() : base(
			v => ConvertToString(v),
			v => ConvertToPayment(v))
		{
		}

		private static string ConvertToString(Payment value)
		{
			return JsonSerializer.Serialize(value, _jsonOptions);
		}

		private static Payment ConvertToPayment(string value)
		{
			return JsonSerializer.Deserialize<Payment>(value, new JsonSerializerOptions
			{
				PropertyNamingPolicy = JsonNamingPolicy.CamelCase
			}) ?? new Payment("1111", "ABC", "12/99", "123");
		}
	}
}
