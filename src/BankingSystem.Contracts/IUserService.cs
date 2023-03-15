using BankingSystem.Dtos;

namespace BankingSystem.Contracts
{
    public interface IUserService
    {
        Task<UserDto> CreateUser(UserDto user);
    }
}
