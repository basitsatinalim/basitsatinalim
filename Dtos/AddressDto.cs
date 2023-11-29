using System.ComponentModel.DataAnnotations;

namespace basitsatinalimuyg.Dtos
{
  public class AddresDto
  {
    public Guid? Id { get; set; } = Guid.NewGuid();
    [Required(ErrorMessage = "Adres başlığı boş olamaz.")]
    public string? AddressTitle { get; set; }
    [Required(ErrorMessage = "Adres içeriği boş olamaz.")]
    public string? AddressLine { get; set; }
    [Required(ErrorMessage = "Adres ilçesi boş olamaz.")]
    public string? City { get; set; }
    [Required(ErrorMessage = "Adres ilçesi boş olamaz.")]
    public string? Country { get; set; }
    [Required(ErrorMessage = "Adres posta kodu boş olamaz.")]
    public string? PostalCode { get; set; }
  }
}