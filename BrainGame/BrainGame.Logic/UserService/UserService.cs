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

        public async Task<User> GetUser()
        {
            var user = AuthService.AuthService.User;

            if (user is null)
            {
                throw new ArgumentNullException();
            }

            return await _repository.GetUser(user);
        }

        public async Task Update(User user)
        {
            var userToUpdate = await _repository.GetUser(AuthService.AuthService.User);

            if (userToUpdate is null)
            {
                throw new ArgumentNullException();
            }

            await _repository.Update(userToUpdate, user);
        }

        public async Task Remove()
        {
            var userToRemove = await _repository.GetUser(AuthService.AuthService.User);

            if (userToRemove is null)
            {
                throw new ArgumentNullException();
            }

            await _repository.Remove(userToRemove);
        }

        public async Task Password(Password model)
        {
            var userToUpdate = await _repository.GetUser(AuthService.AuthService.User);

            if (userToUpdate is null)
            {
                throw new ArgumentNullException();
            }

            await _repository.Password(userToUpdate, model);
        }
    }
}