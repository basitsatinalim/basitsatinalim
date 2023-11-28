using AutoMapper;
using basitsatinalimuyg.Dtos;
using basitsatinalimuyg.Entities;
using basitsatinalimuyg.Models;
using basitsatinalimuyg.Services.Abstraction;
using basitsatinalimuyg.Constants;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace basitsatinalimuyg.Controllers
{
	public class CheckoutController : Controller
	{

		private readonly IUserService _userService;
		private readonly IProductService _productService;
		private readonly IOrderService _orderService;
		private readonly IMapper _mapper;


		public CheckoutController(IUserService userService, IProductService productService, IOrderService orderService, IMapper mapper)
		{
			_userService = userService;
			_productService = productService;
			_orderService = orderService;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			if (User.Identity != null && User.Identity.IsAuthenticated)
			{

				var user = await _userService.GetUserById(Guid.Parse(User.Identity.Name ?? Guid.Empty.ToString()));

				if (user == null)
				{
					return NotFound();
				}

				var userAdresses = await _userService.GetUserAdresses(user.Id ?? Guid.Empty);
				return View(new CheckoutViewModel
				{
					UserAddresses = userAdresses,
				});
			}
			else
			{
				return RedirectToAction("Login", "Auth",
					new { redirectUrl = "/Checkout" }
				);
			}
		}

		[HttpPost]
		public async Task<IActionResult> Index([FromBody] CheckoutDto checkout)
		{

			if (checkout.AddressId == null)
			{
				return Json(new { success = false, message = $"Address is not provided." });
			}

			var user = await _userService.GetUserByIdAsEntity(Guid.Parse(User?.Identity?.Name ?? Guid.Empty.ToString()));

			var address = await _userService.GetAddressByIdAsEntity(Guid.Parse(checkout.AddressId ?? Guid.Empty.ToString()));

			if (user == null)
			{
				return Json(new { success = false, message = $"User not found." });
			}

			var order = _mapper.Map<Order>(checkout);

			order.UserId = user.Id;
			order.User = user;
			order.Status = OrderStatusEnum.Pending;
			order.ShippingAddressId = address?.Id;


			var items = JsonSerializer.Deserialize<ICollection<CartItem>>(checkout.Items, new JsonSerializerOptions
			{
				PropertyNamingPolicy = JsonNamingPolicy.CamelCase
			});

			foreach (var cartItem in items)
			{


				var product = await _productService.GetProductById(Guid.Parse(cartItem.ProductId ?? Guid.Empty.ToString()));

				if (product == null)
				{
					return Json(new { success = false, message = $"{cartItem.ProductId} is not found." });
				}

				if (product.Stock < cartItem.Count)
				{
					return Json(new { success = false, message = $"{product.Name} is out of stock." });
				}

				var orderLineItem = _mapper.Map<OrderLineItem>(cartItem);

				orderLineItem.ProductId = Guid.Parse(cartItem.ProductId ?? Guid.Empty.ToString());
				orderLineItem.Order = order;
				orderLineItem.OrderId = order.Id;

				order.OrderLineItems?.Add(orderLineItem);
			}

			await _orderService.SaveOrder(order);


			return Json(new { success = true, message = "Your order has been applied. :)", orderId = order.Id });

		}

	}
}
