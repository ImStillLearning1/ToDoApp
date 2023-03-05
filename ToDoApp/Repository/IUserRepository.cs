using System.Collections.Generic;
using ToDoApp.Models.Dtos;

namespace ToDoApp.Repository
{
	public interface IUserRepository
	{
		Task<UserDto> CreateUser(UserDto userDto);
		Task<UserDto> UpdateUser(UserDto userDto);
		Task<bool> DeleteUser(Guid userId);
		Task<IEnumerable<UserDto>> GetUsers();
		Task<UserDto> GetUser(UserSignedInDto userSignedInDto);
        Task<UserDto> GetUserById(Guid userId);
    }
}
