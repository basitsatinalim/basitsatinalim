using basitsatinalimuyg.Dtos;
using basitsatinalimuyg.Entities;
using basitsatinalimuyg.Models;

namespace basitsatinalimuyg.Services.Abstraction
{
	public interface IUserService
	{
		Task<ICollection<User?>> GetAllUsers();
		Task<UserViewModel?> GetUserById(Guid id);
		Task<User?> GetUserByIdAsEntity(Guid id);
		Task<User?> CreateUser(User user);
		Task<UserViewModel> UpdateUser(User user);
		Task<UserViewModel> DeleteUser(User user);
		Task<UserViewModel?> GetUserByEmail(string? email);
		Task<ICollection<AddressViewModel>> GetUserAdresses(Guid id);
		Task<Address?> GetAddressByIdAsEntity(Guid id);
		Task<User?> GetUserByEmailAsEntity(string? email);
		Task AddUserAddress(Guid userId, AddresDto userAddress);
		Task DeleteUserAddress(Guid userId, Guid addressId);
		Task UpdateUserAddress(Guid userId, AddresDto userAddress);
	}
}
