using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
using basitsatinalimuyg.Constants;

namespace basitsatinalimuyg.Dtos
{
  public class CheckoutDto
  {


    [JsonPropertyName("addressId")]
    public string? AddressId { get; set; }
    [JsonPropertyName("cardNumber")]
    public string? CardNumber { get; set; }
    [JsonPropertyName("holderName")]
    public string? HolderName { get; set; }
    [JsonPropertyName("expirationDate")]
    public string? ExpirationDate { get; set; }
    [JsonPropertyName("cvv")]
    public string? Cvv { get; set; }
    [JsonPropertyName("total")]
    public decimal Total { get; set; }
    [JsonPropertyName("items")]
    public string? Items { get; set; }
    [JsonPropertyName("count")]
    public int Count { get; set; }

  }
  public class CartItem
  {
    [JsonPropertyName("id")]
    public string? ProductId { get; set; }
    [JsonPropertyName("count")]
    public int Count { get; set; }
    [JsonPropertyName("category")]
    public string? Category { get; set; }
    [JsonPropertyName("amount")]
    public decimal Amount { get; set; }
    [JsonPropertyName("currency")]
    public string? Currency { get; set; }
  }

}
