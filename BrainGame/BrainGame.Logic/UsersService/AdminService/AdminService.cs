using BrainGame.Core.Exceptions;
using BrainGame.Db.Entities.Auth;
using BrainGame.WebDb.UsersRepository.AdminRepository;
using BrainGame.WebDb.UsersRepository.UserRepository;

namespace BrainGame.Logic.UsersService.AdminService
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _repository;
        private readonly IUserRepository _userRepository;

        public AdminService(IAdminRepository repository, IUserRepository userRepository)
        {
            _repository = repository;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetAllAdminsAsync()
        {
            var roleId = 2;

            var admins = await _repository.GetAllAdminsAsync(roleId);

            if (admins is null)
            {
                throw new GenderNotFoundException("Admins not found");
            }

            return admins;
        }

        public async Task RemoveUserAsync(int id)
        {
            var userToRemove = await _userRepository.GetUserAsync(id);

            if (userToRemove is null)
            {
                throw new UserNotFoundException("User not found");
            }

            await _repository.RemoveUserAsync(userToRemove);
        }
    }
}
