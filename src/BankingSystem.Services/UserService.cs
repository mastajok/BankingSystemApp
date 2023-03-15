using BankingSystem.Contracts;
using BankingSystem.Data.Entities;
using BankingSystem.DataAccess.Contracts;
using BankingSystem.Dtos;

namespace BankingSystem.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDto> CreateUser(UserDto user)
        {
            await _userRepository.Create(new User()
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName
            });

            var createdUser = await _userRepository.GetUser(user.Email);

            return new UserDto()
            {
                Email = createdUser.Email,
                FirstName = createdUser.FirstName,
                LastName = createdUser.LastName
            };
        }
    }
}
