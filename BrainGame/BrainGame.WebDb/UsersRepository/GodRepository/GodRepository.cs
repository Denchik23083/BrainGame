using BrainGame.Db;
using BrainGame.Db.Entities.Auth;

namespace BrainGame.WebDb.UsersRepository.GodRepository
{
    public class GodRepository : IGodRepository
    {
        private readonly BrainGameContext _context;

        public GodRepository(BrainGameContext context)
        {
            _context = context;
        }

        public async Task UserToAdmin(User userToAdmin)
        {
            await _context.SaveChangesAsync();
        }

        public async Task AdminToUser(User adminToUser)
        {
            await _context.SaveChangesAsync();
        }
    }
}
