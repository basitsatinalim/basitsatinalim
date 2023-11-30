

using basitsatinalimuyg.Entities;

namespace basitsatinalimuyg.Models
{
  public class AdminViewModel
  {

    public ICollection<User>? Users { get; set; }
    public ICollection<Product>? Products { get; set; }
    public ICollection<Order>? Orders { get; set; }

  }
}
