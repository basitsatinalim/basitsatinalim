using basitsatinalimuyg.Entities;

namespace basitsatinalimuyg.Models
{
  public class OrdersViewModel
  {

    public ICollection<Order> Orders { get; set; } = new List<Order>();


  }
}