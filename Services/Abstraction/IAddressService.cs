using basitsatinalimuyg.Dtos;
using basitsatinalimuyg.Entities;
using basitsatinalimuyg.Models;

namespace basitsatinalimuyg.Services.Abstraction
{
  public interface IAddressService
  {
    Task<ICollection<AddressViewModel>> GetUserAdresses(Guid id);
    Task<Address?> GetAddressByIdAsEntity(Guid id);
    Task AddUserAddress(Guid userId, AddresDto userAddress);
    Task DeleteUserAddress(Guid addressId);
    Task UpdateUserAddress(Guid userId, AddresDto userAddress);
    Task<ICollection<Address>> GetAllAddressAsync();


  }
}
