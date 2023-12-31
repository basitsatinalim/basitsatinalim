﻿using AutoMapper;
using basitsatinalimuyg.Context;
using basitsatinalimuyg.Entities;
using basitsatinalimuyg.Models;
using basitsatinalimuyg.Repositories.Abstraction;
using basitsatinalimuyg.Services.Abstraction;

namespace basitsatinalimuyg.Services
{
	public class UserService : IUserService
	{
		private readonly IUserRepository _userRepository;

		private readonly IMapper _mapper;
		private readonly IUnitOfWork _unitOfWork;


		public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork, IMapper mapper)
		{
			_userRepository = userRepository;
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

		public async Task<User?> GetUserByEmailAsEntity(string? email)
		{
			return await _userRepository.GetUserByEmail(email);
		}

	}
}
