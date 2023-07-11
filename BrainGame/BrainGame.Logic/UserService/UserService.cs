using BrainGame.Core.Exceptions;
using BrainGame.Core.Utilities;
using BrainGame.Db.Entities.Auth;
using BrainGame.WebDb.UserRepository;

namespace BrainGame.Logic.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<User> GetUser(string userEmail)
        {
            var user = await _repository.GetUser(userEmail);

            if (user is null)
            {
                throw new UserNotFoundException("User not found");
            }

            return user;
        }

        public async Task<IEnumerable<Gender>> GetGenders()
        {
            var genders = await _repository.GetGenders();

            if (genders is null)
            {
                throw new GenderNotFoundException("genders not found");
            }

            return genders;
        }

        public async Task EditUser(User user, string userEmail)
        {
            var userToUpdate = await _repository.GetUser(userEmail);

            if (userToUpdate is null)
            {
                throw new UserNotFoundException("User not found");
            }

            userToUpdate.Name = user.Name;
            userToUpdate.Email = user.Email;

            await _repository.EditUser(userToUpdate);
        }

        public async Task EditPassword(Password password, string userEmail)
        {
            var userToUpdate = await _repository.GetUser(userEmail);

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

        public async Task RemoveUser(int id)
        {
            var userToRemove = await _repository.GetUser(id);

            if (userToRemove is null)
            {
                throw new UserNotFoundException("User not found");
            }

            await _repository.RemoveUser(userToRemove);
        }
    }
}