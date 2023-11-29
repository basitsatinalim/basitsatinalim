using basitsatinalimuyg.Dtos;
using basitsatinalimuyg.Models;
using basitsatinalimuyg.Services.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace basitsatinalimuyg.Controllers
{
  public class ProfileController : Controller
  {

    private readonly IUserService _userService;
    private readonly IOrderService _orderService;

    public ProfileController(IUserService userService, IOrderService orderService)
    {
      _userService = userService;
      _orderService = orderService;
    }


    public async Task<IActionResult> Index()
    {

      var user = await _userService.GetUserById(Guid.Parse(User.Identity?.Name ?? Guid.Empty.ToString()));

      return View(user);
    }
    public async Task<IActionResult> Order()
    {

      var orders = await _orderService.GetOrdersByUserId(Guid.Parse(User.Identity?.Name ?? Guid.Empty.ToString()));

      var model = new OrdersViewModel
      {
        Orders = orders
      };

      return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> DeleteOrder([FromQuery(Name = "orderId")] Guid orderId)
    {
      await _orderService.DeleteOrder(orderId);
      return RedirectToAction("Order");
    }

    [HttpGet]
    public async Task<IActionResult> Address()
    {
      var userAddresses = await _userService.GetUserAdresses(Guid.Parse(User.Identity?.Name ?? Guid.Empty.ToString()));
      return View(userAddresses);
    }



  }
}
