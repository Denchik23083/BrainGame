using BrainGame.Core.Exceptions;
using BrainGame.Core.Utilities;
using BrainGame.Db.Entities.Auth;
using BrainGame.WebDb.UsersRepository.UserRepository;

namespace BrainGame.Logic.UsersService.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            var roleId = 3;

            var users = await _repository.GetUsersAsync(roleId);

            if (users is null)
            {
                throw new UserNotFoundException("Users not found");
            }

            return users;
        }

        public async Task<IEnumerable<Gender>> GetGendersAsync()
        {
            var genders = await _repository.GetGendersAsync();

            if (genders is null)
            {
                throw new GenderNotFoundException("Genders not found");
            }

            return genders;
        }

        public async Task EditUserAsync(User user, int id)
        {
            var userToUpdate = await _repository.GetUserAsync(id);

            if (userToUpdate is null)
            {
                throw new UserNotFoundException("User not found");
            }

            userToUpdate.Name = user.Name;
            userToUpdate.Email = user.Email;

            await _repository.EditUserAsync(userToUpdate);
        }

        public async Task EditPasswordAsync(Password password, int id)
        {
            var userToUpdate = await _repository.GetUserAsync(id);

            if (userToUpdate is null)
            {
                throw new UserNotFoundException("User not found");
            }

            if (userToUpdate.Password == password.OldPassword
                && password.NewPassword == password.ConfirmPassword)
            {
                userToUpdate.Password = password.NewPassword;

                await _repository.EditPasswordAsync(userToUpdate);
            }
        }
    }
}