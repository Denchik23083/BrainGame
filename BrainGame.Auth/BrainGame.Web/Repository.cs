using System;
using BrainGame.Db;
using BrainGame.Db.Entities;

namespace BrainGame.WebDb
{
    public class Repository : IRepository 
    {
        private readonly BrainGameContext _context;

        public Repository(BrainGameContext context)
        {
            _context = context;
        }

        public Register Register(Register register)
        {
            if (register.Password != register.ConfirmPassword)
            {
                throw new ArgumentException();
            }

            _context.Registers.Add(register);
            _context.SaveChanges();
            return register;
        }
    }
}
