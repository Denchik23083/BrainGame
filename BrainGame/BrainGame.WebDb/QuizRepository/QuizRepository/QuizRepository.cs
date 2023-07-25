using BrainGame.Db;
using BrainGame.Db.Entities.Quiz;
using Microsoft.EntityFrameworkCore;

namespace BrainGame.WebDb.QuizRepository.QuizRepository
{
    public class QuizRepository : IQuizRepository
    {
        private readonly BrainGameContext _context;

        public QuizRepository(BrainGameContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Quizzes>> GetQuizzes()
        {
            return await _context.Quizzes.ToListAsync();
        }
    }
}