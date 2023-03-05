using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ToDoApp.DbContexts;
using ToDoApp.Models;
using ToDoApp.Models.Dtos;

namespace ToDoApp.Repository
{
	public class UserRepository : IUserRepository
	{
		private readonly AppDbContext _db;
		private IMapper _mapper;

		public UserRepository(AppDbContext db, IMapper mapper)
		{
			_db = db;
			_mapper = mapper;
		}
		public async Task<UserDto> CreateUser(UserDto userDto)
		{
			User user = _mapper.Map<User>(userDto);
			_db.Users.Add(user);

			await _db.SaveChangesAsync();
			_db.Entry(user).State = EntityState.Detached;

			return _mapper.Map<UserDto>(user);

		}

		public Task<bool> DeleteUser(Guid userId)
		{
			throw new NotImplementedException();
		}

		public async Task<UserDto> GetUser(UserSignedInDto userSignedInDto)
		{
            User user = await _db.Users
				.Include(b => b.Scheduler)
				.Include(c => c.Projects).ThenInclude(e => e.Duties)
				.Include(d => d.Events)
				.Where(x => x.Login == userSignedInDto.Login && x.Password == userSignedInDto.Password)
				.AsNoTracking()
				.FirstOrDefaultAsync();
            return _mapper.Map<UserDto>(user);
		}

        public async Task<UserDto> GetUserById(Guid userId)
        {
            User user = await _db.Users
				.Include(b => b.Scheduler)
				.Include(c => c.Projects).ThenInclude(e => e.Duties)
				.Include(d => d.Events)
				.Where(x => x.UserId == userId)
				.AsNoTracking()
				.FirstOrDefaultAsync();
            return _mapper.Map<UserDto>(user);
        }

        public Task<IEnumerable<UserDto>> GetUsers()
		{
			throw new NotImplementedException();
		}

		public async Task<UserDto> UpdateUser(UserDto userDto)
		{
			User userToUpdate = _db.Users.Where(x => x.UserId == userDto.UserId).AsNoTracking().FirstOrDefault();

			userToUpdate.FirstName = userDto.FirstName;
			userToUpdate.LastName = userDto.LastName;
			userToUpdate.EmailAddress = userDto.EmailAddress;
			userToUpdate.PhoneNumber = userDto.PhoneNumber;

			_db.Users.Update(userToUpdate);

			await _db.SaveChangesAsync();

			return _mapper.Map<UserDto>(userToUpdate);
		}
	}
}
