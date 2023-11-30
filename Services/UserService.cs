using AutoMapper;
using basitsatinalimuyg.Context;
using basitsatinalimuyg.Config;
using basitsatinalimuyg.Dtos;
using basitsatinalimuyg.Entities;
using basitsatinalimuyg.Models;
using basitsatinalimuyg.Repositories.Abstraction;
using basitsatinalimuyg.Services.Abstraction;

namespace basitsatinalimuyg.Services
{
	public class UserService : IUserService
	{
		private readonly IUserRepository _userRepository;
		private readonly IAdressRepository _adressRepository;
		private readonly IMapper _mapper;
		private readonly IUnitOfWork _unitOfWork;


		public UserService(IUserRepository userRepository, IAdressRepository adressRepository, IUnitOfWork unitOfWork, IMapper mapper)
		{
			_userRepository = userRepository;
			_adressRepository = adressRepository;
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}


		public async Task<User?> CreateUser(User user)
		{
			if (user == null) return null;
			var savedUser = await _userRepository.AddAsync(user);
			await _unitOfWork.SaveChangesAsync();
			return savedUser;
		}

		public Task<UserViewModel> DeleteUser(User user)
		{
			throw new NotImplementedException();
		}

		public Task<ICollection<User?>> GetAllUsers()
		{
			throw new NotImplementedException();
		}

		public async Task<UserViewModel?> GetUserByEmail(string? email)
		{
			return _mapper.Map<UserViewModel>(await _userRepository.GetUserByEmail(email));
		}

		public async Task<ICollection<AddressViewModel>> GetUserAdresses(Guid id)
		{
			return _mapper.CastListObject<AddressViewModel, ICollection<Address>>(await _adressRepository.GetAllAsync(id));
		}

		public async Task<UserViewModel?> GetUserById(Guid id)
		{
			return _mapper.Map<UserViewModel>(await _userRepository.GetAsync(id));
		}

		public async Task<UserViewModel> UpdateUser(User user)
		{
			var updatedUser = _userRepository.Update(user);
			await _unitOfWork.SaveChangesAsync();
			return _mapper.Map<UserViewModel>(updatedUser);
		}

		public async Task<User?> GetUserByIdAsEntity(Guid id)
		{
			var user = await _userRepository.GetAsync(id);

			return user;
		}

		public async Task<Address?> GetAddressByIdAsEntity(Guid id)
		{
			return await _adressRepository.GetAsync(id);
		}

		public async Task<User?> GetUserByEmailAsEntity(string? email)
		{
			return await _userRepository.GetUserByEmail(email);
		}

		public async Task AddUserAddress(Guid userId, AddresDto userAddress)
		{
			var user = await _userRepository.GetAsync(userId) ?? throw new Exception("User not found");

			var address = _mapper.Map<Address>(userAddress);

			address.UserId = userId;
			address.User = user;

			await _adressRepository.AddAsync(address);
			await _unitOfWork.SaveChangesAsync();

		}

		public async Task DeleteUserAddress(Guid userId, Guid addressId)
		{
			var user = await _userRepository.GetAsync(userId)
			?? throw new Exception("User not found");

			var address = await _adressRepository.GetAsync(addressId) ?? throw new Exception("Address not found");

			_adressRepository.Delete(address);
			await _unitOfWork.SaveChangesAsync();
		}

		public async Task UpdateUserAddress(Guid userId, AddresDto userAddress)
		{
			var user = await _userRepository.GetAsync(userId)
			?? throw new Exception("User not found");

			var address = await _adressRepository.GetAsync(userAddress.Id ?? Guid.Empty) ?? throw new Exception("Address not found");

			address = _mapper.Map(userAddress, address);

			_adressRepository.Update(address);
			await _unitOfWork.SaveChangesAsync();
		}

	}
}
