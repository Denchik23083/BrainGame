using BrainGame.Core.Exceptions;
using BrainGame.WebDb.UsersRepository.AdminRepository;
using BrainGame.WebDb.UsersRepository.GodRepository;
using BrainGame.WebDb.UsersRepository.UserRepository;

namespace BrainGame.Logic.UsersService.GodService
{
    public class GodService : IGodService
    {
        private readonly IGodRepository _repository;
        private readonly IAdminRepository _adminRepository;
        private readonly IUserRepository _userRepository;

        public GodService(IGodRepository repository, IAdminRepository adminRepository, IUserRepository userRepository)
        {
            _repository = repository;
            _adminRepository = adminRepository;
            _userRepository = userRepository;
        }

        public async Task UserToAdmin(int id)
        {
            var adminRoleId = 2;

            var userToAdmin = await _userRepository.GetUser(id);

            if (userToAdmin is null)
            {
                throw new UserNotFoundException("User not found");
            }

            userToAdmin.RoleId = adminRoleId;

            await _repository.UserToAdmin(userToAdmin);
        }

        public async Task AdminToUser(int id)
        {
            var userRoleId = 3;

            var adminToUser = await _adminRepository.GetAdmin(id);

            if (adminToUser is null)
            {
                throw new AdminNotFoundException("Admin not found");
            }

            adminToUser.RoleId = userRoleId;

            await _repository.AdminToUser(adminToUser);
        }
    }
}
