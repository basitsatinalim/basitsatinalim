
using AutoMapper;
using basitsatinalimuyg.Constants;
using basitsatinalimuyg.Context;
using basitsatinalimuyg.Entities;
using basitsatinalimuyg.Repositories.Abstraction;
using basitsatinalimuyg.Services.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace basitsatinalimuyg.Controllers
{
  [Authorize(Roles = $"{UserRoles.ROLE_ADMIN}")]
  [Route("Admin/Address")]
  public class AdminAddressController : Controller
  {
    private readonly IAddressService _addressService;
    private readonly IUnitOfWork _unitOfWork;

    public AdminAddressController(IUnitOfWork unitOfWork, IAddressService addressService)
    {
      _unitOfWork = unitOfWork;
      _addressService = addressService;
    }


    [HttpGet]
    public async Task<IActionResult> Index()
    {

      var allAddresses = await _addressService.GetAllAddressAsync();

      return View("Address/Index", allAddresses);
    }

    [HttpGet]
    [Route("Edit/{id}")]
    public async Task<IActionResult> Edit(Guid id)
    {

      var address = await _addressService.GetAddressByIdAsEntity(id);
      return View("Address/Edit", address);
    }

    [HttpPost]
    [Route("Edit/{id}")]
    public async Task<IActionResult> Edit(Guid id, Address address)
    {

      var dbAddress = await _addressService.GetAddressByIdAsEntity(id) ?? throw new NullReferenceException();

      dbAddress.AddressLine = address.AddressLine;
      dbAddress.City = address.City;
      dbAddress.Country = address.Country;
      dbAddress.PostalCode = address.PostalCode;
      dbAddress.UpdatedAt = DateTime.Now;

      await _unitOfWork.SaveChangesAsync();
      return RedirectToAction("Index");
    }

    [HttpPost("Delete/{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
      await _addressService.DeleteUserAddress(id);
      await _unitOfWork.SaveChangesAsync();
      return RedirectToAction("Index");
    }

  }
}
