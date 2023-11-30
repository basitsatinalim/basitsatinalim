using Microsoft.AspNetCore.Mvc;
using basitsatinalimuyg.Services.Abstraction;
using basitsatinalimuyg.Constants;
using basitsatinalimuyg.Dtos;
using Microsoft.AspNetCore.Authorization;
using basitsatinalimuyg.Repositories.Abstraction;
using AutoMapper;
using basitsatinalimuyg.Entities;

namespace basitsatinalimuyg.Controllers
{
  [Route("Admin/Order")]
  [Authorize(Roles = $"{UserRoles.ROLE_ADMIN}")]
  public class AdminOrderController : Controller
  {
    private readonly IMapper _mapper;
    private readonly IOrderService _orderService;

    public AdminOrderController(IMapper mapper, IOrderService orderService)
    {
      _mapper = mapper;
      _orderService = orderService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
      var orders = await _orderService.GetAllOrderAsync();
      return View("Order/Index", orders);
    }


    [HttpGet]
    [Route("Delete/{id}")]
    public async Task<IActionResult> Delete(Guid? id)
    {

      if (id == null) return NotFound();

      await _orderService.DeleteOrder(id.Value);

      return RedirectToAction("Index");
    }
  }
}
