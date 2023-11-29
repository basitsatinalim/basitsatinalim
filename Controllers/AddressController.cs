using basitsatinalimuyg.Dtos;
using basitsatinalimuyg.Services.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace basitsatinalimuyg.Controllers
{

  public class AddressController : Controller
  {

    private readonly IUserService _userService;

    public AddressController(IUserService userService)
    {
      _userService = userService;
    }


    [HttpGet]
    public async Task<IActionResult> Get(Guid addressId)
    {
      var address = await _userService.GetAddressByIdAsEntity(addressId);

      return View(address);
    }

    [HttpPost]
    public async Task<IActionResult> Add(AddresDto userAddress, string? returnUrl = null)
    {
      if (ModelState.IsValid)
      {
        var userId = Guid.Parse(User.Identity?.Name ?? Guid.Empty.ToString());
        await _userService.AddUserAddress(userId, userAddress);
        if (returnUrl != null) return Redirect(returnUrl);
        return RedirectToAction("Address", "Profile");
      }
      return View(userAddress);
    }

    [HttpGet]
    public async Task<IActionResult> Delete([FromQuery(Name = "addressId")] Guid addressId)
    {
      var userId = Guid.Parse(User.Identity?.Name ?? Guid.Empty.ToString());
      await _userService.DeleteUserAddress(userId, addressId);
      return RedirectToAction("Address", "Profile");
    }

    [HttpPost]
    public async Task<IActionResult> Edit(AddresDto userAddress)
    {
      if (ModelState.IsValid)
      {
        var userId = Guid.Parse(User.Identity?.Name ?? Guid.Empty.ToString());
        await _userService.UpdateUserAddress(userId, userAddress);
        return RedirectToAction("Address", "Profile");
      }
      return View(userAddress);
    }
  }

}