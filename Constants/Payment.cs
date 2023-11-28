


namespace basitsatinalimuyg.Constants
{
  public class Payment
  {
    public Payment(string? cardNumber, string? holderName, string? expirationDate, string? cvv)
    {
      CardNumber = cardNumber;
      HolderName = holderName;
      ExpirationDate = expirationDate;
      Cvv = cvv;
    }

    public string? CardNumber { get; set; }
    public string? HolderName { get; set; }
    public string? ExpirationDate { get; set; }
    public string? Cvv { get; set; }



  }

}
