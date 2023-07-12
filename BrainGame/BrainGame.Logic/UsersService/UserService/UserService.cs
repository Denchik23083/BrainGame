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

        public async Task<IEnumerable<User>> GetUsers()
        {
            var roleId = 3;

            var users = await _repository.GetUsers(roleId);

            if (users is null)
            {
                throw new UserNotFoundException("Users not found");
            }

            return users;
        }

        public async Task<IEnumerable<Gender>> GetGenders()
        {
            var genders = await _repository.GetGenders();

            if (genders is null)
            {
                throw new GenderNotFoundException("Genders not found");
            }

            return genders;
        }

        public async Task<User> GetUser(int id)
        {
            var user = await _repository.GetUser(id);

            if (user is null)
            {
                throw new UserNotFoundException("User not found");
            }

            return user;
        }

        public async Task EditUser(User user, int id)
        {
            var userToUpdate = await _repository.GetUser(id);

            if (userToUpdate is null)
            {
                throw new UserNotFoundException("User not found");
            }

            userToUpdate.Name = user.Name;
            userToUpdate.Email = user.Email;

            await _repository.EditUser(userToUpdate);
        }

        public async Task EditPassword(Password password, int id)
        {
            var userToUpdate = await _repository.GetUser(id);

            if (userToUpdate is null)
            {
                throw new UserNotFoundException("User not found");
            }

            if (userToUpdate.Password == password.OldPassword
                && password.NewPassword == password.ConfirmPassword)
            {
                userToUpdate.Password = password.NewPassword;

                await _repository.EditPassword(userToUpdate);
            }
        }
    }
}