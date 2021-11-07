using System;
using BrainGame.Db.Entities;
using BrainGame.WebDb;

namespace BrainGame.Logic
{
    public class Service : IService
    {
        private readonly IRepository _repository;

        public Service(IRepository repository)
        {
            _repository = repository;
        }

        public Register Register(Register register)
        {
            return _repository.Register(register);
        }

        public User Login(Login login)
        {
            return _repository.Login(login);
        }

        public User User()
        {
            return _repository.User();
        }

        public void Update(User user)
        {
            _repository.Update(user);
        }

        public void Remove()
        {
            _repository.Remove();
        }
    }
}
