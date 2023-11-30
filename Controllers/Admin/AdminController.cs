
using AutoMapper;
using basitsatinalimuyg.Constants;
using basitsatinalimuyg.Context;
using basitsatinalimuyg.Entities;
using basitsatinalimuyg.Models;
using basitsatinalimuyg.Repositories.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace basitsatinalimuyg.Controllers
{
  [Authorize(Roles = $"{UserRoles.ROLE_ADMIN}")]
  [Route("Admin")]
  public class AdminController : Controller
  {
    private readonly IUserRepository _userRepository;
    private readonly IProductRepository _productRepository;
    private readonly IOrderRepository _orderRepository;

    public AdminController(IUserRepository userRepository, IProductRepository productRepository, IOrderRepository orderRepository)
    {
      _userRepository = userRepository;
      _productRepository = productRepository;
      _orderRepository = orderRepository;
    }


    [HttpGet]
    public async Task<IActionResult> Index()
    {

      var allUsers = await _userRepository.GetAllAsync();
      var allProducts = await _productRepository.GetAllAsync();
      var allOrders = await _orderRepository.GetAllAsync();

      var model = new AdminViewModel
      {
        Users = allUsers,
        Products = allProducts,
        Orders = allOrders
      };
      return View("Index", model);
    }

  }
}
