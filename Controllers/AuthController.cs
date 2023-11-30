using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using basitsatinalimuyg.Dtos;
using basitsatinalimuyg.Services.Abstraction;
using basitsatinalimuyg.Constants;
using basitsatinalimuyg.Utils;

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
			if (User?.Identity?.IsAuthenticated ?? false) return RedirectToAction("Index", "Home");
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Login([Bind("Email,Password,RememberMe")] LoginDto login, [FromQuery(Name = "redirectUrl")] string? redirectUrl)
		{
			if (User?.Identity?.IsAuthenticated ?? false) return RedirectToAction("Index", "Home");
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
					new(ClaimTypes.Name, user.Id.ToString()),
					new(ClaimTypes.Role, user.Role.GetName() ?? UserRoleEnum.ROLE_USER.GetName()!),
					new(ClaimTypes.NameIdentifier, user.Email!),
					new(ClaimTypes.DateOfBirth, user.BirthDate.ToString()!),
					new("FirstName", user.Name!),

				};

				var claimsIdentity = new ClaimsIdentity(
					claims, CookieAuthenticationDefaults.AuthenticationScheme);

				var authProperties = new AuthenticationProperties
				{
					AllowRefresh = true,
					ExpiresUtc = DateTimeOffset.UtcNow.AddDays(1),
					IsPersistent = login.RememberMe,
					IssuedUtc = DateTimeOffset.UtcNow,
					RedirectUri = redirectUrl
				};

				await HttpContext.SignInAsync(
					CookieAuthenticationDefaults.AuthenticationScheme,
					new ClaimsPrincipal(claimsIdentity),
					authProperties);


				if (redirectUrl != null) return Redirect(redirectUrl);

				return RedirectToAction("Index", "Home");
			}
			ModelState.AddModelError(string.Empty, "Invalid login attempt.");
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> Logout()
		{
			if (!User?.Identity?.IsAuthenticated ?? false) return RedirectToAction("Index", "Home");

			await HttpContext.SignOutAsync(
									CookieAuthenticationDefaults.AuthenticationScheme);

			return RedirectToAction("Index", "Home");


		}

		[HttpGet]
		public IActionResult Register()
		{
			if (User?.Identity?.IsAuthenticated ?? false) return RedirectToAction("Index", "Home");
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Register(RegisterDto register)
		{
			if (User?.Identity?.IsAuthenticated ?? false) return RedirectToAction("Index", "Home");

			if (ModelState.IsValid)
			{
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
