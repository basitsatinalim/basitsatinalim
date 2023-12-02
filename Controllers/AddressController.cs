using basitsatinalimuyg.Dtos;
using basitsatinalimuyg.Services.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace basitsatinalimuyg.Controllers
{

  public class AddressController : Controller
  {

    private readonly IAddressService _addressService;

    public AddressController(IAddressService addressService)
    {
      _addressService = addressService;
    }


    [HttpGet]
    public async Task<IActionResult> Get(Guid addressId)
    {
      var address = await _addressService.GetAddressByIdAsEntity(addressId);

      return View(address);
    }

    [HttpPost]
    public async Task<IActionResult> Add(AddresDto userAddress, string? returnUrl = null)
    {
      if (ModelState.IsValid)
      {
        var userId = Guid.Parse(User.Identity?.Name ?? Guid.Empty.ToString());
        await _addressService.AddUserAddress(userId, userAddress);
        if (returnUrl != null) return Redirect(returnUrl);
        return RedirectToAction("Address", "Profile");
      }
      return View(userAddress);
    }

    [HttpGet]
    public async Task<IActionResult> Delete([FromQuery(Name = "addressId")] Guid addressId)
    {
      var userId = Guid.Parse(User.Identity?.Name ?? Guid.Empty.ToString());
      await _addressService.DeleteUserAddress(addressId);
      return RedirectToAction("Address", "Profile");
    }

    [HttpPost]
    public async Task<IActionResult> Edit(AddresDto userAddress)
    {
      if (ModelState.IsValid)
      {
        var userId = Guid.Parse(User.Identity?.Name ?? Guid.Empty.ToString());
        await _addressService.UpdateUserAddress(userId, userAddress);
        return RedirectToAction("Address", "Profile");
      }
      return View(userAddress);
    }
  }

}