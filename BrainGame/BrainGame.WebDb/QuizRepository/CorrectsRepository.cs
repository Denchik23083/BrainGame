using BrainGame.Db;
using BrainGame.Db.Entities.Quiz;
using Microsoft.EntityFrameworkCore;

namespace BrainGame.WebDb.QuizRepository
{
    public class CorrectsRepository : ICorrectsRepository
    {
        private readonly BrainGameContext _context;

        public CorrectsRepository(BrainGameContext context)
        {
            _context = context;
        }

        public async Task<Correct> Correct(int id)
        {
            return (await _context.Corrects.FirstOrDefaultAsync(b => b.Id == id))!;
        }
    }
}