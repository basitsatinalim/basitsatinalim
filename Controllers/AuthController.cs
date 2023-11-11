using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using basitsatinalimuyg.Dtos;
using basitsatinalimuyg.Services.Abstraction;
using Microsoft.AspNetCore.Mvc.RazorPages;
using basitsatinalimuyg.Constants;
using basitsatinalimuyg.Utils;
using Microsoft.AspNetCore.Authorization;

namespace basitsatinalimuyg.Controllers
{
	public class AuthController : Controller
	{
		private readonly IAuthService _authService;
		private readonly ILogger<AuthController> _logger;

		public AuthController(IAuthService authService, ILogger<AuthController> logger)
		{
			_authService = authService;
			_logger = logger;
		}


		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Login([Bind("Email,Password,RememberMe")] LoginDto login, [FromQuery(Name = "RedirectUrl")] string? redirectUrl)
		{


			if (ModelState.IsValid)
			{

				var user = await _authService.Login(login.Email!, login.Password!);

				if (user == null)
				{
					ModelState.AddModelError(string.Empty, "Invalid login attempt.");
					return View();
				}

				var claims = new List<Claim>
				{
					new Claim(ClaimTypes.Name, user.Email!),
					new Claim(ClaimTypes.Role, user.Role.GetName() ?? UserRoleEnum.ROLE_USER.GetName()!),
					new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
				};

				var claimsIdentity = new ClaimsIdentity(
					claims, CookieAuthenticationDefaults.AuthenticationScheme);

				var authProperties = new AuthenticationProperties
				{
					AllowRefresh = true,
					ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30),
					IsPersistent = login.RememberMe,
					IssuedUtc = DateTimeOffset.UtcNow,
					RedirectUri = redirectUrl
				};

				await HttpContext.SignInAsync(
					CookieAuthenticationDefaults.AuthenticationScheme,
					new ClaimsPrincipal(claimsIdentity),
					authProperties);

				_logger.LogInformation("User {Email} logged in at {Time}.",
					user.Email, DateTime.UtcNow);

				if (redirectUrl != null) return Redirect(redirectUrl);

				return RedirectToAction("Index", "Home");
			}
			ModelState.AddModelError(string.Empty, "Invalid login attempt.");
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> Logout()
		{
			if (!User.Identity.IsAuthenticated) return RedirectToAction("Index", "Home");

			await HttpContext.SignOutAsync(
									CookieAuthenticationDefaults.AuthenticationScheme);

			_logger.LogInformation("User {Email} logged out at {Time}.",
									User.Identity!.Name, DateTime.UtcNow);

			return RedirectToAction("Index", "Home");


		}

		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Register(RegisterDto register)
		{
			if (User.Identity.IsAuthenticated) return RedirectToAction("Index", "Home");

			if (ModelState.IsValid)
			{
				Console.WriteLine("valid");	
				var user = await _authService.Register(register);

				if (user == null)
				{
					ModelState.AddModelError(string.Empty, "Herhangi bir hesap bulunamadi.");
					return View();
				}

				return RedirectToAction("Login", "Auth");
			}
			return View();
		}


	}
}
