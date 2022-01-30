using System;
using System.Threading.Tasks;
using BrainGame.Db;
using BrainGame.Db.Entities;
using BrainGame.WebDb.AuthRepository;

namespace BrainGame.Logic.AuthService
{
    public class UserService : IUserService
    {
        private readonly BrainGameContext _context;
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository, BrainGameContext context)
        {
            _context = context;
            _repository = repository;
        }

        public User Get()
        {
            var user = AuthService._user;

            _repository.Get(user);

            return user;
        }

        public async Task Update(User user)
        {
            var userToUpdate = await _repository.Update(AuthService._user);

            if (userToUpdate is null)
            {
                throw new ArgumentNullException();
            }

            userToUpdate.Name = user.Name;
            userToUpdate.Email = user.Email;

            _context.Users.Update(userToUpdate);
            await _context.SaveChangesAsync();
        }

        public async Task Password(User model)
        {
            var userToUpdate = await _repository.Update(AuthService._user);

            if (userToUpdate is null)
            {
                throw new ArgumentNullException();
            }

            userToUpdate.Password = model.Password;

            _context.Users.Update(userToUpdate);
            await _context.SaveChangesAsync();
        }

        public async Task Remove()
        {
            var id = AuthService._user.Id;
            await _repository.Remove(id);
        }
    }
}