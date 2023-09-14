using BrainGame.Db;
using BrainGame.Db.Entities.Quiz;
using Microsoft.EntityFrameworkCore;

namespace BrainGame.WebDb.QuizRepository.CorrectRepository
{
    public class CorrectRepository : ICorrectRepository
    {
        private readonly BrainGameContext _context;

        public CorrectRepository(BrainGameContext context)
        {
            _context = context;
        }

        public async Task<Correct?> CorrectAsync(int id)
        {
            return await _context.Corrects.FirstOrDefaultAsync(b => b.QuestionId == id);
        }
    }
}