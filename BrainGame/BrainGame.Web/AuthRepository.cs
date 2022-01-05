using System.Threading.Tasks;
using BrainGame.Db;
using BrainGame.Db.Entities;
using Microsoft.EntityFrameworkCore;

namespace BrainGame.WebDb
{
    public class AuthRepository : IAuthRepository
    {
        private readonly BrainGameContext _context;

        public AuthRepository(BrainGameContext context)
        {
            _context = context;
        }

        public async Task<Register> Register(Register register)
        {
            await _context.Users.AddAsync(Map(register));
            await _context.SaveChangesAsync();

            return register;
        }

        public async Task<User> Login(Login login)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(b =>
                    b.Email == login.Email &&
                    b.Password == login.Password);

            return user;
        }
        private User Map(Register model)
        {
            return new User
            {
                Id = model.Id,
                Name = model.Name,
                Email = model.Email,
                Password = model.Password,
            };
        }
    }
}
