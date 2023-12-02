using AutoMapper;
using basitsatinalimuyg.Config;
using basitsatinalimuyg.Context;
using basitsatinalimuyg.Dtos;
using basitsatinalimuyg.Entities;
using basitsatinalimuyg.Models;
using basitsatinalimuyg.Repositories.Abstraction;
using basitsatinalimuyg.Services.Abstraction;

namespace basitsatinalimuyg.Services
{
  public class AddressService : IAddressService
  {
    private readonly IUserRepository _userRepository;
    private readonly IAdressRepository _addressRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AddressService(IUserRepository userRepository, IAdressRepository adressRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
      _userRepository = userRepository;
      _addressRepository = adressRepository;
      _unitOfWork = unitOfWork;
      _mapper = mapper;
    }

    public async Task<Address?> GetAddressByIdAsEntity(Guid id)
    {
      return await _addressRepository.GetAsync(id);
    }

    public async Task<ICollection<AddressViewModel>> GetUserAdresses(Guid id)
    {
      return _mapper.CastListObject<AddressViewModel, ICollection<Address>>(await _addressRepository.GetAllAsync(id));
    }

    public async Task AddUserAddress(Guid userId, AddresDto userAddress)
    {
      var user = await _userRepository.GetAsync(userId) ?? throw new Exception("User not found");

      var address = _mapper.Map<Address>(userAddress);

      address.UserId = userId;
      address.User = user;

      await _addressRepository.AddAsync(address);
      await _unitOfWork.SaveChangesAsync();

    }

    public async Task DeleteUserAddress(Guid addressId)
    {

      var address = await _addressRepository.GetAsync(addressId) ?? throw new Exception("Address not found");

      _addressRepository.Delete(address);
      await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateUserAddress(Guid userId, AddresDto userAddress)
    {
      var user = await _userRepository.GetAsync(userId)
      ?? throw new Exception("User not found");

      var address = await _addressRepository.GetAsync(userAddress.Id ?? Guid.Empty) ?? throw new Exception("Address not found");

      address = _mapper.Map(userAddress, address);

      _addressRepository.Update(address);
      await _unitOfWork.SaveChangesAsync();
    }

    public async Task<ICollection<Address>> GetAllAddressAsync()
    {
      return await _addressRepository.GetAllAsync();
    }
  }
}
